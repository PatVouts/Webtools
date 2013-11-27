using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.AdvancedSearch
{
    public partial class FrmAdvancedSearch : Form
    {
        //prebuilding lists of controls that will grow depending on what the user selects as filters
        private readonly string[] _strTableList = { "AdvancedSearch" };
        private readonly List<Panel> _filterPanels = new List<Panel>();
        private readonly List<Label> _lblFieldName = new List<Label>();
        private readonly List<ComboBox> _cboTextFilter = new List<ComboBox>();
        private readonly List<ComboBox> _cboDateFilter = new List<ComboBox>();
        private readonly List<DateTimePicker> _dtPickerList = new List<DateTimePicker>();
        private readonly List<TextBox> _txtFilterList = new List<TextBox>();
        private readonly List<NumericUpDown> _numUpDownList = new List<NumericUpDown>();
        private readonly List<ComboBox> _numUpDownFilter = new List<ComboBox>();
        private readonly List<Button> _removeButtonList = new List<Button>();
        private DataTable _dt;
        private readonly FrmMain _mainForm;
        private int _controlTag;
        readonly List<Filter> _lstFilter = new List<Filter>();

        //Standard builder, used to assign the parent form so we know in which "parent" to load the quote.
        public FrmAdvancedSearch(FrmMain parentForm)
        {
            InitializeComponent();
            _mainForm = parentForm;
        }

        //Simply adding the filter (see class in same namespace) to the full list of filters to be offered to the user
        private void LoadFilters()
        {
            DataTable dtAdvancedSearch = Public.SelectAndSortTable(Public.DSDatabase.Tables["AdvancedSearch"], "", Public.Language == "EN" ? "EnglishText" : "FrenchText");
            foreach (DataRow dr in dtAdvancedSearch.Rows)
            {
                //The filter already builds its data according to the ID passed and the table in the base, so we just need to pass an id to the constructor, then add the datarow it gives.
                _lstFilter.Add(new Filter(Convert.ToInt32(dr["ID"])));
            }
        }

        //Simple load, changing the color of the site you're on and the language you chose, plus loading the table for the advanced search)
        private void frmAdvancedSearch_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
            Query.LoadTables(_strTableList);
            LoadFilters();
            FillFilter(cboFilter);
        }

        //Forcing selectionLength to the length of the text you chose in any text box on entering the control.  Like that, when you tab in the control (or click in it), you select the text in it
        
        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        //creates a new combobox and fills it with string filters and assigns
        //a tag to it for easy reference
        private static ComboBox AddTextFilterComboBox(int tag)
        {
            var cbo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = tag,
                Width = 160,
                DropDownWidth = 200
            };
            ComboBoxControl.AddItem(cbo, "=", Public.LanguageString("Equal to", "Égal à"));
            ComboBoxControl.AddItem(cbo, "LIKE", Public.LanguageString("Like", "Comme"));
            ComboBoxControl.SetIDDefaultValue(cbo, "=");
            return cbo;
        }

        //creates a new TextBox and assigns a tag to it for easy reference
        private TextBox AddTextBox(int tag)
        {
            var txt = new TextBox {Tag = tag, Width = 200, Height = 25};
            txt.Enter += AutoSelectTextBox_Enter;
            return txt;
        }

        //creates a new DateTime filter to the list of filters and assigns a tag to it for easy reference
        private ComboBox AddDateFilterComboBox(int tag)
        {
            var cbo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = tag,
                Width = 160,
                DropDownWidth = 200
            };
            ComboBoxControl.AddItem(cbo, "<", Public.LanguageString("Less than", "Moins de"));
            ComboBoxControl.AddItem(cbo, ">", Public.LanguageString("Greater than", "Plus de"));
            ComboBoxControl.AddItem(cbo, "<=", Public.LanguageString("Less than or equal to", "Inférieur ou égal à"));
            ComboBoxControl.AddItem(cbo, ">=", Public.LanguageString("Greater than or equal to", "Supérieur ou égal à"));
            ComboBoxControl.AddItem(cbo, "=", Public.LanguageString("Equal to", "Égal à"));
            ComboBoxControl.SetIDDefaultValue(cbo, "=");
            return cbo;
        }

        //creates a new DateTimePicker and assigns a tag to it for easy reference
        private DateTimePicker AddDateTimePicker(int tag)
        {
            var dtPicker = new DateTimePicker {Width = 200, Height = 200, Tag = tag};
            return dtPicker;
        }

        //Adding a NumericUpDown box and assigning a tag for reference
        private NumericUpDown AddNumUpDown(int tag)
        {
            var numUpDown = new NumericUpDown {Width = 200, Height = 25, Maximum = 100000000, Tag = tag};
            return numUpDown;
        }

        //Adding a filter for a numerical Up Down selected by the user.
        private ComboBox AddNumUpDownFilter(int tag)
        {
            var cbo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = tag,
                Width = 160,
                DropDownWidth = 200
            };
            ComboBoxControl.AddItem(cbo, "<", Public.LanguageString("Less than", "Moins de"));
            ComboBoxControl.AddItem(cbo, ">", Public.LanguageString("Greater than", "Plus de"));
            ComboBoxControl.AddItem(cbo, "<=", Public.LanguageString("Less than or equal to", "Inférieur ou égal à"));
            ComboBoxControl.AddItem(cbo, ">=", Public.LanguageString("Greater than or equal to", "Supérieur ou égal à"));
            ComboBoxControl.AddItem(cbo, "=", Public.LanguageString("Equal to", "Égal à"));
            ComboBoxControl.SetIDDefaultValue(cbo, "=");
            return cbo;
        }

        //Adding a button and giving it an easy tag.  Button will remove the filter.
        private Button AddButton(int tag)
        {
            var button = new Button
            {
                Tag = tag,
                Text = @"X",
                BackColor = Color.DarkRed,
                ForeColor = Color.White,
                Size = new Size(27, 25),
                Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat
            };
            button.Click += button_Click;
            return button;
        }

        //Remove the filter when the red X is pressed
        private void button_Click(object sender, EventArgs e)
        {
            RemovePanel(Convert.ToInt32(((Button)sender).Tag.ToString()));
        }

        //method used to refresh the panels in the search
        private void RefreshPanels()
        {
            int top = 0;
            foreach (Panel p in _filterPanels)
            {
                if (p.Visible)
                {
                    p.Left = 0;
                    p.Top = top;
                    top = p.Bottom - 1;
                }                
            }
        }

        //Getting the text filter in a certain criteria
        private string GetTextFilter(int tag)
        {
            foreach (ComboBox cbo in _cboTextFilter)
            {
                if (cbo.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                {
                    return  ((CBOITEM)cbo.SelectedItem).ID;
                }
            }
            return "";
        }

        //Getting the value searched in a certain criteria
        private string GetTextSearch(int tag)
        {
            foreach (TextBox txt in _txtFilterList)
            {
                if (txt.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                {
                    return txt.Text;
                }
            }
            return "";
        }

        //Getting the date filter in a certain criteria
        private string GetDateFilter(int tag)
        {
            foreach (ComboBox cbo in _cboDateFilter)
            {
                if (cbo.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                {
                    return ((CBOITEM)cbo.SelectedItem).ID;
                }
            }
            return "";
        }

        //Getting the date searched in a certain criteria
        private string GetDateSearch(int tag)
        {
            foreach (DateTimePicker dtPicker in _dtPickerList)
            {
                if (dtPicker.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                {
                    return dtPicker.Value.ToShortDateString();
                }
            }
            return "";
        }

        //Getting the numerical filter in a certain criteria
        private string GetNumFilter(int tag)
        {
            foreach (ComboBox cbo in _numUpDownFilter)
            {
                if (cbo.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                {
                    return ((CBOITEM)cbo.SelectedItem).ID;
                }
            }
            return "";
        }

        //Getting the numerical searched value in a certain criteria
        private int GetNumSearch(int tag)
        {
            foreach (NumericUpDown numUpDown in _numUpDownList)
            {
                if (numUpDown.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                {
                    return Convert.ToInt32(numUpDown.Value);
                }
            }
            return 0;
        }

        //removes the panel with the search filter based on the tag of the panel sent as a parameter
        private void RemovePanel(int tag)
        {
            foreach (Panel p in _filterPanels)
            {
                //If the panel = the ID searched, we can remove.  Out of safety we remove everything in the panel.
                if (p.Tag.ToString().Split('-')[0] == tag.ToString(CultureInfo.InvariantCulture))
                {
                    foreach (Label l in _lblFieldName)
                    {
                        if (l.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(l);
                            _lblFieldName.Remove(l);
                            break;
                        }
                    }

                    foreach (ComboBox cbo in _cboTextFilter)
                    {
                        if (cbo.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(cbo);
                            _cboTextFilter.Remove(cbo);
                            break;
                        }
                    }

                    foreach (ComboBox cbo in _cboDateFilter)
                    {
                        if (cbo.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(cbo);
                            _cboDateFilter.Remove(cbo);
                            break;
                        }
                    }

                    foreach (DateTimePicker dtPicker in _dtPickerList)
                    {
                        if (dtPicker.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(dtPicker);
                            _dtPickerList.Remove(dtPicker);
                            break;
                        }
                    }

                    foreach (TextBox txt in _txtFilterList)
                    {
                        if (txt.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(txt);
                            _txtFilterList.Remove(txt);
                            break;
                        }
                    }

                    foreach (NumericUpDown numUpDown in _numUpDownList)
                    {
                        if (numUpDown.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(numUpDown);
                            _numUpDownList.Remove(numUpDown);
                            break;
                        }
                    }

                    foreach (ComboBox cbo in _numUpDownFilter)
                    {
                        if (cbo.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(cbo);
                            _numUpDownFilter.Remove(cbo);
                            break;
                        }
                    }

                    foreach (Button button in _removeButtonList)
                    {
                        if (button.Tag.ToString() == tag.ToString(CultureInfo.InvariantCulture))
                        {
                            p.Controls.Remove(button);
                            _removeButtonList.Remove(button);
                            break;
                        }
                    }
                    pnlSearchCriteriaList.Controls.Remove(p);
                    _filterPanels.Remove(p);
                    break;
                }
            }
            RefreshPanels();
        }

        //Adding a label
        private Label AddLabel(int tag, string fieldName)
        {
            var l = new Label
            {
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Width = 185,
                Height = 18,
                Text = fieldName,
                Tag = tag
            };
            return l;
        }

        //Adding a panel weith an attribute, a tag, a value to search, and a boolean "filter" symbol.
        private Panel AddPanel(int tag, int id, bool allowRemove)
        {
            var f = new Filter(id);
            var p = new Panel {Height = 35, Width = 660, BorderStyle = BorderStyle.FixedSingle, Tag = tag + "-" + id};

            //adding the field name
            Label label = AddLabel(tag, f.GetLanguageRelatedText());
            _lblFieldName.Add(label);
            p.Controls.Add(label);
            label.Top = 5;
            label.Left = 5;

            Type t = f.GetFieldType();

            int lastObjectLocation;

            if (t == typeof(string))
            {
                //add combo box filter for textbox
                ComboBox cbo = AddTextFilterComboBox(tag);
                TextBox txt = AddTextBox(tag);
                _cboTextFilter.Add(cbo);
                _txtFilterList.Add(txt);
                p.Controls.Add(cbo);
                p.Controls.Add(txt);
                cbo.Left = label.Right + 10;
                cbo.Top = label.Top;
                txt.Left = cbo.Right + 10;
                txt.Top = label.Top;
                lastObjectLocation = txt.Right;
            }
            else if (t == typeof(DateTime))
            {
                ComboBox cbo = AddDateFilterComboBox(tag);
                DateTimePicker dtPicker = AddDateTimePicker(tag);
                _cboDateFilter.Add(cbo);
                _dtPickerList.Add(dtPicker);
                p.Controls.Add(cbo);
                p.Controls.Add(dtPicker);
                cbo.Left = label.Right + 10;
                cbo.Top = label.Top;
                dtPicker.Left = cbo.Right + 10;
                dtPicker.Top = label.Top;
                lastObjectLocation = dtPicker.Right;
            }
            else
            {
                NumericUpDown numUpDown = AddNumUpDown(tag);
                ComboBox cbo = AddNumUpDownFilter(tag);
                _numUpDownFilter.Add(cbo);
                _numUpDownList.Add(numUpDown);
                p.Controls.Add(cbo);
                p.Controls.Add(numUpDown);
                cbo.Left = label.Right + 10;
                cbo.Top = label.Top;
                numUpDown.Left = cbo.Right + 10;
                numUpDown.Top = label.Top;
                lastObjectLocation = numUpDown.Right;
            }

            Button button = AddButton(tag);
            _removeButtonList.Add(button);
            p.Controls.Add(button);
            button.Left = lastObjectLocation + 10;
            button.Top = label.Top;

            if (!allowRemove)
            {
                button.Visible = false;
            }
            return p;
        }

        //Command when you decide to add a filter to your list of filter.  Called with true because your filter can be removed from list.
        private void cmdAddFilter_Click(object sender, EventArgs e)
        {
            AddFilter(true);
        }

        //Adds a filter to the filterPanel.  Also adds the attribute selected to the search criteria list.
        private void AddFilter(bool allowRemove)
        {
            Panel p = AddPanel(_controlTag, Convert.ToInt32(ComboBoxControl.IndexInformation(cboFilter)), allowRemove);

            _filterPanels.Add(p);
            pnlSearchCriteriaList.Controls.Add(p);

            ++_controlTag;
            RefreshPanels();
        }

        //Fills the 2 basic filters for dates.  
        private void FillFilter(ComboBox cbo)
        {
            for (int i = 0; i < _lstFilter.Count; i++)
            {
                ComboBoxControl.AddItem(cbo, _lstFilter[i].GetID().ToString(CultureInfo.InvariantCulture), _lstFilter[i].GetLanguageRelatedText());
            }

            //select date and add twice to the list by default and not possible to change... adding it twice to limit the date by max and min.
            ComboBoxControl.SetIDDefaultValue(cbo, "4");
            AddFilter(false);
            AddFilter(false);

            DateTime dtNow = DateTime.Now;
            DateTime dt6Months = dtNow.AddMonths(-6);

            //Date filters, lesser than for first, greater than for second
            ComboBoxControl.SetIDDefaultValue(_cboDateFilter[0], ">=");
            ComboBoxControl.SetIDDefaultValue(_cboDateFilter[1], "<=");

            _dtPickerList[0].Value = dt6Months;
            _dtPickerList[1].Value = dtNow;

            //set quote id as default
            ComboBoxControl.SetIDDefaultValue(cbo, "1");
        }

        //Delete all the "custom" tags from the panel list.
        private void cmdReset_Click(object sender, EventArgs e)
        {
            for (int i = _filterPanels.Count; i >= 2; --i)
            {
                RemovePanel(i);
            }
        }

        //Search command, Searches the database, then returns all quotes found
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (_filterPanels.Count > 0)
            {
                ThreadProcess.Start(Public.LanguageString("Searching for quotes", "Recherche de soumissions"));
                try
                {
                    SearchDatabase();
                    //After SearchDatabase, dt contains the found items. if count = 0, means we have no found results
                    if (_dt.Rows.Count > 0)
                    {
                        DisplaySearchResults(Public.SelectAndSortTable(_dt, "", "QuoteID DESC"));
                        ThreadProcess.Stop();
                        Focus();
                    }
                    else
                    {
                        lvResults.Items.Clear();
                        lvResults.Refresh();
                        ThreadProcess.Stop();
                        Focus();
                        Public.LanguageBox("No results match your search criteria.", "Aucun résultat ne correspond à vos critères de recherche.");
                    }
                }
                    //Only error (SO FAR) has been because the query returns way too much data to handle.  So.... we expect the problem to always come from that and react in consequence....
                catch(Exception ex) 
                {
                    Public.PushLog(ex.ToString(),"frmAdvancedSearch cmdSearch_click");
                    Public.LanguageBox("Unable to load due to too great amount of data valid for the current search parameter. Try reducing search range.", "Impossible de charger toutes les informations retournées par la recherche car les critères ne sont pas assez affinés. Veuillez raffiner vos critères de recherche");
                }
            }
            else
            {
                Public.LanguageBox("You must choose at least 1 search filter.", "Vous devez choisir au moins 1 critère de recherche.");
            }
        }

        //This makes a list of lists, separating every "group" of filters from each other in a separate list.
        private List<List<FilterData>> GetFiltersGroup(List<FilterData> lstfilterdata)
        {
            var lstGroupData = new List<List<FilterData>>();

            //this will select distinct filters
            var lstDistinctFilters = new List<FilterData>();

            for (int i = 0; i < lstfilterdata.Count; i++)
            {
                if (!FilterExist(lstfilterdata[i], lstDistinctFilters))
                {
                    lstDistinctFilters.Add(lstfilterdata[i]);
                }
            }

            //now for each distinct we will fill a new list
            foreach (FilterData fd in lstDistinctFilters)
            {
                var lsttemp = new List<FilterData>();

                for (int ifd = 0; ifd < lstfilterdata.Count; ifd++)
                {
                    if (lstfilterdata[ifd].GetFilter().GetID() == fd.GetFilter().GetID())
                    {
                        lsttemp.Add(lstfilterdata[ifd]);
                    }
                }
                lstGroupData.Add(lsttemp);
            }
            return lstGroupData;
        }

        //Loops through a list of the existing filters to look if a specific filter exists in it.
        private bool FilterExist(FilterData f, List<FilterData> lstFilterData)
        {
            for (int i = 0; i < lstFilterData.Count; i++)
            {
                if (lstFilterData[i].GetFilter().GetID() == f.GetFilter().GetID())
                {
                    return true;
                }
            }
            return false;
        }

        //Loops through the list of tables provided to check if the requested table exists
        private bool TableExist(string sTableName, List<DataTable> lstdt)
        {
            for (int i = 0; i < lstdt.Count; i++)
            {
                if (lstdt[i].TableName == sTableName)
                {
                    return true;
                }
            }
            return false;
        }

        //Builds a list of datatable concerned by the advanced search so the system knows where to look.
        private List<DataTable> GetTablesToSearch(List<List<FilterData>> lstFilterGroupData)
        {
            var lstTableFilters = new List<DataTable>();

            //add the quote table for sure
            var dtTemp = new DataTable("v_AdvancedSearchQuote");
            lstTableFilters.Add(dtTemp);
            lstTableFilters[0].TableName = "v_AdvancedSearchQuote";

            //for each filters we must find all the tables that need to be filled
            for (int iGroup = 0; iGroup < lstFilterGroupData.Count; iGroup++)
            {
                string sTableName = lstFilterGroupData[iGroup][0].GetFilter().GetTableName();
                if (!TableExist(sTableName, lstTableFilters))
                {
                    var dt = new DataTable(sTableName);
                    lstTableFilters.Add(dt);
                }
            }
            return lstTableFilters;
        }

        //With the table name and the list of filters associated with it, build part of the where clause.
        private string BuildWhereClause(string sTableName, List<List<FilterData>> lstFilterGroupData)
        {
            string sWhereClause = "";
            int iMatchingGroupQty = 0;
            for (int iGroup = 0; iGroup < lstFilterGroupData.Count; iGroup++)
            {
                if (lstFilterGroupData[iGroup][0].GetFilter().GetTableName() == sTableName)
                {
                    if (iMatchingGroupQty > 0)
                    {
                        sWhereClause += " AND ";
                    }
                    ++iMatchingGroupQty;

                    //Separate every attribute searched by an "(" and a ")" so we can (possibly over time?) build an "or" query?.  FOr the moment the parenthesis seems to be for clarity only (which is
                    //weird since the only one reading the query is the databse)
                    sWhereClause += "( ";

                    for (int iFilter = 0; iFilter < lstFilterGroupData[iGroup].Count; iFilter++)
                    {
                        if (iFilter > 0)
                        {
                            sWhereClause += " AND ";
                        }
                        sWhereClause += lstFilterGroupData[iGroup][iFilter].GetFilter().GetFilter(lstFilterGroupData[iGroup][iFilter].GetValue(), lstFilterGroupData[iGroup][iFilter].GetSymbol());
                    }
                    sWhereClause += " )";
                }
            }
            return sWhereClause;
        }

        //Counts, in all the tables, the amount of rows returned, so the system knows how many total search results are in
        private int QuantityOfSearchResult(int quoteID, int quoteRevision, List<DataTable> lstTableFilters)
        {
            int iQty = 1;

            for (int i = 1; i < lstTableFilters.Count; i++)
            {
                iQty += (Public.SelectAndSortTable(lstTableFilters[i], "QuoteID = " + quoteID + " AND QuoteRevision = " + quoteRevision, "").Rows.Count > 0 ? 1 : 0);
            }
            return iQty;
        }

        //Builds a list of filter groups and actually filters the tables according to that list, making sure every table only contains concerning information
        private void SearchDatabase()
        {
            //if multiple time same parameter selected it will get grouped under
            //a single list.
            //List
            //  |- List
            //  |   |-Quote ID >= 1000
            //  |   |-Quote ID < 1500
            //  |- List
            //     |- QuoteDate >= 2013/01/01
            //
            //example above there is 3 filters total but 2 on the same field.
            //so it's a group on fields in a single array.
            List<List<FilterData>> lstFilterGroupData = GetFiltersGroup(GetFilterData());

            //this list all the tables that will be required
            List<DataTable> lstTableFilters = GetTablesToSearch(lstFilterGroupData);

            //standard filter for the table
            string sQuoteDataFilter = BuildWhereClause("v_AdvancedSearchQuote", lstFilterGroupData);
            //build the query string for the quote data table minimum
            string sQuoteDataWhereClause = " WHERE quotationsite = '" + UserInformation.CurrentSite + "' " + QuoteVisibilityWhereClause() + (sQuoteDataFilter.Length > 0 ? " AND " : "") + sQuoteDataFilter;

            //now get all the tables filtered
            for (int iTable = 0; iTable < lstTableFilters.Count; iTable++)
            {
                string sTableName = lstTableFilters[iTable].TableName;
                string sTableFilter = (sTableName != "v_AdvancedSearchQuote" ? BuildWhereClause(sTableName, lstFilterGroupData) : "");

                lstTableFilters[iTable] = Query.Select("SELECT * FROM " + lstTableFilters[iTable].TableName + " " + sQuoteDataWhereClause + (sTableFilter.Length > 0 ? " AND " : "") + sTableFilter);
                lstTableFilters[iTable].TableName = sTableName;
            }

            _dt = lstTableFilters[0].Clone();

            _dt.Columns.Add("CoilModel", typeof(string));
            _dt.Columns.Add("CondenserModel", typeof(string));
            _dt.Columns.Add("CondensingUnitModel", typeof(string));
            _dt.Columns.Add("CustomUnitModel", typeof(string));
            _dt.Columns.Add("EvaporatorModel", typeof(string));
            _dt.Columns.Add("FluidCoolerModel", typeof(string));
            _dt.Columns.Add("GravityCoilModel", typeof(string));
            _dt.Columns.Add("HeatPipeModel", typeof(string));
            _dt.Columns.Add("ManualCoilModel", typeof(string));
            _dt.Columns.Add("OEMCoilModel", typeof(string));

            for (int iQuoteRecord = 0; iQuoteRecord < lstTableFilters[0].Rows.Count; iQuoteRecord++)
            {
                if (QuantityOfSearchResult(Convert.ToInt32(lstTableFilters[0].Rows[iQuoteRecord]["QuoteID"]), Convert.ToInt32(lstTableFilters[0].Rows[iQuoteRecord]["QuoteRevision"]), lstTableFilters) >= lstTableFilters.Count)
                {
                    DataRow dr = _dt.NewRow();
                    foreach (DataColumn dc in lstTableFilters[0].Columns)
                    {
                        dr[dc.ColumnName] = lstTableFilters[0].Rows[iQuoteRecord][dc.ColumnName];
                    }

                    dr["CoilModel"] = "";
                    dr["CondenserModel"] = "";
                    dr["CondensingUnitModel"] = "";
                    dr["CustomUnitModel"] = "";
                    dr["EvaporatorModel"] = "";
                    dr["FluidCoolerModel"] = "";
                    dr["GravityCoilModel"] = "";
                    dr["HeatPipeModel"] = "";
                    dr["ManualCoilModel"] = "";
                    dr["OEMCoilModel"] = "";


                    for (int iTable = 1; iTable < lstTableFilters.Count; iTable++)
                    {
                        string sModels = "";

                        DataTable dtTempView = Public.SelectAndSortTable(lstTableFilters[iTable], "QuoteID = " + lstTableFilters[0].Rows[iQuoteRecord]["QuoteID"] + " AND QuoteRevision = " + lstTableFilters[0].Rows[iQuoteRecord]["QuoteRevision"], "");

                        foreach (DataRow drData in dtTempView.Rows)
                        {
                            sModels += (sModels.Length > 0 ? ", " : "") + drData["Model"];
                        }

                        switch (lstTableFilters[iTable].TableName)
                        {
                            case "v_AdvancedSearchCoil":
                                dr["CoilModel"] = sModels;
                                break;
                            case "v_AdvancedSearchCondenser":
                                dr["CondenserModel"] = sModels;
                                break;
                            case "v_AdvancedSearchCondensingUnit":
                                dr["CondensingUnitModel"] = sModels;
                                break;
                            case "v_AdvancedSearchCustomUnit":
                                dr["CustomUnitModel"] = sModels;
                                break;
                            case "v_AdvancedSearchEvaporator":
                                dr["EvaporatorModel"] = sModels;
                                break;
                            case "v_AdvancedSearchFluidCooler":
                                dr["FluidCoolerModel"] = sModels;
                                break;
                            case "v_AdvancedSearchGravityCoil":
                                dr["GravityCoilModel"] = sModels;
                                break;
                            case "v_AdvancedSearchHeatPipe":
                                dr["HeatPipeModel"] = sModels;
                                break;
                            case "v_AdvancedSearchManualCoil":
                                dr["ManualCoilModel"] = sModels;
                                break;
                            case "v_AdvancedSearchOEMCoil":
                                dr["OEMCoilModel"] = sModels;
                                break;
                        }
                    }
                    _dt.Rows.Add(dr);
                }
            }
        }

        //Builds the actual list containing all the filters to have in the advanced search
        private List<FilterData> GetFilterData()
        {
            var fd = new List<FilterData>();

            //looping through all the filters entered in the panel
            for (int i = 0; i < _filterPanels.Count; i++)
            {
                string sID = _filterPanels[i].Tag.ToString().Split('-')[1];

                //building a filter from the ID of the variable to search)
                var f = new Filter(Convert.ToInt32(sID));

                Type t = f.GetFieldType();

                string sFilterSymbol;
                string sValue;

                int iPanelTag = Convert.ToInt32(_filterPanels[i].Tag.ToString().Split('-')[0]);

                //checking what's the type of the filter so we know what boolean symbol to apply to the variable, and the correct functions to call to get the right symbols and values
                if (t == typeof(string))
                {
                    sFilterSymbol = GetTextFilter(iPanelTag);
                    sValue = GetTextSearch(iPanelTag);
                }
                else if (t == typeof(DateTime))
                {
                    sFilterSymbol = GetDateFilter(iPanelTag);
                    sValue = GetDateSearch(iPanelTag);
                }
                else
                {
                    sFilterSymbol = GetNumFilter(iPanelTag);
                    sValue = GetNumSearch(iPanelTag).ToString(CultureInfo.InvariantCulture);
                }
                fd.Add(new FilterData(f, sFilterSymbol, sValue));
            }
            return fd;
        }

        //Loads the results of the search into the list of quotations
        private void DisplaySearchResults(DataTable dt)
        {
            lvResults.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Adding subitem after subitem until we have all the necessary items to the quotation.  Looping on the amount of quotes found
                var lvi = new ListViewItem(dt.Rows[i]["quoteid"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["quoterevision"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["quoterevisiontext"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["projectname"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["quotationdate"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["quotationby"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["quotationbyusername"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["email"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["rep"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["engineer"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["terms"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["delivery"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["freight"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["contactname"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["address"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["city"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["state"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["country"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["companyname"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["notes"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["attention"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["lastupdateby"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["coilmodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["condensermodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["EvaporatorModel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["fluidcoolermodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["heatpipemodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["condensingunitmodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["gravitycoilmodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["customunitmodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["manualcoilmodel"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["oemcoilmodel"].ToString());
                lvResults.Items.Add(lvi);
            }
            lvResults.Refresh();
        }

        //When you double-click on a quote, it opens it.  Slight bug if you double-click on something ELSE then a quote (the bar to grow a column, for instance), where it calls this but never opens anything
        //because nothing is actually selected.
        private void lvResults_DoubleClick(object sender, EventArgs e)
        {
            OpenQuote();
        }

        // Send the quote to be loaded to the mainform so it knows which quote to open
        private void OpenQuote()
        {
            //Since you can't multiselect, ==1 = >0, and makes more sense.
            if (lvResults.SelectedItems.Count == 1)
            {
                //Calls from the main form, the loadquote method, with the index and revision of the quote to load
                _mainForm.LoadQuote(Convert.ToInt32(lvResults.SelectedItems[0].SubItems[0].Text), Convert.ToInt32(lvResults.SelectedItems[0].SubItems[1].Text));
                //Cleaning up after itself
                Dispose();
            }
            else
            {
                //if count = 0, you selected nothing and tried to open a quote....
                Public.LanguageBox("You must select a quote to open.", "Vous devez sélectionner une soumission à ouvrir");
            }
        }

        //Adds to the where clause depending on your permission level.  If you're at 90 or more, you can see all quotes, so no special where.  If you're under 90, you can only
        //see quotes by someone in your group, or for someone in your group.
        private string QuoteVisibilityWhereClause()
        {
            return (UserInformation.RequiredPermissionLevel(90) ? "" : " AND (QuotationByGroupID IN (" + UserInformation.UserGroups + ") OR GroupID IN (" + UserInformation.UserGroups + ")) ");
        }

        //Opens selected quote.
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            OpenQuote();
        }

        //Closes current form.
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // If user presses F1, summons the help files for this form
        private void frmAdvancedSearch_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        //Summons the help files for the form you're in.
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }
    }
}