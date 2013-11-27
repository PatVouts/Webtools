using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.CondensingUnit
{
    public partial class FrmDrawingManagerCondesingUnit : Form
    {
        private readonly string[] _strTableList = { "CondensingUnitCompressorManufacturer", "CondensingUnitCompressorType", "CondensingUnitRefrigerant", "CondensingUnitType", "Voltage", "CondensingUnitApplication", "CondensingUnitCompressorAmount", "CondensingUnitOptionFirstPart" };

        public FrmDrawingManagerCondesingUnit()
        {
            InitializeComponent();
        }

        private void frmDrawingManagerCondesingUnit_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            //this call all the fill combobox function needed
            Fill_Lists();

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

        private void Fill_Lists()
        {
            Fill_FirstPart();

            Fill_ThirdPart();

            Fill_Compressor();

            Fill_Voltage();

            RefreshOptionList();

            Fill_OptionList();

            Fill_ListOfDrawings();
        }

        private void RefreshOptionList()
        {
            lvDrawingList.Items.Clear();

            DataTable dtDrawingList = Query.Select("SELECT * FROM CondensingUnitDrawingManager ORDER BY Description");

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

            string[] listOfDrawingOnServer = DrawingManager.GetListOfDrawings("REFPLUS", DrawingManager.DrawingCategory.CondensingUnit);

            for (int i = 0; i < listOfDrawingOnServer.Length; i++)
            {
                ComboBoxControl.AddItem(cboDrawing, listOfDrawingOnServer[i], listOfDrawingOnServer[i]);
            }

            if (cboDrawing.FindString(currentValue) >= 0)
            {
                cboDrawing.SelectedIndex = cboDrawing.FindString(currentValue);
            }
        }

        private void cmdUploadAndPreviewFile_Click(object sender, EventArgs e)
        {
            var dwgFileManager = new Generic.FrmDrawingFileManager();
            dwgFileManager.ShowDialog();

            Fill_ListOfDrawings();
        }

        private void Fill_FirstPart()
        {
            lvFirstPart.Items.Clear();

            DataTable dtFirstPart = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitOptionFirstPart"], "", "UnitType, AirFlow, CompressorType");

            foreach (DataRow drFirstPart in dtFirstPart.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvFirstPart);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drFirstPart["UnitType"].ToString();
                myItem.SubItems[2].Text = drFirstPart["AirFlow"].ToString();
                myItem.SubItems[3].Text = drFirstPart["CompressorType"].ToString();
                lvFirstPart.Items.Add(myItem);
            }

            lvFirstPart.Refresh();
        }

        private void Fill_OptionList()
        {
            lvOptions.Items.Clear();

            var myItem = new GlacialComponents.Controls.GLItem(lvOptions);

            myItem.SubItems[0].Text = "";
            myItem.SubItems[1].Text = "NONE";

            lvOptions.Items.Add(myItem);

            for (int i = 65; i <= 90; i++)
            {
                myItem = new GlacialComponents.Controls.GLItem(lvOptions);

                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = char.ConvertFromUtf32(i).ToUpper();

                lvOptions.Items.Add(myItem);
            }

            lvOptions.Refresh();
        }

        private string GetOptions()
        {
            string strOptions = "";

            for (int i = 0; i < lvOptions.Items.Count; i++)
            {
                string s = lvOptions.Items[i].SubItems[1].Text;

                if (s == "NONE")
                {
                    s = "0";
                }

                if (lvOptions.Items[i].SubItems[0].Checked)
                {
                    strOptions += s + ",";
                }
            }

            return strOptions;
        }

        private void SelectOptions(string options)
        {
            string[] s = options.Split(',');

            for (int iString = 0; iString < s.Length; iString++)
            {
                string search = s[iString];

                if (search == "0")
                {
                    search = "NONE";
                }

                for (int i = 0; i < lvOptions.Items.Count; i++)
                {
                    if (lvOptions.Items[i].SubItems[1].Text == search)
                    {
                        lvOptions.Items[i].SubItems[0].Checked = true;
                        i = lvOptions.Items.Count;
                    }
                }
            }
        }

        private void Fill_ThirdPart()
        {
            lvThirdPart.Items.Clear();

            DataTable dtThirdPart = GetThirdPart();

            foreach (DataRow drThirdPart in dtThirdPart.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvThirdPart);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drThirdPart["CompressorManufacturer"].ToString();
                myItem.SubItems[2].Text = drThirdPart["Application"].ToString();
                myItem.SubItems[3].Text = drThirdPart["Refrigerant"].ToString();
                lvThirdPart.Items.Add(myItem);
            }

            lvThirdPart.Refresh();
        }

        private void Fill_Compressor()
        {
            lvCompressor.Items.Clear();

            foreach (DataRow drCompressor in Public.DSDatabase.Tables["CondensingUnitCompressorAmount"].Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvCompressor);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drCompressor["Number"].ToString();
                lvCompressor.Items.Add(myItem);
            }

            lvCompressor.Refresh();
        }

        private void Fill_Voltage()
        {
            lvVoltage.Items.Clear();

            foreach (DataRow drVoltage in Public.DSDatabase.Tables["Voltage"].Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvVoltage);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drVoltage["VoltDescription"].ToString();
                myItem.SubItems[2].Text = drVoltage["VoltageID"].ToString();
                lvVoltage.Items.Add(myItem);
            }

            lvVoltage.Refresh();
        }

        private static DataTable GetThirdPart()
        {
            var dtThirdPart = new DataTable();
            dtThirdPart.Columns.Add("CompressorManufacturer", typeof(string));
            dtThirdPart.Columns.Add("Application", typeof(string));
            dtThirdPart.Columns.Add("Refrigerant", typeof(string));

            DataTable dtRefrigerant = Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CondensingUnitRefrigerant"]);

            foreach (DataRow drManufacturer in Public.DSDatabase.Tables["CondensingUnitCompressorManufacturer"].Rows)
            {
                foreach (DataRow drApplication in Public.DSDatabase.Tables["CondensingUnitApplication"].Rows)
                {
                    foreach (DataRow drRefrigerant in dtRefrigerant.Rows)
                    {
                        DataRow drThirdPart = dtThirdPart.NewRow();
                        drThirdPart["CompressorManufacturer"] = drManufacturer["CompressorManufacturerParameter"].ToString();
                        drThirdPart["Application"] = drApplication["Parameter"].ToString();
                        drThirdPart["Refrigerant"] = drRefrigerant["RefrigerantParameter"].ToString();
                        dtThirdPart.Rows.Add(drThirdPart);
                    }
                }
            }

            return Public.SelectAndSortTable(dtThirdPart, "", "CompressorManufacturer, Application, Refrigerant");
        }

        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

        private void SetAllHP(bool setAll)
        {
            if (setAll)
            {
                numMinHP.Value = numMinHP.Minimum;
                numMaxHP.Value = numMaxHP.Maximum;
            }
            else
            {
                numMinHP.Value = 0m;
                numMaxHP.Value = 0m;
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

        private void CheckCompressor(string compressor)
        {
            for (int i = 0; i < lvCompressor.Items.Count; i++)
            {
                if (Convert.ToInt32(lvCompressor.Items[i].SubItems[1].Text) == Convert.ToInt32(compressor))
                {
                    lvCompressor.Items[i].SubItems[0].Checked = true;
                    i = lvCompressor.Items.Count;
                }
            }
        }

        private void CheckThirdPart(string thirdPart)
        {
            for (int i = 0; i < lvThirdPart.Items.Count; i++)
            {
                if (lvThirdPart.Items[i].SubItems[1].Text == thirdPart.Substring(0, 1) &&
                    lvThirdPart.Items[i].SubItems[2].Text == thirdPart.Substring(1, 1) &&
                    lvThirdPart.Items[i].SubItems[3].Text == thirdPart.Substring(2, 1))
                {
                    lvThirdPart.Items[i].SubItems[0].Checked = true;
                    i = lvThirdPart.Items.Count;
                }
            }
        }

        private void CheckFirstPart(string firstPart)
        {
            for (int i = 0; i < lvFirstPart.Items.Count; i++)
            {
                if (lvFirstPart.Items[i].SubItems[1].Text == firstPart.Substring(0, 1) &&
                    lvFirstPart.Items[i].SubItems[2].Text == firstPart.Substring(1, 1) &&
                    lvFirstPart.Items[i].SubItems[3].Text == firstPart.Substring(2, 1))
                {
                    lvFirstPart.Items[i].SubItems[0].Checked = true;
                    i = lvFirstPart.Items.Count;
                }
            }
        }

        private void cmdFirstPartPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvFirstPart, true);
        }

        private void cmdFirstPartUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvFirstPart, false);
        }

        private void cmdCompressorPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvCompressor, true);
        }

        private void cmdCompressorUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvCompressor, false);
        }

        private void cmdThirdPartPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvThirdPart, true);
        }

        private void cmdThirdPartUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvThirdPart, false);
        }

        private void cmdVoltagePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage, true);
        }

        private void cmdVoltageUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage, false);
        }

        private void cmdOptionsPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvOptions, true);
        }

        private void cmdOptionsUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvOptions, false);
        }

        private void cmdHPPickAll_Click(object sender, EventArgs e)
        {
            SetAllHP(true);
        }

        private void cmdHPUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllHP(false);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            LoadOption();
        }


        private void ClearAll()
        {
            txtDescription.Text = "";
            cboDrawing.SelectedIndex = -1;

            SetAllCheckValues(lvFirstPart, false);
            SetAllHP(false);
            SetAllCheckValues(lvCompressor, false);
            SetAllCheckValues(lvThirdPart, false);
            SetAllCheckValues(lvVoltage, false);
            SetAllCheckValues(lvOptions, false);
        }

        private void LoadOption()
        {
            if (lvDrawingList.SelectedItems.Count > 0)
            {
                //load option data
                DataTable dtDrawing = Query.Select("SELECT * FROM CondensingUnitDrawingManager WHERE Description = '" + ((GlacialComponents.Controls.GLItem)lvDrawingList.SelectedItems[0]).SubItems[0].Text + "'");

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

                    string[] strFirstPart = dtDrawing.Rows[0]["FirstPart"].ToString().Split(',');

                    foreach (string str in strFirstPart)
                    {
                        if (str != "")
                            CheckFirstPart(str);
                    }

                    numMinHP.Value = Convert.ToDecimal(dtDrawing.Rows[0]["MinHP"]);
                    numMaxHP.Value = Convert.ToDecimal(dtDrawing.Rows[0]["MaxHP"]);

                    string[] strCompressor = dtDrawing.Rows[0]["Compressor"].ToString().Split(',');

                    foreach (string str in strCompressor)
                    {
                        if (str != "")
                            CheckCompressor(str);
                    }

                    string[] strThirdPart = dtDrawing.Rows[0]["ThirdPart"].ToString().Split(',');

                    foreach (string str in strThirdPart)
                    {
                        if (str != "")
                            CheckThirdPart(str);
                    }

                    string[] strVoltage = dtDrawing.Rows[0]["Voltage"].ToString().Split(',');

                    foreach (string str in strVoltage)
                    {
                        if (str != "")
                            CheckVoltage(str);
                    }

                    SelectOptions(dtDrawing.Rows[0]["Options"].ToString());

                }

                dtDrawing.Dispose();   
            }
        }

        private void lvDrawingList_Click(object sender, EventArgs e)
        {
            LoadOption();
        }

        private void lvDrawingList_SelectedIndexChanged(object source, GlacialComponents.Controls.ClickEventArgs e)
        {
            LoadOption();
        }

         private void DeleteOption()
        {
            if (lvDrawingList.SelectedItems.Count > 0)
            {
                if (Public.LanguageQuestionBox("Are you sure you want to delete the selected drawing filter ?", "Etes-vous sur de vouloir supprimer ce filtre de dessing ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //delete
                    DeleteSpecificOption(((GlacialComponents.Controls.GLItem)lvDrawingList.SelectedItems[0]).SubItems[0].Text);
                    
                    //update server
                    Query.UpdateServerTableVersion("CondensingUnitDrawingManager");

                    //relod list
                    RefreshOptionList();
                }
            }
        }

        private void DeleteSpecificOption(string description)
        {
            Query.Execute("DELETE FROM CondensingUnitDrawingManager WHERE Description = '" + description + "'");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteOption();
        }

        private bool SavingConfirmation()
        {
            return Public.LanguageQuestionBox("Are you sure you want to save ?", "Etes-vous sur de vouloir sauvegarder ?", MessageBoxButtons.YesNo) == DialogResult.Yes;
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
                    Public.LanguageBox("Description cannot contain the following character(s) : '", "La description ne peut contenir le/les caract�re(s) suivants : '");
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
                Public.LanguageBox("You must select a drawing.", "Vous devez s�lectionner un dessin.");
            }

            return valid;
        }

        private bool ValidateOverwrite()
        {
            bool valid = true;

            //load option data
            DataTable dtDrawing = Query.Select("SELECT * FROM CondensingUnitDrawingManager WHERE Description = '" + txtDescription.Text + "'");

            if (dtDrawing.Rows.Count > 0)
            {
                if (Public.LanguageQuestionBox("This drawing logic description already exists. Do you want to overwrite (yes) or cancel (no) ?", "Cette logique de dessin existe d�ja.  Voulez vous l'�craser (Oui) or annuler (Non) ?", MessageBoxButtons.YesNo) == DialogResult.No)
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

                            string firstPart = "";

                            for (int i = 0; i < lvFirstPart.Items.Count; i++)
                            {
                                if (lvFirstPart.Items[i].SubItems[0].Checked)
                                {
                                    firstPart += lvFirstPart.Items[i].SubItems[1].Text + lvFirstPart.Items[i].SubItems[2].Text + lvFirstPart.Items[i].SubItems[3].Text + ",";
                                }
                            }

                            decimal minHP = numMinHP.Value;
                            decimal maxHP = numMaxHP.Value;

                            string compressor = "";

                            for (int i = 0; i < lvCompressor.Items.Count; i++)
                            {
                                if (lvCompressor.Items[i].SubItems[0].Checked)
                                {
                                    compressor += lvCompressor.Items[i].SubItems[1].Text.PadLeft(2, '0') + ",";
                                }
                            }

                            string thirdPart = "";

                            for (int i = 0; i < lvThirdPart.Items.Count; i++)
                            {
                                if (lvThirdPart.Items[i].SubItems[0].Checked)
                                {
                                    thirdPart += lvThirdPart.Items[i].SubItems[1].Text + lvThirdPart.Items[i].SubItems[2].Text + lvThirdPart.Items[i].SubItems[3].Text + ",";
                                }
                            }

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
                            tsql += @"INSERT INTO CondensingUnitDrawingManager
                                     ([Description]
                                     ,[Drawing]
                                     ,[FirstPart]
                                     ,[MinHP]
                                     ,[MaxHP]
                                     ,[Compressor]
                                     ,[ThirdPart]
                                     ,[Voltage]
                                     ,[Options])
                               VALUES
                                     ('" + description + @"'
                                     ,'" + strDrawing + @"'                                     
                                     ,'" + firstPart + @"'
                                     ," + minHP + @"
                                     ," + maxHP + @"
                                     ,'" + compressor + @"'
                                     ,'" + thirdPart + @"'
                                     ,'" + voltage + @"'
                                     ,'" + GetOptions() + "')";

                            if (Query.Execute(tsql))
                            {
                                //update server
                                Query.UpdateServerTableVersion("CondensingUnitDrawingManager");

                                Public.LanguageBox("Save sucessful.", "Sauvegarde reussie.");
                                RefreshOptionList();
                            }
                            else
                            {
                                Public.LanguageBox("Could not save.", "�chec de sauvegarde.");
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