using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmGravityCoilPricingIncrease : Form
    {
        public FrmGravityCoilPricingIncrease()
        {
            InitializeComponent();
        }

        private void frmGravityCoilPricingIncrease_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_Serie();

            HideTabs();
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void HideTabs()
        {
            tabParent.TabPages.Remove(tabReview);
        }

        private string GetSerieEvaporator()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[0];
        }

        private string GetSerieGravity()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[1];
        }

        private string GetSerieAirDefrost()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[2];
        }

        private void Fill_Serie()
        {
            DataTable dtSeries = Query.Select("SELECT DISTINCT Evaporator, Gravity, AirDefrost FROM GravityCoil ORDER BY Evaporator, Gravity, AirDefrost");

            cboSerie.Items.Clear();

            for (int i = 0; i < dtSeries.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboSerie, dtSeries.Rows[i]["Evaporator"] + "," + dtSeries.Rows[i]["Gravity"] + "," + dtSeries.Rows[i]["AirDefrost"], dtSeries.Rows[i]["Evaporator"] + dtSeries.Rows[i]["Gravity"].ToString() + dtSeries.Rows[i]["AirDefrost"]);
            }

            cboSerie.SelectedIndex = 0;
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            tabParent.TabPages.Remove(tabChoose);
            tabParent.TabPages.Add(tabReview);

            LoadModels();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadModels()
        {
            ThreadProcess.Start(Public.LanguageString("Loading model list", "Chargement de la liste des modèles"));
            lvReview.Items.Clear();
            lvReview.Refresh();

            string type = GetSerieEvaporator();
            string style = GetSerieGravity();
            string defrostType = GetSerieAirDefrost();

            DataTable dtModels = Query.Select("SELECT * FROM GravityCoil WHERE Evaporator = '" + type + "' AND Gravity = '" + style + "' AND AirDefrost = '" + defrostType + "' ORDER BY REFPLUS_Model");

            for (int i = 0; i < dtModels.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvReview);

                myItem.SubItems[0].Text = dtModels.Rows[i]["REFPLUS_Model"].ToString();
                myItem.SubItems[1].Text = Convert.ToDecimal(dtModels.Rows[i]["FPIListPrice"]).ToString("N2");
                myItem.SubItems[2].Text = "0";
                myItem.SubItems[3].Text = "0";
                myItem.SubItems[4].Text = dtModels.Rows[i]["Evaporator"] + "," +
                                          dtModels.Rows[i]["Gravity"] + "," +
                                          dtModels.Rows[i]["AirDefrost"] + "," +
                                          dtModels.Rows[i]["FaceTubes"] + "," +
                                          dtModels.Rows[i]["Slab"] + "," +
                                          dtModels.Rows[i]["FPI"] + "," +
                                          dtModels.Rows[i]["FinPattern"] + "," +
                                          dtModels.Rows[i]["FinLength"];

                lvReview.Items.Add(myItem);
            }

            ThreadProcess.UpdateMessage(Public.LanguageString("Calculating new prices", "Calcul des nouveaux prix"));

            decimal factor = GetFactor();

            for (int i = 0; i < lvReview.Items.Count; i++)
            {
                decimal currentPrice = Convert.ToDecimal(lvReview.Items[i].SubItems[1].Text);
                decimal newPrice = currentPrice * factor;

                //rounding. as per Simon answer he wants ceiling
                //Ex : prix de 526 $ Augmentation de 5% = 552.30 $
                //deviens 553.00$

                newPrice = Math.Ceiling(newPrice);

                lvReview.Items[i].SubItems[2].Text = newPrice.ToString("N2");
            }

            lvReview.Refresh();

            ThreadProcess.Stop();
            Focus();
        }

        private decimal GetFactor()
        {
            return 1m + (numFactor.Value / 100m);
        }

        private void lvReview_DoubleClick(object sender, EventArgs e)
        {
            if (lvReview.SelectedItems.Count > 0)
            {
                decimal currentPrice = Convert.ToDecimal(((GlacialComponents.Controls.GLItem)lvReview.SelectedItems[0]).SubItems[1].Text);
                decimal newPrice = Convert.ToDecimal(((GlacialComponents.Controls.GLItem)lvReview.SelectedItems[0]).SubItems[2].Text);
                
                var editprice = new FrmEditPrice(currentPrice, newPrice);

                if (editprice.ShowDialog() == DialogResult.Yes)
                {
                    ((GlacialComponents.Controls.GLItem)lvReview.SelectedItems[0]).SubItems[2].Text = editprice.GetNewPrice().ToString("N2");
                    ((GlacialComponents.Controls.GLItem)lvReview.SelectedItems[0]).SubItems[3].Text = "1";
                    ((GlacialComponents.Controls.GLItem)lvReview.SelectedItems[0]).BackColor = Color.LightBlue;
                }
            }
        }

        private void cmdGoToConfirmation_Click(object sender, EventArgs e)
        {
            if (lvReview.Items.Count > 0)
            {
                var confirmation = new FrmConfirmPriceChange(lvReview.Items.Count, Public.LanguageString("Models", "Modèles"));
                
                if (confirmation.ShowDialog() == DialogResult.Yes)
                {
                    UpdatePrices(confirmation.GetReason());
                }
            }
            else
            {
                Public.LanguageBox("There is no model to update", "Il n'y a pas de modèle à modifier.");
            }
        }

        private void UpdatePrices(string strReason)
        {
            ThreadProcess.Start(Public.LanguageString("Saving in progress", "Sauvegarde en cours"));

            string serverDate = Public.GetServerDate().ToString(CultureInfo.InvariantCulture);
           
            for (int i = 0; i < lvReview.Items.Count; i++)
            {

                string tsql = "";

                tsql += " UPDATE GravityCoil SET FPIListPrice = " + Convert.ToDecimal(lvReview.Items[i].SubItems[2].Text) + " WHERE " + GetWhereClause(i);
                tsql += @" INSERT INTO [PricingChangeLog]
                           ([Model]
                           ,[CurrentPrice]
                           ,[NewPrice]
                           ,[PercentageSelected]
                           ,[PercentageCalculated]
                           ,[UserModified]
                           ,[DateChanged]
                           ,[Reason]
                           ,[Username])
                     VALUES
                           ('" + lvReview.Items[i].SubItems[0].Text + @"'
                           ," + Convert.ToDecimal(lvReview.Items[i].SubItems[1].Text) + @"
                           ," + Convert.ToDecimal(lvReview.Items[i].SubItems[2].Text) + @"
                           ," + numFactor.Value + @"
                           ," + GetCalculatedFactor(i) + @"
                           ," + Convert.ToInt32(lvReview.Items[i].SubItems[3].Text) + @"
                           ,'" + serverDate + @"'
                           ,'" + strReason.Replace("'","''") + @"'
                           ,'" + UserInformation.UserName + @"')";

                Query.Execute(tsql);

            }

            Query.UpdateServerTableVersion("GravityCoil");
            Query.UpdateServerTableVersion("v_SelectGravityCoilModels");

            ThreadProcess.Stop();
            Focus();

            Public.LanguageBox("Saving complete", "Sauvegarde complétée");

            GoBackToSerieSelection();
        }

        private string GetWhereClause(int listRowIndex)
        {
            string[] splitModel = lvReview.Items[listRowIndex].SubItems[4].Text.Split(',');

            string strType = splitModel[0];
            string strGravity = splitModel[1];
            string strAirDefrost = splitModel[2];
            string strFaceTubes = splitModel[3];
            string strSlab = splitModel[4];
            string strFPI = splitModel[5];
            string strFinPattern = splitModel[6];
            string strFinLength = splitModel[7];

            string strWhereClause = "";

            strWhereClause += " Evaporator = '" + strType + "'";
            strWhereClause += " AND Gravity = '" + strGravity + "'";
            strWhereClause += " AND AirDefrost = '" + strAirDefrost + "'";
            strWhereClause += " AND FaceTubes = " + strFaceTubes;
            strWhereClause += " AND Slab = " + strSlab;
            strWhereClause += " AND FPI = " + strFPI;
            strWhereClause += " AND FinPattern = '" + strFinPattern + "'";
            strWhereClause += " AND FinLength = " + strFinLength;

            return strWhereClause;
        }


        private decimal GetCalculatedFactor(int listRowIndex)
        {
            decimal oldPrice = Convert.ToDecimal(lvReview.Items[listRowIndex].SubItems[1].Text);
            decimal newPrice = Convert.ToDecimal(lvReview.Items[listRowIndex].SubItems[2].Text);

            return ((newPrice / oldPrice) - 1m) * 100m;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            GoBackToSerieSelection();
        }

        private void GoBackToSerieSelection()
        {
            tabParent.TabPages.Remove(tabReview);
            tabParent.TabPages.Add(tabChoose);

            lvReview.Items.Clear();
            lvReview.Refresh();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmGravityCoilPricingIncrease_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}