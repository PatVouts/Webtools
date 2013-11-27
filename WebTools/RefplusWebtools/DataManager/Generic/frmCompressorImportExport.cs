using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmCompressorImportExport : Form
    {
        public FrmCompressorImportExport()
        {
            InitializeComponent();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            MyFolderBrowser.ShowDialog();

            DataTable dtCompressorData = Query.Select("SELECT * FROM CompressorData");

            Public.ExportTableToCSV(dtCompressorData, MyFolderBrowser.SelectedPath + "\\CompressorData.csv");

            Public.LanguageBox("File exported successfully.","Fichier exporté avec succès.");

        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to import a file.", "Êtes-vous sûr de vouloir importer un fichier?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MyOpenFile.Filter = @"Comma Separated Value|*.csv";
                MyOpenFile.ShowDialog();

                if (MyOpenFile.FileName != "")
                {
                    DataTable dtCompressorData = Query.Select("SELECT * FROM CompressorData");

                    DataTable dtImport = Public.ImportCSVToTable(dtCompressorData, MyOpenFile.FileName, "CompressorData");

                    if (dtImport != null)
                    {
                        Query.Execute("SELECT * INTO CompressorData_" + GetFormatedServerDate() + " FROM CompressorData");

                        Query.Execute("DELETE FROM CompressorData");

                        for (int i = 0; i < dtImport.Rows.Count; i++)
                        {
                            Query.Execute(Query.BuildInsertQueryPerRow(dtImport, i, "CompressorData"));
                        }

                        Query.UpdateServerTableVersion("CompressorData");

                        Public.LanguageBox("File imported", "Fichier Importé");
                    }
                    else
                    {
                        Public.LanguageBox("Imported file does not follow the established rules", "Le fichier importé ne suit pas les rêgles établies.");
                    }
                }
            }
        }

        private string GetFormatedServerDate()
        {
            DateTime currentDate = Public.GetServerDate();

            return currentDate.Year + currentDate.Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + currentDate.Day.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + currentDate.Hour.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + currentDate.Minute.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + currentDate.Second.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}