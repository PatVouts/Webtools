using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.ControlPanel
{
    public partial class FrmAddEditOption : Form
    {
        private readonly string _strOption = "";
        private readonly string _strDescription = "";
        private readonly int _intGroup;
        private readonly int _intUnique;
        private readonly bool _editMode;

        public FrmAddEditOption()
        {
            InitializeComponent();
        }


        public FrmAddEditOption(string option, string description,int group, int unique)
        {
            InitializeComponent();
            _strOption = option;
            _strDescription = description;
            _intGroup = group;
            _intUnique = unique;
            _editMode = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddEditOption_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillGroup();

            if (_editMode)
            {
                txtOption.Text = _strOption;
                txtOption.Enabled = false;
                txtDescription.Text = _strDescription;
                ComboBoxControl.SetIDDefaultValue(cboGroup, _intGroup.ToString(CultureInfo.InvariantCulture));
                chkUnique.Checked = (_intUnique == 1);
            }
        }

        private void FillGroup()
        {
            cboGroup.Items.Clear();

            DataTable dtGroups = Query.Select("SELECT * FROM ControlPanel_OptionsGroup ORDER BY GroupID");

            for (int i = 0; i < dtGroups.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboGroup, dtGroups.Rows[i]["GroupID"].ToString(), dtGroups.Rows[i]["GroupID"].ToString());
            }

            cboGroup.SelectedIndex = 0;
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtOption.Text = StringManipulation.FilterInvalidCharacters(txtOption.Text);
            txtDescription.Text = StringManipulation.FilterInvalidCharacters(txtDescription.Text);
        }

        private void Save()
        {
            //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
            ValidateInputsCharacterValidity();

            if (txtOption.Text.Trim().Length > 0)
            {
                if (Public.LanguageQuestionBox("Are you sure you want to save", "Êtes-vous sûr de vouloir sauvegarder", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_editMode)
                    {
                        Query.Execute("UPDATE ControlPanel_Options SET Description = '" + txtDescription.Text.Replace("'", "''") + "', GroupID = " + cboGroup.Text + ", UniqueSelection = " + (chkUnique.Checked ? "1" : "0") + " WHERE PanelOption = '" + _strOption + "'");

                        Query.UpdateServerTableVersion("ControlPanel_Options");

                        Public.LanguageBox("Update successful", "Mise à jour réussie");
                    }
                    else
                    {
                        DataTable dtOption = Query.Select("SELECT * FROM ControlPanel_Options WHERE PanelOption = '" + txtOption.Text.Replace("'", "''") + "'");

                        if (dtOption.Rows.Count == 0)
                        {
                            Query.Execute("INSERT INTO ControlPanel_Options (PanelOption, Description, GroupID, UniqueSelection) VALUES ('" + txtOption.Text.Replace("'", "''") + "', '" + txtDescription.Text.Replace("'", "''") + "', " + cboGroup.Text + ", " + (chkUnique.Checked ? "1" : "0") + ")");

                            Query.Execute("INSERT INTO ControlPanel_PanelOptionPrices (Panel, FanWide, FanLong, VoltageID, Options, Price) SELECT Panel, FanWide, FanLong, VoltageID, '" + txtOption.Text.Replace("'", "''") + "' as Options, -1000000 as Price FROM ControlPanel_Panels, ControlPanel_FanArrangement,ControlPanel_Voltage");

                            Query.UpdateServerTableVersion("ControlPanel_Options");
                            Query.UpdateServerTableVersion("ControlPanel_PanelOptionPrices");

                            Public.LanguageBox("Saving successful", "Sauvegarde réussie");
                        }
                        else
                        {
                            Public.LanguageBox("This option already exist", "Cette option existe déja");
                        }
                    }
                    Close();
                }
            }
            else
            {
                Public.LanguageBox("You must enter an option name", "Vous devez entrez le nom de l'option");
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}