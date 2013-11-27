using System;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }
       
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (txtNewPassword.Text.Trim().Length > 0 && txtRetypeNewPassword.Text.Trim().Length > 0)
            {
                if (txtNewPassword.Text == txtRetypeNewPassword.Text)
                {
                    if (Public.IsStringAlphanumeric(txtNewPassword.Text))
                    {
                        string oldPassword = Query.Select("SELECT * FROM UserAccount_NEW WHERE Username = '" + UserInformation.UserName + "'").Rows[0]["Password"].ToString();

                        if (oldPassword == txtOldPassword.Text)
                        {
                            Query.Execute("UPDATE UserAccount_NEW SET Password = '" + txtNewPassword.Text + "' WHERE Username = '" + UserInformation.UserName + "'");

                            Public.LanguageBox("Password changed successfuly.", "Mot de passe changé avec succès.");

                            Close();
                        }
                        else
                        {
                            Public.LanguageBox("Old password does not match.", "Le vieux mot de passe ne correspond pas.");
                        }
                    }
                    else
                    {
                        Public.LanguageBox("Password must be alphanumeric.", "Le mot de passe doit etre alphanumérique.");
                    }
                }
                else
                {
                    Public.LanguageBox("New password does not match the retyped one.", "Le nouveau mot de passe ne correspond pas avec celui réécrit.");
                }
            }
            else
            {
                Public.LanguageBox("Password cannot be empty.", "Le mot de passe ne peut pas être vide.");
            }
        }
    }
}