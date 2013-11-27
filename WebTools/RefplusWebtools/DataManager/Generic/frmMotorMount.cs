using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmMotorMount : Form
    {
        private DataTable _dtTable;

        public FrmMotorMount()
        {
            InitializeComponent();
        }


        private void frmMotorMount_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            FillTable();

            FillMotorMountModel();

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

        private void FillMotorMountModel()
        {
            cboModel.Items.Clear();
            ComboBoxControl.AddItem(cboModel, "[ADD NEW]", "[ADD NEW]");
            
            foreach (DataRow dr in _dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["MotorMountID"].ToString(), dr["MotorMountID"].ToString());
            }

            cboModel.SelectedIndex = 0;
        }

        private void FillTable()
        {
            _dtTable = Query.Select("SELECT * FROM MotorMountModel");
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strMotorMount = ComboBoxControl.IndexInformation(cboModel);
            if (strMotorMount == "[ADD NEW]")
            {
                txtMotorMount.Text = @"[Enter Motor Mount Name]";
                txtMotorMount.Enabled = true;
                numFanSize.Value = 0m;
                numFrameSize.Value = 0m;
                txtComposition.Text = "";
                numPrice.Value = 0m;
            }
            else
            {
                LoadMotorMountData(strMotorMount);
                HighlightGridLine(strMotorMount);
                txtMotorMount.Enabled = false;
                txtMotorMount.BackColor = Color.White;
            }
        }

        private void LoadMotorMountData(string strMotorMount)
        {
            DataRow dr = Public.SelectAndSortTable(_dtTable.Copy(), "MotorMountID = '" + strMotorMount + "'", "").Rows[0];

            txtMotorMount.Text = dr["MotorMountID"].ToString();
            numFanSize.Value = Convert.ToDecimal(dr["FanSize"]);
            numFrameSize.Value = Convert.ToDecimal(dr["FrameSize"]);
            txtComposition.Text = dr["Composition"].ToString();
            numPrice.Value = Convert.ToDecimal(dr["Price"]);
        }

        private void HighlightGridLine(string strMotorMount)
        {
            int index = 0;

            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                if (dgTable.Rows[i].Cells["MotorMountID"].Value.ToString() == strMotorMount)
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
                    cboModel.FindString(dgTable.SelectedRows[0].Cells["MotorMountID"].Value.ToString());
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmMotorMount dgTable_SelectionChanged");
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

            if (txtMotorMount.Text.Trim() == "")
            {
                Public.LanguageBox("Please enter a motor mount name", "Veuillez entrer le nom du soutien pour moteur");
                valid = false;
            }
            else if (txtMotorMount.Text.Contains("\""))
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
            txtMotorMount.Text = StringManipulation.FilterInvalidCharacters(txtMotorMount.Text);
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
                    if (Query.Select("SELECT * FROM MotorMountModel WHERE MotorMountID = '" + txtMotorMount.Text + "'").Rows.Count > 0)
                    {
                        Public.LanguageBox("Motor mount model already exist", "Le nom du modèle de ce soutien pour moteur existe déja.");
                    }
                    else
                    {
                        if (Query.Execute("INSERT INTO MotorMountModel ([MotorMountID],[FanSize],[FrameSize],[Composition],[Price]) VALUES ('" + txtMotorMount.Text + "'," + numFanSize.Value + "," + numFrameSize.Value + ",'" + txtComposition.Text + "'," + numPrice.Value + ")"))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    if(Query.Execute("UPDATE MotorMountModel SET [FanSize] = " + numFanSize.Value + ",[FrameSize] = " + numFrameSize.Value + ",[Composition] = '" + txtComposition.Text + "',[Price] = " + numPrice.Value + " WHERE MotorMountID = '" + txtMotorMount.Text + "'"))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                if (reload)
                {
                    Query.UpdateServerTableVersion("MotorMountModel");

                    FillTable();

                    FillMotorMountModel();

                    FillTableView();
                }
            } 
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmMotorMount_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }


       
    }
}