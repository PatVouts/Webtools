using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmReportUpload : Form
    {

        private string _idOpened = "-1";
        public FrmReportUpload()
        {
            InitializeComponent();
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            DataTable reports = Query.Select("Select distinct(DescriptionEN) as description from REportsInfo where NOT DescriptionEn = 'FAKE'");
            cmbReports.Items.Add("(new)");
            if (reports.Rows.Count > 0)
            {
                foreach (DataRow row in reports.Rows)
                {
                    cmbReports.Items.Add(row["description"]);
                }
            }
        }


        private void cmdBrowseEN_Click_1(object sender, EventArgs e)
        {
            OpenDlg.Title = Public.LanguageString("Select a PDF file", "Sélectionnez un fichier PDF");
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                txtEnglishFile.Text = OpenDlg.FileName;
            }
        }

        private void cmdBrowseFR_Click_1(object sender, EventArgs e)
        {
            OpenDlg.Title = Public.LanguageString("Select a PDF file", "Sélectionnez un fichier PDF");
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                txtFrenchFile.Text = OpenDlg.FileName;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtEnglishFile.Text == "" || txtENDescription.Text == "" || txtFRDescription.Text == "" ||
                txtFrenchFile.Text == "")
            {
                Public.LanguageBox("You are missing a description or a file, please verify.","Il vous manque ou un fichier ou une description.  Veuillez vérifier");
            }
            else
            {
                ThreadProcess.Start(Public.LanguageString("Uploading", "Transfert"));
                if(_idOpened == "-1")
                {
                    DataTable result = Query.Select("Select Max(reportID) + 1 as M from ReportsInfo");
                    string id = result.Rows[0]["M"].ToString();
                    Query.Execute("Insert into ReportsInfo Values ('" + id + "', '" + ParseForFileNameOnly(txtFrenchFile.Text) + "', '" + txtFRDescription.Text + "','" + ParseForFileNameOnly(txtEnglishFile.Text) + "','" + txtENDescription.Text + "')");
                    _idOpened = id;
                }
                else
                {
                    Query.Execute("Update ReportsInfo set ReportFR = '" + ParseForFileNameOnly(txtFrenchFile.Text) +
                                  "', DescriptionFR = '" + txtFRDescription.Text + "', ReportEN = '" +
                                  ParseForFileNameOnly(txtEnglishFile.Text) + "', DescriptionEN = '" + txtENDescription.Text +
                                  "' where ReportID = " + _idOpened);

                }
                UploadReport(txtFrenchFile.Text);
                UploadReport(txtEnglishFile.Text);
                Public.LanguageBox("The reports have been uploaded to the server, now please assign which models you want these reports to link to.", "Les rapports ont été correctement transmis au serveur.  Veuillez maintenant assigner des modèles à ces rapports.");

                DataTable count  = Query.Select("Select * from ReportsAssociation where ReportID = " + _idOpened);

                ThreadProcess.Stop();
                Focus();
                if(count.Rows.Count == 0)
                {
                    //Will need to change for correct model selector
                    var ms = new FrmModelSelector(_idOpened , "Reports", false);
                    ms.ShowDialog();
                    
                }
                else
                {
                    var models = new List<string>();
                    foreach (DataRow row in count.Rows)
                    {
                        models.Add(row["model"].ToString());
                    }
                    var ml = new FrmModelList(_idOpened, "Reports", models, count.Rows[0]["Type"].ToString());
                    ml.ShowDialog();
                }
                Close();
            }
        }


        private void UploadReport(string fileNameWithPath)
        {
            byte[] bFile = FileManager.FiletoByteArray(fileNameWithPath);

            //connect to webservice
            var ws = new WebService.Service();

            string fileName = fileNameWithPath.Split('\\')[fileNameWithPath.Split('\\').Length - 1];

            ws.SendPublicity(bFile, fileName, Encryption.WebServiceEncryptKey());
        }


        private string ParseForFileNameOnly(string toCut)
        {
            for (int i = toCut.Length; i > 0 ; --i)
            {
                if (toCut[i-1] == '\\')
                {
                    return toCut.Substring(i);
                }
            }
            return "";
        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmReportUpload_Load_1(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbReports.Text == @"(new)")
            {
                txtFRDescription.Text = "";
                txtENDescription.Text = "";
            }
            else
            {
                DataTable report =
                    Query.Select("Select * from ReportsInfo where DescriptionEN = '" + cmbReports.SelectedItem + "'");

                _idOpened = report.Rows[0]["ReportID"].ToString();
                txtFRDescription.Text = report.Rows[0]["DescriptionFR"].ToString();
                txtENDescription.Text = report.Rows[0]["DescriptionEN"].ToString();
            
                Public.LanguageBox("If you want to update these reports, you need to re-select the reports.", "Pour mettre à jour ces rapports, vous devez re-sélectionner les rapports.");
            }
        }

        

        private void btnAddMachines_Click(object sender, EventArgs e)
        {
            DataTable report =
                  Query.Select("Select * from ReportsInfo where DescriptionEN = '" + cmbReports.SelectedItem + "'");

            _idOpened = report.Rows[0]["ReportID"].ToString();
            if (cmbReports.Text == @"(new)")
            {
                Public.LanguageBox("We can't add machines to a non-existing report.  Please select a report first",
                    "Il est impossible d'assigner des nouvelles machines à un rapport non existant.  Sélectionnez un rapport en premier s'il vous plaît.");
            }
            else
            {
                DataTable count = Query.Select("Select * from ReportsAssociation where ReportID = " + _idOpened);

                ThreadProcess.Stop();
                Focus();
                if (count.Rows.Count == 0)
                {
                    //Will need to change for correct model selector
                    var ms = new FrmModelSelector(_idOpened, "Reports", false);
                    ms.ShowDialog();

                }
                else
                {
                    var models = new List<string>();
                    foreach (DataRow row in count.Rows)
                    {
                        models.Add(row["model"].ToString());
                    }
                    var ml = new FrmModelList(_idOpened, "Reports", models, count.Rows[0]["Type"].ToString());
                    ml.ShowDialog();
                }
            }
        }
    }
}