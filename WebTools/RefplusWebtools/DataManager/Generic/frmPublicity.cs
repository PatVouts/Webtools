using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmPublicity : Form
    {
        private readonly DataTable _dtPublicityCount;

        public FrmPublicity(DataTable dtPublicityCount)
        {
            InitializeComponent();
            _dtPublicityCount = dtPublicityCount;
        }

        private void frmPublicity_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            //2012-11-28 : corrected the random number which was flawed.
            var randomNum = new Random((int)DateTime.Now.Ticks);
            int publicityNum = randomNum.Next(0, _dtPublicityCount.Rows.Count);
            DataTable dtPublicity = Query.Select("SELECT * FROM Publicity WHERE Language = '" + Public.Language + "' AND Name = '" + _dtPublicityCount.Rows[publicityNum]["Name"] + "'");
            string filename = dtPublicity.Rows[0]["Filename"].ToString().Split('\\')[dtPublicity.Rows[0]["Filename"].ToString().Split('\\').Length - 1];
            byte[] file = PublicityManager.GetPublicity(filename);
            string filepath = PublicityManager.SavePublicityToDisk(file, filename);
            picPublicity.Image = Image.FromFile(filepath);
            MinimizeScreen();
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeLabel_Click(object sender, EventArgs e)
        {
            MinimizeScreen();
        }

        private void maximizeLabel_Click(object sender, EventArgs e)
        {
            MaximizeScreen();
        }

        private Size ResizeForm(Image imageToResize, Size size)
        {
            int originalWidth = imageToResize.Width;
            int originalHeight = imageToResize.Height;

            float nPercentW = size.Width / (float)originalWidth;
            float nPercentH = (((float)size.Height - picPublicity.Top - (Height - picPublicity.Bottom))  / originalHeight);

            float nPercent = nPercentH <= nPercentW ? nPercentH : nPercentW;

            var destWidth = (int)(originalWidth * nPercent);
            var destHeight = (int)(originalHeight * nPercent);

            destHeight = destHeight + picPublicity.Top + (Height - picPublicity.Bottom);

            return new Size(destWidth, destHeight);
        }

        private void CenterScreen()
        {
            int boundWidth = Screen.PrimaryScreen.Bounds.Width;
            int boundHeight = Screen.PrimaryScreen.Bounds.Height;
            int x = boundWidth - Width;
            int y = boundHeight - Height;
            Location = new Point(x / 2, y / 2);
        }

        private void MinimizeScreen()
        {
            Size = ResizeForm(picPublicity.Image, new Size(1024, 768));
            CenterScreen();
        }

        private void MaximizeScreen()
        {
            Size = ResizeForm(picPublicity.Image, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            CenterScreen();
        }

        private void chkNoShow_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}