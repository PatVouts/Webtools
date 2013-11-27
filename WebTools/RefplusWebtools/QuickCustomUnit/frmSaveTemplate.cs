using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCustomUnit
{
    public partial class FrmSaveTemplate : Form
    {
        private string _description = "";

        public FrmSaveTemplate()
        {
            InitializeComponent();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text != "")
            {
                if (DoesTemplateAlreadyExist(txtDescription.Text))
                {
                    Public.LanguageBox("This template already exists. Please choose another name for the template.", "Ce modèle existe déjà. S'il vous plaît choisir un autre nom pour le modèle.");
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    _description = txtDescription.Text;
                    Close();
                }
            }
            else
            {
                Public.LanguageBox("You must enter a name for the template", "Vous devez entrer un nom pour le modèle");
            }
        }

        public string GetDescription()
        {
            return _description;
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool DoesTemplateAlreadyExist(string template)
        {            
            DataTable dtTemplate = Query.Select("SELECT Description from CustomUnitTemplate WHERE Description = '" + template + "'");
            
            if (dtTemplate.Rows.Count > 0)
            {
                dtTemplate.Dispose();
                return true;
            }

            dtTemplate.Dispose();
            return false;
        }

        private void frmSaveTemplate_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        } 
    }
}