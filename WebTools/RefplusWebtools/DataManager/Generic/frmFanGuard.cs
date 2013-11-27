using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmFanGuard : Form
    {
        private DataTable _dtTable;

        public FrmFanGuard()
        {
            InitializeComponent();
        }

        private void frmFanGuard_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            FillTable();

            FillFanGuardModel();

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

        private void FillFanGuardModel()
        {
            cboModel.Items.Clear();
            ComboBoxControl.AddItem(cboModel, "[ADD NEW]", "[ADD NEW]");
            
            foreach (DataRow dr in _dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["FanGuardID"].ToString(), dr["FanGuardID"].ToString());
            }

            cboModel.SelectedIndex = 0;
        }

        private void FillTable()
        {
            _dtTable = Query.Select("SELECT * FROM FanGuardModel");
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFanGuard = ComboBoxControl.IndexInformation(cboModel);
            if (strFanGuard == "[ADD NEW]")
            {
                txtFanModel.Text = @"[Enter Fan Guard Name]";
                txtFanModel.Enabled = true;
                numFanSize.Value = 0m;
                txtComposition.Text = "";
                numPrice.Value = 0m;
            }
            else
            {
                LoadFanGuardData(strFanGuard);
                HighlightGridLine(strFanGuard);
                txtFanModel.Enabled = false;
                txtFanModel.BackColor = Color.White;
            }
        }

        private void LoadFanGuardData(string strFanGuard)
        {
            DataRow dr = Public.SelectAndSortTable(_dtTable.Copy(), "FanGuardID = '" + strFanGuard + "'", "").Rows[0];

            txtFanModel.Text = dr["FanGuardID"].ToString();
            numFanSize.Value = Convert.ToDecimal(dr["FanSize"]);
            txtComposition.Text = dr["Composition"].ToString();
            numPrice.Value = Convert.ToDecimal(dr["Price"]);
        }

        private void HighlightGridLine(string strFanGuard)
        {
            int index = 0;

            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                if (dgTable.Rows[i].Cells["FanGuardID"].Value.ToString() == strFanGuard)
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
                    cboModel.FindString(dgTable.SelectedRows[0].Cells["FanGuardID"].Value.ToString());
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmFanGuard dgTable_SelectionChanged");
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

            if (txtFanModel.Text.Trim() == "")
            {
                Public.LanguageBox("Please enter a fan guard name", "Veuillez entrer le nom du modèle du protecteur de ventilateur");
                valid = false;
            }
            else if (txtFanModel.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not valid a character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtComposition.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            return valid;
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtFanModel.Text = StringManipulation.FilterInvalidCharacters(txtFanModel.Text);
            txtComposition.Text = StringManipulation.FilterInvalidCharacters(txtComposition.Text);
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
                    if (Query.Select("SELECT * FROM FanGuardModel WHERE FanGuardID = '" + txtFanModel.Text + "'").Rows.Count > 0)
                    {
                        Public.LanguageBox("Fan guard model already exist", "Le nom du modèle de ce protecteur de ventilateur existe déja.");
                    }
                    else
                    {
                        if(Query.Execute("INSERT INTO FanGuardModel ([FanGuardID],[FanSize],[Composition],[Price]) VALUES ('" + txtFanModel.Text + "'," + numFanSize.Value + ",'" + txtComposition.Text + "'," + numPrice.Value + ")"))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    if(Query.Execute("UPDATE FanGuardModel SET [FanSize] = " + numFanSize.Value + ",[Composition] = '" + txtComposition.Text + "',[Price] = " + numPrice.Value + " WHERE FanGuardID = '" + txtFanModel.Text + "'"))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                if (reload)
                {
                    Query.UpdateServerTableVersion("FanGuardModel");

                    FillTable();

                    FillFanGuardModel();

                    FillTableView();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmFanGuard_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

       
    }
}