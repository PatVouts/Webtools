using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RefplusWebtools.Report
{
    public partial class FrmExtraReports : Form
    {
        private readonly string _model;
        public FrmExtraReports(string model)
        {
            InitializeComponent();
            _model = model;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            int count = 0;
            //If the row is "checked",  count ++
            foreach (DataGridViewRow row in FilesView.Rows)
            {
                if (Convert.ToBoolean(row.Cells["ToPrint"].Value))
                {
                    ++count;
                }
            }

            //Makes sure there is at least one checked report before merging them
            if (count == 0)
            {
                Public.LanguageBox("To generate a report, you need to at least one report selected.", "Pour pouvoir générer un rapport, vous devez en avoir au moins un de séléctionné.");
            }
            //if count = 1, there's only one report to open, no merging necessary
            else
            {
                var files = new List<byte[]>();
                var pdf = new PDFMerge();
                foreach (DataGridViewRow row in FilesView.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ToPrint"].Value))
                    {
                        var ws = new WebService.Service();

                        byte[] bReport = ws.GetPublicity(row.Cells["FileName"].Value.ToString(), Encryption.WebServiceEncryptKey());
                        files.Add(bReport);
                    }
                }
                
                string strMergeReportLocation = Public.GenerateFileNameAndPath("QuoteReport", "pdf");
                File.WriteAllBytes(strMergeReportLocation, pdf.MergeFiles(files));

                //open up the file
                System.Diagnostics.Process.Start(strMergeReportLocation);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmExtraReports_Load_1(object sender, EventArgs e)
        {
            DataTable reports = Query.Select("Select Report" + ((Public.Language == "FR") ? "FR" : "EN") + " as ReportName, Description" + ((Public.Language == "FR") ? "FR" : "EN") + " as description from ReportsInfo as RI INNER JOIN ReportsAssociation as RA on RI.ReportID = RA.ReportID where  RA.Model = '" + _model + "'");
            foreach (DataRow row in reports.Rows)
            {
                FilesView.Rows.Add(false, row["ReportName"], row["description"]);
            }
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
        }


    }

}
