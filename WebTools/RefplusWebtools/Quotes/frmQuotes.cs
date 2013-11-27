using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;
using System.Windows.Forms;
using System.Collections;
using File = System.IO.File;
using System.Net;



namespace RefplusWebtools.Quotes
{
    public partial class FrmQuotes : Form
    {
        //this dataset hold all unit informations of the quote
        private DataSet _dsQuoteData;

        private readonly QuoteCode _backgroundCode = new QuoteCode();

        private bool _quoteIsModified;

        //these will be used later on
        private int _quoteID;
        private int _revisionID;
        //private bool IsQuoteSaved = false;
        private bool _isNewQuote = true;

        private readonly List<string> _sql = new List<string>();

        //by default it's set to your info. it need
        //to be changed when loading a quote
        private string _strQuotationByUsername = UserInformation.UserName;
        private int _intQuotationByContactID = UserInformation.ContactID;
        private int _intQuotationByGroupID = UserInformation.GroupID;

        private int _contactGroupID;

        private readonly string[] _strTableList = { "Currency", "Drawings", "CondensingUnitDrawingManager", "CondensingUnitModel", "EvaporatorDrawingManager" };

        public FrmQuotes(int quoteID, int revisionID, bool isNewQuote)
        {
            InitializeComponent();
            _quoteID = quoteID;
            _revisionID = revisionID;
            _isNewQuote = isNewQuote;
            sExtraReportsToolStrip.Visible = (UserInformation.UserName == "pvoutsinas" || UserInformation.UserName == "strepanier");
        }
        public void ClearSQL(int index)
        {
            string queryToRemove = "";
            foreach (string query in _sql)
            {
                if (query.Substring(query.Length - 1, 1) == index.ToString(CultureInfo.InvariantCulture))
                {
                    queryToRemove = query;
                }
            }
            if (queryToRemove != "")
            {
                _sql.Remove(queryToRemove);
            }
        }
        public void PushSQL(string sql)
        {
            string queryToRemove = "";
            string queryToAdd = "";
            bool found = false;
            foreach (string query in _sql)
            {
                if (query.Substring(query.Length - 1, 1) == sql.Substring(sql.Length - 1, 1))
                {
                    queryToRemove = query;
                    queryToAdd = sql;
                    found = true;
                }
            }
            if (found == false)
            {
                _sql.Add(sql);
            }
            if (queryToAdd != "" && queryToRemove != "")
            {
                _sql.Add(queryToAdd);
                _sql.Remove(queryToRemove);
            }
            if (_sql.Count == 0)
            {
                _sql.Add(sql);
            }
        }
        public int GetQuoteID()
        {
            return _quoteID;
        }
        public int GetRevisionID()
        {
            return _revisionID;
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void frmQuotes_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);
            if (!UserInformation.AccessQuoteCustomUnit)
            {
                toolAddCustomUnit.Text = Public.LanguageString("Other","Autre");
            }

            InstanciateDataset();

            Query.LoadTables(_strTableList);

            Fill_Controls();

            CheckSpecialReport();

            SetDefaults();

            //if not new quote we are loading
            if (!_isNewQuote)
            {
                LoadQuote();
            }

            SetQuoteIsModified(false);

            RefreshBasketList();
        }

        private void CheckSpecialReport()
        {
            if (UserInformation.AccessReport)
            {
                toolSpecialReports.Visible = true;
            }

            if (UserInformation.AccessReportEngineeringReport)
            {
                toolSpecialReportEngineeringReport.Enabled = true;
            }

            if (UserInformation.AccessReportAdvancedSalesReport)
            {
                toolSpecialReportAdvancedSalesReport.Enabled = true;
            }
        }

        private bool GetFreight()
        {
            return (cboFreight.SelectedIndex != 0);
        }

        private void SetDefaults()
        {
            ComboBoxControl.SetDefaultValue(cboCurrency, "CAD");

            cboTerms.SelectedIndex = 0;
            cboDelivery.SelectedIndex = 0;
            cboFreight.SelectedIndex = 0;
            //2011-08-22 : #1167 : now they want 0 defautl all the time
            //2011-03-10: needed to add this because the default multipler was alwys being set to 0.305 even though the
            //client had a higher multiplier
            //if (UserInformation.MIN_MULTIPLIER > Public.DefaultMultiplier)
            //{
            //    SetMultiplierControl(UserInformation.MIN_MULTIPLIER);
            //}
            //else
            //{
            SetMultiplierControl(Public.DefaultMultiplier);
            //}
        }

        private void Fill_Controls()
        {
            Fill_Currency();
            UpdateQuotationByFields();
        }

        private void UpdateQuotationByFields()
        {
            lblQuotationDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            lblQuotationBy.Text = UserInformation.Name;
            lblQuotationEmail.Text = UserInformation.Email;
            _strQuotationByUsername = UserInformation.UserName;
            _intQuotationByContactID = UserInformation.ContactID;
            _intQuotationByGroupID = UserInformation.GroupID;
        }

        private string GetTo()
        {
            string strTo = "";

            strTo += txtContactName.Text + Environment.NewLine;
            strTo += txtContactEmail.Text + Environment.NewLine;
            strTo += txtPhone.Text + Environment.NewLine;
            strTo += txtAddress.Text + Environment.NewLine;
            strTo += txtCity.Text + "," + txtState.Text + "," + txtCountry.Text + Environment.NewLine;
            strTo += txtZipcode.Text;

            return strTo;
        }

