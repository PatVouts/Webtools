using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmPublicityManager : Form
    {
        public enum OpenPublicityType { ADD, EDIT }

        public FrmPublicityManager()
        {
            InitializeComponent();
        }

        private void frmPublicityManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillPublicityNamesAndFiles();
        }

        private void FillPublicityNamesAndFiles()
        {
            lvPublicity.Items.Clear();

            DataTable dtPublicity = Query.Select("SELECT DISTINCT * FROM PublicityRotation ORDER BY Name ASC");

            foreach (DataRow dr in dtPublicity.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvPublicity);

                myItem.SubItems[0].Checked = (bool)dr["Rotation"];
                myItem.SubItems[1].Text = dr["Name"].ToString();

                lvPublicity.Items.Add(myItem);
            }

            lvPublicity.Refresh();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var upload = new FrmPublicityUpload(OpenPublicityType.ADD);
            upload.ShowDialog();
            FillPublicityNamesAndFiles();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvPublicity.SelectedItems.Count > 0)
            {
                var upload = new FrmPublicityUpload(OpenPublicityType.EDIT, ((GlacialComponents.Controls.GLItem)lvPublicity.SelectedItems[0]).SubItems[1].Text);
                upload.ShowDialog();
                FillPublicityNamesAndFiles();
            }
            else
            {
                Public.LanguageBox("You must select a publicity name to edit.", "Vous devez choisir un nom de publicité à modifier.");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvPublicity_DoubleClick(object sender, EventArgs e)
        {
            if (lvPublicity.SelectedItems.Count > 0)
            {
                var upload = new FrmPublicityUpload(OpenPublicityType.EDIT, (((GlacialComponents.Controls.GLItem)lvPublicity.SelectedItems[0]).SubItems[1].Text));
                upload.ShowDialog();
                FillPublicityNamesAndFiles();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.LanguageQuestionBox("Are you sure you wish to save these changes?", "Êtes-vous sûr de vouloir enregistrer ces modifications?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Query.Execute("UPDATE PublicityRotation SET Rotation = 0");
                foreach (GlacialComponents.Controls.GLItem item in lvPublicity.Items)
                {
                    Query.Execute("UPDATE PublicityRotation SET Rotation = " + (item.SubItems[0].Checked ? "1" : "0") + " WHERE Name = '" + item.SubItems[1].Text.Replace("'", "''") + "'");
                }
            }
            FillPublicityNamesAndFiles();
        }
    }
}