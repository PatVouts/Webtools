using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EatonLeonardConverter
{
    public partial class FrmTubeSize : Form
    {
        public FrmTubeSize()
        {
            InitializeComponent();
        }
        private double _bendRadius;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() == "")
            {
                MessageBox.Show("Please select a tube diameter before clicking ok.");
            }
            else
            {
                switch (comboBox1.Text.ToString())
                {
                    case ("3/8"):
                        _bendRadius = 0.9375;
                        break;
                    case ("1/2"):
                        _bendRadius = 0.75;
                        break;
                    case ("5/8"):
                        _bendRadius = 0.751;
                        break;
                    case ("7/8"):
                        _bendRadius = 1.25;
                        break;
                    case ("1 1/8"):
                        _bendRadius = 1.75;
                        break;
                    case ("1 3/8"):
                        _bendRadius = 2;
                        break;
                    case ("1 5/8"):
                        _bendRadius = 2.5;
                        break;
                    case ("2 1/8"):
                        _bendRadius = 4;
                        break;
                }
                Visible = false;
            }
        }
        public double GetBendRadius()
        {
            return _bendRadius;
        }
    }
}
