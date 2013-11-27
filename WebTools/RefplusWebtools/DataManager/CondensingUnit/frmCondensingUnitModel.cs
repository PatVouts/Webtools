using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using GlacialComponents.Controls;

namespace RefplusWebtools.DataManager.CondensingUnit
{
    public partial class FrmCondensingUnitModel : Form
    {
        private readonly string[] _strTableList = { "CondensingUnitCompressorManufacturer", "CondensingUnitCompressorType", "CondensingUnitRefrigerant", "CondensingUnitType", "Voltage", "CondensingUnitApplication", "CoilFinType", "v_CoilFinTypeDefaults", "CoilFinShape", "CoilFinTypeShape", "v_CoilFinDefaults", "CoilFinMaterial", "CoilfinThickness", "CoilTubeMaterial", "v_CoilTubeDefaults" ,"CoilTubeThickness","CondensingUnitReceiver","CondensingUnitWaterCooledCondenser"};
        private readonly RefplusQuotesExcelDatabase _rquotes = new RefplusQuotesExcelDatabase();
        private bool _isLoading = true;
        private DataTable _dtCompressorList;

        private readonly Color _cCapacity = Color.Black;
        private readonly Color _cCommercialized = Color.Blue;


        public FrmCondensingUnitModel()
        {
            InitializeComponent();
        }
        

        private void frmCondensingUnitModel_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            lblCapacityColor.BackColor = _cCapacity;
            lblCommecializedColor.BackColor = _cCommercialized;

            //this call all the fill combobox function needed
            Fill_Combobox();

            //this function sets all the defaults at loading
            SetDefaults();

            _isLoading = false;

            Fill_CompressorList();

            SetTabsEnabledProperty(false);

            WindowState = FormWindowState.Maximized;

            
        }

        private bool HaveAccessToKFinAndR744()
        {
            //admin and Refplus group
            return (UserInformation.UserName == "admin" || UserInformation.GroupID == 0);
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void Fill_OldRefplusQuotModel()
        {
            cboOldReplusQuoteModel.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtModels = _rquotes.GetTable("rel_CUVoltage");

            if (dtModels != null)
            {
                dtModels = Public.SelectAndSortTable(dtModels, "", "CUModelID ASC, VoltageID ASC");

                foreach (DataRow drModel in dtModels.Rows)
                {
                    string strIndex = drModel["CUModelID"].ToString() + '-' + drModel["VoltageID"];
                    string strText = drModel["CUModelID"].ToString() + '-' + drModel["VoltageID"];
                    ComboBoxControl.AddItem(cboOldReplusQuoteModel, strIndex, strText);
                }

                dtModels.Dispose();
            }
        }

        private void RefreshCondensingUnitList()
        {
            cboCondensingUnitModel.Items.Clear();

            DataTable dtCondensingUnitModel = Query.Select("SELECT Model FROM CondensingUnitModel order by Model ASC");

            for (int i = 0; i < dtCondensingUnitModel.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboCondensingUnitModel, dtCondensingUnitModel.Rows[i]["Model"].ToString(), dtCondensingUnitModel.Rows[i]["Model"].ToString());
            }

            dtCondensingUnitModel.Dispose();

            if (cboCondensingUnitModel.Items.Count > 0)
            {
                cboCondensingUnitModel.SelectedIndex = 0;
            }
        }

        private void SetTabsEnabledProperty(bool valueEnabled)
        {
            ((Control)tabCompressor).Enabled = valueEnabled;
            ((Control)tabCoil).Enabled = valueEnabled;
            ((Control)tabBalancing).Enabled = valueEnabled;
        }

        private void Fill_Combobox()
        {
            Fill_Type();

            Fill_CompressorType();

            Fill_CompressorManufacturer();

            Fill_Refrigerant();

            Fill_Voltage();

            Fill_Application();

            Fill_FinType();

            Fill_Receiver();

            Fill_WaterCooled();

            RefreshCondensingUnitList();

            Fill_OldRefplusQuotModel();

            Fill_OptionList();
        }

        private void Fill_OptionList()
        {
            lvOptions.Items.Clear();

            var myItem = new GLItem(lvOptions);

            myItem.SubItems[0].Text = "";
            myItem.SubItems[1].Text = "NONE";

            lvOptions.Items.Add(myItem);

            for (int i = 65; i <= 90; i++)
            {
                myItem = new GLItem(lvOptions);

                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = char.ConvertFromUtf32(i).ToUpper();

                lvOptions.Items.Add(myItem);
            }

            lvOptions.Refresh();

           
        }

