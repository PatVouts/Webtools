using System;
using System.Windows.Forms;

namespace RefplusWebtools.Quotes
{
    public partial class FrmTag : Form
    {
        private string _text;
        private Boolean _clicked;

        public FrmTag()
        {
            InitializeComponent();
            Public.ChangeFormLanguage(this);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _clicked = true;
            _text = textBox1.Text;
            Visible = false;
        }
        public string GetText()
        {
            return _text;
        }
        public Boolean GetPressed()
        {
            return _clicked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _clicked = false;
            Visible = false;
        }
    }
}
