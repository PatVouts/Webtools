using System;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Costing
{
    public partial class FrmRatio : Form
    {
        private int _ratio;
        public FrmRatio()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _ratio = Convert.ToInt32(num_Ratio.Value);
            Close();
        }

        public int GetRatio()
        {
            return _ratio;
        }

        private void frmRatio_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);
            Public.ChangeColor(this);
        }

        private void num_Ratio_Enter(object sender, EventArgs e)
        {
            num_Ratio.Select(0, num_Ratio.Text.Length);
        }
    }
}
