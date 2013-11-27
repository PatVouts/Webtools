using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmControlPanelPanelAndOptionPrices : Form
    {
        private bool _unlockDatagridLoading;

        public FrmControlPanelPanelAndOptionPrices()
        {
            InitializeComponent();
        }

        private void frmControlPanelPanelAndOptionPrices_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_Controls();

            _unlockDatagridLoading = true;

            Fill_Datagrid();
        }

        private void Fill_Controls()
        {
            Fill_Panels();

            Fill_FanArrangement();
        }

        private int GetFanWide()
        {
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboFanArrangement).Substring(0, 1));
        }

        private int GetFanLong()
        {
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboFanArrangement).Substring(1, 1));
        }

        private void Fill_FanArrangement()
        {
            cboFanArrangement.Items.Clear();

            DataTable dtFanArrangement = Query.Select("SELECT * FROM ControlPanel_FanArrangement ORDER BY FanWide, FanLong");

            for (int i = 0; i < dtFanArrangement.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboFanArrangement, dtFanArrangement.Rows[i]["FanWide"] + dtFanArrangement.Rows[i]["FanLong"].ToString(), dtFanArrangement.Rows[i]["FanArrangement"].ToString());
            }

            dtFanArrangement.Dispose();

            cboFanArrangement.SelectedIndex = 0;
        }

        private void Fill_Panels()
        {
            cboPanel.Items.Clear();

            DataTable dtPanels = Query.Select("SELECT * FROM ControlPanel_Panels ORDER BY Panel");

            for (int i = 0; i < dtPanels.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboPanel, dtPanels.Rows[i]["Panel"].ToString(), dtPanels.Rows[i]["Panel"].ToString());
            }

            dtPanels.Dispose();

            cboPanel.SelectedIndex = 0;
        }

        private void Fill_Datagrid()
        {
            if (_unlockDatagridLoading)
            {
                ClearGrid();

                DataTable dtPanelOptionPrice = Query.Select("SELECT * FROM ControlPanel_PanelOptionPrices WHERE Panel = '" + cboPanel.Text + "' AND FanWide = " + GetFanWide() + " AND FanLong = " + GetFanLong());

                if (dtPanelOptionPrice.Rows.Count > 0)
                {

                    DataTable dtPanelPrice = Query.Select("SELECT * FROM ControlPanel_PanelPrices WHERE Panel = '" + cboPanel.Text + "' AND FanWide = " + GetFanWide() + " AND FanLong = " + GetFanLong());

                    if (dtPanelPrice.Rows.Count > 0)
                    {
                        numPanelPrice.Value = Convert.ToDecimal(dtPanelPrice.Rows[0]["Price"]);
                    }

                    DataTable dtPanelSpecialPrice = Query.Select("SELECT * FROM ControlPanel_SpecialPrice WHERE Panel = '" + cboPanel.Text + "' AND FanWide = " + GetFanWide() + " AND FanLong = " + GetFanLong());
                   
                    if (dtPanelSpecialPrice.Rows.Count > 0)
                    {
                        chkSpecialPrice.Checked = (Convert.ToInt32(dtPanelSpecialPrice.Rows[0]["SpecialPrice"]) == 1);
                    }


                    for (int i = 0; i < dtPanelOptionPrice.Rows.Count; i++)
                    {
                        SetGridValue(dtPanelOptionPrice.Rows[i]["Options"].ToString(),
                                     Convert.ToInt32(dtPanelOptionPrice.Rows[i]["VoltageID"]),
                                     Convert.ToDecimal(dtPanelOptionPrice.Rows[i]["Price"]));
                    }
                }
            }
        }

        private void ClearGrid(decimal clearingValue = 0m)
        {
            dgPanelOptionPrices.Rows.Clear();

            DataTable dtOption = Query.Select("SELECT * FROM ControlPanel_Options ORDER BY PanelOption");

            for (int i = 0; i < dtOption.Rows.Count; i++)
            {
                dgPanelOptionPrices.Rows.Add();
            }

            for (int i = 0; i < dtOption.Rows.Count; i++)
            {
                dgPanelOptionPrices.Rows[i].Cells[0].Value = dtOption.Rows[i]["PanelOption"].ToString();
                dgPanelOptionPrices.Rows[i].Cells[1].Value = clearingValue;
                dgPanelOptionPrices.Rows[i].Cells[2].Value = clearingValue;
                dgPanelOptionPrices.Rows[i].Cells[3].Value = clearingValue;
                dgPanelOptionPrices.Rows[i].Cells[4].Value = clearingValue;
                dgPanelOptionPrices.Rows[i].Cells[5].Value = clearingValue;
                dgPanelOptionPrices.Rows[i].Cells[6].Value = clearingValue;
                dgPanelOptionPrices.Rows[i].Cells[7].Value = clearingValue;
            }

            dgPanelOptionPrices.Refresh();
        }

        private void SetGridValue(string strCapLetter, int voltageID, decimal price)
        {
            for (int i = 0; i < dgPanelOptionPrices.Rows.Count; i++)
            {
                if (dgPanelOptionPrices.Rows[i].Cells[0].Value.ToString() == strCapLetter)
                {
                    dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(voltageID)].Value = price;
                    i = dgPanelOptionPrices.Rows.Count;
                }
            }
        }

        private int GetVoltageIndexColumn(int voltageID)
        {
            int columnIndex = 0;

            switch (voltageID)
            {
                case 1:
                    columnIndex = 1;
                    break;
                case 2:
                    columnIndex = 2;
                    break;
                case 3:
                    columnIndex = 3;
                    break;
                case 5:
                    columnIndex = 4;
                    break;
                case 6:
                    columnIndex = 5;
                    break;
                case 8:
                    columnIndex = 6;
                    break;
                case 9:
                    columnIndex = 7;
                    break;
            }

            return columnIndex;
        }

        private void cboPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Datagrid();
        }

        private void cboFanArrangement_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Datagrid();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool AreValueValid()
        {
            for (int i = 0; i < dgPanelOptionPrices.Rows.Count; i++)
                {
                    decimal testDecimal;
                    if (!Decimal.TryParse(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(1)].Value.ToString(), out testDecimal))
                    {
                        return false;
                    }
                    if (!Decimal.TryParse(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(2)].Value.ToString(), out testDecimal))
                    {
                        return false;
                    }
                    if (!Decimal.TryParse(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(3)].Value.ToString(), out testDecimal))
                    {
                        return false;
                    }
                    if (!Decimal.TryParse(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(5)].Value.ToString(), out testDecimal))
                    {
                        return false;
                    }
                    if (!Decimal.TryParse(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(6)].Value.ToString(), out testDecimal))
                    {
                        return false;
                    }
                    if (!Decimal.TryParse(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(8)].Value.ToString(), out testDecimal))
                    {
                        return false;
                    }
                    if (!Decimal.TryParse(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(9)].Value.ToString(), out testDecimal))
                    {
                        return false;
                    }

                   if(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(1)].Value.ToString().Trim() == "") 
                   {
                       return false;
                   }
                   if(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(2)].Value.ToString().Trim() == "") 
                   {
                       return false;
                   }
                   if(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(3)].Value.ToString().Trim() == "")
                   {
                       return false;
                   }
                   if(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(5)].Value.ToString().Trim() == "")
                   {
                       return false;
                   }
                   if(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(6)].Value.ToString().Trim() == "")
                   {
                       return false;
                   }
                   if(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(7)].Value.ToString().Trim() == "") 
                   {
                       return false;
                   }
                   if(dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(9)].Value.ToString().Trim() == "")
                   {
                       return false;
                   }
                }
        
            return true;
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save ?", "Êtes-vous sûr de vouloir sauvegarder ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (AreValueValid())
                {
                    ThreadProcess.Start(Public.LanguageString("Saving in progress. Please wait", "Sauvegarde en cours. Veuillez patienter."));

                    DataTable dtPanelOptionPrices = Query.Select("SELECT * FROM ControlPanel_PanelOptionPrices WHERE Panel = '" + cboPanel.Text + "' AND FanWide = " + GetFanWide() + " AND FanLong = " + GetFanLong());
                    dtPanelOptionPrices.Rows.Clear();

                    for (int i = 0; i < dgPanelOptionPrices.Rows.Count; i++)
                    {
                        //Voltage 1
                        DataRow dr = dtPanelOptionPrices.NewRow();
                        dr["Panel"] = cboPanel.Text;
                        dr["FanWide"] = GetFanWide();
                        dr["FanLong"] = GetFanLong();
                        dr["VoltageID"] = 1;
                        dr["Options"] = dgPanelOptionPrices.Rows[i].Cells[0].Value;
                        dr["Price"] = dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(1)].Value;
                        dtPanelOptionPrices.Rows.Add(dr);

                        //Voltage 2
                        dr = dtPanelOptionPrices.NewRow();
                        dr["Panel"] = cboPanel.Text;
                        dr["FanWide"] = GetFanWide();
                        dr["FanLong"] = GetFanLong();
                        dr["VoltageID"] = 2;
                        dr["Options"] = dgPanelOptionPrices.Rows[i].Cells[0].Value;
                        dr["Price"] = dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(2)].Value;
                        dtPanelOptionPrices.Rows.Add(dr);

                        //Voltage 3
                        dr = dtPanelOptionPrices.NewRow();
                        dr["Panel"] = cboPanel.Text;
                        dr["FanWide"] = GetFanWide();
                        dr["FanLong"] = GetFanLong();
                        dr["VoltageID"] = 3;
                        dr["Options"] = dgPanelOptionPrices.Rows[i].Cells[0].Value;
                        dr["Price"] = dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(3)].Value;
                        dtPanelOptionPrices.Rows.Add(dr);

                        //Voltage 5
                        dr = dtPanelOptionPrices.NewRow();
                        dr["Panel"] = cboPanel.Text;
                        dr["FanWide"] = GetFanWide();
                        dr["FanLong"] = GetFanLong();
                        dr["VoltageID"] = 5;
                        dr["Options"] = dgPanelOptionPrices.Rows[i].Cells[0].Value;
                        dr["Price"] = dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(5)].Value;
                        dtPanelOptionPrices.Rows.Add(dr);

                        //Voltage 6
                        dr = dtPanelOptionPrices.NewRow();
                        dr["Panel"] = cboPanel.Text;
                        dr["FanWide"] = GetFanWide();
                        dr["FanLong"] = GetFanLong();
                        dr["VoltageID"] = 6;
                        dr["Options"] = dgPanelOptionPrices.Rows[i].Cells[0].Value;
                        dr["Price"] = dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(6)].Value;
                        dtPanelOptionPrices.Rows.Add(dr);

                        //Voltage 8
                        dr = dtPanelOptionPrices.NewRow();
                        dr["Panel"] = cboPanel.Text;
                        dr["FanWide"] = GetFanWide();
                        dr["FanLong"] = GetFanLong();
                        dr["VoltageID"] = 8;
                        dr["Options"] = dgPanelOptionPrices.Rows[i].Cells[0].Value;
                        dr["Price"] = dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(8)].Value;
                        dtPanelOptionPrices.Rows.Add(dr);

                        //Voltage 9
                        dr = dtPanelOptionPrices.NewRow();
                        dr["Panel"] = cboPanel.Text;
                        dr["FanWide"] = GetFanWide();
                        dr["FanLong"] = GetFanLong();
                        dr["VoltageID"] = 9;
                        dr["Options"] = dgPanelOptionPrices.Rows[i].Cells[0].Value;
                        dr["Price"] = dgPanelOptionPrices.Rows[i].Cells[GetVoltageIndexColumn(9)].Value;
                        dtPanelOptionPrices.Rows.Add(dr);
                    }

                    Query.Execute("UPDATE ControlPanel_PanelPrices SET Price = " + numPanelPrice.Value + " WHERE Panel = '" + cboPanel.Text + "' AND FanWide = " + GetFanWide() + " AND FanLong = " + GetFanLong());

                    Query.Execute("UPDATE ControlPanel_SpecialPrice SET SpecialPrice = " + (chkSpecialPrice.Checked ? "1" : "0") + " WHERE Panel = '" + cboPanel.Text + "' AND FanWide = " + GetFanWide() + " AND FanLong = " + GetFanLong());

                    Query.Execute("DELETE FROM ControlPanel_PanelOptionPrices WHERE Panel = '" + cboPanel.Text + "' AND FanWide = " + GetFanWide() + " AND FanLong = " + GetFanLong());

                    for (int i = 0; i < dtPanelOptionPrices.Rows.Count; i++)
                    {
                        Query.Execute(Query.BuildInsertQueryPerRow(dtPanelOptionPrices, i, "ControlPanel_PanelOptionPrices"));
                    }

                    Query.UpdateServerTableVersion("ControlPanel_PanelPrices");
                    Query.UpdateServerTableVersion("ControlPanel_PanelOptionPrices");
                    Query.UpdateServerTableVersion("ControlPanel_SpecialPrice");

                    ThreadProcess.Stop();
                    Focus();
                }
                else
                {
                    Public.LanguageBox("One or more price entered is/are invalid.", "Un ou plusieurs prix est/sont invalide(s).");
                }
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ClearGrid(-1000000m);
        }

        private void cmdMultiUpdate_Click(object sender, EventArgs e)
        {
            var updater = new FrmMultiUpdateControlPanelOptions();
            updater.ShowDialog();
            Fill_Datagrid();
        }
    }
}