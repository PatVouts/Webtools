using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace EatonLeonardConverter
{
    public partial class FrmJobInfo : Form
    {
        public FrmJobInfo()
        {
            InitializeComponent();
        }
        public string GetModel()
        {
            return txtModel.Text;
        }
        public string GetJob()
        {
            return txtJob.Text;
        }
        public string GetQuantity()
        {
            return nud_qty.Value.ToString(CultureInfo.InvariantCulture);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtJob.Text == "" || txtModel.Text == "")
            {
                MessageBox.Show("Please enter a model and a job number");
            }
            else
            {

                if (File.Exists(@"P:\Refplus\Rpapps\Eaton-Leonard\BOM" + txtJob + ".doc"))
                {
                    MessageBox.Show(
                        @"You need to enter a job number that hasn't been used before.  Please correct your job number before retrying");
                }
                else
                {
                    Visible = false;
                }
            }
        }
    }
}
