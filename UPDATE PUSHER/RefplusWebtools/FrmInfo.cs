using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UpdatePusher
{
    public partial class FrmInfo : Form
    {
        private static int vers = 0;
        public FrmInfo(int version)
        {
            InitializeComponent();
            vers = version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query.Execute("Insert into [RefplusWebtools].[dbo].[Updates] VALUES('" + vers + "', '" + comboBox1.Text + "','" +
                          textBox1.Text + "','" + textBox2.Text + "'," + comboBox2.Text + ")");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
