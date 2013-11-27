using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Evaporator
{
    public partial class FrmEvaporatorDrawingManager : Form
    {
        private readonly string[] _strTableList = { "EvaporatorVoltage", "EvaporatorSerie" };

        public FrmEvaporatorDrawingManager()
        {
            InitializeComponent();
        }

        private void frmEvaporatorDrawingManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            //this call all the fill combobox function needed
            Fill_Lists();
        }

        private void RefreshOptionList()
        {
            lvDrawingList.Items.Clear();

            DataTable dtDrawingList = Query.Select("SELECT * FROM EvaporatorDrawingManager ORDER BY Description");

            foreach (DataRow drDrawing in dtDrawingList.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvDrawingList);
                myItem.SubItems[0].Text = drDrawing["Description"].ToString();
                lvDrawingList.Items.Add(myItem);
            }

            lvDrawingList.Refresh();
        }

        private void Fill_ListOfDrawings()
        {
            string currentValue = cboDrawing.Text;

            cboDrawing.Items.Clear();

            string[] listOfDrawingOnServer = DrawingManager.GetListOfDrawings("REFPLUS", DrawingManager.DrawingCategory.Evaporator);

            for (int i = 0; i < listOfDrawingOnServer.Length; i++)
            {
                ComboBoxControl.AddItem(cboDrawing, listOfDrawingOnServer[i], listOfDrawingOnServer[i]);
            }

            if (cboDrawing.FindString(currentValue) >= 0)
            {
                cboDrawing.SelectedIndex = cboDrawing.FindString(currentValue);
            }
        }

        private void ClearAll()
        {
            txtDescription.Text = "";
            cboDrawing.SelectedIndex = -1;

            SetAllCheckValues(lvSerie, false);
            SetAllCapacity(false);
            SetAllCheckValues(lvVoltage, false);
        }

        private void LoadOption()
        {
            if (lvDrawingList.SelectedItems.Count > 0)
            {
                //load option data
                DataTable dtDrawing = Query.Select("SELECT * FROM EvaporatorDrawingManager WHERE Description = '" + ((GlacialComponents.Controls.GLItem)lvDrawingList.SelectedItems[0]).SubItems[0].Text + "'");

                //clear
                ClearAll();

                //if data found fill the controls
                if (dtDrawing.Rows.Count > 0)
                {

                    txtDescription.Text = dtDrawing.Rows[0]["Description"].ToString();
                    if (cboDrawing.FindString(dtDrawing.Rows[0]["Drawing"].ToString()) >= 0)
                    {
                        cboDrawing.SelectedIndex = cboDrawing.FindString(dtDrawing.Rows[0]["Drawing"].ToString());
                    }
                    else
                    {
                        Public.LanguageBox("Drawing does not exist anymore.", "Le dessin n'existe plus.");
                        cboDrawing.SelectedIndex = -1;
                    }

                    string[] strSerie = dtDrawing.Rows[0]["Serie"].ToString().Split(',');

                    foreach (string str in strSerie)
                    {
                        if (str != "")
                            CheckSerie(str);
                    }

                    numMinCapacity.Value = Convert.ToDecimal(dtDrawing.Rows[0]["MinCapacity"]);
                    numMaxCapacity.Value = Convert.ToDecimal(dtDrawing.Rows[0]["MaxCapacity"]);

                 
                    string[] strVoltage = dtDrawing.Rows[0]["Voltage"].ToString().Split(',');

                    foreach (string str in strVoltage)
                    {
                        if (str != "")
                            CheckVoltage(str);
                    }
                }

                dtDrawing.Dispose();
            }
        }

        private void Fill_Lists()
        {
            Fill_FillSerie();

            Fill_Voltage();

            RefreshOptionList();

            Fill_ListOfDrawings();
        }

        private void CheckSerie(string serie)
        {
            for (int i = 0; i < lvSerie.Items.Count; i++)
            {
                if (lvSerie.Items[i].SubItems[1].Text == serie.Substring(0, 1) &&
                    lvSerie.Items[i].SubItems[2].Text == serie.Substring(1, 1) &&
                    lvSerie.Items[i].SubItems[3].Text == serie.Substring(2, 1))
                {
                    lvSerie.Items[i].SubItems[0].Checked = true;
                    i = lvSerie.Items.Count;
                }
            }
        }

        private void CheckVoltage(string voltage)
        {
            for (int i = 0; i < lvVoltage.Items.Count; i++)
            {
                if (Convert.ToInt32(lvVoltage.Items[i].SubItems[2].Text) == Convert.ToInt32(voltage))
                {
                    lvVoltage.Items[i].SubItems[0].Checked = true;
                    i = lvVoltage.Items.Count;
                }
            }
        }

        private void Fill_FillSerie()
        {
            lvSerie.Items.Clear();

            DataTable dtSerie = Public.SelectAndSortTable(Public.DSDatabase.Tables["EvaporatorSerie"], "", "Type, Style, DefrostType");

            foreach (DataRow drSerie in dtSerie.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvSerie);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drSerie["Type"].ToString();
                myItem.SubItems[2].Text = drSerie["Style"].ToString();
                myItem.SubItems[3].Text = drSerie["DefrostType"].ToString();
                lvSerie.Items.Add(myItem);
            }

            lvSerie.Refresh();
        }

        private void Fill_Voltage()
        {
            lvVoltage.Items.Clear();

            foreach (DataRow drVoltage in Public.DSDatabase.Tables["EvaporatorVoltage"].Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvVoltage);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drVoltage["VoltDescription"].ToString();
                myItem.SubItems[2].Text = drVoltage["VoltageID"].ToString();
                lvVoltage.Items.Add(myItem);
            }

            lvVoltage.Refresh();
        }

        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

        private void SetAllCapacity(bool setAll)
        {
            if (setAll)
            {
                numMinCapacity.Value = numMinCapacity.Minimum;
                numMaxCapacity.Value = numMaxCapacity.Maximum;
            }
            else
            {
                numMinCapacity.Value = 0m;
                numMaxCapacity.Value = 0m;
            }
        }

        private void cmdSeriePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSerie, true);
        }

        private void cmdSerieUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSerie, false);
        }

        private void cmdVoltagePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage, true);
        }

        private void cmdVoltageUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage, false);
        }

        private void cmdCapacityPickAll_Click(object sender, EventArgs e)
        {
            SetAllCapacity(true);
        }

        private void cmdCapacityUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCapacity(false);
        }

        private void lvDrawingList_Click(object sender, EventArgs e)
        {
            LoadOption();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            LoadOption();
        }

        private void cmdUploadAndPreviewFile_Click(object sender, EventArgs e)
        {
            var dwgFileManager = new Generic.FrmDrawingFileManager();
            dwgFileManager.ShowDialog();

            Fill_ListOfDrawings();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvDrawingList_SelectedIndexChanged(object source, GlacialComponents.Controls.ClickEventArgs e)
        {
            LoadOption();
        }

        private void DeleteSpecificOption(string description)
        {
            Query.Execute("DELETE FROM EvaporatorDrawingManager WHERE Description = '" + description + "'");
        }

        private void DeleteOption()
        {
            if (lvDrawingList.SelectedItems.Count > 0)
            {
                if (Public.LanguageQuestionBox("Are you sure you want to delete the selected drawing filter ?", "Êtes-vous sûr de vouloir supprimer ce filtre de dessin?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //delete
                    DeleteSpecificOption(((GlacialComponents.Controls.GLItem)lvDrawingList.SelectedItems[0]).SubItems[0].Text);

                    //update server
                    Query.UpdateServerTableVersion("EvaporatorDrawingManager");

                    //relod list
                    RefreshOptionList();
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteOption();
        }

        private bool SavingConfirmation()
        {
            return Public.LanguageQuestionBox("Are you sure you want to save ?", "Êtes-vous sûr de vouloir sauvegarder?", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private bool ValidateDescription()
        {
            bool valid = false;

            if (txtDescription.Text.Trim() != "")
            {
                if (!txtDescription.Text.Contains("'"))
                {
                    valid = true;
                }
                else
                {
                    Public.LanguageBox("Description cannot contain the following character(s) : '", "La description ne peut contenir le/les caractère(s) suivants : '");
                }
            }
            else
            {
                Public.LanguageBox("You must input a description", "Vous devez entrer une description");
            }

            return valid;
        }

        private bool ValidateDrawing()
        {

            bool valid = false;

            if (cboDrawing.SelectedIndex >= 0)
            {
                valid = true;
            }
            else
            {
                Public.LanguageBox("You must select a drawing.", "Vous devez sélectionner un dessin.");
            }

            return valid;
        }

        private bool ValidateOverwrite()
        {
            bool valid = true;

            //load option data
            DataTable dtDrawing = Query.Select("SELECT * FROM EvaporatorDrawingManager WHERE Description = '" + txtDescription.Text + "'");

            if (dtDrawing.Rows.Count > 0)
            {
                if (Public.LanguageQuestionBox("This drawing logic description already exist. Do you want to overwrite (yes) or cancel (no) ?", "Cette logique de dessin existe déja.  Voulez vous l'écraser (Oui) or annuler (Non) ?", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    valid = false;
                }
            }

            dtDrawing.Dispose();

            return valid;
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtDescription.Text = StringManipulation.FilterInvalidCharacters(txtDescription.Text);
        }

        private void SaveOption()
        {
            //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
            ValidateInputsCharacterValidity();

            if (SavingConfirmation())
            {
                if (ValidateDescription())
                {
                    if (ValidateDrawing())
                    {
                        if (ValidateOverwrite())
                        {
                            string description = txtDescription.Text;
                            string strDrawing = cboDrawing.Text;

                            string serie = "";

                            for (int i = 0; i < lvSerie.Items.Count; i++)
                            {
                                if (lvSerie.Items[i].SubItems[0].Checked)
                                {
                                    serie += lvSerie.Items[i].SubItems[1].Text + lvSerie.Items[i].SubItems[2].Text + lvSerie.Items[i].SubItems[3].Text + ",";
                                }
                            }

                            decimal minCapacity = numMinCapacity.Value;
                            decimal maxCapacity = numMaxCapacity.Value;

                            string voltage = "";

                            for (int i = 0; i < lvVoltage.Items.Count; i++)
                            {
                                if (lvVoltage.Items[i].SubItems[0].Checked)
                                {
                                    voltage += lvVoltage.Items[i].SubItems[2].Text + ",";
                                }
                            }

                            DeleteSpecificOption(description);

                            string tsql = "";
                            tsql += @"INSERT INTO EvaporatorDrawingManager
                                     ([Description]
                                     ,[Drawing]
                                     ,[Serie]
                                     ,[MinCapacity]
                                     ,[MaxCapacity]
                                     ,[Voltage])
                               VALUES
                                     ('" + description + @"'
                                     ,'" + strDrawing + @"'                                     
                                     ,'" + serie + @"'
                                     ," + minCapacity + @"
                                     ," + maxCapacity + @"
                                     ,'" + voltage + @"')";

                            if (Query.Execute(tsql))
                            {
                                //update server
                                Query.UpdateServerTableVersion("EvaporatorDrawingManager");

                                Public.LanguageBox("Save sucessful.", "Sauvegarde reussie.");
                                RefreshOptionList();
                            }
                            else
                            {
                                Public.LanguageBox("Could not save.", "Échec de sauvegarde.");
                            }
                        }
                    }
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveOption();
        }
    }
}