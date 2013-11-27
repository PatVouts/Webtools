using System;
using System.Data;
using System.Windows.Forms;
using Powerpoint = Microsoft.Office.Interop.PowerPoint;

namespace RefplusWebtools
{
    public partial class FrmLeadTime : Form
    {
        public FrmLeadTime()
        {
            InitializeComponent();
            Public.RefreshMdiFormLanguage(this);
        }

        //on load, the datagrid in each tab goes to get the correct info from the 
        //updates table
        private void frmUpdates_Load(object sender, EventArgs e)
        {
            UpdateNames(sender,e);

        }

        private void UpdateNames(object sender, EventArgs e)
        {
            lblDate.Text = GetWeekRange();
            DataTable leads = Query.Select("Select * from LeadTimes");
            foreach (DataRow row in leads.Rows)
            {
                switch (row["Description"].ToString())
                {
                    case "EVAP 1":
                        textBox1.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 2":
                        textBox2.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 3":
                        textBox3.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 4":
                        textBox4.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 5":
                        textBox5.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 6":
                        textBox6.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 7":
                        textBox7.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 8":
                        textBox8.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 9":
                        textBox9.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "EVAP 10":
                        textBox10.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COND 1":
                        textBox11.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COND 2":
                        textBox12.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 1":
                        textBox13.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 2":
                        textBox14.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 3":
                        textBox15.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 4":
                        textBox16.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 5":
                        textBox17.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 6":
                        textBox30.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 7":
                        label41.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "COILS 8":
                        label43.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "PACK 1":
                        textBox18.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "PACK 2":
                        textBox19.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "CU 1":
                        textBox20.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "CU 2":
                        textBox21.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "CU 3":
                        textBox22.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "CU 4":
                        textBox23.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "CU 5":
                        textBox24.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "CU 6":
                        textBox29.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "CS 1":
                        textBox25.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem");
                        break;
                    case "BLY":
                        textBox27.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem").Replace("add", Public.Language == "EN" ? "add" : "+ ");
                        break;
                    case "HERE":
                        textBox28.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem").Replace("add", Public.Language == "EN" ? "add" : "+ ");
                        break;
                    case "ELECTRO":
                        textBox26.Text = row["LeadTime"].ToString().Replace("wk", Public.Language == "EN" ? "week(s)" : "sem").Replace("add", Public.Language == "EN" ? "add" : "+ ");
                        break;

                }

            }
            leads.Dispose();
        }
        private string GetWeekRange()
        {
            DateTime d = DateTime.Today;

            int offset = d.DayOfWeek - DayOfWeek.Monday;

            DateTime lastMonday = d.AddDays(-offset);
            DateTime nextSunday = lastMonday.AddDays(4);
            return lastMonday.ToShortDateString() + "  -  " + nextSunday.ToShortDateString();
        }
    }
}
