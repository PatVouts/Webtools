using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.ControlPanel
{
    public partial class FrmAddEditPanel : Form
    {
        private readonly string _strPanel = "";
        private readonly string _strDescription = "";
        private readonly bool _editMode;

        public FrmAddEditPanel(string panel, string description)
        {
            InitializeComponent();
            _strPanel = panel;
            _strDescription = description;
            _editMode = true;
        }

        public FrmAddEditPanel()
        {
            InitializeComponent();
        }

        private void frmAddEditPanel_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            if (_editMode)
            {
                txtPanel.Text = _strPanel;
                txtPanel.Enabled = false;
                txtDescription.Text = _strDescription;
            }
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtPanel.Text = StringManipulation.FilterInvalidCharacters(txtPanel.Text);
            txtDescription.Text = StringManipulation.FilterInvalidCharacters(txtDescription.Text);
        }

        private void Save()
        {
            //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
            ValidateInputsCharacterValidity();

            if (txtPanel.Text.Trim().Length > 0)
            {
                if (Public.LanguageQuestionBox("Are you sure you want to save", "Êtes-vous sûr de vouloir sauvegarder", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_editMode)
                    {
                        Query.Execute("UPDATE ControlPanel_Panels SET Description = '" + txtDescription.Text.Replace("'", "''") + "' WHERE Panel = '" + _strPanel + "'");

                        Query.UpdateServerTableVersion("ControlPanel_Panels");

                        Public.LanguageBox("Update successful", "Mise à jour réussie");
                    }
                    else
                    {
                        DataTable dtPanel = Query.Select("SELECT * FROM ControlPanel_Panels WHERE Panel = '" + txtPanel.Text.Replace("'", "''") + "'");

                        if (dtPanel.Rows.Count == 0)
                        {
                            Query.Execute("INSERT INTO ControlPanel_Panels (Panel, Description) VALUES ('" + txtPanel.Text.Replace("'", "''") + "', '" + txtDescription.Text.Replace("'", "''") + "')");

                            Query.Execute("INSERT INTO ControlPanel_PanelPrices (Panel, FanWide, FanLong, Price) SELECT '" + txtPanel.Text.Replace("'", "''") + "' as Panel, FanWide, FanLong, -1000000 as Price FROM ControlPanel_FanArrangement");

                            Query.Execute("INSERT INTO ControlPanel_PanelOptionPrices (Panel, FanWide, FanLong, VoltageID, Options, Price) SELECT '" + txtPanel.Text.Replace("'", "''") + "' as Panel, FanWide, FanLong, VoltageID, PanelOption as Options, -1000000 as Price FROM ControlPanel_FanArrangement,ControlPanel_Voltage, ControlPanel_Options");

                            Query.Execute("INSERT INTO ControlPanel_SpecialPrice (Panel, FanWide, FanLong, SpecialPrice) SELECT '" + txtPanel.Text.Replace("'", "''") + "' as Panel, FanWide, FanLong, 0 as SpecialPrice FROM ControlPanel_FanArrangement");

                            Query.UpdateServerTableVersion("ControlPanel_Panels");
                            Query.UpdateServerTableVersion("ControlPanel_PanelPrices");
                            Query.UpdateServerTableVersion("ControlPanel_PanelOptionPrices");
                            Query.UpdateServerTableVersion("ControlPanel_SpecialPrice");

                            Public.LanguageBox("Saving successful", "Sauvegarde réussie");
                        }
                        else
                        {
                            Public.LanguageBox("This panel already exist", "Ce panneau existe déja");
                        }
                    }
                    Close();
                }
            }
            else
            {
                Public.LanguageBox("You must enter a panel name", "Vous devez entrez le nom du panneau");
            }
        }
    }
}