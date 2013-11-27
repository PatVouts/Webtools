using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmCompressor : Form
    {
        private DataTable _dtTable;
        private readonly Boolean _compressorChosen;

        private readonly string _compressor;
        private readonly string _refrigerant;
        private readonly string _voltage;

        public FrmCompressor()
        {
            InitializeComponent();
        }

        public FrmCompressor(string compressor, string refrigerant, string voltage)
        {
            InitializeComponent();
            _compressor = compressor;
            _refrigerant = refrigerant;
            _voltage = voltage; 
            _compressorChosen = true;
        }
        private void frmCompressor_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            FillTable();

            FillRefrigerant();

            FillVoltage();

            FillManufacturer();

            FillType();

            FillCompressorModel();

            FillTableView();

            WindowState = FormWindowState.Maximized;

            if (_compressorChosen)
            {
                cboModel.SelectedIndex =
    cboModel.FindString(_compressor + " - " +
                        _refrigerant + " - " +
                        _voltage);
            }
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

        private void FillCompressorModel()
        {
            cboModel.Items.Clear();

            ComboBoxControl.AddItem(cboModel, "[ADD NEW]", "[ADD NEW]");
            
            foreach (DataRow dr in _dtTable.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["Compressor"] + "|" + dr["RefrigerantID"] + "|" + dr["VoltageID"], dr["Compressor"] + " - " + dr["Refrigerant"] + " - " + dr["VoltDescription"]);
            }

            cboModel.SelectedIndex = 0;
        }

        private void FillRefrigerant()
        {
            DataTable dtRefrigerant = Query.Select("SELECT * FROM Refrigerant ORDER BY Refrigerant");

            foreach (DataRow dr in dtRefrigerant.Rows)
            {
                ComboBoxControl.AddItem(cboRefrigerant, dr["RefrigerantID"].ToString(), dr["Refrigerant"].ToString());
            }

            cboRefrigerant.SelectedIndex = 0;
        }

        private void FillManufacturer()
        {
            DataTable dtManufacturer = Query.Select("SELECT * FROM CompressorManufacturer ORDER BY Manufacturer");

            foreach (DataRow dr in dtManufacturer.Rows)
            {
                ComboBoxControl.AddItem(cboManufacturer, dr["Manufacturer"].ToString(), dr["Manufacturer"].ToString());
            }

            cboManufacturer.SelectedIndex = 0;
        }

        private void FillType()
        {
            DataTable dtType = Query.Select("SELECT * FROM CompressorType ORDER BY CompressorType");

            foreach (DataRow dr in dtType.Rows)
            {
                ComboBoxControl.AddItem(cboType, dr["CompressorType"].ToString(), dr["CompressorType"].ToString());
            }

            cboType.SelectedIndex = 0;
        }

        private void FillVoltage()
        {
            DataTable dtVoltage = Query.Select("SELECT * FROM Voltage ORDER BY VoltDescription");

            foreach (DataRow dr in dtVoltage.Rows)
            {
                ComboBoxControl.AddItem(cboVoltage, dr["VoltageID"].ToString(), dr["VoltDescription"].ToString());
            }

            cboVoltage.SelectedIndex = 0;
        }

        private void FillPolynomialList(decimal c1, decimal c2, decimal c3, decimal c4, decimal c5, decimal c6, decimal c7, decimal c8, decimal c9, decimal c10, decimal p1, decimal p2, decimal p3, decimal p4, decimal p5, decimal p6, decimal p7, decimal p8, decimal p9, decimal p10)
        {
            glPoly.Items.Clear();

            glPoly.Items.Add(GetPolyItem("C1", c1));
            glPoly.Items.Add(GetPolyItem("C2", c2));
            glPoly.Items.Add(GetPolyItem("C3", c3));
            glPoly.Items.Add(GetPolyItem("C4", c4));
            glPoly.Items.Add(GetPolyItem("C5", c5));
            glPoly.Items.Add(GetPolyItem("C6", c6));
            glPoly.Items.Add(GetPolyItem("C7", c7));
            glPoly.Items.Add(GetPolyItem("C8", c8));
            glPoly.Items.Add(GetPolyItem("C9", c9));
            glPoly.Items.Add(GetPolyItem("C10", c10));
            glPoly.Items.Add(GetPolyItem("P1", p1));
            glPoly.Items.Add(GetPolyItem("P2", p2));
            glPoly.Items.Add(GetPolyItem("P3", p3));
            glPoly.Items.Add(GetPolyItem("P4", p4));
            glPoly.Items.Add(GetPolyItem("P5", p5));
            glPoly.Items.Add(GetPolyItem("P6", p6));
            glPoly.Items.Add(GetPolyItem("P7", p7));
            glPoly.Items.Add(GetPolyItem("P8", p8));
            glPoly.Items.Add(GetPolyItem("P9", p9));
            glPoly.Items.Add(GetPolyItem("P10", p10));

            glPoly.Refresh();
        }

        private GlacialComponents.Controls.GLItem GetPolyItem(string strText, decimal value)
        {
            var myItem = new GlacialComponents.Controls.GLItem(glPoly);

            myItem.SubItems[0].Text = strText;
            myItem.SubItems[1].Text = value.ToString(CultureInfo.InvariantCulture);

            return myItem;
        }

        private void FillTable()
        {
            _dtTable = Query.Select("SELECT CompressorData.*, Voltage.VoltDescription, Refrigerant.Refrigerant FROM CompressorData LEFT JOIN Voltage on CompressorData.VoltageID = Voltage.VoltageID LEFT JOIN Refrigerant on CompressorData.RefrigerantID = Refrigerant.RefrigerantID ORDER BY Compressor, CompressorData.RefrigerantID, CompressorData.VoltageID");
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModel.Text == @"[ADD NEW]")
            {
                txtCompressor.Text = @"[Enter Compressor Name]";
                txtCompressor.Enabled = true;
                cboRefrigerant.Enabled = true;
                cboRefrigerant.SelectedIndex = 0;
                cboVoltage.Enabled = true;
                cboVoltage.SelectedIndex = 0;
                cboManufacturer.Enabled = true;
                cboManufacturer.SelectedIndex = 0;
                cboType.Enabled = true;
                cboType.SelectedIndex = 0;
                numRLA.Value = 0m;
                numLRA.Value = 0m;
                chkTandemCompressor.Checked = false;
                FillPolynomialList(0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m);
            }
            else
            {
                string strCompressorModel = ComboBoxControl.IndexInformation(cboModel).Split('|')[0];
                string strRefrigerantID = ComboBoxControl.IndexInformation(cboModel).Split('|')[1];
                string strVoltageID = ComboBoxControl.IndexInformation(cboModel).Split('|')[2];
                LoadCompressorData(strCompressorModel, strRefrigerantID, strVoltageID);
                HighlightGridLine(strCompressorModel, strRefrigerantID, strVoltageID);
                txtCompressor.Enabled = false;
                txtCompressor.BackColor = Color.White;
                ComboBoxControl.SetIDDefaultValue(cboRefrigerant, strRefrigerantID);
                cboRefrigerant.Enabled = false;
                ComboBoxControl.SetIDDefaultValue(cboVoltage, strVoltageID);
                cboVoltage.Enabled = false;
            }
        }

        private void LoadCompressorData(string strCompressorModel, string refrigerantID, string voltageID)
        {
            DataRow dr = Public.SelectAndSortTable(_dtTable.Copy(), "Compressor = '" + strCompressorModel + "' AND RefrigerantID = " + refrigerantID + " AND VoltageID = " + voltageID, "").Rows[0];


            ComboBoxControl.SetIDDefaultValue(cboManufacturer, dr["Manufacturer"].ToString());
            ComboBoxControl.SetIDDefaultValue(cboType, dr["Type"].ToString());

            txtCompressor.Text = dr["Compressor"].ToString();
            numRLA.Value = Convert.ToDecimal(dr["RLA"]);
            numLRA.Value = Convert.ToDecimal(dr["LRA"]);
            chkTandemCompressor.Checked = (Convert.ToInt32(dr["SinglePhaseTandem"]) == 1);
            FillPolynomialList(Convert.ToDecimal(dr["Capacity1"])
                             , Convert.ToDecimal(dr["Capacity2"])
                             , Convert.ToDecimal(dr["Capacity3"])
                             , Convert.ToDecimal(dr["Capacity4"])
                             , Convert.ToDecimal(dr["Capacity5"])
                             , Convert.ToDecimal(dr["Capacity6"])
                             , Convert.ToDecimal(dr["Capacity7"])
                             , Convert.ToDecimal(dr["Capacity8"])
                             , Convert.ToDecimal(dr["Capacity9"])
                             , Convert.ToDecimal(dr["Capacity10"])
                             , Convert.ToDecimal(dr["Power1"])
                             , Convert.ToDecimal(dr["Power2"])
                             , Convert.ToDecimal(dr["Power3"])
                             , Convert.ToDecimal(dr["Power4"])
                             , Convert.ToDecimal(dr["Power5"])
                             , Convert.ToDecimal(dr["Power6"])
                             , Convert.ToDecimal(dr["Power7"])
                             , Convert.ToDecimal(dr["Power8"])
                             , Convert.ToDecimal(dr["Power9"])
                             , Convert.ToDecimal(dr["Power10"]));

        }

        private void HighlightGridLine(string strCompressorModel, string refrigerantID, string voltageID)
        {
            int index = 0;

            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                if (dgTable.Rows[i].Cells["Compressor"].Value.ToString() == strCompressorModel
                    && dgTable.Rows[i].Cells["RefrigerantID"].Value.ToString() == refrigerantID
                    && dgTable.Rows[i].Cells["VoltageID"].Value.ToString() == voltageID)
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
                    cboModel.FindString(dgTable.SelectedRows[0].Cells["Compressor"].Value + " - " +
                                        dgTable.SelectedRows[0].Cells["Refrigerant"].Value + " - " +
                                        dgTable.SelectedRows[0].Cells["VoltDescription"].Value);
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmCompressor dgTable_SelectionChanged");
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

            if (txtCompressor.Text.Trim() == "")
            {
                Public.LanguageBox("Please enter a compressor name", "Veuillez entrer le nom du compresseur");
                valid = false;
            }
            else if (txtCompressor.Text.Contains("\""))
            {
                Public.LanguageBox("\" is not a valid character.", "\" n'est pas un caractère valide.");
                valid = false;
            }

            bool goodPoly = true;
            //check for invalid poly numbers
            for (int i = 0; i < glPoly.Items.Count; i++)
            {
                decimal testingDecimal;
                if(!Decimal.TryParse(glPoly.Items[i].SubItems[1].Text, out testingDecimal))
                {
                    goodPoly = false;
                    break;
                }
            }

            if (!goodPoly)
            {
                valid = false;
                Public.LanguageBox("Invalid Polynomials entered. Make sure they are all valid numbers.", "Polynôme invalide entré. Veuillez vérifier que chaque chiffre entré est valide.");
            }
            return valid;
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtCompressor.Text = StringManipulation.FilterInvalidCharacters(txtCompressor.Text);
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
                    if (Query.Select("SELECT * FROM CompressorData WHERE Compressor = '" + txtCompressor.Text + "' AND RefrigerantID = " + ComboBoxControl.IndexInformation(cboRefrigerant) + " AND VoltageID = " + ComboBoxControl.IndexInformation(cboVoltage)).Rows.Count > 0)
                    {
                        Public.LanguageBox("Compressor model already exist for this refrigerant and voltage.", "Le nom du modèle de ce compresseur existe déja pour ce réfrigérant et voltage.");
                    }
                    else
                    {
                        if (Query.Execute("INSERT INTO CompressorData ([Compressor],[RefrigerantID],[VoltageID],[Manufacturer],[Type],[RLA],[LRA],[SinglePhaseTandem],[Capacity1],[Capacity2],[Capacity3],[Capacity4],[Capacity5],[Capacity6],[Capacity7],[Capacity8],[Capacity9],[Capacity10],[Power1],[Power2],[Power3],[Power4],[Power5],[Power6],[Power7],[Power8],[Power9],[Power10]) VALUES ('" + txtCompressor.Text + "'," + ComboBoxControl.IndexInformation(cboRefrigerant) + "," + ComboBoxControl.IndexInformation(cboVoltage) + ",'" + cboManufacturer.Text + "','" + cboType.Text + "'," + numRLA.Value + "," + numLRA.Value + "," + (chkTandemCompressor.Checked ? "1" : "0") + "," + GetPoly("C1") + "," + GetPoly("C2") + "," + GetPoly("C3") + "," + GetPoly("C4") + "," + GetPoly("C5") + "," + GetPoly("C6") + "," + GetPoly("C7") + "," + GetPoly("C8") + "," + GetPoly("C9") + "," + GetPoly("C10") + "," + GetPoly("P1") + "," + GetPoly("P2") + "," + GetPoly("P3") + "," + GetPoly("P4") + "," + GetPoly("P5") + "," + GetPoly("P6") + "," + GetPoly("P7") + "," + GetPoly("P8") + "," + GetPoly("P9") + "," + GetPoly("P10") + ")"))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    if (Query.Execute("UPDATE CompressorData SET Manufacturer = '" + cboManufacturer.Text + "', Type = '" + cboType.Text + "', RLA = " + numRLA.Value + ",LRA = " + numLRA.Value + ",SinglePhaseTandem = " + (chkTandemCompressor.Checked ? "1" : "0") + ",Capacity1 = " + GetPoly("C1") + ",Capacity2 = " + GetPoly("C2") + ",Capacity3 = " + GetPoly("C3") + ",Capacity4 = " + GetPoly("C4") + ",Capacity5 = " + GetPoly("C5") + ",Capacity6 = " + GetPoly("C6") + ",Capacity7 = " + GetPoly("C7") + ",Capacity8 = " + GetPoly("C8") + ",Capacity9 = " + GetPoly("C9") + ",Capacity10 = " + GetPoly("C10") + ",Power1 = " + GetPoly("P1") + ",Power2 = " + GetPoly("P2") + ",Power3 = " + GetPoly("P3") + ",Power4 = " + GetPoly("P4") + ",Power5 = " + GetPoly("P5") + ",Power6 = " + GetPoly("P6") + ",Power7 = " + GetPoly("P7") + ",Power8 = " + GetPoly("P8") + ",Power9 = " + GetPoly("P9") + ",Power10 = " + GetPoly("P10") + " WHERE Compressor = '" + txtCompressor.Text + "' AND RefrigerantID = " + ComboBoxControl.IndexInformation(cboRefrigerant) + " AND VoltageID = " + ComboBoxControl.IndexInformation(cboVoltage)))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                if (reload)
                {
                    Query.UpdateServerTableVersion("CompressorData");

                    FillTable();

                    FillCompressorModel();

                    FillTableView();
                }
            } 
        }

        private string GetPoly(string poly)
        {
            string strPoly = "";

            for (int i = 0; i < glPoly.Items.Count; i++)
            {
                if (glPoly.Items[i].SubItems[0].Text == poly)
                {
                    strPoly = glPoly.Items[i].SubItems[1].Text;
                }
            }

            return strPoly;
        }

        private void Validate_RLA_LRA()
        {
            txtRLA.Text = (chkTandemCompressor.Checked ? "2 x " : "") + numRLA.Value;
            txtLRA.Text = (chkTandemCompressor.Checked ? "2 x " : "") + numLRA.Value;
        }

        private void numRLA_ValueChanged(object sender, EventArgs e)
        {
            Validate_RLA_LRA();
        }

        private void numLRA_ValueChanged(object sender, EventArgs e)
        {
            Validate_RLA_LRA();
        }

        private void chkTandemCompressor_CheckedChanged(object sender, EventArgs e)
        {
            Validate_RLA_LRA();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmCompressor_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void cmdImportExport_Click(object sender, EventArgs e)
        {
            var frmImportExport = new FrmCompressorImportExport();
            frmImportExport.ShowDialog();

            FillTable();

            FillCompressorModel();

            FillTableView();
        }

        private void dgTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //var oneComp = new frmOneCompressor(dgTable.SelectedRows[0].Cells["Compressor"].Value, dgTable.SelectedRows[0].Cells["RefrigerantID"].Value, dgTable.SelectedRows[0].Cells["VoltageID"].Value);
            }
        }

    }
}