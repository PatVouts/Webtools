using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public partial class FrmThreadProcess : Form
    {
        public FrmThreadProcess()
        {
            InitializeComponent();
        }
        private Color _threadColor = Color.DodgerBlue;

        private void frmThreadProcess_Load(object sender, EventArgs e)
        {
            _threadColor = Public.GetSiteColor();

            var lc = new LoadingCircle
            {
                Height = 140,
                Width = 140,
                NumberSpoke = 14,
                OuterCircleRadius = 60,
                SpokeThickness = 10,
                InnerCircleRadius = 45
            };
            lc.InnerCircleRadius = 45;
            lc.RotationSpeed = 90;
            lc.ForeColor = Color.Black;
            lc.Color = _threadColor;
            lc.BackColor = Color.White;

            lc.Parent = pnlContainer;

            lc.Left = pnlContainer.Width / 2 - lc.Width / 2;
            lc.Top = pnlContainer.Height / 2 - lc.Height / 2 - 20;
            lc.Active = true;
            lc.BringToFront();

            lblProgress.ForeColor = _threadColor;
            lblProgress.BringToFront();
        }

        public void UpdateProgress(int intProgress)
        {
            string strNewProgress = (intProgress == -1 ? "" : intProgress.ToString(CultureInfo.InvariantCulture));
            if (strNewProgress != lblProgress.Text)
            {
                lblProgress.Text = strNewProgress;
                lblProgress.Refresh();
            }
        }

        public void UpdateMessage(string strMessage)
        {
            if (strMessage != lblMessage.Text)
            {
                lblMessage.Text = strMessage;
                lblMessage.Refresh();
            }
        }
    }
}