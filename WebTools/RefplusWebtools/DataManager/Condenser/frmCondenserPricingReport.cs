using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace RefplusWebtools.DataManager.Condenser
{
    public partial class FrmCondenserPricingReport : Form
    {
        public FrmCondenserPricingReport()
        {
            InitializeComponent();
        }

        private void frmCondenserPricingReport_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);
        }

        private DataTable GetBuildTable()
        {
            const string tsql = @"SELECT    
                            CondenserXref.REFPLUS_CondenserXRefModel AS Model, 
                            CondenserModel.THR_at_1F, 
                            CondenserModel.FanWide, 
                            CondenserModel.FanLong, 
                            CondenserModel.ShipWeight,
                            CondenserXref.Price AS ListPrice, 
                            CondenserModel.FinType, 
                            CondenserModel.Row, 
                            CondenserModel.FPI, 
                            CondenserModel.FinHeight, 
                            CondenserModel.FinLength
                            
                            FROM CondenserModel LEFT JOIN CondenserXref ON 
                            CondenserModel.CondenserType = CondenserXref.CondenserType AND                             
                            CondenserModel.Motor = CondenserXref.Motor AND 
                            CondenserModel.CoilArr = CondenserXref.CoilArr AND 
                            CondenserModel.FanWide = CondenserXref.FanWide AND 
                            CondenserModel.FanLong = CondenserXref.FanLong AND 
                            CondenserModel.Row = CondenserXref.Row AND 
                            CondenserModel.FPI = CondenserXref.FPI
                            
                            WHERE CondenserXref.REFPLUS_CondenserXRefModel <> ''
                            
                            ORDER BY CondenserXref.REFPLUS_CondenserXRefModel";

            DataTable dtCondensers = Query.Select(tsql);

            //now everything there except the blygold prices.

            dtCondensers.Columns.Add("BlyGoldPrice", typeof(decimal));

            DateTime startTime = DateTime.Now;

            for (int i = 0; i < dtCondensers.Rows.Count; i++)
            {
                var coating = new RefplusWebtools.Pricing.BlyGoldCoating(
                    dtCondensers.Rows[i]["Fintype"].ToString(),
                    1m,
                    Convert.ToDecimal( dtCondensers.Rows[i]["Row"]),
                    Convert.ToDecimal( dtCondensers.Rows[i]["FPI"]),
                    Convert.ToDecimal( dtCondensers.Rows[i]["FinHeight"]),
                    Convert.ToDecimal( dtCondensers.Rows[i]["FinLength"]));

                dtCondensers.Rows[i]["BlyGoldPrice"] = coating.Price;

                ThreadProcess.UpdateMessage(Public.LanguageString("Generating Data ", "Génération des données ") + i.ToString("N0") + " / " + dtCondensers.Rows.Count.ToString("N0") + GetEstimatedTimeLeft(i, dtCondensers.Rows.Count, startTime));
            }

            //now remove unwanted columns

            dtCondensers.Columns.Remove("FinType");
            dtCondensers.Columns.Remove("Row");
            dtCondensers.Columns.Remove("FPI");
            dtCondensers.Columns.Remove("FinHeight");
            dtCondensers.Columns.Remove("FinLength");

            return dtCondensers;
        }

        private void cmdGenerateReport_Click(object sender, EventArgs e)
        {
            if (MyFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                ThreadProcess.Start(Public.LanguageString("Generating Data", "Génération des données"));

                DataTable dtCompressorData = GetBuildTable();

                string filename = MyFolderBrowser.SelectedPath + "\\CondensersListPriceWithBlygold.csv";

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

        private static string GetEstimatedTimeLeft(int currentPosition, int totalPosition, DateTime startTime)
        {
            decimal decTimeRatio = (totalPosition / (currentPosition + 1m)) - 1m;

            TimeSpan ts = DateTime.Now - startTime;

            double secondsElapsed = ts.TotalSeconds * (double)decTimeRatio;

            ts = TimeSpan.FromSeconds(secondsElapsed);

            string strEstimatedTimeLeft = "\n" + Public.LanguageString("Estimated time left : ", "Temps restant estimé : ") + ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");

            return strEstimatedTimeLeft;

        }
    }
}