using System;
using System.Windows.Forms;

namespace RefplusWebtools.QuickWaterEvaporator
{
    public partial class FrmWaterEvaporatorCoating : Form
    {
        readonly ComboBox _cboOriginalCoating;

        public FrmWaterEvaporatorCoating(ComboBox cboOriginalCoating)
        {
            InitializeComponent();
            _cboOriginalCoating = cboOriginalCoating;
        }

        private void frmWaterEvaporatorCoating_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            Fill_Coating();

        }

        public string GetSelectedCoating()
        {
            return cboCoilCoating.Text;
        }

        private void Fill_Coating()
        {
            for (int i = 0; i < _cboOriginalCoating.Items.Count; i++)
            {
                cboCoilCoating.Items.Add(((CBOITEM)_cboOriginalCoating.Items[i]).Text);
            }

            cboCoilCoating.SelectedIndex = _cboOriginalCoating.SelectedIndex;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}