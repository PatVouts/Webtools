using System;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmDrawingFileManager : Form
    {
        public FrmDrawingFileManager()
        {
            InitializeComponent();
        }

        private void frmDrawingFileManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            cboCategory.SelectedIndex = 0;
        }

        private void Fill_ListOfFiles()
        {
            cboFile.Items.Clear();
            if(cboCategory.SelectedIndex>=0)
            {
                string[] listOfFiles = DrawingManager.GetListOfDrawings("REFPLUS", GetCategory());

                for (int i = 0; i < listOfFiles.Length; i++)
                {
                    ComboBoxControl.AddItem(cboFile, listOfFiles[i], listOfFiles[i]);
                }

                if (cboFile.Items.Count > 0)
                {
                    cboFile.SelectedIndex = 0;
                }
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            var frmupload = new FrmDrawingUpload();
            frmupload.ShowDialog();
            frmupload.Dispose();

            Fill_ListOfFiles();
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            if (cboFile.SelectedIndex >= 0 && cboCategory.SelectedIndex >= 0)
            {
                ThreadProcess.Start(Public.LanguageString("Downloading drawing for preview", "Téléchargement du dessin pour aperçu"));
                string strFile = DrawingManager.SaveDrawingToDisk(DrawingManager.GetDrawingFile(cboFile.Text, "REFPLUS",GetCategory()), "Drawing.pdf");
                ThreadProcess.Stop();
                Focus();

                if (!string.IsNullOrEmpty(strFile))
                {
                    //open up the file
                    System.Diagnostics.Process.Start(strFile);
                }
                else
                {
                    Public.LanguageBox("File could not be loaded", "Le fichier n'a pas pu être affiché");
                }
            }
        }

        private DrawingManager.DrawingCategory GetCategory()
        {
            var dc = DrawingManager.DrawingCategory.Condenser;

            switch (cboCategory.Text)
            {
                case "Condenser":
                    dc = DrawingManager.DrawingCategory.Condenser;
                    break;
                case "Condensing Unit":
                    dc = DrawingManager.DrawingCategory.CondensingUnit;
                    break;
                case "Evaporator":
                    dc = DrawingManager.DrawingCategory.Evaporator;
                    break;
                case "Fluid Cooler":
                    dc = DrawingManager.DrawingCategory.FluidCooler;
                    break;
                case "Gravity Coil":
                    dc = DrawingManager.DrawingCategory.GravityCoil;
                    break;
            }

            return dc;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_ListOfFiles();
        }
    }
}