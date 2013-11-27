using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCondensingUnit
{
    public partial class FrmCondensingUnitOption : Form
    {
        private readonly string[] _strTableList = { "CondensingUnitOptions" };

        private bool _openQuote;
        private string _unitType = "";
        private string _airFlow = "";
        private string _compressorType = "";
        private string _hp = "";
        private string _numberOfCompressor = "";
        private string _compressorManufacturer = "";
        private string _application = "";
        private string _refrigerantType = "";
        private string _voltageID = "";
        private string _unitOptions = "";

        private Boolean _digitalPossible;

        private DataTable _dtOptionList;
        private readonly List<Panel> _options = new List<Panel>();
        private readonly Dictionary<string, Label> _priceLabels = new Dictionary<string, Label>();

        //link to the quote form
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;

        public FrmCondensingUnitOption(bool openQuote, string unitType, string airFlow, string compressorType, string hp, string numberOfCompressor, string compressorManufacturer, string application, string refrigerantType, string voltageID, string unitOptions, DataSet dsQuoteData, int intIndex)
        {
            FormConstructor(openQuote, unitType, airFlow, compressorType, hp, numberOfCompressor, compressorManufacturer, application, refrigerantType, voltageID, unitOptions);

            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
        }

        public FrmCondensingUnitOption(bool openQuote, string unitType, string airFlow, string compressorType, string hp, string numberOfCompressor, string compressorManufacturer, string application, string refrigerantType, string voltageID, string unitOptions)
        {
            FormConstructor(openQuote, unitType, airFlow, compressorType, hp, numberOfCompressor, compressorManufacturer, application, refrigerantType, voltageID, unitOptions);
        }

        private void FormConstructor(bool openQuote, string unitType, string airFlow, string compressorType, string hp, string numberOfCompressor, string compressorManufacturer, string application, string refrigerantType, string voltageID, string unitOptions)
        {
            InitializeComponent();

            _openQuote = openQuote;
            _unitType = unitType;
            _airFlow = airFlow;
            _compressorType = compressorType;
            _hp = hp;
            _numberOfCompressor = numberOfCompressor;
            _compressorManufacturer = compressorManufacturer;
            _application = application;
            _refrigerantType = refrigerantType;
            _voltageID = voltageID;
            _unitOptions = unitOptions;
        }

        public DataTable GetOptionInput { get; private set; }

        private void frmCondensingUnitOption_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            LoadOptionsList();

            CreateOptions();

            DisplayOptions();

            if (_intIndex != -1)
            {
                LoadSavedData();
            }
        }

        private void LoadSavedData()
        {
            DataTable dtOptions = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitOption"], "ItemID = " + _intIndex, "");

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

        private string OptionsFilter()
        {
            string strFilter = "";

            string[] strOptionList = _unitOptions.Split(',');

            for (int i = 0; i < strOptionList.Length; i++)
            {
                if (strOptionList[i] != "")
                {
                    //2011-07-13 : Simon wnat ot change the way drawing selection is done
                    //we now change o pick per letter and not as combo
                    strFilter += " OR Options LIKE '%" + strOptionList[i] + "%' ";
                    //strFilter += " AND Options LIKE '%" + strOptionList[i] + "%' ";
                }
            }

            strFilter =" AND (" + strFilter.Substring(4) + ")";

            return strFilter;
        }

        private void LoadOptionsList()
        {
            _dtOptionList = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitOptions"], "FirstPart LIKE '%" + _unitType + _airFlow + _compressorType + "%' AND MinHP <= " + _hp + " AND MaxHP >= " + _hp + " AND Compressor LIKE '%" + _numberOfCompressor.PadLeft(2, '0') + "%' AND ThirdPart LIKE '%" + _compressorManufacturer + _application + _refrigerantType + "%' AND Voltage LIKE '%" + _voltageID + "%' " + OptionsFilter(), "GroupName, Description");
        }

        private void DisplayOptions()
        {
            //2011-09-14 : #1356 : change the way the options are diplayed
            if (_dtOptionList.Rows.Count > 0)
            {
                //bool DrawLeftSide = true;
                int topLocation = 0;

                for (int i = 0; i < _options.Count; i++)
                {
                    pnlContainer.Controls.Add(_options[i]);
                    //if (DrawLeftSide)
                    //{
                        _options[i].Left = 0;
                        _options[i].Top = topLocation;
                    //    DrawLeftSide = false;
                    //}
                    //else
                    //{
                    //    Options[i].Left = Options[i].Width;
                    //    Options[i].Top = TopLocation;
                    //    DrawLeftSide = true;
                        topLocation += _options[i].Height;
                    //}
                }
            }

            Refresh();
        }

        private void CreateOptions()
        {
            if (_dtOptionList.Rows.Count > 0)
            {
                //first list the groups
                List<string> groups = GetFilteredGroups();         

                for (int i = 0; i < groups.Count; i++)
                {
                    //2011-08-25 : #983 : dont show option if only option is none and checkbox
                    //now the CreatePanelControl() can return null
                    Panel pGroup = CreatePanelControl(groups[i]);
                    if (pGroup != null)
                    {
                        _options.Add(pGroup);
                    }
                }
            }
        }

        private Panel CreatePanelControl(string @group)
        {
            //2011-09-14 : #1356 : change the way the options are diplayed
            Panel p = null;

            DataTable dtGroup = Public.SelectAndSortTable(_dtOptionList, "GroupName = '" + @group + "'", "");

            int quantityInGroup = dtGroup.Rows.Count;

            //2011-08-25 : #983 : dont show option if only option is none and checkbox
            if (quantityInGroup == 1 && dtGroup.Rows[0]["Description"].ToString() == "None")
            {
                quantityInGroup = 0;
            }

            if (quantityInGroup > 0)
            {
                p = new Panel {Width = 900, Height = 35, Tag = @group + "|||" + (quantityInGroup == 1 ? "CHK" : "CBO")};
                //p.Width = 450;
                //extra ||| and chk or cbo is so i can know by looking at the tag
                //that the control im looking for is a checkbox of combobox

                //price label
                Label priceLabel = GetPriceLabel((quantityInGroup == 1 ? dtGroup.Rows[0]["Price"].ToString() : "0"));
                p.Controls.Add(priceLabel);
                priceLabel.Left = 816;
                //PriceLabel.Left = 366;
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
                    
                    //the new dotted line when the group label show up
                    Label dottedLine = Public.GetDottedLine();
                    p.Controls.Add(dottedLine);
                    dottedLine.Left = 3;
                    dottedLine.Top = 11;
                    dottedLine.SendToBack();
                }

                if (quantityInGroup == 1)
                {
                    CheckBox checkOption = GetOptionCheckBox(@group, dtGroup.Rows[0]["Description"].ToString());
                    p.Controls.Add(checkOption);
                    checkOption.Left = 300;
                    //CheckOption.Left = 160;
                    checkOption.Top = 8;
                }
                else
                {
                    ComboBox comboOption = GetOptionComboBox(@group);
                    int longestStringSize = 0;
                    for (int i = 0; i < dtGroup.Rows.Count; i++)
                    {
                        comboOption.Items.Add(dtGroup.Rows[i]["Description"].ToString());

                        //2011-09-13 : #1309 , drop down width too small sometime. added 4 px per non alpha numeric
                        longestStringSize = Math.Max(longestStringSize, TextRenderer.MeasureText(dtGroup.Rows[i]["Description"].ToString(), comboOption.Font).Width + 4 * GetNonAlphanumericCharacterAmount(dtGroup.Rows[i]["Description"].ToString()));
                    }

                    comboOption.DropDownWidth = longestStringSize + 10;
                    
                    p.Controls.Add(comboOption);
                    comboOption.Left = 300;
                    //ComboOption.Left = 160;
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

        private ComboBox GetOptionComboBox(string @group)
        {
            var cbo = new ComboBox
            {
                Tag = @group,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 510,
                DropDownWidth = 510
            };
            //cbo.Width = 200;
            //cbo.DropDownWidth = 350;
            cbo.SelectedIndexChanged += cbo_SelectedIndexChanged;
            return cbo;
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string group = ((ComboBox)sender).Tag.ToString();
            string description = ((ComboBox)sender).Text;

            DataTable dtPrice = Public.SelectAndSortTable(_dtOptionList, "GroupName = '" + group + "' AND Description = '" + description + "'", "");

            decimal decPrice = 0m;

            if (dtPrice.Rows.Count > 0)
            {
                decPrice = Convert.ToDecimal(dtPrice.Rows[0]["Price"]);
            }

            dtPrice.Dispose();

            _priceLabels[group].Text = decPrice.ToString("N2") + @" $";
        }

        private CheckBox GetOptionCheckBox(string @group, string description)
        {
            var chk = new CheckBox
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Text = description,
                Tag = @group,
                AutoSize = true,
                Checked = false
            };
            return chk;
        }

        private Label GetGroupLabel(string @group)
        {
            var l = new Label {Tag = "GROUP", Text = @group, AutoSize = true};
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
                    if (currentGroup.Contains("Digital"))
                    {
                        _digitalPossible = true;
                    }
                }
            }

            return groups;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {

            bool saved = false;
            
            if (_digitalPossible )
            {
                foreach (Panel p in _options)
                {
                    string[] panelTag = p.Tag.ToString().Split(new[] { "|||" }, StringSplitOptions.None);
                    if (panelTag[0] == "Digital Kit")
                    {
                        foreach (object o in p.Controls)
                        {
                            if (o.GetType() == typeof(ComboBox))
                            {
                                if (((ComboBox)o).Text == @"None")
                                {
                                    Public.LanguageBox("Your unit must have a selected digital kit, yet you chose none.  Please correct and retry.  Thank you!", "Votre unité doit absolument avoir un kit digital, mais vous n'en avez sélectionné aucun.  Veuillez corriger, puis sauvegarder à nouveau.  Merci!");
                                    break;
                                }
                                if(!saved)
                                {
                                    OptionSaveTable();
                                    DialogResult = DialogResult.OK;
                                        
                                    saved = true;
                                }
                            }
                        }
                    }
                    
                }
            }
            else
             {
                OptionSaveTable();
                DialogResult = DialogResult.OK;
                Close();    
            }
            if (saved)
            {
                Close();
            }
            
        }

        private void OptionSaveTable()
        {
            GetOptionInput = Tables.DtCondensingUnitOptions();

            foreach (Panel p in _options)
            {
                DataRow drSaveTable = GetOptionInput.NewRow();
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
                    GetOptionInput.Rows.Add(drSaveTable);
                }
            }
        }
    }
}