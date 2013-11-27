using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmMultiUpdateControlPanelOptions : Form
    {
        public FrmMultiUpdateControlPanelOptions()
        {
            InitializeComponent();
        }

        private void frmMultiUpdateControlPanelOptions_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillPanels();

            FillFanArrangement();

            FillVoltage();

            FillOptions();

        }

        private void FillPanels()
        {

            DataTable dtPanels = Query.Select("SELECT * FROM ControlPanel_Panels ORDER BY Panel");

            for (int i = 0; i < dtPanels.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(glPanels);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = dtPanels.Rows[i]["Panel"].ToString();
                glPanels.Items.Add(myItem);
            }

            dtPanels.Dispose();
        }

        private void FillFanArrangement()
        {
            DataTable dtFanArrangement = Query.Select("SELECT * FROM ControlPanel_FanArrangement ORDER BY FanWide, FanLong");

            for (int i = 0; i < dtFanArrangement.Rows.Count; i++)
            {

                var myItem = new GlacialComponents.Controls.GLItem(glFanArrangement);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = dtFanArrangement.Rows[i]["FanWide"] + "X" + dtFanArrangement.Rows[i]["FanLong"];
                glFanArrangement.Items.Add(myItem);
            }

            dtFanArrangement.Dispose();
            
        }

        private void FillVoltage()
        {
            DataTable dtVoltage = Query.Select("SELECT * FROM ControlPanel_Voltage");

            foreach (DataRow row in dtVoltage.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(glVoltage);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = row["VOltageID"].ToString();
                glVoltage.Items.Add(myItem);
            }

        }

        private void FillOptions()
        {
             DataTable dtOption = Query.Select("SELECT * FROM ControlPanel_Options ORDER BY PanelOption");

             foreach (DataRow row in dtOption.Rows)
             {
                 var myItem = new GlacialComponents.Controls.GLItem(glOptions);
                 myItem.SubItems[0].Text = "";
                 myItem.SubItems[1].Text = row["PanelOption"].ToString();
                 glOptions.Items.Add(myItem);
             }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glPanels, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glPanels, false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glFanArrangement, true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glFanArrangement, false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glVoltage, true);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glVoltage, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glOptions, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(glOptions, false);
        }

        //Function called for both select all and unselect all.  The boolean checkValueToSet is the value to be set all around.
        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (numPrice.Value < 0 && numPrice.Value != -1000000)
            {
                Public.LanguageBox("You are trying to save a negative price.  If you want to show the item is unavailable, it has to be - 1 million, nothing else.  Thank you :) ", "Vous tentez de sauvegarder un prix négatif.  La façon d'indiquer qu'une option est inaccessible est de mettre le prix à -1 million.  Merci :)");
            }
            else
            {
                ThreadProcess.Start("Updating Prices");
                for (int i = 0; i < glPanels.Items.Count; ++i)
                {
                    for (int j = 0; j < glFanArrangement.Items.Count; ++j)
                    {
                        for (int k = 0; k < glVoltage.Items.Count; ++k)
                        {
                            for (int l = 0; l < glOptions.Items.Count; ++l)
                            {
                                if (glPanels.Items[i].SubItems[0].Checked && glFanArrangement.Items[j].SubItems[0].Checked && glVoltage.Items[k].SubItems[0].Checked && glOptions.Items[l].SubItems[0].Checked)
                                {
                                    Query.Execute("Update ControlPanel_PanelOptionPrices set Price = " + numPrice.Value + " where Panel = '" + glPanels.Items[i].SubItems[1].Text + "' and FanWide = " + glFanArrangement.Items[j].SubItems[1].Text.Substring(0, 1) + " and FanLong = " + glFanArrangement.Items[j].SubItems[1].Text.Substring(2, 1) + " and VoltageID = " + glVoltage.Items[k].SubItems[1].Text + " and Options = '" + glOptions.Items[l].SubItems[1].Text + "'");
                                }
                            }
                        }
                    }
                }
                ThreadProcess.Stop();
                Public.LanguageBox("Your price update passed in the system", "Votre modification de prix a été bien envoyée dans le système");
                Focus();
            }
        }

    }
}
