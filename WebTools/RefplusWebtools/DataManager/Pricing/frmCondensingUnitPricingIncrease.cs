using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmCondensingUnitPricingIncrease : Form
    {
        public FrmCondensingUnitPricingIncrease()
        {
            InitializeComponent();
        }

        private void frmCondensingUnitPricingIncrease_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_Serie();

            Fill_CompressorManufacturer();

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

        private string GetSerieUnitType()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[0];
        }

        private string GetSerieAirFlow()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[1];
        }

        private string GetSerieCompressorType()
        {
            return ComboBoxControl.IndexInformation(cboSerie).Split(',')[2];
        }

        private void Fill_Serie()
        {
            DataTable dtSeries = Query.Select("SELECT DISTINCT UnitType, AirFlow, CompressorType FROM CondensingUnitModel ORDER BY UnitType, AirFlow, CompressorType");

            cboSerie.Items.Clear();

            for (int i = 0; i < dtSeries.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboSerie, dtSeries.Rows[i]["UnitType"] + "," + dtSeries.Rows[i]["AirFlow"] + "," + dtSeries.Rows[i]["CompressorType"], dtSeries.Rows[i]["UnitType"] + dtSeries.Rows[i]["AirFlow"].ToString() + dtSeries.Rows[i]["CompressorType"]);
            }

            cboSerie.SelectedIndex = 0;
        }

        private string GetCompressorManufacturer()
        {
            return ComboBoxControl.IndexInformation(cboCompressorManufacturer);
        }

        private void Fill_CompressorManufacturer()
        {
            DataTable dtCompressorManufacturer = Query.Select("SELECT DISTINCT cucm.CompressorManufacturerParameter, cucm.CompressorManufacturer FROM CondensingUnitModel as cum LEFT JOIN CondensingUnitCompressorManufacturer as cucm ON cum.CompressorManufacturer = cucm.CompressorManufacturerParameter");

            cboCompressorManufacturer.Items.Clear();

            for (int i = 0; i < dtCompressorManufacturer.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboCompressorManufacturer, dtCompressorManufacturer.Rows[i]["CompressorManufacturerParameter"].ToString(), dtCompressorManufacturer.Rows[i]["CompressorManufacturer"].ToString());
            }

            cboCompressorManufacturer.SelectedIndex = 0;
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
            ThreadProcess.Start(Public.LanguageString("Loading model list", "Chargement de la liste des mod�les"));
            lvReview.Items.Clear();
            lvReview.Refresh();

            string unitType = GetSerieUnitType();
            string airFlow = GetSerieAirFlow();
            string compressorType = GetSerieCompressorType();
            string compressorManufacturer = GetCompressorManufacturer();

            DataTable dtModels = Query.Select("SELECT Model, Price FROM CondensingUnitModel WHERE UnitType = '" + unitType + "' AND AirFlow = '" + airFlow + "' AND CompressorType = '" + compressorType + "' AND CompressorManufacturer = " + compressorManufacturer + " ORDER BY Model");

            for (int i = 0; i < dtModels.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvReview);

                myItem.SubItems[0].Text = dtModels.Rows[i]["Model"].ToString();
                myItem.SubItems[1].Text = Convert.ToDecimal(dtModels.Rows[i]["Price"]).ToString("N2");
                myItem.SubItems[2].Text = "0";
                myItem.SubItems[3].Text = "0";

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
                var confirmation = new FrmConfirmPriceChange(lvReview.Items.Count, Public.LanguageString("Models", "Mod�les"));
                
                if (confirmation.ShowDialog() == DialogResult.Yes)
                {
                    UpdatePrices(confirmation.GetReason());
                }
            }
            else
            {
                Public.LanguageBox("There is no model to update", "Il n'y a pas de mod�le � modifier.");
            }
        }

        private void UpdatePrices(string strReason)
        {
            ThreadProcess.Start(Public.LanguageString("Saving in progress", "Sauvegarde en cours"));

            string serverDate = Public.GetServerDate().ToString(CultureInfo.InvariantCulture);
            
            for (int i = 0; i < lvReview.Items.Count; i++)
            {
                string tsql = "";

                tsql += " UPDATE CondensingUnitModel SET Price = " + Convert.ToDecimal(lvReview.Items[i].SubItems[2].Text) + " WHERE Model = '" + lvReview.Items[i].SubItems[0].Text + "'";
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

            Query.UpdateServerTableVersion("CondensingUnitModel");

            ThreadProcess.Stop();
            Focus();

            Public.LanguageBox("Saving complete", "Sauvegarde complet�e");

            GoBackToSerieSelection();
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

        private void GoBackToSerieSelection()
        {
            tabParent.TabPages.Remove(tabReview);
            tabParent.TabPages.Add(tabChoose);

            lvReview.Items.Clear();
            lvReview.Refresh();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            GoBackToSerieSelection();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmCondensingUnitPricingIncrease_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void lvReview_Click(object sender, EventArgs e)
        {

        }
    }
}