using System;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCoil
{
    public partial class FrmCoilCoating : Form
    {
        private readonly ComboBox _cboOriginalCoilCoating;
        private readonly string _previousSelection = "";

        public FrmCoilCoating(ComboBox cboOriginalCoilCoating, string previousSelection)
        {
            InitializeComponent();
            _cboOriginalCoilCoating = cboOriginalCoilCoating;
            _previousSelection = previousSelection;
        }

        private void frmCoilCoating_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            cboCoilCoating.Items.Clear();

            for (int i = 0; i < _cboOriginalCoilCoating.Items.Count; i++)
            {
                cboCoilCoating.Items.Add(((CBOITEM)_cboOriginalCoilCoating.Items[i]).Text);
            }

            cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(_previousSelection) >= 0 ? cboCoilCoating.FindString(_previousSelection) : 0;
        }

        public string GetCoilCoating()
        {
            return cboCoilCoating.Text;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}