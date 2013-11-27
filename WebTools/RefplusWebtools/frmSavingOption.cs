using System;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public partial class FrmSavingOption : Form
    {
        public FrmSavingOption()
        {
            InitializeComponent();
        }

        private void cmdOverwrite_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void cmdSaveAsCopy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void frmSavingOption_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);
        }
    }
}