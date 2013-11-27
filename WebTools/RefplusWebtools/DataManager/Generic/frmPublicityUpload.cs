using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmPublicityUpload : Form
    {
        private readonly FrmPublicityManager.OpenPublicityType _type;
        private readonly string _name;

        public FrmPublicityUpload(FrmPublicityManager.OpenPublicityType type)
        {
            InitializeComponent();
            _type = type;
        }

        public FrmPublicityUpload(FrmPublicityManager.OpenPublicityType type, string name)
        {
            InitializeComponent();
            _type = type;
            _name = name;
        }

        private void cmdBrowseEN_Click(object sender, EventArgs e)
        {
            OpenDlg.Title = Public.LanguageString("Select an image file", "Sélectionnez un fichier d'image");
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                txtEnglishFile.Text = OpenDlg.FileName;
            }
        }

        private void cmdBrowseFR_Click(object sender, EventArgs e)
        {
            OpenDlg.Title = Public.LanguageString("Select an image file", "Sélectionnez un fichier d'image");
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                txtFrenchFile.Text = OpenDlg.FileName;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string errors = "";
            DataTable dtName = Query.Select("SELECT Name FROM PublicityRotation WHERE Name = '" + txtName.Text.Replace("'", "''") + "'");

            if (txtName.Text == "")
            {
                errors += Public.LanguageString("You must enter a name for the files.\n", "Vous devez entrer un nom pour les fichiers.\n");
            }

            if (txtEnglishFile.Text == "")
            {
                errors += Public.LanguageString("You must select a file for English display.\n", "Vous devez sélectionner un fichier pour l'affichage en anglais.\n");
            }

            if (txtFrenchFile.Text == "")
            {
                errors += Public.LanguageString("You must select a file for French display.\n", "Vous devez sélectionner un fichier pour l'affichage en français.\n");
            }


            if (errors != "")
            {
                MessageBox.Show(errors, @"Error", MessageBoxButtons.OK);
            }
            else
            {
                if (_type == FrmPublicityManager.OpenPublicityType.ADD)
                {
                    if (dtName.Rows.Count == 0)
                    {
                        if (Public.LanguageQuestionBox("Are you sure you want to upload these files?", "Etes-vous sûr que vous souhaitez télécharger ces fichiers sur le serveur?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (txtEnglishFile.Text.Split('\\')[txtEnglishFile.Text.Split('\\').Length - 1].Length <= 100 && txtFrenchFile.Text.Split('\\')[txtFrenchFile.Text.Split('\\').Length - 1].Length <= 100)
                            {
                                PublicityManager.UploadPublicity(txtEnglishFile.Text);
                                PublicityManager.UploadPublicity(txtFrenchFile.Text);
                                Query.Execute("INSERT INTO Publicity VALUES ('" + txtName.Text.Replace("'", "''") + "', '" + txtEnglishFile.Text.Replace("'", "''") + "', 'EN')");
                                Query.Execute("INSERT INTO Publicity VALUES ('" + txtName.Text.Replace("'", "''") + "', '" + txtFrenchFile.Text.Replace("'", "''") + "', 'FR')");
                                Query.Execute("INSERT INTO PublicityRotation VALUES (1, '" + txtName.Text.Replace("'", "''") + "')");
                                Public.LanguageBox("Images uploaded successfully.", "Les images ont été téléchargées avec succès.");
                                Close();
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
                        Public.LanguageBox("This name already exists. Please enter a different name.", "Ce nom existe déjà. S'il vous plaît entrer un autre nom.");
                    }
                }
                else
                {
                    if (Public.LanguageQuestionBox("Are you sure you want to upload these files?", "Etes-vous sûr que vous souhaitez télécharger ces fichiers sur le serveur?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (txtEnglishFile.Text.Split('\\')[txtEnglishFile.Text.Split('\\').Length - 1].Length <= 100 && txtFrenchFile.Text.Split('\\')[txtFrenchFile.Text.Split('\\').Length - 1].Length <= 100)
                        {
                            PublicityManager.UploadPublicity(txtEnglishFile.Text);
                            PublicityManager.UploadPublicity(txtFrenchFile.Text);
                            Query.Execute("UPDATE Publicity SET Name = '" + txtName.Text.Replace("'", "''") + "', Filename = '" + txtEnglishFile.Text.Replace("'", "''") + "' WHERE Name = '" + _name.Replace("'", "''") + "' AND language = 'EN'");
                            Query.Execute("UPDATE Publicity SET Name = '" + txtName.Text.Replace("'", "''") + "', Filename = '" + txtFrenchFile.Text.Replace("'", "''") + "' WHERE Name = '" + _name.Replace("'", "''") + "' AND language = 'FR'");
                            Query.Execute("UPDATE PublicityRotation SET Name = '" + txtName.Text.Replace("'", "''") + "' WHERE Name = '" + _name.Replace("'", "''") + "'");
                            Public.LanguageBox("Images uploaded successfully.", "Les images ont été téléchargées avec succès.");
                            Close();
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
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPublicityUpload_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            if (_type == FrmPublicityManager.OpenPublicityType.EDIT)
            {
                txtName.Text = _name;
                //txtEnglishFile.Text = dtFilenames.Rows[0]["Filename"].ToString();
                //txtFrenchFile.Text = dtFilenames.Rows[1]["Filename"].ToString();
            }
        }
    }
}