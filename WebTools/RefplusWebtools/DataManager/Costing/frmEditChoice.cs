using System;
using System.Data;
using System.Windows.Forms;
using RefplusWebtools.DataManager.Generic;

namespace RefplusWebtools.DataManager.Costing
{
    public partial class FrmEditChoice : Form
    {
        private readonly string _moduleName;
        public FrmEditChoice(string moduleName)
        {
            InitializeComponent();
            _moduleName = moduleName;
            textBox1.Text = _moduleName;
            if (!moduleName.Contains("MODULE"))
            {
                btn_EditLogic.Enabled = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_EditLogic_Click(object sender, EventArgs e)
        {
            string name = _moduleName.Substring(_moduleName.IndexOf("-", StringComparison.Ordinal) + 1);
            name = name.Substring(name.IndexOf("-", StringComparison.Ordinal) + 1);
            DataTable type =
                Query.Select(
                    "Select TypeName, KitName from KitInfo Inner Join KitType on KitInfo.KitType = KitType.TypeID where KitInfo.KitName = '" +
                   name.Trim()  + "'");

            if(type.Rows[0]["TypeName"].ToString().Contains("MODULE"))
            {
                var oL = new FrmLogic(name.Trim(), type.Rows[0]["TypeName"].ToString(), false, "");
                oL.ShowDialog();
            }
            else
            {
                DataTable kitInfo = Query.Select("Select * from KitInfo where KitName = '" + _moduleName + "'");
                var oA = new FrmModelSelector(kitInfo.Rows[0]["KitID"].ToString(), "Kit", false);
                oA.ShowDialog();
            }
        }
        private void btn_EditPieces_Click(object sender, EventArgs e)
        {
            string name;
            if(_moduleName.Contains("MODULE"))
            {
                name = _moduleName.Substring(_moduleName.IndexOf("-", StringComparison.Ordinal) + 1);
                name = name.Substring(name.IndexOf("-", StringComparison.Ordinal) + 1);
            }
            else
            {
                name = _moduleName;
            }
            var oP = new FrmOptionPack(name.Trim());
            oP.ShowDialog();
        }

        private void FrmEditChoice_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
        }
    }
}
