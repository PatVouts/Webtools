using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.Balancing
{
    public partial class FrmCompressorCondenserCoilBalancing : Form
    {

        private DataTable _dtCompressorList;
        private List<BalancingData> _lastBalancing;
        private readonly decimal _minAmbient;
        private readonly decimal _maxAmbient;
        private readonly decimal _minSST;
        private readonly decimal _maxSST;
        private readonly string _coilType = "";
        private readonly decimal _finHeight;
        private readonly decimal _finLength;
        private readonly decimal _cfm;
        private readonly string _refrigerant = "";
        private readonly decimal _fpi;
        private readonly decimal _rows;
        private readonly string _finMaterialParameter = "";
        private readonly decimal _finThickness;
        private readonly string _tubeMaterialParameter = "";
        private readonly decimal _tubeThickness;
        private readonly string _tubeType = "";
        private readonly int _circuits;
        private readonly List<Compressor> _compressors;
        readonly bool _openFromCondensingUnit;

        //Standard form constructor, nothing to do except initialize.
        public FrmCompressorCondenserCoilBalancing()
        {
            InitializeComponent();
        }

        //Form constructor with attributes, actually used (the signature higher up isn't).  Copies the info for the balancing to its internal attributes and initializes the form components
        public FrmCompressorCondenserCoilBalancing(decimal minAmbient, decimal maxAmbient, decimal minSST, decimal maxSST, string coilType, decimal finHeight, decimal finLength, decimal cfm, string refrigerant, decimal fpi, decimal rows, string finMaterialParameter, decimal finThickness, string tubeMaterialParameter, decimal tubeThickness, string tubeType, int circuits, List<Compressor> compressors)
        {
            InitializeComponent();

            _minAmbient = minAmbient;
            _maxAmbient = maxAmbient;
            _minSST = minSST;
            _maxSST = maxSST;
            _coilType = coilType;
            _finHeight = finHeight;
            _finLength = finLength;
            _cfm = cfm;
            _refrigerant = refrigerant;
            _fpi = fpi;
            _rows = rows;
            _finMaterialParameter = finMaterialParameter;
            _finThickness = finThickness;
            _tubeMaterialParameter = tubeMaterialParameter;
            _tubeThickness = tubeThickness;
            _tubeType = tubeType;
            _circuits = circuits;
            _compressors = compressors;
            _openFromCondensingUnit = true;
        }

        //Simple function to create a new empty item in the list and display it.
        private void cmdAddEmpty_Click(object sender, EventArgs e)
        {
            //create the item
            var myItem = new GlacialComponents.Controls.GLItem(lvCompressors);

            //add the empty data
            myItem.SubItems[0].Text = "Enter Model";
            myItem.SubItems[1].Text = "0";
            myItem.SubItems[2].Text = "0";
            myItem.SubItems[3].Text = "0";
            myItem.SubItems[4].Text = "0";
            myItem.SubItems[5].Text = "0";
            myItem.SubItems[6].Text = "0";
            myItem.SubItems[7].Text = "0";
            myItem.SubItems[8].Text = "0";
            myItem.SubItems[9].Text = "0";
            myItem.SubItems[10].Text = "0";
            myItem.SubItems[11].Text = "0";
            myItem.SubItems[12].Text = "0";
            myItem.SubItems[13].Text = "0";
            myItem.SubItems[14].Text = "0";
            myItem.SubItems[15].Text = "0";
            myItem.SubItems[16].Text = "0";
            myItem.SubItems[17].Text = "0";
            myItem.SubItems[18].Text = "0";
            myItem.SubItems[19].Text = "0";
            myItem.SubItems[20].Text = "0";

            //add item to list
            lvCompressors.Items.Add(myItem);

            //refresh the list
            lvCompressors.Refresh();
        }

        //auto-select content of numerical up and down on tab.  By default when you tab or click the numerical up down, it doesn't select the text.  this forces it to be the case, so you can "tab then type"
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        //Starts by assigning the language and color,m then filling the list of possible compressors, passing all attributes as default.  Then, if the form was opened from a condensing unit, loads the condensing
        //units' attributes
        private void frmCompressorCondenserCoilBalancing_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
            FillCompressorList();
            SetDefaults();

            if (_openFromCondensingUnit)
            {
                numAmbientMin.Value = _minAmbient;
                numAmbientMax.Value = _maxAmbient;
                numSSTMin.Value = _minSST;
                numSSTMax.Value = _maxSST;
                txtCoilType.Text = _coilType;
                numFinHeight.Value = _finHeight;
                numFinLength.Value = _finLength;
                numCFM.Value = _cfm;
                cboRefrigerant.Text = _refrigerant;
                numFPI.Value = _fpi;
                numRows.Value = _rows;
                cboFinMaterial.Text = _finMaterialParameter;
                numFinThickness.Value = _finThickness;
                cboTubeMaterial.Text = _tubeMaterialParameter;
                numTubeThickness.Value = _tubeThickness;
                cboTubeType.Text = _tubeType;
                cboCircuit.Text = _circuits.ToString(CultureInfo.InvariantCulture);

                //Show the compressor polynomials.
                for (int i = 0; i < _compressors.Count; i++)
                {
                    //create the item
                    var myItem = new GlacialComponents.Controls.GLItem(lvCompressors);

                    //add the data
                    myItem.SubItems[0].Text = _compressors[i].Model;
                    myItem.SubItems[1].Text = _compressors[i].GetCapacity1.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[2].Text = _compressors[i].GetCapacity2.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[3].Text = _compressors[i].GetCapacity3.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[4].Text = _compressors[i].GetCapacity4.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[5].Text = _compressors[i].GetCapacity5.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[6].Text = _compressors[i].GetCapacity6.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[7].Text = _compressors[i].GetCapacity7.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[8].Text = _compressors[i].GetCapacity8.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[9].Text = _compressors[i].GetCapacity9.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[10].Text = _compressors[i].GetCapacity10.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[11].Text = _compressors[i].GetPower1.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[12].Text = _compressors[i].GetPower2.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[13].Text = _compressors[i].GetPower3.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[14].Text = _compressors[i].GetPower4.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[15].Text = _compressors[i].GetPower5.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[16].Text = _compressors[i].GetPower6.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[17].Text = _compressors[i].GetPower7.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[18].Text = _compressors[i].GetPower8.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[19].Text = _compressors[i].GetPower9.ToString(CultureInfo.InvariantCulture);
                    myItem.SubItems[20].Text = _compressors[i].GetPower10.ToString(CultureInfo.InvariantCulture);

                    //add item to list
                    lvCompressors.Items.Add(myItem);
                }
                //refresh the list
                lvCompressors.Refresh();
            }
            ThreadProcess.Stop();
            Focus();
        }

        //Method to validate if the user has access to K fin with R-744 refrigerant
        //(COPIED FUNCTION TO MOVE)
        private bool HaveAccessToKFinAndR744()
        {
            //admin and Refplus group only should have access to K fin with R744
            return (UserInformation.UserName == "admin" || UserInformation.GroupID == 0);
        }

        //Setting all the combo boxes at index 0 to begin with
        private void SetDefaults()
        {
            cboRefrigerant.SelectedIndex = 0;
            cboFinMaterial.SelectedIndex = 0;
            cboTubeMaterial.SelectedIndex = 0;
            cboTubeType.SelectedIndex = 0;
            cboCircuit.SelectedIndex = 0;
        }

        //Method called when the form is created, so we can put all the existing compressors in the comboBox list
        private void FillCompressorList()
        {
            _dtCompressorList = Query.Select("SELECT CompressorData.*, Voltage.VoltDescription, Refrigerant.Refrigerant FROM CompressorData LEFT JOIN Voltage on CompressorData.VoltageID = Voltage.VoltageID LEFT JOIN Refrigerant on CompressorData.RefrigerantID = Refrigerant.RefrigerantID ORDER BY Compressor, CompressorData.RefrigerantID, CompressorData.VoltageID");
            //Cleaning up the comboBox list, so we can rebuild it
            cboCompressors.Items.Clear();
            //For every compressor found, add it to the combo box
            foreach (DataRow dr in _dtCompressorList.Rows)
            {
                ComboBoxControl.AddItem(cboCompressors, dr["Compressor"] + "|" + dr["RefrigerantID"] + "|" + dr["VoltageID"], dr["Compressor"] + " - " + dr["Refrigerant"] + " - " + dr["VoltDescription"]);
            }
            //Force to default index.
            cboCompressors.SelectedIndex = 0;
        }

        //Depending on the selected comptressor, adds it to the list of compressors with the correct polynomial
        private void cmdAddFromList_Click(object sender, EventArgs e)
        {
            //The different SPlits serve to separate the diverse attributes (compressor, refrigerant, voltage) so we can lookup in the table to see the polynomial for the compressor
            DataRow dr = Public.SelectAndSortTable(_dtCompressorList.Copy(), "Compressor = '" + ComboBoxControl.IndexInformation(cboCompressors).Split('|')[0] + "' AND RefrigerantID = " + ComboBoxControl.IndexInformation(cboCompressors).Split('|')[1] + " AND VoltageID = " + ComboBoxControl.IndexInformation(cboCompressors).Split('|')[2], "").Rows[0];
            //create the item
            var myItem = new GlacialComponents.Controls.GLItem(lvCompressors);
            //add the data
            myItem.SubItems[0].Text = dr["Compressor"].ToString();
            myItem.SubItems[1].Text = Convert.ToDecimal(dr["Capacity1"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[2].Text = Convert.ToDecimal(dr["Capacity2"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[3].Text = Convert.ToDecimal(dr["Capacity3"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[4].Text = Convert.ToDecimal(dr["Capacity4"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[5].Text = Convert.ToDecimal(dr["Capacity5"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[6].Text = Convert.ToDecimal(dr["Capacity6"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[7].Text = Convert.ToDecimal(dr["Capacity7"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[8].Text = Convert.ToDecimal(dr["Capacity8"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[9].Text = Convert.ToDecimal(dr["Capacity9"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[10].Text = Convert.ToDecimal(dr["Capacity10"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[11].Text = Convert.ToDecimal(dr["Power1"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[12].Text = Convert.ToDecimal(dr["Power2"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[13].Text = Convert.ToDecimal(dr["Power3"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[14].Text = Convert.ToDecimal(dr["Power4"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[15].Text = Convert.ToDecimal(dr["Power5"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[16].Text = Convert.ToDecimal(dr["Power6"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[17].Text = Convert.ToDecimal(dr["Power7"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[18].Text = Convert.ToDecimal(dr["Power8"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[19].Text = Convert.ToDecimal(dr["Power9"]).ToString(CultureInfo.InvariantCulture);
            myItem.SubItems[20].Text = Convert.ToDecimal(dr["Power10"]).ToString(CultureInfo.InvariantCulture);
            //add item to list
            lvCompressors.Items.Add(myItem);
            //refresh the list
            lvCompressors.Refresh();
      
        }

        //When clicking on remove, the system will remove the selected compressor from the glacial list.
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            //If the Count of selected compressors = 1, we can remove it.
            if (lvCompressors.SelectedItems.Count == 1)
            {
                lvCompressors.Items.Remove(((GlacialComponents.Controls.GLItem)lvCompressors.SelectedItems[0]));
                lvCompressors.Refresh();
            }
            else
            {
                Public.LanguageBox("Before removing a compressor, please select one. Thank you!", "Avant d'enlever un compresseur, veuillez-vous assurer d'en avoir sélectionné un.  Merci!");
            }
        }

        //Command to check if the user should be balancing current unit, and then balance or explain why the user cannot balance
        private void cmdBalance_Click(object sender, EventArgs e)
        {
            //If we have at least one compressor, and the user has access to K fin and R-744, we can call the balance method.  If not, we show a message explaining what's happening to the user
            if (lvCompressors.Items.Count > 0)
            {
                if (txtCoilType.Text.StartsWith("K") && !HaveAccessToKFinAndR744())
                {
                    Public.LanguageBox("You do not have access to K fin type", "Vous n'avez pas accès aux ailettes de type K");
                }
                else
                {
                    Balance();
                }
            }
            else
            {
                Public.LanguageBox("Make sure you have at least 1 compressor in order to balance.", "Assurez-vous d'avoir au moins un compresseur avant d'essayer de balancer.");
            }
        }

        //Function used when the data displayed changes.  Simply rewrites the balancing table in accordance to the specific unit requested (with the radio buttons)
        private void DisplayData()
        { 
            //add the data to the list
            foreach (BalancingData b in _lastBalancing)
            {
                string strDisplayValue = "";

                //Using the correct value depending on what the user asks to see
                if (radCapacity.Checked)
                {
                    strDisplayValue = (b.CAPACITY / 1000m).ToString(CultureInfo.InvariantCulture);
                }
                else if (radShowKw.Checked)
                {
                    strDisplayValue = b.KW.ToString(CultureInfo.InvariantCulture);
                }
                else if (radShowEER.Checked)
                {
                    strDisplayValue = b.EER.ToString(CultureInfo.InvariantCulture);
                }
                else if (radShowCondensing.Checked)
                {
                    strDisplayValue = b.CONDENSING.ToString(CultureInfo.InvariantCulture);
                }
                else if (radShowPressureDrop.Checked)
                {
                    strDisplayValue = b.LIQUIDPRESSUREDROP.ToString(CultureInfo.InvariantCulture);
                }
                //Adding the result to the correct row and column, using the balancingLine's suction and ambien temps
                lvResults.Items[GetRowIndex(b.AMBIENT)].SubItems[GetColumnIndex(b.SST)].Text = strDisplayValue;
            }
            lvResults.Refresh();
        }

        //Method to return the list of compressors in the form.
        private List<Compressor> GetCompressors()
        {
            var listOfCompressors = new List<Compressor>();
            //For each item in the list of compressors, add the "compressor" to the list returned
            for (int i = 0; i < lvCompressors.Items.Count; i++)
            {
                listOfCompressors.Add(new Compressor(
                    lvCompressors.Items[i].SubItems[0].Text,
                    Convert.ToDecimal(lvCompressors.Items[i].SubItems[1].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[2].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[3].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[4].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[5].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[6].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[7].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[8].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[9].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[10].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[11].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[12].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[13].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[14].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[15].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[16].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[17].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[18].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[19].Text),
                Convert.ToDecimal(lvCompressors.Items[i].SubItems[20].Text), 0m, ""));
            }
            return listOfCompressors;
        }

        //Balancing function itself.  Fills up a table with no data, making sure the table ranges covers what we need.  Then calls the "display data" function, which fills up the table with the correct data.
        private void Balance()
        {
            ThreadProcess.Start(Public.LanguageString("Balancing ...", "Balancement ..."));
            lvResults.Items.Clear();
            lvResults.Columns.Clear();
            lvResults.Refresh();
            //Build a balancingData list using the method from CompressorCondenserCoil
            _lastBalancing = CompressorCondenserCoil.GetBalancingData(numAmbientMin.Value,numAmbientMax.Value,numAmbientTicks.Value,numSSTMin.Value,numSSTMax.Value,numSSTTicks.Value,GetCompressors(),txtCoilType.Text,numFinHeight.Value,numFinLength.Value,numCFM.Value,cboRefrigerant.Text,numFPI.Value,Convert.ToInt32(cboCircuit.Text),numRows.Value,cboFinMaterial.Text,numFinThickness.Value,cboTubeMaterial.Text,numTubeThickness.Value,cboTubeType.Text);
            ThreadProcess.UpdateProgress(-1);
            ThreadProcess.UpdateMessage(Public.LanguageString("Displaying Data", "Affichage des Données"));
            //add the header column for sst and ambient
            lvResults.Columns.Add(new GlacialComponents.Controls.GLColumn("Ambient \\ SST"));
            //add sst columns
            for (int i = Convert.ToInt32(numSSTMin.Value); i <= Convert.ToInt32(numSSTMax.Value); i+=Convert.ToInt32(numSSTTicks.Value))
            {
                var myCol = new GlacialComponents.Controls.GLColumn {Text = i.ToString(CultureInfo.InvariantCulture)};
                lvResults.Columns.Add(myCol);              
            }

            //add rows to contain data for each ambient
            for (int i = Convert.ToInt32(numAmbientMin.Value); i <= Convert.ToInt32(numAmbientMax.Value); i+= Convert.ToInt32(numAmbientTicks.Value))
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvResults);
                myItem.SubItems[0].Text = i.ToString(CultureInfo.InvariantCulture);
                int totalSST = Convert.ToInt32(numSSTMax.Value) - Convert.ToInt32(numSSTMin.Value);
                for (int sst = 0; sst <= totalSST; sst++)
                {
                    myItem.SubItems[sst + 1].Text = "0";
                }
                lvResults.Items.Add(myItem);
            }
            //Put the correct data in the table now.
            DisplayData();
            ThreadProcess.Stop();
            Focus();
        }

        //Cycles through the row indexes and checks to see if one is the right ambient temperature.  In that case, returns it.  In other cases, returns -1 (no chance of it happening)
        private int GetRowIndex(decimal ambient)
        {
            for (int i = 0; i < lvResults.Items.Count; i++)
            {
                if (Convert.ToInt32(lvResults.Items[i].SubItems[0].Text) == Convert.ToInt32(ambient))
                {
                    return i;
                }
            }
            return -1;
        }

        //Cycles through the column indexes and checks to see if one is the right suction temperature.  In that case, returns it.  In other cases, returns -1 (no chance of it happening)
        private int GetColumnIndex(decimal sst)
        {
            //first column is textual so we bypass it
            for (int i = 1; i < lvResults.Columns.Count; i++)
            {
                if (Convert.ToInt32(lvResults.Columns[i].Text) == Convert.ToInt32(sst))
                {
                    return i;
                }
            }
            return -1;
        }

        //Function called to select the text whenever you go in the txtbox for the coil type
        private void txtCoilType_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        //Function called whenever the user changes the radio button currently selected. Changes the whole data set to show the data formatted according to the requested unit.
        private void DiplayCheckChanged()
        {
            ThreadProcess.Start(Public.LanguageString("Displaying Data", "Affichages des Données"));
            DisplayData();
            ThreadProcess.Stop();
            Focus();
        }

        //Function to call the displaying data function whenever the user changes which unit is selected for display
        private void radCapacity_CheckedChanged(object sender, EventArgs e)
        {
            DiplayCheckChanged();
        }

        //Function to call the displaying data function whenever the user changes which unit is selected for display
        private void radShowEER_CheckedChanged(object sender, EventArgs e)
        {
            DiplayCheckChanged();
        }

        //Function to call the displaying data function whenever the user changes which unit is selected for display
        private void radShowKw_CheckedChanged(object sender, EventArgs e)
        {
            DiplayCheckChanged();
        }

        //Function to call the displaying data function whenever the user changes which unit is selected for display
        private void radShowCondensing_CheckedChanged(object sender, EventArgs e)
        {
            DiplayCheckChanged();
        }

        //Function to call the displaying data function whenever the user changes which unit is selected for display
        private void radShowPressureDrop_CheckedChanged(object sender, EventArgs e)
        {
            DiplayCheckChanged();
        }

        //closes the form
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Copies the balancing data to the user's clipboard, building the data in a readable way at the same time
        private void CopyToClipboardData()
        {
            const string tab = "\t";
            const string newline = "\r\n";

            var genericHeader = "";
            var capacity = "";
            var kilowatts = "";
            var eer = "";
            var condensing = "";
            var liquidPressure = "";

            genericHeader += "Ambient \\ SST" + tab;

            //add sst columns
            for (int i = Convert.ToInt32(numSSTMin.Value); i <= Convert.ToInt32(numSSTMax.Value); i += Convert.ToInt32(numSSTTicks.Value))
            {
                genericHeader += i + "°F" + tab;
            }

            genericHeader += newline;

            //add rows to contain data for each ambient
            for (int i = Convert.ToInt32(numAmbientMin.Value); i <= Convert.ToInt32(numAmbientMax.Value); i += Convert.ToInt32(numAmbientTicks.Value))
            {
                //ambient temperature
                capacity += i + "°F" + tab;
                kilowatts += i + "°F" + tab;
                eer += i + "°F" + tab;
                condensing += i + "°F" + tab;
                liquidPressure += i + "°F" + tab;

                //Then put the data of the correct row in the corect value.
                for (int j = Convert.ToInt32(numSSTMin.Value); j <= Convert.ToInt32(numSSTMax.Value); j += Convert.ToInt32(numSSTTicks.Value))
                {
                    BalancingData b = GetBalancingData(i, j);
                    capacity += Math.Round(b.CAPACITY / 1000m, 1) + tab;
                    kilowatts += Math.Round(b.KW, 2) + tab;
                    eer += Math.Round(b.EER, 2) + tab;
                    condensing += Math.Round(b.CONDENSING, 0) + tab;
                    liquidPressure += Math.Round(b.LIQUIDPRESSUREDROP, 3) + tab;
                }
                capacity += newline;
                kilowatts += newline;
                eer += newline;
                condensing += newline;
                liquidPressure += newline;
            }
            //build up

            //Copy text to clipboard, formatted in a correct way, showing unit after unit, for all suctions and ambient temps
            Clipboard.SetText("CAPACITY" + newline + genericHeader + capacity + newline +
                              "KILOWATTS" + newline + genericHeader + kilowatts + newline +
                              "EER" + newline + genericHeader + eer + newline +
                              "CONDENSING" + newline + genericHeader + condensing + newline +
                              "LIQUID PRESSURE DROP" + newline + genericHeader + liquidPressure);
        }

        //Return the balancing data for a specifit ambient and suction temperature
        private BalancingData GetBalancingData(decimal ambient, decimal sst)
        {
            foreach (BalancingData b in _lastBalancing)
            {
                if (b.AMBIENT == ambient && b.SST == sst)
                {
                    return b;
                }
            }
            return null;
        }

        //check if there is some balancing data shown.  If there isn't, returns an error message.  if there is data, copies it to the clipboard.
        private void cmdCopyClipboard_Click(object sender, EventArgs e)
        {
            if (_lastBalancing != null && _lastBalancing.Count > 0)
            {
                CopyToClipboardData();
            }
            else
            {
                Public.LanguageBox("You do not have any balancing displayed", "Vouz n'avez aucune information à copier au presse-papiers");
            }
        }

        // If user presses F1, summons the help files for this form
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        //Summons the help files for the form you're in.
        private void frmCompressorCondenserCoilBalancing_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}