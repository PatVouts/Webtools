using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.CondensingUnit
{
    public partial class FrmCondensingUnitWaterCooledCondenser : Form
    {
        private DataTable _dtTable;

        public FrmCondensingUnitWaterCooledCondenser()
        {
            InitializeComponent();
        }

        private void frmCondensingUnitWaterCooledCondenser_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            FillTable();

            FillWaterCooledModel();

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

        private void FillTable()
        {
            _dtTable = Query.Select("SELECT * FROM CondensingUnitWaterCooledCondenser");
        }

        private void FillWaterCooledModel()
        {
            cboModel.Items.Clear();
            ComboBoxControl.AddItem(cboModel, "[ADD NEW]", "[ADD NEW]");

            foreach (DataRow dr in _dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["WaterCooledModel"].ToString(), dr["WaterCooledModel"].ToString());
            }

            cboModel.SelectedIndex = 0;
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strReceiver = ComboBoxControl.IndexInformation(cboModel);
            if (strReceiver == "[ADD NEW]")
            {
                txtWaterCooledCondenserModel.Text = @"[Enter Water Cooled Condenser Name]";
                txtWaterCooledCondenserModel.Enabled = true;
                numPumpDownCapacity.Value = 0m;
            }
            else
            {
                LoadReceiverData(strReceiver);
                HighlightGridLine(strReceiver);
                txtWaterCooledCondenserModel.Enabled = false;
                txtWaterCooledCondenserModel.BackColor = Color.White;
            }
        }

        private void HighlightGridLine(string strReceiver)
        {
            int index = 0;

            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                if (dgTable.Rows[i].Cells["WaterCooledModel"].Value.ToString() == strReceiver)
                {
                    index = i;
                }
            }

            dgTable.Rows[index].Selected = true;
            dgTable.Select();
        }

        private void LoadReceiverData(string strReceiver)
        {
            DataRow dr = Public.SelectAndSortTable(_dtTable.Copy(), "WaterCooledModel = '" + strReceiver + "'", "").Rows[0];

            txtWaterCooledCondenserModel.Text = dr["WaterCooledModel"].ToString();
            numPumpDownCapacity.Value = Convert.ToDecimal(dr["PumpDownCapacity"]);
            
        }

        private void dgTable_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cboModel.SelectedIndex =
                    cboModel.FindString(dgTable.SelectedRows[0].Cells["WaterCooledModel"].Value.ToString());
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmCondensingUnitWaterCooled dgTable_SelectionChanged");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save ?", "Etes-vous sur de vouloir sauvegarder ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Save();
            }
        }

        private bool ValidFields()
        {
            bool valid = true;

            if (txtWaterCooledCondenserModel.Text.Trim() == "")
            {
                Public.LanguageBox("Please enter a water cooled condenser name", "Veuillez entrer le nom du refroidisseur liquide à condensation");
                valid = false;
            }
            else if (txtWaterCooledCondenserModel.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }

            return valid;
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtWaterCooledCondenserModel.Text = StringManipulation.FilterInvalidCharacters(txtWaterCooledCondenserModel.Text);
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
                    if (Query.Select("SELECT * FROM CondensingUnitWaterCooledCondenser WHERE WaterCooledModel = '" + txtWaterCooledCondenserModel.Text + "'").Rows.Count > 0)
                    {
                        Public.LanguageBox("Motor mount model already exist", "Le nom du modèle de ce soutien pour moteur existe déja.");
                    }
                    else
                    {
                        if (Query.Execute("INSERT INTO CondensingUnitWaterCooledCondenser ([WaterCooledModel],[PumpDownCapacity]) VALUES ('" + txtWaterCooledCondenserModel.Text + "'," + numPumpDownCapacity.Value + ")"))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    if (Query.Execute("UPDATE CondensingUnitWaterCooledCondenser SET [PumpDownCapacity] = " + numPumpDownCapacity.Value + " WHERE WaterCooledModel = '" + txtWaterCooledCondenserModel.Text + "'"))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                if (reload)
                {
                    Query.UpdateServerTableVersion("CondensingUnitWaterCooledCondenser");

                    FillTable();

                    FillWaterCooledModel();

                    FillTableView();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);

        }

        private void frmCondensingUnitWaterCooledCondenser_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

      
    }
}