using System;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    /* Standard frm to give a name to a new kit of pieces.  */
    public partial class FrmName : Form
    {
        private bool _saved;
        private string _name;

        public FrmName(string name)
        {
            InitializeComponent();
            Public.ChangeFormLanguage(this);
            textBox1.Text = name;
        }

        /*If uses presses cancel, it shouldn't save.  So saved = false to be grabbed by the parent process*/
        private void cmd_delete_Click(object sender, EventArgs e)
        {
            _saved = false;
            Visible = false;
        }

        /*If uses presses save, it should save.  So saved = true to be grabbed by the parent process along with the name*/
        private void cmd_save_Click(object sender, EventArgs e)
        {
            _name = textBox1.Text;
            _saved = true;
            Visible = false;
        }


        /* standard gets to return name and "saved" to parent process*/
        public string Getname()
        {
            return _name;
        }
        public bool Getsaved()
        {
            return _saved;
        }
    }
}
