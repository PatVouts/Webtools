using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace RefplusWebtools.DataManager.FluidCooler
{
    public partial class FrmFluidCoolerPricingReport : Form
    {
        public FrmFluidCoolerPricingReport()
        {
            InitializeComponent();
        }

        private DataTable GetBuildTable()
        {
            const string tsql = @"SELECT    
                            REFPLUS_FluidXRefModel AS Model, 
                            FanWide, 
                            FanLong, 
                            Weight,
                            Price AS ListPrice, 
                            Fin, 
                            Row, 
                            FPI, 
                            FinHeight, 
                            CoilLength
                            
                            FROM FluidCoolerModel
                            
                            WHERE REFPLUS_FluidXRefModel <> ''
                            
                            ORDER BY REFPLUS_FluidXRefModel";

            DataTable dtFluidCooler = Query.Select(tsql);

            //now everything there except the blygold prices.

            dtFluidCooler.Columns.Add("BlyGoldPrice", typeof(decimal));

            DateTime startTime = DateTime.Now;

            for (int i = 0; i < dtFluidCooler.Rows.Count; i++)
            {
                var coating = new RefplusWebtools.Pricing.BlyGoldCoating(
                    dtFluidCooler.Rows[i]["Fin"].ToString(),
                    1m,
                    Convert.ToDecimal(dtFluidCooler.Rows[i]["Row"]),
                    Convert.ToDecimal(dtFluidCooler.Rows[i]["FPI"]),
                    Convert.ToDecimal(dtFluidCooler.Rows[i]["FinHeight"]),
                    Convert.ToDecimal(dtFluidCooler.Rows[i]["CoilLength"]));

                dtFluidCooler.Rows[i]["BlyGoldPrice"] = coating.Price;

                ThreadProcess.UpdateMessage(Public.LanguageString("Generating Data ", "Génération des données ") + i.ToString("N0") + " / " + dtFluidCooler.Rows.Count.ToString("N0") + GetEstimatedTimeLeft(i, dtFluidCooler.Rows.Count, startTime));

            }

            //now remove unwanted columns

            dtFluidCooler.Columns.Remove("Fin");
            dtFluidCooler.Columns.Remove("Row");
            dtFluidCooler.Columns.Remove("FPI");
            dtFluidCooler.Columns.Remove("FinHeight");
            dtFluidCooler.Columns.Remove("CoilLength");

            return dtFluidCooler;
        }

        private static string GetEstimatedTimeLeft(int currentPosition, int totalPosition, DateTime startTime)
        {
            decimal decTimeRatio = (totalPosition / (currentPosition + 1m)) - 1m;

            TimeSpan ts = DateTime.Now - startTime;

            double secondsElapsed = ts.TotalSeconds * (double)decTimeRatio;

            ts = TimeSpan.FromSeconds(secondsElapsed);

            string strEstimatedTimeLeft = "\n" + Public.LanguageString("Estimated time left : ", "Temps restant estimé : ") + ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");

            return strEstimatedTimeLeft;
            
        }

        private void cmdGenerateReport_Click(object sender, EventArgs e)
        {
            if (MyFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                ThreadProcess.Start(Public.LanguageString("Generating Data", "Génération des données"));

                DataTable dtCompressorData = GetBuildTable();

                string filename = MyFolderBrowser.SelectedPath + "\\FluidCoolersListPriceWithBlygold.csv";

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                Public.ExportTableToCSV(dtCompressorData, filename);

                ThreadProcess.Stop();
                Focus();

                Public.LanguageBox("File exported successfully.", "Fichier exporté avec succès.");
            }
        }

        private void frmFluidCoolerPricingReport_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);
        }
    }
}