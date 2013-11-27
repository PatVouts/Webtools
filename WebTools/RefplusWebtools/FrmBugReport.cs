using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace RefplusWebtools
{
    /* simple form to send an email to a user (ME) so I can receive bug reports sent by sales people*/
    public partial class FrmBugReport : Form
    {
        public FrmBugReport()
        {
            InitializeComponent();
            Public.RefreshMdiFormLanguage(this);
        }

        private void FrmBugReport_Load(object sender, EventArgs e)
        {
            Initialize();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        //putting everything at false and placing the username in the designated box
        private void Initialize()
        {
            txtUsername.Text = UserInformation.UserName;
            rdioBug.Checked = false;
            rdioImprv.Checked = false;
            cmb_Priority.SelectedText = "";
            txtTitle.Text = "";
            txtProblem.Text = "";
        }


        //When you send, it sends one of two messages depending on which choice you took
        private void cmdSend_Click(object sender, EventArgs e)
        {
            if(rdioBug.Checked)
            {
                CreateMessage("Bug BY : " + txtUsername.Text + " - " + txtTitle.Text + " - " + cmb_Priority.Text, txtProblem.Text);
            }
            else
            {
                CreateMessage("Improv BY : " + txtUsername.Text +" - " + txtTitle.Text + " - " + cmb_Priority.Text, txtProblem.Text);
            }
        }

        //standard message to send an email To me from the generic refplus it email 
        public static void CreateMessage(string emailTitle, string emailBody)
        {
            try
            {
                //using the "itrefplus" email at gmail to send
                var cred = new NetworkCredential("itrefplus@gmail.com", "vp2Z25E@5z7#");
                var msg = new MailMessage();
                msg.To.Add("pvoutsinas@refplus.com");
                msg.From = new MailAddress("itrefplus@gmail.com");
                msg.Subject = emailTitle;
                msg.Body = emailBody;

                var client = new SmtpClient("smtp.gmail.com", 25) {Credentials = cred, EnableSsl = true};
                client.Send(msg);
                Public.LanguageBox("Your bug was successfully sent", "Votre bug a été envoyé avec succès");
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"FrmBugReport CreateMessage");
                MessageBox.Show(ex.ToString());
            }

        }

    }
}
