using System;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmDrawingUpload : Form
    {
        public FrmDrawingUpload()
        {
            InitializeComponent();
        }

        private void cmdBrowseFile_Click(object sender, EventArgs e)
        {
            OpenDlg.Title = Public.LanguageString("Select the drawing you wish to upload on the server", "Sélectionner le dessin que vous désirez envoyer sur le serveur");

            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = OpenDlg.FileName;
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {

            if (txtFile.Text != "")
            {
                if (Public.LanguageQuestionBox("Are you sure you want to upload this file", "Êtes-vous sûr de vouloir télécharger ce fichier sur le serveur?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strFilename = txtFile.Text.Split('\\')[txtFile.Text.Split('\\').Length - 1];
                    if (strFilename.Length <= 100)
                    {
                        if (strFilename.Contains("'") == false)
                        {
                            DrawingManager.UploadFile(txtFile.Text, "REFPLUS", GetCategory());
                            Public.LanguageBox("Drawing uploaded succesfully", "Dessin téléchargé avec succès");
                        }
                        else
                        {
                            Public.LanguageBox("File name cannot contain apostrophe", "Le nom du ficher ne peut pas contenir d'apostrophe");
                        }
                    }
                    else
                    {
                        Public.LanguageBox("Filename is too long. It must not exceed 100 characters", "Le nom du fichier est trop long. Il ne peut pas dépasser 100 caractères");
                    }
                }
                else
                {
                    Public.LanguageBox("Upload canceled", "Téléchargement annulé");
                }
            }
            else
            {
                Public.LanguageBox("You must select a file", "Vous devez sélectionner un fichier");
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

        private void frmDrawingUpload_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);
        }
    }
}