using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Evaporator
{
    public partial class FrmEvaporatorOptions : Form
    {
        private readonly string[] _strTableList = { "EvaporatorVoltage", "EvaporatorSerie" };

        public FrmEvaporatorOptions()
        {
            InitializeComponent();
        }

        private void frmEvaporatorOptions_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            //this call all the fill combobox function needed
            Fill_Lists();

        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void Fill_Lists()
        {
            Fill_FillSerie();

            Fill_Voltage();

            RefreshOptionList();

        }

        private void Fill_FillSerie()
        {
            lvSerie.Items.Clear();

            DataTable dtSerie = Public.SelectAndSortTable(Public.DSDatabase.Tables["EvaporatorSerie"], "", "Type, Style, DefrostType");

            foreach (DataRow drSerie in dtSerie.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvSerie);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drSerie["Type"].ToString();
                myItem.SubItems[2].Text = drSerie["Style"].ToString();
                myItem.SubItems[3].Text = drSerie["DefrostType"].ToString();
                lvSerie.Items.Add(myItem);
            }

            lvSerie.Refresh();
        }

        private void Fill_Voltage()
        {
            lvVoltage.Items.Clear();

            foreach (DataRow drVoltage in Public.DSDatabase.Tables["EvaporatorVoltage"].Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvVoltage);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drVoltage["VoltDescription"].ToString();
                myItem.SubItems[2].Text = drVoltage["VoltageID"].ToString();
                lvVoltage.Items.Add(myItem);
            }

            lvVoltage.Refresh();
        }

        private void RefreshOptionList()
        {
            lvOptionsList.Items.Clear();

            DataTable dtOptionList = Query.Select("SELECT * FROM EvaporatorOptions ORDER BY Groupname,Description");

            foreach (DataRow drOption in dtOptionList.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvOptionsList);
                myItem.SubItems[0].Text = drOption["Groupname"].ToString();
                myItem.SubItems[1].Text = drOption["Description"].ToString();
                lvOptionsList.Items.Add(myItem);
            }

            lvOptionsList.Refresh();
        }

        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

        private void SetAllCapacity(bool setAll)
        {
            if (setAll)
            {
                numMinCapacity.Value = numMinCapacity.Minimum;
                numMaxCapacity.Value = numMaxCapacity.Maximum;
            }
            else
            {
                numMinCapacity.Value = 0m;
                numMaxCapacity.Value = 0m;
            }
        }

        private void cmdSeriePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSerie, true);
        }

        private void cmdSerieUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSerie, false);
        }

        private void cmdVoltagePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage, true);
        }

        private void cmdVoltageUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage, false);
        }

        private void cmdCapacityPickAll_Click(object sender, EventArgs e)
        {
            SetAllCapacity(true);
        }

        private void cmdCapacityUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCapacity(false);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveOption();
        }

        private bool ValidateGroup()
        {
            bool valid = false;

            if (txtGroup.Text.Trim() != "")
            {
                if (!txtGroup.Text.Contains("'"))
                {
                    valid = true;
                }
                else
                {
                    Public.LanguageBox("Group name cannot contain the following character(s) : '", "Le nom de groupe ne peut contenir le/les caractère(s) suivants : '");
                }
            }
            else
            {
                Public.LanguageBox("You must input a group name", "Vous devez entrer un nom de groupe");
            }

            return valid;
        }

        private bool ValidateDescription()
        {
            bool valid = false;

            if (txtDescription.Text.Trim() != "")
            {
                if (!txtDescription.Text.Contains("'"))
                {
                    valid = true;
                }
                else
                {
                    Public.LanguageBox("Description cannot contain the following character(s) : '", "La description ne peut contenir le/les caractère(s) suivants : '");
                }
            }
            else
            {
                Public.LanguageBox("You must input a description", "Vous devez entrer une description");
            }

            return valid;
        }

        private bool SavingConfirmation()
        {
            return Public.LanguageQuestionBox("Are you sure you want to save ?", "Êtes-vous sûr de vouloir sauvegarder ?", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private bool ValidateOverwrite()
        {
            bool valid = true;

            //load option data
            DataTable dtOption = Query.Select("SELECT * FROM EvaporatorOptions WHERE Groupname = '" + txtGroup.Text + "' AND Description = '" + txtDescription.Text + "'");

            if (dtOption.Rows.Count > 0)
            {
                if (Public.LanguageQuestionBox("This option already exist. Do you want to overwrite (yes) or cancel (no) ?", "Cette option existe déja.  Voulez vous l'écraser (Oui) or annuler (Non) ?", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    valid = false;
                }
            }

            dtOption.Dispose();

            return valid;
        }

        private void DeleteSpecificOption(string group, string description)
        {
            Query.Execute("DELETE FROM EvaporatorOptions WHERE Groupname = '" + group + "' AND Description = '" + description + "'");
        }

        //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
        private void ValidateInputsCharacterValidity()
        {
            txtGroup.Text = StringManipulation.FilterInvalidCharacters(txtGroup.Text);
            txtDescription.Text = StringManipulation.FilterInvalidCharacters(txtDescription.Text);
        }

        private void SaveOption()
        {
            //2012-05-24 : #3085 : filtering the text entered in managers for strange characters
            ValidateInputsCharacterValidity();

            if (SavingConfirmation())
            {
                if (ValidateGroup())
                {
                    if (ValidateDescription())
                    {
                        if (ValidateOverwrite())
                        {
                            string group = txtGroup.Text;
                            string description = txtDescription.Text;
                            decimal price = numPrice.Value;

                            string serie = "";

                            for (int i = 0; i < lvSerie.Items.Count; i++)
                            {
                                if (lvSerie.Items[i].SubItems[0].Checked)
                                {
                                    serie += lvSerie.Items[i].SubItems[1].Text + lvSerie.Items[i].SubItems[2].Text + lvSerie.Items[i].SubItems[3].Text + ",";
                                }
                            }

                            decimal minCapacity = numMinCapacity.Value;
                            decimal maxCapacity = numMaxCapacity.Value;

                            string voltage = "";

                            for (int i = 0; i < lvVoltage.Items.Count; i++)
                            {
                                if (lvVoltage.Items[i].SubItems[0].Checked)
                                {
                                    voltage += lvVoltage.Items[i].SubItems[2].Text + ",";
                                }
                            }

                            DeleteSpecificOption(group, description);

                            string tsql = "";
                            tsql += @"INSERT INTO EvaporatorOptions
                                     ([GroupName]
                                     ,[Description]
                                     ,[Price]
                                     ,[Serie]
                                     ,[MinCapacity]
                                     ,[MaxCapacity]
                                     ,[Voltage]
                                     ,[IsRefrigerant]
                                     ,[IsWater])
                               VALUES
                                     ('" + group + @"'
                                     ,'" + description + @"'
                                     ," + price + @"
                                     ,'" + serie + @"'
                                     ," + minCapacity + @"
                                     ," + maxCapacity + @"
                                     ,'" + voltage + @"'
                                     ," + (chkRefrigerant.Checked ? "1" : "0") + @"
                                     ," + (chkWater.Checked ? "1" : "0") + @")";

                            if (Query.Execute(tsql))
                            {
                                //update server
                                Query.UpdateServerTableVersion("EvaporatorOptions");

                                Public.LanguageBox("Save sucessful.", "Sauvegarde reussie.");
                                RefreshOptionList();
                            }
                            else
                            {
                                Public.LanguageBox("Could not save.", "Échec de sauvegarde.");
                            }
                        }
                    }
                }
            }
        }


        private void CheckSerie(string serie)
        {
            for (int i = 0; i < lvSerie.Items.Count; i++)
            {
                if (lvSerie.Items[i].SubItems[1].Text == serie.Substring(0, 1) &&
                    lvSerie.Items[i].SubItems[2].Text == serie.Substring(1, 1) &&
                    lvSerie.Items[i].SubItems[3].Text == serie.Substring(2, 1))
                {
                    lvSerie.Items[i].SubItems[0].Checked = true;
                    i = lvSerie.Items.Count;
                }
            }
        }

        private void CheckVoltage(string voltage)
        {
            for (int i = 0; i < lvVoltage.Items.Count; i++)
            {
                if (Convert.ToInt32(lvVoltage.Items[i].SubItems[2].Text) == Convert.ToInt32(voltage))
                {
                    lvVoltage.Items[i].SubItems[0].Checked = true;
                    i = lvVoltage.Items.Count;
                }
            }
        }

        private void ClearAll()
        {
            txtGroup.Text = "";
            txtDescription.Text = "";
            numPrice.Value = 0m;

            SetAllCheckValues(lvSerie, false);
            SetAllCapacity(false);
            SetAllCheckValues(lvVoltage, false);
        }

        private void DeleteOption()
        {
            if (lvOptionsList.SelectedItems.Count > 0)
            {
                if (Public.LanguageQuestionBox("Are you sure you want to delete the selected option ?", "Êtes-vous sûr de vouloir supprimer l'option selectionnée?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //delete
                    DeleteSpecificOption(((GlacialComponents.Controls.GLItem)lvOptionsList.SelectedItems[0]).SubItems[0].Text, ((GlacialComponents.Controls.GLItem)lvOptionsList.SelectedItems[0]).SubItems[1].Text);

                    //update server
                    Query.UpdateServerTableVersion("EvaporatorOptions");

                    //relod list
                    RefreshOptionList();
                }
            }
        }

        private void LoadOption()
        {
            if (lvOptionsList.SelectedItems.Count > 0)
            {
                //load option data
                DataTable dtOption = Query.Select("SELECT * FROM EvaporatorOptions WHERE Groupname = '" + ((GlacialComponents.Controls.GLItem)lvOptionsList.SelectedItems[0]).SubItems[0].Text + "' AND Description = '" + ((GlacialComponents.Controls.GLItem)lvOptionsList.SelectedItems[0]).SubItems[1].Text + "'");

                //clear
                ClearAll();

                //if data found fill the controls
                if (dtOption.Rows.Count > 0)
                {
                    txtGroup.Text = dtOption.Rows[0]["Groupname"].ToString();
                    txtDescription.Text = dtOption.Rows[0]["Description"].ToString();
                    numPrice.Value = Convert.ToDecimal(dtOption.Rows[0]["Price"]);

                    string[] strSerie = dtOption.Rows[0]["Serie"].ToString().Split(',');

                    foreach (string str in strSerie)
                    {
                        if (str != "")
                            CheckSerie(str);
                    }

                    numMinCapacity.Value = Convert.ToDecimal(dtOption.Rows[0]["MinCapacity"]);
                    numMaxCapacity.Value = Convert.ToDecimal(dtOption.Rows[0]["MaxCapacity"]);

                   
                    string[] strVoltage = dtOption.Rows[0]["Voltage"].ToString().Split(',');

                    foreach (string str in strVoltage)
                    {
                        if (str != "")
                            CheckVoltage(str);
                    }

                    chkRefrigerant.Checked = Convert.ToInt32(dtOption.Rows[0]["IsRefrigerant"]) == 1;
                    chkWater.Checked = Convert.ToInt32(dtOption.Rows[0]["IsWater"]) == 1;
                }

                dtOption.Dispose();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteOption();
        }

        private void lvOptionsList_Click(object sender, EventArgs e)
        {
            LoadOption();
        }

        private void lvOptionsList_SelectedIndexChanged(object source, GlacialComponents.Controls.ClickEventArgs e)
        {
            LoadOption();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            LoadOption();
        }

    }
}