using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.QuickEvaporator
{
    public partial class FrmQuickEvaporator : Form
    {
        //form need access to his background code
        private readonly QuickEvaporatorCode _backgroundCode = new QuickEvaporatorCode();

        //this DataTable will only hold the most recent selection
        private DataTable _dtRecentSelection = new DataTable();
        private DataTable _dtOptions = Tables.DtEvaporatorOptions();

        private readonly string[] _strTableList = { "EvaporatorDefrostType", "EvaporatorPowerSupply", "EvaporatorVoltage", "Evaporators", "v_Evaporators", "ElectroFinAdjustement", "HeresiteSafety", "CoilFinType", "CoilFinMaterial", "CoilCasingMaterial", "CoilTubeMaterial", "V_CoilFinDefaults", "V_CoilTubeDefaults", "Drawings", "CondenserRefrigerant", "FuseSize", "Evaporators", "EvaporatorDrawingManager" };

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        public FrmQuickEvaporator()
        {
            InitializeComponent();
        }

        public FrmQuickEvaporator(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
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

        private void chkAttachToCondensingUnit_CheckedChanged(object sender, EventArgs e)
        {
            cboCondensingUnit.Visible = chkAttachToCondensingUnit.Checked;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void frmQuickEvaporator_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            Query.LoadTables(_strTableList);

            //fill all the combobox
            Fill_Combobox();

            //set defaults
            SetDefaults();

            ThreadProcess.Stop();
            Focus();

            if (_bolQuoteSelection && _intIndex != -1)
            {
                LoadSavedData();
            }
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void SetDefaults()
        {
            //R-134A refrigerant default
            ComboBoxControl.SetDefaultValue(cboRefrigerant, "R-134A");

            //voltage 208-240/3/60 (5)
            ComboBoxControl.SetIDDefaultValue(cboVoltage, "5");

            //air defrost (1)
            ComboBoxControl.SetIDDefaultValue(cboDefrostType, "1");

            //fpi to stadard
            ComboBoxControl.SetDefaultValue(cboFinsPerInch, "STANDARD");

            //selection type Automatic
            ComboBoxControl.SetDefaultValue(cboSelectionType, "AUTOMATIC");

            //selection type Automatic
            ComboBoxControl.SetDefaultValue(cboFinMaterial, "ALUMINIUM");

            //select first model
            cboModel.SelectedIndex = 0;

            //if it's not a quote we hide the price column
            if (!_bolQuoteSelection)
            {
                lvEvaporators.Columns[4].Width = 0;
            }
        }

        private void Fill_Combobox()
        {
            //fill defrost type
            Fill_DefrostType();

            //fill voltage
            Fill_Voltage();

            //fill fpi
            Fill_FPI();

            //fill model
            Fill_Model();

            //2011-08-24 : #1068 now it must be filled according to the selected evap coil
            ////fill fin material
            //Fill_FinMaterial();
        }

        private int ModelLowVelocity()
        {
            return Convert.ToInt32(ComboBoxControl.ItemInformations(cboModel, Public.DSDatabase.Tables["Evaporators"], "EvaporatorID")[0]["LowVelocity"]);
        }

        //return the defrost type of a specific model when not in Automatic selection
        private string ModelDefrostType()
        {
            return ComboBoxControl.ItemInformations(cboModel, Public.DSDatabase.Tables["Evaporators"], "EvaporatorID")[0]["DefrostType"].ToString();
        }

        private void Fill_Model()
        {
            cboModel.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            //2011-07-25 : ticket #798 orderring was not done in this list. simply added it.

            DataTable dtTempEvap = Public.SelectAndSortTable(Public.DSDatabase.Tables["Evaporators"], "", "EvaporatorID");

            //for each model
            foreach (DataRow drModel in dtTempEvap.Rows)
            {
                string strIndex = drModel["EvaporatorID"].ToString();
                string strText = drModel["EvaporatorID"].ToString();
                ComboBoxControl.AddItem(cboModel, strIndex, strText);
            }
        }

        //return the fpi parameter
        private int FPIParameter()
        {
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboFinsPerInch));
        }

        private void Fill_FPI()
        {
            ComboBoxControl.AddItem(cboFinsPerInch, "-99", "STANDARD");
            ComboBoxControl.AddItem(cboFinsPerInch, "4", "4");
            ComboBoxControl.AddItem(cboFinsPerInch, "5", "5");
            ComboBoxControl.AddItem(cboFinsPerInch, "6", "6");
        }

        //return the voltageId, mostly used in tables for reference
        private int VoltageID()
        {
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboVoltage));
        }

        private void Fill_Voltage()
        {
            cboVoltage.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each voltage
            foreach (DataRow drVoltage in Public.DSDatabase.Tables["EvaporatorVoltage"].Rows)
            {
                string strIndex = drVoltage["VoltageID"].ToString();
                string strText = drVoltage["VoltDescription"].ToString();
                ComboBoxControl.AddItem(cboVoltage, strIndex, strText);
            }
        }

        //return the defrost type parameter (mostly used in tables as reference
        private string DefrostTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboDefrostType, Public.DSDatabase.Tables["EvaporatorDefrostType"], "UniqueID")[0]["DefrostTypeParameter"].ToString();
        }

        private void Fill_DefrostType()
        {
            cboDefrostType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each defrost
            foreach (DataRow drDefrostType in Public.DSDatabase.Tables["EvaporatorDefrostType"].Rows)
            {
                string strIndex = drDefrostType["UniqueID"].ToString();
                string strText = drDefrostType["DefrostType"].ToString();
                ComboBoxControl.AddItem(cboDefrostType, strIndex, strText);
            }
        }

        //return the capacity in btuh
        private decimal CapacityInBTU()
        {
            return numRequiredCapacity.Value * 1000m;
        }

        private void cmdRunSelection_Click(object sender, EventArgs e)
        {
            ExecuteSelection();
            ValidateCoilCoating();
        }

        //this run the selection and call another function to fill the list
        private void ExecuteSelection()
        {
            ThreadProcess.Start(Public.LanguageString("Running Selection", "Sélection en cours"));

            //clean the table
            _dtRecentSelection = new DataTable();

            //if automatic then
            _dtRecentSelection = cboSelectionType.Text == @"AUTOMATIC" ? _backgroundCode.RunEvaporatorSelection(Public.DSDatabase.Tables["v_Evaporators"].Copy(), CapacityInBTU(), Convert.ToInt32(numQuantity.Value), numSuctionTemperature.Value, DefrostTypeParameter(), VoltageID(), FPIParameter(), Convert.ToInt32(numMinTemp.Value), Convert.ToInt32(numMaxTemp.Value)) : _backgroundCode.ModelInformations(Public.DSDatabase.Tables["v_Evaporators"].Copy(), cboModel.Text, Convert.ToInt32(numQuantity.Value), VoltageID(), FPIParameter(), numSuctionTemperature.Value, Convert.ToInt32(numMinTemp.Value), Convert.ToInt32(numMaxTemp.Value), _backgroundCode.IsEvaporatorStandard((ModelLowVelocity() == 1), ModelDefrostType()));

            //fill the list view with all evaporator found
            Fill_ListOfEvaporators();

            ThreadProcess.Stop();
            Focus();
        }

        //fill the listview
        private void Fill_ListOfEvaporators()
        {
            lvEvaporators.Items.Clear();

            //for each record add it to the list view
            for (int intRows = 0; intRows < _dtRecentSelection.Rows.Count; intRows++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvEvaporators);
                myItem.SubItems[0].Text = intRows.ToString(CultureInfo.InvariantCulture);
                myItem.SubItems[1].Text = _dtRecentSelection.Rows[intRows]["EvaporatorID"].ToString();
                myItem.SubItems[2].Text = Convert.ToDecimal(_dtRecentSelection.Rows[intRows]["CAPACITY_FOR_TD"]).ToString("N0") + " BTU/H";
                myItem.SubItems[3].Text = Convert.ToDecimal(_dtRecentSelection.Rows[intRows]["TD_FOR_CAPACITY"]).ToString("N1") + " °FTD";
                myItem.SubItems[4].Text = Convert.ToDecimal(_dtRecentSelection.Rows[intRows]["EvaporatorPrice"]).ToString("N2") + " $";

                lvEvaporators.Items.Add(myItem);
            }

            lvEvaporators.Refresh();
        }

        private void cboSelectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //on automatic we do not use a specific model
            if (cboSelectionType.Text == @"AUTOMATIC")
            {
                cboModel.Enabled = false;

                //also capacity and defrost type are not available when not automatic
                cboDefrostType.Enabled = true;
                numRequiredCapacity.Enabled = true;
            }
            else
            {
                cboModel.Enabled = true;
                //also capacity and defrost type are not available when not automatic
                cboDefrostType.Enabled = false;
                numRequiredCapacity.Enabled = false;
            }
            ClearSelection();
        }

        private DataTable GetSaveTable()
        {
            DataTable dtSaveTable = Tables.DtEvaporator();

            DataRow drSaveTable = dtSaveTable.NewRow();
            //header
            drSaveTable["QuoteID"] = 0;
            drSaveTable["QuoteRevision"] = 0;
            drSaveTable["QuoteRevisionText"] = "";
            drSaveTable["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Evaporator);
            drSaveTable["ItemID"] = 0;
            drSaveTable["Username"] = "";

            var myItem = ((GlacialComponents.Controls.GLItem)lvEvaporators.SelectedItems[0]);

            int intIndex = Convert.ToInt32(myItem.SubItems[0].Text);

            foreach (DataColumn dc in _dtRecentSelection.Columns)
            {
                if (dtSaveTable.Columns[dc.ColumnName] != null)
                {
                    if (dc.DataType == typeof(string))
                    {
                        drSaveTable[dc.ColumnName] = _dtRecentSelection.Rows[intIndex][dc.ColumnName].ToString();
                    }
                    else if (dc.DataType == typeof(decimal) || dc.DataType == typeof(double))
                    {
                        drSaveTable[dc.ColumnName] = Convert.ToDecimal(_dtRecentSelection.Rows[intIndex][dc.ColumnName]);
                    }
                    else if (dc.DataType == typeof(int))
                    {
                        drSaveTable[dc.ColumnName] = Convert.ToInt32(_dtRecentSelection.Rows[intIndex][dc.ColumnName]);
                    }
                }
            }

            drSaveTable["AttachToCondensingUnit"] = (chkAttachToCondensingUnit.Checked ? 1 : 0);
            drSaveTable["CondensingUnitItemID"] = 0;
            drSaveTable["CondensingUnitSystemName"] = cboCondensingUnit.Text;
            drSaveTable["Tag"] = txtTag.Text;
            drSaveTable["Quantity"] = Convert.ToInt32(numQuantity.Value);
            drSaveTable["SuctionTemperature"] = numSuctionTemperature.Value;
            drSaveTable["LiquidTemperature"] = numLiquidTemperature.Value;
            drSaveTable["RefrigerantText"] = cboRefrigerant.Text;
            drSaveTable["DefrostText"] = cboDefrostType.Text;
            drSaveTable["VoltageText"] = cboVoltage.Text;
            drSaveTable["FPIText"] = cboFinsPerInch.Text;
            drSaveTable["TemperatureRangeMin"] = numMinTemp.Value;
            drSaveTable["TemperatureRangeMax"] = numMaxTemp.Value;
            drSaveTable["RequiredCapacity"] = numRequiredCapacity.Value;
            drSaveTable["SelectionTypeText"] = cboSelectionType.Text;
            drSaveTable["ModelText"] = cboModel.Text;
            drSaveTable["CoilCoatingText"] = cboCoilCoating.Text;
            //drSaveTable["CoilCoatingPrice"] = cboCoilCoating.Text == "Blygold" ? Convert.ToDecimal(drSaveTable["BlygoldPrice"]) : GetCoilCoatingPrice(drSaveTable["CoilModel"].ToString().Substring(1, 1), Convert.ToDecimal(drSaveTable["CoilRow"]), (Convert.ToInt32(drSaveTable["CurrentFPI"]) == -99 ? Convert.ToDecimal(drSaveTable["StandardFPI"]) : Convert.ToDecimal(drSaveTable["CurrentFPI"])), BackgroundCode.GetCoilFinHeight(Public.dsDATABASE.Tables["CoilFinType"], drSaveTable["CoilModel"].ToString(), Convert.ToInt32(drSaveTable["CoilTubes"])), Convert.ToDecimal(drSaveTable["CoilLength"]));
            drSaveTable["CoilCoatingPrice"] = GetCoilCoatingPrice(Convert.ToDecimal(drSaveTable["CoilRow"]), (Convert.ToInt32(drSaveTable["CurrentFPI"]) == -99 ? Convert.ToDecimal(drSaveTable["StandardFPI"]) : Convert.ToDecimal(drSaveTable["CurrentFPI"])), _backgroundCode.GetCoilFinHeight(Public.DSDatabase.Tables["CoilFinType"], drSaveTable["CoilModel"].ToString(), Convert.ToInt32(drSaveTable["CoilTubes"])), Convert.ToDecimal(drSaveTable["CoilLength"]), Convert.ToDecimal(_dtRecentSelection.Rows[intIndex]["BlygoldPrice"]));
            drSaveTable["FinMaterialText"] = cboFinMaterial.Text;
            drSaveTable["FinMaterialPrice"] = _backgroundCode.GetFinMaterialPrice(Public.DSDatabase.Tables["CoilFinMaterial"], Public.DSDatabase.Tables["CoilCasingMaterial"], Public.DSDatabase.Tables["coilTubeMaterial"], Public.DSDatabase.Tables["v_CoilFinDefaults"], drSaveTable["CoilModel"].ToString().Substring(1, 1), drSaveTable["CoilModel"].ToString().Substring(2, 1), Convert.ToInt32(drSaveTable["StandardFPI"]), (Convert.ToInt32(drSaveTable["CurrentFPI"]) == -99 ? Convert.ToInt32(drSaveTable["StandardFPI"]) : Convert.ToInt32(drSaveTable["CurrentFPI"])), Convert.ToDecimal(drSaveTable["CoilRow"]), _backgroundCode.GetCoilFinHeight(Public.DSDatabase.Tables["CoilFinType"], drSaveTable["CoilModel"].ToString(), Convert.ToInt32(drSaveTable["CoilTubes"])), Convert.ToDecimal(drSaveTable["CoilLength"]), cboFinMaterial.Text);



            //fill the description
            drSaveTable["Description"] = "Evaporator : " + drSaveTable["EvaporatorID"]
                + Environment.NewLine + drSaveTable["VoltageText"]
                + Environment.NewLine + drSaveTable["CAPACITY_FOR_TD"] + " BTU/H  @ " + drSaveTable["TD_FOR_CAPACITY"] + " TD";

            //set price
            drSaveTable["Price"] = Convert.ToDecimal(drSaveTable["EvaporatorPrice"]);


            drSaveTable["RefrigerantChargeMultiplier"] = _backgroundCode.GetRefrigerantChargeMultiplier(Public.DSDatabase.Tables["CondenserRefrigerant"], cboRefrigerant.Text);
            drSaveTable["DefrostHeaterKilowatts"] = _backgroundCode.GetElectricHeaterKilowatts(Convert.ToInt32(drSaveTable["EvaporatorHeaterQty"]), Convert.ToDecimal(drSaveTable["DefrostHeaterWatt"]), Convert.ToDecimal(drSaveTable["WattMultiplier"]));
            drSaveTable["HeaterFLA"] = _backgroundCode.GetElectricHeaterFLA(Convert.ToInt32(drSaveTable["EvaporatorHeaterQty"]), Convert.ToDecimal(drSaveTable["DefrostHeaterWatt"]), Convert.ToDecimal(drSaveTable["HeaterFLAMultiplier"]), Convert.ToInt32(drSaveTable["VoltsValue"]), Convert.ToInt32(drSaveTable["PhaseNumber"]));
            drSaveTable["HeaterMCA"] = _backgroundCode.GetHeaterMCA(Convert.ToDecimal(drSaveTable["HeaterFLA"]));
            drSaveTable["HeaterFUSE"] = _backgroundCode.GetHeaterFuseSize(Public.DSDatabase.Tables["FuseSize"], Convert.ToDecimal(drSaveTable["HeaterMCA"]));
            drSaveTable["MotorMCA"] = _backgroundCode.GetMotorMCA(Convert.ToInt32(drSaveTable["EvaporatorFanQty"]), Convert.ToDecimal(drSaveTable["MotorFLA"]));
            drSaveTable["MotorMOP"] = _backgroundCode.GetMotorMOP(Convert.ToInt32(drSaveTable["EvaporatorFanQty"]), Convert.ToDecimal(drSaveTable["MotorFLA"]));
            drSaveTable["MotorFUSE"] = _backgroundCode.GetMotorFuseSize(Public.DSDatabase.Tables["FuseSize"], Convert.ToDecimal(drSaveTable["MotorMCA"]), Convert.ToDecimal(drSaveTable["MotorMOP"]));

            //2012-05-22 : #1355 : adding dwg to spec
            string strSerie = drSaveTable["EvaporatorID"].ToString().Substring(0, 1) +
                               drSaveTable["EvaporatorID"].ToString().Substring(1, 1) +
                               drSaveTable["EvaporatorID"].ToString().Substring(2, 1);

            string strDrawingName = DrawingManager.GetDrawingName_Evaporator(
                 Public.DSDatabase.Tables["EvaporatorDrawingManager"],
                 strSerie,
                 Convert.ToDecimal(drSaveTable["CapacityAt10TD"]),
                 drSaveTable["VoltageID"].ToString());

            //string strDrawingName = DrawingManager.GetDrawingName(Public.dsDATABASE.Tables["Drawings"], drSaveTable["EvaporatorID"].ToString());
            drSaveTable["DimensionDrawing"] = (strDrawingName ?? "");
            drSaveTable["ElectricalDrawing"] = "";

            dtSaveTable.Rows.Add(drSaveTable);

            return dtSaveTable;
        }

        private void LoadSavedData()
        {
            //will contain all errors
            string strErrors = "";

            DataTable dtData = Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Evaporator) + " AND ItemID = " + _intIndex, "");
            DataRow drData = dtData.NewRow();
            drData.ItemArray = dtData.Rows[0].ItemArray;

            chkAttachToCondensingUnit.Checked = (drData["AttachToCondensingUnit"].ToString() == "1");

            if (chkAttachToCondensingUnit.Checked)
            {
                if (cboCondensingUnit.FindString(drData["CondensingUnitText"].ToString()) >= 0)
                {
                    cboCondensingUnit.SelectedIndex = cboCondensingUnit.FindString(drData["CondensingUnitText"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find linked Condensing Unit", "- Incapable de trouver le groupe compresseur-condenseur sélectionné") + Environment.NewLine;
                }
            }

            txtTag.Text = drData["Tag"].ToString();

            numQuantity.Value = Convert.ToDecimal(drData["Quantity"]);

            if (Convert.ToDecimal(drData["SuctionTemperature"]) >= numSuctionTemperature.Minimum && Convert.ToDecimal(drData["SuctionTemperature"]) <= numSuctionTemperature.Maximum)
            {
                numSuctionTemperature.Value = Convert.ToDecimal(drData["SuctionTemperature"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select suction temperature (Your value is out of the new bounds)", "- Impossible de sélectionner la même température de succion (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (Convert.ToDecimal(drData["LiquidTemperature"]) >= numLiquidTemperature.Minimum && Convert.ToDecimal(drData["LiquidTemperature"]) <= numLiquidTemperature.Maximum)
            {
                numLiquidTemperature.Value = Convert.ToDecimal(drData["LiquidTemperature"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select liquid temperature (Your value is out of the new bounds)", "- Impossible de sélectionner la même température du liquide (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (cboRefrigerant.FindString(drData["RefrigerantText"].ToString()) >= 0)
            {
                cboRefrigerant.SelectedIndex = cboRefrigerant.FindString(drData["RefrigerantText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Refrigerant", "- Incapable de trouver le Réfrigérant sélectionné") + Environment.NewLine;
            }

            if (cboDefrostType.FindStringExact(drData["DefrostText"].ToString()) >= 0)
            {
                cboDefrostType.SelectedIndex = cboDefrostType.FindStringExact(drData["DefrostText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Defrost Type", "- Incapable de trouver le Type de Dégivrage sélectionné") + Environment.NewLine;
            }

            if (cboVoltage.FindString(drData["VoltageText"].ToString()) >= 0)
            {
                cboVoltage.SelectedIndex = cboVoltage.FindString(drData["VoltageText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Voltage", "- Incapable de trouver le Voltage sélectionné") + Environment.NewLine;
            }

            if (cboFinsPerInch.FindString(drData["FPIText"].ToString()) >= 0)
            {
                cboFinsPerInch.SelectedIndex = cboFinsPerInch.FindString(drData["FPIText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Fins Per Inch", "- Incapable de trouver le nombre d'ailettes par pouces sélectionné") + Environment.NewLine;
            }

            if (Convert.ToDecimal(drData["TemperatureRangeMin"]) >= numMinTemp.Minimum && Convert.ToDecimal(drData["TemperatureRangeMin"]) <= numMinTemp.Maximum)
            {
                numMinTemp.Value = Convert.ToDecimal(drData["TemperatureRangeMin"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select minimum temperature (Your value is out of the new bounds)", "- Impossible de sélectionner la même température minimum (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (Convert.ToDecimal(drData["TemperatureRangeMax"]) >= numMaxTemp.Minimum && Convert.ToDecimal(drData["TemperatureRangeMax"]) <= numMaxTemp.Maximum)
            {
                numMaxTemp.Value = Convert.ToDecimal(drData["TemperatureRangeMax"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select maximum temperature (Your value is out of the new bounds)", "- Impossible de sélectionner la même température maximum (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (Convert.ToDecimal(drData["RequiredCapacity"]) >= numRequiredCapacity.Minimum && Convert.ToDecimal(drData["RequiredCapacity"]) <= numRequiredCapacity.Maximum)
            {
                numRequiredCapacity.Value = Convert.ToDecimal(drData["RequiredCapacity"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select Required Capacity (Your value is out of the new bounds)", "- Impossible de sélectionner la même capacité requise (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (cboSelectionType.FindString(drData["SelectionTypeText"].ToString()) >= 0)
            {
                cboSelectionType.SelectedIndex = cboSelectionType.FindString(drData["SelectionTypeText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Selection Type", "- Incapable de trouver le Type de Sélection sélectionné") + Environment.NewLine;
            }

            if (cboModel.FindString(drData["ModelText"].ToString()) >= 0)
            {
                cboModel.SelectedIndex = cboModel.FindString(drData["ModelText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Model in rating mode", "- Incapable de trouver le Modèle sélectionné en mode performance") + Environment.NewLine;
            }





            //here run the selection
            ExecuteSelection();

            //now get the index of the model
            int intRecordIndex = -1;
            for (int intItem = 0; intItem < _dtRecentSelection.Rows.Count; intItem++)
            {
                if (_dtRecentSelection.Rows[intItem]["EvaporatorID"].ToString() == drData["EvaporatorID"].ToString())
                {
                    intRecordIndex = intItem;
                }
            }

            //if no error and there an index is there
            if (strErrors == "" && intRecordIndex >= 0)
            {
                lvEvaporators.Items[intRecordIndex].Selected = true;
                lvEvaporators.Select();
                ValidateCoilCoating();
            }
            else
            {
                Public.LanguageBox("Selected model doesn't exist anymore for the actual inputs. Please contact Refplus if you need more information", "Le modèle que vous avez sélectionné n'est plus disponible pour les valeurs que vous avez. Veuillez contacter Refplus si vous avez besoin de plus d'informations.");
            }

            //2011-08-24 : #1068 : needed to move the loading of the fin material in order to load properly. since
            //nowi t's based on the coil inside the evaporator unit we need to highlight hte unit before reselecting
            //previously saved data
            if (cboFinMaterial.FindString(drData["FinMaterialText"].ToString()) >= 0)
            {
                cboFinMaterial.SelectedIndex = cboFinMaterial.FindString(drData["FinMaterialText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Fin Material", "- Incapable de trouver le matériau des Ailettes sélectionné") + Environment.NewLine;
            }

            if (cboCoilCoating.FindString(drData["CoilCoatingText"].ToString()) >= 0)
            {
                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(drData["CoilCoatingText"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Coil Coating", "- Incapable de trouver le Revêtement du serpentin sélectionné") + Environment.NewLine;
            }

            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivantes sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      

        private void ValidateCoilCoating()
        {
            if (lvEvaporators.SelectedItems.Count > 0)
            {
                Fill_FinMaterial();
                Fill_CoilCoating();
            }
            else
            {
                cboFinMaterial.Items.Clear();
                cboCoilCoating.Items.Clear();
            }
        }

        private void Fill_FinMaterial()
        {
            cboFinMaterial.Items.Clear();

            var myItem = ((GlacialComponents.Controls.GLItem)lvEvaporators.SelectedItems[0]);

            int intIndex = Convert.ToInt32(myItem.SubItems[0].Text);

            string strFinType = _dtRecentSelection.Rows[intIndex]["CoilType"].ToString().Substring(1, 1);
            string strFinShape = _dtRecentSelection.Rows[intIndex]["CoilType"].ToString().Substring(2, 1);
            int intFPI = Convert.ToInt32(_dtRecentSelection.Rows[intIndex]["CoilFPI"]);

            //these variable as use for easier modification of index or text showing
            //in the combobox

            var qcc = new QuickCoil.QuickCoilCode();
            //for each fin type
            foreach (DataRow drFinMaterial in Public.DSDatabase.Tables["CoilFinMaterial"].Rows)
            {
                //if we can found the fintype in the table that mean it's available for
                //the selected coil type so we can show it
                if (qcc.IsFinMaterialAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), strFinType, strFinShape, intFPI, drFinMaterial["UniqueID"].ToString()))
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
            //ComboBoxControl.AddItem(cboFinMaterial, "1", "ALUMINIUM");
            //ComboBoxControl.AddItem(cboFinMaterial, "2", "COPPER");
        }

        private decimal GetCoilCoatingPrice(decimal rows, decimal fpi, decimal finHeight, decimal finLength, decimal blygoldPrice)
        {
            decimal decCoatingPrice = 0m;

            switch (cboCoilCoating.Text)
            {
                case "Blygold":
                    //Pricing.BlyGoldCoating BlyGoldCoating = new Pricing.BlyGoldCoating(FinType, 1m, Rows, FPI, FinHeight, FinLength);


                    //set value
                    decCoatingPrice = blygoldPrice;

                    //dispose
                    //BlyGoldCoating = null;

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

        private void Fill_CoilCoating()
        {
            //clear the list
            cboCoilCoating.Items.Clear();

            var myItem = ((GlacialComponents.Controls.GLItem)lvEvaporators.SelectedItems[0]);

            int intIndex = Convert.ToInt32(myItem.SubItems[0].Text);

            //add none
            ComboBoxControl.AddItem(cboCoilCoating, "1", "None");

            //side note on the blygold. in the coil we have a comment saying Hypoxy/Epoxy fin
            //cannot be coated since they are already baked cannot be coated. Here
            //we can add it without problem because these fin material are not selectable for evap
            //add blygold
            ComboBoxControl.AddItem(cboCoilCoating, "2", "Blygold");

            //check if electro fin available, if yes add it
            if (Query.IsElectroFinAvailable(Public.DSDatabase.Tables["ElectroFinAdjustement"].Copy(), Convert.ToInt32(_dtRecentSelection.Rows[intIndex]["CoilRow"]), Convert.ToInt32(_dtRecentSelection.Rows[intIndex]["CoilFPI"])))
            {
                ComboBoxControl.AddItem(cboCoilCoating, "3", "ElectroFin");
            }

            //check if heresite available, if yes add it
            if (Query.IsHeresiteAvailable(Public.DSDatabase.Tables["HeresiteSafety"].Copy(), Convert.ToDecimal(_dtRecentSelection.Rows[intIndex]["CoilTubes"]) * GetFaceTubeSize(_dtRecentSelection.Rows[intIndex]["CoilType"].ToString().Substring(1, 1)), Convert.ToDecimal(_dtRecentSelection.Rows[intIndex]["CoilLength"])))
            {
                ComboBoxControl.AddItem(cboCoilCoating, "4", "Heresite");
            }

            //select none as default
            cboCoilCoating.SelectedIndex = 0;
        }

        private decimal GetFaceTubeSize(string finType)
        {
            decimal faceTubeSize = 0m;

            DataTable dtFinType = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinType"].Copy(), "FinType = '" + finType + "'", "");

            if (dtFinType.Rows.Count > 0)
            {
                faceTubeSize = Convert.ToDecimal(dtFinType.Rows[0]["FaceTube"]);
            }

            return faceTubeSize;
        }

        private bool SelectOptions()
        {
            bool bolSelectionIsComplete = false;

            var myItem = ((GlacialComponents.Controls.GLItem)lvEvaporators.SelectedItems[0]);

            int index = Convert.ToInt32(myItem.SubItems[0].Text);

            var options = new FrmEvaporatorOption(
                _bolQuoteSelection,
                _dtRecentSelection.Rows[index]["EvaporatorID"].ToString().Substring(0, 1),
                _dtRecentSelection.Rows[index]["EvaporatorID"].ToString().Substring(1, 1),
                _dtRecentSelection.Rows[index]["EvaporatorID"].ToString().Substring(2, 1),
                Convert.ToDecimal(_dtRecentSelection.Rows[index]["CapacityAt10TD"]),
                _dtRecentSelection.Rows[index]["VoltageID"].ToString(),
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
            }

            return bolSelectionIsComplete;
        }

        private bool SelectCoating()
        {
            bool bolSelectionIsComplete = false;

            var evapcoating = new FrmEvaporatorCoating(cboCoilCoating);

            if (evapcoating.ShowDialog() == DialogResult.OK)
            {
                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(evapcoating.GetSelectedCoating());
                bolSelectionIsComplete = true;
            }

            return bolSelectionIsComplete;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (lvEvaporators.SelectedItems.Count > 0)
            {
                if (SelectCoating())
                {
                    if (SelectOptions())
                    {
                        //if press when form loaded from quote form
                        if (_bolQuoteSelection)
                        {
                            ThreadProcess.Start(Public.LanguageString("Adding Evaporator to quote", "Ajout de l'Évaporateur à la soumission"));
                            DataTable dtSave = GetSaveTable();
                            //DataSet dsEvapData = new DataSet("EvaporatorDATA");
                            //dsEvapData.Tables.Add(dtSave.Copy());
                            //dsEvapData.WriteXmlSchema("EvaporatorXSD.xsd");
                            int newIndexToPush;
                            //we need create new record
                            if (_intIndex != -1)
                            {
                                var savingoption = new FrmSavingOption();

                                ThreadProcess.Stop();
                                Focus();

                                if (savingoption.ShowDialog() == DialogResult.Yes)
                                {//if he want to overwrite

                                    _quoteform.DeleteFromQuoteEvaporator(_intIndex);
                                    newIndexToPush = _intIndex;
                                    _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Evaporator), newIndexToPush);
                                    //Quoteform.DeleteFromQuoteAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Evaporator));
                                }
                                else
                                {
                                    //since we actually always recreate the record
                                    // save as new is simple, all i have to do is copy the additionnal items
                                    //if reused the update function to instead duplicate record.
                                    newIndexToPush = _quoteform.GetNextID("Evaporators");
                                    _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Evaporator), newIndexToPush);

                                }

                                ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                            }
                            else
                            {
                                newIndexToPush = _quoteform.GetNextID("Evaporators");
                            }

                            dtSave.Rows[0]["ItemID"] = newIndexToPush;
                            _dsQuoteData.Tables["Evaporators"].Rows.Add(dtSave.Rows[0].ItemArray);

                            foreach (DataRow drOptions in _dtOptions.Rows)
                            {
                                drOptions["ItemType"] = dtSave.Rows[0]["ItemType"];
                                drOptions["ItemID"] = dtSave.Rows[0]["ItemID"];
                                _dsQuoteData.Tables["EvaporatorOption"].Rows.Add(drOptions.ItemArray);
                            }


                            DataTable copy = _dsQuoteData.Tables["Evaporators"].Copy();
                            DataRow[] list = copy.Select("", "itemID");

                            _dsQuoteData.Tables["Evaporators"].Rows.Clear();
                            foreach (DataRow row in list)
                            {
                                _dsQuoteData.Tables["Evaporators"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["AttachToCondensingUnit"], row["CondensingUnitItemID"], row["CondensingUnitSystemName"], row["Tag"], row["Quantity"], row["SuctionTemperature"], row["LiquidTemperature"], row["RefrigerantText"], row["DefrostText"], row["VoltageText"], row["FPIText"], row["TemperatureRangeMin"], row["TemperatureRangeMax"], row["RequiredCapacity"], row["SelectionTypeText"], row["ModelText"], row["CoilCoatingText"], row["CoilCoatingPrice"], row["FinMaterialText"], row["FinMaterialPrice"], row["Description"], row["Price"], row["RefrigerantChargeMultiplier"], row["MotorMCA"], row["MotorMOP"], row["MotorFUSE"], row["HeaterFLA"], row["HeaterMCA"], row["HeaterFUSE"], row["DimensionDrawing"], row["ElectricalDrawing"], row["EvaporatorID"], row["CapacityAt10TD"], row["DefrostType"], row["EvaporatorCapacity"], row["EvaporatorWeight"], row["EvaporatorCoilQty"], row["EvaporatorFanQty"], row["EvaporatorHeaterQTY"], row["EvaporatorCFM"], row["EvaporatorRefCharge"], row["EvaporatorPrice"], row["LowVelocity"], row["Liquid"], row["Suction"], row["HotGas"], row["ConnQty"], row["FanArrangement"], row["SSucTemp"], row["FSucTemp"], row["EvaporatorType"], row["CoilType"], row["CoilTubes"], row["CoilRow"], row["CoilFPI"], row["CoilLength"], row["CoilModel"], row["EvaporatorTypeDesc"], row["EvaporatorStyleDesc"], row["DefrostTypeID"], row["DefrostTypeDescription"], row["UnitID"], row["VoltageID"], row["StandardFPI"], row["CurrentFPI"], row["FPIMultiplier"], row["VoltDescription"], row["VoltsValue"], row["PhaseNumber"], row["HzValue"], row["WattMultiplier"], row["HeaterFLAMultiplier"], row["PowerFactorAdjustement"], row["MotorCoilArr"], row["PowerSupply"], row["CapacityMultiplier"], row["Motor"], row["MotorHP"], row["MotorRPM"], row["MotorRotType"], row["MotorFrameType"], row["MotorShaftLength"], row["MotorPrice"], row["MotorFLA"], row["MotorMount"], row["MotorMountFanSize"], row["MotorMountFrameSize"], row["MotorMountComposition"], row["MotorMountPrice"], row["Fan"], row["FanDiameter"], row["FanBladeQuantity"], row["FanRotationType"], row["FanComposition"], row["FanPitch"], row["FanPrice"], row["FanGuard"], row["FanGuardFanSize"], row["FanGuardComposition"], row["DefrostHeater"], row["DefrostHeaterType"], row["DefrostHeaterVolt"], row["DefrostHeaterWatt"], row["DefrostHeaterDesc"], row["DefrostHeaterPrice"], row["DefrostHeaterKilowatts"], row["CapacityMultiplied"], row["TD_FOR_CAPACITY"], row["CAPACITY_FOR_TD"]);
                            }
                            //here call refresh of quote form
                            _quoteform.RefreshBasketList();
                            _quoteform.SetQuoteIsModified(true);
                            ThreadProcess.Stop();
                            Focus();

                            Dispose();
                        }
                        else
                        {
                            DataTable dtSave = GetSaveTable();

                            ThreadProcess.Start(Public.LanguageString("Generating Report", "Création du rapport"));

                            EvaporatorReport.GenerateDataReport(dtSave, _dtOptions, true, 0, "");

                            ThreadProcess.Stop();
                            Focus();
                        }
                    }
                }
            }
        }


        private void lvEvaporators_SelectedIndexChanged(object source, GlacialComponents.Controls.ClickEventArgs e)
        {

        }

        private void lvEvaporators_Click(object sender, EventArgs e)
        {
            if (lvEvaporators.SelectedItems.Count > 0)
            {
                ValidateCoilCoating();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

      

        private void numRequiredCapacity_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void ClearSelection()
        {
            lvEvaporators.Items.Clear();
            lvEvaporators.Refresh();
        }

        private void txtTag_TextChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numSuctionTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numLiquidTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboRefrigerant_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboDefrostType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboFinsPerInch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numMinTemp_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numMaxTemp_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }
    }
}