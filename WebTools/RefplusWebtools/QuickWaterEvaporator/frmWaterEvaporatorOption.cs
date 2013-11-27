using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.QuickWaterEvaporator
{
    public partial class FrmWaterEvaporatorOption : Form
    {
        private readonly string[] _strTableList = { "EvaporatorOptions" };

        private bool _openQuote;
        private string _evaporatorType = "";
        private string _style = "";
        private string _defrostType = "";
        private decimal _capacity;
        private string _voltageID = "";

        private DataTable _dtOptionList;
        private readonly List<Panel> _options = new List<Panel>();
        private readonly Dictionary<string, Label> _priceLabels = new Dictionary<string, Label>();

        //link to the quote form
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;

        public FrmWaterEvaporatorOption(bool openQuote, string evaporatorType, string style, string defrostType, decimal capacity, string voltageID, DataSet dsQuoteData, int intIndex)
        {
            FormConstructor(openQuote, evaporatorType, style, defrostType, capacity, voltageID);

            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
        }

        public FrmWaterEvaporatorOption(bool openQuote, string evaporatorType, string style, string defrostType, decimal capacity, string voltageID)
        {
            FormConstructor(openQuote, evaporatorType, style, defrostType, capacity, voltageID);
        }

        private void FormConstructor(bool openQuote, string evaporatorType, string style, string defrostType, decimal capacity, string voltageID)
        {
            InitializeComponent();

            _openQuote = openQuote;
            _evaporatorType = evaporatorType;
            _style = style;
            _defrostType = defrostType;
            _capacity = capacity;
            _voltageID = voltageID;

        }

        public DataTable OptionInput { get; private set; }

        private void frmWaterEvaporatorOption_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Query.LoadTables(_strTableList);

            LoadOptionsList();

            CreateOptions();

            DisplayOptions();

            if (_intIndex != -1)
            {
                LoadSavedData();
            }
        }

        private void LoadOptionsList()
        {
            _dtOptionList = Public.SelectAndSortTable(Public.DSDatabase.Tables["EvaporatorOptions"], "Serie LIKE '%" + _evaporatorType + _style + _defrostType + "%' AND MinCapacity <= " + _capacity + " AND MaxCapacity >= " + _capacity + " AND Voltage LIKE '%" + _voltageID + "%' AND IsWater = 1", "GroupName, Description");
        }

        private void DisplayOptions()
        {
            if (_dtOptionList.Rows.Count > 0)
            {
                int topLocation = 0;

                for (int i = 0; i < _options.Count; i++)
                {
                    pnlContainer.Controls.Add(_options[i]);

                    _options[i].Left = 0;
                    _options[i].Top = topLocation;
                    topLocation += _options[i].Height;
                }
            }

            Refresh();
        }

        private void LoadSavedData()
        {
            DataTable dtOptions = Public.SelectAndSortTable(_dsQuoteData.Tables["WaterEvaporatorOption"], "ItemID = " + _intIndex, "");

            //loop on each option saved
            foreach (DataRow drSavedOption in dtOptions.Rows)
            {
                //then search if a panel "group" may apply
                foreach (Panel p in _options)
                {
                    //will store group / desc for check

                    //this containt the group and the type of control
                    string[] panelTag = p.Tag.ToString().Split(new[] { "|||" }, StringSplitOptions.None);

                    //store the group
                    string group = panelTag[0];

                    //check each object in the panel for the proper control
                    foreach (object o in p.Controls)
                    {
                        //if we look for checkbox
                        string description;
                        if (panelTag[1] == "CHK")
                        {
                            if (o.GetType() == typeof(CheckBox))
                            {
                                //store description
                                description = ((CheckBox)o).Text;

                                //if i actually have this group / desc combinaison saved
                                //that mean it was selected so we check it
                                if (drSavedOption["GroupName"].ToString() == group &&
                                    drSavedOption["Description"].ToString() == description)
                                {
                                    ((CheckBox)o).Checked = true;
                                }
                            }
                        }
                        else
                        {//if i look for combobox
                            if (o.GetType() == typeof(ComboBox))
                            {
                                //for cbo i need to loop throught items to find
                                //out is the description exist within it
                                for (int i = 0; i < ((ComboBox)o).Items.Count; i++)
                                {
                                    //strop description
                                    description = ((ComboBox)o).Items[i].ToString();

                                    //if i actually have this group / desc combinaison saved
                                    //that mean it was selected so we select the proper item
                                    if (drSavedOption["GroupName"].ToString() == group &&
                                    drSavedOption["Description"].ToString() == description)
                                    {
                                        ((ComboBox)o).SelectedIndex = i;
                                        //we make sure to break out the loop
                                        //otherwise it will continue and may drop on another control.
                                        i = ((ComboBox)o).Items.Count;
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        private void CreateOptions()
        {
            if (_dtOptionList.Rows.Count > 0)
            {
                //first list the groups
                List<string> groups = GetFilteredGroups();

                for (int i = 0; i < groups.Count; i++)
                {
                    _options.Add(CreatePanelControl(groups[i]));
                }
            }
        }

        private List<string> GetFilteredGroups()
        {
            //in case of only 1 option left and if it's none we need to remove it.

            //list the groups
            List<string> groups = GetGroups();

            //will contai all valid groups
            var validGroups = new List<string>();

            foreach (string group in groups)
            {
                DataTable dtGroup = Public.SelectAndSortTable(_dtOptionList, "GroupName = '" + group + "'", "");

                bool groupValid = true;

                if (dtGroup.Rows.Count == 1)
                {
                    if (dtGroup.Rows[0]["Description"].ToString() == "none")
                    {
                        groupValid = false;
                    }
                }

                if (groupValid)
                {
                    validGroups.Add(group);
                }
            }

            return groups;
        }

        private List<string> GetGroups()
        {
            var groups = new List<string>();

            for (int i = 0; i < _dtOptionList.Rows.Count; i++)
            {
                bool groupExist = false;

                string currentGroup = _dtOptionList.Rows[i]["GroupName"].ToString();

                for (int s = 0; s < groups.Count; s++)
                {
                    if (currentGroup == groups[s])
                    {
                        groupExist = true;
                        s = groups.Count;
                    }
                }

                if (!groupExist)
                {
                    groups.Add(currentGroup);
                }
            }

            return groups;
        }

        private ComboBox GetOptionComboBox(string group)
        {
            var cbo = new ComboBox
            {
                Tag = group,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 510,
                DropDownWidth = 510
            };
            cbo.SelectedIndexChanged += cbo_SelectedIndexChanged;
            return cbo;
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string group = ((ComboBox)sender).Tag.ToString();
            string description = ((ComboBox)sender).Text;

            DataTable dtPrice = Public.SelectAndSortTable(_dtOptionList, "GroupName = '" + group + "' AND Description = '" + description + "'", "");

            decimal decPrice = 0m;

            if (_dtOptionList.Rows.Count > 0)
            {
                decPrice = Convert.ToDecimal(dtPrice.Rows[0]["Price"]);
            }

            dtPrice.Dispose();

            _priceLabels[group].Text = decPrice.ToString("N2") + @" $";
        }

        private Panel CreatePanelControl(string group)
        {
            Panel p = null;

            DataTable dtGroup = Public.SelectAndSortTable(_dtOptionList, "GroupName = '" + group + "'", "");

            int quantityInGroup = dtGroup.Rows.Count;

            if (quantityInGroup > 0)
            {
                p = new Panel {Width = 900, Height = 35, Tag = @group + "|||" + (quantityInGroup == 1 ? "CHK" : "CBO")};
                //extra ||| and chk or cbo is so i can know by looking at the tag
                //that the control im looking for is a checkbox of combobox

                //price label
                Label priceLabel = GetPriceLabel((quantityInGroup == 1 ? dtGroup.Rows[0]["Price"].ToString() : "0"));
                p.Controls.Add(priceLabel);
                priceLabel.Left = 816;
                priceLabel.Top = 8;
                _priceLabels.Add(@group, priceLabel);

                //if 2 or more item or 1 item but group and description different
                //we show the group label
                if (quantityInGroup > 1 || (quantityInGroup == 1 && @group != dtGroup.Rows[0]["Description"].ToString()))
                {
                    Label groupLabel = GetGroupLabel(@group);
                    p.Controls.Add(groupLabel);
                    groupLabel.Left = 3;
                    groupLabel.Top = 11;

                    Label dottedLine = Public.GetDottedLine();
                    p.Controls.Add(dottedLine);
                    dottedLine.Left = 3;
                    dottedLine.Top = 11;
                    dottedLine.SendToBack();
                }

                if (quantityInGroup == 1)
                {
                    CheckBox checkOption = GetOptionCheckBox(group, dtGroup.Rows[0]["Description"].ToString());
                    p.Controls.Add(checkOption);
                    checkOption.Left = 300;
                    checkOption.Top = 8;
                }
                else
                {
                    ComboBox comboOption = GetOptionComboBox(group);
                    int longestStringSize = 0;
                    for (int i = 0; i < dtGroup.Rows.Count; i++)
                    {
                        comboOption.Items.Add(dtGroup.Rows[i]["Description"].ToString());
                        longestStringSize = Math.Max(longestStringSize, TextRenderer.MeasureText(dtGroup.Rows[i]["Description"].ToString(), comboOption.Font).Width + 4 * GetNonAlphanumericCharacterAmount(dtGroup.Rows[i]["Description"].ToString()));
                    }

                    comboOption.DropDownWidth = longestStringSize + 10;

                    p.Controls.Add(comboOption);
                    comboOption.Left = 300;
                    comboOption.Top = 8;
                    comboOption.SelectedIndex = comboOption.FindString("none") >= 0 ? comboOption.FindString("none") : 0;
                }
            }

            dtGroup.Dispose();

            return p;
        }


        private bool IsAlphaNumericOrSpace(string character)
        {
            return char.IsLetterOrDigit(character, 0) || character == " ";
        }

        private int GetNonAlphanumericCharacterAmount(string text)
        {
            int nonAlphaNumericCharacterAmount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (!IsAlphaNumericOrSpace(text.Substring(i, 1)))
                {
                    ++nonAlphaNumericCharacterAmount;
                }
            }

            return nonAlphaNumericCharacterAmount;
        }

        private CheckBox GetOptionCheckBox(string group, string description)
        {
            var chk = new CheckBox
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Text = description,
                Tag = group,
                AutoSize = true,
                Checked = false
            };
            return chk;
        }

        private Label GetGroupLabel(string group)
        {
            var l = new Label {Tag = "GROUP", Text = group, AutoSize = true};
            return l;
        }

        private Label GetPriceLabel(string price)
        {
            var l = new Label
            {
                Tag = "PRICE",
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(255, 255, 192),
                TextAlign = ContentAlignment.MiddleRight,
                Width = 77,
                Height = 21,
                Text = Convert.ToDecimal(price).ToString("N2") + @" $",
                Visible = _openQuote
            };
            //if open from quote the price show up. otherwise we simply hide it visually
            return l;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            OptionSaveTable();

            Close();
        }

        private void OptionSaveTable()
        {
            OptionInput = Tables.DtWaterEvaporatorOptions();

            foreach (Panel p in _options)
            {
                DataRow drSaveTable = OptionInput.NewRow();
                drSaveTable = Tables.SetToZero(drSaveTable);

                string[] panelTag = p.Tag.ToString().Split(new[] { "|||" }, StringSplitOptions.None);

                drSaveTable["GroupName"] = panelTag[0];

                //in some case we do not want
                bool addOption = true;

                foreach (object o in p.Controls)
                {
                    if (panelTag[1] == "CHK")
                    {
                        if (o.GetType() == typeof(CheckBox))
                        {
                            drSaveTable["Description"] = ((CheckBox)o).Text;

                            //if it's not checked we do not show
                            if (!((CheckBox)o).Checked)
                            {
                                addOption = false;
                            }
                        }
                    }
                    else
                    {
                        if (o.GetType() == typeof(ComboBox))
                        {
                            drSaveTable["Description"] = ((ComboBox)o).Text;

                            //none option is not valid to add
                            if (((ComboBox)o).Text.ToUpper() == "NONE")
                            {
                                addOption = false;
                            }
                        }
                    }
                }

                drSaveTable["Price"] = Convert.ToDecimal(_priceLabels[panelTag[0]].Text.Replace("$", "").Replace(" ", ""));

                if (addOption)
                {
                    OptionInput.Rows.Add(drSaveTable);
                }
            }
        }

    }
}