        private bool ValidateModel()
        {
            string strModel = txtModelName.Text;

            string[] parseModel = strModel.Split('-');

            bool error = true;

            //check if model is in 4 disctinctive parts
            if (parseModel.Length == 4)
            {
                //check if first part is 3 character i.e. OVS, ICZ...
                if (parseModel[0].Length == 3)
                {
                    //use the 2 first character of the first part for the unit type
                    string unitType = parseModel[0].Substring(0, 2);

                    //select that unit type info
                    DataTable dtUnitType = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitType"], "TypeParameter = '" + unitType + "'", "");

                    //if the unit type exist
                    if (dtUnitType.Rows.Count > 0)
                    {
                        //save the index where we find that unit type
                        int unitTypeIndex = cboType.FindString(unitType + " - " + dtUnitType.Rows[0]["Type"]);

                        //if the type exist in the combobox
                        if (unitTypeIndex >= 0)
                        {
                            //select the unit type
                            cboType.SelectedIndex = unitTypeIndex;

                            //use the third and last character of the first part for the compressor type
                            string compressorType = parseModel[0].Substring(2, 1);

                            //select that compressor type info
                            DataTable dtCompressorType = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorType"], "CompressorTypeParameter = '" + compressorType + "'", "");

                            //if the compressor type exist
                            if (dtCompressorType.Rows.Count > 0)
                            {
                                //save the index where we find that compressor type
                                int compressorTypeIndex = cboCompressorType.FindString(dtCompressorType.Rows[0]["CompressorType"].ToString());

                                //if the compressor type exist in the combobox
                                if (compressorTypeIndex >= 0)
                                {
                                    //select the compressor type
                                    cboCompressorType.SelectedIndex = compressorTypeIndex;

                                    //We have few validation we can do on the second part
                                    string strHPandorCompressor = parseModel[1];

                                    //the length must be between 2 and 4 and all characters must be number
                                    if (IsAllNumeric(strHPandorCompressor) && strHPandorCompressor.Length >=2 && strHPandorCompressor.Length <= 4)
                                    {
                                        //use the first character of the third part for the compressor manufacturer
                                        string compressorManufacturer = parseModel[2].Substring(0, 1);

                                        //select that compressor manufacturer info
                                        DataTable dtCompressorManufacturer = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorManufacturer"], "CompressorManufacturerParameter = '" + compressorManufacturer + "'", "");

                                        //if the compressor manufacturer exist
                                        if (dtCompressorManufacturer.Rows.Count > 0)
                                        {
                                            //save the index where we find that compressor type
                                            int compressorManufacturerIndex = cboCompressorManufacturer.FindString(dtCompressorManufacturer.Rows[0]["CompressorManufacturer"].ToString());

                                            //if the compressor manufacturer exist in the combobox
                                            if (compressorManufacturerIndex >= 0)
                                            {
                                                //select the compressor manufacturer
                                                cboCompressorManufacturer.SelectedIndex = compressorManufacturerIndex;

                                                //use the second character of the third part for the application
                                                string strApplication = parseModel[2].Substring(1, 1);

                                                //select that application info
                                                DataTable dtApplication = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitApplication"], "Parameter = '" + strApplication + "'", "");

                                                //if the application exist
                                                if (dtApplication.Rows.Count > 0)
                                                {
                                                    //save the index where we find that application
                                                    int applicationIndex = cboApplication.FindString(dtApplication.Rows[0]["Application"].ToString());

                                                    //if the application exist in the combobox
                                                    if (applicationIndex >= 0)
                                                    {
                                                        //select the application
                                                        cboApplication.SelectedIndex = applicationIndex;

                                                        //use the third character of the third part for the refrigerant
                                                        string strRefrigerant = parseModel[2].Substring(2, 1);

                                                        //select that refrigerant info
                                                        DataTable dtRefrigerant = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitRefrigerant"], "RefrigerantParameter = " + strRefrigerant, "");

                                                        //if the refrigerant exist
                                                        if (dtRefrigerant.Rows.Count > 0)
                                                        {
                                                            //save the index where we find that refrigerant
                                                            int refrigerantIndex = cboRefrigerant.FindString(dtRefrigerant.Rows[0]["Refrigerant"].ToString());

                                                            //if the refrigerant exist in the combobox
                                                            if (refrigerantIndex >= 0)
                                                            {
                                                                //select the refrigerant
                                                                cboRefrigerant.SelectedIndex = refrigerantIndex;

                                                                //now validate the fourth part it must be between 1 and 4 character

                                                                if (parseModel[3].Length >= 1 && parseModel[3].Length <= 4)
                                                                {
                                                                    //use the first character of the fourth part for the voltageid
                                                                    string strVoltageID = parseModel[3].Substring(0, 1);

                                                                    //select that refrigerant info
                                                                    DataTable dtVoltage = Public.SelectAndSortTable(Public.DSDatabase.Tables["Voltage"], "VoltageID = " + strVoltageID, "");

                                                                    //if the refrigerant exist
                                                                    if (dtVoltage.Rows.Count > 0)
                                                                    {
                                                                        //save the index where we find that refrigerant
                                                                        int voltageIndex = cboVoltage.FindString(dtVoltage.Rows[0]["VoltDescription"].ToString());

                                                                        //if the refrigerant exist in the combobox
                                                                        if (voltageIndex >= 0)
                                                                        {
                                                                            //select the voltage
                                                                            cboVoltage.SelectedIndex = voltageIndex;

                                                                            //if the fourth part is 1 character it's only the voltage
                                                                            //so it's good if voltage good. we do need to check for possible
                                                                            //options none to 3 letters
                                                                            if (parseModel[3].Length > 1)
                                                                            {
                                                                                //the options are only letters and must be in alphabetical order
                                                                                if (IsAllLetter(parseModel[3].Substring(1)))
                                                                                {
                                                                                    //now check the order
                                                                                    if (AllCharactersOrdered(parseModel[3].Substring(1)))
                                                                                    {
                                                                                        error = false;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                //no error if it get here, the options are "optional"
                                                                                error = false;
                                                                            }
                                                                        }
                                                                    }

                                                                    dtVoltage.Dispose();
                                                                }
                                                            }
                                                        }

                                                        dtRefrigerant.Dispose();
                                                    }
                                                }

                                                dtApplication.Dispose();
                                            }
                                        }

                                        dtCompressorManufacturer.Dispose();
                                    }
                                }
                            }

                            dtCompressorType.Dispose();
                        }
                    }

                    dtUnitType.Dispose();
                }
            }

            if (error)
            {
                Public.LanguageBox("Invalid Model Name", "Nom de modèle invalide");
            }

            return !error;
        }

        private bool AllCharactersOrdered(string valueText)
        {
            for (int i = 1; i < valueText.Length; i++)
            {
                if (String.Compare(valueText.Substring(i - 1, 1), valueText.Substring(i, 1), StringComparison.Ordinal) >= 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNumeric(string character)
        {
            return char.IsNumber(character, 0);
        }

        private bool IsLetter(string character)
        {
            return char.IsLetter(character, 0);
        }


        private bool IsAllLetter(string valueText)
        {
            for (int i = 0; i < valueText.Length; i++)
            {
                if (!IsLetter(valueText.Substring(i, 1)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsAllNumeric(string valueText)
        {
            for (int i = 0; i < valueText.Length; i++)
            {
                if (!IsNumeric(valueText.Substring(i, 1)))
                {
                    return false;
                }
            }

            return true;
        }

        private void SetDefaults()
        {
            //INDOOR AIR-COOLED
            cboType.SelectedIndex = 0;

            //ALL
            cboCompressorType.SelectedIndex = 0;

            //ALL
            cboCompressorManufacturer.SelectedIndex = 0;

            //Application
            cboApplication.SelectedIndex = 0;

            //R-22
            ComboBoxControl.SetDefaultValue(cboRefrigerant, "R-22");

            //208-240/3/60
            ComboBoxControl.SetDefaultValue(cboVoltage, "208-240/3/60");

            cboCircuit.SelectedIndex = 0;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void Fill_MotorModel()
        {
            cboMotor.Items.Clear();

            DataTable dtTable = Query.Select("SELECT MotorModel.*, Voltage.VoltageID FROM MotorModel LEFT JOIN MotorModelFLA ON MotorModel.MotorID = MotorModelFLA.MotorID LEFT JOIN Voltage ON MotorModelFLA.VoltageID = Voltage.VoltageID WHERE Voltage.VoltageID = " + Voltage() + " ORDER BY MotorModel.MotorID, MotorModelFLA.VoltageID");

            foreach (DataRow dr in dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboMotor, dr["MotorID"].ToString(), dr["MotorID"].ToString());
            }

            cboMotor.SelectedIndex = 0;
        }

        private void Fill_WaterCooled()
        {
            cboWaterCooled.Items.Clear();

            foreach (DataRow drWaterCooled in Public.DSDatabase.Tables["CondensingUnitWaterCooledCondenser"].Rows)
            {
                string strIndex = drWaterCooled["WaterCooledModel"].ToString();
                string strText = drWaterCooled["WaterCooledModel"].ToString();
                ComboBoxControl.AddItem(cboWaterCooled, strIndex, strText);
            }

            cboWaterCooled.SelectedIndex = 0;
        }

        private void Fill_Receiver()
        {
            cboReceiver.Items.Clear();

            ComboBoxControl.AddItem(cboReceiver, "NONE", "NONE");

            foreach (DataRow drReceiver in Public.DSDatabase.Tables["CondensingUnitReceiver"].Rows)
            {
                string strIndex = drReceiver["ReceiverModel"].ToString();
                string strText = drReceiver["ReceiverModel"].ToString();
                ComboBoxControl.AddItem(cboReceiver, strIndex, strText);
            }

            cboReceiver.SelectedIndex = 0;
        }

      

        
    
        private void FormatBalancingTable()
        {
            lvBalancing.Items.Clear();
            lvBalancing.Columns.Clear();
            lvBalancing.Refresh();

            //add the header column for sst and ambient
            lvBalancing.Columns.Add(new GLColumn("Balancing \\ SST"));

            //add sst columns
            for (int i = Convert.ToInt32(numSSTMin.Value); i <= Convert.ToInt32(numSSTMax.Value); i++)
            {
                var myCol = new GLColumn
                {
                    ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox,
                    Width = Convert.ToInt32(numColumnWidth.Value),
                    Text = i.ToString(CultureInfo.InvariantCulture)
                };
                lvBalancing.Columns.Add(myCol);
            }

            //add rows to contain data for each ambient
            for (int i = Convert.ToInt32(numBalancingMin.Value); i <= Convert.ToInt32(numBalancingMax.Value); i++)
            {
                
                var myItem = new GLItem(lvBalancing);
                myItem.SubItems[0].Text = i.ToString(CultureInfo.InvariantCulture);

                int totalSST = Convert.ToInt32(numSSTMax.Value) - Convert.ToInt32(numSSTMin.Value);
                for (int sst = 0; sst <= totalSST; sst++)
                {
                    myItem.SubItems[sst + 1].Text = "";
                }

                lvBalancing.Items.Add(myItem);
            }

            lvBalancing.Refresh();
        }

        private void VerticalExtrapolation(ref bool valueChanged)
        {
            bool searchingForStart = true;
            int startPoint = 0;

            for (int col = 1; col < lvBalancing.Columns.Count; col++)
            {
                for (int row = 0; row < lvBalancing.Items.Count; row++)
                {
                    if (lvBalancing.Items[row].SubItems[col].Text != "")
                    {
                        try
                        {
                            if (searchingForStart)
                            {
                                startPoint = row;
                                searchingForStart = false;
                            }
                            else
                            {
                                ExtrapolateVerticalRange(startPoint, row, col, ref valueChanged);
                                startPoint = row;
                            }
                        }
                        catch (Exception ex)
                        {
                            Public.PushLog(ex.ToString(),"frmCondensingUnitModel VerticalExtrapolation");
                        }
                    }
                }

                searchingForStart = true;
            }
        }

        private void HorizontalExtrapolation(ref bool valueChanged)
        {
            bool searchingForStart = true;
            int startPoint = 0;

            for (int row = 0; row < lvBalancing.Items.Count; row++)
            {
                for (int col = 1; col < lvBalancing.Columns.Count; col++)
                {
                    if (lvBalancing.Items[row].SubItems[col].Text != "")
                    {
                        try
                        {
                            if (searchingForStart)
                            {
                                startPoint = col;
                                searchingForStart = false;
                            }
                            else
                            {
                                ExtrapolateHorizontalRange(startPoint, col, row, ref valueChanged);
                                startPoint = col;
                            }
                        }
                        catch (Exception ex)
                        {
                            Public.PushLog(ex.ToString(),"frmCondensingUnitModel HorizontalExtrapolation");
                        }
                    }
                }

                searchingForStart = true;
            }
           
        }

        private void ExtrapolateVerticalRange(int @from, int to, int col, ref bool valueChanged)
        {
            //between 2 value 1 degree appart there is no extrapolation needed
            if (to - @from > 1)
            {
                for (int row = 1; row < to - @from; row++)
                {
                    lvBalancing.Items[@from + row].SubItems[col].Text = Extrapolation(@from, to, Convert.ToDecimal(lvBalancing.Items[@from].SubItems[col].Text), Convert.ToDecimal(lvBalancing.Items[to].SubItems[col].Text), row).ToString(CultureInfo.InvariantCulture);
                    valueChanged = true;
                }
            }
        }

        private void ExtrapolateHorizontalRange(int @from, int to, int row, ref bool valueChanged)
        {
            //between 2 value 1 degree appart there is no extrapolation needed
            if (to - @from > 1)
            {
                for (int col = 1; col < to - @from; col++)
                {
                    lvBalancing.Items[row].SubItems[@from + col].Text = Extrapolation(@from, to, Convert.ToDecimal(lvBalancing.Items[row].SubItems[@from].Text), Convert.ToDecimal(lvBalancing.Items[row].SubItems[to].Text), col).ToString(CultureInfo.InvariantCulture);
                    valueChanged = true;
                }
            }
        }

        private decimal Extrapolation(int start, int end, decimal startValue, decimal endValue, int index)
        {
            return Math.Round(startValue + (index * ((endValue - startValue) / (end - start))), Convert.ToInt32(numDecimalPrecision.Value));
        }

        private void cmdFormatBalancingTable_Click(object sender, EventArgs e)
        {
            radCapacity.Checked = true;
            FormatBalancingTable();
        }

        private void cmdExtrapolate_Click(object sender, EventArgs e)
        {

            ThreadProcess.Start(Public.LanguageString("Extrapolation in progress", "Extrapolation en cours"));

            bool valueChanged = true;

            while (valueChanged)
            {
                valueChanged = false;
                HorizontalExtrapolation(ref valueChanged);
                VerticalExtrapolation(ref valueChanged);
            }

            ThreadProcess.Stop();
            Focus();
        }

        private void numColumnWidth_ValueChanged(object sender, EventArgs e)
        {
            UpdateColumnWidth();
        }

        private void UpdateColumnWidth()
        {
            int width = Convert.ToInt32(numColumnWidth.Value);

            for (int i = 1; i < lvBalancing.Columns.Count; i++)
            {
                lvBalancing.Columns[i].Width = width;
            }

            lvBalancing.Refresh();
        }
     
        //return type
        private string Type()
        {
            return ComboBoxControl.ItemInformations(cboType, Public.DSDatabase.Tables["CondensingUnitType"], "UniqueID")[0]["TypeParameter"].ToString();
        }

        //return coil present
        private bool TypeCoilPresent()
        {
            return (Convert.ToInt32(ComboBoxControl.ItemInformations(cboType, Public.DSDatabase.Tables["CondensingUnitType"], "UniqueID")[0]["CoilPresent"].ToString()) == 1);
        }



        //fill type
        private void Fill_Type()
        {
            cboType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all type
            foreach (DataRow drType in Public.DSDatabase.Tables["CondensingUnitType"].Rows)
            {
                string strIndex = drType["UniqueID"].ToString();
                string strText = drType["TypeParameter"] + " - " + drType["Type"];
                ComboBoxControl.AddItem(cboType, strIndex, strText);
            }
        }

        //return compressor type
        private string CompressorType()
        {
            return ComboBoxControl.ItemInformations(cboCompressorType, Public.DSDatabase.Tables["CondensingUnitCompressorType"], "UniqueID")[0]["CompressorTypeParameter"].ToString();
        }

        //fill compressor type
        private void Fill_CompressorType()
        {
            cboCompressorType.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all compressor type
            foreach (DataRow drCompressorType in Public.DSDatabase.Tables["CondensingUnitCompressorType"].Rows)
            {
                string strIndex = drCompressorType["UniqueID"].ToString();
                string strText = drCompressorType["CompressorType"].ToString();
                ComboBoxControl.AddItem(cboCompressorType, strIndex, strText);
            }
        }

        //return compressor Manufacturer
        private string CompressorManufacturer()
        {
            return ComboBoxControl.ItemInformations(cboCompressorManufacturer, Public.DSDatabase.Tables["CondensingUnitCompressorManufacturer"], "UniqueID")[0]["CompressorManufacturerParameter"].ToString();
        }

        //fill compressor Manufacturer
        private void Fill_CompressorManufacturer()
        {
            cboCompressorManufacturer.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all compressor Manufacturer
            foreach (DataRow drCompressorManufacturer in Public.DSDatabase.Tables["CondensingUnitCompressorManufacturer"].Rows)
            {
                string strIndex = drCompressorManufacturer["UniqueID"].ToString();
                string strText = drCompressorManufacturer["CompressorManufacturer"].ToString();
                ComboBoxControl.AddItem(cboCompressorManufacturer, strIndex, strText);
            }
        }

        //return Refrigerant
        private string Refrigerant()
        {
            return ComboBoxControl.ItemInformations(cboRefrigerant, Public.DSDatabase.Tables["CondensingUnitRefrigerant"], "RefrigerantID")[0]["RefrigerantParameter"].ToString();
        }

        //fill Refrigerant
        private void Fill_Refrigerant()
        {
            cboRefrigerant.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtRefrigerant = Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CondensingUnitRefrigerant"]);

            //loop through all Refrigerant
            foreach (DataRow drRefrigerant in dtRefrigerant.Rows)
            {
                string strIndex = drRefrigerant["RefrigerantID"].ToString();
                string strText = drRefrigerant["Refrigerant"].ToString();
                ComboBoxControl.AddItem(cboRefrigerant, strIndex, strText);
            }

            dtRefrigerant.Dispose();
        }

        //return Voltage
        private string Voltage()
        {
            return ComboBoxControl.ItemInformations(cboVoltage, Public.DSDatabase.Tables["Voltage"], "UniqueID")[0]["VoltageID"].ToString();
        }

        //fill Voltage
        private void Fill_Voltage()
        {
            cboVoltage.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all Voltage
            foreach (DataRow drVoltage in Public.DSDatabase.Tables["Voltage"].Rows)
            {
                string strIndex = drVoltage["UniqueID"].ToString();
                string strText = drVoltage["VoltDescription"].ToString();
                ComboBoxControl.AddItem(cboVoltage, strIndex, strText);
            }
        }

        private void Fill_Application()
        {
            cboApplication.Items.Clear();

            foreach (DataRow drApplication in Public.DSDatabase.Tables["CondensingUnitApplication"].Rows)
            {
                string strIndex = drApplication["Parameter"].ToString();
                string strText = drApplication["Application"].ToString();
                ComboBoxControl.AddItem(cboApplication, strIndex, strText);
            }
        }

        private void Fill_CompressorList()
        {
            if (!_isLoading)
            {
                _dtCompressorList = Query.Select("SELECT CompressorData.*, Voltage.VoltDescription, Refrigerant.Refrigerant FROM CompressorData LEFT JOIN Voltage on CompressorData.VoltageID = Voltage.VoltageID LEFT JOIN Refrigerant on CompressorData.RefrigerantID = Refrigerant.RefrigerantID WHERE CompressorData.RefrigerantID =" + Refrigerant() + " AND CompressorData.VoltageID = " + Voltage() + " AND CompressorData.Manufacturer = '" + cboCompressorManufacturer.Text + "' AND CompressorData.Type = '" + cboCompressorType.Text + "' ORDER BY Compressor, CompressorData.RefrigerantID, CompressorData.VoltageID");

                cboCompressors.Items.Clear();

                foreach (DataRow dr in _dtCompressorList.Rows)
                {
                    ComboBoxControl.AddItem(cboCompressors, dr["Compressor"] + "|" + dr["RefrigerantID"] + "|" + dr["VoltageID"], dr["Compressor"] + " - " + dr["Refrigerant"] + " - " + dr["VoltDescription"]);
                }

                if (cboCompressors.Items.Count > 0)
                {
                    cboCompressors.SelectedIndex = 0;
                }
            }
        }

        private void cmdAddCompressor_Click(object sender, EventArgs e)
        {
            if (cboCompressors.SelectedIndex >= 0)
            {
                string strCompressorModel = ComboBoxControl.IndexInformation(cboCompressors).Split('|')[0];
                string strRefrigerantID = ComboBoxControl.IndexInformation(cboCompressors).Split('|')[1];
                string strVoltageID = ComboBoxControl.IndexInformation(cboCompressors).Split('|')[2];

                AddToCompressor(strCompressorModel, strVoltageID, strRefrigerantID, numLiquid.Value, numSuction.Value, numDischarge.Value, cboReceiver.Text, numRatio.Value);

                lvCompressor.Refresh();
            }
        }

        private void AddToCompressor(string model, string voltageID, string refrigerantID, decimal liquid, decimal suction, decimal discharge, string receiver, decimal ratio)
        {
            var myItem = new GLItem(lvCompressor);

            myItem.SubItems[0].Text = model;
            myItem.SubItems[1].Text = voltageID;
            myItem.SubItems[2].Text = refrigerantID;
            myItem.SubItems[3].Text = liquid.ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[4].Text = suction.ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[5].Text = discharge.ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[6].Text = receiver.Replace("NONE", "");
            myItem.SubItems[7].Text = ratio.ToString(CultureInfo.InvariantCulture);

            lvCompressor.Items.Add(myItem);
        }

        private void cboRefrigerant_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_CompressorList();
        }

        private void cboVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_CompressorList();

            Fill_MotorModel();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateCoilVisibility();
        }

        private void ValidateCoilVisibility()
        {
            //due to an issue with the set of visible that does not
            //use same variable as the getter of .Visible the update is only done on
            //a form refresh. so instead i store the value and set all control individually
            bool coilPresent = TypeCoilPresent();

            lblNoCoil.Visible = !coilPresent;
            pnlCoil.Enabled = coilPresent;
        }


        //return the FaceTube Amount of the selected FinType
        private decimal FinTypeFaceTube()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FaceTube"]);
        }

        //return the FinType Parameter
        private string FinTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString();
        }

        private void Fill_FinType()
        {
            cboFinType.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            var coilBackCode = new QuickCoil.QuickCoilCode();

            //for each fin type
            foreach (DataRow drFinType in Public.DSDatabase.Tables["CoilFinType"].Rows)
            {

                if (coilBackCode.IsFinTypeAvailableForThisCoil(Public.DSDatabase.Tables["v_CoilFinTypeDefaults"].Copy(), drFinType["UniqueID"].ToString(),"1" /*Condenser Coil is 1*/ , false))
                {

                    //2012-09-26 : #3400 Temporary code to prevent K fin for non refplus people
                    bool addFinType = !(drFinType["FinType"].ToString() == "K" && !HaveAccessToKFinAndR744());

                    if (addFinType)
                    {
                        //this is an output example
                        //C - 3/8", 1" X 3/4"
                        string strIndex = drFinType["UniqueID"].ToString();
                        string strText = drFinType["FinType"] + " - " + drFinType["TubeDiameter"] + "\", " + drFinType["FaceTube"] + "\" X " + drFinType["TubeRow"] + "\"";
                        ComboBoxControl.AddItem(cboFinType, strIndex, strText);
                    }
                }
            }

            cboFinType.SelectedIndex = 0;
        }

        //return the Fin shape parameter needed i nthe DLL and maybe some conditions
        private string FinShapeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinShape, Public.DSDatabase.Tables["CoilFinShape"], "UniqueID")[0]["FinShapeParameter"].ToString();
        }

        private void Fill_FinShape()
        {
            cboFinShape.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            //fin type
            string strFinType = FinTypeParameter();

            var coilBackCode = new QuickCoil.QuickCoilCode();

            //for each fin Shape
            foreach (DataRow drFinShape in Public.DSDatabase.Tables["CoilFinShape"].Rows)
            {
                if (coilBackCode.IsFinShapeAvailable(Public.DSDatabase.Tables["CoilFinTypeShape"], strFinType, drFinShape["FinShapeParameter"].ToString()))
                {
                    string strIndex = drFinShape["UniqueID"].ToString();
                    string strText = drFinShape["FinShape"].ToString();
                    ComboBoxControl.AddItem(cboFinShape, strIndex, strText);
                }
            }

            if (cboFinShape.Items.Count > 0)
            {
                cboFinShape.SelectedIndex = 0;
            }
        }

        private void cboFinType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear these 2 combobox that are depended on following selected values
            cboFinMaterial.Items.Clear();
            cboFinThickness.Items.Clear();
            cboTubeThickness.Items.Clear();

            //fill fins shape
            Fill_FinShape();

            //fill fin height
            Fill_FinHeight();

            //fill the fpi
            Fill_FPI();

            //fill tube material
            Fill_TubeMaterial();

            ClearCoilModel();
        }

        private decimal FinHeightParameter()
        {
            return Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight));
        }

