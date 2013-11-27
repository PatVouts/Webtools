using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.ControlPanel
{
    public partial class FrmControlPanelOptionManager : Form
    {

        private string _currentlySelectedOption = "";

        public FrmControlPanelOptionManager()
        {
            InitializeComponent();
        }

        private void frmControlPanelOptionManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillOptions();
        }

        private void FillOptions()
        {
            lvOptions.Items.Clear();

            DataTable dtOptions = Query.Select("SELECT * FROM ControlPanel_Options ORDER BY PanelOption");

            for (int i = 0; i < dtOptions.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvOptions);

                myItem.SubItems[0].Text = dtOptions.Rows[i]["PanelOption"].ToString();
                myItem.SubItems[1].Text = dtOptions.Rows[i]["Description"].ToString();
                myItem.SubItems[2].Text = dtOptions.Rows[i]["GroupID"].ToString();
                myItem.SubItems[3].Text = dtOptions.Rows[i]["UniqueSelection"].ToString();
                myItem.SubItems[4].Control = CmdOptionDelete(dtOptions.Rows[i]["PanelOption"].ToString());

                lvOptions.Items.Add(myItem);
            }

            lvOptions.Refresh();
        }

        private Button CmdOptionDelete(string option)
        {
            var cmd = new Button {Text = Public.LanguageString("Delete", "Supprimer"), Tag = option, Height = 25};
            cmd.Click += cmdOptionDelete_Click;
            return cmd;
        }

        private void cmdOptionDelete_Click(object sender, EventArgs e)
        {
            string option = ((Button)sender).Tag.ToString();
            DeleteOption(option);
        }

        private void DeleteOption(string option)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to delete this option ?", "Êtes-vous sûr de vouloir supprimer cette option ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Query.Execute("DELETE FROM ControlPanel_Options WHERE PanelOption = '" + option + "'");
                Query.Execute("DELETE FROM ControlPanel_PanelOptionPrices WHERE Options = '" + option + "'");
                Query.Execute("DELETE FROM ControlPanel_OptionsSelection WHERE PanelOption = '" + option + "'");

                Query.UpdateServerTableVersion("ControlPanel_Options");
                Query.UpdateServerTableVersion("ControlPanel_PanelOptionPrices");
                Query.UpdateServerTableVersion("ControlPanel_OptionsSelection");

                FillOptions();
                _currentlySelectedOption = "";
                FillOptionLogic();
            }
        }

        private void FillOptionLogic()
        {
            lvSelection.Items.Clear();

            if (_currentlySelectedOption != "")
            {
                DataTable dtOptions = Query.Select("SELECT * FROM ControlPanel_OptionsSelection WHERE PanelOption = '" + _currentlySelectedOption + "' ORDER BY PanelOption");

                for (int i = 0; i < dtOptions.Rows.Count; i++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvSelection);

                    myItem.SubItems[0].Text = dtOptions.Rows[i]["PanelOption"].ToString();
                    myItem.SubItems[1].Text = dtOptions.Rows[i]["CoolerType"].ToString();
                    myItem.SubItems[2].Text = dtOptions.Rows[i]["MinFanWide"].ToString();
                    myItem.SubItems[3].Text = dtOptions.Rows[i]["MaxFanWide"].ToString();
                    myItem.SubItems[4].Text = dtOptions.Rows[i]["MotorCoilArr"].ToString();
                    myItem.SubItems[5].Control = CmdOptionLogicDelete(dtOptions.Rows[i]);

                    lvSelection.Items.Add(myItem);
                }
            }
            lvSelection.Refresh();
        }

        private Button CmdOptionLogicDelete(DataRow dr)
        {
            var cmd = new Button {Text = Public.LanguageString("Delete", "Supprimer"), Tag = dr, Height = 25};
            cmd.Click += cmdOptionLogicDelete_Click;
            return cmd;
        }

        public void cmdOptionLogicDelete_Click(object sender, EventArgs e)
        {
            var dr = (DataRow)((Button)sender).Tag;
            DeleteOptionLogic(dr);
        }

        private void DeleteOptionLogic(DataRow dr)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to delete this option logic?", "Êtes-vous sûr de vouloir supprimer cette logique d'option ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Query.Execute("DELETE FROM ControlPanel_OptionsSelection WHERE PanelOption = '" + dr["PanelOption"] + "'  AND CoolerType = '" + dr["CoolerType"] + "'  AND MinFanWide = " + dr["MinFanWide"] + " AND MaxFanWide = " + dr["MaxFanWide"] + " AND MotorCoilArr = '" + dr["MotorCoilArr"] + "'");

                Query.UpdateServerTableVersion("ControlPanel_OptionsSelection");

                FillOptionLogic();
            }
        }

        private void lvOptions_Click(object sender, EventArgs e)
        {
            if (lvOptions.SelectedItems.Count > 0)
            {
                _currentlySelectedOption = ((GlacialComponents.Controls.GLItem)lvOptions.SelectedItems[0]).SubItems[0].Text;

                FillOptionLogic();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var add = new FrmAddEditOption();
            add.ShowDialog();

            FillOptions();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvOptions.SelectedItems.Count > 0)
            {
                var myItem = ((GlacialComponents.Controls.GLItem)lvOptions.SelectedItems[0]);
                var add = new FrmAddEditOption(myItem.SubItems[0].Text, myItem.SubItems[1].Text, Convert.ToInt32(myItem.SubItems[2].Text), Convert.ToInt32(myItem.SubItems[3].Text));
                add.ShowDialog();

                FillOptions();
            }
        }

        private void cmdAddLogic_Click(object sender, EventArgs e)
        {
            if (_currentlySelectedOption != "")
            {
                var addlogic = new FrmAddEditOptionLogic(_currentlySelectedOption);
                addlogic.ShowDialog();

                FillOptionLogic();
            }
        }

        private void cmdEditLogic_Click(object sender, EventArgs e)
        {
            if (lvSelection.SelectedItems.Count > 0)
            {
                var myItem = ((GlacialComponents.Controls.GLItem)lvSelection.SelectedItems[0]);

                var addlogic = new FrmAddEditOptionLogic(_currentlySelectedOption, myItem.SubItems[1].Text, Convert.ToDecimal(myItem.SubItems[2].Text), Convert.ToDecimal(myItem.SubItems[3].Text),  myItem.SubItems[4].Text);
                addlogic.ShowDialog();

                FillOptionLogic();
            }
        }
      
    }
}