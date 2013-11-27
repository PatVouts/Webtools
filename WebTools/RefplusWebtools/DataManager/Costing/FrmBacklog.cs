using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Costing
{
    public partial class FrmBacklog : Form
    {
        public FrmBacklog()
        {
            InitializeComponent();
        }

        private void FrmBacklog_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);
            Public.ChangeColor(this);
            btnNormal.Checked = true;

            LoadUnits();
        }

        private void btnNormal_CheckedChanged(object sender, EventArgs e)
        {
            LoadUnits();
            btnrebalance.Visible = !btnNormal.Checked;
        }

        private void LoadUnits()
        {
            lvUnits.Items.Clear();
            string sql = "Select * from machineUpdateBacklog where show = 1 ";
            if (btnUnbalanced.Checked)
            {
                sql += " and rebalanced = 0";
            }
            DataTable unitsToShow = Query.Select(sql);
            foreach (DataRow unit in unitsToShow.Rows)
            {
                var myItem = new ListViewItem(unit["machineName"].ToString());
                myItem.SubItems.Add(unit["moduleName"].ToString());
                myItem.SubItems.Add(unit["date"].ToString());
                myItem.SubItems.Add(unit["modifier"].ToString());
                myItem.SubItems.Add((unit["rebalanced"].ToString() == "True"? "Yes" : "No"));
                lvUnits.Items.Add(myItem);
            }
        }

        private void btnrebalance_Click(object sender, EventArgs e)
        {
            ThreadProcess.Start("Updating machines");
            int i = 1;
            var stopWatch = new Stopwatch();
            foreach (ListViewItem itm in lvUnits.SelectedItems)
            {

                stopWatch.Start();
                DataTable machineInfo =
                    Query.Select("Select machineID from machine where machineName = '" + itm.SubItems["machine"].Text +
                                 "'");
                if(machineInfo.Rows.Count > 0)
                {
                    Public.ForceUpdateOnMachine(Convert.ToInt32(machineInfo.Rows[0]["machineID"].ToString()));
                }

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                int secondsForOne = 0;
                if (secondsForOne == 0)
                {
                    secondsForOne = ts.Seconds;
                }
                ThreadProcess.UpdateMessage("Time left : " + secondsForOne * (lvUnits.SelectedItems.Count-i) + " seconds");
                ++i;
            }
            ThreadProcess.Stop();
        }
    }
}
