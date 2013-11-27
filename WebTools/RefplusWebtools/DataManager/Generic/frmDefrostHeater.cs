using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmDefrostHeater : Form
    {
        private DataTable _dtTable;

        public FrmDefrostHeater()
        {
            InitializeComponent();
        }

        private void frmDefrostHeater_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            FillTable();

            FillDefrostHeaterModel();

            FillTableView();
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void FillTableView()
        {
            dgTable.DataSource = _dtTable;
            dgTable.Refresh();
        }

        private void FillDefrostHeaterModel()
        {
            cboModel.Items.Clear();
            ComboBoxControl.AddItem(cboModel, "[ADD NEW]", "[ADD NEW]");

            foreach (DataRow dr in _dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["DefrostHeater"].ToString(), dr["DefrostHeater"].ToString());
            }

            cboModel.SelectedIndex = 0;
        }

        private void FillTable()
        {
            _dtTable = Query.Select("SELECT * FROM DefrostHeater");
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strDefrostHeater = ComboBoxControl.IndexInformation(cboModel);
            if (strDefrostHeater == "[ADD NEW]")
            {
                txtDefrostHeaterModel.Text = @"[Enter Defrost Heater Name]";
                txtDefrostHeaterModel.Enabled = true;
                txtType.Text = "";
                numVolts.Value = 0m;
                numWatts.Value = 0m;
                txtDescription.Text = "";
                numPrice.Value = 0m;
            }
            else
            {
                LoadDefrostHeaterData(strDefrostHeater);
                HighlightGridLine(strDefrostHeater);
                txtDefrostHeaterModel.Enabled = false;
                txtDefrostHeaterModel.BackColor = Color.White;
            }
        }

        private void LoadDefrostHeaterData(string strDefrostHeater)
        {
            DataRow dr = Public.SelectAndSortTable(_dtTable.Copy(), "DefrostHeater = '" + strDefrostHeater + "'", "").Rows[0];

            txtDefrostHeaterModel.Text = dr["DefrostHeater"].ToString();
            txtType.Text = dr["DefrostHeaterType"].ToString();
            numVolts.Value = Convert.ToDecimal(dr["DefrostHeaterVolt"]);
            numWatts.Value = Convert.ToDecimal(dr["DefrostHeaterWatt"]);
            txtDescription.Text = dr["DefrostHeaterDesc"].ToString();
            numPrice.Value = Convert.ToDecimal(dr["DefrostHeaterPrice"]);

        }

        private void HighlightGridLine(string strDefrostHeater)
        {
            int index = 0;

            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                if (dgTable.Rows[i].Cells["DefrostHeater"].Value.ToString() == strDefrostHeater)
                {
                    index = i;
                }
            }

            dgTable.Rows[index].Selected = true;
            dgTable.Select();
        }

        private void dgTable_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cboModel.SelectedIndex =
                    cboModel.FindString(dgTable.SelectedRows[0].Cells["DefrostHeater"].Value.ToString());
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmDefrostHeater dgTable_SelectionChanged");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save ?", "Êtes-vous sûr de vouloir sauvegarder ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Save();
            }
        }

        private bool ValidFields()
        {
            bool valid = true;

            if (txtDefrostHeaterModel.Text.Trim() == "")
            {
                Public.LanguageBox("Please enter a defrost heater name", "Veuillez entrer le nom du modèle du dégivreur");
                valid = false;
            }
            else if (txtDefrostHeaterModel.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtDefrostHeaterModel.Text.Contains("'"))
            {
                Public.LanguageBox("' is not a valid character.", "' n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtType.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtType.Text.Contains("'"))
            {
                Public.LanguageBox("' is not a valid character.", "' n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtDescription.Text.Contains("'"))
            {
                Public.LanguageBox("' is not a valid character.", "' n'est pas un caractère valide.");
                valid = false;
            }
            return valid;
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtDefrostHeaterModel.Text = StringManipulation.FilterInvalidCharacters(txtDefrostHeaterModel.Text);
            txtType.Text = StringManipulation.FilterInvalidCharacters(txtType.Text);
            txtDescription.Text = StringManipulation.FilterInvalidCharacters(txtDescription.Text);
        }

        private void Save()
        {
            //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
            ValidateInputsCharacterValidity();

            if (ValidFields())
            {
                bool reload = false;

                if (cboModel.Text == @"[ADD NEW]")
                {//insert
                    if (Query.Select("SELECT * FROM DefrostHeater WHERE DefrostHeater = '" + txtDefrostHeaterModel.Text + "'").Rows.Count > 0)
                    {
                        Public.LanguageBox("Defrost heater model already exist", "Le nom du modèle de ce dégivreur existe déja.");
                    }
                    else
                    {
                        if (Query.Execute("INSERT INTO DefrostHeater ([DefrostHeater],[DefrostHeaterType],[DefrostHeaterVolt],[DefrostHeaterWatt],[DefrostHeaterDesc],[DefrostHeaterPrice]) VALUES ('" + txtDefrostHeaterModel.Text + "','" + txtType.Text + "'," + numVolts.Value + "," + numWatts.Value + ",'" + txtDescription.Text + "'," + numPrice.Value + ")"))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    if (Query.Execute("UPDATE DefrostHeater SET [DefrostHeaterType] = '" + txtType.Text + "' ,[DefrostHeaterVolt] = " + numVolts.Value + " ,[DefrostHeaterWatt] = " + numWatts.Value + " ,[DefrostHeaterDesc] = '" + txtDescription.Text + "' ,[DefrostHeaterPrice] = " + numPrice.Value + " WHERE DefrostHeater = '" + txtDefrostHeaterModel.Text + "'"))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                if (reload)
                {
                    Query.UpdateServerTableVersion("DefrostHeater");

                    FillTable();

                    FillDefrostHeaterModel();

                    FillTableView();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmDefrostHeater_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

    }
}