using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.ControlPanel
{
    public partial class frmControlPanelOption : Form
    {
        public frmControlPanelOption()
        {
            InitializeComponent();
            
        }

        private void frmControlPanelOption_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
        }
    }
}