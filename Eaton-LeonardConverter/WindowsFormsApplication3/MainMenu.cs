using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EatonLeonardConverter
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var conv = new Converter();
            conv.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start('"' + Application.StartupPath + @"\Batch.exe""");

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var bom = new FrmBOM();
            bom.ShowDialog();
        }
    }
}
