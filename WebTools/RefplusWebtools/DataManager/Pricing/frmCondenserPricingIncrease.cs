using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmCondenserPricingIncrease : Form
    {
        public FrmCondenserPricingIncrease()
        {
            InitializeComponent();
        }

        private void frmCondenserPricingIncrease_Load(object sender, EventArgs e)
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

        private string GetSerieType()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[0];
        }

        private string GetSerieMotor()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[1];
        }

        private string GetSerieCoilArr()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[2];
        }

        private void Fill_Serie()
        {
            DataTable dtSeries = Query.Select("SELECT DISTINCT CondenserType as Type, Motor, CoilArr FROM CondenserXref WHERE convert(nvarchar,Motor)+convert(nvarchar,CoilArr) IN (SELECT convert(nvarchar,Motor)+convert(nvarchar,CoilArr) FROM CondenserSerie WHERE Sites LIKE '%" + UserInformation.CurrentSite + "%') ORDER BY Type, Motor, CoilArr");

            cboSerie.Items.Clear();

            for (int i = 0; i < dtSeries.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboSerie, dtSeries.Rows[i]["Type"] + "," + dtSeries.Rows[i]["Motor"] + "," + dtSeries.Rows[i]["CoilArr"], dtSeries.Rows[i]["Type"] + dtSeries.Rows[i]["Motor"].ToString().Replace("S", "V") + dtSeries.Rows[i]["CoilArr"] + (dtSeries.Rows[i]["Motor"].ToString() == "S" ? "-L" : ""));
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

            string type = GetSerieType();
            string motor = GetSerieMotor();
            string coilArr = GetSerieCoilArr();

            //add special code to handle S
            DataTable dtModels = Query.Select("SELECT * FROM CondenserXref WHERE CondenserType = '" + type + "' AND Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' ORDER BY CondenserType, Motor, CoilArr, FanWide, FanLong, Row, FPI, Airflow");

            for (int i = 0; i < dtModels.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvReview);

                myItem.SubItems[0].Text = dtModels.Rows[i]["REFPLUS_CondenserXRefModel"] + " - " +
                                          dtModels.Rows[i]["ECOSAIRE_CondenserXRefModel"] + " - " +
                                          dtModels.Rows[i]["DECTRON_CondenserXRefModel"] + " - " +
                                          dtModels.Rows[i]["CIRCULAIRE_CondenserXRefModel"];
                myItem.SubItems[1].Text = Convert.ToDecimal(dtModels.Rows[i]["Price"]).ToString("N2");
                myItem.SubItems[2].Text = "0";
                myItem.SubItems[3].Text = "0";
                myItem.SubItems[4].Text = dtModels.Rows[i]["CondenserType"] + "," +
                                          dtModels.Rows[i]["Motor"] + "," +
                                          dtModels.Rows[i]["CoilArr"] + "," +
                                          dtModels.Rows[i]["FanWide"] + "," +
                                          dtModels.Rows[i]["FanLong"] + "," +
                                          dtModels.Rows[i]["Row"] + "," +
                                          dtModels.Rows[i]["FPI"] + "," +
                                          dtModels.Rows[i]["AirFlow"];

                lvReview.Items.Add(myItem);
            }

            ThreadProcess.UpdateMessage(Public.LanguageString("Calculating new prices", "Calculation des nouveaux prix"));

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

                tsql += " UPDATE CondenserXref SET Price = " + Convert.ToDecimal(lvReview.Items[i].SubItems[2].Text) + " WHERE " + GetWhereClause(i);
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
                           ('" + lvReview.Items[i].SubItems[4].Text + @"'
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

            Query.UpdateServerTableVersion("CondenserXref");

            ThreadProcess.Stop();
            Focus();

            Public.LanguageBox("Saving complete", "Sauvegarde complétée");

            GoBackToSerieSelection();

        }

        private string GetWhereClause(int listRowIndex)
        {
            string[] splitModel = lvReview.Items[listRowIndex].SubItems[4].Text.Split(',');

            string strType = splitModel[0];
            string strMotor = splitModel[1];
            string strCoilArr = splitModel[2];
            string strFanWide = splitModel[3];
            string strFanLong = splitModel[4];
            string strRow = splitModel[5];
            string strFPI = splitModel[6];
            string strAirFlow = splitModel[7];

            string strWhereClause = "";

            strWhereClause += " CondenserType = '" + strType + "'";
            strWhereClause += " AND Motor = '" + strMotor + "'";
            strWhereClause += " AND CoilArr = '" + strCoilArr + "'";
            strWhereClause += " AND FanWide = " + strFanWide;
            strWhereClause += " AND FanLong = " + strFanLong;
            strWhereClause += " AND Row = " + strRow;
            strWhereClause += " AND FPI = " + strFPI;
            strWhereClause += " AND AirFlow = '" + strAirFlow + "'";

            return strWhereClause;
        }


        private decimal GetCalculatedFactor(int listRowIndex)
        {
            decimal oldPrice = Convert.ToDecimal(lvReview.Items[listRowIndex].SubItems[1].Text);
            decimal newPrice = Convert.ToDecimal(lvReview.Items[listRowIndex].SubItems[2].Text);

            //ex: 4000 became 2000 (-50%)
            // ((2000 / 4000) - 1) * 100
            // (0.5 - 1) * 100
            // -0.5 * 100 = -50%

            //inverse 2000 became 4000 (100%)
            // ((4000 / 2000) - 1) * 100
            // (2 - 1) * 100
            // 1 * 100 = 100%

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

        private void frmCondenserPricingIncrease_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}