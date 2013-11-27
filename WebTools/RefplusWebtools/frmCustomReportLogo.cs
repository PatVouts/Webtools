using System;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public partial class FrmCustomReportLogo : Form
    {
        private string _pathOfFile = "";

        public FrmCustomReportLogo()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBrowseFile_Click(object sender, EventArgs e)
        {
            opendlg.ShowDialog();
            _pathOfFile = opendlg.FileName;
            LoadPicture();
        }

        private void LoadPicture()
        {
            if (_pathOfFile != "")
            {
                try
                {
                    picLogo.Load(_pathOfFile);
                }
                catch(Exception ex)
                {
                    Public.PushLog(ex.ToString(),"frmCustomReportLogo LoadPicture");
                    Public.LanguageBox("Invalid Image", "Image non valide");
                    _pathOfFile = "";
                }
            }
        }

        private void radCustom_CheckedChanged(object sender, EventArgs e)
        {
            pnlCustom.Enabled = radCustom.Checked;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (radCustom.Checked)
            {
                Reg.Set(Reg.Key.CustomLogo, _pathOfFile);
                Reg.Set(Reg.Key.CustomAddress, txtAddress.Text);
            }
            else
            {
                Reg.Set(Reg.Key.CustomLogo, "");
                Reg.Set(Reg.Key.CustomAddress, "");
            }

            Public.LanguageBox("Settings changed", "Paramêtre changé");
        }

        private void frmCustomReportLogo_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            if (Reg.Get(Reg.Key.CustomLogo) != "")
            {
                radCustom.Checked = true;
                _pathOfFile = Reg.Get(Reg.Key.CustomLogo);
                LoadPicture();
                txtAddress.Text = Reg.Get(Reg.Key.CustomAddress);
            }
        }

        private void radDefault_CheckedChanged(object sender, EventArgs e)
        {
            picLogo.Image = null;
            _pathOfFile = "";
            txtAddress.Text = "";
        }
    }
}