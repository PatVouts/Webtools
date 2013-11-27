using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace EatonLeonardConverter
{
    public partial class FrmBOM : Form
    {
        public FrmBOM()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"P:\Refplus\Rpapps\Eaton-Leonard\BOM" + txtJob.Text + ".doc"))
                Process.Start(@"P:\Refplus\Rpapps\Eaton-Leonard\BOM" + txtJob.Text + ".doc");
            else
            {
                MessageBox.Show(
                    @"Either you don't have a number entered, or the number refers to a job that wasn't converted with this software.  Sorry!");
            }
        }

        private void txtJob_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return))
            {
                if (File.Exists(@"P:\Refplus\Rpapps\Eaton-Leonard\BOM" + txtJob.Text + ".doc"))
                    Process.Start(@"P:\Refplus\Rpapps\Eaton-Leonard\BOM" + txtJob.Text + ".doc");
                else
                {
                    MessageBox.Show(
                        @"Either you don't have a number entered, or the number refers to a job that wasn't converted with this software.  Sorry!");
                }
            }
        }
    }
}
