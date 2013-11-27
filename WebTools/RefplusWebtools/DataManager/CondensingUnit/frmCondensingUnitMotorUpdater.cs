using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.CondensingUnit
{
    public partial class FrmCondensingUnitMotorUpdater : Form
    {
        private readonly string[] _strTableList = { "CondensingUnitCompressorManufacturer", "CondensingUnitCompressorType", "CondensingUnitRefrigerant", "CondensingUnitType", "Voltage", "CondensingUnitApplication", "CondensingUnitCompressorAmount", "CondensingUnitOptionFirstPart" };

        public FrmCondensingUnitMotorUpdater()
        {
            InitializeComponent();
        }

        private void frmCondensingUnitMotorUpdater_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            //this call all the fill combobox function needed
            Fill_Lists();
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

            Fill_OptionList();
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

            cboVoltage.SelectedIndex = 0;
        }

        private void cboVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_MotorModel();
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

        private void cmdFirstPartPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvFirstPart, true);
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

        private void cmdFirstPartUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvFirstPart, false);
        }

        private void cmdHPPickAll_Click(object sender, EventArgs e)
        {
            SetAllHP(true);
        }

        private void cmdHPUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllHP(false);
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

        private void cmdOptionsPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvOptions, true);
        }

        private void cmdOptionsUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvOptions, false);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to update the part to the applicable models ?", "Êtes-vous sûr de vouloir mettre à jour la piece aux modèles applicables?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool validSelection = true;

                //get list of model that need to be updated
                string whereClause = GetWhereClause(ref validSelection);

                if (validSelection)
                {
                    DataTable dtModelsToUpdate = Query.Select("SELECT * FROM CondensingUnitModel WHERE " + whereClause);

                    //now update all model
                    for (int i = 0; i < dtModelsToUpdate.Rows.Count; i++)
                    {
                        string tsql = "UPDATE CondensingUnitCoilLink SET MotorModel = '" + cboMotor.Text + "' WHERE Model = '" + dtModelsToUpdate.Rows[i]["Model"] + "'";
                        Query.Execute(tsql);
                    }

                    Query.UpdateServerTableVersion("CondensingUnitCoilLink");

                    Public.LanguageBox("Update completed", "Mise a jour completée");
                }
                else
                {
                    Public.LanguageBox("You must select at least 1 option in every section", "Vous devez sélectionner au moins 1 option dans chaque section.");
                }
            }
        }

        private string GetWhereClause(ref bool validSelection)
        {
            string firstPart = "";

            for (int i = 0; i < lvFirstPart.Items.Count; i++)
            {
                if (lvFirstPart.Items[i].SubItems[0].Checked)
                {
                    firstPart += "(UnitType = '" + lvFirstPart.Items[i].SubItems[1].Text + "' AND AirFlow = '" + lvFirstPart.Items[i].SubItems[2].Text + "' AND CompressorType = '" + lvFirstPart.Items[i].SubItems[3].Text + "') OR ";
                }
            }

            if (firstPart.Length > 0)
            {
                firstPart = firstPart.Substring(0, firstPart.Length - 3);
            }
            else
            {
                validSelection = false;
            }

            decimal minHP = numMinHP.Value;
            decimal maxHP = numMaxHP.Value;

            string hp = " (HP >= " + minHP + " AND HP <= " + maxHP + ") ";

            string compressor = "";

            for (int i = 0; i < lvCompressor.Items.Count; i++)
            {
                if (lvCompressor.Items[i].SubItems[0].Checked)
                {
                    compressor += "NumberOfCompressor = " + lvCompressor.Items[i].SubItems[1].Text + " OR ";
                }
            }

            if (compressor.Length > 0)
            {
                compressor = compressor.Substring(0, compressor.Length - 3);
            }
            else
            {
                validSelection = false;
            }

            string thirdPart = "";

            for (int i = 0; i < lvThirdPart.Items.Count; i++)
            {
                if (lvThirdPart.Items[i].SubItems[0].Checked)
                {
                    thirdPart += "(CompressorManufacturer = " + lvThirdPart.Items[i].SubItems[1].Text + " AND Application = '" + lvThirdPart.Items[i].SubItems[2].Text + "' AND RefrigerantID = " + lvThirdPart.Items[i].SubItems[3].Text + ") OR ";
                }
            }

            if (thirdPart.Length > 0)
            {
                thirdPart = thirdPart.Substring(0, thirdPart.Length - 3);
            }
            else
            {
                validSelection = false;
            }

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
                    strOptions += "Options Like '%" + s + "%' AND ";
                }
            }

            if (strOptions.Length > 0)
            {
                strOptions = strOptions.Substring(0, strOptions.Length - 4);
            }
            else
            {
                validSelection = false;
            }

            string strVoltage = " VoltageID = " + Voltage() + " ";

            return "(" + firstPart + ") AND (" + compressor + ") AND (" + hp + ") AND (" + thirdPart + ") AND (" + strOptions + ") AND (" + strVoltage + ")";
        }
       
    }
}