        private decimal CurrenyMultiplier()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboCurrency, Public.DSDatabase.Tables["Currency"], "Currency")[0]["Multiplier"]);
        }

        private void Fill_Currency()
        {
            cboCurrency.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each fluid type
            foreach (DataRow drCurrency in Public.DSDatabase.Tables["Currency"].Rows)
            {
                string strIndex = drCurrency["Currency"].ToString();
                string strText = drCurrency["Currency"].ToString();
                ComboBoxControl.AddItem(cboCurrency, strIndex, strText);
            }
        }

        private void InstanciateDataset()
        {
            _dsQuoteData = new DataSet();
            //quote main info (fields on the form)
            _dsQuoteData.Tables.Add(Tables.QuoteTable());

            //evaporator
            _dsQuoteData.Tables.Add(Tables.DtEvaporator());

            //evaporator options
            _dsQuoteData.Tables.Add(Tables.DtEvaporatorOptions());

            //Condenser
            _dsQuoteData.Tables.Add(Tables.DtCondenser());

            //Control Panel
            _dsQuoteData.Tables.Add(Tables.DtControlPanelInputs());

            //Receiver
            _dsQuoteData.Tables.Add(Tables.DtReceiverInputs());

            //Secondary Option
            _dsQuoteData.Tables.Add(Tables.DtSecondaryOptions());

            //condenser refrigerant circuits
            _dsQuoteData.Tables.Add(Tables.DtCondenserRefrigerantCircuits());

            //fluid cooler table
            _dsQuoteData.Tables.Add(Tables.DtFluidCooler());

            //pumps
            _dsQuoteData.Tables.Add(Tables.DtPumpInputs());

            //coil
            _dsQuoteData.Tables.Add(Tables.DtQuickCoil());

            //additional items
            _dsQuoteData.Tables.Add(Tables.DtAdditionalItems());

            //condensing unit
            _dsQuoteData.Tables.Add(Tables.DtCondensingUnit());

            //condensing unit compressor
            _dsQuoteData.Tables.Add(Tables.DtCondensingUnitCompressors());

            //condensing unit watercooled
            _dsQuoteData.Tables.Add(Tables.DtCondensingUnitWaterCooledCondensers());

            //condensing unit options
            _dsQuoteData.Tables.Add(Tables.DtCondensingUnitOptions());

            //Manual Coil
            _dsQuoteData.Tables.Add(Tables.DtQuickManualCoil());

            //heat pipe
            _dsQuoteData.Tables.Add(Tables.DtQuoteHeatPipe());

            //2010-09-29 Gravity Coil
            _dsQuoteData.Tables.Add(Tables.DtGravityCoil());

            //Custom Unit
            _dsQuoteData.Tables.Add(Tables.DtCustomUnitReport());

            //OEM Coil
            _dsQuoteData.Tables.Add(Tables.DtOEMCoil());

            //OEM Coil Connection
            _dsQuoteData.Tables.Add(Tables.DtOEMCoilConnections());

            //OEM Coil Distributor
            _dsQuoteData.Tables.Add(Tables.DtOEMCoilDistributors());

            //OEM Coil FlareFittings
            _dsQuoteData.Tables.Add(Tables.DtOEMCoilFlareFittings());

            //OEM Coil Price
            _dsQuoteData.Tables.Add(Tables.DtOEMCoilPrice());

            //water evap
            _dsQuoteData.Tables.Add(Tables.DtQuickWaterEvaporator());

            //water evap options
            _dsQuoteData.Tables.Add(Tables.DtWaterEvaporatorOptions());

        }

        //this refresh the basket list
        public bool RefreshBasketList()
        {
            var tagList = new string[103];
            int currentTag = 0;
            ThreadProcess.Start(Public.LanguageString("Refreshing Basket", "Rafraîchissement du panier"));
            bool oldCondensingUnits = false;
            decimal decGrandTotal = 0m;

            foreach (DataTable dtTables in _dsQuoteData.Tables)
            {
                bool existingtag;
                if (dtTables.TableName == "Evaporators")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            ++currentTag;
                        }

                    }

                }
                //2012-02-14 : #2572 : adding water evaporator
                if (dtTables.TableName == "QuickWaterEvaporator")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                           ++currentTag;
                        }                    }

                }
                if (dtTables.TableName == "Condensers")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            ++currentTag;
                        }
                    }
                }
                if (dtTables.TableName == "FluidCoolers")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            ++currentTag;
                        }
                    }
                }
                if (dtTables.TableName == "QuickCoil")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            ++currentTag;
                        }
                    }

                }
                if (dtTables.TableName == "CondensingUnit")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            ++currentTag;
                        }
                    }
                }
                if (dtTables.TableName == "QuickManualCoil")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            ++currentTag;
                        }
                    }
                }
                if (dtTables.TableName == "HeatPipes")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            ++currentTag;
                        }
                    }
                }

                if (dtTables.TableName == "GravityCoils")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            ++currentTag;
                        }
                    }

                }
                if (dtTables.TableName == "CustomUnitTable")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            ++currentTag;
                        }
                    }
                }
                if (dtTables.TableName == "OEMCoils")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        existingtag = false;
                        foreach (string tag in tagList)
                        {
                            if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString())
                            {
                                existingtag = true;
                            }
                        }
                        if (!existingtag)
                        {
                            tagList[currentTag] = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            ++currentTag;
                        }
                    }
                }

            }


            lstBasket.Items.Clear();

            foreach (string tag in tagList)
            {
                if (tag != "")
                {
                    foreach (DataTable dtTables in _dsQuoteData.Tables)
                    {
                        if (dtTables.TableName == "Evaporators")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (tag == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                                    myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                                    //add coating and fin material
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilCoatingPrice"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FinMaterialPrice"]);

                                    //add options price
                                    DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["EvaporatorOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtOptionPrice.Rows.Count > 0)
                                    {
                                        foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                                        {
                                            decPriceEach += Convert.ToDecimal(drOptionPrice["Price"]);
                                        }
                                    }
                                    dtOptionPrice.Dispose();
                                    
                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }

                        }
                        //2012-02-14 : #2572 : adding water evaporator
                        if (dtTables.TableName == "QuickWaterEvaporator")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                                    myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["EvaporatorPrice"]);

                                    //add coating and fin material
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilCoatingPrice"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FinMaterialPrice"]);

                                    //add options price
                                    DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["WaterEvaporatorOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtOptionPrice.Rows.Count > 0)
                                    {
                                        foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                                        {
                                            decPriceEach += Convert.ToDecimal(drOptionPrice["Price"]);
                                        }
                                    }
                                    dtOptionPrice.Dispose();

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    lstBasket.Items.Add(myItem);
                                }
                            }

                        }
                        if (dtTables.TableName == "Condensers")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                                    myItem.SubItems[3].Text = "Condenser : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CondenserModel"] + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["VoltageID"] + Environment.NewLine + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["VoltageDescription"] + Environment.NewLine + "Capacity : " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Final_Capacity"]).ToString("#,##0") + " BTU/H";
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CondenserPrice"]);

                                    //add control panel
                                    DataTable dtControlPanelPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtControlPanelPrice.Rows.Count > 0)
                                    {
                                        decPriceEach += Convert.ToDecimal(dtControlPanelPrice.Rows[0]["Price"]);
                                        myItem.SubItems[3].Text += Environment.NewLine + "Control Panel : " + dtControlPanelPrice.Rows[0]["ControlPanelNomenclature"] + ", " + dtControlPanelPrice.Rows[0]["ControlVoltage"];
                                        foreach (DataRow drControlPanelPrice in dtControlPanelPrice.Rows)
                                        {
                                            decPriceEach += Convert.ToDecimal(drControlPanelPrice["OptionPrice"]);
                                        }
                                    }
                                    dtControlPanelPrice.Dispose();

                                    //add Receiver
                                    DataTable dtReceiverPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ReceiverInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtReceiverPrice.Rows.Count > 0)
                                    {
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1Price"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ValvePriceIndividual"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1PatchHeaterQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1PatchHeaterPriceIndividual"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1SightGlassQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1SightGlassPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1InsulationQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1InsulationPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ReliefValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ReliefValvePrice"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2Price"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ValvePriceIndividual"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2PatchHeaterQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2PatchHeaterPriceIndividual"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2SightGlassQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2SightGlassPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2InsulationQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2InsulationPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ReliefValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ReliefValvePrice"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer1Qty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer1Price"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer2Qty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer2Price"]);
                                        decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverReinforcedBaseQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverReinforcedBasePrice"]);
                                        myItem.SubItems[3].Text += Environment.NewLine + "Receiver : ";
                                    }
                                    dtReceiverPrice.Dispose();

                                    //add Secondary Options
                                    DataTable dtSecondaryOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtSecondaryOptionPrice.Rows.Count > 0)
                                    {
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["FinMaterialPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["TubeMaterialPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CoilCoatingPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CasingFinishPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["LegsPrice"]);
                                    }
                                    dtSecondaryOptionPrice.Dispose();

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }
                        }
                        if (dtTables.TableName == "FluidCoolers")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                                    myItem.SubItems[3].Text = "Fluid Cooler : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FluidCoolerModel"] + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["VoltageID"] + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Fin"] + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["cir1"] + Environment.NewLine + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Voltage"] + Environment.NewLine + "Capacity : " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Cap"]).ToString("#,##0.0") + " MBH";
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                                    //add control panel
                                    DataTable dtControlPanelPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtControlPanelPrice.Rows.Count > 0)
                                    {
                                        decPriceEach += Convert.ToDecimal(dtControlPanelPrice.Rows[0]["Price"]);
                                        myItem.SubItems[3].Text += Environment.NewLine + "Control Panel : " + dtControlPanelPrice.Rows[0]["ControlPanelNomenclature"] + ", " + dtControlPanelPrice.Rows[0]["ControlVoltage"];
                                        foreach (DataRow drControlPanelPrice in dtControlPanelPrice.Rows)
                                        {
                                            decPriceEach += Convert.ToDecimal(drControlPanelPrice["OptionPrice"]);
                                        }
                                    }
                                    dtControlPanelPrice.Dispose();

                                    //add Pump
                                    DataTable dtPumpPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["PumpInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtPumpPrice.Rows.Count > 0)
                                    {
                                        decPriceEach += Convert.ToDecimal(dtPumpPrice.Rows[0]["PumpPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtPumpPrice.Rows[0]["ExpansionTankKitPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtPumpPrice.Rows[0]["ValvePrice"]);
                                        myItem.SubItems[3].Text += Environment.NewLine + "Pump : " + dtPumpPrice.Rows[0]["PumpNomenclature"];
                                        foreach (DataRow drPumpPrice in dtPumpPrice.Rows)
                                        {
                                            decPriceEach += Convert.ToDecimal(drPumpPrice["OptionPrice"]);
                                        }
                                    }
                                    dtPumpPrice.Dispose();

                                    //add Secondary Options
                                    DataTable dtSecondaryOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtSecondaryOptionPrice.Rows.Count > 0)
                                    {
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["FinMaterialPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["TubeMaterialPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CoilCoatingPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CasingFinishPrice"]);
                                        decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["LegsPrice"]);
                                    }
                                    dtSecondaryOptionPrice.Dispose();

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }
                        }
                        if (dtTables.TableName == "QuickCoil")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                                    myItem.SubItems[3].Text = "Coil : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilModel"] + Environment.NewLine + "Capacity (Total Heat Rejection / Sensible) : " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["R_TotalHeat"]).ToString("N1") + " / " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["R_SensibleHeat"]).ToString("N1") + " BTUH";
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], false);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilPrice"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoatingPrice"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["TurbulatorPrice"]);

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Coil));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }

                        }
                        if (dtTables.TableName == "CondensingUnit")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == tag)
                                {
                                    if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "IC" || _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "OC" || _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "IL" || _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "OL")
                                    {
                                        oldCondensingUnits = true;
                                    }

                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                                    myItem.SubItems[3].Text = "Condensing Unit : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"] + "\nVoltage : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Voltage"] + "\nCapacity : " + Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["UnitCapacity"]).ToString("N1") + " MBH";
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FinMaterialPrice"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilCoatingPrice"]);

                                    //add options price
                                    DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                                    if (dtOptionPrice.Rows.Count > 0)
                                    {
                                        foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                                        {
                                            decPriceEach += Convert.ToDecimal(drOptionPrice["Price"]);
                                        }
                                    }
                                    dtOptionPrice.Dispose();

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }
                        }
                        if (dtTables.TableName == "QuickManualCoil")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                                    myItem.SubItems[3].Text = "Manual Coil : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilModel"];
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], false);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoatingPrice"]);
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["TurbulatorPrice"]);

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.ManualCoil));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //no spec for it right now
                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }
                        }
                        if (dtTables.TableName == "HeatPipes")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                                    myItem.SubItems[3].Text = "HeatPipe : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"];
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.HeatPipe));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //spec
                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }
                        }

                        if (dtTables.TableName == "GravityCoils")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                                    myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ListPrice"]);

                                    //add coating price
                                    decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoatingPrice"]);

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.GravityCoil));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }

                        }
                        if (dtTables.TableName == "CustomUnitTable")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                                    myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                                    //get price of 1
                                    decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                                    //add additional items price
                                    decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CustomUnit));

                                    //apply multiplier
                                    decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }
                        }
                        if (dtTables.TableName == "OEMCoils")
                        {
                            for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                            {
                                if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == tag)
                                {
                                    var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                                    myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                                    myItem.SubItems[1].Text = dtTables.TableName;
                                    myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                                    myItem.SubItems[3].Text = "OEM Coil : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Model"];
                                    myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], false);

                                    //get price of 1
                                    const decimal decPriceEach = 0m;

                                    //show price
                                    myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                                    //calculate the total (price * qty)
                                    decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Quantity"]);

                                    //show total
                                    myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                                    //add up the grand total
                                    decGrandTotal = decGrandTotal + decTotalPrice;

                                    //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                                    lstBasket.Items.Add(myItem);
                                }
                            }
                        }

                    }
                }
            }
            foreach (DataTable dtTables in _dsQuoteData.Tables)
            {
                if (dtTables.TableName == "Evaporators")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if ("" == _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString())
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                            //add coating and fin material
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilCoatingPrice"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FinMaterialPrice"]);

                            //add options price
                            DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["EvaporatorOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtOptionPrice.Rows.Count > 0)
                            {
                                foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                                {
                                    decPriceEach += Convert.ToDecimal(drOptionPrice["Price"]);
                                }
                            }
                            dtOptionPrice.Dispose();

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }

                }
                //2012-02-14 : #2572 : adding water evaporator
                if (dtTables.TableName == "QuickWaterEvaporator")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["EvaporatorPrice"]);

                            //add coating and fin material
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilCoatingPrice"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FinMaterialPrice"]);

                            //add options price
                            DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["WaterEvaporatorOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtOptionPrice.Rows.Count > 0)
                            {
                                foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                                {
                                    decPriceEach += Convert.ToDecimal(drOptionPrice["Price"]);
                                }
                            }
                            dtOptionPrice.Dispose();

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            lstBasket.Items.Add(myItem);
                        }
                    }

                }
                if (dtTables.TableName == "Condensers")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            myItem.SubItems[3].Text = "Condenser : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CondenserModel"] + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["VoltageID"] + Environment.NewLine + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["VoltageDescription"] + Environment.NewLine + "Capacity : " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Final_Capacity"]).ToString("#,##0") + " BTU/H";
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CondenserPrice"]);

                            //add control panel
                            DataTable dtControlPanelPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtControlPanelPrice.Rows.Count > 0)
                            {
                                decPriceEach += Convert.ToDecimal(dtControlPanelPrice.Rows[0]["Price"]);
                                myItem.SubItems[3].Text += Environment.NewLine + "Control Panel : " + dtControlPanelPrice.Rows[0]["ControlPanelNomenclature"] + ", " + dtControlPanelPrice.Rows[0]["ControlVoltage"];
                                foreach (DataRow drControlPanelPrice in dtControlPanelPrice.Rows)
                                {
                                    decPriceEach += Convert.ToDecimal(drControlPanelPrice["OptionPrice"]);
                                }
                            }
                            dtControlPanelPrice.Dispose();

                            //add Receiver
                            DataTable dtReceiverPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ReceiverInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtReceiverPrice.Rows.Count > 0)
                            {
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1Price"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ValvePriceIndividual"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1PatchHeaterQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1PatchHeaterPriceIndividual"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1SightGlassQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1SightGlassPrice"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1InsulationQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1InsulationPrice"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ReliefValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ReliefValvePrice"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2Price"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ValvePriceIndividual"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2PatchHeaterQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2PatchHeaterPriceIndividual"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2SightGlassQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2SightGlassPrice"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2InsulationQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2InsulationPrice"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ReliefValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ReliefValvePrice"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer1Qty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer1Price"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer2Qty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer2Price"]);
                                decPriceEach += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverReinforcedBaseQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverReinforcedBasePrice"]);
                                myItem.SubItems[3].Text += Environment.NewLine + "Receiver : ";
                            }
                            dtReceiverPrice.Dispose();

                            //add Secondary Options
                            DataTable dtSecondaryOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtSecondaryOptionPrice.Rows.Count > 0)
                            {
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["FinMaterialPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["TubeMaterialPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CoilCoatingPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CasingFinishPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["LegsPrice"]);
                            }
                            dtSecondaryOptionPrice.Dispose();

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }
                }
                if (dtTables.TableName == "FluidCoolers")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            myItem.SubItems[3].Text = "Fluid Cooler : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FluidCoolerModel"] + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["VoltageID"] + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Fin"] + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["cir1"] + Environment.NewLine + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Voltage"] + Environment.NewLine + "Capacity : " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Cap"]).ToString("#,##0.0") + " MBH";
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                            //add control panel
                            DataTable dtControlPanelPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtControlPanelPrice.Rows.Count > 0)
                            {
                                decPriceEach += Convert.ToDecimal(dtControlPanelPrice.Rows[0]["Price"]);
                                myItem.SubItems[3].Text += Environment.NewLine + "Control Panel : " + dtControlPanelPrice.Rows[0]["ControlPanelNomenclature"] + ", " + dtControlPanelPrice.Rows[0]["ControlVoltage"];
                                foreach (DataRow drControlPanelPrice in dtControlPanelPrice.Rows)
                                {
                                    decPriceEach += Convert.ToDecimal(drControlPanelPrice["OptionPrice"]);
                                }
                            }
                            dtControlPanelPrice.Dispose();

                            //add Pump
                            DataTable dtPumpPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["PumpInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtPumpPrice.Rows.Count > 0)
                            {
                                decPriceEach += Convert.ToDecimal(dtPumpPrice.Rows[0]["PumpPrice"]);
                                decPriceEach += Convert.ToDecimal(dtPumpPrice.Rows[0]["ExpansionTankKitPrice"]);
                                decPriceEach += Convert.ToDecimal(dtPumpPrice.Rows[0]["ValvePrice"]);
                                myItem.SubItems[3].Text += Environment.NewLine + "Pump : " + dtPumpPrice.Rows[0]["PumpNomenclature"];
                                foreach (DataRow drPumpPrice in dtPumpPrice.Rows)
                                {
                                    decPriceEach += Convert.ToDecimal(drPumpPrice["OptionPrice"]);
                                }
                            }
                            dtPumpPrice.Dispose();

                            //add Secondary Options
                            DataTable dtSecondaryOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtSecondaryOptionPrice.Rows.Count > 0)
                            {
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["FinMaterialPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["TubeMaterialPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CoilCoatingPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CasingFinishPrice"]);
                                decPriceEach += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["LegsPrice"]);
                            }
                            dtSecondaryOptionPrice.Dispose();

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }
                }
                if (dtTables.TableName == "QuickCoil")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            myItem.SubItems[3].Text = "Coil : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilModel"] + Environment.NewLine + "Capacity (Total Heat Rejection / Sensible) : " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["R_TotalHeat"]).ToString("N1") + " / " + Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["R_SensibleHeat"]).ToString("N1") + " BTUH";
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], false);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilPrice"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoatingPrice"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["TurbulatorPrice"]);

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Coil));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }

                }
                if (dtTables.TableName == "CondensingUnit")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == "")
                        {
                            if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "IC" || _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "OC" || _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "IL" || _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"].ToString().Substring(0, 2) == "OL")
                            {
                                oldCondensingUnits = true;
                            }

                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            myItem.SubItems[3].Text = "Condensing Unit : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"] + "\nVoltage : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Voltage"] + "\nCapacity : " + Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["UnitCapacity"]).ToString("N1") + " MBH";
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["FinMaterialPrice"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilCoatingPrice"]);

                            //add options price
                            DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit) + " AND ItemID = " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], "");
                            if (dtOptionPrice.Rows.Count > 0)
                            {
                                foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                                {
                                    decPriceEach += Convert.ToDecimal(drOptionPrice["Price"]);
                                }
                            }
                            dtOptionPrice.Dispose();

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }
                }
                if (dtTables.TableName == "QuickManualCoil")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            myItem.SubItems[3].Text = "Manual Coil : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoilModel"];
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], false);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoatingPrice"]);
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["TurbulatorPrice"]);

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.ManualCoil));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //no spec for it right now
                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }
                }
                if (dtTables.TableName == "HeatPipes")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            myItem.SubItems[3].Text = "HeatPipe : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Model"];
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.HeatPipe));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //spec
                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }
                }

                if (dtTables.TableName == "GravityCoils")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ListPrice"]);

                            //add coating price
                            decPriceEach += Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["CoatingPrice"]);

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.GravityCoil));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }

                }
                if (dtTables.TableName == "CustomUnitTable")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Tag"].ToString();
                            myItem.SubItems[3].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Description"].ToString();
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]);

                            //get price of 1
                            decimal decPriceEach = Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Price"]);

                            //add additional items price
                            decPriceEach += GetAdditonnalItemsPrice(Convert.ToInt32(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"]), QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CustomUnit));

                            //apply multiplier
                            decPriceEach = decPriceEach * numMultiplier.Value * CurrenyMultiplier();

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }
                }
                if (dtTables.TableName == "OEMCoils")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        if (_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString() == "")
                        {
                            var myItem = new GlacialComponents.Controls.GLItem(lstBasket);
                            myItem.SubItems[0].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"].ToString();
                            myItem.SubItems[1].Text = dtTables.TableName;
                            myItem.SubItems[2].Text = _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Tag"].ToString();
                            myItem.SubItems[3].Text = "OEM Coil : " + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Model"];
                            myItem.SubItems[4].Control = QuantityUpDown(Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Quantity"]), dtTables.TableName + "-" + _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["ItemID"], false);

                            //get price of 1
                            const decimal decPriceEach = 0m;

                            //show price
                            myItem.SubItems[5].Text = decPriceEach.ToString("$#,##0.00");

                            //calculate the total (price * qty)
                            decimal decTotalPrice = decPriceEach * Convert.ToDecimal(_dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Input_Quantity"]);

                            //show total
                            myItem.SubItems[6].Text = decTotalPrice.ToString("$#,##0.00");

                            //add up the grand total
                            decGrandTotal = decGrandTotal + decTotalPrice;

                            //myItem.SubItems[7].Control = GenerateSpecButton(dtTables.TableName + "-" + intRow.ToString());

                            lstBasket.Items.Add(myItem);
                        }
                    }
                }
            }

            for (int i = 0; i < lstBasket.Items.Count; i++)
            {
                lstBasket.Items[i].SubItems[7].Text = i.ToString(CultureInfo.InvariantCulture);
            }

            lstBasket.Refresh();

            //show grand total
            lblTotalPriceValue.Text = decGrandTotal.ToString("$#,##0.00");

            ThreadProcess.Stop();
            Focus();
            return oldCondensingUnits;
        }

        private decimal GetAdditonnalItemsPrice(int itemID, int itemType)
        {
            decimal decTotalAdditionalItemsPrice = 0m;

            DataTable dtAdditionnalItemsList = Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemType = " + itemType.ToString(CultureInfo.InvariantCulture) + " AND ItemID = " + itemID, "");

            foreach (DataRow drAdditionnalItemsList in dtAdditionnalItemsList.Rows)
            {
                decTotalAdditionalItemsPrice += (Convert.ToDecimal(drAdditionnalItemsList["Price"]) * Convert.ToDecimal(drAdditionnalItemsList["Quantity"]));
            }

            return decTotalAdditionalItemsPrice;
        }

        private decimal GetCondensingUnitPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnit"], "ItemID = " + itemID, "").Rows[0]["Price"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnit"], "ItemID = " + itemID, "").Rows[0]["FinMaterialPrice"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnit"], "ItemID = " + itemID, "").Rows[0]["CoilCoatingPrice"]);

            //add options price
            DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit) + " AND ItemID = " + itemID, "");
            if (dtOptionPrice.Rows.Count > 0)
            {
                foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                {
                    decGrandTotal += Convert.ToDecimal(drOptionPrice["Price"]);
                }
            }
            dtOptionPrice.Dispose();

            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit));

            return decGrandTotal;
        }

        private decimal GetCoilPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemID = " + itemID, "").Rows[0]["CoilPrice"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemID = " + itemID, "").Rows[0]["CoatingPrice"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemID = " + itemID, "").Rows[0]["TurbulatorPrice"]);

            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Coil));

            return decGrandTotal;
        }

        private decimal GetManualCoilPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickManualCoil"], "ItemID = " + itemID, "").Rows[0]["Price"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickManualCoil"], "ItemID = " + itemID, "").Rows[0]["CoatingPrice"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickManualCoil"], "ItemID = " + itemID, "").Rows[0]["TurbulatorPrice"]);

            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.ManualCoil));

            return decGrandTotal;
        }

        private decimal GetHeatPipePrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["HeatPipes"], "ItemID = " + itemID, "").Rows[0]["Price"]);

            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.HeatPipe));

            return decGrandTotal;
        }

        private decimal GetGravityCoilPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["GravityCoils"], "ItemID = " + itemID, "").Rows[0]["ListPrice"]);
            if (Public.SelectAndSortTable(_dsQuoteData.Tables["GravityCoils"], "ItemID = " + itemID, "").Rows[0]["CoilCoatingInput"].ToString() != "None")
            {
                decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["GravityCoils"], "ItemID = " + itemID, "").Rows[0]["CoatingPrice"]);
            }
            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.GravityCoil));

            return decGrandTotal;
        }

        private decimal GetCustomUnitPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"], "ItemID = " + itemID, "").Rows[0]["Price"]);

            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CustomUnit));

            return decGrandTotal;
        }



        private decimal GetEvaporatorPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemID = " + itemID, "").Rows[0]["Price"]);

            //add coating and fin material
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemID = " + itemID, "").Rows[0]["CoilCoatingPrice"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemID = " + itemID, "").Rows[0]["FinMaterialPrice"]);

            //add options price
            DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["EvaporatorOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator) + " AND ItemID = " + itemID, "");
            if (dtOptionPrice.Rows.Count > 0)
            {
                foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                {
                    decGrandTotal += Convert.ToDecimal(drOptionPrice["Price"]);
                }
            }
            dtOptionPrice.Dispose();


            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator));

            return decGrandTotal;
        }


        private decimal GetWaterEvaporatorPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickWaterEvaporator"], "ItemID = " + itemID, "").Rows[0]["EvaporatorPrice"]);

            //add coating and fin material
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickWaterEvaporator"], "ItemID = " + itemID, "").Rows[0]["CoilCoatingPrice"]);
            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickWaterEvaporator"], "ItemID = " + itemID, "").Rows[0]["FinMaterialPrice"]);

            //add options price
            DataTable dtOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["WaterEvaporatorOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator) + " AND ItemID = " + itemID, "");
            if (dtOptionPrice.Rows.Count > 0)
            {
                foreach (DataRow drOptionPrice in dtOptionPrice.Rows)
                {
                    decGrandTotal += Convert.ToDecimal(drOptionPrice["Price"]);
                }
            }
            dtOptionPrice.Dispose();


            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator));

            return decGrandTotal;
        }


        private decimal GetFluidCoolerPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["FluidCoolers"], "ItemID = " + itemID, "").Rows[0]["Price"]);

            DataTable dtControlPanelPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, "");
            if (dtControlPanelPrice.Rows.Count > 0)
            {
                decGrandTotal += Convert.ToDecimal(dtControlPanelPrice.Rows[0]["Price"]);
                foreach (DataRow drControlPanelPrice in dtControlPanelPrice.Rows)
                {
                    decGrandTotal += Convert.ToDecimal(drControlPanelPrice["OptionPrice"]);
                }
            }
            dtControlPanelPrice.Dispose();

            //add Pump
            DataTable dtPumpPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["PumpInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, "");
            if (dtPumpPrice.Rows.Count > 0)
            {
                decGrandTotal += Convert.ToDecimal(dtPumpPrice.Rows[0]["PumpPrice"]);
                decGrandTotal += Convert.ToDecimal(dtPumpPrice.Rows[0]["ExpansionTankKitPrice"]);
                decGrandTotal += Convert.ToDecimal(dtPumpPrice.Rows[0]["ValvePrice"]);
                foreach (DataRow drPumpPrice in dtPumpPrice.Rows)
                {
                    decGrandTotal += Convert.ToDecimal(drPumpPrice["OptionPrice"]);
                }
            }
            dtPumpPrice.Dispose();

            //add Secondary Options
            DataTable dtSecondaryOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, "");
            if (dtSecondaryOptionPrice.Rows.Count > 0)
            {
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["FinMaterialPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["TubeMaterialPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CoilCoatingPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CasingFinishPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["LegsPrice"]);
            }
            dtSecondaryOptionPrice.Dispose();

            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler));

            return decGrandTotal;
        }

        private decimal GetCondenserPrice(int itemID)
        {
            decimal decGrandTotal = 0m;

            decGrandTotal += Convert.ToDecimal(Public.SelectAndSortTable(_dsQuoteData.Tables["Condensers"], "ItemID = " + itemID, "").Rows[0]["CondenserPrice"]);

            DataTable dtControlPanelPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, "");
            if (dtControlPanelPrice.Rows.Count > 0)
            {
                decGrandTotal += Convert.ToDecimal(dtControlPanelPrice.Rows[0]["Price"]);
                foreach (DataRow drControlPanelPrice in dtControlPanelPrice.Rows)
                {
                    decGrandTotal += Convert.ToDecimal(drControlPanelPrice["OptionPrice"]);
                }
            }
            dtControlPanelPrice.Dispose();

            //add Receiver
            DataTable dtReceiverPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["ReceiverInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, "");
            if (dtReceiverPrice.Rows.Count > 0)
            {
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1Price"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ValvePriceIndividual"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1PatchHeaterQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1PatchHeaterPriceIndividual"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1SightGlassQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1SightGlassPrice"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1InsulationQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1InsulationPrice"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ReliefValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver1ReliefValvePrice"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2Price"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ValvePriceIndividual"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2PatchHeaterQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2PatchHeaterPriceIndividual"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2SightGlassQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2SightGlassPrice"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2InsulationQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2InsulationPrice"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ReliefValveQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["Receiver2ReliefValvePrice"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer1Qty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer1Price"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer2Qty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverTransformer2Price"]);
                decGrandTotal += Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverReinforcedBaseQty"]) * Convert.ToDecimal(dtReceiverPrice.Rows[0]["ReceiverReinforcedBasePrice"]);
            }
            dtReceiverPrice.Dispose();

            //add Secondary Options
            DataTable dtSecondaryOptionPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, "");
            if (dtSecondaryOptionPrice.Rows.Count > 0)
            {
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["FinMaterialPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["TubeMaterialPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CoilCoatingPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["CasingFinishPrice"]);
                decGrandTotal += Convert.ToDecimal(dtSecondaryOptionPrice.Rows[0]["LegsPrice"]);
            }
            dtSecondaryOptionPrice.Dispose();

            //add additional items price
            decGrandTotal += GetAdditonnalItemsPrice(itemID, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser));

            return decGrandTotal;
        }

        private NumericUpDown QuantityUpDown(decimal decDefaultValue, string strTag, bool enable = true)
        {
            var myNum = new NumericUpDown {Minimum = 1m, Maximum = 100m, Value = decDefaultValue, Tag = strTag};
            myNum.ValueChanged += (Quantity_ValueChanged);
            if (!enable)
            {
                myNum.Enabled = false;
                myNum.BackColor = Color.White;
                myNum.ForeColor = Color.Black;
            }
            return myNum;
        }


        //event handler for quantity up down
        private void Quantity_ValueChanged(object sender, EventArgs e)
        {
            //get the tag
            string[] strTag = ((NumericUpDown)sender).Tag.ToString().Split(Convert.ToChar("-"));
            int newQuantity = Convert.ToInt32(((NumericUpDown)sender).Value);

            for (int irow = 0; irow < _dsQuoteData.Tables[strTag[0]].Rows.Count; irow++)
            {
                if (_dsQuoteData.Tables[strTag[0]].Rows[irow]["ItemID"].ToString() == strTag[1])
                {
                    //evaporator special thing to do.
                    //capacity searched need to be updated as well
                    if (strTag[0] == "Evaporators")
                    {
                        decimal oldCapacity = Convert.ToDecimal(_dsQuoteData.Tables[strTag[0]].Rows[irow]["RequiredCapacity"]);

                        _dsQuoteData.Tables[strTag[0]].Rows[irow]["RequiredCapacity"] = (oldCapacity / Convert.ToDecimal(_dsQuoteData.Tables[strTag[0]].Rows[irow]["Quantity"])) * newQuantity;
                    }

                    else if (strTag[0] == "GravityCoils")
                    {
                        decimal oldCapacity = Convert.ToDecimal(_dsQuoteData.Tables[strTag[0]].Rows[irow]["CapacityInput"]);

                        _dsQuoteData.Tables[strTag[0]].Rows[irow]["CapacityInput"] = (oldCapacity / Convert.ToDecimal(_dsQuoteData.Tables[strTag[0]].Rows[irow]["Quantity"])) * newQuantity;
                    }

                    _dsQuoteData.Tables[strTag[0]].Rows[irow]["Quantity"] = newQuantity;
                }
            }

            //refresh the list
            RefreshBasketList();
        }

       private void GenerateSingleHeatPipeSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["HeatPipes"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the coil
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickHeatPipe.HeatPipeReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["HeatPipes"], "ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }


        private void GenerateSingleGravityCoilSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["GravityCoils"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the coil
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickGravityCoil.GravityCoilReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["GravityCoils"], "ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }

        private void GenerateSingleCoilSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["QuickCoil"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the coil
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickCoil.CoilReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }

        private int GetCurrentQuoteIDForSpecReport()
        {
            return _quoteID;
        }

        private string GetCurrentQuoteRevisionTextForSpecReport()
        {
            return (_quoteID == 0 ? "" : Public.RevisionID_To_Letter(_revisionID));
        }

        private void GenerateSingleFluidCoolerSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["FluidCoolers"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the fluid cooler
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickFluidCooler.FluidCoolerReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["FluidCoolers"], "ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["PumpInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }

        private void GenerateSingleCondenserSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["Condensers"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the condenser
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickCondenser.CondenserReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["Condensers"], "ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["RefrigerantCircuits"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["ReceiverInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }

        

        private void GenerateSingleCondensingUnitSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["CondensingUnit"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the condenser
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickCondensingUnit.CondensingUnitReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnit"], "ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitCompressorReceiver"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit) + " AND ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitWaterCooledCondenser"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit) + " AND ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitOption"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit) + " AND ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }


        private void GenerateSingleEvaporatorSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["Evaporators"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the evaporator
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickEvaporator.EvaporatorReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["EvaporatorOption"], "ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }

        private void GenerateSingleWaterEvaporatorSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[intIndex]["ItemID"]);

            //i already have a function that create the spec report of the water evaporator
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickWaterEvaporator.WaterEvaporatorReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickWaterEvaporator"], "ItemID = " + itemID, ""), Public.SelectAndSortTable(_dsQuoteData.Tables["WaterEvaporatorOption"], "ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }

        private void GenerateSingleEvaporatorTechSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = intIndex;
            
            //i already have a function that create the spec report of the evaporator
            //by just passing it's datatable to it and it return the filename and path
            string strFileLocation = QuickEvaporator.EvaporatorReport.GenerateTechReport(Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemID = " + itemID, ""), false);

            //if the creation of pdf worked
            //add the file name (containing path) to the list of files to be merged
            if (strFileLocation != "")
            {
                lstFileNames.Add(strFileLocation);
            }
        }


        private void GenerateSingleCustomUnitSpec(int intIndex, ref List<string> lstFileNames)
        {
            int itemID = Convert.ToInt32(_dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["ItemID"]);

            //2011-03-03: Simon wants when he put 2 empty lines it means he dont want the report to show up.

            bool generateReport = true;

            if (_dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Text1"].ToString() == "BLANK LINE" &&
                _dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Value1"].ToString() == "BLANK LINE" &&
                _dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Unit1"].ToString() == "BLANK LINE" &&
                _dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Text2"].ToString() == "BLANK LINE" &&
                _dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Value2"].ToString() == "BLANK LINE" &&
                _dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Unit2"].ToString() == "BLANK LINE")
            {
                generateReport = false;
                for (int i = 3; i <= 100; i++)
                {
                    if (_dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Text" + i].ToString() != "")
                    {
                        generateReport = true;
                        i = 101;
                    }
                    if (_dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Value" + i].ToString() != "")
                    {
                        generateReport = true;
                        i = 101;
                    }
                    if (_dsQuoteData.Tables["CustomUnitTable"].Rows[intIndex]["Unit" + i].ToString() != "")
                    {
                        generateReport = true;
                        i = 101;
                    }
                }
            }

            if (generateReport)
            {

                    //i already have a function that create the spec report of the custom unit
                    //by just passing it's datatable to it and it return the filename and path
                    string strFileLocation = QuickCustomUnit.CustomUnitReport.GenerateDataReport(Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"], "ItemID = " + itemID, ""), false, GetCurrentQuoteIDForSpecReport(), GetCurrentQuoteRevisionTextForSpecReport());


                    //if the creation of pdf worked
                    //add the file name (containing path) to the list of files to be merged
                    if (strFileLocation != "")
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                
            }
        }

        private void toolAddEvaporator_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteEvaporator)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Evaporator Selection", "Préparation de la sélection d'Évaporateur"));
                //open evaportator in add mode (-1 as index)
                var quickEvaporator = new QuickEvaporator.FrmQuickEvaporator(this, _dsQuoteData, -1);
                quickEvaporator.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        public int GetNextID(string strTableName)
        {
            //set to 0 so the first item get 1 as index
            int intIndex = 0;
            for (int intRecord = 0; intRecord < _dsQuoteData.Tables[strTableName].Rows.Count; intRecord++)
            {
                //loop throught all to get the biggest one
                intIndex = Convert.ToInt32(Math.Max(intIndex, Convert.ToDecimal(_dsQuoteData.Tables[strTableName].Rows[intRecord]["ItemID"])));
            }
            //add one because we want the next one
            ++intIndex;
            return intIndex;

        }

        private void lstBasket_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {

            if (lstBasket.SelectedItems.Count > 0)
            {
                ArrayList myItem = lstBasket.SelectedItems;
                string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                int intPosition = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[7].Text);
                switch (strTable)
                {
                    case "Evaporators":
                        if (UserInformation.AccessQuoteEvaporator)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Evaporator Selection", "Préparation de la sélection d'Évaporateur"));
                            //open evaportator in edit mode
                            var quickEvaporator = new QuickEvaporator.FrmQuickEvaporator(this, _dsQuoteData, intIndex);
                            quickEvaporator.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "QuickWaterEvaporator":
                        if (UserInformation.AccessQuoteWaterEvaporator)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Water Evaporator Selection", "Préparation de la sélection d'Évaporateur à l'eau"));
                            //open evaportator in edit mode
                            var quickWaterEvaporator = new QuickWaterEvaporator.FrmQuickWaterEvaporator(this, _dsQuoteData, intIndex);
                            quickWaterEvaporator.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "Condensers":
                        if (UserInformation.AccessQuoteCondenser)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Condenser Selection", "Préparation de la sélection de Condenseur"));
                            //open condenser in edit mode
                            var quickCondenser = new QuickCondenser.FrmQuickCondenser(this, _dsQuoteData, intIndex);
                            quickCondenser.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "FluidCoolers":
                        if (UserInformation.AccessQuoteFluidCooler)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Fluid Cooler Selection", "Préparation de la sélection de Refroidisseur Liquide"));
                            //open fluid cooler in edit mode
                            var quickFluidCooler = new QuickFluidCooler.FrmQuickFluidCooler(this, _dsQuoteData, intIndex);
                            quickFluidCooler.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "QuickCoil":
                        if (UserInformation.AccessQuoteCoil)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Coil Selection", "Préparation de la sélection de Serpentin"));
                            //open coil in edit mode
                            var quickCoilform = new QuickCoil.FrmQuickCoil(this, _dsQuoteData, intIndex, QuickCoil.FrmQuickCoil.CoilOpenType.Selection, intPosition);
                            quickCoilform.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "CondensingUnit":
                        if (UserInformation.AccessQuoteCondensingUnit)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Condensing Unit Selection", "Préparation de la sélection du groupe compresseur-condenseur"));
                            //open condensing unit in edit mode
                            var quickCondensingUnit = new QuickCondensingUnit.FrmQuickCondensingUnit(this, _dsQuoteData, intIndex);
                            quickCondensingUnit.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "QuickManualCoil":
                        if (UserInformation.AccessQuoteManualCoil)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Coil Selection", "Préparation de la sélection de Serpentin"));
                            //open coil in edit mode
                            var quickCoilform = new QuickCoil.FrmQuickCoil(this, _dsQuoteData, intIndex, QuickCoil.FrmQuickCoil.CoilOpenType.Manual, intPosition);
                            quickCoilform.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "HeatPipes":
                        if (UserInformation.AccessQuoteHeatPipe)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Heat Pipe Selection", "Préparation de la sélection des Caloducs"));
                            //open heat pipe in edit mode
                            var quickHeatPipeform = new QuickHeatPipe.FrmQuickHeatPipe(this, _dsQuoteData, intIndex);
                            quickHeatPipeform.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "GravityCoils":
                        if (UserInformation.AccessQuoteGravityCoil)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing Gravity Coil Selection", "Préparation de la sélection des Serpentin à gravité"));
                            //open heat pipe in edit mode
                            var quickGravityCoilform = new QuickGravityCoil.FrmGravityCoil(this, _dsQuoteData, intIndex);
                            quickGravityCoilform.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "CustomUnitTable":
                        ThreadProcess.Start(Public.LanguageString("Preparing Custom Unit Selection", "Préparation de la sélection de l'unité personnalisée"));
                        var quickCustomUnit = new QuickCustomUnit.FrmQuickCustomUnit(this, _dsQuoteData, intIndex);
                        quickCustomUnit.ShowDialog();
                        
                        break;

                    case "OEMCoils":
                        if (UserInformation.AccessQuoteOEMCoil)
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing OEM Coil Selection", "Préparation de la sélection de serpentin OEM"));
                            //open oem in edit mode
                            var editOEMCoil = new OEMCoil.FrmOEMCoil(this, _dsQuoteData, intIndex);
                            editOEMCoil.ShowDialog();
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                }
            }
            else
            {
                Public.LanguageBox("You must select something in order to edit.", "Vous devez sélectionner quelque chose pour modifier.");
            }
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void numMultiplier_ValueChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
            //refresh the list
            RefreshBasketList();
        }


        private void toolRemove_Click(object sender, EventArgs e)
        {
            RemoveUnit();
        }

        private void RemoveUnit()
        {
            if (lstBasket.SelectedItems.Count > 0)
            {
                ArrayList myItem = lstBasket.SelectedItems;
                string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                switch (strTable)
                {
                    case "Evaporators":
                        if (UserInformation.AccessQuoteEvaporator)
                        {
                            DeleteFromQuoteEvaporator(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "QuickWaterEvaporator":
                        if (UserInformation.AccessQuoteWaterEvaporator)
                        {
                            DeleteFromQuoteWaterEvaporator(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "Condensers":
                        if (UserInformation.AccessQuoteCondenser)
                        {
                            DeleteFromQuoteCondenser(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "FluidCoolers":
                        if (UserInformation.AccessQuoteFluidCooler)
                        {
                            DeleteFromQuoteFluidCooler(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "QuickCoil":
                        if (UserInformation.AccessQuoteCoil)
                        {
                            DeleteFromQuoteCoil(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Coil));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "CondensingUnit":
                        if (UserInformation.AccessQuoteCondensingUnit)
                        {
                            DeleteFromQuoteCondensingUnit(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "QuickManualCoil":
                        if (UserInformation.AccessQuoteManualCoil)
                        {
                            DeleteFromQuoteManualCoil(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.ManualCoil));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "HeatPipes":
                        if (UserInformation.AccessQuoteHeatPipe)
                        {
                            DeleteFromQuoteHeatPipe(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.HeatPipe));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "GravityCoils":
                        if (UserInformation.AccessQuoteGravityCoil)
                        {
                            DeleteFromQuoteGravityCoil(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.GravityCoil));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "CustomUnitTable":
                        if (UserInformation.AccessQuoteCustomUnit)
                        {
                            DeleteFromQuoteCustomUnit(intIndex);
                            DeleteFromQuoteAdditionalItems(intIndex, QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CustomUnit));
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                    case "OEMCoils":
                        if (UserInformation.AccessQuoteOEMCoil)
                        {
                            DeleteFromQuoteOEMCoil(intIndex);
                        }
                        else
                        {
                            Public.NoPermissionMessage();
                        }
                        break;
                }

                RefreshBasketList();
                SetQuoteIsModified(true);
            }
            else
            {
                Public.LanguageBox("You must select a unit to remove.", "Vous devez sélectionner une unité pour la retirer.");
            }
        }

        private void toolAddCondenser_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteCondenser)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Condenser Selection", "Préparation de la sélection de Condenseur"));
                var quickCondenser = new QuickCondenser.FrmQuickCondenser(this, _dsQuoteData, -1);
                quickCondenser.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        public void DeleteFromQuoteCoil(int intIndex)
        {
            DataTable dtGoodCoil = Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Coil) + " OR ItemID <> " + intIndex, "");
            _dsQuoteData.Tables["QuickCoil"].Rows.Clear();
            foreach (DataRow drGoodCoil in dtGoodCoil.Rows)
            {
                _dsQuoteData.Tables["QuickCoil"].Rows.Add(drGoodCoil.ItemArray);
            }
        }

        public void DeleteFromQuoteManualCoil(int intIndex)
        {
            DataTable dtGoodCoil = Public.SelectAndSortTable(_dsQuoteData.Tables["QuickManualCoil"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.ManualCoil) + " OR ItemID <> " + intIndex, "");
            _dsQuoteData.Tables["QuickManualCoil"].Rows.Clear();
            foreach (DataRow drGoodCoil in dtGoodCoil.Rows)
            {
                _dsQuoteData.Tables["QuickManualCoil"].Rows.Add(drGoodCoil.ItemArray);
            }
        }

        public void DeleteFromQuoteEvaporator(int intIndex)
        {
            DataTable dtGoodEvaporators = Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator) + " OR ItemID <> " + intIndex, "");
            DataTable dtGoodOptions = Public.SelectAndSortTable(_dsQuoteData.Tables["EvaporatorOption"], "ItemID <> " + intIndex, "");

            _dsQuoteData.Tables["Evaporators"].Rows.Clear();
            foreach (DataRow drGoodEvaporators in dtGoodEvaporators.Rows)
            {
                _dsQuoteData.Tables["Evaporators"].Rows.Add(drGoodEvaporators.ItemArray);
            }

            _dsQuoteData.Tables["EvaporatorOption"].Rows.Clear();
            foreach (DataRow drGoodOptions in dtGoodOptions.Rows)
            {
                _dsQuoteData.Tables["EvaporatorOption"].Rows.Add(drGoodOptions.ItemArray);
            }
        }

        public void DeleteFromQuoteWaterEvaporator(int intIndex)
        {
            DataTable dtGoodWaterEvaporators = Public.SelectAndSortTable(_dsQuoteData.Tables["QuickWaterEvaporator"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator) + " OR ItemID <> " + intIndex, "");
            DataTable dtGoodOptions = Public.SelectAndSortTable(_dsQuoteData.Tables["WaterEvaporatorOption"], "ItemID <> " + intIndex, "");

            _dsQuoteData.Tables["QuickWaterEvaporator"].Rows.Clear();
            foreach (DataRow drGoodEvaporators in dtGoodWaterEvaporators.Rows)
            {
                _dsQuoteData.Tables["QuickWaterEvaporator"].Rows.Add(drGoodEvaporators.ItemArray);
            }

            _dsQuoteData.Tables["WaterEvaporatorOption"].Rows.Clear();
            foreach (DataRow drGoodOptions in dtGoodOptions.Rows)
            {
                _dsQuoteData.Tables["WaterEvaporatorOption"].Rows.Add(drGoodOptions.ItemArray);
            }
        }

        public void DeleteFromQuoteAdditionalItems(int intIndex, int intItemType)
        {
            DataTable dtGoodAdditionnalItems = Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemType <> " + intItemType + " OR ItemID <> " + intIndex, "");
            _dsQuoteData.Tables["AdditionalItems"].Rows.Clear();
            foreach (DataRow drGoodAdditionnalItems in dtGoodAdditionnalItems.Rows)
            {
                _dsQuoteData.Tables["AdditionalItems"].Rows.Add(drGoodAdditionnalItems.ItemArray);
            }
        }

        public void UpdateAdditionalItems(int intIndex, int intItemType, int newItemID)
        {
            for (int iAdditionalItems = 0; iAdditionalItems < _dsQuoteData.Tables["AdditionalItems"].Rows.Count; iAdditionalItems++)
            {
                if (Convert.ToInt32(_dsQuoteData.Tables["AdditionalItems"].Rows[iAdditionalItems]["ItemType"]) == intItemType
                    && Convert.ToInt32(_dsQuoteData.Tables["AdditionalItems"].Rows[iAdditionalItems]["ItemID"]) == intIndex)
                {
                    _dsQuoteData.Tables["AdditionalItems"].Rows[iAdditionalItems]["ItemID"] = newItemID;
                }
            }
        }

        public void CopyAdditionalItems(int intIndex, int intItemType, int newItemID)
        {
            for (int iAdditionalItems = 0; iAdditionalItems < _dsQuoteData.Tables["AdditionalItems"].Rows.Count; iAdditionalItems++)
            {
                if (Convert.ToInt32(_dsQuoteData.Tables["AdditionalItems"].Rows[iAdditionalItems]["ItemType"]) == intItemType
                    && Convert.ToInt32(_dsQuoteData.Tables["AdditionalItems"].Rows[iAdditionalItems]["ItemID"]) == intIndex)
                {
                    //create new datarow
                    DataRow drNew = _dsQuoteData.Tables["AdditionalItems"].NewRow();

                    //set it to equal the data of the one to copy
                    //ItemArray is used because it's the only way to set datarow
                    //data passing by value and not reference
                    drNew.ItemArray = _dsQuoteData.Tables["AdditionalItems"].Rows[iAdditionalItems].ItemArray;

                    //now change the id of the copy
                    drNew["ItemID"] = newItemID;

                    //add the copy to the table
                    //that wont cause problem in the loop even if it use the table.count
                    //because the ID of the new ones wont match the one we are looking for.
                    _dsQuoteData.Tables["AdditionalItems"].Rows.Add(drNew);
                }
            }
        }

        public void DeleteFromQuoteCondensingUnit(int intIndex)
        {
            DataTable dtGoodCondensingUnit = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnit"], "ItemID <> " + intIndex, "");
            DataTable dtGoodCompressor = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitCompressorReceiver"], "ItemID <> " + intIndex, "");
            DataTable dtGoodWaterCooled = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitWaterCooledCondenser"], "ItemID <> " + intIndex, "");
            DataTable dtGoodOptions = Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitOption"], "ItemID <> " + intIndex, "");

            _dsQuoteData.Tables["CondensingUnit"].Rows.Clear();
            foreach (DataRow drGoodCondensingUnit in dtGoodCondensingUnit.Rows)
            {
                _dsQuoteData.Tables["CondensingUnit"].Rows.Add(drGoodCondensingUnit.ItemArray);
            }

            _dsQuoteData.Tables["CondensingUnitCompressorReceiver"].Rows.Clear();
            foreach (DataRow drGoodCompressor in dtGoodCompressor.Rows)
            {
                _dsQuoteData.Tables["CondensingUnitCompressorReceiver"].Rows.Add(drGoodCompressor.ItemArray);
            }

            _dsQuoteData.Tables["CondensingUnitWaterCooledCondenser"].Rows.Clear();
            foreach (DataRow drGoodWaterCooled in dtGoodWaterCooled.Rows)
            {
                _dsQuoteData.Tables["CondensingUnitWaterCooledCondenser"].Rows.Add(drGoodWaterCooled.ItemArray);
            }

            _dsQuoteData.Tables["CondensingUnitOption"].Rows.Clear();
            foreach (DataRow drGoodOptions in dtGoodOptions.Rows)
            {
                _dsQuoteData.Tables["CondensingUnitOption"].Rows.Add(drGoodOptions.ItemArray);
            }
        }

        public void DeleteFromQuoteHeatPipe(int intIndex)
        {
            DataTable dtGoodHeatPipe = Public.SelectAndSortTable(_dsQuoteData.Tables["HeatPipes"], "ItemID <> " + intIndex, "");
            _dsQuoteData.Tables["HeatPipes"].Rows.Clear();
            foreach (DataRow drGoodHeatPipe in dtGoodHeatPipe.Rows)
            {
                _dsQuoteData.Tables["HeatPipes"].Rows.Add(drGoodHeatPipe.ItemArray);
            }
        }

        public void DeleteFromQuoteGravityCoil(int intIndex)
        {
            DataTable dtGoodGravityCoil = Public.SelectAndSortTable(_dsQuoteData.Tables["GravityCoils"], "ItemID <> " + intIndex, "");
            _dsQuoteData.Tables["GravityCoils"].Rows.Clear();
            foreach (DataRow drGoodGravityCoil in dtGoodGravityCoil.Rows)
            {
                _dsQuoteData.Tables["GravityCoils"].Rows.Add(drGoodGravityCoil.ItemArray);
            }
        }

        public void DeleteFromQuoteCustomUnit(int intIndex)
        {
            DataTable dtGoodCustomUnit = Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"], "ItemID <> " + intIndex, "");
            _dsQuoteData.Tables["CustomUnitTable"].Rows.Clear();
            foreach (DataRow drGoodCustomUnit in dtGoodCustomUnit.Rows)
            {
                _dsQuoteData.Tables["CustomUnitTable"].Rows.Add(drGoodCustomUnit.ItemArray);
            }
        }

        public void DeleteFromQuoteCondenser(int intIndex)
        {
            DataTable dtGoodCondenser = Public.SelectAndSortTable(_dsQuoteData.Tables["Condensers"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " OR ItemID <> " + intIndex, "");
            DataTable dtGoodControlPanel = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser)+ " OR ItemID <> " + intIndex, "");
            DataTable dtGoodReceiver = Public.SelectAndSortTable(_dsQuoteData.Tables["ReceiverInputs"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " OR ItemID <> " + intIndex ,"");
            DataTable dtGoodSecondaryOption = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " OR ItemID <> " + intIndex, "");
            DataTable dtGoodRefrigerantCircuit = Public.SelectAndSortTable(_dsQuoteData.Tables["RefrigerantCircuits"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " OR ItemID <> " + intIndex, "");

            _dsQuoteData.Tables["Condensers"].Rows.Clear();
            foreach (DataRow drGoodCondenser in dtGoodCondenser.Rows)
            {
                _dsQuoteData.Tables["Condensers"].Rows.Add(drGoodCondenser.ItemArray);
            }

            _dsQuoteData.Tables["ControlPanelInputs"].Rows.Clear();
            foreach (DataRow drGoodControlPanel in dtGoodControlPanel.Rows)
            {
                _dsQuoteData.Tables["ControlPanelInputs"].Rows.Add(drGoodControlPanel.ItemArray);
            }

            _dsQuoteData.Tables["ReceiverInputs"].Rows.Clear();
            foreach (DataRow drGoodReceiver in dtGoodReceiver.Rows)
            {
                _dsQuoteData.Tables["ReceiverInputs"].Rows.Add(drGoodReceiver.ItemArray);
            }

            _dsQuoteData.Tables["SecondaryOptions"].Rows.Clear();
            foreach (DataRow drGoodSecondaryOption in dtGoodSecondaryOption.Rows)
            {
                _dsQuoteData.Tables["SecondaryOptions"].Rows.Add(drGoodSecondaryOption.ItemArray);
            }

            _dsQuoteData.Tables["RefrigerantCircuits"].Rows.Clear();
            foreach (DataRow drGoodRefrigerantCircuit in dtGoodRefrigerantCircuit.Rows)
            {
                _dsQuoteData.Tables["RefrigerantCircuits"].Rows.Add(drGoodRefrigerantCircuit.ItemArray);
            }
        }

        public void DeleteFromQuoteFluidCooler(int intIndex)
        {
            DataTable dtGoodFluidCooler = Public.SelectAndSortTable(_dsQuoteData.Tables["FluidCoolers"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " OR ItemID <> " + intIndex, "");
            DataTable dtGoodControlPanel = Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " OR ItemID <> " + intIndex, "");
            DataTable dtGoodPumpOption = Public.SelectAndSortTable(_dsQuoteData.Tables["PumpInputs"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " OR ItemID <> " + intIndex, "");
            DataTable dtGoodSecondaryOption = Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType <> " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " OR ItemID <> " + intIndex, "");

            _dsQuoteData.Tables["FluidCoolers"].Rows.Clear();
            foreach (DataRow drGoodFluidCooler in dtGoodFluidCooler.Rows)
            {
                _dsQuoteData.Tables["FluidCoolers"].Rows.Add(drGoodFluidCooler.ItemArray);
            }

            _dsQuoteData.Tables["ControlPanelInputs"].Rows.Clear();
            foreach (DataRow drGoodControlPanel in dtGoodControlPanel.Rows)
            {
                _dsQuoteData.Tables["ControlPanelInputs"].Rows.Add(drGoodControlPanel.ItemArray);
            }

            _dsQuoteData.Tables["PumpInputs"].Rows.Clear();
            foreach (DataRow drGoodPump in dtGoodPumpOption.Rows)
            {
                _dsQuoteData.Tables["PumpInputs"].Rows.Add(drGoodPump.ItemArray);
            }

            _dsQuoteData.Tables["SecondaryOptions"].Rows.Clear();
            foreach (DataRow drGoodSecondaryOption in dtGoodSecondaryOption.Rows)
            {
                _dsQuoteData.Tables["SecondaryOptions"].Rows.Add(drGoodSecondaryOption.ItemArray);
            }
        }

        public void DeleteFromQuoteOEMCoil(int intIndex)
        {
            DataTable dtGoodOEMCoil = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoils"], "ItemID <> " + intIndex, "");
            DataTable dtGoodOEMCoilConnections = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilConnections"], "ItemID <> " + intIndex, "");
            DataTable dtGoodOEMCoilFlareFittings = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilFlareFittings"], "ItemID <> " + intIndex, "");
            DataTable dtGoodOEMCoilDistributors = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilDistributors"], "ItemID <> " + intIndex, "");
            DataTable dtGoodOEMCoilPrice = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilPrice"], "ItemID <> " + intIndex, "");

            _dsQuoteData.Tables["OEMCoils"].Rows.Clear();
            foreach (DataRow drGoodOEMCoil in dtGoodOEMCoil.Rows)
            {
                _dsQuoteData.Tables["OEMCoils"].Rows.Add(drGoodOEMCoil.ItemArray);
            }

            _dsQuoteData.Tables["OEMCoilConnections"].Rows.Clear();
            foreach (DataRow drGoodOEMCoilConnections in dtGoodOEMCoilConnections.Rows)
            {
                _dsQuoteData.Tables["OEMCoilConnections"].Rows.Add(drGoodOEMCoilConnections.ItemArray);
            }

            _dsQuoteData.Tables["OEMCoilFlareFittings"].Rows.Clear();
            foreach (DataRow drGoodOEMCoilFlareFittings in dtGoodOEMCoilFlareFittings.Rows)
            {
                _dsQuoteData.Tables["OEMCoilFlareFittings"].Rows.Add(drGoodOEMCoilFlareFittings.ItemArray);
            }

            _dsQuoteData.Tables["OEMCoilDistributors"].Rows.Clear();
            foreach (DataRow drGoodOEMCoilDistributors in dtGoodOEMCoilDistributors.Rows)
            {
                _dsQuoteData.Tables["OEMCoilDistributors"].Rows.Add(drGoodOEMCoilDistributors.ItemArray);
            }

            _dsQuoteData.Tables["OEMCoilPrice"].Rows.Clear();
            foreach (DataRow drGoodOEMCoilPrice in dtGoodOEMCoilPrice.Rows)
            {
                _dsQuoteData.Tables["OEMCoilPrice"].Rows.Add(drGoodOEMCoilPrice.ItemArray);
            }
        }

        private void toolAddFluidCooler_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteFluidCooler)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Fluid Cooler Selection", "Préparation de la sélection de Refroidisseur Liquide"));
                var quickFluidCooler = new QuickFluidCooler.FrmQuickFluidCooler(this, _dsQuoteData, -1);
                quickFluidCooler.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdBrowseClient_Click(object sender, EventArgs e)
        {
            var contactManager = new Contact.FrmContactManager(true);
            DialogResult dr = contactManager.ShowDialog();
            int contactID = contactManager.GetSelectedContactID();
            contactManager.Dispose();

            if (dr == DialogResult.Yes)
            {
                FillClientInfo(contactID);
            }
        }

        private void FillClientInfo(int contactID)
        {
            DataRow drContactInfo = Public.GetContactInfo(contactID);
            _contactGroupID = Convert.ToInt32(drContactInfo["GroupID"]);
            if (Convert.ToInt32(lblContactIDValue.Text) != contactID)
            {
                _isNewQuote = true;
            }
            lblContactIDValue.Text = contactID.ToString(CultureInfo.InvariantCulture );
            txtContactName.Text = drContactInfo["Name"] + (drContactInfo["CompanyName"].ToString() != "" ? " (" + drContactInfo["CompanyName"] + ")" : "");
            txtContactEmail.Text = drContactInfo["Email"].ToString();
            string strPhone = drContactInfo["Phone"].ToString();
            string strExt = drContactInfo["PhoneExt"].ToString();
            txtPhone.Text = (strPhone.Trim() != "" ? strPhone + (strExt.Trim() != "" ? " Ext: " + strExt : "") : "");
            txtAddress.Text = drContactInfo["Street"].ToString();
            txtCity.Text = drContactInfo["City"].ToString();
            txtState.Text = drContactInfo["State"].ToString();
            txtCountry.Text = drContactInfo["Country"].ToString();
            SetClientCurrency(drContactInfo["Country"].ToString());
            txtZipcode.Text = drContactInfo["Zip"].ToString();
            SetMultiplierControl(Convert.ToDecimal(drContactInfo["DefaultMultiplier"]));
        }

        private void SetClientCurrency(string strCountry)
        {
            cboCurrency.SelectedIndex = cboCurrency.FindString(strCountry.ToUpper().Contains("CANADA") ? "CAD" : "USD");
        }

        private void SetMultiplierControl(decimal decValue)
        {
            numMultiplier.Minimum = 0m;
            numMultiplier.Maximum = 1m;
            numMultiplier.Enabled = true;

            if (decValue < UserInformation.MinMultiplier || decValue > UserInformation.MaxMultiplier)
            {
                numMultiplier.Value = decValue;
                numMultiplier.Enabled = false;
                numMultiplier.BackColor = Color.White;
            }
            else
            {
                numMultiplier.Minimum = UserInformation.MinMultiplier;
                numMultiplier.Maximum = UserInformation.MaxMultiplier;
                numMultiplier.Value = decValue;
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            _isNewQuote = true;
            lblContactIDValue.Text = @"0";
            txtContactName.Text = "";
            txtContactEmail.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            txtZipcode.Text = "";
        }

        private void toolPrintQuote_Click(object sender, EventArgs e)
        {
            //if the quote is not modified and we have a quoteid (mean it's a saved quote)
            if (!_quoteIsModified && _quoteID != 0)
            {
                if (Public.LanguageQuestionBox("Are you sure you want to print preview this quote?", "Êtes-vous sûr de vouloir avoir l'apercu de cette soumission?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    var openFormat = new FrmQuotePrintOptions();
                    openFormat.ShowDialog();

                    bool showHeader = openFormat.PricingHeaderPage();
                    bool showPricing = openFormat.PricingPages();
                    bool showDetailPricing = openFormat.DetailPricingPages();
                    bool showPerformance = openFormat.PerformanceSheets();
                    bool showDrawings = openFormat.Drawings();
                    bool showDimensions = openFormat.Dimensions();

                    openFormat.Dispose();

                    ThreadProcess.Start(Public.LanguageString("Generating Report", "Création du rapport"));

                    //this list will contain the filenames (including path) of the report
                    //to merge together.
                    var lstFileNames = new List<string>();

                    //this list will contain information to make the cover page
                    var lstCoverPageData = new List<QuoteCoverPageData>();

                    //generate all condenser price reports
                    GenerateCondenserPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDrawings, showDetailPricing);

                    //generate all fluid cooler price report
                    GenerateFluidCoolerPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDrawings, showDetailPricing);

                    //generate all Evaporator price report
                    GenerateEvaporatorPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, false, showDrawings, showDetailPricing);

                    //generate all water evaporator price report
                    GenerateWaterEvaporatorPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDrawings, showDetailPricing);

                    //generate all Coil price report
                    GenerateCoilPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDetailPricing);

                    //generate all Condensing unit price report
                    GenerateCondensingUnitPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDrawings, showDetailPricing);

                    //generate all Manual Coil Price report
                    GenerateManualCoilPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDetailPricing);

                    //generate all Heat Pipe Price report
                    GenerateHeatPipePriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDetailPricing);

                    //generate all Gravity Coil price reports
                    GenerateGravityCoilPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDrawings, showDetailPricing, showDimensions);

                    //generate all OEM Coil
                    GenerateOEMCoilPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance);

                    //generate all custom unit price reports
                    GenerateCustomUnitPriceReports(ref lstFileNames, ref lstCoverPageData, showPricing, showPerformance, showDetailPricing);

                    //generate the coverpage
                    string strCoverPageFilePath = "";
                    if (showHeader)
                    {
                        strCoverPageFilePath = GeneratePriceReportCoverPage(lstCoverPageData);
                    }

                  

                    //merge all the file and show the merged file.
                    MergeAndPreviewReport(lstFileNames, strCoverPageFilePath);

                    ThreadProcess.Stop();
                    Focus();
                }
            }
            else
            {
                Public.LanguageBox("Your quote is either a new quote that has not been saved yet or the quote has been modified and changes were not saved.", "Votre soumission est soit une nouvelle soumission qui n'a pas été sauvegardée encore ou la cotation a été modifiée sans que les changements soient sauvegardés.");
            }
        }

        private string GeneratePriceReportCoverPage(List<QuoteCoverPageData> lstCoverPageData)
        {
            string strFilePath = "";

            if (lstCoverPageData.Count > 0)
            {
                var dsQuoteCoverPageData = new DataSet("PricingCoverPageDATA");
                dsQuoteCoverPageData.Tables.Add(Tables.DtQuotePricingCoverPage());

                decimal decGrandTotal = 0m;
                foreach (QuoteCoverPageData qcpd in lstCoverPageData)
                {
                    DataRow drCoverPage = dsQuoteCoverPageData.Tables[0].NewRow();

                    drCoverPage["QuoteID"] = _quoteID;
                    drCoverPage["QuoteRevision"] = _revisionID;
                    drCoverPage["QuoteRevisionText"] = Public.RevisionID_To_Letter(_revisionID);

                    drCoverPage["Tag"] = qcpd.Tag;
                    drCoverPage["Description"] = qcpd.Description;
                    drCoverPage["Quantity"] = qcpd.Quantity;
                    drCoverPage["UnitPrice"] = qcpd.UnitPrice;
                    drCoverPage["TotalPrice"] = qcpd.TotalPrice;
                    decGrandTotal += qcpd.TotalPrice;

                    dsQuoteCoverPageData.Tables[0].Rows.Add(drCoverPage);
                }
                //dsQuoteCoverPageData.WriteXmlSchema("PricingCoverPageXSD.xsd");

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.PricingCoverPage();

                //set datasource
                rptPricingReport.SetDataSource(dsQuoteCoverPageData);

                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.PricingPageTranslation.translateReport(rptPricingReport, Public.Language);

                //export to pdf without opening it (will be merge later on)
                strFilePath = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);
            }

            return strFilePath;
        }

        private void MergeAndPreviewReport(List<string> lstFileNames, string coverPageFile)
        {
            if (lstFileNames.Count > 0 || coverPageFile != "")
            {
                var pdf = new PDFMerge();

                if (coverPageFile != "")
                {
                    //first add the cover page
                    //last test : check if file exist just in case
                    if (File.Exists(coverPageFile))
                    {
                        //add the file to the list of files to be merged
                        pdf.AddFile(coverPageFile);
                    }
                }

                //for each file that has been generated the file path has
                //been saved into that string array we jsut have to merge them
                for (int iFile = 0; iFile < lstFileNames.Count; iFile++)
                {
                    //last test : check if file exist just in case
                    if (File.Exists(lstFileNames[iFile]))
                    {
                        //add the file to the list of files to be merged
                        pdf.AddFile(lstFileNames[iFile]);
                    }
                }

                //get a randomly generated filename
                string strMergeReportLocation = Public.GenerateFileNameAndPath("QuoteReport", "pdf");

                //Merge and create the file
                pdf.Merge(strMergeReportLocation);

                //open up the file
                System.Diagnostics.Process.Start(strMergeReportLocation);
            }
            else
            {
                Public.LanguageBox("Your only unit is a unit of the type \"other\", so we can't produce a pricing report with only that, sorry","Votre seule unité est du type \"autre\", donc nous ne pouvons pas générer de rapport de prix, désolé.");
            }       
        }

        private void GenerateCondensingUnitPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool addDrawingToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each condensing unit in the quote
            for (int iCondensingUnit = 0; iCondensingUnit < _dsQuoteData.Tables["CondensingUnit"].Rows.Count; iCondensingUnit++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["CondensingUnit"].Rows[iCondensingUnit]["ItemID"]);
                var dsCondensingUnit = new DataSet("CondensingUnitDATA");
                dsCondensingUnit.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnit"], "ItemID = " + itemID, ""));
                //dsCondensingUnit.WriteXmlSchema("CondensingUnitXSD.xsd");

                var dsCondensingUnitOptions = new DataSet("CondensingUnitOptionsDATA");
                dsCondensingUnitOptions.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["CondensingUnitOption"], "ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.CondensingUnitPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsCondensingUnit);
                rptPricingReport.Subreports["CondensingUnitOptionPrice.rpt"].SetDataSource(dsCondensingUnitOptions);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["CondensingUnit"].Rows[iCondensingUnit]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetCondensingUnitPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["CondensingUnit"].Rows[iCondensingUnit]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.CondensingUnitPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        //performance shows here
                        GenerateSingleCondensingUnitSpec(iCondensingUnit, ref lstFileNames);
                    }
                    if (addDrawingToQuote)
                    {
                        string strDrawingFileLocation = GenerateSingleCondensingUnitDrawing(iCondensingUnit);

                        if (strDrawingFileLocation != "")
                        {
                            lstFileNames.Add(strDrawingFileLocation);
                        }
                    }
                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["CondensingUnit"].Rows[iCondensingUnit]["Input_Tag"].ToString(), _dsQuoteData.Tables["CondensingUnit"].Rows[iCondensingUnit]["Model"].ToString(), Convert.ToInt32(_dsQuoteData.Tables["CondensingUnit"].Rows[iCondensingUnit]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["CondensingUnit"].Rows[iCondensingUnit]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }

        private string GenerateSingleCondensingUnitDrawing(int intIndex)
        {
            string strFileLocation = "";

            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitModel"], "Model = '" + _dsQuoteData.Tables["CondensingUnit"].Rows[intIndex]["Model"] + "'", "");
            string strDrawingName = DrawingManager.GetDrawingName_CondensingUnit(
                 Public.DSDatabase.Tables["CondensingUnitDrawingManager"],
                 dtModel.Rows[0]["UnitType"].ToString(),
                 dtModel.Rows[0]["AirFlow"].ToString(),
                 dtModel.Rows[0]["CompressorType"].ToString(),
                 dtModel.Rows[0]["HP"].ToString(),
                 dtModel.Rows[0]["NumberOfCompressor"].ToString(),
                 dtModel.Rows[0]["CompressorManufacturer"].ToString(),
                 dtModel.Rows[0]["Application"].ToString(),
                 dtModel.Rows[0]["RefrigerantID"].ToString(),
                 dtModel.Rows[0]["VoltageID"].ToString(),
                 dtModel.Rows[0]["Options"].ToString());

            if (strDrawingName != "")
            {
                byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.CondensingUnit);
                if (bfile != null)
                {
                    string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                    if (strDrawingFileLocation != "")
                    {
                        strFileLocation = strDrawingFileLocation;
                    }
                }
            }

            return strFileLocation;
        }




        private string GenerateSingleOEMCoilPriceReport(int itemID, bool advancedSales, bool open)
        {
            var dsOEMCoil = new DataSet("OEMCoilDATA");
            dsOEMCoil.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoils"], "ItemID = " + itemID, ""));

            var dsOEMCoilPrice = new DataSet("OEMCoilPriceDATA");
            dsOEMCoilPrice.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilPrice"], "ItemID = " + itemID, "PriceID"));

            //instanciate the report
            var rptPricingReport = new DLLPricingReports.OEMCoilPricing();

            //set datasource
            rptPricingReport.SetDataSource(dsOEMCoil);
            rptPricingReport.Subreports["OEMCoilPriceLine.rpt"].SetDataSource(dsOEMCoilPrice);

            rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(dsOEMCoil.Tables["OEMCoils"].Rows[0]["Input_Quantity"]));
            rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
            rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
            rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
            const decimal decGrandTotal = 0m;
            rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
            rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
            rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
            rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
            rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
            rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
            rptPricingReport.SetParameterValue("To", GetTo());
            rptPricingReport.SetParameterValue("Freight", GetFreight());

            rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            //2010-12-17 : added advanced sales to OEM coil
            rptPricingReport.SetParameterValue("AdvancedSales", (advancedSales ? 1 : 0));

            //translate the report
            //DLLPricingReports.OEMPriceLineTranslation.translateReport(rptPricingReport.Subreports["OEMCoilPriceLine.rpt"], Public.Language);
            DLLPricingReports.OEMPricingTranslation.translateReport(rptPricingReport, Public.Language);
            //export to pdf without opening it (will be merge later on)

            string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", open);

            //dispose object
            rptPricingReport.Dispose();

            return strFileLocation;
        }

        private void GenerateOEMCoilPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote)
        {
            //loop to create the pricing report of each condensing unit in the quote
            for (int iOEMCoil = 0; iOEMCoil < _dsQuoteData.Tables["OEMCoils"].Rows.Count; iOEMCoil++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["OEMCoils"].Rows[iOEMCoil]["ItemID"]);

                var dsOEMCoil = new DataSet("OEMCoilDATA");
                dsOEMCoil.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoils"], "ItemID = " + itemID, ""));

                var dsOEMCoilPrice = new DataSet("OEMCoilPriceDATA");
                dsOEMCoilPrice.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilPrice"], "ItemID = " + itemID, "PriceID"));

                ////instanciate the report
                //DLLPricingReports.OEMCoilPricing rptPricingReport = new DLLPricingReports.OEMCoilPricing();

                ////set datasource
                //rptPricingReport.SetDataSource(dsOEMCoil);
                //rptPricingReport.Subreports["OEMCoilPriceLine.rpt"].SetDataSource(dsOEMCoilPrice);

                //rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(dsQuoteData.Tables["OEMCoils"].Rows[iOEMCoil]["Input_Quantity"]));
                //rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                //rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                //rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                //decimal decGrandTotal = 0m;
                //rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                //rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                //rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                //rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                //rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                //rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                //rptPricingReport.SetParameterValue("To", GetTo());

                //rptPricingReport.SetParameterValue("Site", UserInformation.CURRENT_SITE);
                ////2010-12-17 : added advanced sales to OEM coil
                //rptPricingReport.SetParameterValue("AdvancedSales", 0);

                ////translate the report
                //DLLPricingReports.OEMPriceLineTranslation.translateReport(rptPricingReport.Subreports["OEMCoilPriceLine.rpt"], Public.Language);
                //DLLPricingReports.OEMPricingTranslation.translateReport(rptPricingReport, Public.Language);
                ////export to pdf without opening it (will be merge later on)

                //string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                string strFileLocation = GenerateSingleOEMCoilPriceReport(itemID, false, false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        ////performance shows here
                        //GenerateSingleOEMCoilSpec(iOEMCoil, ref lstFileNames);
                    }

                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["OEMCoils"].Rows[iOEMCoil]["Input_Tag"].ToString(), _dsQuoteData.Tables["OEMCoils"].Rows[iOEMCoil]["Input_Model"].ToString(), 0, 0m, 0m));
                }

                ////dispose object
                //rptPricingReport.Dispose();
                //rptPricingReport = null;

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }

        private void GenerateManualCoilPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each coil in the quote
            for (int iCoil = 0; iCoil < _dsQuoteData.Tables["QuickManualCoil"].Rows.Count; iCoil++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["QuickManualCoil"].Rows[iCoil]["ItemID"]);
                var dsManualCoil = new DataSet("ManualCoilDATA");
                dsManualCoil.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickManualCoil"], "ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.ManualCoil), ""));

                //dsManualCoil.WriteXmlSchema("QuickManualCoilXSD.xsd");

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.ManualCoilPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsManualCoil);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["QuickManualCoil"].Rows[iCoil]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetManualCoilPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["QuickManualCoil"].Rows[iCoil]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.ManualCoilPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        //performance shows here
                    }

                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["QuickManualCoil"].Rows[iCoil]["Tag"].ToString(), _dsQuoteData.Tables["QuickManualCoil"].Rows[iCoil]["CoilModel"].ToString(), Convert.ToInt32(_dsQuoteData.Tables["QuickManualCoil"].Rows[iCoil]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["QuickManualCoil"].Rows[iCoil]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }

        private void GenerateHeatPipePriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each coil in the quote
            for (int iHeatPipe = 0; iHeatPipe < _dsQuoteData.Tables["HeatPipes"].Rows.Count; iHeatPipe++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["HeatPipes"].Rows[iHeatPipe]["ItemID"]);
                var dsHeatPipe = new DataSet("HeatPipeDATA");

                dsHeatPipe.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["HeatPipes"], "ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.HeatPipe), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.HeatPipePricing();

                //set datasource
                rptPricingReport.SetDataSource(dsHeatPipe);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["HeatPipes"].Rows[iHeatPipe]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetHeatPipePrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["HeatPipes"].Rows[iHeatPipe]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.HeatPipePricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        //performance shows here
                        GenerateSingleHeatPipeSpec(iHeatPipe, ref lstFileNames);
                    }

                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["HeatPipes"].Rows[iHeatPipe]["Tag"].ToString(), _dsQuoteData.Tables["HeatPipes"].Rows[iHeatPipe]["Model"].ToString(), Convert.ToInt32(_dsQuoteData.Tables["HeatPipes"].Rows[iHeatPipe]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["HeatPipes"].Rows[iHeatPipe]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }


        private void GenerateGravityCoilPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool addDrawingToQuote, bool detailedPriceREport, bool dimensionsReport)
        {
            //loop to create the pricing report of each coil in the quote
            for (int iGravityCoil = 0; iGravityCoil < _dsQuoteData.Tables["GravityCoils"].Rows.Count; iGravityCoil++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["GravityCoils"].Rows[iGravityCoil]["ItemID"]);
                var dsGravityCoil = new DataSet("GravityCoilDATA");

                dsGravityCoil.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["GravityCoils"], "ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.GravityCoil), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.GravityCoilPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsGravityCoil);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["GravityCoils"].Rows[iGravityCoil]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetGravityCoilPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["GravityCoils"].Rows[iGravityCoil]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.GravityCoilPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        //performance shows here
                        GenerateSingleGravityCoilSpec(iGravityCoil, ref lstFileNames);
                    }
                    if (addDrawingToQuote)
                    {
                        string strDrawingFileLocation = GenerateSingleGravityCoilDrawing(iGravityCoil);

                        if (strDrawingFileLocation != "")
                        {
                            lstFileNames.Add(strDrawingFileLocation);
                        }
                    }
                    if (dimensionsReport)
                    {
                        //string dimensionsFileLocation = GenerateDimension(iGravityCoil, "GravityCoil", lstFileNames);
                       
                    }
                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["GravityCoils"].Rows[iGravityCoil]["Input_Tag"].ToString(), _dsQuoteData.Tables["GravityCoils"].Rows[iGravityCoil]["Model"].ToString(), Convert.ToInt32(_dsQuoteData.Tables["GravityCoils"].Rows[iGravityCoil]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["GravityCoils"].Rows[iGravityCoil]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }

        private void GenerateDimension(int intIndex, string unitType, ref List<string> lstFileNames)
        {
            //DataTable 
            
        }


        private string GenerateSingleGravityCoilDrawing(int intIndex)
        {
            string strFileLocation = "";

            string strDrawingName = DrawingManager.GetDrawingName(DrawingManager.DrawingCategory.GravityCoil, _dsQuoteData.Tables["GravityCoils"].Rows[intIndex]["Model"].ToString());
            if (strDrawingName != "")
            {
                byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.GravityCoil);
                if (bfile != null)
                {
                    string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                    if (strDrawingFileLocation != "")
                    {
                        strFileLocation = strDrawingFileLocation;
                    }
                }
            }

            return strFileLocation;
        }

        private void GenerateCoilPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each coil in the quote
            for (int iCoil = 0; iCoil < _dsQuoteData.Tables["QuickCoil"].Rows.Count; iCoil++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["QuickCoil"].Rows[iCoil]["ItemID"]);
                var dsCoil = new DataSet("CoilDATA");
                dsCoil.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Coil), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.CoilPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsCoil);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["QuickCoil"].Rows[iCoil]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetCoilPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["QuickCoil"].Rows[iCoil]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.CoilPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        GenerateSingleCoilSpec(iCoil, ref lstFileNames);
                    }
                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["QuickCoil"].Rows[iCoil]["Tag"].ToString(), _dsQuoteData.Tables["QuickCoil"].Rows[iCoil]["CoilModel"].ToString(), Convert.ToInt32(_dsQuoteData.Tables["QuickCoil"].Rows[iCoil]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["QuickCoil"].Rows[iCoil]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }



        private void GenerateEvaporatorPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool addTechSpecReportToQuote, bool addDrawingToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each evapoator in the quote
            for (int iEvap = 0; iEvap < _dsQuoteData.Tables["Evaporators"].Rows.Count; iEvap++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["Evaporators"].Rows[iEvap]["ItemID"]);
                var dsEvap = new DataSet("EvaporatorDATA");
                dsEvap.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["Evaporators"], "ItemID = " + itemID, ""));

                var dsOption = new DataSet("EvaporatorOptionDATA");
                dsOption.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["EvaporatorOption"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator), ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.EvaporatorPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsEvap);
                rptPricingReport.Subreports["EvaporatorOptionPrice.rpt"].SetDataSource(dsOption);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["Evaporators"].Rows[iEvap]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetEvaporatorPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["Evaporators"].Rows[iEvap]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.EvaporatorPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        GenerateSingleEvaporatorSpec(iEvap, ref lstFileNames);
                    }
                    if (addTechSpecReportToQuote)
                    {
                        GenerateSingleEvaporatorTechSpec(iEvap, ref lstFileNames);
                    }
                    if (addDrawingToQuote)
                    {
                        string strDrawingFileLocation = GenerateSingleEvaporatorDrawing(iEvap);

                        if (strDrawingFileLocation != "")
                        {
                            lstFileNames.Add(strDrawingFileLocation);
                        }
                    }
                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["Evaporators"].Rows[iEvap]["Tag"].ToString(), _dsQuoteData.Tables["Evaporators"].Rows[iEvap]["EvaporatorID"] + "-" + _dsQuoteData.Tables["Evaporators"].Rows[iEvap]["VoltageID"], Convert.ToInt32(_dsQuoteData.Tables["Evaporators"].Rows[iEvap]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["Evaporators"].Rows[iEvap]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }


        }

        private void GenerateWaterEvaporatorPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool addDrawingToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each evapoator in the quote
            for (int iWaterEvap = 0; iWaterEvap < _dsQuoteData.Tables["QuickWaterEvaporator"].Rows.Count; iWaterEvap++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["ItemID"]);
                var dsEvap = new DataSet("WaterEvaporatorDATA");
                dsEvap.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["QuickWaterEvaporator"], "ItemID = " + itemID, ""));

                var dsOption = new DataSet("WaterEvaporatorOptionDATA");
                dsOption.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["WaterEvaporatorOption"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator), ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.WaterEvaporatorPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsEvap);
                rptPricingReport.Subreports["WaterEvaporatorOptionPrice.rpt"].SetDataSource(dsOption);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetWaterEvaporatorPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.WaterEvaporatorPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        GenerateSingleWaterEvaporatorSpec(iWaterEvap, ref lstFileNames);
                    }
                    if (addDrawingToQuote)
                    {
                        string strDrawingFileLocation = GenerateSingleWaterEvaporatorDrawing(iWaterEvap);

                        if (strDrawingFileLocation != "")
                        {
                            lstFileNames.Add(strDrawingFileLocation);
                        }
                    }
                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["Tag"].ToString(), _dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["EvaporatorID"] + "-" + _dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["Input_VoltageID"] + "-W", Convert.ToInt32(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[iWaterEvap]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }


        }

        private string GenerateSingleEvaporatorDrawing(int intIndex)
        {
            string strFileLocation = "";

            string strSerie = _dsQuoteData.Tables["Evaporators"].Rows[intIndex]["EvaporatorID"].ToString().Substring(0, 1) +
                               _dsQuoteData.Tables["Evaporators"].Rows[intIndex]["EvaporatorID"].ToString().Substring(1, 1) +
                               _dsQuoteData.Tables["Evaporators"].Rows[intIndex]["EvaporatorID"].ToString().Substring(2, 1);

            string strDrawingName = DrawingManager.GetDrawingName_Evaporator(
                 Public.DSDatabase.Tables["EvaporatorDrawingManager"],
                 strSerie,
                 Convert.ToDecimal(_dsQuoteData.Tables["Evaporators"].Rows[intIndex]["CapacityAt10TD"]),
                 _dsQuoteData.Tables["Evaporators"].Rows[intIndex]["VoltageID"].ToString());

            if (strDrawingName != "")
            {
                byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.Evaporator);
                if (bfile != null)
                {
                    string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                    if (strDrawingFileLocation != "")
                    {
                        strFileLocation = strDrawingFileLocation;
                    }
                }
            }

            return strFileLocation;
        }

        private string GenerateSingleWaterEvaporatorDrawing(int intIndex)
        {
            string strFileLocation = "";

            string strSerie = _dsQuoteData.Tables["QuickWaterEvaporator"].Rows[intIndex]["EvaporatorID"].ToString().Substring(0, 1) +
                               _dsQuoteData.Tables["QuickWaterEvaporator"].Rows[intIndex]["EvaporatorID"].ToString().Substring(1, 1) +
                               _dsQuoteData.Tables["QuickWaterEvaporator"].Rows[intIndex]["EvaporatorID"].ToString().Substring(2, 1);

            string strDrawingName = DrawingManager.GetDrawingName_Evaporator(
                 Public.DSDatabase.Tables["EvaporatorDrawingManager"],
                 strSerie,
                 Convert.ToDecimal(_dsQuoteData.Tables["QuickWaterEvaporator"].Rows[intIndex]["CapacityAt10TD"]),
                 _dsQuoteData.Tables["QuickWaterEvaporator"].Rows[intIndex]["Input_VoltageID"].ToString());

            if (strDrawingName != "")
            {
                byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.Evaporator);
                if (bfile != null)
                {
                    string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                    if (strDrawingFileLocation != "")
                    {
                        strFileLocation = strDrawingFileLocation;
                    }
                }
            }

            return strFileLocation;
        }

        private void GenerateFluidCoolerPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool addDrawingToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each condenser in the quote
            for (int iFluidCooler = 0; iFluidCooler < _dsQuoteData.Tables["FluidCoolers"].Rows.Count; iFluidCooler++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["ItemID"]);
                var dsFluidCooler = new DataSet("FluidCoolerDATA");
                dsFluidCooler.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["FluidCoolers"], "ItemID = " + itemID, ""));

                var dsControlPanel = new DataSet("ControlPanelDATA");
                dsControlPanel.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, ""));

                var dsPump = new DataSet("PumpInputsDATA");
                dsPump.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["PumpInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, ""));

                var dsSecondaryOptions = new DataSet("SecondaryOptionsDATA");
                dsSecondaryOptions.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler), ""));
                //dsAddtionnalItems.WriteXmlSchema("AdditionalItemsXSD.xsd");

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.FluidCoolerPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsFluidCooler);
                rptPricingReport.Subreports["ControlPanelPrice.rpt"].SetDataSource(dsControlPanel);
                rptPricingReport.Subreports["PumpPrice.rpt"].SetDataSource(dsPump);
                rptPricingReport.Subreports["SecondaryOptionPrice.rpt"].SetDataSource(dsSecondaryOptions);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetFluidCoolerPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.FluidCoolerPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.PumpPriceTranslation.translateReport(rptPricingReport.Subreports["PumpPrice.rpt"], Public.Language);
                DLLPricingReports.SecondaryOptionsTranslation.translateReport(rptPricingReport.Subreports["SecondaryOptionPrice.rpt"], Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);
                DLLPricingReports.ControlPanelTranslation.translateReport(rptPricingReport.Subreports["ControlPanelPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        GenerateSingleFluidCoolerSpec(iFluidCooler, ref lstFileNames);
                    }
                    if (addDrawingToQuote)
                    {
                        string strDrawingFileLocation = GenerateSingleFluidCoolerDrawing(iFluidCooler);

                        if (strDrawingFileLocation != "")
                        {
                            lstFileNames.Add(strDrawingFileLocation);
                        }
                    }
                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["Input_Tag"].ToString(), _dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["FluidCoolerModel"] + "-" + _dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["VoltageID"] + "-" + _dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["Fin"] + _dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["cir1"], Convert.ToInt32(_dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["FluidCoolers"].Rows[iFluidCooler]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }

        private string GenerateSingleFluidCoolerDrawing(int intIndex)
        {
            string strFileLocation = "";

            string strDrawingName = _dsQuoteData.Tables["FluidCoolers"].Rows[intIndex]["ApprovalDrawing"] + ".PDF";
            if (strDrawingName != "")
            {
                byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.FluidCooler);
                if (bfile != null)
                {
                    string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                    if (strDrawingFileLocation != "")
                    {
                        strFileLocation = strDrawingFileLocation;
                    }
                }
            }

            return strFileLocation;
        }


        private void GenerateCondenserPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool addDrawingToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each condenser in the quote
            for (int iCondenser = 0; iCondenser < _dsQuoteData.Tables["Condensers"].Rows.Count; iCondenser++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["Condensers"].Rows[iCondenser]["ItemID"]);
                var dsCondenser = new DataSet("CondenserDATA");
                dsCondenser.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["Condensers"], "ItemID = " + itemID, ""));

                var dsControlPanel = new DataSet("ControlPanelDATA");
                dsControlPanel.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["ControlPanelInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, ""));

                var dsReceiver = new DataSet("ReceiverDATA");
                dsReceiver.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["ReceiverInputs"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, ""));

                var dsSecondaryOptions = new DataSet("SecondaryOptionsDATA");
                dsSecondaryOptions.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["SecondaryOptions"], "ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser) + " AND ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.CondenserPricing();

                //set datasource
                rptPricingReport.SetDataSource(dsCondenser);
                rptPricingReport.Subreports["ControlPanelPrice.rpt"].SetDataSource(dsControlPanel);
                rptPricingReport.Subreports["ReceiverPrice.rpt"].SetDataSource(dsReceiver);
                rptPricingReport.Subreports["SecondaryOptionPrice.rpt"].SetDataSource(dsSecondaryOptions);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["Condensers"].Rows[iCondenser]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetCondenserPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["Condensers"].Rows[iCondenser]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.CondenserPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.ControlPanelTranslation.translateReport(rptPricingReport.Subreports["ControlPanelPrice.rpt"], Public.Language);
                DLLPricingReports.ReceiverPriceTranslation.translateReport(rptPricingReport.Subreports["ReceiverPrice.rpt"], Public.Language);
                DLLPricingReports.SecondaryOptionsTranslation.translateReport(rptPricingReport.Subreports["SecondaryOptionPrice.rpt"], Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        lstFileNames.Add(strFileLocation);
                    }
                    if (addPerformanceReportToQuote)
                    {
                        GenerateSingleCondenserSpec(iCondenser, ref lstFileNames);
                    }
                    if (addDrawingToQuote)
                    {
                        string strDrawingFileLocation = GenerateSingleCondenserDrawing(iCondenser);

                        if (strDrawingFileLocation != "")
                        {
                            lstFileNames.Add(strDrawingFileLocation);
                        }
                    }

                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["Condensers"].Rows[iCondenser]["Input_Tag"].ToString(), _dsQuoteData.Tables["Condensers"].Rows[iCondenser]["CondenserModel"] + "-" + _dsQuoteData.Tables["Condensers"].Rows[iCondenser]["VoltageID"], Convert.ToInt32(_dsQuoteData.Tables["Condensers"].Rows[iCondenser]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["Condensers"].Rows[iCondenser]["Quantity"]), decGrandTotal));

                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }

        private string GenerateSingleCondenserDrawing(int intIndex)
        {
            string strFileLocation = "";
            //Since both the receiver and legs table are linked by the "quote ID, quote Item, ItemType, Item ID" values, we will have the same exact where clause... easier to change if it's here.
            string whereClause = "where QuoteID = " + _dsQuoteData.Tables["Condensers"].Rows[intIndex]["QuoteID"] + " and QuoteRevision = " + _dsQuoteData.Tables["Condensers"].Rows[intIndex]["QuoteRevision"] + " and ItemType = " + _dsQuoteData.Tables["Condensers"].Rows[intIndex]["ItemType"] + " and ItemID = " + _dsQuoteData.Tables["Condensers"].Rows[intIndex]["ItemID"];
            string strDrawingNameData = _dsQuoteData.Tables["Condensers"].Rows[intIndex]["ApprovalDrawing"] + ".PDF";
            string strDrawingName = "";
            DataTable receiver = Query.Select("Select ReceiverReinforcedBaseQty, Receiver1Model, Receiver2Model, ReceiverInstall from QuoteReceiverData " + whereClause);
            DataTable legs = Query.Select("Select LegSize from QuoteSecondaryOptionsData " + whereClause);

            //Finding the way legs are called in the system
            if (legs.Rows.Count != 0)
            {
                string legNomenclature;
                if (legs.Rows[0]["LegSize"].ToString() == "0")
                    legNomenclature = "N00";
                else
                {
                    legNomenclature = "L" + legs.Rows[0]["LegSize"];
                }

                //With the receiver table, find if base is installed, receiver is installed, and the quantity of receivers with the unit
                int quantityOfReceiver = 0;
                bool baseInstalled = false;
                bool receiverInstalled = false;
                if (receiver.Rows.Count > 0)
                {
                    if (receiver.Rows[0]["Receiver1Model"].ToString() != "" && receiver.Rows[0]["Receiver1Model"] != null)
                    {
                        ++quantityOfReceiver;
                    }

                    if (receiver.Rows[0]["Receiver2Model"].ToString() != "" && receiver.Rows[0]["Receiver2Model"] != null)
                    {
                        ++quantityOfReceiver;
                    }
                    receiverInstalled = receiver.Rows[0]["ReceiverInstall"].ToString().Contains("INSTALLED");
                    baseInstalled = (Convert.ToInt32(receiver.Rows[0]["ReceiverReinforcedBaseQty"].ToString()) >= 1);
                }

                //Generating the approval name at runtime to see if it's accessible
                strDrawingName = QuickCondenser.FrmQuickCondenser.GetApprovalDrawing(_dsQuoteData.Tables["Condensers"].Rows[intIndex]["Motor"].ToString(), _dsQuoteData.Tables["Condensers"].Rows[intIndex]["CoilArr"].ToString(), _dsQuoteData.Tables["Condensers"].Rows[intIndex]["CondenserType"].ToString(), _dsQuoteData.Tables["Condensers"].Rows[intIndex]["FanWide"].ToString(), _dsQuoteData.Tables["Condensers"].Rows[intIndex]["FanLong"].ToString(), baseInstalled, _dsQuoteData.Tables["Condensers"].Rows[intIndex]["AirFlowType"].ToString(), receiverInstalled, quantityOfReceiver, legNomenclature);
                strDrawingName += ".PDF";
                if (strDrawingName != "")
                {
                    byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.Condenser);
                    if (bfile != null)
                    {
                        string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                        if (strDrawingFileLocation != "")
                        {
                            strFileLocation = strDrawingFileLocation;
                        }
                    }
                }

                //Simple check to make sure there isn't a problem with the leg nomenclature (in certain cases, L22 units go with L21 drawings)  (MAIL SIMON : RE: Tue 8/6/2013 1:01)
                if (strFileLocation == "")
                {
                    if (strDrawingName != "")
                    {
                        strDrawingName = strDrawingName.Replace("L22", "L21");
                        byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.Condenser);
                        if (bfile != null)
                        {
                            string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                            if (strDrawingFileLocation != "")
                            {
                                strFileLocation = strDrawingFileLocation;
                            }
                        }
                    }
                }
            }
            //Just in case, if it still hasn't produced anything, we try the name saved in the database.
            if (strFileLocation == "")
            {
                if (strDrawingNameData != "")
                {
                    strDrawingName = strDrawingNameData;
                    byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.Condenser);
                    if (bfile != null)
                    {
                        string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                        if (strDrawingFileLocation != "")
                        {
                            strFileLocation = strDrawingFileLocation;
                        }
                    }
                }
            }

            //Finally, for a LAST try, we try the name saved in the system, but with a L22 instead of L21 (just in case the confusion comes from the Leg name change.
            if (strFileLocation == "")
            {
                if (strDrawingNameData != "")
                {
                    strDrawingName = strDrawingName.Replace("L22", "L21");
                    byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.Condenser);
                    if (bfile != null)
                    {
                        string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                        if (strDrawingFileLocation != "")
                        {
                            strFileLocation = strDrawingFileLocation;
                        }
                    }
                }
            }
            return strFileLocation;
        }




        private void GenerateCustomUnitPriceReports(ref List<string> lstFileNames, ref List<QuoteCoverPageData> lstCoverPageData, bool addPriceReportToQuote, bool addPerformanceReportToQuote, bool detailedPriceREport)
        {
            //loop to create the pricing report of each coil in the quote
            for (int iCustomUnit = 0; iCustomUnit < _dsQuoteData.Tables["CustomUnitTable"].Rows.Count; iCustomUnit++)
            {
                int itemID = Convert.ToInt32(_dsQuoteData.Tables["CustomUnitTable"].Rows[iCustomUnit]["ItemID"]);
                var dsCustomUnit = new DataSet("CustomUnitDATA");

                dsCustomUnit.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"], "ItemID = " + itemID, ""));

                var dsAddtionnalItems = new DataSet("AdditionalItemsDATA");
                dsAddtionnalItems.Tables.Add(Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemID = " + itemID + " AND ItemType = " + QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CustomUnit), ""));

                //instanciate the report
                var rptPricingReport = new DLLPricingReports.CustomUnitPrice();

                //set datasource
                rptPricingReport.SetDataSource(dsCustomUnit);
                rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"].SetDataSource(dsAddtionnalItems);

                rptPricingReport.SetParameterValue("Quantity", Convert.ToInt32(_dsQuoteData.Tables["CustomUnitTable"].Rows[iCustomUnit]["Quantity"]));
                rptPricingReport.SetParameterValue("Multiplier", numMultiplier.Value);
                rptPricingReport.SetParameterValue("Currency", cboCurrency.Text);
                rptPricingReport.SetParameterValue("CurrencyMultiplier", CurrenyMultiplier());
                decimal decGrandTotal = GetCustomUnitPrice(itemID) * Convert.ToDecimal(_dsQuoteData.Tables["CustomUnitTable"].Rows[iCustomUnit]["Quantity"]) * numMultiplier.Value * CurrenyMultiplier();
                rptPricingReport.SetParameterValue("GrandTotal", decGrandTotal);
                rptPricingReport.SetParameterValue("ProjectName", txtProjectName.Text);
                rptPricingReport.SetParameterValue("QuotationDate", Convert.ToDateTime(lblQuotationDate.Text));
                rptPricingReport.SetParameterValue("QuotationBy", lblQuotationBy.Text);
                rptPricingReport.SetParameterValue("Terms", cboTerms.Text);
                rptPricingReport.SetParameterValue("Delivery", cboDelivery.Text);
                rptPricingReport.SetParameterValue("To", GetTo());
                rptPricingReport.SetParameterValue("Detailed", detailedPriceREport);
                rptPricingReport.SetParameterValue("Freight", GetFreight());

                rptPricingReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptPricingReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptPricingReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

                //translate the report
                DLLPricingReports.CustomUnitPricingTranslation.translateReport(rptPricingReport, Public.Language);
                DLLPricingReports.AdditionalItemsTranslation.translateReport(rptPricingReport.Subreports["AdditionnalItemsPrice.rpt"], Public.Language);

                //export to pdf without opening it (will be merge later on)
                string strFileLocation = Public.ExportReportToFormat(rptPricingReport, "QuoteReport", "PDF", false);

                //if the creation of pdf worked
                //add the file name (containing path) to the list of files to be merged
                if (strFileLocation != "")
                {
                    if (addPriceReportToQuote)
                    {
                        DataTable test = Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"],
                       "ItemID = " + itemID, "");
                        if (test.Rows[0]["Unit1"].ToString() != "BLANK UNIT")
                        {
                            lstFileNames.Add(strFileLocation);
                        }
                    }
                    if (addPerformanceReportToQuote)
                    {
                        DataTable test = Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"],
                       "ItemID = " + itemID, "");
                        if (test.Rows[0]["Unit1"].ToString() != "BLANK UNIT")
                        {
                            //performance shows here
                            GenerateSingleCustomUnitSpec(iCustomUnit, ref lstFileNames);
                        }
                    }

                    lstCoverPageData.Add(new QuoteCoverPageData(_dsQuoteData.Tables["CustomUnitTable"].Rows[iCustomUnit]["Tag"].ToString(), _dsQuoteData.Tables["CustomUnitTable"].Rows[iCustomUnit]["Description"].ToString(), Convert.ToInt32(_dsQuoteData.Tables["CustomUnitTable"].Rows[iCustomUnit]["Quantity"]), decGrandTotal / Convert.ToDecimal(_dsQuoteData.Tables["CustomUnitTable"].Rows[iCustomUnit]["Quantity"]), decGrandTotal));
                }

                //dispose object
                rptPricingReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();
            }
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
            //refresh the list
            RefreshBasketList();
        }

        private void txtContactName_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtRep_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtEngineer_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtClientReferenceNumber_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtEstimateNumber_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void cboDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void cboFreight_SelectedIndexChanged(object sender, EventArgs e)
        {
            //2011-03-14 : i was about to show the prix box but they dont use that. 
            //they play with multiplier instead we simply need to change the text
            //on the bottom square on the reports.

            //if (cboFreight.SelectedIndex == 0)
            //{
            //    numFreight.Visible = false;
            //    numFreight.Value = 0m;
            //}
            //else
            //{
            //    numFreight.Visible = true;
            //}

            SetQuoteIsModified(true);
        }

        private void numFreight_ValueChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtZipcode_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private void txtAttention_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        public void SetQuoteIsModified(bool quoteIsModified)
        {
            _quoteIsModified = quoteIsModified;
        }

        private void lblContactIDValue_TextChanged(object sender, EventArgs e)
        {
            SetQuoteIsModified(true);
        }

        private bool IsQuoteReadyToSave()
        {
            bool quoteReadyToSave = true;

            ////must have a project name
            //if (txtProjectName.Text.Trim().Length == 0)
            //{
            //    ThreadProcess.Stop();
            //    Public.LanguageBox("You must enter a project name", "Vous devez entrer un nom de projet");
            //    QuoteReadyToSave = false;
            //}

            //must have a unit in the list
            if (lstBasket.Items.Count == 0)
            {
                ThreadProcess.Stop();
                Focus();
                Public.LanguageBox("You must have at least 1 unit in your quote", "Vous devez avoir un minimum de 1 unité dans votre soumission");
                quoteReadyToSave = false;
            }

            //if a contact has been selected
            if (lblContactIDValue.Text == @"0")
            {
                ThreadProcess.Stop();
                Focus();
                Public.LanguageBox("You must select a contact/client for the quote", "Vous devez sélectionner un contact/client pour votre soumission");
                quoteReadyToSave = false;
            }

            return quoteReadyToSave;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveQuote();
        }

        private void SaveQuote()
        {
            //Save the OLD user of the quote, so we know if the new modifier is in internal sales (so if an email needs to be sent)
            string oldSaver = txtLastUpdateBy.Text.Contains("(") ? txtLastUpdateBy.Text.Substring(0, txtLastUpdateBy.Text.IndexOf("(", StringComparison.Ordinal) - 1).Trim() : txtLastUpdateBy.Text;


            //check if user want to save the quote.
            if (MessageBox.Show(Public.LanguageString("Are you sure you want to save this quote ?", "Êtes-vous sûr de vouloir sauvegarder cette soumission?"), Public.LanguageString("Save Quote", "Sauvegarder soumission"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //check if we can save the quote
                if (IsQuoteReadyToSave())
                {
                    if (!_isNewQuote)
                    {
                        if (MessageBox.Show(Public.LanguageString("Do you want to save this quote as a revision (yes) or as a new quote (no)?","voulez-vous sauvegarder cette soumission en tant que révision (oui) ou en tant que nouvelle soumission (non) ?"),Public.LanguageString("Save Quote", "Sauvegarder soumission"), MessageBoxButtons.YesNo) !=DialogResult.Yes)
                        {
                            _isNewQuote = true;
                        }
                       
                    }

                    ThreadProcess.Start(Public.LanguageString("Saving Quote", "Sauvegarde de la soumission"));

                    //if new quote we need to get a new quote ID and Revision will be 0 (A)
                    if (_isNewQuote)
                    {
                        //get new quote id
                        _quoteID = _backgroundCode.GenerateNewQuoteID();
                        //set revision to 0
                        _revisionID = 0;
                    }
                    else
                    {
                        //increment revision
                        _revisionID = _backgroundCode.GetNewRevisionID(_quoteID);
                    }

                    //to save we check if quoteID is valid (smaller than 0 mean an error occured
                    if (_quoteID > 0)
                    {
                        //everything is fine.
                        //now we need to fill in the quote table and update the respective field 
                        //in the other table that store values from quote. Such as quote ID, revision...
                        //these field are link to know to which quote they are attached to.
                        UpdateUnitTablesData();

                        //update the quote table
                        UpdateQuoteDataTable();

                        //save to database the quote
                        if (SaveQuoteToDatabase())
                        {
                            //set isnew to false so it update next time.
                            _isNewQuote = false;

                            //reload with saved data
                            LoadQuote();

                            SetQuoteIsModified(false);
                            Query.Execute("Insert Into QuotePrice VALUES(" + _quoteID + "," + _revisionID + "," +
                                          numMultiplier.Value + "," + Convert.ToDecimal(lblTotalPriceValue.Text.Remove(0,1)).ToString("0.00") + ")");
                            
                            //if the last saver is one of the salesman, needs to check for PREVIOUS saver
                            if ((oldSaver == "ALLAN ARSENAULT" || oldSaver == "SIMON TRÉPANIER" ||
                                oldSaver == "SYLVAIN LAPALME" || oldSaver == "FRÉDÉRIC HOULE" ||
                                oldSaver == "JACQUES BLANCHARD" || oldSaver == "Patrice Voutsinas") && _revisionID != 0)
                            {
                                DataTable savers =
                                    Query.Select("Select LastUpdateBy from QuoteData where QuoteID =" + _quoteID +
                                                 "order by QuoteRevision desc");
                                foreach (DataRow saver in savers.Rows)
                                {
                                    if (!saver["LastUpdateBy"].ToString().Contains("ALLAN ARSENAULT") &&
                                        !saver["LastUpdateBy"].ToString().Contains("SIMON TRÉPANIER") &&
                                        !saver["LastUpdateBy"].ToString().Contains("SYLVAIN LAPALME") &&
                                        !saver["LastUpdateBy"].ToString().Contains("FRÉDÉRIC HOULE") &&
                                        !saver["LastUpdateBy"].ToString().Contains("JACQUES BLANCHARD") &&
                                        !saver["LastUpdateBy"].ToString().Contains("Patrice Voutsinas"))
                                    {
                                        oldSaver = saver["LastUpdateBy"].ToString().Contains("(") ? saver["LastUpdateBy"].ToString().Substring(0, txtLastUpdateBy.Text.IndexOf("(", StringComparison.Ordinal) - 2).Trim() : saver["LastUpdateBy"].ToString();
                                        break;
                                    }
                                }
                            }
                            if (oldSaver == "ALLAN ARSENAULT" || oldSaver == "SIMON TRÉPANIER" ||
                                oldSaver == "SYLVAIN LAPALME" || oldSaver == "FRÉDÉRIC HOULE" ||
                                oldSaver == "JACQUES BLANCHARD" || oldSaver == "Patrice Voutsinas")
                            {
                                oldSaver = UserInformation.Name;
                            }
                            if (UserInformation.Name != oldSaver && UserInformation.Userlevel > 89 && !_isNewQuote && oldSaver != "" && _revisionID != 0)
                            {
                                if (Public.LanguageQuestionBox("Do you want to send an email to the user :" + oldSaver + " so he knows you changed his quotation?", "Voulez-vous envoyer un courriel à l'usager :" + oldSaver + " pour qu'il sache que vous venez de modifier sa soumission?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if (SendEmail(oldSaver))
                                    {
                                        Public.LanguageBox(
                                            "An email message was sent to warn the user that you just revised his quotation",
                                            "Un courriel vient d'etre envoye au client pour qu'il sache que vous avez modifié sa soumission");
                                     }
                                    else
                                    {
                                        Public.LanguageBox(
                                            "Something happened and the email didn't pass correctly.  Please check with IT to see what happened",
                                            "Le courriel n'a pas été envoyé correctement.  Veuillez vérifier avec TI pour voir ce qui s'est passé.");
                                    }
                                }
                                
                            }

                        }
                        else
                        {
                            ThreadProcess.Stop();
                            Focus();
                            Public.LanguageBox("An error occcured while trying to save. Function SaveQuoteToDatabase", "Une erreur est survenue lors de la sauvegarde.  Fonction SaveQuoteToDatabase");
                        }
                    }
                    else
                    {
                        ThreadProcess.Stop();
                        Focus();
                        Public.LanguageBox("An error occcured while trying to save.  Function QuoteID", "Une erreur est surevenue lors de la sauvegarde.  Fonction QuoteID");
                    }
                    ThreadProcess.Stop();
                    Focus();
                }
            }
        }

        private Boolean SendEmail(string nameToSendEmailTo)
        {
            bool ret = false;
            var cred = new NetworkCredential("mail@networxgroup.net", "smtp587");
            var msg = new MailMessage();
            DataTable email = Query.Select("Select email from contact_new where name = '" + nameToSendEmailTo + "' and email IS NOT NULL and NOT email = '' ");
            if(email.Rows.Count == 1)
            {
                msg.To.Add(email.Rows[0]["Email"].ToString());
                msg.From = new MailAddress("Webtools-Do-Not-Reply@refplus.com");
                msg.Subject = "Votre soumission #" + _quoteID + " vient d'être modifiée par un vendeur de Refplus.   --   Your quote #" + _quoteID + " was just mofied by a Refplus' sales person";
                msg.Body = UserInformation.Name + " vient de modifier votre soumission (numéro : "+ _quoteID + "). \n\n\n" + UserInformation.Name + " modified your quote (number : " + _quoteID + ").";
                var client = new SmtpClient("mail.networxgroup.net", 587) { Credentials = cred, EnableSsl = false };
                client.Send(msg);
                ret = true;
            }
            return ret;
        }

        private bool SaveQuoteToDatabase()
        {
            bool returnValue = false;

            string tsql = GetSaveQuery();

            if (Query.Execute(tsql))
            {
                
                returnValue = true;
                ThreadProcess.Stop();
                Focus();
                Public.LanguageBox("Quote saved sucessfully", "Soumission sauvegardée avec succès");
                foreach (string query in _sql)
                {
                    if (query != "")
                    {
                        Query.Execute(query.Replace("QUOTEPH", _quoteID.ToString(CultureInfo.InvariantCulture)).Replace("REVPH", _revisionID.ToString(CultureInfo.InvariantCulture)));
                    }
                }
            }

            return returnValue;
        }

        public string GetSaveQuery()
        {
            //2013-02-18 : #3822 : added ty catch and rollback in case the primary key check does cancel all
            //subsequent queries.
            string tsql = "BEGIN TRY BEGIN TRANSACTION ";

            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["QUOTE_DATA"], "QuoteData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["Evaporators"], "QuoteEvaporatorData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["EvaporatorOption"], "QuoteEvaporatorOptionsData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["Condensers"], "QuoteCondenserData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["ControlPanelInputs"], "QuoteControlPanelData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["ReceiverInputs"], "QuoteReceiverData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["SecondaryOptions"], "QuoteSecondaryOptionsData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["RefrigerantCircuits"], "QuoteRefrigerantCircuitsData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["FluidCoolers"], "QuoteFluidCoolerData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["PumpInputs"], "QuotePumpData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["QuickCoil"], "QuoteCoilData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["AdditionalItems"], "QuoteAdditionalItemsData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["CondensingUnit"], "QuoteCondensingUnitData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["CondensingUnitCompressorReceiver"], "QuoteCondensingUnitCompressorReceiverData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["CondensingUnitWaterCooledCondenser"], "QuoteCondensingUnitWaterCooledCondenserData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["CondensingUnitOption"], "QuoteCondensingUnitOptionData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["QuickManualCoil"], "QuoteManualCoilData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["HeatPipes"], "QuoteHeatPipeData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["GravityCoils"], "QuoteGravityCoilData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["CustomUnitTable"], "QuoteCustomUnitData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["OEMCoils"], "QuoteOEMCoils");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["OEMCoilConnections"], "QuoteOEMCoilConnections");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["OEMCoilFlareFittings"], "QuoteOEMCoilFlareFittings");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["OEMCoilDistributors"], "QuoteOEMCoilDistributors");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["OEMCoilPrice"], "QuoteOEMCoilPrice");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["QuickWaterEvaporator"], "QuoteWaterEvaporatorData");
            tsql += Query.BuildInsertQuery(_dsQuoteData.Tables["WaterEvaporatorOption"], "QuoteWaterEvaporatorOptionsData");

            tsql += " COMMIT TRANSACTION";
            tsql += " END TRY BEGIN CATCH ROLLBACK RAISERROR ('Error while saving quote', 16,  1 ) END CATCH";

            return tsql;
        }

        private void UpdateQuoteDataTable()
        {
            //2011-03-14 : added because due to adding the save and new quote option it cause a problem
            //where the created by stayed. so i added this function which add the current user info in the
            //quotes by field. like that i dont have to change code for saving.
            if (_isNewQuote)
            {
                UpdateQuotationByFields();
            }

            _dsQuoteData.Tables["QUOTE_DATA"].Rows.Clear();

            DataRow drQuoteData = _dsQuoteData.Tables["QUOTE_DATA"].NewRow();

            drQuoteData["QuoteID"] = _quoteID;
            drQuoteData["QuoteRevision"] = _revisionID;
            drQuoteData["QuoteRevisionText"] = Public.RevisionID_To_Letter(_revisionID);

            drQuoteData["ProjectName"] = txtProjectName.Text;
            //dont set date, server will take care of it
            //drQuoteData["QuotationDate"] = Convert.ToDateTime(lblQuotationDate.Text);
            drQuoteData["QuotationBy"] = lblQuotationBy.Text;
            drQuoteData["QuotationByUsername"] = _strQuotationByUsername;
            drQuoteData["QuotationByContactID"] = _intQuotationByContactID;
            drQuoteData["QuotationByGroupID"] = _intQuotationByGroupID;
            drQuoteData["QuotationSite"] = UserInformation.CurrentSite;
            drQuoteData["Email"] = lblQuotationEmail.Text;
            drQuoteData["Rep"] = txtRep.Text;
            drQuoteData["Engineer"] = txtEngineer.Text;
            drQuoteData["ClientRefNumber"] = txtClientReferenceNumber.Text;
            drQuoteData["EstimateNumber"] = txtEstimateNumber.Text;
            drQuoteData["Terms"] = cboTerms.Text;
            drQuoteData["Delivery"] = cboDelivery.Text;
            drQuoteData["Freight"] = cboFreight.Text;
            drQuoteData["FreightPrice"] = numFreight.Value;
            drQuoteData["Multiplier"] = numMultiplier.Value;
            drQuoteData["ContactID"] = Convert.ToInt32(lblContactIDValue.Text);
            drQuoteData["GroupID"] = _contactGroupID;
            drQuoteData["ContactName"] = txtContactName.Text;
            drQuoteData["ContactEmail"] = txtContactEmail.Text;
            drQuoteData["ContactPhone"] = txtPhone.Text;
            drQuoteData["Address"] = txtAddress.Text;
            drQuoteData["City"] = txtCity.Text;
            drQuoteData["State"] = txtState.Text;
            drQuoteData["Country"] = txtCountry.Text;
            drQuoteData["ZipCode"] = txtZipcode.Text;
            drQuoteData["Notes"] = txtNote.Text;
            drQuoteData["Currency"] = cboCurrency.Text;
            drQuoteData["Attention"] = txtAttention.Text;
            drQuoteData["LastUpdateBy"] = UserInformation.Name + (UserInformation.CompanyName != "" ? " (" + UserInformation.CompanyName + ")" : "");

            _dsQuoteData.Tables["QUOTE_DATA"].Rows.Add(drQuoteData);
        }

        private void UpdateUnitTablesData()
        {
            foreach (DataTable dtTables in _dsQuoteData.Tables)
            {
                if (dtTables.TableName != "QUOTE_DATA")
                {
                    for (int intRow = 0; intRow < dtTables.Rows.Count; intRow++)
                    {
                        _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["QuoteID"] = _quoteID;
                        _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["QuoteRevision"] = _revisionID;
                        _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["QuoteRevisionText"] = Public.RevisionID_To_Letter(_revisionID);
                        _dsQuoteData.Tables[dtTables.TableName].Rows[intRow]["Username"] = UserInformation.UserName;
                    }
                }
            }
        }

        private void LoadQuote()
        {
            //clear any record possibly existing in the dataset
            foreach (DataTable dt in _dsQuoteData.Tables)
            {
                dt.Clear();
            }

            //load the good record in the good table of the dataset
            LoadTable("QuoteData", "QUOTE_DATA", "");
            LoadTable("QuoteEvaporatorData", "Evaporators", "tag");
            LoadTable("QuoteEvaporatorOptionsData", "EvaporatorOption", "");
            LoadTable("QuoteCondenserData", "Condensers", "Input_tag");
            LoadTable("QuoteControlPanelData", "ControlPanelInputs", "");
            LoadTable("QuoteReceiverData", "ReceiverInputs", "");
            LoadTable("QuoteSecondaryOptionsData", "SecondaryOptions", "");
            LoadTable("QuoteRefrigerantCircuitsData", "RefrigerantCircuits", "");
            LoadTable("QuoteFluidCoolerData", "FluidCoolers", "Input_tag");
            LoadTable("QuotePumpData", "PumpInputs", "");
            LoadTable("QuoteCoilData", "QuickCoil", "tag");
            LoadTable("QuoteAdditionalItemsData", "AdditionalItems", "");
            LoadTable("QuoteCondensingUnitData", "CondensingUnit", "Input_tag");
            LoadTable("QuoteCondensingUnitCompressorReceiverData", "CondensingUnitCompressorReceiver", "");
            LoadTable("QuoteCondensingUnitWaterCooledCondenserData", "CondensingUnitWaterCooledCondenser", "");
            LoadTable("QuoteCondensingUnitOptionData", "CondensingUnitOption", "");
            LoadTable("QuoteManualCoilData", "QuickManualCoil", "tag");
            LoadTable("QuoteHeatPipeData", "HeatPipes", "tag");
            LoadTable("QuoteGravityCoilData", "GravityCoils", "Input_tag");
            LoadTable("QuoteCustomUnitData", "CustomUnitTable", "tag");
            LoadTable("QuoteOEMCoils", "OEMCoils", "Input_tag");
            LoadTable("QuoteOEMCoilConnections", "OEMCoilConnections", "");
            LoadTable("QuoteOEMCoilFlareFittings", "OEMCoilFlareFittings", "");
            LoadTable("QuoteOEMCoilDistributors", "OEMCoilDistributors", "");
            LoadTable("QuoteOEMCoilPrice", "OEMCoilPrice", "");
            LoadTable("QuoteWaterEvaporatorData", "QuickWaterEvaporator", "tag");
            LoadTable("QuoteWaterEvaporatorOptionsData", "WaterEvaporatorOption", "");


            //fill the header info of the quote
            if (FillQuoteHeaderInformation() && RefreshBasketList())
            {
                Public.LanguageBox("This quotation was created with old condensing units no longer supported by Webtools.  Please reselect your condensing units starting with IC, IL, OC, or OL, or contact the sales and technical departement. Thank you", "Cette soumission a été créée avec des vieux modèles de groupes compresseurs-condenseurs qui ne sont plus supportés dans Webtools.  Veuillez resélectionner vos appareils commençant par OL, OC, IL, et IC, ou contactez le département des ventes et support techniques.  Merci!");
            }

            SetQuoteIsModified(false);
        }

        private bool FillQuoteHeaderInformation()
        {
            bool oldDate = false;
            txtProjectName.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["ProjectName"].ToString();
            lblQuotationNumber.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuoteID"] + @"-" + _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuoteRevisionText"];
            lblQuotationDate.Text = Convert.ToDateTime(_dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuotationDate"]).ToString(CultureInfo.InvariantCulture);
            if (DateTime.Compare(Convert.ToDateTime(_dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuotationDate"]), new DateTime(2013, 5, 21)) <= 0)
            {
                oldDate = true;
            }
            lblQuotationBy.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuotationBy"].ToString();
            lblQuotationEmail.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Email"].ToString();

            //save these variables to be able to reset then when we save again
            _strQuotationByUsername = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuotationByUsername"].ToString();
            _intQuotationByContactID = Convert.ToInt32(_dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuotationByContactID"]);
            _intQuotationByGroupID = Convert.ToInt32(_dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["QuotationByGroupID"]);

            txtRep.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Rep"].ToString();
            txtEngineer.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Engineer"].ToString();
            txtClientReferenceNumber.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["ClientRefNumber"].ToString();
            txtEstimateNumber.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["EstimateNumber"].ToString();

            ComboBoxControl.SetDefaultValue(cboTerms, _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Terms"].ToString());
            ComboBoxControl.SetDefaultValue(cboDelivery, _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Delivery"].ToString());
            ComboBoxControl.SetDefaultValue(cboFreight, _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Freight"].ToString());

            numFreight.Value = Convert.ToDecimal(_dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["FreightPrice"]);
            SetMultiplierControl(Convert.ToDecimal(_dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Multiplier"]));
            //numMultiplier.Value = Convert.ToDecimal(dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Multiplier"]);

            lblContactIDValue.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["ContactID"].ToString();
            _contactGroupID = Convert.ToInt32(_dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["GroupID"]);

            txtContactName.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["ContactName"].ToString();
            txtContactEmail.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["ContactEmail"].ToString();
            txtPhone.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["ContactPhone"].ToString();
            txtAddress.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Address"].ToString();
            txtCity.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["City"].ToString();
            txtState.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["State"].ToString();
            txtCountry.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Country"].ToString();
            txtZipcode.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["ZipCode"].ToString();
            txtNote.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Notes"].ToString();

            ComboBoxControl.SetDefaultValue(cboCurrency, _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Currency"].ToString());

            txtAttention.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["Attention"].ToString();
            txtLastUpdateBy.Text = _dsQuoteData.Tables["QUOTE_DATA"].Rows[0]["LastUpdateBy"].ToString();
            return oldDate;
        }

        private void LoadTable(string sqlTable, string datasetTable, string tagname)
        {
            //select the data in sql we want according to parameter
            DataTable dtSelect = tagname != "" ? Query.Select("SELECT * FROM " + sqlTable + " WHERE QuoteID = " + _quoteID + " AND QuoteRevision = " + _revisionID + " order by " + tagname + ", itemID") : Query.Select("SELECT * FROM " + sqlTable + " WHERE QuoteID = " + _quoteID + " AND QuoteRevision = " + _revisionID);
            //for each record add the row to the dataset of the quote in the memory
            foreach (DataRow dr in dtSelect.Rows)
            {
                _dsQuoteData.Tables[datasetTable].Rows.Add(dr.ItemArray);
            }
        }

        private void toolAddCoil_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteCoil)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Coil Selection", "Préparation de la sélection de Serpentin"));
                //open coil in add mode (-1 as index)
                var quickCoilform = new QuickCoil.FrmQuickCoil(this, _dsQuoteData, -1, QuickCoil.FrmQuickCoil.CoilOpenType.Selection, -1);
                quickCoilform.ShowDialog();
                
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void toolEditAdditionalItems_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteAdditionnalItems)
            {
                if (lstBasket.SelectedItems.Count > 0)
                {
                    ArrayList myItem = lstBasket.SelectedItems;
                    string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                    int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                    int intItemType = 0;
                    switch (strTable)
                    {
                        case "Evaporators":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Evaporator);
                            break;
                        case "Condensers":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Condenser);
                            break;
                        case "FluidCoolers":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.FluidCooler);
                            break;
                        case "QuickCoil":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.Coil);
                            break;
                        case "CondensingUnit":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CondensingUnit);
                            break;
                        case "QuickManualCoil":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.ManualCoil);
                            break;
                        case "HeatPipes":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.HeatPipe);
                            break;
                        case "GravityCoils":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.GravityCoil);
                            break;
                        case "CustomUnitTable":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.CustomUnit);
                            break;
                        case "QuickWaterEvaporator":
                            intItemType = QuoteItem.ItemTypeToValue(QuoteItem.ItemType.WaterEvaporator);
                            break;
                        default:
                            Public.LanguageBox("This unit cannot have additionnal items", "Cette unité ne peut avoir d'items additionels");
                            break;
                    }

                    var addtionalItems = new FrmAdditionalItems(this, _dsQuoteData, intIndex, intItemType);
                    addtionalItems.ShowDialog();
                }
                else
                {
                    Public.LanguageBox("You must select something in order to edit its additional items.", "Vous devez sélectionner quelque chose pour éditer ses articles supplémentaires.");
                    //MessageBox.Show("You must select something in order to edit it's additional items.");
                }
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void toolAddCondensingUnit_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteCondensingUnit)
            {
                Public.OpenBitzerMessage();
                ThreadProcess.Start(Public.LanguageString("Preparing Condensing Unit Selection", "Préparation de la sélection du groupe compresseur-condenseur"));
                var quickCondensingUnit = new QuickCondensingUnit.FrmQuickCondensingUnit(this, _dsQuoteData, -1);
                quickCondensingUnit.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void toolAddManualCoil_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteManualCoil)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Coil Selection", "Préparation de la sélection de Serpentin"));
                //open coil in add mode (-1 as index)
                var quickCoilform = new QuickCoil.FrmQuickCoil(this, _dsQuoteData, -1, QuickCoil.FrmQuickCoil.CoilOpenType.Manual, -1);
                quickCoilform.ShowDialog();

            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void toolAddHeatPipe_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteHeatPipe)
            {

                ThreadProcess.Start(Public.LanguageString("Preparing Heat Pipe Selection", "Préparation de la sélection des Caloduc"));
                //open Heat pipe in add mode (-1 as index)
                var quickHeatPipeform = new QuickHeatPipe.FrmQuickHeatPipe(this, _dsQuoteData, -1);
                quickHeatPipeform.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void toolAddGravityCoil_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteGravityCoil)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Gravity Coil Selection", "Préparation de la sélection de Serpentin Gravité"));
                var quickGravityCoil = new QuickGravityCoil.FrmGravityCoil(this, _dsQuoteData, -1);
                quickGravityCoil.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void toolAddCustomUnit_Click(object sender, EventArgs e)
        {

                ThreadProcess.Start(Public.LanguageString("Preparing Custom Unit Selection", "Préparation de la sélection de l'unité personnalisée"));
                var quickCustomUnit = new QuickCustomUnit.FrmQuickCustomUnit(this, _dsQuoteData, -1);
                quickCustomUnit.ShowDialog();
            
        }

        private void ToolAddOEMCoil_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteOEMCoil)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing OEM Coil Selection", "Préparation de la sélection de Serpentin OEM"));
                var oemCoil = new OEMCoil.FrmOEMCoil(this, _dsQuoteData, -1);
                oemCoil.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void toolSpecialReportEngineeringReport_Click(object sender, EventArgs e)
        {
            if (lstBasket.SelectedItems.Count > 0)
            {
                ArrayList myItem = lstBasket.SelectedItems;
                string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                
                switch (strTable)
                {
                    case "CondensingUnit":
                        if (UserInformation.Userlevel < 80)
                        {
                            Public.LanguageBox("Access Denied", "Acces refusé");
                        }
                        else
                        {
                            GenerateCondensingUnitEngineeringReport(Public.SelectAndSortTable(_dsQuoteData.Tables[strTable], "ItemID = " + intIndex, "").Rows[0]["Model"].ToString());
                        }
                        break;
                    case "Condensers":
                        GenerateCondenserEngineeringReport(Public.SelectAndSortTable(_dsQuoteData.Tables[strTable], "ItemID = " + intIndex, "").Rows[0]["CondenserModel"].ToString(), Public.SelectAndSortTable(_dsQuoteData.Tables[strTable], "ItemID = " + intIndex, "").Rows[0]["VoltageID"].ToString());
                        break;
                    case "Evaporators":
                        var namesToOpenIfEvaporators = new List<string>();
                        GenerateSingleEvaporatorTechSpec(intIndex, ref namesToOpenIfEvaporators);
                        MergeAndPreviewReport(namesToOpenIfEvaporators, "");
                        break;
                    default:
                        Public.LanguageBox("This unit do not have an engineering report", "Cette unité n'a pas de rapport d'ingénierie");
                        break;
                }
            }
        }


        private void GenerateCondensingUnitEngineeringReport(string modelName)
        {
            Report.EngineeringReport.ErCondensingUnit.Generate(modelName, true);
        }

        private void GenerateCondenserEngineeringReport(string modelName, string voltageID)
        {
            Report.EngineeringReport.ErCondenser.Generate(modelName, voltageID, true);
        }

        private void toolSpecialReportAdvancedSalesReport_Click(object sender, EventArgs e)
        {
            if (lstBasket.SelectedItems.Count > 0)
            {
                ArrayList myItem = lstBasket.SelectedItems;
                string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);

                switch (strTable)
                {
                    case "OEMCoils":
                        GenerateSingleOEMCoilPriceReport(intIndex, true, true);
                        break;
                    default:
                        Public.LanguageBox("This unit do not have an advanced sales report", "Cette unité n'a pas de rapport avancé de prix");
                        break;
                }
            }
        }

        private void picEmail_Click(object sender, EventArgs e)
        {
            //if the email is valid
            if (Public.IsEmailValid(txtContactEmail.Text))
            {
                //open default Email software and fill the "TO"
                System.Diagnostics.Process.Start("mailto:" + txtContactEmail.Text);
            }
            else
            {
                Public.LanguageBox("The email is not valid", "Le courriel indiqué n'est pas valide");
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuotes_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void toolGenerateSpecificationReport_Click(object sender, EventArgs e)
        {
            if (lstBasket.SelectedItems.Count > 0)
            {
                ArrayList myItem = lstBasket.SelectedItems;
                string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                int row = 0;

                for (int i = 0; i < _dsQuoteData.Tables[strTable].Rows.Count; i++)
                {
                    if (Convert.ToInt32(_dsQuoteData.Tables[strTable].Rows[i]["ItemID"].ToString()) == intIndex)
                    {
                        row = i;
                        i = _dsQuoteData.Tables[strTable].Rows.Count;
                    }
                }

                var lstFileNames = new List<string>();

                switch (strTable)
                {
                    case "Evaporators":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleEvaporatorSpec(row, ref lstFileNames);
                        break;
                    case "QuickWaterEvaporator":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleWaterEvaporatorSpec(row, ref lstFileNames);
                        break;
                    case "Condensers":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleCondenserSpec(row, ref lstFileNames);
                        break;
                    case "CondensingUnit":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleCondensingUnitSpec(row, ref lstFileNames);
                        break;
                    case "FluidCoolers":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleFluidCoolerSpec(row, ref lstFileNames);
                        break;
                    case "QuickCoil":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleCoilSpec(row, ref lstFileNames);
                        break;
                    case "HeatPipes":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleHeatPipeSpec(row, ref lstFileNames);
                        break;
                    case "GravityCoils":
                        ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                        GenerateSingleGravityCoilSpec(row, ref lstFileNames);
                        break;
                    case "CustomUnitTable":
                        DataTable test = Public.SelectAndSortTable(_dsQuoteData.Tables["CustomUnitTable"],"", "");
                        if(test.Rows[0]["Unit1"].ToString() == "BLANK UNIT")
                        {
                            Public.LanguageBox("This unit does not have a spec report.", "Cette unité n'a pas de rapport de spécifications");
                        }
                        else
                        {
                            ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                            GenerateSingleCustomUnitSpec(row, ref lstFileNames);
                        }
                        
                        break;
                    //case "OEMCoils":
                    //    ThreadProcess.Start(Public.LanguageString("Generating Specification Report", "Création du rapport de spécifications"));
                    //    GenerateSingleOEMCoilSpec(Row, ref lstFileNames);
                    //    break;
                    default:
                        ThreadProcess.Stop();
                        Focus();
                        Public.LanguageBox("This unit does not have a spec report.", "Cette unité n'a pas de rapport de spécifications");
                        break;
                }

                if (lstFileNames.Count > 0)
                {
                    Public.OpenSpecificFile(Public.MergePDFFiles(lstFileNames));
                }

                ThreadProcess.Stop();
                Focus();

            }
            else
            {
                Public.LanguageBox("You must select something in order to generate spec report.", "Vous devez sélectionner quelque chose pour générer le rapport de spécifications.");
            }
        }

        private void toolGenerateDrawing_Click(object sender, EventArgs e)
        {
            if (lstBasket.SelectedItems.Count > 0)
            {
                ArrayList myItem = lstBasket.SelectedItems;
                string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                int row = 0;

                for (int i = 0; i < _dsQuoteData.Tables[strTable].Rows.Count; i++)
                {
                    if (Convert.ToInt32(_dsQuoteData.Tables[strTable].Rows[i]["ItemID"].ToString()) == intIndex)
                    {
                        row = i;
                        i = _dsQuoteData.Tables[strTable].Rows.Count;
                    }
                }

                string strDrawingFile = "";

                ThreadProcess.Start(Public.LanguageString("Finding drawing", "Recherche du dessin"));

                switch (strTable)
                {
                    case "Evaporators":
                        strDrawingFile = GenerateSingleEvaporatorDrawing(row);
                        break;
                    case "QuickWaterEvaporator":
                        strDrawingFile = GenerateSingleWaterEvaporatorDrawing(row);
                        break;
                    case "Condensers":
                        strDrawingFile = GenerateSingleCondenserDrawing(row);
                        break;
                    case "CondensingUnit":
                        strDrawingFile = GenerateSingleCondensingUnitDrawing(row);
                        break;
                    case "FluidCoolers":
                        strDrawingFile = GenerateSingleFluidCoolerDrawing(row);
                        break;
                    case "QuickCoil":
                        strDrawingFile = "";
                        break;
                    case "HeatPipes":
                        strDrawingFile = "";
                        break;
                    case "GravityCoils":
                        strDrawingFile = GenerateSingleGravityCoilDrawing(row);
                        break;
                    case "CustomUnitTable":
                        strDrawingFile = "";
                        break;
                    case "OEMCoils":
                        strDrawingFile = "";
                        break;
                    case "QuickManualCoil":
                        strDrawingFile = "";
                        break;
                }

                ThreadProcess.Stop();
                Focus();
                if (strDrawingFile != "")
                {
                    Public.OpenSpecificFile(strDrawingFile);
                }
                else
                {
                    Public.LanguageBox("No drawing found for this unit", "Aucun dessin trouvé pour cet unité");
                }
            }


        }

        private void toolAddWaterEvaporator_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuoteWaterEvaporator)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Water Evaporator Selection", "Préparation de la sélection d'Évaporateur à eau"));
                //open water evaportator in add mode (-1 as index)
                var quickWaterEvaporator = new QuickWaterEvaporator.FrmQuickWaterEvaporator(this, _dsQuoteData, -1);
                quickWaterEvaporator.ShowDialog();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void lstBasket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (_quoteID == 0)
                {
                    Public.LanguageBox("Before you edit your units with this function, please save your quotation, thank you", "Avant de modifier vos étiquettes de cette façon, veuillez s'il-vous-plaît sauvegarder votre soumission.  Merci!");
                }
                else
                {
                    if (lstBasket.SelectedItems.Count != 1)
                    {
                        Public.LanguageBox("To edit a tag using F2, you must have only one unit selected", "Pour modifier un tag avec F2, vous devez avoir une seule unité de sélectionnée");
                    }
                    else
                    {

                        var tag = new FrmTag();
                        tag.ShowDialog();
                        if (tag.GetPressed())
                        {
                            SetQuoteIsModified(true);
                            string sqltopush = " Update ";
                            string tagName = "";
                            string tableNameInSQL = "";
                            Boolean update = true;
                            ArrayList myItem = lstBasket.SelectedItems;
                            string strTable = ((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[1].Text;
                            int itemID = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                            switch (strTable)
                            {
                                case "Evaporators":
                                    tableNameInSQL = "QuoteEvaporatorData";
                                    sqltopush += "QuoteEvaporatorData  Set tag = ";
                                    tagName = "tag";
                                    break;
                                case "Condensers":
                                    tableNameInSQL = "QuoteCondenserData";
                                    sqltopush += "QuoteCondenserData  Set Input_tag = ";
                                    tagName = "Input_tag";
                                    break;
                                case "FluidCoolers":
                                    tableNameInSQL = "QuoteFluidCoolerData";
                                    sqltopush += "QuoteFluidCoolerData  Set Input_Tag = ";
                                    tagName = "Input_tag";
                                    break;
                                case "QuickCoil":
                                    tableNameInSQL = "QuoteCoilData";
                                    sqltopush += "QuoteCoilData  Set tag = ";
                                    tagName = "tag";
                                    break;
                                case "CondensingUnit":
                                    tableNameInSQL = "QuoteCondensingUnitData";
                                    sqltopush += "QuoteCondensingUnitData  Set Input_Tag = ";
                                    tagName = "Input_tag";
                                    break;
                                case "QuickManualCoil":
                                    tableNameInSQL = "QuoteManualCoilData";
                                    sqltopush += "QuoteManualCoilData  Set tag = ";
                                    tagName = "tag";
                                    break;
                                case "HeatPipes":
                                    tableNameInSQL = "QuoteHeatPipeData";
                                    sqltopush += "QuoteHeatPipeData  Set tag = ";
                                    tagName = "tag";
                                    break;
                                case "GravityCoils":
                                    tableNameInSQL = "QuoteGravityCoilData";
                                    sqltopush += "QuoteGravityCoilData  Set Input_Tag = ";
                                    tagName = "Input_tag";
                                    break;
                                case "CustomUnitTable":
                                    tableNameInSQL = "QuoteCustomUnitData";
                                    sqltopush += "QuoteCustomUnitData  Set tag = ";
                                    tagName = "tag";
                                    break;
                                case "QuickWaterEvaporator":
                                    tableNameInSQL = "QuoteWaterEvaporatorData";
                                    sqltopush += "QuoteWaterEvaporatorData  Set tag = ";
                                    tagName = "tag";
                                    break;
                                case "OEMCoils":
                                    tableNameInSQL = "QuoteOEMCoils";
                                    sqltopush += "QuoteOEMCoils Set Input_tag = ";
                                    tagName = "Input_tag";
                                    break;
                            }
                            string str = "Select * From " + tableNameInSQL + " Where QuoteID = " + _quoteID + "And QuoteRevision = " + _revisionID + " And ItemID = " + itemID;
                            DataTable dt = Query.Select(str);
                            if (dt.Rows.Count == 0)
                            {
                                update = false;
                            }

                            if (update)
                            {
                                sqltopush += "'" + tag.GetText() + "' where quoteID = " + _quoteID + " And QuoteRevision = " + _revisionID + " And ItemID = " + itemID;

                                Query.Execute(sqltopush);
                            }
                            foreach (DataTable table2 in _dsQuoteData.Tables)
                            {
                                if (table2.TableName == strTable)
                                {
                                    foreach (DataRow row in table2.Rows)
                                    {
                                        if (row["ItemID"].ToString() == itemID.ToString(CultureInfo.InvariantCulture))
                                        {
                                            row[tagName] = tag.GetText();
                                        }
                                    }
                                }
                            }
                            tag.Close();



                            // LoadQuote();
                            RefreshBasketList();

                        }
                    }
                }
            }
        }

        private void sExtraReportsToolStrip_Click(object sender, EventArgs e)
        {

            if (lstBasket.SelectedItems.Count == 1)
            {
                ArrayList myItem = lstBasket.SelectedItems;
                string strTable = ((GlacialComponents.Controls.GLItem) myItem[0]).SubItems[1].Text;
                int intIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem) myItem[0]).SubItems[0].Text);
                int row = 0;
                int i;
                for (i = 0; i < _dsQuoteData.Tables[strTable].Rows.Count; i++)
                {
                    if (Convert.ToInt32(_dsQuoteData.Tables[strTable].Rows[i]["ItemID"].ToString()) == intIndex)
                    {
                        row = i;
                        i = _dsQuoteData.Tables[strTable].Rows.Count;
                    }
                }
                string model;
                switch (strTable)
                {
                    case "Evaporators":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["EvaporatorID"] + "-" + _dsQuoteData.Tables[strTable].Rows[row]["VoltageText"];
                        break;
                    case "Condensers":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["CondenserModel"].ToString();
                        break;
                    case "FluidCoolers":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["REFPLUS_FluidXRefModel"].ToString();
                        break;
                    case "QuickCoil":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["CoilModel"].ToString();
                        break;
                    case "CondensingUnit":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["Input_model"].ToString();
                        break;
                    case "QuickManualCoil":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["CoilModel"].ToString();
                        break;
                    case "HeatPipes":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["Model"].ToString();
                        break;
                    case "GravityCoils":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["Model"].ToString();
                        break;
                    case "CustomUnitTable":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["Description"].ToString();
                        break;
                    case "QuickWaterEvaporator":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["Input_Model"].ToString();
                        break;
                    case "OEMCoils":
                        model = _dsQuoteData.Tables[strTable].Rows[row]["Input_Model"].ToString();
                        break;
                    default:
                        model = "";
                        break;
                }
                var reports = new Report.FrmExtraReports( model);
                reports.ShowDialog();
            }
            else
            {
                Public.LanguageBox("You must have one unit selected to get the extra reports.","Vous devez avoir une unité de sélectionnée pour obtenir les rapports supplémentaires.");
            }
        
    }

        private void FrmQuotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quoteIsModified)
            {
                if (UserInformation.UserName == "strepanier")
                {
                    if (MessageBox.Show(
                    Public.LanguageString("Simon..... Still trying to close an unsaved quote!  Click OK to close quote, Cancel to go back and save it.",
                "Simon... tu fermes encore une soumission sans la saver!  ok pour fermer, annuler pour revenir"),
                Public.LanguageString("Closing", "Fermeture"), MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (MessageBox.Show(
                        Public.LanguageString("You changed your quotation and are now closing it without saving.  Are you sure you want to close?  (Ok to close, cancel to go back)",
                                "Vous avez modifié votre soumission et êtes présentement en train de la fermer sans la modifier.  Êtes-vous certain de vouloir fermer? (ok pour fermer, annuler pour revenir)"),
                                Public.LanguageString("Closing", "Fermeture"), MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }





    }

    class QuoteCoverPageData
    {
        public QuoteCoverPageData(string tag, string description, int quantity, decimal unitPrice, decimal totalPrice)
        {
            Tag = tag;
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public string Tag { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
    }
}