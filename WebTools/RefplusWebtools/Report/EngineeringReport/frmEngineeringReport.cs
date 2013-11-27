using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace RefplusWebtools.Report.EngineeringReport
{
    public partial class FrmEngineeringReport : Form
    {
        public FrmEngineeringReport()
        {
            InitializeComponent();
        }

        private void cboUnitSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_List();
        }

        private void Fill_List()
        {
            lvModel.Items.Clear();
            lvModel.Refresh();

            ThreadProcess.Start(Public.LanguageString("Loading models","Chargement des modèles"));

            DataTable dtModel = null;
            string modelColumn = "";

            switch (cboUnitSerie.Text)
            {
                case "Condensing Unit":
                    dtModel = Query.Select("SELECT Model FROM CondensingUnitModel ORDER BY Model");
                    modelColumn = "Model";
                    break;
                case "Condenser":
                    dtModel = Query.Select("SELECT CondenserXref." + UserInformation.CurrentSite + "_CondenserXRefModel + '-' + CONVERT(nvarchar,Voltage.VoltageID) as Model FROM CondenserXref LEFT JOIN Voltage ON Voltage.MotorCoilArr LIKE '%' + CondenserXref.Motor + CondenserXref.CoilArr + '%' WHERE CondenserXref." + UserInformation.CurrentSite + "_CondenserXRefModel <> '' ORDER BY Model");
                    modelColumn = "Model";
                    break;
            }

            if (dtModel != null)
            {
                Fill_List(dtModel, modelColumn);
            }

            ThreadProcess.Stop();
            Focus();
        }

        private IEnumerable<string> GetSelectedModels()
        {
            var models = new List<string>();

            for (int i = 0; i < lvModel.Items.Count; i++)
            {
                if (lvModel.Items[i].SubItems[0].Checked)
                {
                    models.Add(lvModel.Items[i].SubItems[1].Text);
                }
            }

            return models;
        }

        private void Fill_List(DataTable dt, string modelColumn)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvModel);

                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = dt.Rows[i][modelColumn].ToString();

                lvModel.Items.Add(myItem);
            }

            lvModel.Refresh();
        }

        private void frmEngineeringReport_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            SetDefaults();
        }

        private void SetDefaults()
        {
            cboUnitSerie.SelectedIndex = 0;
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void Generate()
        {
            ThreadProcess.Start(Public.LanguageString("Generating reports", "Création des rapports"));

            switch (cboUnitSerie.Text)
            {
                case "Condensing Unit":
                    Generate_CondensingUnits();
                    break;
                case "Condenser":
                    Generate_Condenser();
                    break;
            }

            ThreadProcess.Stop();
            Focus();
        }

        private void Generate_Condenser()
        {
            IEnumerable<string> models = GetSelectedModels();
            var files = new List<string>();

            foreach (string model in models)
            {
                string[] splitModel = model.Split('-');
                string modelName = splitModel[0];
                string voltageID = splitModel[1];

                string strFile = ErCondenser.Generate(modelName, voltageID, false);

                if (strFile != "")
                {
                    files.Add(strFile);
                }
            }

            MergeAndShow(files);
        }

        private void Generate_CondensingUnits()
        {
            IEnumerable<string> models = GetSelectedModels();
            var files = new List<string>();

            foreach (string model in models)
            {
                string strFile = ErCondensingUnit.Generate(model, false);

                if (strFile != "")
                {
                    files.Add(strFile);
                }
            }

            MergeAndShow(files);
        }

        private void MergeAndShow(List<string> files)
        {
            if (files.Count > 0)
            {
                var pdf = new PDFMerge();
                
                foreach (string strFile in files)
                {
                    if (File.Exists(strFile))
                    {
                        //add the file to the list of files to be merged
                        pdf.AddFile(strFile);
                    }
                }

                //get a randomly generated filename
                string strMergeReportLocation = Public.GenerateFileNameAndPath("EngineeringReport", "pdf");

                //Merge and create the file
                pdf.Merge(strMergeReportLocation);

                //open up the file
                Public.OpenSpecificFile(strMergeReportLocation);

            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmEngineeringReport_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}