        private void Fill_FinHeight()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            //this variable will be set to the height selected if one selected
            //since 0 in not possible as a choice it is used to check if there was something 
            //selected in the first place.
            decimal decSelectedHeight = 0;

            //if we have something selected save the selected value
            if (cboFinHeight.SelectedIndex >= 0)
            {
                decSelectedHeight = Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight));
            }
            cboFinHeight.Items.Clear();

            //this is the face tube value (i.e. 1.5,1.25,1) this number
            //is the "Steps" of possible fin height. If we have 1.5 the 3 first
            //possible height will be 1.5,3,4.5...
            decimal decFaceTubes = FinTypeFaceTube();

            decimal decMaxFinHeight = coilBackCode.MaxFinHeight("HR");

            //for each increment of face tubes, add the height
            for (decimal decFinHeight = decFaceTubes * QuickCoil.QuickCoilCode.DecMinHeightInFaceTubes; decFinHeight < decMaxFinHeight; decFinHeight += decFaceTubes)
            {
                ComboBoxControl.AddItem(cboFinHeight, decFinHeight.ToString(CultureInfo.InvariantCulture), decFinHeight.ToString(CultureInfo.InvariantCulture));
            }

            //now if the decSelectedHeight is Different than 0 it mean something was 
            //selected.
            if (decSelectedHeight != 0)
            {
                ComboBoxControl.SetIDDefaultValue(cboFinHeight, coilBackCode.FinHeightSelectClosestValueOfPreviouslySelectedOne(decSelectedHeight, decFaceTubes));
            }
            else
            {
                cboFinHeight.SelectedIndex = 0;
            }
        }

        private void cboFinShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill the fpi
            Fill_FPI();

            //fin material is related to fin shape
            Fill_FinMaterial();

            ClearCoilModel();
        }

        private void cboFinHeight_Leave(object sender, EventArgs e)
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            //we do it only if we have items in the control
            if (cboFinHeight.Items.Count > 0)
            {
                try
                {
                    //try to convert in decimal
                    decimal decEnteredValue = Convert.ToDecimal(((ComboBox)sender).Text);

                    //find and select the closest value
                    ComboBoxControl.SetIDDefaultValue(((ComboBox)sender), coilBackCode.FinHeightSelectClosestValueOfPreviouslySelectedOne(decEnteredValue, FinTypeFaceTube()));
                }
                catch(Exception ex)
                {
                    Public.PushLog(ex.ToString(),"frmCondensingUnitModel cboFinHeight_Leave");
                    //if it catch it mean what was entered wasn't a number or valid
                    //selection
                    ((ComboBox)sender).SelectedIndex = 0;
                }
            }
        }

        private void cboFinHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboFinHeight.Items.Count == 0)
            {
                e.SuppressKeyPress = true;
            }
        }

        private int FPIParameter()
        {
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI));
        }

        private void Fill_FPI()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            cboFPI.Items.Clear();

            //min and max fpi
            int intMinFPI = 0;
            int intMaxFPI = 0;

            //pass by reference the 2 variable which will return me the min and max fpi
            //available for this fin type
            coilBackCode.MinMaxFPI(Public.DSDatabase.Tables["v_CoilFinDefaults"], FinTypeParameter(), ref intMinFPI, ref intMaxFPI);

            //from the min to the max we add an item
            for (int intFPI = intMinFPI; intFPI <= intMaxFPI; intFPI++)
            {
                ComboBoxControl.AddItem(cboFPI, intFPI.ToString(CultureInfo.InvariantCulture), intFPI.ToString(CultureInfo.InvariantCulture));
            }

            if (cboFPI.Items.Count > 0)
            {
                cboFPI.SelectedIndex = cboFPI.FindString("12");
            }
        }

        private void cboFPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFinThickness.Items.Clear();

            //fill the fin material
            Fill_FinMaterial();

            ClearCoilModel();
        }

        private void cboFPI_Leave(object sender, EventArgs e)
        {
            //we do it only if we have items in the control
            if (cboFPI.Items.Count > 0)
            {
                try
                {
                    //try to convert in int
                    int intEnteredValue = Convert.ToInt32(cboFPI.Text);

                    //since fpi is only integer we can let the default function for combobox
                    //handle the auto select. If the number entered isn't found
                    //the function autoselect the first item.
                    ComboBoxControl.SetIDDefaultValue(cboFPI, intEnteredValue.ToString(CultureInfo.InvariantCulture));
                }
                catch(Exception ex)
                {
                    Public.PushLog(ex.ToString(),"frmCondensingUnitModel cboFPI_Leave");
                    //if it catch it mean what was entered wasn't a number or valid
                    //selection
                    cboFPI.SelectedIndex = 0;
                }
            }
        }

        private void cboFPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboFPI.Items.Count == 0)
            {
                e.SuppressKeyPress = true;
            }
        }

        //return the fin material parameter
        private string FinMaterialParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinMaterial, Public.DSDatabase.Tables["CoilFinMaterial"], "UniqueID")[0]["FinMaterialParameter"].ToString();
        }

        private void Fill_FinMaterial()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            cboFinMaterial.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinMaterial in Public.DSDatabase.Tables["CoilFinMaterial"].Rows)
            {
                //if we can found the fintype in the table that mean it's available for
                //the selected coil type so we can show it
                if (coilBackCode.IsFinMaterialAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), FinTypeParameter(), FinShapeParameter(), FPIParameter(), drFinMaterial["UniqueID"].ToString()))
                {
                    string strIndex = drFinMaterial["UniqueID"].ToString();
                    string strText = drFinMaterial["FinMaterial"].ToString();
                    ComboBoxControl.AddItem(cboFinMaterial, strIndex, strText);
                }
            }

            if (cboFinMaterial.Items.Count > 0)
            {
                cboFinMaterial.SelectedIndex = 0;
            }
        }

        private void cboFinMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill the fins thickness
            Fill_FinThickness();

        }

        //return the fin thickness parameter
        private string FinThicknessParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinThickness, Public.DSDatabase.Tables["CoilfinThickness"], "UniqueID")[0]["FinThickness"].ToString();
        }

        private void Fill_FinThickness()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            cboFinThickness.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinThickness in Public.DSDatabase.Tables["CoilfinThickness"].Rows)
            {
                //is fin thickness available for the following parameter
                if (coilBackCode.IsFinThicknessAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), FinTypeParameter(), FPIParameter(), ComboBoxControl.IndexInformation(cboFinMaterial), drFinThickness["FinThickness"].ToString()))
                {
                    string strIndex = drFinThickness["UniqueID"].ToString();
                    string strText = drFinThickness["FinThickness"].ToString();
                    ComboBoxControl.AddItem(cboFinThickness, strIndex, strText);
                }
            }

            //select the default thickness
            ComboBoxControl.SetDefaultValue(cboFinThickness, coilBackCode.FinThicknessDefault(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), FinTypeParameter(), FinShapeParameter(), FPIParameter(), ComboBoxControl.IndexInformation(cboFinMaterial)));
        }

        //get tube material parameter
        private string TubeMaterialParameter()
        {
            return ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["TubeMaterialParameter"].ToString();
        }

        //get tube type parameter
        private string TubeTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["TubeType"].ToString();
        }

        private void Fill_TubeMaterial()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            cboTubeMaterial.Items.Clear();

            if (cboFinType.SelectedIndex >= 0)
            {

                //these variable as use for easier modification of index or text showing
                //in the combobox

                DataTable dtTubeMaterial = Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CoilTubeMaterial"].Copy());

                //for each material type
                foreach (DataRow drTubeMaterial in dtTubeMaterial.Rows)
                {

                    if (coilBackCode.IsTubeMaterialAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], "HR", FinTypeParameter(), drTubeMaterial["UniqueID"].ToString(), false))
                    {
                        string strIndex = drTubeMaterial["UniqueID"].ToString();
                        string strText = drTubeMaterial["TubeMaterial"].ToString();
                        ComboBoxControl.AddItem(cboTubeMaterial, strIndex, strText);
                    }
                }

                dtTubeMaterial.Dispose();

                if (cboTubeMaterial.Items.Count > 0)
                {
                    cboTubeMaterial.SelectedIndex = 0;
                }
            }
        }

        private void cboTubeMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill tube thickness
            Fill_TubeThickness();
        }

        private string TubeThicknessParameter()
        {
            return ComboBoxControl.ItemInformations(cboTubeThickness, Public.DSDatabase.Tables["CoilTubeThickness"], "UniqueID")[0]["TubeThickness"].ToString();
        }

        private void Fill_TubeThickness()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            cboTubeThickness.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drTubeThickness in Public.DSDatabase.Tables["CoilTubeThickness"].Rows)
            {

                if (coilBackCode.IsTubeThicknessAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], "HR", FinTypeParameter(), ComboBoxControl.IndexInformation(cboTubeMaterial), drTubeThickness["TubeThickness"].ToString(), false))
                {
                    string strIndex = drTubeThickness["UniqueID"].ToString();
                    string strText = drTubeThickness["TubeThickness"].ToString();
                    ComboBoxControl.AddItem(cboTubeThickness, strIndex, strText);
                }
            }

            //select the default thickness
            ComboBoxControl.SetDefaultValue(cboTubeThickness, coilBackCode.TubeThicknessDefault(Public.DSDatabase.Tables["v_CoilTubeDefaults"], "HR", FinTypeParameter(), ComboBoxControl.IndexInformation(cboTubeMaterial), false));
        }

        //return Formated  (Fin Height / face tubes)
        private string ModelNameFormatedFinHeightDivideByFaceTube()
        {
            return Convert.ToInt32(FinHeightParameter() / FinTypeFaceTube()).ToString(CultureInfo.InvariantCulture).PadLeft(2, Convert.ToChar("0"));
        }

        //Coil Model Name
        private string CoilModelName()
        {
            //variable that will be return and contian the model name

            //add the prefix
            string strReturnValue = "C";

            //add the fin Type
            strReturnValue = strReturnValue + FinTypeParameter();

            //add the fin shape
            strReturnValue = strReturnValue + FinShapeParameter();

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add the tubes
            strReturnValue = strReturnValue + ModelNameFormatedFinHeightDivideByFaceTube();

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add number of rows (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + Convert.ToInt32(numRow.Value).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add FPI (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + Convert.ToDecimal(cboFPI.Text).ToString("0.").PadLeft(2, '0');

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add fin length (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + numFinLength.Value.ToString("0#.###");

            return strReturnValue;
        }

        private void cmdGenerateCoilModel_Click(object sender, EventArgs e)
        {
            GenerateCoilModel();  
        }

        private void GenerateCoilModel()
        {
            txtCoilModel.Text = CoilModelName();
        }

        private void ClearCoilModel()
        {
            txtCoilModel.Text = "";
        }

        private void cboFinHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCoilModel();
        }

        private void numFinLength_ValueChanged(object sender, EventArgs e)
        {
            ClearCoilModel();
        }

        private void numRow_ValueChanged(object sender, EventArgs e)
        {
            ClearCoilModel();
        }

        private void cmdAddWaterCooledCondenser_Click(object sender, EventArgs e)
        {
            AddToWaterCooled(cboWaterCooled.Text);

            lvWaterCooledCondenser.Refresh();
        }

        private void AddToWaterCooled(string model)
        {
            var myItem = new GLItem(lvWaterCooledCondenser);

            myItem.SubItems[0].Text = model;

            lvWaterCooledCondenser.Items.Add(myItem);
        }

        private void cmdRemoveCompressor_Click(object sender, EventArgs e)
        {
            if (lvCompressor.SelectedItems.Count > 0)
            {
                lvCompressor.Items.Remove(((GLItem)lvCompressor.SelectedItems[0]));

                lvCompressor.Refresh();
            }
        }

        private void cmdRemoveWaterCooledCondenser_Click(object sender, EventArgs e)
        {
            if (lvWaterCooledCondenser.SelectedItems.Count > 0)
            {
                lvWaterCooledCondenser.Items.Remove(((GLItem)lvWaterCooledCondenser.SelectedItems[0]));

                lvWaterCooledCondenser.Refresh();
            }
        }

        private void cmdValidateModel_Click(object sender, EventArgs e)
        {
            if (ValidateModel())
            {
                SetTabsEnabledProperty(true);
                cmdValidateModel.Visible = false;
                cmdChangeModel.Visible = true;
                txtModelName.Enabled = false;
                numHP.Enabled = true;
                numPrice.Enabled = true;
                numWeight.Enabled = true;
            }
        }

        private void cmdChangeModel_Click(object sender, EventArgs e)
        {
            SetTabsEnabledProperty(false);
            cmdValidateModel.Visible = true;
            cmdChangeModel.Visible = false;
            txtModelName.Enabled = true;
            numHP.Enabled = false;
            numPrice.Enabled = false;
            numWeight.Enabled = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int GetAmountOfCompressors()
        {
            return lvCompressor.Items.Count;
        }

        private int GetAmountOfCompressorsWithReceiver()
        {
            int receiver = 0;

            for (int i = 0; i < lvCompressor.Items.Count; i++)
            {
                if (lvCompressor.Items[i].SubItems[6].Text != "")
                {
                    ++receiver;
                }
            }

            return receiver;
        }

        private int GetAmountOfWaterCooled()
        {
            return lvWaterCooledCondenser.Items.Count;
        }

        private bool IsBalancingTableFilled()
        {
            bool capacityTableFilled = true;

            if (lvBalancing.Items.Count > 0)
            {
                for (int iRows = 0; iRows < lvBalancing.Items.Count; iRows++)
                {
                    for (int iCol = 0; iCol < lvBalancing.Columns.Count; iCol++)
                    {
                        try
                        {
                            if (lvBalancing.Items[iRows].SubItems[iCol].Text != "")
                            {
                            }
                            else
                            {
                                capacityTableFilled = false;
                            }
                        }
                        catch(Exception ex)
                        {
                            Public.PushLog(ex.ToString(),"frmCondensingUnitModel IsBalancingTableFilled");
                            capacityTableFilled = false;
                        }
                    }
                }
            }
            else
            {
                capacityTableFilled = false;
            }

            return capacityTableFilled;
        }

        private bool IsCoilModelValidated()
        {
            return ((pnlCoil.Enabled && txtCoilModel.Text != "") || !pnlCoil.Enabled); 
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool ValidateOverwrite()
        {
            bool bolOverwrite = true;

            DataTable dtUnit = Query.Select("SELECT * FROM CondensingUnitModel WHERE Model = '" + txtModelName.Text + "'");

            if (dtUnit.Rows.Count > 0)
            {
                if (Public.LanguageQuestionBox("The unit " + txtModelName.Text + " already exist. Do you want to overwrite ?", "L'unité " + txtModelName.Text + " existe déjà. Voulez vous l'écraser avec votre unité?", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    bolOverwrite = false;
                }
            }

            dtUnit.Dispose();

            return bolOverwrite;
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save this condensing unit ?", "Êtes-vous sûr de vouloir sauvegarder ce groupe compresseur-condenseur?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //must have at least 1 compressor
                if (GetAmountOfCompressors() > 0)
                {
                    if ((GetAmountOfCompressors() == GetAmountOfCompressorsWithReceiver() && GetAmountOfWaterCooled() == 0) ||
                        (GetAmountOfCompressorsWithReceiver() == 0 && GetAmountOfWaterCooled() <= GetAmountOfCompressors()))
                    {
                        if (IsCoilModelValidated())
                        {
                            if (IsBalancingTableFilled())
                            {
                                if (ValidateOverwrite())
                                {
                                    if (Query.Execute(BuildSaveQuery()))
                                    {
                                        Query.UpdateServerTableVersion("CondensingUnitModel");
                                        Query.UpdateServerTableVersion("CondensingUnitCompressorReceiverLink");
                                        Query.UpdateServerTableVersion("CondensingUnitWaterCooledCondenserLink");
                                        Query.UpdateServerTableVersion("CondensingUnitCoilLink");
                                        for (int i = -100; i <= 55; i++)
                                        {
                                            Query.UpdateServerTableVersion("v_CondensingUnitBalancing_" + i);
                                        }

                                        Public.LanguageBox("Unit saved sucessfully", "Unité sauvegardée avec succès.");
                                        RefreshCondensingUnitList();
                                    }
                                    else
                                    {
                                        Public.LanguageBox("Could not save.", "Échec de sauvegarde");
                                    }
                                }
                            }
                            else
                            {
                                Public.LanguageBox("You capacity table isn't filled properly.", "Votre tableau de capacité n'est pas rempli correctement.");
                            }
                        }
                        else
                        {
                            Public.LanguageBox("You need to validate your coil.", "Vous devez valider votre serpentin.");
                        }
                    }
                    else
                    {
                        Public.LanguageBox("Invalid receiver or water cooled quantity.", "Nombre de receveur ou refroidisseur a eau invalide.");
                    }
                }
                else
                {
                    Public.LanguageBox("Please add at least 1 compressor to your unit.", "Veuillez entrer au moins 1 compresseur à votre unité.");
                }
            }
        }

        private void ClearBalancing()
        {
            lvBalancing.Items.Clear();
            lvBalancing.Columns.Clear();
            lvBalancing.Refresh();
        }

        private void numBalancingMin_ValueChanged(object sender, EventArgs e)
        {
            ClearBalancing();
        }

        private void numSSTMin_ValueChanged(object sender, EventArgs e)
        {
            ClearBalancing();
        }

        private void numBalancingMax_ValueChanged(object sender, EventArgs e)
        {
            ClearBalancing();
        }

        private void numSSTMax_ValueChanged(object sender, EventArgs e)
        {
            ClearBalancing();
        }

        private string BuildSaveQuery()
        {
            string tsql = "";

            tsql += GetCondensingUnitModelTSQL();
            tsql += GetCondensingUnitCompressorReceiverTSQL();
            tsql += GetCondensingUnitWaterCooledTSQL();
            tsql += GetCondensingUnitCoilTSQL();
            tsql += GetCondensingUnitBalancingSQL();

            return tsql;
        }

        private string GetCondensingUnitBalancingSQL()
        {
             string tsql = "";

            
                tsql += " DELETE FROM CondensingUnitBalancing WHERE Model = '" + txtModelName.Text + "' ";

                for (int iRow = 0; iRow < lvBalancing.Items.Count; iRow++)
                {
                    for (int iCol = 1; iCol < lvBalancing.Columns.Count; iCol++)
                    {
                        tsql += @" INSERT INTO CondensingUnitBalancing
                             ([Model]
                             ,[Balancing]
                             ,[SST]
                             ,[Capacity])
                       VALUES
                             ('" + txtModelName.Text + @"'
                             ," + lvBalancing.Items[iRow].SubItems[0].Text + @"
                             ," + lvBalancing.Columns[iCol].Text + @"
                             ," + lvBalancing.Items[iRow].SubItems[iCol].Text + @") ";
                    }
                }
            
            return tsql;
        }

        private string GetCondensingUnitCoilTSQL()
        {
            string tsql = "";

            
            tsql += " DELETE FROM CondensingUnitCoilLink WHERE Model = '" + txtModelName.Text + "' ";

            if (txtCoilModel.Text != "")
            {

                /* NEW, TO PUSH WHEN COLUMNS ARE REMOVED*/
                  tsql += @" INSERT INTO CondensingUnitCoilLink
                    ([Model]
                    ,[CoilModel]
                    ,[CFM]
                    ,[CoilType]
                    ,[FinType]
                    ,[FinShape]
                    ,[Tubes]
                    ,[Row]
                    ,[FPI]
                    ,[Circuit]
                    ,[FinHeight]
                    ,[FinLength]
                    ,[FanWide]
                    ,[FanLong]
                    ,[FinMaterial]
                    ,[FinMaterialParameter]
                    ,[FinThickness]
                    ,[TubeMaterial]
                    ,[TubeMaterialParameter]
                    ,[TubeThickness]
                    ,[MotorModel])
              VALUES
                    ('" + txtModelName.Text + @"'
                    ,'" + txtCoilModel.Text + @"'
                    ," + numCFM.Value + @"
                    ,'C'
                    ,'" + FinTypeParameter() + @"'
                    ,'" + FinShapeParameter() + @"'
                    ," + Convert.ToDecimal(Convert.ToDecimal(cboFinHeight.Text) / FinTypeFaceTube()) + @"
                    ," + numRow.Value + @"
                    ," + Convert.ToInt32(cboFPI.Text) + @"
                    ," + Convert.ToInt32(cboCircuit.Text) + @"
                    ," + cboFinHeight.Text + @"
                    ," + numFinLength.Value + @"
                    ," + numFanWide.Value + @"
                    ," + numFanLong.Value + @"
                    ,'" + cboFinMaterial.Text + @"'
                    ,'" + FinMaterialParameter() + @"'
                    ," + FinThicknessParameter() + @"
                    ,'" + cboTubeMaterial.Text + @"'
                    ,'" + TubeMaterialParameter() + @"'
                    ," + TubeThicknessParameter() + ",'"  + cboMotor.Text + @"') ";
                }
            
                //OLD, WITH PLACEHOLDERS FOR THE MOTOR AND FAN COLUMNS

                /*TSQL += @" INSERT INTO CondensingUnitCoilLink
                    ([Model]
                    ,[CoilModel]
                    ,[CFM]
                    ,[CoilType]
                    ,[FinType]
                    ,[FinShape]
                    ,[Tubes]
                    ,[Row]
                    ,[FPI]
                    ,[Circuit]
                    ,[FinHeight]
                    ,[FinLength]
                    ,[FanWide]
                    ,[FanLong]
                    ,[FinMaterial]
                    ,[FinMaterialParameter]
                    ,[FinThickness]
                    ,[TubeMaterial]
                    ,[TubeMaterialParameter]
                    ,[TubeThickness]
,[MotorModel]
,[MotorMountModel]
,[FanModel]
,[FanGuardModel])
              VALUES
                    ('" + txtModelName.Text + @"'
                    ,'" + txtCoilModel.Text + @"'
                    ," + numCFM.Value.ToString() + @"
                    ,'C'
                    ,'" + FinTypeParameter() + @"'
                    ,'" + FinShapeParameter() + @"'
                    ," + Convert.ToDecimal(Convert.ToDecimal(cboFinHeight.Text) / FinTypeFaceTube()).ToString() + @"
                    ," + numRow.Value.ToString() + @"
                    ," + Convert.ToInt32(cboFPI.Text).ToString() + @"
                    ," + Convert.ToInt32(cboCircuit.Text).ToString() + @"
                    ," + cboFinHeight.Text + @"
                    ," + numFinLength.Value.ToString() + @"
                    ," + numFanWide.Value.ToString() + @"
                    ," + numFanLong.Value.ToString() + @"
                    ,'" + cboFinMaterial.Text + @"'
                    ,'" + FinMaterialParameter() + @"'
                    ," + FinThicknessParameter() + @"
                    ,'" + cboTubeMaterial.Text + @"'
                    ,'" + TubeMaterialParameter() + @"'
                    ," + TubeThicknessParameter() + ",'" + cboMotor.Text +"','','','') ";*/
            

            return tsql;
        }

        private string GetCondensingUnitWaterCooledTSQL()
        {
            string tsql = "";


                tsql += " DELETE FROM CondensingUnitWaterCooledCondenserLink WHERE Model = '" + txtModelName.Text + "' ";

                int numberOfWaterCooled = GetAmountOfWaterCooled();

                for (int i = 0; i < numberOfWaterCooled; i++)
                {
                    tsql += @" INSERT INTO CondensingUnitWaterCooledCondenserLink
           ([Model]
           ,[WaterCooledNumber]
           ,[WaterCooledModel])
     VALUES
           ('" + txtModelName.Text + @"'
           ," + Convert.ToInt32(i + 1) + @"
           ,'" + lvWaterCooledCondenser.Items[i].SubItems[0].Text + @"') ";

                }
            
            return tsql;
        }

        private string GetCondensingUnitCompressorReceiverTSQL()
        {
            string tsql = "";
            
                tsql += " DELETE FROM CondensingUnitCompressorReceiverLink WHERE Model = '" + txtModelName.Text + "' ";

                int numberOfCompressor = GetAmountOfCompressors();

                for (int i = 0; i < numberOfCompressor; i++)
                {
                    tsql += @" INSERT INTO CondensingUnitCompressorReceiverLink
           ([Model]
           ,[CompressorNumber]
           ,[CompressorModel]
           ,[VoltageID]
           ,[RefrigerantID]
           ,[Liquid]
           ,[Suction]
           ,[Discharge]
           ,[LiquidText]
           ,[SuctionText]
           ,[DischargeText]
           ,[ReceiverModel]
           ,[CoilCapacityRatio])
     VALUES
           ('" + txtModelName.Text + @"'
           ," + Convert.ToInt32(i + 1) + @"
           ,'" + lvCompressor.Items[i].SubItems[0].Text + @"'
           ," + lvCompressor.Items[i].SubItems[1].Text + @"
           ," + lvCompressor.Items[i].SubItems[2].Text + @"
           ," + lvCompressor.Items[i].SubItems[3].Text + @"
           ," + lvCompressor.Items[i].SubItems[4].Text + @"
           ," + lvCompressor.Items[i].SubItems[5].Text + @"
           ,'" + new Tools.Fraction(Convert.ToDecimal(lvCompressor.Items[i].SubItems[3].Text)).Text + @"'
           ,'" + new Tools.Fraction(Convert.ToDecimal(lvCompressor.Items[i].SubItems[4].Text)).Text + @"'
           ,'" + new Tools.Fraction(Convert.ToDecimal(lvCompressor.Items[i].SubItems[5].Text)).Text + @"'
           ,'" + lvCompressor.Items[i].SubItems[6].Text + @"'
           ," + lvCompressor.Items[i].SubItems[7].Text + @") ";
                }
            
            return tsql;
        }

        private string GetCondensingUnitModelTSQL()
        {
            string tsql = "";
           
            
            tsql += " DELETE FROM CondensingUnitModel WHERE Model = '" + txtModelName.Text + "' ";

            tsql += @" INSERT INTO CondensingUnitModel
                    ([Model]
                    ,[UnitType]
                    ,[AirFlow]
                    ,[CompressorType]
                    ,[CompressorManufacturer]
                    ,[Application]
                    ,[RefrigerantID]
                    ,[VoltageID]
                    ,[HP]
                    ,[Options]
                    ,[Price]
                    ,[Weight]
                    ,[NumberOfCompressor]
                    ,[MinBalancing]
                    ,[MaxBalancing]
                    ,[MinSST]
                    ,[MaxSST]
                    ,[CommercializedFactor])
                    VALUES
                    ('" + txtModelName.Text + @"'
                    ,'" + Type().Substring(0, 1) + @"'
                    ,'" + Type().Substring(1, 1) + @"'
                    ,'" + CompressorType() + @"'
                    ," + CompressorManufacturer() + @"
                    ,'" + ComboBoxControl.IndexInformation(cboApplication) + @"'
                    ," + Refrigerant() + @"
                    ," + Voltage() + @"
                    ," + numHP.Value + @"
                    ,'" + GetOptions() +@"'
                    ," + numPrice.Value + @"
                    ," + numWeight.Value + @"
                    ," + GetAmountOfCompressors() + @"
                    ," + Convert.ToInt32(numBalancingMin.Value) + @"
                    ," + Convert.ToInt32(numBalancingMax.Value) + @"
                    ," + Convert.ToInt32(numSSTMin.Value) + @"
                    ," + Convert.ToInt32(numSSTMax.Value) + @"
                    ," + numCommercializedFactor.Value + @") ";
            
            return tsql;
        }

        private void cmdLoadCondensingUnit_Click(object sender, EventArgs e)
        {
            LoadUnit();
        }

        private void LoadUnit()
        {
            string strModeltoLoad = cboCondensingUnitModel.Text;

            if (strModeltoLoad != "")
            {

                DataTable dtCondensingUnitModel = Query.Select("SELECT * FROM CondensingUnitModel WHERE Model = '" + strModeltoLoad + "'");
                DataTable dtCondensingUniCompressorReceiverLink = Query.Select("SELECT * FROM CondensingUnitCompressorReceiverLink WHERE Model = '" + strModeltoLoad + "' ORDER BY CompressorNumber ASC");
                DataTable dtCondensingUnitWaterCooledCondenserLink = Query.Select("SELECT * FROM CondensingUnitWaterCooledCondenserLink WHERE Model = '" + strModeltoLoad + "'  ORDER BY WaterCooledNumber ASC");
                DataTable dtCondensingUnitCoilLink = Query.Select("SELECT * FROM CondensingUnitCoilLink WHERE Model = '" + strModeltoLoad + "'");
                DataTable dtCondensingUnitBalancing = Query.Select("SELECT * FROM CondensingUnitBalancing WHERE Model = '" + strModeltoLoad + "'");

                txtModelName.Text = strModeltoLoad;

                if (ValidateModel())
                {
                    SetTabsEnabledProperty(true);
                    cmdValidateModel.Visible = false;
                    cmdChangeModel.Visible = true;
                    txtModelName.Enabled = false;
                    numHP.Enabled = true;
                    numPrice.Enabled = true;
                    numWeight.Enabled = true;

                    for (int i = 0; i < lvOptions.Items.Count; i++)
                    {
                        lvOptions.Items[i].SubItems[0].Checked = false;
                    }

                    //model main info
                    if (dtCondensingUnitModel.Rows.Count > 0)
                    {
                        numHP.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["HP"]);

                        SelectOptions(dtCondensingUnitModel.Rows[0]["Options"].ToString());

                        numPrice.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["Price"]);
                        numWeight.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["Weight"]);

                        numBalancingMin.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["MinBalancing"]);
                        numBalancingMax.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["MaxBalancing"]);
                        numSSTMin.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["MinSST"]);
                        numSSTMax.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["MaxSST"]);
                        numCommercializedFactor.Value = Convert.ToDecimal(dtCondensingUnitModel.Rows[0]["CommercializedFactor"]);

                        FormatBalancingTable();
                    }

                    //compressor & receiver
                    lvCompressor.Items.Clear();
                    foreach (DataRow dr in dtCondensingUniCompressorReceiverLink.Rows)
                    {
                        AddToCompressor(dr["CompressorModel"].ToString(), dr["VoltageID"].ToString(), dr["RefrigerantID"].ToString(), Convert.ToDecimal(dr["Liquid"]), Convert.ToDecimal(dr["Suction"]), Convert.ToDecimal(dr["Discharge"]), dr["ReceiverModel"].ToString(), Convert.ToDecimal(dr["CoilCapacityRatio"]));
                    }
                    lvCompressor.Refresh();

                    //water cooled condenser
                    lvWaterCooledCondenser.Items.Clear();
                    foreach (DataRow dr in dtCondensingUnitWaterCooledCondenserLink.Rows)
                    {
                        AddToWaterCooled(dr["WaterCooledModel"].ToString());
                    }
                    lvWaterCooledCondenser.Refresh();

                    //condenser coil
                    ClearCoilModel();
                    if (dtCondensingUnitCoilLink.Rows.Count > 0)
                    {
                        numCFM.Value = Convert.ToDecimal(dtCondensingUnitCoilLink.Rows[0]["CFM"]);

                        DataTable dtFinType = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinType"], "FinType = '" + dtCondensingUnitCoilLink.Rows[0]["FinType"] + "'", "");
                        if (dtFinType.Rows.Count > 0)
                        {
                            ComboBoxControl.SetIDDefaultValue(cboFinType, dtFinType.Rows[0]["UniqueID"].ToString());
                        }
                        dtFinType.Dispose();

                        DataTable dtFinShape = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinShape"], "FinShapeParameter = '" + dtCondensingUnitCoilLink.Rows[0]["FinShape"] + "'", "");
                        if (dtFinShape.Rows.Count > 0)
                        {
                            ComboBoxControl.SetIDDefaultValue(cboFinShape, dtFinShape.Rows[0]["UniqueID"].ToString());
                        }
                        dtFinShape.Dispose();

                        cboFinHeight.SelectedIndex = cboFinHeight.FindString(dtCondensingUnitCoilLink.Rows[0]["FinHeight"].ToString());
                        numFinLength.Value = Convert.ToDecimal(dtCondensingUnitCoilLink.Rows[0]["FinLength"]);
                        numRow.Value = Convert.ToDecimal(dtCondensingUnitCoilLink.Rows[0]["Row"]);
                        cboFPI.Text = dtCondensingUnitCoilLink.Rows[0]["FPI"].ToString();
                        cboCircuit.Text = dtCondensingUnitCoilLink.Rows[0]["Circuit"].ToString();

                        cboMotor.SelectedIndex = cboMotor.FindString(dtCondensingUnitCoilLink.Rows[0]["MotorModel"].ToString());
                        cboFinMaterial.SelectedIndex = cboFinMaterial.FindString(dtCondensingUnitCoilLink.Rows[0]["FinMaterial"].ToString());
                        cboFinThickness.SelectedIndex = cboFinThickness.FindString(dtCondensingUnitCoilLink.Rows[0]["FinThickness"].ToString());
                        cboTubeMaterial.SelectedIndex = cboTubeMaterial.FindString(dtCondensingUnitCoilLink.Rows[0]["TubeMaterial"].ToString());
                        cboTubeThickness.SelectedIndex = cboTubeThickness.FindString(dtCondensingUnitCoilLink.Rows[0]["TubeThickness"].ToString());

                        GenerateCoilModel();

                        numFanWide.Value = Convert.ToDecimal(dtCondensingUnitCoilLink.Rows[0]["FanWide"]);
                        numFanLong.Value = Convert.ToDecimal(dtCondensingUnitCoilLink.Rows[0]["FanLong"]);
                    }

                    //balancing
                    foreach (DataRow drBalancing in dtCondensingUnitBalancing.Rows)
                    {
                        lvBalancing.Items[GetRowIndex(Convert.ToDecimal(drBalancing["Balancing"]))].SubItems[GetColumnIndex(Convert.ToDecimal(drBalancing["SST"]))].Text = drBalancing["Capacity"].ToString();
                    }
                }
            }
        }

        private int GetRowIndex(decimal balancing)
        {

            for (int i = 0; i < lvBalancing.Items.Count; i++)
            {
                if (Convert.ToInt32(lvBalancing.Items[i].SubItems[0].Text) == Convert.ToInt32(balancing))
                {
                    return  i;
                }
            }

            return lvBalancing.Items.Count;
        }

        private int GetColumnIndex(decimal sst)
        {
            int colIndex = -1;

            //first column is textual so we bypass it
            for (int i = 1; i < lvBalancing.Columns.Count; i++)
            {
                if (Convert.ToInt32(lvBalancing.Columns[i].Text) == Convert.ToInt32(sst))
                {
                    colIndex = i;
                    i = lvBalancing.Columns.Count;
                }
            }

            return colIndex;
        }

        private void numCFM_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedUnit();
        }

        private void DeleteSelectedUnit()
        {
            string strModelToDelete = cboCondensingUnitModel.Text;

            if (strModelToDelete != "")
            {
                if (Public.LanguageQuestionBox("Are you sure you want to suppress this unit", "Êtes-vous sûr de vouloir supprimer cette unité?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string tsql = "";

                    tsql += " DELETE FROM CondensingUnitModel WHERE Model = '" + strModelToDelete + "' ";
                    tsql += " DELETE FROM CondensingUnitCompressorReceiverLink WHERE Model = '" + strModelToDelete + "' ";
                    tsql += " DELETE FROM CondensingUnitWaterCooledCondenserLink WHERE Model = '" + strModelToDelete + "' ";
                    tsql += " DELETE FROM CondensingUnitCoilLink WHERE Model = '" + strModelToDelete + "' ";
                    tsql += " DELETE FROM CondensingUnitBalancing WHERE Model = '" + strModelToDelete + "' ";

                    Query.Execute(tsql);

                    Query.UpdateServerTableVersion("CondensingUnitModel");
                    Query.UpdateServerTableVersion("CondensingUnitCompressorReceiverLink");
                    Query.UpdateServerTableVersion("CondensingUnitWaterCooledCondenserLink");
                    Query.UpdateServerTableVersion("CondensingUnitCoilLink");
                    for (int i = -100; i <= 55; i++)
                    {
                        Query.UpdateServerTableVersion("v_CondensingUnitBalancing_" + i);
                    }

                    RefreshCondensingUnitList();

                    Public.LanguageBox("Delete Sucessful.", "Supprimé avec succès.");
                }
            }
        }

        private void LoadOldModel()
        {
            if (cboOldReplusQuoteModel.SelectedIndex > 0)
            {
                lvCompressor.Items.Clear();
                lvCompressor.Refresh();
                lvWaterCooledCondenser.Items.Clear();
                lvWaterCooledCondenser.Refresh();
                ClearCoilModel();

                string strModelWithVoltage = cboOldReplusQuoteModel.Text;
                string strModel = strModelWithVoltage.Substring(0, strModelWithVoltage.Length - 2);
                string voltageID = strModelWithVoltage.Substring(strModelWithVoltage.Length - 1);

                SetTabsEnabledProperty(false);
                cmdValidateModel.Visible = true;
                cmdChangeModel.Visible = false;
                txtModelName.Enabled = true;
                numHP.Enabled = false;
                numPrice.Enabled = false;
                numWeight.Enabled = false;

                for (int i = 0; i < lvOptions.Items.Count; i++)
                {
                    lvOptions.Items[i].SubItems[0].Checked = false;
                }

                DataTable dtrelCuVoltage = Public.SelectAndSortTable(_rquotes.GetTable("rel_CUVoltage"), "CUModelID = '" + strModel + "' AND VoltageID = " + voltageID, "");

                if (dtrelCuVoltage.Rows.Count > 0)
                {
                    txtModelName.Text = strModelWithVoltage;

                    if (ValidateModel())
                    {
                        //set and reset stuff
                        SetTabsEnabledProperty(true);
                        cmdValidateModel.Visible = false;
                        cmdChangeModel.Visible = true;
                        txtModelName.Enabled = false;
                        numHP.Enabled = true;
                        numHP.Value = 0m;
                        numPrice.Enabled = true;
                        numPrice.Value = 0m;
                        numWeight.Enabled = true;
                        numWeight.Value = 0m;
                        numCFM.Value = 0m;
                        cboFinType.SelectedIndex = 0;
                        cboFinShape.SelectedIndex = 0;
                        cboFinHeight.SelectedIndex = 0;
                        numFinLength.Value = 1m;
                        numRow.Value = 1m;
                        cboFPI.SelectedIndex = 0;
                        cboFinMaterial.SelectedIndex = 0;
                        cboTubeMaterial.SelectedIndex = 0;
                        numFanWide.Value = 1m;
                        cboMotor.SelectedIndex = 0;
                        numFanLong.Value = 1m;

                        //start filling the values we have
                        numPrice.Value = Convert.ToDecimal(dtrelCuVoltage.Rows[0]["CUPrice"]);

                        DataTable dtFCondensingUnit = Public.SelectAndSortTable(_rquotes.GetTable("FCondensingUnit"), "CondensingUnitID = '" + strModel + "'", "");

                        if (dtFCondensingUnit.Rows.Count > 0)
                        {
                            numWeight.Value = Convert.ToDecimal(dtFCondensingUnit.Rows[0]["ShipWeight"]);
                        }

                        dtFCondensingUnit.Dispose();

                        if (pnlCoil.Enabled)
                        {
                            DataTable dtCUCoilCFM = Public.SelectAndSortTable(_rquotes.GetTable("CUCoilCFM"), "CondensingUnit = '" + strModel + "' AND VoltageID = " + voltageID, "");

                            if (dtCUCoilCFM.Rows.Count > 0)
                            {
                                numCFM.Value = Convert.ToDecimal(dtCUCoilCFM.Rows[0]["CoilCFM"]);
                            }

                            dtCUCoilCFM.Dispose();

                            DataTable dtrelCoil = Public.SelectAndSortTable(_rquotes.GetTable("rel_Coil"), "EvaporatorID = '" + strModel + "'", "");

                            if (dtrelCoil.Rows.Count > 0)
                            {
                                string strCoilModel = dtrelCoil.Rows[0]["CoilID"].ToString();

                                string[] splitCoil = strCoilModel.Split('-');

                                if (splitCoil.Length == 5)
                                {
                                    string strFinType = splitCoil[0].Substring(1, 1);

                                    if (cboFinType.FindString(strFinType + " - ")>= 0)
                                    {
                                        cboFinType.SelectedIndex = cboFinType.FindString(strFinType + " - ");

                                        string strFinShape = splitCoil[0].Substring(2, 1);

                                        if (cboFinShape.FindString(strFinShape + " - ")>= 0)
                                        {
                                            cboFinShape.SelectedIndex = cboFinShape.FindString(strFinShape + " - ");

                                            if (cboFinHeight.FindString(Convert.ToDecimal(FinTypeFaceTube() * Convert.ToDecimal(splitCoil[1])).ToString(CultureInfo.InvariantCulture)) >= 0)
                                            {
                                                cboFinHeight.SelectedIndex = cboFinHeight.FindString(Convert.ToDecimal(FinTypeFaceTube() * Convert.ToDecimal(splitCoil[1])).ToString(CultureInfo.InvariantCulture));

                                                numFinLength.Value = Convert.ToDecimal(splitCoil[4]);
                                                numRow.Value = Convert.ToDecimal(splitCoil[2]);
                                                cboFPI.Text = Convert.ToDecimal(splitCoil[3]).ToString(CultureInfo.InvariantCulture);

                                            }
                                        }
                                    }
                                }
                            }

                            dtrelCoil.Dispose();
                        }


                        //motor, mount, fan and guard

                        DataTable dtrelMotor = Public.SelectAndSortTable(_rquotes.GetTable("rel_Motor"), "EvaporatorSerieID = '" + strModel + "' AND VoltageID = " + voltageID, "");

                        if (dtrelMotor.Rows.Count > 0)
                        {
                            if (cboMotor.FindString(dtrelMotor.Rows[0]["MotorID"].ToString()) > 0)
                            {
                                cboMotor.SelectedIndex = cboMotor.FindString(dtrelMotor.Rows[0]["MotorID"].ToString());
                            }
                        }

                        dtrelMotor.Dispose();

                        //capacity
                        DataTable dtCUCapacity = Public.SelectAndSortTable(_rquotes.GetTable("CUCapacity"), "CUModelID = '" + strModel + "'", "");

                        if (dtCUCapacity.Rows.Count > 0)
                        {
                            numBalancingMin.Value = Convert.ToDecimal(Public.SortTable(dtCUCapacity, "AmbientTemp ASC").Rows[0]["AmbientTemp"]);
                            numBalancingMax.Value = Convert.ToDecimal(Public.SortTable(dtCUCapacity, "AmbientTemp DESC").Rows[0]["AmbientTemp"]);
                            numSSTMin.Value = Convert.ToDecimal(Public.SortTable(dtCUCapacity, "SST ASC").Rows[0]["SST"]);
                            numSSTMax.Value = Convert.ToDecimal(Public.SortTable(dtCUCapacity, "SST DESC").Rows[0]["SST"]);
                            numCommercializedFactor.Value = 0m;
                            FormatBalancingTable();

                            foreach (DataRow drCUCapacity in dtCUCapacity.Rows)
                            {
                                lvBalancing.Items[GetRowIndex(Convert.ToDecimal(drCUCapacity["AmbientTemp"]))].SubItems[GetColumnIndex(Convert.ToDecimal(drCUCapacity["SST"]))].Text = drCUCapacity["CUCapacity"].ToString();
                            }
                        }

                        dtCUCapacity.Dispose();
                    }
                }

                dtrelCuVoltage.Dispose();
            }
        }

        private void cmdLoadOldModel_Click(object sender, EventArgs e)
        {
            LoadOldModel();
        }

        private void cmdAutoBalance_Click(object sender, EventArgs e)
        {
            AutoBalance();
        }

        private void AutoBalance()
        {
            try
            {
                if (lvBalancing.Items.Count > 0)
                {
                    if (lvCompressor.Items.Count > 0)
                    {
                        ThreadProcess.Start("Balancing Data");

                        if (TypeCoilPresent())
                        {
                            //if there is a coil we balance the coil with compressor
                            Fill_BalancindData(
                                Balancing.CompressorCondenserCoil.GetBalancingData(
                                    numBalancingMin.Value,
                                    numBalancingMax.Value,
                                    numSSTMin.Value,
                                    numSSTMax.Value,
                                    GetCompressors(),
                                    FinTypeParameter() + FinShapeParameter(),
                                    Convert.ToDecimal(cboFinHeight.Text),
                                    numFinLength.Value,
                                    numCFM.Value,
                                    cboRefrigerant.Text,
                                    Convert.ToDecimal(cboFPI.Text),
                                    Convert.ToInt32(cboCircuit.Text),
                                    numRow.Value,
                                    FinMaterialParameter(),
                                    Convert.ToDecimal(FinThicknessParameter()),
                                    TubeMaterialParameter(),
                                    Convert.ToDecimal(TubeThicknessParameter()),
                                    TubeTypeParameter()));
                        }
                        else
                        {
                            //no balancing needed we simply run performance of the compressor
                            Fill_BalancindData(
                                Balancing.CompressorBalancing.GetBalancingData(
                                    numBalancingMin.Value,
                                    numBalancingMax.Value,
                                    numSSTMin.Value,
                                    numSSTMax.Value,
                                    GetCompressors()));
                        }
                        ThreadProcess.Stop();
                        Focus();
                    }
                    else
                    {
                        Public.LanguageBox("This unit does not have any compressor(s) configured", "Cette unité n'a aucun compresseur de configuré");
                    }
                }
                else
                {
                    Public.LanguageBox("The table is not set for balancing. It cannot receive data yet.", "Le tableau n'est pas près à recevoir des données. Vérifiez que le format est bien affiché.");
                }
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmCondensingUnitModel AutoBalance");
                MessageBox.Show(ex.ToString());
                Public.LanguageBox("An error occured while trying to balance.", "Une erreur est survenue lors du balancement.");
            }
        }

        private void Fill_BalancindData(IEnumerable<BalancingData> bd)
        {
            bool coilPresent = TypeCoilPresent();

            foreach (BalancingData data in bd)
            {
                if (coilPresent)
                {
                    lvBalancing.Items[GetRowIndex(data.AMBIENT)].SubItems[GetColumnIndex(data.SST)].Text = Math.Round(Convert.ToDecimal(data.CAPACITY / 1000m), Convert.ToInt32(numDecimalPrecision.Value)).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    lvBalancing.Items[GetRowIndex(data.CONDENSING)].SubItems[GetColumnIndex(data.SST)].Text = Math.Round(Convert.ToDecimal(data.CAPACITY / 1000m), Convert.ToInt32(numDecimalPrecision.Value)).ToString(CultureInfo.InvariantCulture);
                }
            }

            lvBalancing.Refresh();
        }

        private List<Compressor> GetCompressors()
        {
            var listOfCompressors = new List<Compressor>();

            for (int i = 0; i < lvCompressor.Items.Count; i++)
            {
                DataTable dtCompressorData = Public.SelectAndSortTable(_dtCompressorList, "Compressor = '" + lvCompressor.Items[i].SubItems[0].Text + "' AND RefrigerantID = " + lvCompressor.Items[i].SubItems[2].Text + " AND VoltageID = " + lvCompressor.Items[i].SubItems[1].Text, "");

                listOfCompressors.Add(new Compressor(
                    lvCompressor.Items[i].SubItems[0].Text,
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity1"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity2"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity3"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity4"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity5"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity6"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity7"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity8"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity9"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity10"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power1"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power2"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power3"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power4"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power5"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power6"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power7"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power8"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power9"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power10"]),
                    0m,
                    ""));
            }

            return listOfCompressors;
        }

        private void cboCircuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCoilModel();
        }

        private void cmdGotToBalancingModule_Click(object sender, EventArgs e)
        {
            if (lvCompressor.Items.Count > 0)
            {
                if (TypeCoilPresent())
                {
                    ThreadProcess.Start("Transfering Data to balancing module");

                    var frmBalance = new Balancing.FrmCompressorCondenserCoilBalancing(
                            numBalancingMin.Value,
                            numBalancingMax.Value,
                            numSSTMin.Value,
                            numSSTMax.Value,
                            FinTypeParameter() + FinShapeParameter(),
                            Convert.ToDecimal(cboFinHeight.Text),
                            numFinLength.Value,
                            numCFM.Value,
                            cboRefrigerant.Text,
                            Convert.ToDecimal(cboFPI.Text),
                             numRow.Value,
                             FinMaterialParameter(),
                            Convert.ToDecimal(FinThicknessParameter()),
                            TubeMaterialParameter(),
                            Convert.ToDecimal(TubeThicknessParameter()),
                            TubeTypeParameter(),
                            Convert.ToInt32(cboCircuit.Text),
                             GetCompressors()
                            );

                    frmBalance.ShowDialog();
                }
                else
                {
                    Public.LanguageBox("This option is only available for units with coil.", "Cette option n'est disponible qu'avec une unité ayant un serpentin.");
                }
            }
            else
            {
                Public.LanguageBox("This unit does not have any compressor(s) configured", "Cette unité n'a aucun compresseur de configuré");
            }
        }

        private void ScrollHorizontal_Scroll(object sender, ScrollEventArgs e)
        {
            grpInside.Left = ScrollHorizontal.Value * -1;
        }

        private void frmCondensingUnitModel_Resize(object sender, EventArgs e)
        {
            if (grpOutside.Width > grpInside.Width)
            {
                ScrollHorizontal.Visible = false;
                ScrollHorizontal.Value = 0;
            }
            else
            {
                ScrollHorizontal.Visible = true;
                ScrollHorizontal.Value = 0;
            }
        }

        private void cboCompressorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_CompressorList();
        }

        private void cboCompressorManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_CompressorList();
        }

        private void FillCommercializedList()
        {
            lvCommercialValues.Items.Clear();
            lvCommercialValues.Columns.Clear();
            lvCommercialValues.Refresh();

            foreach(GLColumn colBalancing in lvBalancing.Columns)
            {
                var colCommercialized = new GLColumn
                {
                    Text = colBalancing.Text,
                    Width = colBalancing.Width
                };

                lvCommercialValues.Columns.Add(colCommercialized);
            }

            foreach (GLItem iBalancing in lvBalancing.Items)
            {
                var iCommercialized = new GLItem(lvCommercialValues)
                {
                    ForeColor = _cCommercialized
                };

                iCommercialized.SubItems[0].Text = iBalancing.SubItems[0].Text;

                for (int iCol = 1; iCol < lvCommercialValues.Columns.Count; iCol++)
                {
                    try
                    {
                        iCommercialized.SubItems[iCol].Text = Convert.ToDecimal(Convert.ToDecimal(iBalancing.SubItems[iCol].Text) * ((100m + numCommercializedFactor.Value) / 100m)).ToString(CultureInfo.InvariantCulture);
                    }
                    catch(Exception ex)
                    {
                        Public.PushLog(ex.ToString(), "FrmCondensingUnitModel FillCommercializedList");
                        iCommercialized.SubItems[iCol].Text = "Invalid";
                    }
                }

                lvCommercialValues.Items.Add(iCommercialized);
            }

            lvCommercialValues.Refresh();
        }

        private void ShowProperCapacityList()
        {
            lvBalancing.Visible = false;
            lvCommercialValues.Visible = false;

            if (radCapacity.Checked)
            {
                lvBalancing.Visible = true;
            }

            if (radCommercializedCapacity.Checked)
            {
                lvCommercialValues.Visible = true;
            }
        }

        private void radCapacity_CheckedChanged(object sender, EventArgs e)
        {
            ShowProperCapacityList();
        }

        private void radCommercializedCapacity_CheckedChanged(object sender, EventArgs e)
        {
            ShowProperCapacityList();

            FillCommercializedList();
        }

        private void numCommercializedFactor_ValueChanged(object sender, EventArgs e)
        {
            FillCommercializedList();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmCondensingUnitModel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        

     
    }
}