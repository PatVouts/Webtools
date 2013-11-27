using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.ControlPanel
{
    public partial class FrmAddEditOptionLogic : Form
    {
        private readonly string _strOption = "";
        private readonly string _strCoolerType = "";
        private readonly decimal _decMinFw;
        private readonly decimal _decMaxFw;
        private readonly string _strSeries = "";
        private readonly bool _editMode;

        public FrmAddEditOptionLogic(string option, string coolerType, decimal minFw, decimal maxFw, string series)
        {
            InitializeComponent();
            _strOption = option;
            _strCoolerType = coolerType;
            _decMinFw = minFw;
            _decMaxFw = maxFw;
            _strSeries = series;
            _editMode = true;
        }

        public FrmAddEditOptionLogic(string option)
        {
            InitializeComponent();
            _strOption = option;
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

        private void frmAddEditOptionLogic_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillCoolerType();

            txtOption.Text = _strOption;
            if (_editMode)
            {
                ComboBoxControl.SetIDDefaultValue(cboCoolerType, _strCoolerType);
                numMinFanWide.Value = _decMinFw;
                numMaxFanWide.Value = _decMaxFw;
                CheckSeries(_strSeries);
            } 
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSeriePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSeries, true);
        }

        private void cmdSerieUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSeries, false);
        }

        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

          private void FillCoolerType()
        {
            ComboBoxControl.AddItem(cboCoolerType, "COND", "Condenser");
            ComboBoxControl.AddItem(cboCoolerType, "FC", "Fluid Cooler");

            cboCoolerType.SelectedIndex = 0;
        }

        private void cboCoolerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSeries();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save", "Êtes-vous sûr de vouloir sauvegarder", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_editMode)
                {
                    Query.Execute("UPDATE ControlPanel_OptionsSelection SET PanelOption = '" + txtOption.Text + "' , CoolerType = '" + ComboBoxControl.IndexInformation(cboCoolerType) + "' , MinFanWide = " + numMinFanWide.Value + ", MaxFanWide = " + numMaxFanWide.Value + ", MotorCoilArr = '" + GetSelectedSeries() + "' WHERE PanelOption = '" + _strOption + "' AND CoolerType = '" + _strCoolerType + "' AND MinFanWide = " + _decMinFw + " AND MaxFanWide = " + _decMaxFw + " AND  MotorCoilArr = '" + _strSeries + "'");

                    Query.UpdateServerTableVersion("ControlPanel_OptionsSelection");

                    Public.LanguageBox("Update successful", "Mise à jour réussie");
                }
                else
                {
                    DataTable dtOption = Query.Select("SELECT * FROM ControlPanel_OptionsSelection WHERE PanelOption = '" + txtOption.Text + "'  AND CoolerType = '" + ComboBoxControl.IndexInformation(cboCoolerType) + "'  AND MinFanWide = " + numMinFanWide.Value + " AND MaxFanWide = " + numMaxFanWide.Value + " AND MotorCoilArr = '" + GetSelectedSeries() + "'");

                    if (dtOption.Rows.Count == 0)
                    {
                        Query.Execute("INSERT INTO ControlPanel_OptionsSelection (PanelOption, CoolerType, MinFanWide, MaxFanWide, MotorCoilArr) VALUES ('" + txtOption.Text + "' , '" + ComboBoxControl.IndexInformation(cboCoolerType) + "' , " + numMinFanWide.Value + ", " + numMaxFanWide.Value + ", '" + GetSelectedSeries() + "')");

                        Query.UpdateServerTableVersion("ControlPanel_OptionsSelection");

                        Public.LanguageBox("Saving successful", "Sauvegarde réussie");
                    }
                    else
                    {
                        Public.LanguageBox("This option logic already exist", "Cette logique d'option existe déja");
                    }
                }
                Close();
            }
        }

    }
}