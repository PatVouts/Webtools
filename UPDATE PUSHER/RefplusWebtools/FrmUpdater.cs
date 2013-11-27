using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace UpdatePusher
{
    public partial class FrmUpdater : Form
    {

        public FrmUpdater()
        {
            InitializeComponent();
            DataTable dt = Query.Select("Select Max(Date) as D from UpdateInfo");
            DataTable vt = Query.Select("Select Max(VersionNumber) as D from UpdateInfo");
            textBox2.Text = dt.Rows[0]["D"].ToString();
            textBox3.Text = vt.Rows[0]["D"].ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string folder = chooseFolder();
            textBox1.Text = folder;
            FilesView.Rows.Clear();
            string[] files = Directory.GetFiles(folder);
            foreach (string file in files)
            {
                if (file != null) FilesView.Rows.Add(false,file.Substring(folder.Length + 1), File.GetLastWriteTime(file).ToString());
            }
        }

        private string chooseFolder()
        {
            string folderPath = "";
            var folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            return folderPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //change version in XML
            int version = Convert.ToInt32(textBox3.Text);
            ++version;
            Public.UpdateXMLversion(version.ToString());

            Query.Execute("Insert into [RefplusWebtools].[dbo].[UpdateInfo] VALUES (" + version.ToString() + ", '" + DateTime.Now.ToShortDateString() + "', 0)");
            //transform needed files in .zip    
            foreach (DataGridViewRow row in FilesView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    if (File.Exists(textBox1.Text + @"\" + row.Cells[1].Value + ".zip"))
                    {
                        File.Delete(textBox1.Text + @"\" + row.Cells[1].Value + ".zip");
                    }
                    File.Copy(textBox1.Text + @"\" + row.Cells[1].Value, textBox1.Text + @"\" + row.Cells[1].Value + ".zip");
                    Query.Execute("Insert into [RefplusWebtools].[dbo].[UpdateTable] VALUES (" + version.ToString() + ",'" + ((row.Cells[1].Value.ToString().Contains("Updater"))?  "RefplusWebtoolsUpdater2.exe" : row.Cells[1].Value) + ".zip')");
                }
            }
           //Ask for update table to push
            var info = new FrmInfo(version);
            info.ShowDialog();
            //push update table queries
            MessageBox.Show("Please copy every .zip file just created into the correct folder online. Also remember to manually push your Resources and Formation files, both for the table update and the file upload!  Thank you!");
            Process.Start("explorer.exe", textBox1.Text);
        }

    }
}
