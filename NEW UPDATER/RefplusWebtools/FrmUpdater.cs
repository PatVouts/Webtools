using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace RefplusWebtoolsUpdater
{
    public partial class FrmUpdater : Form
    {
        private bool StandardClosing = true;

        public FrmUpdater()
        {
            InitializeComponent();
        }


        public void StartProcessing()
        {

            int clientVersionToNumber = 0;
            string clientVersion = "";
            string previousVersion = "";
            bool versionDone = false;
            int versionsDone = 0;
            int filesDone = 0;
            try
            {
                var dsLocalVersion = new DataSet();
                dsLocalVersion.ReadXml("Version.xml");
                clientVersion = dsLocalVersion.Tables[0].Rows[0][0].ToString();
                //client version contain the local client version.
                //if the server is higher than the client it will ask for update
                clientVersionToNumber = Convert.ToInt32(clientVersion.Replace(".", ""));
            }
            catch
            {
                MessageBox.Show("An error occured while checking version");
                Environment.Exit(0);
            }


            DataTable serverTable =
                Query.Select(
                    "SELECT MAX([Version Number]) AS V FROM [RefplusWebtools].[dbo].[UpdateTable] as tab INNER Join [RefplusWebtools].[dbo].[UpdateInfo] as info ON tab.[Version Number] = info.[VersionNumber] " +
                    (File.Exists("Sales.txt") ? "" : "where Released = 1 or DATEDIFF(day,info.Date,GETDATE()) > 0"));

            int serverVersion = (int) serverTable.Rows[0]["V"];


            DataTable filesToBeDownloaded = Query.Select(
                "SELECT MAX([Version Number]) as V, [FILE Name] FROM [RefplusWebtools].[dbo].[UpdateTable] where [Version Number] > " +
                clientVersionToNumber + " group by [File Name] order by V");

            previousVersion = filesToBeDownloaded.Rows[0]["V"].ToString();
            progressBar2.Minimum = 1;
            progressBar2.Maximum = filesToBeDownloaded.Rows.Count;
            foreach (DataRow fileName in filesToBeDownloaded.Rows)
            {
                labelUpdate.Text = (filesDone + @" / " + filesToBeDownloaded.Rows.Count);

                if (previousVersion != fileName["V"].ToString())
                {
                    versionDone = true;
                    previousVersion = fileName["V"].ToString();
                }
                Application.DoEvents();
                DownloadFile(fileName["File Name"].ToString());
                if (versionDone)
                {
                    versionDone = false;
                    versionsDone++;
                }
                filesDone++;
                progressBar2.Increment(filesDone == progressBar2.Maximum ? 0 : 1);
                Application.DoEvents();
            }
            KillProcess();
            Public.UpdateXMLversion(serverVersion.ToString());
            Close();

        }

    private void KillProcess()
    {
        // Store all running process in the system
        Process[] runingProcess = Process.GetProcesses();
        for (int i = 0; i < runingProcess.Length; i++)
        {
            // compare equivalent process by their name
            if (runingProcess[i].ProcessName == "RefplusWebtools")
            {
                // kill  running process
                runingProcess[i].Kill();
            }

        }
    
    }

    private void DownloadFile(string fileToDownload)
        {
            KillProcess();
            try
            {
                var client = new WebClient();
                WebRequest req = HttpWebRequest.Create("http://download.refplus.com/WebTools/" + fileToDownload);
                req.Method = "HEAD";
                int contentLength;
                long downloadedSize = 0;
                using (WebResponse resp = req.GetResponse())
                {
                    int.TryParse(resp.Headers.Get("Content-Length"), out contentLength);
                }
                contentLength /= 1024;
                string filePath;
                if (fileToDownload.Contains("Formation"))
                {
                    filePath = Directory.GetCurrentDirectory() + @"\Resources\Formation\" + fileToDownload.Substring(18, fileToDownload.Length - 22);
                }
                else if (fileToDownload.Contains("Resources"))
                {
                    filePath = Directory.GetCurrentDirectory() + @"Resources\" + fileToDownload.Substring(9, fileToDownload.Length - 13);
                }
                else
                {
                    filePath = fileToDownload.Substring(0, fileToDownload.Length - 4);
                }


                client.DownloadFileAsync(new Uri("http://download.refplus.com/WebTools/" + fileToDownload), filePath);
                
                progressBar1.Minimum = 0;
                progressBar1.Maximum = contentLength;
                do
                {
                    var file = new FileInfo(filePath);
                    downloadedSize = file.Length / 1024;
                    labelFile.Text = ((downloadedSize + " / " + contentLength));
                    if (downloadedSize > progressBar1.Maximum)
                    {
                        progressBar1.Value = progressBar1.Maximum;
                    }
                    else
                    {
                        progressBar1.Value = Convert.ToInt32(downloadedSize);
                    }
                    Application.DoEvents();
                } while (client.IsBusy);
                Application.DoEvents();
                client.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



    }
}
