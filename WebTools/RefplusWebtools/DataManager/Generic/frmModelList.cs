using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Data;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmModelList : Form
    {
        private readonly string _id;
        private readonly string _type;
        private readonly string _unitType;
        public FrmModelList(string kitID, string type, IEnumerable<string> modelList, string unitType)
        {
            InitializeComponent();
            _id = kitID;
            _type = type;
            _unitType = unitType;
            if (unitType != "Fluid Cooler" && unitType != "Gravity Coil" && unitType != "Condenser")
            {
                foreach (string model in modelList)
                {   
                    var myItem = new GlacialComponents.Controls.GLItem(lvModels);
                    myItem.SubItems[0].Text = model;
                    lvModels.Items.Add(myItem);
                }
            }
            else
            {
                var listOfModels = new DataTable();
                switch (unitType){
                    case "Fluid Cooler":
                        listOfModels = Query.Select("Select distinct ([REFPLUS_FluidXRefModel]) From FluidCoolerModel");
                        break;
                    case "Gravity Coil" :
                        listOfModels = Query.Select("Select distinct ([REFPLUS_Model]) From GravityCoil");
                        break;
                    case "Condenser" :
                        listOfModels = Query.Select("Select distinct ([REFPLUS_CondenserXRefModel]) From Condenserxref");
                        break;
                }
                foreach (DataRow model in listOfModels.Rows)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvModels);
                    myItem.SubItems[0].Text = model[0].ToString();
                    lvModels.Items.Add(myItem);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((!String.IsNullOrEmpty(txtModel.Text)))
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvModels);
                myItem.SubItems[0].Text = txtModel.Text;
                lvModels.Items.Add(myItem);
                lvModels.Refresh();
            }
        }

        private void lvModels_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = lvModels.Items.Count -1; i >= 0 ; --i)
                {
                    if (lvModels.Items[i].Selected)
                    {
                        lvModels.Items.RemoveAt(i);
                    }
                }
            }
            lvModels.Refresh();
        }

        private void cmd_Assign_Click(object sender, EventArgs e)
        {
            ThreadProcess.Start(Public.LanguageString("Updating associations", "Mise à jour des associations"));
            Query.Execute("Delete from " + _type + "Association where " + _type + "id = " + _id);
            for (int i = 0; i < lvModels.Items.Count; ++i)
            {
                Query.Execute("Insert into " + _type + "Association VALUES ('" + _id + "','" + _unitType + "','" + lvModels.Items[i].SubItems[0].Text + "')");
            }

            ThreadProcess.Stop();
            Public.LanguageBox("Your models have been assigned to the correct " + _type,
                               "Les modèles dans la liste ont été associés au " + _type + " approprié.");
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                for (int i = lvModels.Items.Count - 1; i >= 0; --i)
                {
                    if (lvModels.Items[i].SubItems[0].Text.Contains(maskedTextBox1.Text))
                    {
                        lvModels.Items.RemoveAt(i);
                    }
                }
            }
            lvModels.Refresh();
        }

        private void frmModelList_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);
        }

        private void cmd_AddListOfModels_Click(object sender, EventArgs e)
        {
            var frm = new FrmModelSelector(_id, _type, true);
            frm.ShowDialog();
            var listToAdd = frm.GetModels();
            frm.Close();
            if(listToAdd != null)
            {
                foreach (string model in listToAdd)
                {
                    if( !string.IsNullOrEmpty(model))
                    {
                        var myItem = new GlacialComponents.Controls.GLItem(lvModels);
                        myItem.SubItems[0].Text = model;
                        lvModels.Items.Add(myItem);
                        lvModels.Refresh();
                    }
                }
            }
        }
    }
}