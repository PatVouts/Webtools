using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCondensingUnit
{
    public partial class FrmQuickCondensingUnit : Form
    {
        //form need access to his background code
        private readonly CondensingUnitCode _backgroundCode = new CondensingUnitCode();

        private readonly string[] _strTableList = { "CondensingUnitCompressorManufacturer", "CondensingUnitCompressorType", "CondensingUnitModel", "CondensingUnitRefrigerant", "CondensingUnitType", "Voltage", "CondensingUnitCompressorAmount", "CondensingUnitCapacityFactor", "CondensingUnitCoilLink", "ElectroFinAdjustement", "HeresiteSafety", "MotorModel", "MotorModelFLA", "MotorMountModel", "FanModel", "FanGuardModel", "CoilFinMaterial", "CoilCasingMaterial", "CoilTubeMaterial", "v_CoilFinDefaults", "FuseSize", "CondensingUnitReceiver", "CondensingUnitWaterCooledCondenser", "CondensingUnitWaterCooledCondenserLink", "CondensingUnitCompressorReceiverLink", "CompressorData", "CondensingUnitApplication", "Drawings", "CondensingUnitDrawingManager" };

        //selection table
        private DataTable _dtLastSelection;

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        //used to store data before saving to the quote.
        private DataTable _dtCondensingUnitInputs;
        private DataTable _dtCompressorInputs;
        private DataTable _dtWaterCooledInputs;
        private DataTable _dtOptions = Tables.DtCondensingUnitOptions();


        public FrmQuickCondensingUnit()
        {
            InitializeComponent();
        }

        public FrmQuickCondensingUnit(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void frmQuickCondensingUnit_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            //this call all the fill combobox function needed
            Fill_Combobox();

            //this function sets all the defaults at loading
            SetDefaults();

            if (_bolQuoteSelection && _intIndex != -1)
            {
                ThreadProcess.UpdateMessage(Public.LanguageString("Loading saved data", "Chargement des données"));
                LoadSavedData();
            }

            ThreadProcess.Stop();
            Focus();
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void LoadSavedData()
        {
            //will contain all errors
            string strErrors = "";

            DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnit"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CondensingUnit) + " AND ItemID = " + _intIndex, "");
            DataRow drSavedInfo = dtSavedInfo.NewRow();
            drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;

            txtTag.Text = drSavedInfo["Input_Tag"].ToString();

            numQuantity.Value = Convert.ToDecimal(drSavedInfo["Quantity"]);

            if (cboFilter.FindString(drSavedInfo["Input_Filter"].ToString()) >= 0)
            {
                cboFilter.SelectedIndex = cboFilter.FindString(drSavedInfo["Input_Filter"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected filter", "- Incapable de trouver le type de filtre utilisé") + Environment.NewLine;
            }

            if (drSavedInfo["Input_Filter"].ToString() == "Rating")
            {
                if (cboModel.FindString(drSavedInfo["Input_Model"].ToString()) >= 0)
                {
                    cboModel.SelectedIndex = cboModel.FindString(drSavedInfo["Input_Model"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find selected model", "- Incapable de trouver le modèle utilisé") + Environment.NewLine;
                }
            }

            if (cboType.FindString(drSavedInfo["Input_Type"].ToString()) >= 0)
            {
                cboType.SelectedIndex = cboType.FindString(drSavedInfo["Input_Type"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected type", "- Incapable de trouver le type utilisé") + Environment.NewLine;
            }

            if (cboCompressorType.FindString(drSavedInfo["Input_CompressorType"].ToString()) >= 0)
            {
                cboCompressorType.SelectedIndex = cboCompressorType.FindString(drSavedInfo["Input_CompressorType"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected compressor type", "- Incapable de trouver le type de compresseur utilisé") + Environment.NewLine;
            }

            if (cboCompressorManufacturer.FindString(drSavedInfo["Input_CompressorManufacturer"].ToString()) >= 0)
            {
                cboCompressorManufacturer.SelectedIndex = cboCompressorManufacturer.FindString(drSavedInfo["Input_CompressorManufacturer"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected compressor manufacturer", "- Incapable de trouver le manufacturier du compresseur utilisé") + Environment.NewLine;
            }

            if (cboRefrigerant.FindString(drSavedInfo["Input_Refrigerant"].ToString()) >= 0)
            {
                cboRefrigerant.SelectedIndex = cboRefrigerant.FindString(drSavedInfo["Input_Refrigerant"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected refrigerant", "- Incapable de trouver le réfrigérant utilisé") + Environment.NewLine;
            }

            if (cboNumberOfCompressors.FindString(drSavedInfo["Input_NumberOfCompressor"].ToString()) >= 0)
            {
                cboNumberOfCompressors.SelectedIndex = cboNumberOfCompressors.FindString(drSavedInfo["Input_NumberOfCompressor"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected number of compressor", "- Incapable de trouver le nombre de compresseurs utilisé") + Environment.NewLine;
            }

            numCapacity.Value = Convert.ToDecimal(drSavedInfo["Input_Capacity"]);


            if (cboCapacityRange.FindString(drSavedInfo["Input_CapacityRange"].ToString()) >= 0)
            {
                cboCapacityRange.SelectedIndex = cboCapacityRange.FindString(drSavedInfo["Input_CapacityRange"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected capacity range", "- Incapable de trouver la plage de capacité utilisée") + Environment.NewLine;
            }

            txtSaturatedSuctionTemp.Text = drSavedInfo["Input_SST"].ToString();
            txtBalancingTemperature.Text = drSavedInfo["Input_Balancing"].ToString();

            //numSaturatedSuctionTemp.Text = drSavedInfo["Input_SST"].ToString();
            //numSaturatedSuctionTemp.Value = Convert.ToDecimal(drSavedInfo["Input_SST"]);

            //numBalancingTemperature.Text = drSavedInfo["Input_Balancing"].ToString();
            //numBalancingTemperature.Value = Convert.ToDecimal(drSavedInfo["Input_Balancing"]);

            if (cboVoltage.FindString(drSavedInfo["Input_Voltage"].ToString()) >= 0)
            {
                cboVoltage.SelectedIndex = cboVoltage.FindString(drSavedInfo["Input_Voltage"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected voltage", "- Incapable de trouver le voltage utilisé") + Environment.NewLine;
            }

            RunSelection();



            int rowToHighlight = -1;

            for (int i = 0; i < lvCondensingUnit.Items.Count; i++)
            {
                if (lvCondensingUnit.Items[i].SubItems[1].Text == drSavedInfo["Model"].ToString())
                {
                    rowToHighlight = i;
                }
            }

            if (rowToHighlight != -1)
            {
                lvCondensingUnit.Items[rowToHighlight].Selected = true;
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected condensing unit model", "- Incapable de trouver le groupe compresseur-condenseur utilisé") + Environment.NewLine;
            }

            Fill_CoatingAndMaterial();

            if (cboCoilCoating.FindString(drSavedInfo["Input_CoilCoating"].ToString()) >= 0)
            {
                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(drSavedInfo["Input_CoilCoating"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected coil coating", "- Incapable de trouver le revêtement du serpentin utilisé") + Environment.NewLine;
            }

            if (cboFinMaterial.FindString(drSavedInfo["Input_FinMaterial"].ToString()) >= 0)
            {
                cboFinMaterial.SelectedIndex = cboFinMaterial.FindString(drSavedInfo["Input_FinMaterial"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected fin material", "- Incapable de trouver le matériau des ailettes utilisé") + Environment.NewLine;
            }

            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivantes sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Fill_Combobox()
        {
            Fill_Type();

            Fill_CompressorType();

            Fill_CompressorManufacturer();

            Fill_NumberOfCompressor();

            Fill_CapacityRange();

            Fill_Refrigerant();

            Fill_Voltage();

            FillModel();

        }

        private void SetDefaults()
        {
            //INDOOR AIR-COOLED
            cboType.SelectedIndex = 0;

            //ALL
            cboCompressorType.SelectedIndex = 0;

            //ALL
            cboCompressorManufacturer.SelectedIndex = 0;

            //ALL
            cboNumberOfCompressors.SelectedIndex = 0;

            //2011-04-08 : Was 5% before but simon said to change to 25% because no one change it.
            // +/- 25%
            cboCapacityRange.SelectedIndex = 4;

            //R-22
            ComboBoxControl.SetDefaultValue(cboRefrigerant, "ALL");

            //208-240/3/60
            ComboBoxControl.SetDefaultValue(cboVoltage, "208-240/3/60");

            //selection
            cboFilter.SelectedIndex = 0;

            if (cboModel.Items.Count > 0)
            {
                //select first model of the list
                cboModel.SelectedIndex = 0;
            }

            //if it's not from the quote form (not for pricing) we do not show the price column
            if (!_bolQuoteSelection)
            {
                lvCondensingUnit.Columns[4].Width = 0;
            }
        }

        private string RatingModelName()
        {
            return (cboModel.Enabled ? ComboBoxControl.IndexInformation(cboModel) : "");
        }

        private string CapacityRangeFactor()
        {
            return ComboBoxControl.IndexInformation(cboCapacityRange);
        }

        private void Fill_CapacityRange()
        {
            cboCapacityRange.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all compressor type
            foreach (DataRow drCapacity in Public.DSDatabase.Tables["CondensingUnitCapacityFactor"].Rows)
            {
                string strIndex = drCapacity["Factor"].ToString();
                string strText = drCapacity["Description"].ToString();
                ComboBoxControl.AddItem(cboCapacityRange, strIndex, strText);
            }
        }

        private void FillModel()
        {
            cboModel.Items.Clear();

            //list of models
            DataTable dtModelOrdered = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitModel"], "", "Model ASC");

            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all model
            foreach (DataRow drModel in dtModelOrdered.Rows)
            {
                string strIndex = drModel["Model"].ToString();
                string strText = drModel["Model"].ToString();
                ComboBoxControl.AddItem(cboModel, strIndex, strText);
            }

            if (cboModel.Items.Count == 0)
            {
                cboFilter.Enabled = false;
            }
        }

        //return balancing type
        private string BalancingType()
        {
            return ComboBoxControl.ItemInformations(cboType, Public.DSDatabase.Tables["CondensingUnitType"], "UniqueID")[0]["Balancing"].ToString();
        }


        //return type
        private string Type()
        {
            return ComboBoxControl.ItemInformations(cboType, Public.DSDatabase.Tables["CondensingUnitType"], "UniqueID")[0]["TypeParameter"].ToString();
        }

        //fill type
        private void Fill_Type()
        {
            cboType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtCondensingUnitType = Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CondensingUnitType"]);

            //loop through all type
            foreach (DataRow drType in dtCondensingUnitType.Rows)
            {
                string strIndex = drType["UniqueID"].ToString();
                string strText = drType["TypeParameter"] + " - " + drType["Type"];
                ComboBoxControl.AddItem(cboType, strIndex, strText);
            }
        }
        //return number of compressors
        private string NumberOfCompressor()
        {
            if (cboNumberOfCompressors.Text == @"ALL")
            {
                return "ALL";
            }
            return ComboBoxControl.IndexInformation(cboNumberOfCompressors);
        }

        private void Fill_NumberOfCompressor()
        {
            cboNumberOfCompressors.Items.Clear();

            ComboBoxControl.AddItem(cboNumberOfCompressors, "ALL", "ALL");

            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all compressor type
            foreach (DataRow drNumberOfCompressor in Public.DSDatabase.Tables["CondensingUnitCompressorAmount"].Rows)
            {
                string strIndex = drNumberOfCompressor["Number"].ToString();
                string strText = drNumberOfCompressor["Description"].ToString();
                ComboBoxControl.AddItem(cboNumberOfCompressors, strIndex, strText);
            }
        }

        //return compressor type
        private string CompressorType()
        {
            if (cboCompressorType.Text == @"ALL")
            {
                return "ALL";
            }
            return ComboBoxControl.ItemInformations(cboCompressorType, Public.DSDatabase.Tables["CondensingUnitCompressorType"], "UniqueID")[0]["CompressorTypeParameter"].ToString();
        }

        //fill compressor type
        private void Fill_CompressorType()
        {
            cboCompressorType.Items.Clear();

            ComboBoxControl.AddItem(cboCompressorType, "ALL", "ALL");

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
            if (cboCompressorManufacturer.Text == @"ALL")
            {
                return "ALL";
            }
            return ComboBoxControl.ItemInformations(cboCompressorManufacturer, Public.DSDatabase.Tables["CondensingUnitCompressorManufacturer"], "UniqueID")[0]["CompressorManufacturerParameter"].ToString();
        }

        //fill compressor Manufacturer
        private void Fill_CompressorManufacturer()
        {
            cboCompressorManufacturer.Items.Clear();

            ComboBoxControl.AddItem(cboCompressorManufacturer, "ALL", "ALL");

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
            if (cboRefrigerant.Text == @"ALL")
            {
                return "ALL";
            }
            return ComboBoxControl.ItemInformations(cboRefrigerant, Public.DSDatabase.Tables["CondensingUnitRefrigerant"], "RefrigerantID")[0]["RefrigerantParameter"].ToString();
        }

        //fill Refrigerant
        private void Fill_Refrigerant()
        {
            cboRefrigerant.Items.Clear();

            ComboBoxControl.AddItem(cboRefrigerant, "ALL", "ALL");

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

        private void cmdRunSelection_Click(object sender, EventArgs e)
        {
            RunSelection();
        }

        private void RunSelection()
        {
            ThreadProcess.Start(Public.LanguageString("Running Selection", "Sélection en cours"));

            //load the table needed
            string strBalancingViewNeeded = "v_CondensingUnitBalancing_" + Convert.ToInt32(txtSaturatedSuctionTemp.Text);

            Query.LoadTables(new[] { strBalancingViewNeeded });

            _dtLastSelection = _backgroundCode.SelectCondensingUnit(Public.DSDatabase.Tables["CondensingUnitModel"], Public.DSDatabase.Tables[strBalancingViewNeeded], Public.DSDatabase.Tables["CondensingUnitRefrigerant"], Type(), CompressorType(), CompressorManufacturer(), Refrigerant(), Voltage(), NumberOfCompressor(), numCapacity.Value, Convert.ToDecimal(CapacityRangeFactor()), Convert.ToDecimal(txtBalancingTemperature.Text), Convert.ToDecimal(txtSaturatedSuctionTemp.Text), RatingModelName());

            Query.UnloadTables(new[] { strBalancingViewNeeded });

            if (_dtLastSelection != null)
            {
                if (_dtLastSelection.Rows.Count > 0)
                {
                    Fill_CondensingUnitList();
                }
                else
                {
                    ClearSelection();
                    ThreadProcess.Stop();
                    Focus();
                    Public.LanguageBox("No selection for input parameters", "Aucune sélection pour les paramètres utilisés");
                }
            }
            else
            {
                ClearSelection();
                ThreadProcess.Stop();
                Focus();
                Public.LanguageBox("No selection for input parameters", "Aucune sélection pour les paramètres utilisés");
            }

            ThreadProcess.Stop();
            Focus();
        }

        private void Fill_CondensingUnitList()
        {
            lvCondensingUnit.Items.Clear();

            for (int intRow = 0; intRow < _dtLastSelection.Rows.Count; intRow++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvCondensingUnit);

                myItem.SubItems[0].Text = intRow.ToString(CultureInfo.InvariantCulture);
                myItem.SubItems[1].Text = _dtLastSelection.Rows[intRow]["Model"].ToString();
                myItem.SubItems[2].Text = Convert.ToDecimal(_dtLastSelection.Rows[intRow]["CommercialCapacity"]).ToString("N1");
                myItem.SubItems[3].Text = _dtLastSelection.Rows[intRow]["Refrigerant"].ToString();
                myItem.SubItems[4].Text = Convert.ToDecimal(_dtLastSelection.Rows[intRow]["Price"]).ToString("N2") + " $";

                lvCondensingUnit.Items.Add(myItem);
            }

            lvCondensingUnit.Refresh();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCondensingTemperature.Visible = false;
            lblAmbientTemperature.Visible = false;

            //2012-02-17 : #1558 : changing the default Temp to 95 on ambient and 100 on condensing base unit
            switch (BalancingType())
            {
                case "C":
                    lblCondensingTemperature.Visible = true;
                    txtBalancingTemperature.Text = @"100";
                    break;
                case "A":
                    lblAmbientTemperature.Visible = true;
                    txtBalancingTemperature.Text = @"95";
                    break;
            }

            ClearSelection();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilter.SelectedIndex == 0)
            {
                cboModel.Enabled = false;
                LockUnlockRating(false);
            }
            else
            {
                cboModel.Enabled = true;
                SetControlsForRatingMode();
            }

            ClearSelection();
        }

        private void SetControlsForRatingMode()
        {
            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitModel"], "Model = '" + cboModel.Text + "'", "");
            ComboBoxControl.SetIDDefaultValue(cboType, Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitType"], "TypeParameter = '" + dtModel.Rows[0]["UnitType"] + dtModel.Rows[0]["AirFlow"] + "'", "").Rows[0]["UniqueID"].ToString());
            ComboBoxControl.SetIDDefaultValue(cboCompressorType, Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorType"], "CompressorTypeParameter = '" + dtModel.Rows[0]["CompressorType"] + "'", "").Rows[0]["UniqueID"].ToString());
            ComboBoxControl.SetIDDefaultValue(cboCompressorManufacturer, Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorManufacturer"], "CompressorManufacturerParameter = '" + dtModel.Rows[0]["CompressorManufacturer"] + "'", "").Rows[0]["UniqueID"].ToString());
            ComboBoxControl.SetIDDefaultValue(cboRefrigerant, Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitRefrigerant"], "RefrigerantParameter = " + dtModel.Rows[0]["RefrigerantID"], "").Rows[0]["RefrigerantID"].ToString());
            ComboBoxControl.SetIDDefaultValue(cboVoltage, Public.SelectAndSortTable(Public.DSDatabase.Tables["Voltage"], "VoltageID = " + dtModel.Rows[0]["VoltageID"], "").Rows[0]["UniqueID"].ToString());
            ComboBoxControl.SetIDDefaultValue(cboNumberOfCompressors, dtModel.Rows[0]["NumberOfCompressor"].ToString());
            LockUnlockRating(true);
        }

        private void LockUnlockRating(bool Lock)
        {
            cboType.Enabled = !Lock;
            cboCompressorType.Enabled = !Lock;
            cboCompressorManufacturer.Enabled = !Lock;
            cboRefrigerant.Enabled = !Lock;
            cboVoltage.Enabled = !Lock;
            cboNumberOfCompressors.Enabled = !Lock;
            numCapacity.Enabled = !Lock;
            numCapacity.Value = 0m;
            cboCapacityRange.Enabled = !Lock;

            cboType.BackColor = Color.White;
            cboCompressorType.BackColor = Color.White;
            cboCompressorManufacturer.BackColor = Color.White;
            cboRefrigerant.BackColor = Color.White;
            cboVoltage.BackColor = Color.White;
            cboNumberOfCompressors.BackColor = Color.White;
            numCapacity.BackColor = Color.White;
            cboCapacityRange.BackColor = Color.White;
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModel.Enabled)
            {
                SetControlsForRatingMode();
            }
            ClearSelection();
        }

        private bool SelectOptions()
        {
            bool bolSelectionIsComplete;

            int index = Convert.ToInt32(((GlacialComponents.Controls.GLItem)lvCondensingUnit.SelectedItems[0]).SubItems[0].Text);

            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitModel"], "Model = '" + _dtLastSelection.Rows[index]["Model"] + "'", "");

            var options = new FrmCondensingUnitOption(
                _bolQuoteSelection,
                dtModel.Rows[0]["UnitType"].ToString(),
                dtModel.Rows[0]["AirFlow"].ToString(),
                dtModel.Rows[0]["CompressorType"].ToString(),
                dtModel.Rows[0]["HP"].ToString(),
                dtModel.Rows[0]["NumberOfCompressor"].ToString(),
                dtModel.Rows[0]["CompressorManufacturer"].ToString(),
                dtModel.Rows[0]["Application"].ToString(),
                dtModel.Rows[0]["RefrigerantID"].ToString(),
                dtModel.Rows[0]["VoltageID"].ToString(),
                dtModel.Rows[0]["Options"].ToString(),
                _dsQuoteData,
                _intIndex);

            if (options.ShowDialog() == DialogResult.OK)
            {
                _dtOptions = options.GetOptionInput;
                bolSelectionIsComplete = true;
            }
            else
            {
                _dtOptions.Clear();
                bolSelectionIsComplete = false;
            }

            return bolSelectionIsComplete;
        }

        private void Accept()
        {
            try
            {
                if (lvCondensingUnit.SelectedItems.Count > 0)
                {
                    if (SelectOptions())
                    {
                        ThreadProcess.Start(Public.LanguageString("Preparing data", "Préparation des données"));

                        _dtCondensingUnitInputs = CondensingUnitModelSaveTable();
                        _dtCompressorInputs = CondensingUnitCompressorSaveTable();
                        _dtWaterCooledInputs = CondensingUnitWaterCooledCondenserSaveTable();

                        //if press when form loaded from quote form
                        if (_bolQuoteSelection)
                        {
                            ThreadProcess.UpdateMessage(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                            int newIndexToPush;
                            if (_intIndex != -1)
                            {
                                var savingoption = new FrmSavingOption();

                                ThreadProcess.Stop();
                                Focus();

                                if (savingoption.ShowDialog() == DialogResult.Yes)
                                {//if he want to overwrite

                                    //it's a modification unit so we delete and recreate records
                                    _quoteform.DeleteFromQuoteCondensingUnit(_intIndex);
                                    newIndexToPush = _intIndex;
                                    _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CondensingUnit), newIndexToPush);
                                    //Quoteform.DeleteFromQuoteAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CondensingUnit));
                                }
                                else
                                {
                                    //since we actually always recreate the record
                                    // save as new is simple, all i have to do is copy the additionnal items
                                    //if reused the update function to instead duplicate record.
                                    newIndexToPush = _quoteform.GetNextID("CondensingUnit");
                                    _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CondensingUnit), newIndexToPush);

                                }

                                ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                            }
                            else
                            {
                                newIndexToPush = _quoteform.GetNextID("CondensingUnit");
                            }

                            AddToQuote(newIndexToPush);

                            _quoteform.RefreshBasketList();
                            _quoteform.SetQuoteIsModified(true);

                            ThreadProcess.Stop();
                            Focus();
                            Dispose();
                        }
                        else
                        {
                            ThreadProcess.UpdateMessage(Public.LanguageString("Generating Report", "Création du rapport"));
                            //generate the report for non-quote also
                            //add if to check to either generate or
                            //save to quote
                            CondensingUnitReport.GenerateDataReport(_dtCondensingUnitInputs, _dtCompressorInputs, _dtWaterCooledInputs, _dtOptions, true, 0, "");

                            ThreadProcess.Stop();
                            Focus();
                        }
                    }
                }
                else
                {
                    Public.LanguageBox("You must select a Condensing unit in the list before accepting the unit", "Vous devez sélectionner un groupe compresseur-condenseur avant d'accepter l'unité");
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickCondensingUnit Accept");
                ThreadProcess.Stop();
                Focus();
            }
            finally
            {
                ThreadProcess.Stop();
                Focus();
            }
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void AddToQuote(int itemID)
        {
            _dtCondensingUnitInputs.Rows[0]["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CondensingUnit);
            _dtCondensingUnitInputs.Rows[0]["ItemID"] = itemID;
            _dsQuoteData.Tables["CondensingUnit"].Rows.Add(_dtCondensingUnitInputs.Rows[0].ItemArray);

            DataTable copy = _dsQuoteData.Tables["CondensingUnit"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["CondensingUnit"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["CondensingUnit"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Input_Tag"], row["Quantity"], row["Input_Filter"], row["Input_Model"], row["Input_Type"], row["Input_CompressorType"], row["Input_CompressorManufacturer"], row["Input_NumberOfCompressor"], row["Input_Refrigerant"], row["Input_Capacity"], row["Input_CapacityRange"], row["Input_SST"], row["Input_Balancing"], row["Input_Voltage"], row["Input_CoilCoating"], row["Input_FinMaterial"], row["Model"], row["UnitType"], row["AirFlow"], row["CompressorType"], row["CompressorTypeText"], row["CompressorManufacturer"], row["CompressorManufacturerText"], row["Application"], row["ApplicationText"], row["RefrigerantID"], row["VoltageID"], row["HP"], row["Price"], row["Weight"], row["NumberOfCompressor"], row["MinBalancing"], row["MaxBalancing"], row["MinSST"], row["MaxSST"], row["FinMaterialPrice"], row["CoilCoatingPrice"], row["MCA"], row["MOP"], row["FUSE"], row["RefrigerantSummerCharge"], row["RefrigerantWinterCharge"], row["UnitCapacity"], row["UnitDrawing"], row["ElectricalDrawing"], row["CoilModel"], row["CFM"], row["CoilType"], row["FinType"], row["FinShape"], row["Tubes"], row["Row"], row["FPI"], row["Circuit"], row["FinHeight"], row["FinLength"], row["FinMaterial"], row["FinMaterialParameter"], row["FinThickness"], row["TubeMaterial"], row["TubeMaterialParameter"], row["TubeThickness"], row["FanWide"], row["FanLong"], row["MotorModel"], row["MotorMountModel"], row["FanModel"], row["FanGuardModel"], row["MotorHP"], row["MotorRPM"], row["MotorRotType"], row["MotorFrameType"], row["MotorShaftLength"], row["MotorPrice"], row["MotorFLA"], row["MotorMountFanSize"], row["MotorMountFrameSize"], row["MotorMountComposition"], row["MotorMountPrice"], row["FanDiameter"], row["FanBladeQuantity"], row["FanRotationType"], row["FanComposition"], row["FanPitch"], row["FanPrice"], row["FanGuardFanSize"], row["FanGuardComposition"], row["FanGuardPrice"]);
            }

            foreach (DataRow drCompressor in _dtCompressorInputs.Rows)
            {
                drCompressor["ItemType"] = _dtCondensingUnitInputs.Rows[0]["ItemType"];
                drCompressor["ItemID"] = _dtCondensingUnitInputs.Rows[0]["ItemID"];
                _dsQuoteData.Tables["CondensingUnitCompressorReceiver"].Rows.Add(drCompressor.ItemArray);
            }

            foreach (DataRow drWaterCooled in _dtWaterCooledInputs.Rows)
            {
                drWaterCooled["ItemType"] = _dtCondensingUnitInputs.Rows[0]["ItemType"];
                drWaterCooled["ItemID"] = _dtCondensingUnitInputs.Rows[0]["ItemID"];
                _dsQuoteData.Tables["CondensingUnitWaterCooledCondenser"].Rows.Add(drWaterCooled.ItemArray);
            }

            foreach (DataRow drOptions in _dtOptions.Rows)
            {
                drOptions["ItemType"] = _dtCondensingUnitInputs.Rows[0]["ItemType"];
                drOptions["ItemID"] = _dtCondensingUnitInputs.Rows[0]["ItemID"];
                _dsQuoteData.Tables["CondensingUnitOption"].Rows.Add(drOptions.ItemArray);
            }
        }

        private DataTable CondensingUnitWaterCooledCondenserSaveTable()
        {
            DataTable dtSaveTable = Tables.DtCondensingUnitWaterCooledCondensers();

            int index = Convert.ToInt32(((GlacialComponents.Controls.GLItem)lvCondensingUnit.SelectedItems[0]).SubItems[0].Text);

            DataTable dtWaterCooledCondensers = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitWaterCooledCondenserLink"], "Model = '" + _dtLastSelection.Rows[index]["Model"] + "'", "WaterCooledNumber ASC");

            if (dtWaterCooledCondensers.Rows.Count > 0)
            {
                for (int iWaterCooled = 0; iWaterCooled < dtWaterCooledCondensers.Rows.Count; iWaterCooled++)
                {
                    DataRow drSaveTable = dtSaveTable.NewRow();

                    drSaveTable = Tables.SetToZero(drSaveTable);

                    //header
                    drSaveTable["QuoteID"] = 0;
                    drSaveTable["QuoteRevision"] = 0;
                    drSaveTable["QuoteRevisionText"] = "";
                    drSaveTable["ItemType"] = 0;
                    drSaveTable["ItemID"] = 0;
                    drSaveTable["Username"] = "";

                    drSaveTable["WaterCooledNumber"] = Convert.ToInt32(dtWaterCooledCondensers.Rows[iWaterCooled]["WaterCooledNumber"]);
                    drSaveTable["WaterCooledModel"] = dtWaterCooledCondensers.Rows[iWaterCooled]["WaterCooledModel"].ToString();

                    decimal pumpDownCapacity = 0m;

                    DataTable dtWaterCooled = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitWaterCooledCondenser"], "WaterCooledModel = '" + drSaveTable["WaterCooledModel"] + "'", "");

                    if (dtWaterCooled.Rows.Count > 0)
                    {
                        pumpDownCapacity = Convert.ToDecimal(dtWaterCooled.Rows[0]["PumpDownCapacity"]);
                    }

                    drSaveTable["PumpDownCapacity"] = pumpDownCapacity;

                    dtSaveTable.Rows.Add(drSaveTable);
                }
            }

            dtWaterCooledCondensers.Dispose();


            return dtSaveTable;
        }

        private DataTable CondensingUnitCompressorSaveTable()
        {
            DataTable dtSaveTable = Tables.DtCondensingUnitCompressors();

            int index = Convert.ToInt32(((GlacialComponents.Controls.GLItem)lvCondensingUnit.SelectedItems[0]).SubItems[0].Text);

            DataTable dtCompressors = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorReceiverLink"], "Model = '" + _dtLastSelection.Rows[index]["Model"] + "'", "CompressorNumber ASC");

            if (dtCompressors.Rows.Count > 0)
            {
                for (int icomp = 0; icomp < dtCompressors.Rows.Count; icomp++)
                {
                    DataRow drSaveTable = dtSaveTable.NewRow();
                    drSaveTable = Tables.SetToZero(drSaveTable);

                    DataTable dtCompressorData = Public.SelectAndSortTable(Public.DSDatabase.Tables["CompressorData"], "Compressor = '" + dtCompressors.Rows[icomp]["CompressorModel"] + "' AND RefrigerantID = " + dtCompressors.Rows[icomp]["RefrigerantID"] + " AND VoltageID = " + dtCompressors.Rows[icomp]["VoltageID"], "");

                    //header
                    drSaveTable["QuoteID"] = 0;
                    drSaveTable["QuoteRevision"] = 0;
                    drSaveTable["QuoteRevisionText"] = "";
                    drSaveTable["ItemType"] = 0;
                    drSaveTable["ItemID"] = 0;
                    drSaveTable["Username"] = "";

                    drSaveTable["CompressorNumber"] = Convert.ToInt32(dtCompressors.Rows[icomp]["CompressorNumber"]);
                    drSaveTable["CompressorModel"] = dtCompressors.Rows[icomp]["CompressorModel"].ToString();
                    drSaveTable["VoltageID"] = Convert.ToInt32(dtCompressors.Rows[icomp]["VoltageID"]);
                    drSaveTable["RefrigerantID"] = Convert.ToInt32(dtCompressors.Rows[icomp]["RefrigerantID"]);
                    drSaveTable["RLA"] = Convert.ToDecimal(dtCompressorData.Rows[0]["RLA"]);
                    drSaveTable["LRA"] = Convert.ToDecimal(dtCompressorData.Rows[0]["LRA"]);
                    drSaveTable["SinglePhaseTandem"] = Convert.ToInt32(dtCompressorData.Rows[0]["SinglePhaseTandem"]);
                    drSaveTable["Liquid"] = Convert.ToDecimal(dtCompressors.Rows[icomp]["Liquid"]);
                    drSaveTable["Suction"] = Convert.ToDecimal(dtCompressors.Rows[icomp]["Suction"]);
                    drSaveTable["Discharge"] = Convert.ToDecimal(dtCompressors.Rows[icomp]["Discharge"]);
                    drSaveTable["LiquidText"] = dtCompressors.Rows[icomp]["LiquidText"].ToString();
                    drSaveTable["SuctionText"] = dtCompressors.Rows[icomp]["SuctionText"].ToString();
                    drSaveTable["DischargeText"] = dtCompressors.Rows[icomp]["DischargeText"].ToString();
                    drSaveTable["ReceiverModel"] = dtCompressors.Rows[icomp]["ReceiverModel"].ToString();
                    drSaveTable["CoilCapacityRatio"] = Convert.ToDecimal(dtCompressors.Rows[icomp]["CoilCapacityRatio"]);

                    dtCompressorData.Dispose();

                    decimal receiverCapacity = 0m;
                    decimal refrigerantCapacityFactor = 0m;

                    DataTable dtReceiver = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitReceiver"], "ReceiverModel = '" + drSaveTable["ReceiverModel"] + "'", "");

                    if (dtReceiver.Rows.Count > 0)
                    {
                        receiverCapacity = Convert.ToDecimal(dtReceiver.Rows[0]["PumpDownCapacity"]);
                    }

                    dtReceiver.Dispose();

                    DataTable dtRefrigerant = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitRefrigerant"], "RefrigerantParameter = " + drSaveTable["RefrigerantID"], "");

                    if (dtRefrigerant.Rows.Count > 0)
                    {
                        refrigerantCapacityFactor = Convert.ToDecimal(dtRefrigerant.Rows[0]["ReceiverPumpDownCapacityFactor"]);
                    }

                    dtRefrigerant.Dispose();

                    drSaveTable["ReceiverPumpDownCapacity"] = receiverCapacity * refrigerantCapacityFactor;

                    dtSaveTable.Rows.Add(drSaveTable);
                }
            }

            dtCompressors.Dispose();


            return dtSaveTable;
        }

        private decimal GetFinMaterialPrice(string strFinType, string strFinShape, int fpi, decimal decRows, decimal decFinHeight, decimal decFinLength)
        {
            decimal finMaterialPrice = 0m;

            if (cboFinMaterial.Text != "" && cboFinMaterial.Text != @"none")
            {
                finMaterialPrice = _backgroundCode.GetFinMaterialPrice(Public.DSDatabase.Tables["CoilFinMaterial"], Public.DSDatabase.Tables["CoilCasingMaterial"], Public.DSDatabase.Tables["coilTubeMaterial"], Public.DSDatabase.Tables["v_CoilFinDefaults"], strFinType, strFinShape, fpi, decRows, decFinHeight, decFinLength, cboFinMaterial.Text);
            }

            return finMaterialPrice;
        }

        //this return the saved data
        private DataTable CondensingUnitModelSaveTable()
        {
            //create the table
            DataTable dtSaveTable = Tables.DtCondensingUnit();

            //create a new row
            DataRow drSaveTable = dtSaveTable.NewRow();

            //set to empty all data
            drSaveTable = Tables.SetToZero(drSaveTable);

            //header
            drSaveTable["QuoteID"] = 0;
            drSaveTable["QuoteRevision"] = 0;
            drSaveTable["QuoteRevisionText"] = "";
            drSaveTable["ItemType"] = 0;
            drSaveTable["ItemID"] = 0;
            drSaveTable["Username"] = "";

            //inputs
            drSaveTable["Input_Tag"] = txtTag.Text;
            drSaveTable["Quantity"] = Convert.ToInt32(numQuantity.Value);
            drSaveTable["Input_Filter"] = cboFilter.Text;
            drSaveTable["Input_Model"] = cboModel.Text;
            drSaveTable["Input_Type"] = cboType.Text;
            drSaveTable["Input_CompressorType"] = cboCompressorType.Text;
            drSaveTable["Input_CompressorManufacturer"] = cboCompressorManufacturer.Text;
            drSaveTable["Input_NumberOfCompressor"] = cboNumberOfCompressors.Text;
            drSaveTable["Input_Refrigerant"] = cboRefrigerant.Text;
            drSaveTable["Input_Capacity"] = numCapacity.Value;
            drSaveTable["Input_CapacityRange"] = cboCapacityRange.Text;
            drSaveTable["Input_SST"] = txtSaturatedSuctionTemp.Text;
            drSaveTable["Input_Balancing"] = txtBalancingTemperature.Text;
            //drSaveTable["Input_SST"] = numSaturatedSuctionTemp.Value;
            //drSaveTable["Input_Balancing"] = numBalancingTemperature.Value;
            drSaveTable["Input_Voltage"] = cboVoltage.Text;
            drSaveTable["Input_CoilCoating"] = cboCoilCoating.Text;
            drSaveTable["Input_FinMaterial"] = cboFinMaterial.Text;

            int index = Convert.ToInt32(((GlacialComponents.Controls.GLItem)lvCondensingUnit.SelectedItems[0]).SubItems[0].Text);

            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitModel"], "Model = '" + _dtLastSelection.Rows[index]["Model"] + "'", "");

            if (dtModel.Rows.Count > 0)
            {
                drSaveTable["Model"] = dtModel.Rows[0]["Model"].ToString();
                drSaveTable["UnitType"] = dtModel.Rows[0]["UnitType"].ToString();
                drSaveTable["AirFlow"] = dtModel.Rows[0]["AirFlow"].ToString();
                drSaveTable["CompressorType"] = dtModel.Rows[0]["CompressorType"].ToString();
                drSaveTable["CompressorTypeText"] = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorType"], "CompressorTypeParameter = '" + drSaveTable["CompressorType"] + "'", "").Rows[0]["CompressorType"].ToString();
                drSaveTable["CompressorManufacturer"] = Convert.ToInt32(dtModel.Rows[0]["CompressorManufacturer"]);
                drSaveTable["CompressorManufacturerText"] = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorManufacturer"], "CompressorManufacturerParameter = '" + drSaveTable["CompressorManufacturer"] + "'", "").Rows[0]["CompressorManufacturer"].ToString();
                drSaveTable["Application"] = dtModel.Rows[0]["Application"].ToString();
                drSaveTable["ApplicationText"] = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitApplication"], "Parameter = '" + drSaveTable["Application"] + "'", "").Rows[0]["Application"].ToString();
                drSaveTable["RefrigerantID"] = Convert.ToInt32(dtModel.Rows[0]["RefrigerantID"]);
                drSaveTable["VoltageID"] = Convert.ToInt32(dtModel.Rows[0]["VoltageID"]);
                drSaveTable["HP"] = Convert.ToDecimal(dtModel.Rows[0]["HP"]);
                drSaveTable["Price"] = Convert.ToDecimal(dtModel.Rows[0]["Price"]);
                drSaveTable["Weight"] = Convert.ToDecimal(dtModel.Rows[0]["Weight"]);
                drSaveTable["NumberOfCompressor"] = Convert.ToInt32(dtModel.Rows[0]["NumberOfCompressor"]);
                drSaveTable["MinBalancing"] = Convert.ToInt32(dtModel.Rows[0]["MinBalancing"]);
                drSaveTable["MaxBalancing"] = Convert.ToInt32(dtModel.Rows[0]["MaxBalancing"]);
                drSaveTable["MinSST"] = Convert.ToInt32(dtModel.Rows[0]["MinSST"]);
                drSaveTable["MaxSST"] = Convert.ToInt32(dtModel.Rows[0]["MaxSST"]);
                drSaveTable["FinMaterialPrice"] = 0m;//filled in the coil part
                drSaveTable["CoilCoatingPrice"] = 0m;//filled in the coil part
                drSaveTable["MCA"] = 0m;//filled at the end
                drSaveTable["MOP"] = 0m;//filled at the end
                drSaveTable["FUSE"] = 0m;//filled at the end
                drSaveTable["RefrigerantSummerCharge"] = 0m;//filled in coil
                drSaveTable["RefrigerantWinterCharge"] = 0m;//filled in coil
                drSaveTable["UnitCapacity"] = Convert.ToDecimal(_dtLastSelection.Rows[index]["CommercialCapacity"]);

                //2012-05-22 : #1355 : we need to show the dwg name on the report
                string strDrawingName = DrawingManager.GetDrawingName_CondensingUnit(
                Public.DSDatabase.Tables["CondensingUnitDrawingManager"],
                drSaveTable["UnitType"].ToString(),
                drSaveTable["AirFlow"].ToString(),
                drSaveTable["CompressorType"].ToString(),
                drSaveTable["HP"].ToString(),
                drSaveTable["NumberOfCompressor"].ToString(),
                drSaveTable["CompressorManufacturer"].ToString(),
                drSaveTable["Application"].ToString(),
                drSaveTable["RefrigerantID"].ToString(),
                drSaveTable["VoltageID"].ToString(),
                dtModel.Rows[0]["Options"].ToString());

                drSaveTable["UnitDrawing"] = strDrawingName;

                drSaveTable["ElectricalDrawing"] = "";

                DataTable dtCoil = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCoilLink"], "Model = '" + _dtLastSelection.Rows[index]["Model"] + "'", "");

                if (dtCoil.Rows.Count > 0)
                {
                    //coil
                    drSaveTable["CoilModel"] = dtCoil.Rows[0]["CoilModel"].ToString();
                    drSaveTable["CFM"] = Convert.ToDecimal(dtCoil.Rows[0]["CFM"]);
                    drSaveTable["CoilType"] = dtCoil.Rows[0]["CoilType"].ToString();
                    drSaveTable["FinType"] = dtCoil.Rows[0]["FinType"].ToString();
                    drSaveTable["FinShape"] = dtCoil.Rows[0]["FinShape"].ToString();
                    drSaveTable["Tubes"] = Convert.ToInt32(dtCoil.Rows[0]["Tubes"]);
                    drSaveTable["Row"] = Convert.ToInt32(dtCoil.Rows[0]["Row"]);
                    drSaveTable["FPI"] = Convert.ToInt32(dtCoil.Rows[0]["FPI"]);
                    drSaveTable["Circuit"] = Convert.ToInt32(dtCoil.Rows[0]["Circuit"]);
                    drSaveTable["FinHeight"] = Convert.ToDecimal(dtCoil.Rows[0]["FinHeight"]);
                    drSaveTable["FinLength"] = Convert.ToDecimal(dtCoil.Rows[0]["FinLength"]);
                    drSaveTable["FinMaterial"] = dtCoil.Rows[0]["FinMaterial"].ToString();
                    drSaveTable["FinMaterialParameter"] = dtCoil.Rows[0]["FinMaterialParameter"].ToString();
                    drSaveTable["FinThickness"] = Convert.ToDecimal(dtCoil.Rows[0]["FinThickness"]);
                    drSaveTable["TubeMaterial"] = dtCoil.Rows[0]["TubeMaterial"].ToString();
                    drSaveTable["TubeMaterialParameter"] = dtCoil.Rows[0]["TubeMaterialParameter"].ToString();
                    drSaveTable["TubeThickness"] = Convert.ToDecimal(dtCoil.Rows[0]["TubeThickness"]);
                    drSaveTable["FanWide"] = Convert.ToInt32(dtCoil.Rows[0]["FanWide"]);
                    drSaveTable["FanLong"] = Convert.ToInt32(dtCoil.Rows[0]["FanLong"]);
                    drSaveTable["MotorModel"] = dtCoil.Rows[0]["MotorModel"].ToString();

                    drSaveTable["FinMaterialPrice"] = GetFinMaterialPrice(
                        drSaveTable["FinType"].ToString(),
                        drSaveTable["FinShape"].ToString(),
                        Convert.ToInt32(drSaveTable["FPI"]),
                        Convert.ToDecimal(drSaveTable["Row"]),
                        Convert.ToDecimal(drSaveTable["FinHeight"]),
                        Convert.ToDecimal(drSaveTable["FinLength"]));
                    drSaveTable["CoilCoatingPrice"] = GetCoilCoatingPrice(
                        drSaveTable["FinType"].ToString(),
                        Convert.ToDecimal(drSaveTable["Row"]),
                        Convert.ToDecimal(drSaveTable["FPI"]),
                        Convert.ToDecimal(drSaveTable["FinHeight"]),
                        Convert.ToDecimal(drSaveTable["FinLength"]));


                    var civ = new QuickCoil.CoilInternalVolume(
                        drSaveTable["FinType"].ToString(),
                        Convert.ToDecimal(drSaveTable["TubeThickness"]),
                        Convert.ToDecimal(drSaveTable["FinHeight"]),
                        Convert.ToDecimal(drSaveTable["FinLength"]),
                        Convert.ToInt32(drSaveTable["Row"]));

                    decimal decSummerCharge = 0m;
                    decimal decWinterCharge = 0m;

                    var rc = new RefrigerantCharge();
                    rc.SetCharges(
                        ref decSummerCharge,
                        ref decWinterCharge,
                        civ.GetInternalVolume(),
                        Convert.ToInt32(drSaveTable["RefrigerantID"]),
                        100m,
                        0.3m,
                        0.7m,
                        -20m,
                        0.7m,
                        0.3m);


                    drSaveTable["RefrigerantSummerCharge"] = decSummerCharge;
                    drSaveTable["RefrigerantWinterCharge"] = decWinterCharge;

                    DataTable dtMotor = Public.SelectAndSortTable(Public.DSDatabase.Tables["MotorModel"], "MotorID = '" + drSaveTable["MotorModel"] + "'", "");

                    if (dtMotor.Rows.Count > 0)
                    {
                        //motor
                        drSaveTable["MotorHP"] = Convert.ToDecimal(dtMotor.Rows[0]["HP"]);
                        drSaveTable["MotorRPM"] = Convert.ToDecimal(dtMotor.Rows[0]["RPM"]);
                        drSaveTable["MotorRotType"] = dtMotor.Rows[0]["RotType"].ToString();
                        drSaveTable["MotorFrameType"] = dtMotor.Rows[0]["FrameType"].ToString();
                        drSaveTable["MotorShaftLength"] = Convert.ToDecimal(dtMotor.Rows[0]["ShaftLength"]);
                        drSaveTable["MotorPrice"] = Convert.ToDecimal(dtMotor.Rows[0]["Price"]);

                        DataTable dtMotorFLA = Public.SelectAndSortTable(Public.DSDatabase.Tables["MotorModelFLA"], "MotorID = '" + drSaveTable["MotorModel"] + "' AND VoltageID = " + drSaveTable["VoltageID"], "");

                        if (dtMotorFLA.Rows.Count > 0)
                        {
                            drSaveTable["MotorFLA"] = Convert.ToDecimal(dtMotorFLA.Rows[0]["FLA"]);
                        }

                        dtMotorFLA.Dispose();
                    }

                    dtMotor.Dispose();

                    DataTable dtMotorMount = Public.SelectAndSortTable(Public.DSDatabase.Tables["MotorMountModel"], "MotorMountID = '" + drSaveTable["MotorMountModel"] + "'", "");

                    if (dtMotorMount.Rows.Count > 0)
                    {
                        //motor mount
                        drSaveTable["MotorMountFanSize"] = Convert.ToDecimal(dtMotorMount.Rows[0]["FanSize"]);
                        drSaveTable["MotorMountFrameSize"] = Convert.ToDecimal(dtMotorMount.Rows[0]["FrameSize"]);
                        drSaveTable["MotorMountComposition"] = dtMotorMount.Rows[0]["Composition"].ToString();
                        drSaveTable["MotorMountPrice"] = Convert.ToDecimal(dtMotorMount.Rows[0]["Price"]);
                    }

                    dtMotorMount.Dispose();

                    DataTable dtFan = Public.SelectAndSortTable(Public.DSDatabase.Tables["FanModel"], "FanID = '" + drSaveTable["FanModel"] + "'", "");

                    if (dtFan.Rows.Count > 0)
                    {
                        //fan
                        drSaveTable["FanDiameter"] = Convert.ToDecimal(dtFan.Rows[0]["Diameter"]);
                        drSaveTable["FanBladeQuantity"] = Convert.ToInt32(dtFan.Rows[0]["BladeQuantity"]);
                        drSaveTable["FanRotationType"] = dtFan.Rows[0]["RotationType"].ToString();
                        drSaveTable["FanComposition"] = dtFan.Rows[0]["Composition"].ToString();
                        drSaveTable["FanPitch"] = Convert.ToDecimal(dtFan.Rows[0]["Pitch"]);
                        drSaveTable["FanPrice"] = Convert.ToDecimal(dtFan.Rows[0]["Price"]);
                    }

                    dtFan.Dispose();

                    DataTable dtFanGuard = Public.SelectAndSortTable(Public.DSDatabase.Tables["FanGuardModel"], "FanGuardID = '" + drSaveTable["FanGuardModel"] + "'", "");

                    if (dtFanGuard.Rows.Count > 0)
                    {
                        //fan guard
                        drSaveTable["FanGuardFanSize"] = Convert.ToDecimal(dtFanGuard.Rows[0]["FanSize"]);
                        drSaveTable["FanGuardComposition"] = dtFanGuard.Rows[0]["Composition"].ToString();
                        drSaveTable["FanGuardPrice"] = Convert.ToDecimal(dtFanGuard.Rows[0]["Price"]);
                    }

                    dtFanGuard.Dispose();
                }

                dtCoil.Dispose();

                //mca, mop fuse

                decimal biggestFLA = GetBiggestFLA(drSaveTable["Model"].ToString(), Convert.ToDecimal(drSaveTable["MotorFLA"]));
                decimal totalFLA = GetTotalFLA(drSaveTable["Model"].ToString(), Convert.ToDecimal(drSaveTable["MotorFLA"]), Convert.ToInt32(drSaveTable["FanWide"]) * Convert.ToInt32(drSaveTable["FanLong"]));

                decimal mca = (1.25m * biggestFLA) + totalFLA - biggestFLA;
                decimal mop = (2.25m * biggestFLA) + totalFLA - biggestFLA;
                decimal fuse = _backgroundCode.GetFuseSize(Public.DSDatabase.Tables["FuseSize"], mca, mop);

                drSaveTable["MCA"] = mca;
                drSaveTable["MOP"] = mop;
                drSaveTable["FUSE"] = fuse;
            }

            dtModel.Dispose();

            //add the row to the table
            dtSaveTable.Rows.Add(drSaveTable);

            return dtSaveTable;
        }

        private decimal GetTotalFLA(string strModel, decimal motorFLA, int motorQuantity)
        {
            decimal totalFLA = 0m;

            totalFLA += motorFLA * motorQuantity;

            List<decimal[]> compressorRLA = GetCompressorRLA(strModel);

            for (int i = 0; i < compressorRLA.Count; i++)
            {
                //if the second parameter is 1 double it up, it mean it's tandem
                totalFLA += (compressorRLA[i][0] * (compressorRLA[i][1] == 1m ? 2m : 1m));
            }

            return totalFLA;
        }

        private decimal GetBiggestFLA(string strModel, decimal motorFLA)
        {
            decimal biggestFLA = 0m;

            biggestFLA = Math.Max(motorFLA, biggestFLA);

            List<decimal[]> compressorRLA = GetCompressorRLA(strModel);

            for (int i = 0; i < compressorRLA.Count; i++)
            {
                biggestFLA = Math.Max(compressorRLA[i][0], biggestFLA);
            }

            return biggestFLA;
        }

        private List<decimal[]> GetCompressorRLA(string strModel)
        {
            var compressorRLA = new List<decimal[]>();

            DataTable dtCompressors = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCompressorReceiverLink"], "Model = '" + strModel + "'", "");
            foreach (DataRow dr in dtCompressors.Rows)
            {
                DataTable dtCompressorData = Public.SelectAndSortTable(Public.DSDatabase.Tables["CompressorData"], "Compressor = '" + dr["CompressorModel"] + "' AND RefrigerantID = " + dr["RefrigerantID"] + " AND VoltageID = " + dr["VoltageID"], "");

                if (dtCompressorData.Rows.Count > 0)
                {
                    compressorRLA.Add(new[] { Convert.ToDecimal(dtCompressorData.Rows[0]["RLA"]), Convert.ToDecimal(dtCompressorData.Rows[0]["SinglePhaseTandem"]) });
                }
            }

            return compressorRLA;
        }

        private void ClearSelection()
        {
            if (_dtLastSelection != null)
            {
                _dtLastSelection.Rows.Clear();
            }
            lvCondensingUnit.Items.Clear();
            lvCondensingUnit.Refresh();
            cboFinMaterial.Items.Clear();
            cboCoilCoating.Items.Clear();
        }

        private void cboCompressorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboCompressorManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboRefrigerant_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numCapacity_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numSaturatedSuctionTemp_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
            numSaturatedSuctionTemp.Value = Convert.ToDecimal(numSaturatedSuctionTemp.Text);
        }

       
        private void cboVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboCoilCoating_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numBalancingTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
            numBalancingTemperature.Value = Convert.ToDecimal(numBalancingTemperature.Text);
        }

        private void cboNumberOfCompressors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboCapacityRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void lvCondensingUnit_Click(object sender, EventArgs e)
        {
            Fill_CoatingAndMaterial();
        }

        private void Fill_CoatingAndMaterial()
        {
            if (lvCondensingUnit.SelectedItems.Count > 0)
            {
                Fill_FinMaterial();
            }
        }

        private decimal GetCoilCoatingPrice(string finType, decimal rows, decimal fpi, decimal finHeight, decimal finLength)
        {
            decimal decCoatingPrice = 0m;

            switch (cboCoilCoating.Text)
            {
                case "Blygold":
                    var blyGoldCoating = new Pricing.BlyGoldCoating(finType, 1m, rows, fpi, finHeight, finLength);

                    //set value
                    decCoatingPrice = blyGoldCoating.Price;

                    //dispose

                    break;
                case "ElectroFin":
                    var electroFinCoating = new Pricing.ElectroFinCoating(1m, rows, fpi, finHeight, finLength);

                    //set value
                    decCoatingPrice = electroFinCoating.Price;

                    //dispose

                    break;
                case "Heresite":
                    var heresiteCoating = new Pricing.HeresiteCoating(1m, rows, finHeight, finLength);

                    //set value
                    decCoatingPrice = heresiteCoating.Price;

                    //dispose

                    break;
            }

            return decCoatingPrice;
        }

        private void Fill_FinMaterial()
        {
            cboFinMaterial.Items.Clear();

            int index = Convert.ToInt32(((GlacialComponents.Controls.GLItem)lvCondensingUnit.SelectedItems[0]).SubItems[0].Text);

            DataTable dtCoilInfo = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCoilLink"], "Model = '" + _dtLastSelection.Rows[index]["Model"] + "'", "");

            if (dtCoilInfo.Rows.Count == 0)
            {
                ComboBoxControl.AddItem(cboFinMaterial, "4", "NONE");
            }
            else
            {
                ComboBoxControl.AddItem(cboFinMaterial, "1", "ALUMINIUM");
                ComboBoxControl.AddItem(cboFinMaterial, "3", "EPOXY ALUMINIUM");
                ComboBoxControl.AddItem(cboFinMaterial, "2", "COPPER");
            }

            dtCoilInfo.Dispose();

            cboFinMaterial.SelectedIndex = 0;
        }

        private void Fill_CoilCoating()
        {
            //clear the list
            cboCoilCoating.Items.Clear();

            int index = Convert.ToInt32(((GlacialComponents.Controls.GLItem)lvCondensingUnit.SelectedItems[0]).SubItems[0].Text);

            DataTable dtCoilInfo = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitCoilLink"], "Model = '" + _dtLastSelection.Rows[index]["Model"] + "'", "");

            //add none
            ComboBoxControl.AddItem(cboCoilCoating, "1", "None");

            //only condensing unit that have coil and have aluminium fin material can have Coil Coating
            if (dtCoilInfo.Rows.Count > 0 && cboFinMaterial.Text == @"ALUMINIUM")
            {
                //side note on the blygold. in the coil we have a comment saying Hypoxy/Epoxy fin
                //cannot be coated since they are already baked cannot be coated. Here
                //we can add it without problem because these fin material are not selectable for evap
                //add blygold
                ComboBoxControl.AddItem(cboCoilCoating, "2", "Blygold");

                //check if electro fin available, if yes add it
                if (Query.IsElectroFinAvailable(Public.DSDatabase.Tables["ElectroFinAdjustement"].Copy(), Convert.ToInt32(dtCoilInfo.Rows[0]["Row"]), Convert.ToInt32(dtCoilInfo.Rows[0]["FPI"])))
                {
                    ComboBoxControl.AddItem(cboCoilCoating, "3", "ElectroFin");
                }

                //check if heresite available, if yes add it
                if (Query.IsHeresiteAvailable(Public.DSDatabase.Tables["HeresiteSafety"].Copy(), Convert.ToDecimal(dtCoilInfo.Rows[0]["FinHeight"]), Convert.ToDecimal(dtCoilInfo.Rows[0]["FinLength"])))
                {
                    ComboBoxControl.AddItem(cboCoilCoating, "4", "Heresite");
                }
            }

            dtCoilInfo.Dispose();

            //select none as default
            cboCoilCoating.SelectedIndex = 0;
        }

        private void cboFinMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_CoilCoating();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuickCondensingUnit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void txtBalancingTemperature_Validated(object sender, EventArgs e)
        {
            txtBalancingTemperature.Text = IsNumber(txtBalancingTemperature.Text) ? GetValidatedValueForMinMax(50m, 150m, Math.Round(Convert.ToDecimal(txtBalancingTemperature.Text), 0), 95m).ToString(CultureInfo.InvariantCulture) : "95";
        }

        private static decimal GetValidatedValueForMinMax(decimal min, decimal max, decimal value, decimal valueOutsideRange)
        {
            decimal returnValue;

            if (value < min || value > max)
            {
                returnValue = valueOutsideRange;
            }
            else
            {
                returnValue = value;
            }

            return returnValue;
        }

        private bool IsNumber(string s)
        {
            decimal testDecimal;

            return Decimal.TryParse(s,out testDecimal);
        }

        private void txtSaturatedSuctionTemp_Validated(object sender, EventArgs e)
        {
            txtSaturatedSuctionTemp.Text = IsNumber(txtSaturatedSuctionTemp.Text) ? GetValidatedValueForMinMax(-100m, 55m, Math.Round(Convert.ToDecimal(txtSaturatedSuctionTemp.Text), 0), 45m).ToString(CultureInfo.InvariantCulture) : "45";
        }

        private void txtBalancingTemperature_TextChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void txtSaturatedSuctionTemp_TextChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

    }
}