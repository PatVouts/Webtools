using System;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using File = System.IO.File;

namespace RefplusWebtoolsInstaller
{
    public partial class FrmInstaller : Form
    {
        private string _directory;
        private readonly string[] filesToBeDownloaded = new[] {"ChillWaterCoil.dll.zip","Compressors.dll.zip","CondenserCoil.dll.zip","CR2008.bat.zip","CRRuntime_12_2_mlb.msi.zip",
        "DLLCoilReport.dll.zip","DLLCoilReport.pdb.zip","DLLCondenserReport.dll.zip","DLLCondenserReport.pdb.zip","DLLCondensingUnit.dll.zip", "DLLCondensingUnit.pdb.zip","DLLCustomUnit.dll.zip","DLLEvaporatorReport.dll.zip",
        "DLLFluidCoolerReport.dll.zip","DLLGravityCoilReport.dll.zip","DLLHeatPipeReport.dll.zip","DLLOEMCoil.dll.zip","DLLPricingReports.dll.zip","DLLPricingReports.pdb.zip","DLLWaterEvaporatorReport.dll.zip","dummy.txt.zip",
        "DXCoil.dll.zip","GCcoil.dll.zip","GlacialList.dll.zip","HotWaterCoil.dll.zip","ICSharpCode.SharpZipLib.dll.zip","install.txt.zip","Interop.kFRefplus.dll.zip","Interop.Pipes.dll.zip",
        "itextsharp.dll.zip","kFRefplus.dll.zip","pipes.dll.zip","Psylib32.dll.zip","Rdll.bat.zip","RefplusWebtools.exe.config.zip","RefplusWebtools.exe.zip","RefplusWebtools.ico.zip",
        "RefplusWebtoolsUpdater.exe.config.zip","RefplusWebtoolsUpdater.exe.zip","Start.bat.zip","SteamCoil.dll.zip","Version.xml.zip","WebServiceConfig.xml.zip","ResourcesFormationOptionKits.pptx.zip"};

        public FrmInstaller()
        {
            InitializeComponent();
        }

        public void CreateShortcut()
        {
            string[] lines = {"set oShellLink = CreateObject(\"WScript.Shell\").CreateShortcut(CreateObject(\"WScript.Shell\").SpecialFolders(\"Desktop\") & + \"\\\" + \"RefplusWebtools.lnk\")",   
                              "oShellLink.Description = \"Webtools Shortcut\"",
                              "oShellLink.TargetPath = \"" + _directory + "\\RefplusWebtools.exe\"",
                              "oShellLink.WorkingDirectory = \"" + _directory +"\"",
                              "oShellLink.Save"
                       };
            File.WriteAllLines("test.vbs", lines);
            Process P = Process.Start("test.vbs");
            P.WaitForExit(int.MaxValue);
            File.Delete("test.vbs");
        }

