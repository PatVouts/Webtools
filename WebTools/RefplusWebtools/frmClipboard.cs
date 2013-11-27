using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public partial class FrmClipboard : Form
    {
        public enum OpenType { AdditionalItems };

        private readonly OpenType _selectedOpenType = OpenType.AdditionalItems;

        public FrmClipboard()
        {
            InitializeComponent();
        }

        public FrmClipboard(OpenType ot)
        {
            InitializeComponent();
            _selectedOpenType = ot;
        }

        private void frmClipboard_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            HideAllTabs();

            DisplayProperTab();
        }

        private void HideAllTabs()
        {
            tabMain.TabPages.Remove(tabAdditionnalItems);
        }

        private void DisplayProperTab()
        {
            switch (_selectedOpenType)
            {
                case OpenType.AdditionalItems:
                    Display_AdditionalItems();
                    break;
            }
        }

        public DataTable GetSelectedItems()
        {
            DataTable dt = null;

            switch (_selectedOpenType)
            {
                case OpenType.AdditionalItems:
                    dt = GetSelectedAdditionalItems();
                    break;
            }

            return dt;
        }

        private DataTable GetSelectedAdditionalItems()
        {
            DataTable dtSelectedItems = Tables.DtAdditionalItems();

            for (int i = 0; i < lstAdditionalItems.Items.Count; i++)
            {
                if (lstAdditionalItems.Items[i].SubItems[0].Checked)
                {
                    DataRow dr = dtSelectedItems.NewRow();

                    dr["Description"] = lstAdditionalItems.Items[i].SubItems[1].Text;
                    dr["Quantity"] = Convert.ToDecimal(lstAdditionalItems.Items[i].SubItems[2].Text);
                    dr["Price"] = Convert.ToDecimal(lstAdditionalItems.Items[i].SubItems[3].Text);

                    dtSelectedItems.Rows.Add(dr);
                }
            }

            return dtSelectedItems;
        }

        private void Display_AdditionalItems()
        {
            DataTable dtAddtionalItems = InternalClipboard.Get_AdditionalItems();

            if (dtAddtionalItems != null)
            {
                for (int i = 0; i < dtAddtionalItems.Rows.Count; i++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lstAdditionalItems);

                    myItem.SubItems[0].Text = "";
                    myItem.SubItems[1].Text = dtAddtionalItems.Rows[i]["Description"].ToString();
                    myItem.SubItems[2].Text = dtAddtionalItems.Rows[i]["Quantity"].ToString();
                    myItem.SubItems[3].Text = dtAddtionalItems.Rows[i]["Price"].ToString();

                    lstAdditionalItems.Items.Add(myItem);
                }
            }

            lstAdditionalItems.Refresh();

            tabMain.TabPages.Add(tabAdditionnalItems);
        }

        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

        private void cmdAdditionalItemsPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lstAdditionalItems, true);
        }

        private void cmdAdditionalItemsUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lstAdditionalItems, false);
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdAdditionalItemsClear_Click(object sender, EventArgs e)
        {
            InternalClipboard.Clear_AdditionalItems();
            lstAdditionalItems.Items.Clear();
            lstAdditionalItems.Refresh();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmClipboard_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}