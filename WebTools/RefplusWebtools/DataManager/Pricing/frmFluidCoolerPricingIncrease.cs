using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmFluidCoolerPricingIncrease : Form
    {
        public FrmFluidCoolerPricingIncrease()
        {
            InitializeComponent();
        }

        private void frmFluidCoolerPricingIncrease_Load(object sender, EventArgs e)
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
            DataTable dtSeries = Query.Select("SELECT DISTINCT 'F' as Type, Motor, CoilArr FROM FluidCoolerModel ORDER BY Type, Motor, CoilArr ");

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

            string motor = GetSerieMotor();
            string coilArr = GetSerieCoilArr();

            //add special code to handle S
            DataTable dtModels = Query.Select("SELECT * FROM FluidCoolerModel WHERE Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' ORDER BY Motor, CoilArr, FanWide, FanLong, Row, FPI, Fin, AirFlow");

            for (int i = 0; i < dtModels.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvReview);

                myItem.SubItems[0].Text = dtModels.Rows[i]["REFPLUS_FluidXRefModel"] + "-" +
                                          dtModels.Rows[i]["Fin"] +
                                          dtModels.Rows[i]["Cir1"];
                myItem.SubItems[1].Text = Convert.ToDecimal(dtModels.Rows[i]["Price"]).ToString("N2");
                myItem.SubItems[2].Text = "0";
                myItem.SubItems[3].Text = "0";
                myItem.SubItems[4].Text = dtModels.Rows[i]["Motor"] + "," +
                                          dtModels.Rows[i]["CoilArr"] + "," +
                                          dtModels.Rows[i]["FanWide"] + "," +
                                          dtModels.Rows[i]["FanLong"] + "," +
                                          dtModels.Rows[i]["Row"] + "," +
                                          dtModels.Rows[i]["FPI"] + "," +
                                          dtModels.Rows[i]["Fin"] + "," +
                                          dtModels.Rows[i]["Cir1"]+ "," +
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

                tsql += " UPDATE FluidCoolerModel SET Price = " + Convert.ToDecimal(lvReview.Items[i].SubItems[2].Text) + " WHERE " + GetWhereClause(i);
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
                           ('F," + lvReview.Items[i].SubItems[4].Text + @"'
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

            Query.UpdateServerTableVersion("FluidCoolerModel");

            ThreadProcess.Stop();
            Focus();

            Public.LanguageBox("Saving complete", "Sauvegarde complétée");

            GoBackToSerieSelection();
        }

        private string GetWhereClause(int listRowIndex)
        {
            string[] splitModel = lvReview.Items[listRowIndex].SubItems[4].Text.Split(',');

            string strMotor = splitModel[0];
            string strCoilArr = splitModel[1];
            string strFanWide = splitModel[2];
            string strFanLong = splitModel[3];
            string strRow = splitModel[4];
            string strFPI = splitModel[5];
            string strFinType = splitModel[6];
            string strCir1 = splitModel[7];
            string strAirFlow = splitModel[8];

            string strWhereClause = "";

            strWhereClause += " Motor = '" + strMotor + "'";
            strWhereClause += " AND CoilArr = '" + strCoilArr + "'";
            strWhereClause += " AND FanWide = " + strFanWide;
            strWhereClause += " AND FanLong = " + strFanLong;
            strWhereClause += " AND Row = " + strRow;
            strWhereClause += " AND FPI = " + strFPI;
            strWhereClause += " AND Fin = '" + strFinType + "'";
            strWhereClause += " AND Cir1 = " + strCir1;
            strWhereClause += " AND AirFlow = '" + strAirFlow + "'";

            return strWhereClause;
        }


        private decimal GetCalculatedFactor(int listRowIndex)
        {
            //(COPIED FUNCTION TO MOVE)
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

        private void frmFluidCoolerPricingIncrease_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
       
    }
}