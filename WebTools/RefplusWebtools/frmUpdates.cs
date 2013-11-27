using System;
using System.Data;
using System.Windows.Forms;
using Powerpoint = Microsoft.Office.Interop.PowerPoint;

namespace RefplusWebtools
{
    // ADDED BY Patrice V on 2013/5/1, to make a list of improvements and upgrades
    // to the database.
    public partial class FrmUpdates : Form
    {
        public FrmUpdates()
        {
            InitializeComponent();
            Public.RefreshMdiFormLanguage(this);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //on load, the datagrid in each tab goes to get the correct info from the 
        //updates table
        private void frmUpdates_Load(object sender, EventArgs e)
        {
            //Will save a part of the where clause to make sure salemen only see 
            //"Salemen only" fixes
            string salemen = UserInformation.Userlevel > 89 ? "" : " and [SalemenOnly?] = 0";
            //Starting with the bug fixes
            string sql = "Select Version, Description from dbo.Updates where type = 'Bug Fix' and Version > (Select Max(Version) - 10 as MaxVersion from dbo.Updates)  " + salemen + " Order by version";
            DataTable dtSQL = Query.Select(sql);          
            dgBugFix.DataSource = dtSQL;
            foreach (DataGridViewColumn col in dgBugFix.Columns)
            {
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, false);
            }
            //Then the improvements
            sql = "Select Version, Description from dbo.Updates where type = 'Improvement' and Version > (Select Max(Version) - 10 as MaxVersion from dbo.Updates) " + salemen + " Order by version";
            dtSQL = Query.Select(sql);          
            dgImprovements.DataSource = dtSQL;
            foreach (DataGridViewColumn col in dgImprovements.Columns)
            {
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, false);
            }

            


            //and the formationDocs.... formation contains extra FormationPath
            //as a column, to be able to go on the right document to open whenever
            //user presses "open formation document"
            sql = "Select Version, Description, FormationPath from dbo.Updates where type = 'Formation' and Version > (Select Max(Version) - 10 as MaxVersion from dbo.Updates) " + salemen + " Order by version";
            dtSQL = Query.Select(sql);          
            dgFormation.DataSource = dtSQL;
            foreach (DataGridViewColumn col in dgFormation.Columns)
            {
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, false);
            }


        }

        //When the user clicks, if there's any selected row, it'll open the document
        //for the associated "formation"
        private void btn_OpenDocument_Click(object sender, EventArgs e)
        {
            if (dgFormation.SelectedRows.Count > 0)
            {
                Powerpoint._Application ppApp = new Powerpoint.ApplicationClass();
                try
                {
                    // If we are in DEV, open locally (my PC). If not, open from
                    //Resources folder in C
                    if (Query.GetWebServiceUrl().Contains("DEV"))
                    {
                        ppApp.Presentations.Open("U:\\Patrice\\REFPLUS_WEBTOOLS\\RefplusWebtools\\Resources\\Formation\\" + dgFormation.SelectedRows[0].Cells[2].Value);
                    }
                    else
                    {
                        ppApp.Presentations.Open("C:\\Program Files (x86)\\Refplus Webtools\\Resources\\Formation\\" + dgFormation.SelectedRows[0].Cells[2].Value);
                    }
                }
                catch (Exception ex)
                {
                    Public.PushLog(ex.ToString(),"frmUpdate btn_OpenDocument");
                    MessageBox.Show(@"[Exception error: {0}]", ex.ToString());
                }
            }
            else
            {
                Public.LanguageBox("Please select a formation before clicking on this button", "Veuillez sélectionner une formation avant de cliquer sur ce bouton");
            }
            
        }

        private void dgBugFix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