        public void StartProcessing()
        {
            bool cont = true;
            ShowInTaskbar = true;
            Opacity = 1d;


            
            //Create folder 
            bool alreadyInstalled = false;
            Opacity = 1d;
            ShowInTaskbar = true;
           
            if (Directory.Exists(@"C:\Program Files (x86)"))
            {
                _directory = @"C:\Program Files (x86)\Refplus Webtools";
                if (Directory.Exists(@"C:\Program Files (x86)\Refplus Webtools"))
                {
                    alreadyInstalled = true;
                }
                else
                {
                    Directory.CreateDirectory(@"C:\Program Files (x86)\Refplus Webtools");
                    Directory.CreateDirectory(@"C:\Program Files (x86)\Refplus Webtools\Resources");
                    Directory.CreateDirectory(@"C:\Program Files (x86)\Refplus Webtools\Resources\Formation");
                    DirectoryInfo di = Directory.CreateDirectory(@"C:\Program Files (x86)\Refplus Webtools\temp");
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                }
            }
            else
            {
                _directory = @"C:\Program Files\Refplus Webtools";
                if (Directory.Exists(@"C:\Program Files\Refplus Webtools"))
                {
                    alreadyInstalled = true;
                }
                else
                {
                    Directory.CreateDirectory(@"C:\Program Files\Refplus Webtools");
                    Directory.CreateDirectory(@"C:\Program Files\Refplus Webtools\Resources");
                    Directory.CreateDirectory(@"C:\Program Files\Refplus Webtools\Resources\Formation");
                    DirectoryInfo di = Directory.CreateDirectory(@"C:\Program Files\Refplus Webtools\temp");
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
            }
            if (alreadyInstalled)
            {
                if (
                    MessageBox.Show(
                        "A previous installation of Webtools has been found.  If you click yes, that previous install will be deleted before the new one will take place. Do you want to delete the previous install?",
                        "Previous install detected", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    Close();
                    cont = false;
                }
            }
            if (cont)
            {
                //Copy every file in The folder
                int amountOfFileDone = 0;
                progressBar2.Minimum = 0;
                progressBar2.Maximum = filesToBeDownloaded.Length;
                foreach (string fileName in filesToBeDownloaded)
                {
                    labelInstaller.Text = amountOfFileDone + @"/" + filesToBeDownloaded.Length;
                    progressBar2.Value = amountOfFileDone;
                    Application.DoEvents();
                    DownloadFile(fileName);
                    amountOfFileDone++;
                    Application.DoEvents();
                }
                labelInstaller.Text = amountOfFileDone + @"/" + filesToBeDownloaded.Length;
                progressBar2.Increment(1);
                //install CR
                MessageBox.Show(
                    "In order to properly run webtools, you need to install a version of crystal report.  The installer will now launch Crystal Report's own installer.  Please install it fully.  Thank you very much.");
                var crystal = Process.Start(_directory + @"\CRRuntime_12_2_mlb.msi");
                crystal.WaitForExit();
                //Process.Start("CMD.exe", "msiexec.exe /i \"" + directory + @"\CRRuntime_12_2_mlb.msi""");
                //Copy shortcut to desktop
                CreateShortcut();

            }
            //launch WT
            Close();

        }
        private void DownloadFile(string fileToDownload)
        {
            try
            {
                var client = new WebClient();
                WebRequest req = WebRequest.Create("http://download.refplus.com/WebTools/" + fileToDownload);
                req.Method = "HEAD";
                int contentLength;
                long downloadedSize;
                using (WebResponse resp = req.GetResponse())
                {
                    int.TryParse(resp.Headers.Get("Content-Length"), out contentLength);
                }
                contentLength /= 1024;
                string filePath;
                if (fileToDownload.Contains("Formation"))
                {
                    filePath = _directory + @"\Resources\Formation\" +
                           fileToDownload.Substring(18, fileToDownload.Length - 22);
                }
                else if (fileToDownload.Contains("Resources"))
                {
                    filePath = _directory + @"\Resources\" +
                           fileToDownload.Substring(9, fileToDownload.Length - 13);
                }   
                else
                {
                    filePath = _directory + @"\" +
                           fileToDownload.Substring(0, fileToDownload.Length - 4);
                }
                client.DownloadFileAsync(new Uri("http://download.refplus.com/WebTools/" + fileToDownload),  filePath);    
                
                

                progressBar1.Minimum = 0;
                progressBar1.Maximum = contentLength;
                do
                {
                    
                    var file = new FileInfo( filePath);
                    downloadedSize = file.Length / 1024;
                    labelFile.Text = downloadedSize + @"kb /" + contentLength + @"kb";
                    progressBar1.Value = Convert.ToInt32(downloadedSize);
                    Application.DoEvents();
                } while (downloadedSize < contentLength);

                client.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static string GetWebServiceUrl()
        {
            string url = "";
            // Get the path of the webservice xml file (url).
            const string urlPath = "WebServiceConfig.xml";
            var dtUrl = new DataTable("WebServiceConfig");
            dtUrl.Columns.Add("url", typeof(string));
            // if the web service url file exist.
            if (File.Exists(urlPath))
            {
                try
                {
                    // Read the path from the xml file.
                    dtUrl.ReadXml(urlPath);
                    if (dtUrl.Rows.Count > 0)
                    {
                        //put the path in the variable
                        url = dtUrl.Rows[0][0].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show(@"Error while getting connection information.");
                    Environment.Exit(0);
                }
            }
            return url;
        }

    }
}
