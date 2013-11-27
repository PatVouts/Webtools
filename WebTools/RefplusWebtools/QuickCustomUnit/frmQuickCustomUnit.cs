using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCustomUnit
{
    public partial class FrmQuickCustomUnit : Form
    {
        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;

        //dataset of the quote
        private readonly DataSet _dsQuoteData;

        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        private bool _isLoadedTemplate;
        private readonly int _userID = UserInformation.UserID;

        private bool _minimalAccess = true;

        private DataTable _dtCustomUnit = new DataTable();
        private DataTable _dtSaveTable = new DataTable();
        private DataTable _dtQuoteTable = new DataTable();
        private string _templateName = "";

        public FrmQuickCustomUnit()
        {
            InitializeComponent();

        }

        public FrmQuickCustomUnit(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;
           
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void frmQuickCustomUnit_Load(object sender, EventArgs e)
        {
            _minimalAccess = !UserInformation.AccessQuoteCustomUnit;
            if (_minimalAccess)
            {
                grpFullCustom.Visible = false;
                toolStrip1.Visible = false;
                cmdCancel.Location = new Point(cmdCancel.Location.X, 137);
                cmdGenerateReport.Visible = false;
                btnHelp.Location = new Point(btnHelp.Location.X, 120);
                numPrice.Location = new Point(577, 62);
                lblPrice.Location = new Point(500, 64);
                cmdAccept.Location = new Point(cmdAccept.Location.X, 137);
            }

            //load into memory table that are needed
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Query.LoadTables(new[] { "CustomUnitReportText", "CustomUnitReportUnits", "CustomUnitTemplate" });

            Fill_Combobox();

            SetDefaults();

            if (_bolQuoteSelection && _intIndex != -1)
            {
                LoadSavedData();
            }

            //2010-12-20 : Francis : Added sorting because it look better.
            DataTable dtTemplateListOrdered = Public.SelectAndSortTable(Public.DSDatabase.Tables["CustomUnitTemplate"], "", "Description");

            for (int i = 0; i < dtTemplateListOrdered.Rows.Count; i++)
            {
                sLoadToolStripMenuItem.DropDownItems.Add(dtTemplateListOrdered.Rows[i]["Description"].ToString());
            }

            foreach (ToolStripMenuItem item in sLoadToolStripMenuItem.DropDownItems)
            {
                item.Click += item_Click;
            }

            ThreadProcess.Stop();
            Focus();
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void item_Click(object sender, EventArgs e)
        {
            var template = (ToolStripItem)sender;
            DataTable dtTemplate = Public.SelectAndSortTable(Public.DSDatabase.Tables["CustomUnitTemplate"], "Description = '" + template.Text + "'", "");
            if (dtTemplate.Rows.Count > 0)
            {
                lvLeft.Items.Clear();
                lvRight.Items.Clear();
                for (int i = 1; i <= Convert.ToInt32(dtTemplate.Rows[0]["Count"].ToString()); i++)
                {
                    var leftItem = new GlacialComponents.Controls.GLItem(lvLeft);
                    leftItem.SubItems[0].Text = dtTemplate.Rows[0]["Text" + ((i * 2) - 1)].ToString();
                    leftItem.SubItems[1].Text = dtTemplate.Rows[0]["Value" + ((i * 2) - 1)].ToString();
                    leftItem.SubItems[2].Text = dtTemplate.Rows[0]["Unit" + ((i * 2) - 1)].ToString();
                    lvLeft.Items.Add(leftItem);
                    lvLeft.Refresh();

                    var rightItem = new GlacialComponents.Controls.GLItem(lvRight);
                    rightItem.SubItems[0].Text = dtTemplate.Rows[0]["Text" + (i * 2)].ToString();
                    rightItem.SubItems[1].Text = dtTemplate.Rows[0]["Value" + (i * 2)].ToString();
                    rightItem.SubItems[2].Text = dtTemplate.Rows[0]["Unit" + (i * 2)].ToString();
                    lvRight.Items.Add(rightItem);
                    lvRight.Refresh();
                }
                _templateName = template.Text;
                _isLoadedTemplate = true;
            }
        }



        private void LoadSavedData()
        {
            //string strErrors = "";
            DataTable dtData = Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CustomUnit) + " AND ItemID = " + _intIndex, "");
            DataRow drData = dtData.NewRow();
            drData.ItemArray = dtData.Rows[0].ItemArray;

            txtTag.Text = drData["Tag"].ToString();
            numQuantity.Value = Convert.ToDecimal(drData["Quantity"].ToString());
            txtModel.Text = drData["Description"].ToString();
            numPrice.Value = Convert.ToDecimal(drData["Price"].ToString());

            for (int i = 1; i <= Convert.ToInt32(drData["Count"].ToString()); i++)
            {
                var leftItem = new GlacialComponents.Controls.GLItem(lvLeft);
                if (drData["Text" + ((i*2) - 1)].ToString() != "BLANK UNIT" && _minimalAccess)
                {
                    Public.LanguageBox("You opened this item, but you don,t have access to the full custom unit items, so you can't edit this. Contact refplus' sales departement if you need this unit changed.  thank you","Vous avez tenté de modifier cet item sur la soumission, mais vous n'avez pas accès aux unités sur mesure.  Contactez le département des ventes de refplus pour modifier cette unité. Merci!");
                    Close();
                }
                leftItem.SubItems[0].Text = drData["Text" + ((i * 2) - 1)].ToString();
                leftItem.SubItems[1].Text = drData["Value" + ((i * 2) - 1)].ToString();
                leftItem.SubItems[2].Text = drData["Unit" + ((i * 2) - 1)].ToString();
                lvLeft.Items.Add(leftItem);
                lvLeft.Refresh();

                var rightItem = new GlacialComponents.Controls.GLItem(lvRight);
                rightItem.SubItems[0].Text = drData["Text" + (i * 2)].ToString();
                rightItem.SubItems[1].Text = drData["Value" + (i * 2)].ToString();
                rightItem.SubItems[2].Text = drData["Unit" + (i * 2)].ToString();
                lvRight.Items.Add(rightItem);
                lvRight.Refresh();
            }
        }

        //fill combobox
        private void Fill_Combobox()
        {
            FillTextCombobox();

            FillUnitCombobox();

        }

        //set control defaults
        private void SetDefaults()
        {
            //set both column combobox to lelect the left column as default
            cboColumn.SelectedIndex = 0;
            cboBlankColumn.SelectedIndex = 0;
        }

        //fill the text combobox
        private void FillTextCombobox()
        {
            //sort
            DataTable dtCustomUnitReportText = Public.SelectAndSortTable(Public.DSDatabase.Tables["CustomUnitReportText"], "", "Text ASC");


            //add items
            foreach (DataRow drCustomUnitReportText in dtCustomUnitReportText.Rows)
            {
                cboText.Items.Add(drCustomUnitReportText["Text"].ToString());
            }

            //dispose
            dtCustomUnitReportText.Dispose();
        }

        //fill the unit combobox
        private void FillUnitCombobox()
        {
            //sort
            DataTable dtCustomUnitReportUnits = Public.SelectAndSortTable(Public.DSDatabase.Tables["CustomUnitReportUnits"], "", "Units ASC");
            //add items
            foreach (DataRow drCustomUnitReportUnits in dtCustomUnitReportUnits.Rows)
            {
                cboUnit.Items.Add(drCustomUnitReportUnits["Units"].ToString());
            }

            //dispose
            dtCustomUnitReportUnits.Dispose();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (cboText.Text != "" && txtValue.Text != "")
            {
                if (cboColumn.SelectedIndex == 0)
                {
                    if (lvLeft.Items.Count != 50)
                    {
                        var myItem = new GlacialComponents.Controls.GLItem(lvLeft);
                        myItem.SubItems[0].Text = cboText.Text;
                        myItem.SubItems[1].Text = txtValue.Text;
                        myItem.SubItems[2].Text = (cboUnit.Text == "" ? "N/A" : cboUnit.Text);
                        lvLeft.Items.Add(myItem);
                    }
                    lvLeft.Refresh();

                }
                else
                {
                    if (lvRight.Items.Count != 50)
                    {
                        var myItem = new GlacialComponents.Controls.GLItem(lvRight);
                        myItem.SubItems[0].Text = cboText.Text;
                        myItem.SubItems[1].Text = txtValue.Text;
                        myItem.SubItems[2].Text = (cboUnit.Text == "" ? "N/A" : cboUnit.Text);
                        lvRight.Items.Add(myItem);
                    }
                    lvRight.Refresh();
                }
            }
        }

        private void cmdBlankAdd_Click(object sender, EventArgs e)
        {
            if (cboBlankColumn.SelectedIndex == 0)
            {
                if (lvLeft.Items.Count != 50)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvLeft);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvLeft.Items.Add(myItem);
                }
                lvLeft.Refresh();
            }
            else
            {
                if (lvRight.Items.Count != 50)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvRight);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvRight.Items.Add(myItem);
                }
                lvRight.Refresh();
            }
        }

        private void cmdLeftMoveUp_Click(object sender, EventArgs e)
        {
            if (lvLeft.SelectedItems.Count > 0)
            {
                MoveListViewItem(ref lvLeft, true);
            }
        }

        //this function moves up or down and item
        private void MoveListViewItem(ref GlacialComponents.Controls.GlacialList lvMyListView, bool bolMoveUp)
        {
            string strCache;

            int intSelId = lvMyListView.Items.FindItemIndex((GlacialComponents.Controls.GLItem)lvMyListView.SelectedItems[0]);
            if (bolMoveUp)
            {
                // ignore moveup of row(0)
                if (intSelId == 0)
                    return;

                // move the subitems for the previous row
                // to cache to make room for the selected row
                for (int i = 0; i < lvMyListView.Items[intSelId].SubItems.Count; i++)
                {
                    strCache = lvMyListView.Items[intSelId - 1].SubItems[i].Text;
                    lvMyListView.Items[intSelId - 1].SubItems[i].Text =
                      lvMyListView.Items[intSelId].SubItems[i].Text;
                    lvMyListView.Items[intSelId].SubItems[i].Text = strCache;
                }
                lvMyListView.Items[intSelId - 1].Selected = true;
                lvMyListView.Refresh();
                lvMyListView.Focus();
            }
            else
            {
                // ignore movedown of last item
                if (intSelId == lvMyListView.Items.Count - 1)
                    return;
                // move the subitems for the next row
                // to cache so we can move the selected row down
                for (int i = 0; i < lvMyListView.Items[intSelId].SubItems.Count; i++)
                {
                    strCache = lvMyListView.Items[intSelId + 1].SubItems[i].Text;
                    lvMyListView.Items[intSelId + 1].SubItems[i].Text =
                      lvMyListView.Items[intSelId].SubItems[i].Text;
                    lvMyListView.Items[intSelId].SubItems[i].Text = strCache;
                }
                lvMyListView.Items[intSelId + 1].Selected = true;
                lvMyListView.Refresh();
                lvMyListView.Focus();
            }
        }

        private void cmdLeftMoveDown_Click(object sender, EventArgs e)
        {
            if (lvLeft.SelectedItems.Count > 0)
            {
                MoveListViewItem(ref lvLeft, false);
            }
        }

        private void cmdRightMoveUp_Click(object sender, EventArgs e)
        {
            if (lvRight.SelectedItems.Count > 0)
            {
                MoveListViewItem(ref lvRight, true);
            }
        }

        private void cmdRightMoveDown_Click(object sender, EventArgs e)
        {
            if (lvRight.SelectedItems.Count > 0)
            {
                MoveListViewItem(ref lvRight, false);
            }
        }

        private void cmdGenerateReport_Click(object sender, EventArgs e)
        {
            if (lvLeft.Items.Count + lvRight.Items.Count > 0)
            {
                ThreadProcess.Start(Public.LanguageString("Generating Report", "Création du rapport"));
                //get the max lines
                int intLeftItems = Convert.ToInt32(Math.Max(lvLeft.Items.Count, lvRight.Items.Count)) - lvLeft.Items.Count;
                int intRightItems = Convert.ToInt32(Math.Max(lvLeft.Items.Count, lvRight.Items.Count)) - lvRight.Items.Count;

                //fill up both column to make sure they are even
                for (int intFillLeftBlanks = 0; intFillLeftBlanks < intLeftItems; intFillLeftBlanks++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvLeft);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvLeft.Items.Add(myItem);
                    lvLeft.Refresh();
                }

                //fill up both column to make sure they are even
                for (int intFillRightBlanks = 0; intFillRightBlanks < intRightItems; intFillRightBlanks++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvRight);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvRight.Items.Add(myItem);
                    lvRight.Refresh();
                }

                DataTable dtToPass = Tables.DtCustomUnitReport();

                //how much item exist on 1 side
                int intTotal = lvLeft.Items.Count;
                DataRow drCustomUnit = dtToPass.NewRow();

                //header
                drCustomUnit["QuoteID"] = 0;
                drCustomUnit["QuoteRevision"] = 0;
                drCustomUnit["QuoteRevisionText"] = "";
                drCustomUnit["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CustomUnit);
                drCustomUnit["ItemID"] = 0;
                drCustomUnit["Username"] = "";
                drCustomUnit["Tag"] = txtTag.Text;
                drCustomUnit["Quantity"] = numQuantity.Value;
                drCustomUnit["Description"] = txtModel.Text;
                drCustomUnit["Price"] = numPrice.Value;

                //for each item add it to the table making sure we
                //put 1 item of left then 1 item of right and keep alternating
                for (int i = 1; i <= intTotal; i++)
                {

                    drCustomUnit["Text" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[0].Text;
                    drCustomUnit["Value" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[1].Text;
                    drCustomUnit["Unit" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[2].Text;

                    drCustomUnit["Text" + (i * 2)] = lvRight.Items[i - 1].SubItems[0].Text;
                    drCustomUnit["Value" + (i * 2)] = lvRight.Items[i - 1].SubItems[1].Text;
                    drCustomUnit["Unit" + (i * 2)] = lvRight.Items[i - 1].SubItems[2].Text;

                }

                for (int iFillRest = (intTotal * 2) + 1; iFillRest < 100; iFillRest++)
                {
                    drCustomUnit["Text" + iFillRest] = "";
                    drCustomUnit["Value" + iFillRest] = "";
                    drCustomUnit["Unit" + iFillRest] = "";
                }

                drCustomUnit["Count"] = intTotal;

                dtToPass.Rows.Add(drCustomUnit);

                CustomUnitReport.GenerateDataReport(dtToPass, true, 0, "");
                ThreadProcess.Stop();
                Focus();

            }
            else
            {
                Public.LanguageBox("You must have at least 1 field", "Vous devez avoir au moins 1 champs");
            }
        }

        private void lvLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvLeft.SelectedItems.Count > 0)
            {
                //if delete is press on an item
                if (e.KeyCode == Keys.Delete)
                {
                    lvLeft.Items.RemoveAt(lvLeft.Items.FindItemIndex((GlacialComponents.Controls.GLItem)lvLeft.SelectedItems[0]));
                    lvLeft.Refresh();
                }
            }
        }

        private void lvRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvRight.SelectedItems.Count > 0)
            {
                //if delete is press on an item
                if (e.KeyCode == Keys.Delete)
                {
                    lvRight.Items.RemoveAt(lvRight.Items.FindItemIndex((GlacialComponents.Controls.GLItem)lvRight.SelectedItems[0]));
                    lvRight.Refresh();
                }
            }
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void Accept()
        {
            if (_minimalAccess)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvLeft);
                myItem.SubItems[0].Text = "BLANK UNIT";
                myItem.SubItems[1].Text = "BLANK UNIT";
                myItem.SubItems[2].Text = "BLANK UNIT";
                lvLeft.Items.Add(myItem);
            }
            if (lvLeft.Items.Count + lvRight.Items.Count > 0)
            {
                if (txtModel.Text != "")
                {
                    if (_bolQuoteSelection)
                    {

                        ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                        int newIndexToPush;
                        if (_intIndex != -1)
                        {
                            var savingoption = new FrmSavingOption();

                            ThreadProcess.Stop();
                            Focus();

                            if (savingoption.ShowDialog() == DialogResult.Yes)
                            {//if he want to overwrite

                                //it's a modification unit so we delete and recreate records
                                _quoteform.DeleteFromQuoteCustomUnit(_intIndex);
                                newIndexToPush = _intIndex;
                                _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CustomUnit), newIndexToPush);
                            }
                            else
                            {
                                //since we actually always recreate the record
                                // save as new is simple, all i have to do is copy the additionnal items
                                //if reused the update function to instead duplicate record.
                                newIndexToPush = _quoteform.GetNextID("CustomUnitTable");
                                _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CustomUnit), newIndexToPush);

                            }

                            ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                        }
                        else
                        {
                            newIndexToPush = _quoteform.GetNextID("CustomUnitTable");
                        }

                        AddToQuote(newIndexToPush);

                        _quoteform.RefreshBasketList();
                        _quoteform.SetQuoteIsModified(true);

                        ThreadProcess.Stop();
                        Focus();
                        Dispose();
                    }
                }
                else
                {
                    Public.LanguageBox("You must provide a model name for this custom unit", "Vous devez fournir un nom de modèle pour cette unité personnalisée");
                }
            }
            else
            {
                Public.LanguageBox("You must have at least 1 field", "Vous devez avoir au moins 1 champs");
            }
        }

        private void AddToQuote(int itemId)
        {
            _dtQuoteTable = GetSaveTable();
            _dtQuoteTable.Rows[0]["ItemID"] = itemId;
            _dsQuoteData.Tables["CustomUnitTable"].Rows.Add(_dtQuoteTable.Rows[0].ItemArray);

            DataTable copy = _dsQuoteData.Tables["CustomUnitTable"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["CustomUnitTable"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["CustomUnitTable"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Tag"], row["Quantity"], row["Description"], row["Price"], row["Text1"], row["Value1"], row["Unit1"], row["Text2"], row["Value2"], row["Unit2"], row["Text3"], row["Value3"], row["Unit3"], row["Text4"], row["Value4"], row["Unit4"], row["Text5"], row["Value5"], row["Unit5"], row["Text6"], row["Value6"], row["Unit6"], row["Text7"], row["Value7"], row["Unit7"], row["Text8"], row["Value8"], row["Unit8"], row["Text9"], row["Value9"], row["Unit9"], row["Text10"], row["Value10"], row["Unit10"], row["Text11"], row["Value11"], row["Unit11"], row["Text12"], row["Value12"], row["Unit12"], row["Text13"], row["Value13"], row["Unit13"], row["Text14"], row["Value14"], row["Unit14"], row["Text15"], row["Value15"], row["Unit15"], row["Text16"], row["Value16"], row["Unit16"], row["Text17"], row["Value17"], row["Unit17"], row["Text18"], row["Value18"], row["Unit18"], row["Text19"], row["Value19"], row["Unit19"], row["Text20"], row["Value20"], row["Unit20"], row["Text21"], row["Value21"], row["Unit21"], row["Text22"], row["Value22"], row["Unit22"], row["Text23"], row["Value23"], row["Unit23"], row["Text24"], row["Value24"], row["Unit24"], row["Text25"], row["Value25"], row["Unit25"], row["Text26"], row["Value26"], row["Unit26"], row["Text27"], row["Value27"], row["Unit27"], row["Text28"], row["Value28"], row["Unit28"], row["Text29"], row["Value29"], row["Unit29"], row["Text30"], row["Value30"], row["Unit30"], row["Text31"], row["Value31"], row["Unit31"], row["Text32"], row["Value32"], row["Unit32"], row["Text33"], row["Value33"], row["Unit33"], row["Text34"], row["Value34"], row["Unit34"], row["Text35"], row["Value35"], row["Unit35"], row["Text36"], row["Value36"], row["Unit36"], row["Text37"], row["Value37"], row["Unit37"], row["Text38"], row["Value38"], row["Unit38"], row["Text39"], row["Value39"], row["Unit39"], row["Text40"], row["Value40"], row["Unit40"], row["Text41"], row["Value41"], row["Unit41"], row["Text42"], row["Value42"], row["Unit42"], row["Text43"], row["Value43"], row["Unit43"], row["Text44"], row["Value44"], row["Unit44"], row["Text45"], row["Value45"], row["Unit45"], row["Text46"], row["Value46"], row["Unit46"], row["Text47"], row["Value47"], row["Unit47"], row["Text48"], row["Value48"], row["Unit48"], row["Text49"], row["Value49"], row["Unit49"], row["Text50"], row["Value50"], row["Unit50"], row["Text51"], row["Value51"], row["Unit51"], row["Text52"], row["Value52"], row["Unit52"], row["Text53"], row["Value53"], row["Unit53"], row["Text54"], row["Value54"], row["Unit54"], row["Text55"], row["Value55"], row["Unit55"], row["Text56"], row["Value56"], row["Unit56"], row["Text57"], row["Value57"], row["Unit57"], row["Text58"], row["Value58"], row["Unit58"], row["Text59"], row["Value59"], row["Unit59"], row["Text60"], row["Value60"], row["Unit60"], row["Text61"], row["Value61"], row["Unit61"], row["Text62"], row["Value62"], row["Unit62"], row["Text63"], row["Value63"], row["Unit63"], row["Text64"], row["Value64"], row["Unit64"], row["Text65"], row["Value65"], row["Unit65"], row["Text66"], row["Value66"], row["Unit66"], row["Text67"], row["Value67"], row["Unit67"], row["Text68"], row["Value68"], row["Unit68"], row["Text69"], row["Value69"], row["Unit69"], row["Text70"], row["Value70"], row["Unit70"], row["Text71"], row["Value71"], row["Unit71"], row["Text72"], row["Value72"], row["Unit72"], row["Text73"], row["Value73"], row["Unit73"], row["Text74"], row["Value74"], row["Unit74"], row["Text75"], row["Value75"], row["Unit75"], row["Text76"], row["Value76"], row["Unit76"], row["Text77"], row["Value77"], row["Unit77"], row["Text78"], row["Value78"], row["Unit78"], row["Text79"], row["Value79"], row["Unit79"], row["Text80"], row["Value80"], row["Unit80"], row["Text81"], row["Value81"], row["Unit81"], row["Text82"], row["Value82"], row["Unit82"], row["Text83"], row["Value83"], row["Unit83"], row["Text84"], row["Value84"], row["Unit84"], row["Text85"], row["Value85"], row["Unit85"], row["Text86"], row["Value86"], row["Unit86"], row["Text87"], row["Value87"], row["Unit87"], row["Text88"], row["Value88"], row["Unit88"], row["Text89"], row["Value89"], row["Unit89"], row["Text90"], row["Value90"], row["Unit90"], row["Text91"], row["Value91"], row["Unit91"], row["Text92"], row["Value92"], row["Unit92"], row["Text93"], row["Value93"], row["Unit93"], row["Text94"], row["Value94"], row["Unit94"], row["Text95"], row["Value95"], row["Unit95"], row["Text96"], row["Value96"], row["Unit96"], row["Text97"], row["Value97"], row["Unit97"], row["Text98"], row["Value98"], row["Unit98"], row["Text99"], row["Value99"], row["Unit99"], row["Text100"], row["Value100"], row["Unit100"], row["Count"]);
            }

        }

        private DataTable GetTemplateTable()
        {
            if (lvLeft.Items.Count + lvRight.Items.Count > 0)
            {
                _dtSaveTable = Tables.DtCustomUnitTemplate();

                //get the max lines
                int intLeftItems = Convert.ToInt32(Math.Max(lvLeft.Items.Count, lvRight.Items.Count)) - lvLeft.Items.Count;
                int intRightItems = Convert.ToInt32(Math.Max(lvLeft.Items.Count, lvRight.Items.Count)) - lvRight.Items.Count;

                //fill up both column to make sure they are even
                for (int intFillLeftBlanks = 0; intFillLeftBlanks < intLeftItems; intFillLeftBlanks++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvLeft);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvLeft.Items.Add(myItem);
                    lvLeft.Refresh();
                }

                //fill up both column to make sure they are even
                for (int intFillRightBlanks = 0; intFillRightBlanks < intRightItems; intFillRightBlanks++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvRight);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvRight.Items.Add(myItem);
                    lvRight.Refresh();
                }

                int intTotal = lvLeft.Items.Count;
                DataRow drSaveTable = _dtSaveTable.NewRow();
                drSaveTable["UserID"] = _userID;

                for (int i = 1; i <= intTotal; i++)
                {

                    drSaveTable["Text" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[0].Text;
                    drSaveTable["Unit" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[2].Text;

                    drSaveTable["Text" + (i * 2)] = lvRight.Items[i - 1].SubItems[0].Text;
                    drSaveTable["Unit" + (i * 2)] = lvRight.Items[i - 1].SubItems[2].Text;

                }
                drSaveTable["Count"] = intTotal;
                _dtSaveTable.Rows.Add(drSaveTable);

            }
            else
            {
                Public.LanguageBox("You must have at least 1 field", "Vous devez avoir au moins 1 champs");
            }


            return _dtSaveTable;
        }

        private DataTable GetSaveTable()
        {
            DataTable dt = Tables.DtCustomUnitReport();
            DataRow drSaveTable = dt.NewRow();
            if (lvLeft.Items.Count + lvRight.Items.Count > 0)
            {
                //get the max lines
                int intLeftItems = Convert.ToInt32(Math.Max(lvLeft.Items.Count, lvRight.Items.Count)) - lvLeft.Items.Count;
                int intRightItems = Convert.ToInt32(Math.Max(lvLeft.Items.Count, lvRight.Items.Count)) - lvRight.Items.Count;

                //fill up both column to make sure they are even
                for (int intFillLeftBlanks = 0; intFillLeftBlanks < intLeftItems; intFillLeftBlanks++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvLeft);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvLeft.Items.Add(myItem);
                    lvLeft.Refresh();
                }

                //fill up both column to make sure they are even
                for (int intFillRightBlanks = 0; intFillRightBlanks < intRightItems; intFillRightBlanks++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvRight);
                    myItem.SubItems[0].Text = "BLANK LINE";
                    myItem.SubItems[1].Text = "BLANK LINE";
                    myItem.SubItems[2].Text = "BLANK LINE";
                    lvRight.Items.Add(myItem);
                    lvRight.Refresh();
                }

                int intTotal = lvLeft.Items.Count;

                //header
                drSaveTable["QuoteID"] = 0;
                drSaveTable["QuoteRevision"] = 0;
                drSaveTable["QuoteRevisionText"] = "";
                drSaveTable["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.CustomUnit);
                drSaveTable["ItemID"] = 0;
                drSaveTable["Username"] = "";
                drSaveTable["Tag"] = txtTag.Text;
                drSaveTable["Quantity"] = numQuantity.Value;
                drSaveTable["Description"] = txtModel.Text;
                drSaveTable["Price"] = numPrice.Value;

                for (int i = 1; i <= intTotal; i++)
                {
                    drSaveTable["Text" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[0].Text;
                    drSaveTable["Value" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[1].Text;
                    drSaveTable["Unit" + ((i * 2) - 1)] = lvLeft.Items[i - 1].SubItems[2].Text;
                    drSaveTable["Text" + (i * 2)] = lvRight.Items[i - 1].SubItems[0].Text;
                    drSaveTable["Value" + (i * 2)] = lvRight.Items[i - 1].SubItems[1].Text;
                    drSaveTable["Unit" + (i * 2)] = lvRight.Items[i - 1].SubItems[2].Text;
                }
                drSaveTable["Count"] = intTotal;

                dt.Rows.Add(drSaveTable);
            }
            return dt;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void sSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtCustomUnit = GetTemplateTable();
            if (lvLeft.Items.Count > 0 && lvLeft.Items.Count < 50 && lvRight.Items.Count > 0 && lvRight.Items.Count < 50)
            {
                var template = new FrmSaveTemplate();
                if (_isLoadedTemplate)
                {
                    DataTable dtUserID = Query.Select("select userID from customunittemplate where description = '" + _templateName + "'");
                    if (_userID == Convert.ToInt32(dtUserID.Rows[0]["UserID"].ToString()) || _userID == 1)
                    {
                        DialogResult result = Public.LanguageQuestionBox("Are you sure you wish to overwrite this template?", "Êtes-vous sûr de vouloir écraser ce modèle?", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Query.Execute("Delete from CustomUnitTemplate where description = '" + _templateName + "'");
                            for (int i = 0; i < _dtCustomUnit.Rows.Count; i++)
                            {
                                _dtCustomUnit.Rows[i]["Description"] = _templateName;
                            }

                            if (Query.Execute(Query.BuildInsertQuery(_dtCustomUnit, "CustomUnitTemplate")))
                            {
                                Public.LanguageBox("Template saved successfully", "Modèle enregistré avec succès");
                                Query.UpdateServerTableVersion("CustomUnitTemplate");
                            }
                            else
                            {
                                Public.LanguageBox("An error occurred while saving", "Une erreur s'est produite lors de l'enregistrement");
                            }
                        }
                    }
                    else
                    {
                        Public.LanguageBox("You cannot save this template.", "Vous ne pouvez sauvegarder ce modèle");
                    }
                }
                else
                {
                    DialogResult dr = template.ShowDialog();

                    if (dr != DialogResult.Cancel)
                    {
                        for (int i = 0; i < _dtCustomUnit.Rows.Count; i++)
                        {
                            _dtCustomUnit.Rows[i]["Description"] = template.GetDescription();
                        }

                        if (Query.Execute(Query.BuildInsertQuery(_dtCustomUnit, "CustomUnitTemplate")))
                        {
                            Public.LanguageBox("Template saved successfully", "Modèle enregistré avec succès");
                            Query.UpdateServerTableVersion("CustomUnitTemplate");
                        }
                        else
                        {
                            Public.LanguageBox("An error occurred while saving", "Une erreur s'est produite lors de l'enregistrement");
                        }
                    }
                    template.Dispose();
                }
            }
        }

        private void sSaveAsNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtCustomUnit = GetTemplateTable();
            if (lvLeft.Items.Count > 0 && lvLeft.Items.Count < 50 && lvRight.Items.Count > 0 && lvRight.Items.Count < 50)
            {
                var template = new FrmSaveTemplate();
                DialogResult dr = template.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    for (int i = 0; i < _dtCustomUnit.Rows.Count; i++)
                    {
                        _dtCustomUnit.Rows[i]["Description"] = template.GetDescription();
                    }

                    if (Query.Execute(Query.BuildInsertQuery(_dtCustomUnit, "CustomUnitTemplate")))
                    {
                        Public.LanguageBox("Template saved successfully", "Modèle enregistré avec succès");
                        Query.UpdateServerTableVersion("CustomUnitTemplate");
                    }
                    else
                    {
                        Public.LanguageBox("An error occurred while saving", "Une erreur s'est produite lors de l'enregistrement");
                    }
                }
                template.Dispose();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuickCustomUnit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

    }
}