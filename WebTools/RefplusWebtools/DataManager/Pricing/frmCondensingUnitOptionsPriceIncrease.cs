using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmCondensingUnitOptionsPriceIncrease : Form
    {
        public FrmCondensingUnitOptionsPriceIncrease()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            tabParent.TabPages.Remove(tabChoose);
            tabParent.TabPages.Add(tabReview);

            LoadOptions();
        }

        private void LoadOptions()
        {
            ThreadProcess.Start(Public.LanguageString("Loading option list", "Chargement de la liste des options"));
            lvReview.Items.Clear();
            lvReview.Refresh();

            DataTable dtOptions = Query.Select("SELECT * FROM CondensingUnitOptions ORDER BY GroupName, Description");

            for (int i = 0; i < dtOptions.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvReview);

                myItem.SubItems[0].Text = dtOptions.Rows[i]["GroupName"] + " - " + dtOptions.Rows[i]["Description"];
                myItem.SubItems[1].Text = Convert.ToDecimal(dtOptions.Rows[i]["Price"]).ToString("N2");
                myItem.SubItems[2].Text = "0";
                myItem.SubItems[3].Text = "0";
                myItem.SubItems[4].Text = dtOptions.Rows[i]["GroupName"] + "|||" + dtOptions.Rows[i]["Description"];

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

        private void frmCondensingUnitOptionsPriceIncrease_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

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
                Public.LanguageBox("There is no options to update", "Il n'y a pas d'options à modifier.");
            }
        }

        private void UpdatePrices(string strReason)
        {
            ThreadProcess.Start(Public.LanguageString("Saving in progress", "Sauvegarde en cours"));

            string serverDate = Public.GetServerDate().ToString(CultureInfo.InvariantCulture);

            for (int i = 0; i < lvReview.Items.Count; i++)
            {
                string tsql = "";

                tsql += " UPDATE CondensingUnitOptions SET Price = " + Convert.ToDecimal(lvReview.Items[i].SubItems[2].Text) + " WHERE GroupName = '" + lvReview.Items[i].SubItems[4].Text.Split(new[] { "|||" } , StringSplitOptions.None)[0] + "' AND Description = '" + lvReview.Items[i].SubItems[4].Text.Split(new[] { "|||" } , StringSplitOptions.None)[1] + "'";
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
                           ,'" + strReason.Replace("'", "''") + @"'
                           ,'" + UserInformation.UserName + @"')";

                Query.Execute(tsql);

            }

            Query.UpdateServerTableVersion("CondensingUnitOptions");

            ThreadProcess.Stop();
            Focus();

            Public.LanguageBox("Saving complete", "Sauvegarde complétée");

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

            try
            {
                return ((newPrice / oldPrice) - 1m) * 100m;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmCondensingUnitOptionsPriceIncrease GetCalculatedFactor");
                return 0m;
            }
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
    }
}