using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmGenericDrawingManager : Form
    {
        private readonly DrawingManager.DrawingCategory _dc = DrawingManager.DrawingCategory.Condenser;

        public FrmGenericDrawingManager()
        {
            InitializeComponent();
        }

        public FrmGenericDrawingManager(DrawingManager.DrawingCategory dc)
        {
            InitializeComponent();
            _dc = dc;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCondenserDrawingManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_ListOfModel();

            Fill_ListOfDrawings();
        }

        private void cmdUploadFileAndPreview_Click(object sender, EventArgs e)
        {
            var dwgFileManager = new FrmDrawingFileManager();
            dwgFileManager.ShowDialog();

            Fill_ListOfDrawings();
        }

        private void Fill_ListOfModel()
        {
            lvDrawingList.Items.Clear();

            DataTable dtModel = Query.Select("SELECT * FROM DrawingManager_" + DrawingManager.GetCategory(_dc));

            for (int i = 0; i < dtModel.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvDrawingList);

                myItem.SubItems[0].Text = dtModel.Rows[i]["Model"].ToString();
                myItem.SubItems[1].Text = dtModel.Rows[i]["Filename"].ToString();

                lvDrawingList.Items.Add(myItem);
            }
  
            lvDrawingList.Refresh();
        }

        private void Fill_ListOfDrawings()
        {
            string currentValue = cboDrawing.Text;

            cboDrawing.Items.Clear();

            string[] listOfDrawingOnServer = DrawingManager.GetListOfDrawings("REFPLUS", _dc);

            for (int i = 0; i < listOfDrawingOnServer.Length; i++)
            {
                ComboBoxControl.AddItem(cboDrawing, listOfDrawingOnServer[i], listOfDrawingOnServer[i]);
            }

            if (cboDrawing.FindString(currentValue) >= 0)
            {
                cboDrawing.SelectedIndex = cboDrawing.FindString(currentValue);
            }
            else if (cboDrawing.Items.Count > 0)
            {
                cboDrawing.SelectedIndex = 0;
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            LoadSelectedModel();
        }

        private void LoadSelectedModel()
        {
            if (lvDrawingList.SelectedItems.Count > 0)
            {
                var myItem = (GlacialComponents.Controls.GLItem)lvDrawingList.SelectedItems[0];

                txtModel.Text = myItem.SubItems[0].Text;

                if (cboDrawing.FindString(myItem.SubItems[1].Text) >= 0)
                {
                    cboDrawing.SelectedIndex = cboDrawing.FindString(myItem.SubItems[1].Text);
                }
                else
                {
                    Public.LanguageBox("File could not be found", "Le fichier n'a pas pu être trouvé.");
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
            Fill_ListOfModel();
        }

        private void DeleteSelected()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to delete this model/drawing link ?", "Êtes-vous sûr de vouloir supprimer ce lien modèle/dessin ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (lvDrawingList.SelectedItems.Count > 0)
                {
                    var myItem = (GlacialComponents.Controls.GLItem)lvDrawingList.SelectedItems[0];

                    string strModel = myItem.SubItems[0].Text;

                    Query.Execute("DELETE FROM DrawingManager_" + DrawingManager.GetCategory(_dc) + " WHERE Model = '" + strModel.Replace("'", "''") + "'");
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save this model with this drawing. Prexisting model will automatically be overwritten to use this drawing.", "Êtes-vous sûr de vouloir sauvegarder ce modèle avec ce dessin? Si le modèle existe déja il sera automatiquement remplacer par ce dessin.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtModel.Text != "")
                {
                    if (cboDrawing.SelectedIndex >= 0)
                    {
                        Query.Execute("DELETE FROM DrawingManager_" + DrawingManager.GetCategory(_dc) + " WHERE Model = '" + txtModel.Text.Replace("'", "''") + "'");

                        Query.Execute("INSERT INTO DrawingManager_" + DrawingManager.GetCategory(_dc) + " (Model, Filename) VALUES ('" + txtModel.Text.Replace("'", "''") + "', '" + cboDrawing.Text + "')");

                        Fill_ListOfModel();
                    }
                    else
                    {
                        Public.LanguageBox("You must select a drawing", "Vous devez sélectionner un dessin");
                    }
                }
                else
                {
                    Public.LanguageBox("You must enter a model name", "Vous devez entrez un nom de modèle");
                }
            }
        }

        private void lvDrawingList_DoubleClick(object sender, EventArgs e)
        {
            LoadSelectedModel();
        }

        private void lvDrawingList_Click(object sender, EventArgs e)
        {

        }


    }
}