using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmMotorModel : Form
    {
        private DataTable _dtTable;

        public FrmMotorModel()
        {
            InitializeComponent();
        }

        private void frmMotorModel_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            FillTable();

            FillMotorModel();

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

        private void FillMotorModel()
        {
            cboModel.Items.Clear();
            ComboBoxControl.AddItem(cboModel, "[ADD NEW]", "[ADD NEW]");

            foreach (DataRow dr in _dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["MotorID"].ToString(), dr["MotorID"].ToString());
            }

            cboModel.SelectedIndex = 0;
        }

        private void FillTable()
        {
            _dtTable = Query.Select("SELECT MotorModel.*, MainVoltage.VoltageID, MainVoltage.VoltDescription, MotorModelFLA.FLA FROM MotorModel LEFT JOIN MotorModelFLA ON MotorModel.MotorID = MotorModelFLA.MotorID LEFT JOIN MainVoltage ON MotorModelFLA.VoltageID = MainVoltage.VoltageID ORDER BY MotorModel.MotorID, MotorModelFLA.VoltageID");
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strMotorModel  = ComboBoxControl.IndexInformation(cboModel);
            if (strMotorModel == "[ADD NEW]")
            {
                txtMotorModel.Text = @"[Enter Motor Name]";
                txtMotorModel.Enabled = true;
                numHP.Value = 0m;
                numRPM.Value = 0m;
                txtRotationType.Text = "";
                txtFrameType.Text = "";
                numShaftLength.Value = 0m;
                numPrice.Value = 0m;
                num120_1_60_FLA.Value = 0m;
                num208_240_1_60_FLA.Value = 0m;
                num208_240_3_60_FLA.Value = 0m;
                num480_3_60_FLA.Value = 0m;
                num600_3_60_FLA.Value = 0m;
            }
            else
            {
                LoadMotorData(strMotorModel);
                HighlightGridLine(strMotorModel);
                txtMotorModel.Enabled = false;
                txtMotorModel.BackColor = Color.White;
            }
        }

        private void LoadMotorData(string strMotorModel)
        {
            DataTable dtFiltered = Public.SelectAndSortTable(_dtTable.Copy(), "MotorID = '" + strMotorModel + "'", "");

            txtMotorModel.Text = dtFiltered.Rows[0]["MotorID"].ToString();
            numHP.Value = Convert.ToDecimal(dtFiltered.Rows[0]["HP"]);
            numRPM.Value = Convert.ToDecimal(dtFiltered.Rows[0]["RPM"]);
            txtRotationType.Text = dtFiltered.Rows[0]["RotType"].ToString();
            txtFrameType.Text = dtFiltered.Rows[0]["FrameType"].ToString();
            numShaftLength.Value = Convert.ToDecimal(dtFiltered.Rows[0]["ShaftLength"]);
            numPrice.Value = Convert.ToDecimal(dtFiltered.Rows[0]["Price"]);

            foreach (DataRow dr in dtFiltered.Rows)
            {
                if (dr["VoltDescription"].ToString() == "120/1/60")
                {
                    num120_1_60_FLA.Value = Convert.ToDecimal(dr["FLA"]);
                }
                if (dr["VoltDescription"].ToString() == "208-240/1/60")
                {
                    num208_240_1_60_FLA.Value = Convert.ToDecimal(dr["FLA"]);
                }
                else if (dr["VoltDescription"].ToString() == "208-240/3/60")
                {
                    num208_240_3_60_FLA.Value = Convert.ToDecimal(dr["FLA"]);
                }
                else if (dr["VoltDescription"].ToString() == "480/3/60")
                {
                    num480_3_60_FLA.Value = Convert.ToDecimal(dr["FLA"]);
                }
                else if (dr["VoltDescription"].ToString() == "600/3/60")
                {
                    num600_3_60_FLA.Value = Convert.ToDecimal(dr["FLA"]);
                }
            }
        }

        private void HighlightGridLine(string strMotorModel)
        {
            int index = 0;

            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                if (dgTable.Rows[i].Cells["MotorID"].Value.ToString() == strMotorModel)
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
                cboModel.SelectedIndex = cboModel.FindString(dgTable.SelectedRows[0].Cells["MotorID"].Value.ToString());
            }
            catch (Exception  ex)
            {
                Public.PushLog(ex.ToString(),"frmMotorModel dgTable_SelectionChanged");
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

            if (txtMotorModel.Text.Trim() == "")
            {
                Public.LanguageBox("Please enter a motor name", "Veuillez entrer le nom du moteur");
                valid = false;
            }
            else if (txtMotorModel.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtRotationType.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            else if (txtFrameType.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }
            return valid;
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtMotorModel.Text = StringManipulation.FilterInvalidCharacters(txtMotorModel.Text);
            txtRotationType.Text = StringManipulation.FilterInvalidCharacters(txtRotationType.Text);
            txtFrameType.Text = StringManipulation.FilterInvalidCharacters(txtFrameType.Text);
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
                    if (Query.Select("SELECT * FROM MotorModel WHERE MotorID = '" + txtMotorModel.Text + "'").Rows.Count > 0)
                    {
                        Public.LanguageBox("Motor model already exist", "Le nom du modèle de ce moteur existe déja.");
                    }
                    else
                    {
                        string tsql = "BEGIN TRANSACTION ";

                        tsql += " INSERT INTO MotorModel ([MotorID],[HP],[RPM],[RotType],[FrameType],[ShaftLength],[Price]) VALUES ('" + txtMotorModel.Text + "'," + numHP.Value + "," + numRPM.Value + ",'" + txtRotationType.Text + "','" + txtFrameType.Text + "'," + numShaftLength.Value + "," + numPrice.Value + ")";
                        tsql += " INSERT INTO MotorModelFLA ([MotorID],[VoltageID],[FLA]) VALUES ('" + txtMotorModel.Text + "',1," + num120_1_60_FLA.Value + ")";
                        tsql += " INSERT INTO MotorModelFLA ([MotorID],[VoltageID],[FLA]) VALUES ('" + txtMotorModel.Text + "',2," + num208_240_1_60_FLA.Value + ")";
                        tsql += " INSERT INTO MotorModelFLA ([MotorID],[VoltageID],[FLA]) VALUES ('" + txtMotorModel.Text + "',5," + num208_240_3_60_FLA.Value + ")";
                        tsql += " INSERT INTO MotorModelFLA ([MotorID],[VoltageID],[FLA]) VALUES ('" + txtMotorModel.Text + "',9," + num480_3_60_FLA.Value + ")";
                        tsql += " INSERT INTO MotorModelFLA ([MotorID],[VoltageID],[FLA]) VALUES ('" + txtMotorModel.Text + "',8," + num600_3_60_FLA.Value + ")";

                        tsql += "COMMIT TRAN";
                        
                        if(Query.Execute(tsql))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    string tsql = "BEGIN TRANSACTION ";

                    tsql += " UPDATE MotorModel SET [HP] = " + numHP.Value + ",[RPM] = " + numRPM.Value + ",[RotType] = '" + txtRotationType.Text + "',[FrameType] = '" + txtFrameType.Text + "',[ShaftLength] = " + numShaftLength.Value + ",[Price] = " + numPrice.Value + " WHERE MotorID = '" + txtMotorModel.Text + "'";
                    tsql += " UPDATE MotorModelFLA SET [FLA] = " + num120_1_60_FLA.Value + " WHERE MotorID = '" + txtMotorModel.Text + "' AND VoltageID = 1";
                    tsql += " UPDATE MotorModelFLA SET [FLA] = " + num208_240_1_60_FLA.Value + " WHERE MotorID = '" + txtMotorModel.Text + "' AND VoltageID = 2";
                    tsql += " UPDATE MotorModelFLA SET [FLA] = " + num208_240_3_60_FLA.Value + " WHERE MotorID = '" + txtMotorModel.Text + "' AND VoltageID = 5";
                    tsql += " UPDATE MotorModelFLA SET [FLA] = " + num480_3_60_FLA.Value + " WHERE MotorID = '" + txtMotorModel.Text + "' AND VoltageID = 9";
                    tsql += " UPDATE MotorModelFLA SET [FLA] = " + num600_3_60_FLA.Value + " WHERE MotorID = '" + txtMotorModel.Text + "' AND VoltageID = 8";

                    tsql += "COMMIT TRAN";

                    if (Query.Execute(tsql))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                if (reload)
                {
                    Query.UpdateServerTableVersion("MotorModel");
                    Query.UpdateServerTableVersion("MotorModelFLA");
                    Query.UpdateServerTableVersion("v_Evaporators");

                    FillTable();

                    FillMotorModel();

                    FillTableView();
                }
            } 
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmMotorModel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}