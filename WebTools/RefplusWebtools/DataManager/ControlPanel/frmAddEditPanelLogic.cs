using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.ControlPanel
{
    public partial class FrmAddEditPanelLogic : Form
    {
        private readonly string _strPanel = "";
        private readonly string _strCoolerType = "";
        private readonly decimal _decMinFw;
        private readonly decimal _decMaxFw;
        private readonly decimal _decMinCirc;
        private readonly decimal _decMaxCirc;
        private readonly string _strEqualCap = "";
        private readonly string _strVoltages = "";
        private readonly string _strSeries = "";
        private readonly bool _editMode;

        public FrmAddEditPanelLogic(string panel, string coolerType,decimal minFw, decimal maxFw, decimal minCirc, decimal maxCirc, string equalCap, string voltages, string series)
        {
            InitializeComponent();
            _strPanel = panel;
            _strCoolerType = coolerType;
            _decMinFw = minFw;
            _decMaxFw = maxFw;
            _decMinCirc = minCirc;
            _decMaxCirc = maxCirc;
            _strEqualCap = equalCap;
            _strVoltages = voltages;
            _strSeries = series;
            _editMode = true;
        }

        public FrmAddEditPanelLogic(string panel)
        {
            InitializeComponent();
            _strPanel = panel;
        }

        private void frmAddEditPanelLogic_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillCoolerType();
            FillEqualCapacity();
            FillPanelVoltage();

            txtPanel.Text = _strPanel;

            if (_editMode)
            {
                ComboBoxControl.SetIDDefaultValue(cboCoolerType, _strCoolerType);
                numMinFanWide.Value = _decMinFw;
                numMaxFanWide.Value = _decMaxFw;
                numMinCircuit.Value = _decMinCirc;
                numMaxCircuit.Value = _decMaxCirc;
                ComboBoxControl.SetIDDefaultValue(cboEqualCapacity, _strEqualCap);
                CheckVoltages(_strVoltages);
                CheckSeries(_strSeries);
            } 
        }

        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

        private void CheckVoltages(string voltageToCheck)
        {
            //comma separated field
            string[] voltageList = voltageToCheck.Split(',');

            foreach (string voltage in voltageList)
            {
                CheckSpecificVoltage(voltage);
            }
        }

        private void CheckSpecificVoltage(string strVoltage)
        {
            for (int i = 0; i < lvPanelVoltage.Items.Count; i++)
            {
                if (lvPanelVoltage.Items[i].SubItems[2].Text == strVoltage)
                {
                    lvPanelVoltage.Items[i].SubItems[0].Checked = true;
                    i = lvPanelVoltage.Items.Count;
                }
            }
        }

        private void CheckSeries(string seriesToCheck)
        {
            //comma separated field
            string[] serieList = seriesToCheck.Split(',');

            foreach (string serie in serieList)
            {
                CheckSpecificSerie(serie);
            }
        }

        private void CheckSpecificSerie(string strSerie)
        {
            for (int i = 0; i < lvSeries.Items.Count; i++)
            {
                if (lvSeries.Items[i].SubItems[2].Text == strSerie)
                {
                    lvSeries.Items[i].SubItems[0].Checked = true;
                    i = lvSeries.Items.Count;
                }
            }
        }

        private void FillCoolerType()
        {
            ComboBoxControl.AddItem(cboCoolerType, "COND", "Condenser");
            ComboBoxControl.AddItem(cboCoolerType, "FC", "Fluid Cooler");

            cboCoolerType.SelectedIndex = 0;
        }

        private void FillSeries()
        {
            if (ComboBoxControl.IndexInformation(cboCoolerType) == "FC")
            {
                FillFluidCoolerSeries();
            }
            else if (ComboBoxControl.IndexInformation(cboCoolerType) == "COND")
            {
                FillCondenserSeries();
            }
        }

        private void FillCondenserSeries()
        {
            lvSeries.Items.Clear();

            DataTable dtCondenserSeries = Query.Select("SELECT * FROM CondenserSerie WHERE Sites like '%" + UserInformation.CurrentSite + "%' AND Active = 1 ORDER BY Description");

            foreach (DataRow drCondenserSerie in dtCondenserSeries.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvSeries);

                myItem.SubItems[1].Text = drCondenserSerie["Description"].ToString();
                myItem.SubItems[2].Text = drCondenserSerie["Motor"] + drCondenserSerie["CoilArr"].ToString();

                lvSeries.Items.Add(myItem);
            }

            lvSeries.Refresh();
        }

        private void FillPanelVoltage()
        {
            lvPanelVoltage.Items.Clear();

            DataTable dtPanelVoltage = Query.Select("SELECT * FROM ControlPanel_PanelVoltage ORDER BY Voltage");

            foreach (DataRow drCondenserSerie in dtPanelVoltage.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvPanelVoltage);

                myItem.SubItems[1].Text = drCondenserSerie["Voltage"].ToString();
                myItem.SubItems[2].Text = drCondenserSerie["VoltageParameter"].ToString();

                lvPanelVoltage.Items.Add(myItem);
            }

            lvPanelVoltage.Refresh();
        }


        private void FillFluidCoolerSeries()
        {
            lvSeries.Items.Clear();

            DataTable dtFluidCoolerSeries = Query.Select("SELECT * FROM CoilInfo WHERE Active = 1 ORDER BY Description");

            foreach (DataRow drFluidCoolerSerie in dtFluidCoolerSeries.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvSeries);

                myItem.SubItems[1].Text = drFluidCoolerSerie["Description"].ToString();
                myItem.SubItems[2].Text = drFluidCoolerSerie["Motor"] + drFluidCoolerSerie["CoilArr"].ToString();

                lvSeries.Items.Add(myItem);
            }

            lvSeries.Refresh();
        }

        private void FillEqualCapacity()
        {
            ComboBoxControl.AddItem(cboEqualCapacity, "1", "Yes");
            ComboBoxControl.AddItem(cboEqualCapacity, "0", "No");

            cboEqualCapacity.SelectedIndex = 0;
        }

        private void cboCoolerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSeries();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string GetSelectedSeries()
        {
            string strSelectedSeries = "";

            for (int i = 0; i < lvSeries.Items.Count; i++)
            {
                if (lvSeries.Items[i].SubItems[0].Checked)
                {
                    strSelectedSeries += lvSeries.Items[i].SubItems[2].Text + ",";
                }
            }

            return strSelectedSeries;
        }

        private string GetSelectedVoltages()
        {
            string strSelectedVoltages = "";

            for (int i = 0; i < lvPanelVoltage.Items.Count; i++)
            {
                if (lvPanelVoltage.Items[i].SubItems[0].Checked)
                {
                    strSelectedVoltages += lvPanelVoltage.Items[i].SubItems[2].Text + ",";
                }
            }

            return strSelectedVoltages;
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save", "Êtes-vous sûr de vouloir sauvegarder", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_editMode)
                {
                    Query.Execute("UPDATE ControlPanel_PanelsSelection SET Panel = '" + txtPanel.Text + "' , CoolerType = '" + ComboBoxControl.IndexInformation(cboCoolerType) + "' , MinFanWide = " + numMinFanWide.Value + ", MaxFanWide = " + numMaxFanWide.Value + ", MinCircuits = " + numMinCircuit.Value + ", MaxCircuits = " + numMaxCircuit.Value + ", EqualCapacity = " + ComboBoxControl.IndexInformation(cboEqualCapacity) + ", Voltages = '" + GetSelectedVoltages()+ "' , MotorCoilArr = '" + GetSelectedSeries() + "' WHERE Panel = '" + _strPanel + "' AND CoolerType = '" + _strCoolerType + "' AND MinFanWide = " + _decMinFw + " AND MaxFanWide = " + _decMaxFw + " AND MinCircuits = " + _decMinCirc + " AND MaxCircuits = " + _decMaxCirc + " AND EqualCapacity = " + _strEqualCap + " AND Voltages = '" + _strVoltages + "' AND MotorCoilArr = '" + _strSeries + "'");
                    
                    Query.UpdateServerTableVersion("ControlPanel_PanelsSelection");

                    Public.LanguageBox("Update successful", "Mise à jour réussie");
                }
                else
                {
                    DataTable dtPanel = Query.Select("SELECT * FROM ControlPanel_PanelsSelection WHERE Panel = '" + txtPanel.Text + "'  AND CoolerType = '" + ComboBoxControl.IndexInformation(cboCoolerType) + "'  AND MinFanWide = " + numMinFanWide.Value + " AND MaxFanWide = " + numMaxFanWide.Value + " AND MinCircuits = " + numMinCircuit.Value + " AND MaxCircuits = " + numMaxCircuit.Value + " AND EqualCapacity = " + ComboBoxControl.IndexInformation(cboEqualCapacity) + " AND Voltages = '" + GetSelectedVoltages() + "' AND MotorCoilArr = '" + GetSelectedSeries() + "'");

                    if (dtPanel.Rows.Count == 0)
                    {
                        Query.Execute("INSERT INTO ControlPanel_PanelsSelection (Panel, CoolerType, MinFanWide, MaxFanWide, MinCircuits, MaxCircuits, EqualCapacity, Voltages, MotorCoilArr) VALUES ('" + txtPanel.Text + "' , '" + ComboBoxControl.IndexInformation(cboCoolerType) + "' , " + numMinFanWide.Value + ", " + numMaxFanWide.Value + ", " + numMinCircuit.Value + ", " + numMaxCircuit.Value + ", " + ComboBoxControl.IndexInformation(cboEqualCapacity) + ", '" + GetSelectedVoltages() + "', '" + GetSelectedSeries() + "')");

                        Query.UpdateServerTableVersion("ControlPanel_PanelsSelection");

                        Public.LanguageBox("Saving successful", "Sauvegarde réussie");
                    }
                    else
                    {
                        Public.LanguageBox("This panel logic already exist", "Cette logique de panneau existe déja");
                    }
                }
                Close();
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cmdSeriePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSeries, true);
        }

        private void cmdSerieUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSeries, false);
        }

        private void cmdVoltagePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvPanelVoltage, true);
        }

        private void cmdVoltageUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvPanelVoltage, false);
        }

    }
}