using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmFanModel : Form
    {

        private DataTable _dtTable;

        public FrmFanModel()
        {
            InitializeComponent();
        }

        private void frmFanModel_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            FillTable();

            FillFanModel();

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

        private void FillFanModel()
        {
            cboModel.Items.Clear();
            ComboBoxControl.AddItem(cboModel, "[ADD NEW]", "[ADD NEW]");
            
            foreach (DataRow dr in _dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["FanID"].ToString(), dr["FanID"].ToString());
            }

            cboModel.SelectedIndex = 0;
        }

        private void FillTable()
        {
            _dtTable = Query.Select("SELECT * FROM FanModel");
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFanModel = ComboBoxControl.IndexInformation(cboModel);
            if (strFanModel == "[ADD NEW]")
            {
                txtFanModel.Text = @"[Enter Fan Model Name]";
                txtFanModel.Enabled = true;
                numDiameter.Value = 0m;
                numBladeQuantity.Value = 0m;
                txtRotationType.Text = "";
                txtComposition.Text = "";
                numPitch.Value = 0m;
                numPrice.Value = 0m;
            }
            else
            {
                LoadFanData(strFanModel);
                HighlightGridLine(strFanModel);
                txtFanModel.Enabled = false;
                txtFanModel.BackColor = Color.White;
            }
        }

        private void LoadFanData(string strFanModel)
        {
            DataRow dr = Public.SelectAndSortTable(_dtTable.Copy(), "FanID = '" + strFanModel + "'", "").Rows[0];

            txtFanModel.Text = dr["FanID"].ToString();
            numDiameter.Value = Convert.ToDecimal(dr["Diameter"]);
            numBladeQuantity.Value = Convert.ToInt32(dr["BladeQuantity"]);
            txtRotationType.Text = dr["RotationType"].ToString();
            txtComposition.Text = dr["Composition"].ToString();
            numPitch.Value = Convert.ToDecimal(dr["Pitch"]);
            numPrice.Value = Convert.ToDecimal(dr["Price"]);
        }

        private void HighlightGridLine(string strFanModel)
        {
            int index = 0;

            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                if (dgTable.Rows[i].Cells["FanID"].Value.ToString() == strFanModel)
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
                cboModel.SelectedIndex = cboModel.FindString(dgTable.SelectedRows[0].Cells["FanID"].Value.ToString());
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmFanModel dgTable_SelectionChanged");
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
                Public.LanguageBox("Please enter a fan model name", "Veuillez entrer le nom du modèle du ventilateur");
                valid = false;
            }
            else if (txtFanModel.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtRotationType.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
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
            txtRotationType.Text = StringManipulation.FilterInvalidCharacters(txtRotationType.Text);
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
                    if (Query.Select("SELECT * FROM FanModel WHERE FanID = '" + txtFanModel.Text + "'").Rows.Count > 0)
                    {
                        Public.LanguageBox("Fan model already exist", "Le nom du modèle de ce ventilateur existe déja.");
                    }
                    else
                    {
                        if(Query.Execute("INSERT INTO FanModel ([FanID],[Diameter],[BladeQuantity],[RotationType],[Composition],[Pitch],[Price]) VALUES ('" + txtFanModel.Text + "'," + numDiameter.Value + "," + numBladeQuantity.Value + ",'" + txtRotationType.Text + "','" + txtComposition.Text + "'," + numPitch.Value + "," + numPrice.Value + ")"))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    if (Query.Execute("UPDATE FanModel SET [Diameter] = " + numDiameter.Value + ",[BladeQuantity] = " + numBladeQuantity.Value + ",[RotationType] = '" + txtRotationType.Text + "',[Composition] = '" + txtComposition.Text + "',[Pitch] = " + numPitch.Value + ",[Price] = " + numPrice.Value + " WHERE FanID = '" + txtFanModel.Text + "'"))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                if (reload)
                {
                    Query.UpdateServerTableVersion("FanModel");

                    FillTable();

                    FillFanModel();

                    FillTableView();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmFanModel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}