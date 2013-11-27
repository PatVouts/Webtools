using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.ControlPanel
{
    public partial class FrmControlPanelPanelManager : Form
    {
        private string _currentlySelectedPanel = "";

        public FrmControlPanelPanelManager()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var add = new FrmAddEditPanel();
            add.ShowDialog();

            FillPanels();
        }

        private void cmdAddLogic_Click(object sender, EventArgs e)
        {
            if (_currentlySelectedPanel != "")
            {
                var addlogic = new FrmAddEditPanelLogic(_currentlySelectedPanel);
                addlogic.ShowDialog();

                FillPanelLogic();
            }
        }

        private void frmControlPanelPanelManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillPanels();
        }

        private void FillPanels()
        {
            lvPanels.Items.Clear();

            DataTable dtPanels = Query.Select("SELECT * FROM ControlPanel_Panels ORDER BY Panel");

            for (int i = 0; i < dtPanels.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvPanels);

                myItem.SubItems[0].Text = dtPanels.Rows[i]["Panel"].ToString();
                myItem.SubItems[1].Text = dtPanels.Rows[i]["Description"].ToString();
                myItem.SubItems[2].Control = CmdPanelDelete(dtPanels.Rows[i]["Panel"].ToString());

                lvPanels.Items.Add(myItem);
            }

            lvPanels.Refresh();
        }

        private Button CmdPanelLogicDelete(DataRow dr)
        {
            var cmd = new Button {Text = Public.LanguageString("Delete", "Supprimer"), Tag = dr, Height = 25};
            cmd.Click += cmdPanelLogicDelete_Click;
            return cmd;
        }

        public void cmdPanelLogicDelete_Click(object sender, EventArgs e)
        {
            var dr = (DataRow)((Button)sender).Tag;
            DeletePanelLogic(dr);
        }

        private Button CmdPanelDelete(string panel)
        {
            var cmd = new Button {Text = Public.LanguageString("Delete", "Supprimer"), Tag = panel, Height = 25};
            cmd.Click += cmdPanelDelete_Click;
            return cmd;
        }

        private void cmdPanelDelete_Click(object sender, EventArgs e)
        {
            string panel = ((Button)sender).Tag.ToString();
            DeletePanel(panel);
        }

        private void DeletePanel(string panel)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to delete this panel ?", "Êtes-vous sûr de vouloir supprimer ce panneau ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Query.Execute("DELETE FROM ControlPanel_Panels WHERE Panel = '" + panel + "'");
                Query.Execute("DELETE FROM ControlPanel_PanelPrices WHERE Panel = '" + panel + "'");
                Query.Execute("DELETE FROM ControlPanel_PanelOptionPrices WHERE Panel = '" + panel + "'");
                Query.Execute("DELETE FROM ControlPanel_PanelsSelection WHERE Panel = '" + panel + "'");
                Query.Execute("DELETE FROM ControlPanel_SpecialPrice WHERE Panel = '" + panel + "'");

                Query.UpdateServerTableVersion("ControlPanel_Panels");
                Query.UpdateServerTableVersion("ControlPanel_PanelPrices");
                Query.UpdateServerTableVersion("ControlPanel_PanelOptionPrices");
                Query.UpdateServerTableVersion("ControlPanel_PanelsSelection");
                Query.UpdateServerTableVersion("ControlPanel_SpecialPrice");

                FillPanels();
                _currentlySelectedPanel = "";
                FillPanelLogic();
            }
        }

        private void DeletePanelLogic(DataRow dr)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to delete this panel logic?", "Êtes-vous sûr de vouloir supprimer cette logique de panneau ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Query.Execute("DELETE FROM ControlPanel_PanelsSelection WHERE Panel = '" + dr["Panel"] + "'  AND CoolerType = '" + dr["CoolerType"] + "'  AND MinFanWide = " + dr["MinFanWide"] + " AND MaxFanWide = " + dr["MaxFanWide"] + " AND MinCircuits = " + dr["MinCircuits"] + " AND MaxCircuits = " + dr["MaxCircuits"] + " AND EqualCapacity = " + dr["EqualCapacity"] + " AND MotorCoilArr = '" + dr["MotorCoilArr"] + "'");

                Query.UpdateServerTableVersion("ControlPanel_PanelsSelection");

                FillPanelLogic();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvPanels.SelectedItems.Count > 0)
            {
                var myItem = ((GlacialComponents.Controls.GLItem)lvPanels.SelectedItems[0]);
                var add = new FrmAddEditPanel(myItem.SubItems[0].Text, myItem.SubItems[1].Text);
                add.ShowDialog();

                FillPanels();
            }
        }

        private void FillPanelLogic()
        {
            lvSelection.Items.Clear();
            if (_currentlySelectedPanel != "")
            {
                DataTable dtPanels = Query.Select("SELECT * FROM ControlPanel_PanelsSelection WHERE Panel = '" + _currentlySelectedPanel + "' ORDER BY Panel");

                for (int i = 0; i < dtPanels.Rows.Count; i++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvSelection);

                    myItem.SubItems[0].Text = dtPanels.Rows[i]["Panel"].ToString();
                    myItem.SubItems[1].Text = dtPanels.Rows[i]["CoolerType"].ToString();
                    myItem.SubItems[2].Text = dtPanels.Rows[i]["MinFanWide"].ToString();
                    myItem.SubItems[3].Text = dtPanels.Rows[i]["MaxFanWide"].ToString();
                    myItem.SubItems[4].Text = dtPanels.Rows[i]["MinCircuits"].ToString();
                    myItem.SubItems[5].Text = dtPanels.Rows[i]["MaxCircuits"].ToString();
                    myItem.SubItems[6].Text = dtPanels.Rows[i]["EqualCapacity"].ToString();
                    myItem.SubItems[7].Text = dtPanels.Rows[i]["Voltages"].ToString();
                    myItem.SubItems[8].Text = dtPanels.Rows[i]["MotorCoilArr"].ToString();
                    myItem.SubItems[9].Control = CmdPanelLogicDelete(dtPanels.Rows[i]);

                    lvSelection.Items.Add(myItem);
                }
            }
            lvSelection.Refresh();
        }

        private void lvPanels_Click(object sender, EventArgs e)
        {
            if (lvPanels.SelectedItems.Count > 0)
            {
                _currentlySelectedPanel = ((GlacialComponents.Controls.GLItem)lvPanels.SelectedItems[0]).SubItems[0].Text;

                FillPanelLogic();
            }
        }

        private void cmdEditLogic_Click(object sender, EventArgs e)
        {
            if (lvSelection.SelectedItems.Count > 0)
            {
                var myItem = ((GlacialComponents.Controls.GLItem)lvSelection.SelectedItems[0]);

                var addlogic = new FrmAddEditPanelLogic(_currentlySelectedPanel, myItem.SubItems[1].Text, Convert.ToDecimal(myItem.SubItems[2].Text), Convert.ToDecimal(myItem.SubItems[3].Text), Convert.ToDecimal(myItem.SubItems[4].Text), Convert.ToDecimal(myItem.SubItems[5].Text), myItem.SubItems[6].Text, myItem.SubItems[7].Text, myItem.SubItems[8].Text);
                addlogic.ShowDialog();

                FillPanelLogic();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}