using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace RefplusWebtools.QuickGravityCoil
{
    public partial class FrmGravityCoil : Form
    {
        decimal _minCapacityResult;
        decimal _maxCapacityResult;

        DataTable _dtRecentSelection;
        readonly QuickGravityCoilCode _backgroundCode = new QuickGravityCoilCode();
        DataTable _dtGravityCoil;
        DataTable _dtSaveTable;

        private readonly List<string> _lstFileNames = new List<string>();
        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        private readonly string[] _strTableList = { "v_SelectGravityCoilModels", "GravityCoilCapacityPercentageMultipliers", "GravityCoilFaceTubes", "Drawings", "GravityCoil" };

        public FrmGravityCoil()
        {
            InitializeComponent();
        }

        public FrmGravityCoil(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;

        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void frmGravityCoil_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            Query.LoadTables(_strTableList);

            //fill all the combobox
            Fill_Combobox();

            //set defaults
            SetDefaults();

            if (_bolQuoteSelection && _intIndex != -1)
            {
                LoadSavedData();
            }

            ThreadProcess.Stop();
            Focus();
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void Fill_Combobox()
        {
            FillPercentageComboBoxes();
            FillFaceTubesComboBox();
            FillRefrigerant();
            FillModels();
        }

        private void SetDefaults()
        {
            ComboBoxControl.SetDefaultValue(cboFaceTubes, "ALL");
            ComboBoxControl.SetDefaultValue(cboMinCapacityPercentage, "5%");
            ComboBoxControl.SetDefaultValue(cboMaxCapacityPercentage, "10%");
            ComboBoxControl.SetDefaultValue(cboRefrigerant, "R-404A");
            ComboBoxControl.SetDefaultValue(cboSelection, "SELECTION");
            cboModel.SelectedIndex = 0;
        }

        private void LoadSavedData()
        {
            string strErrors = "";

            DataTable dtData = Public.SelectAndSortTable(_dsQuoteData.Tables["GravityCoils"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.GravityCoil) + " AND ItemID = " + _intIndex, "");
            DataRow drData = dtData.NewRow();
            drData.ItemArray = dtData.Rows[0].ItemArray;
            Decimal quantity = Convert.ToDecimal(drData["Quantity"].ToString());
            txtTag.Text = drData["Input_Tag"].ToString();
            numQuantity.Value = 1;
            if (Convert.ToDecimal(drData["CapacityInput"]) / Convert.ToDecimal(drData["Quantity"]) >= numCapacity.Minimum && Convert.ToDecimal(drData["CapacityInput"]) / Convert.ToDecimal(drData["Quantity"]) <= numCapacity.Maximum)
            {
                numCapacity.Value = Convert.ToDecimal(drData["CapacityInput"]) / Convert.ToDecimal(drData["Quantity"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select capacity (Your value is out of the new bounds)", "- Impossible de sélectionner la capacité (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (cboMinCapacityPercentage.FindString(drData["MinMultiplierInput"].ToString()) >= 0)
            {
                cboMinCapacityPercentage.SelectedIndex = cboMinCapacityPercentage.FindString(drData["MinMultiplierInput"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected minimum capacity mulitplier", "- Incapable de trouver le multiplicateur de capacité minimale") + Environment.NewLine;
            }

            if (cboMaxCapacityPercentage.FindString(drData["MaxMultiplierInput"].ToString()) >= 0)
            {
                cboMaxCapacityPercentage.SelectedIndex = cboMaxCapacityPercentage.FindString(drData["MaxMultiplierInput"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected maximum capacity mulitplier", "- Incapable de trouver le multiplier capacité maximale sélectionné") + Environment.NewLine;
            }

            if (cboRefrigerant.FindString(drData["RefrigerantInput"].ToString()) >= 0)
            {
                cboRefrigerant.SelectedIndex = cboRefrigerant.FindString(drData["RefrigerantInput"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Refrigerant", "- Incapable de trouver le Réfrigérant sélectionné") + Environment.NewLine;
            }

            if (cboFaceTubes.FindString(drData["FaceTubesInput"].ToString()) >= 0)
            {
                cboFaceTubes.SelectedIndex = cboFaceTubes.FindString(drData["FaceTubesInput"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected face tubes", "- Incapable de trouver le tubes par face sélectionné") + Environment.NewLine;
            }

            if (Convert.ToDecimal(drData["SSTInput"]) >= numSuctionTemp.Minimum && Convert.ToDecimal(drData["SSTInput"]) <= numSuctionTemp.Maximum)
            {
                numSuctionTemp.Value = Convert.ToDecimal(drData["SSTInput"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select suction temp. (Your value is out of the new bounds)", "- Impossible de sélectionner la temp. de succion (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (Convert.ToDecimal(drData["TDInput"]) >= numTD.Minimum && Convert.ToDecimal(drData["TDInput"]) <= numTD.Maximum)
            {
                numTD.Value = Convert.ToDecimal(drData["TDInput"]);
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot select TD (Your value is out of the new bounds)", "- Impossible de sélectionner la TD (Votre valeur est hors du nouvel intervalle)") + Environment.NewLine;
            }

            if (cboSelection.FindString(drData["SelectionInput"].ToString()) >= 0)
            {
                cboSelection.SelectedIndex = cboSelection.FindString(drData["SelectionInput"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Selection Type", "- Incapable de trouver le Type de Sélection sélectionné") + Environment.NewLine;
            }

            if (cboModel.FindString(drData["Model"].ToString()) >= 0)
            {
                cboModel.SelectedIndex = cboModel.FindString(drData["Model"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected model", "- Incapable de trouver le modèle sélectionné") + Environment.NewLine;
            }

            //run the selection
            ExecuteSelection();

            int recordIndex = -1;
            for (int i = 0; i < _dtRecentSelection.Rows.Count; i++)
            {
                if (_dtRecentSelection.Rows[i]["Model"].ToString() == drData["Model"].ToString())
                {
                    recordIndex = i;
                }
            }
            numQuantity.Value = quantity;
            if (strErrors == "" && recordIndex >= 0)
            {
                lvGravityCoil.Items[recordIndex].Selected = true;
                lvGravityCoil.Select();
                FillCoilCoating();
            }
            else
            {
                Public.LanguageBox("Selected model don't exist anymore for the actual inputs. Please contact Refplus if you need more information", "Le modèle que vous avez sélectionné n'est plus disponible pour les valeurs que vous avez. Veuillez contacter Refplus si vous avez besoin de plus d'information.");
            }

            if (cboCoilCoating.FindString(drData["CoilCoatingInput"].ToString()) >= 0)
            {
                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(drData["CoilCoatingInput"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected Coil Coating", "- Incapable de trouver le Revêtement du serpentin sélectionné") + Environment.NewLine;
            }

            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivantes sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FillPercentageComboBoxes()
        {
            DataTable dtPercentage = Public.DSDatabase.Tables["GravityCoilCapacityPercentageMultipliers"];
            for (int i = 0; i < dtPercentage.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboMinCapacityPercentage, i.ToString(CultureInfo.InvariantCulture), dtPercentage.Rows[i]["PercentageMultiplier"].ToString());
                ComboBoxControl.AddItem(cboMaxCapacityPercentage, i.ToString(CultureInfo.InvariantCulture), dtPercentage.Rows[i]["PercentageMultiplier"].ToString());
            }

        }

        private string FaceTubeParameter()
        {
            return ComboBoxControl.IndexInformation(cboFaceTubes);
        }

        private string RatingParameter()
        {
            return cboSelection.Text == @"RATING" ? ComboBoxControl.IndexInformation(cboModel) : "ALL";
        }

        private void FillFaceTubesComboBox()
        {
            cboFaceTubes.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each refrigerant
            foreach (DataRow drFaceTube in Public.DSDatabase.Tables["GravityCoilFaceTubes"].Rows)
            {
                string strIndex = drFaceTube["FaceTubesParameter"].ToString();
                string strText = drFaceTube["FaceTubes"].ToString();
                ComboBoxControl.AddItem(cboFaceTubes, strIndex, strText);
            }
        }

        private void FillCoilCoating()
        {
            cboCoilCoating.Items.Clear();
            ComboBoxControl.AddItem(cboCoilCoating, "None", "None");
            ComboBoxControl.AddItem(cboCoilCoating, "Blygold", "Blygold");
            ComboBoxControl.SetDefaultValue(cboCoilCoating, "None");
        }

        private void FillRefrigerant()
        {
            cboRefrigerant.Items.Clear();
            ComboBoxControl.AddItem(cboRefrigerant, "4", "R-404A");
            ComboBoxControl.AddItem(cboRefrigerant, "4", "R-507A");
        }

        private void FillModels()
        {
            cboModel.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            foreach (DataRow drModel in Public.DSDatabase.Tables["GravityCoil"].Rows)
            {
                string strIndex = drModel["Evaporator"] + "," + drModel["Gravity"] + "," + drModel["AirDefrost"] + "," + drModel["FaceTubes"] + "," + drModel["Slab"] + "," + drModel["FPI"] + "," + drModel["FinPattern"] + "," + drModel["FinLength"];
                string strText = drModel[UserInformation.CurrentSite + "_Model"].ToString();
                ComboBoxControl.AddItem(cboModel, strIndex, strText);
            }
        }

        private void cmdRunSelection_Click(object sender, EventArgs e)
        {
            lvGravityCoil.Columns[2].Text = Public.LanguageString("Capacity @" + numTD.Value + "ºFTD", "Capacité @" + numTD.Value + "ºFTD");
            ExecuteSelection();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void DisplayResults(DataTable dt)
        {
            int index = -1;
            decimal bestCapDiff = 100000000000m;
            lvGravityCoil.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var lvi = new ListViewItem(dt.Rows[i]["Model"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["FaceTubes"].ToString());
                lvi.SubItems.Add(Convert.ToDecimal(dt.Rows[i]["CurrentCapacity"]).ToString("N0") + " BTU/H");
                lvi.SubItems.Add(dt.Rows[i]["Height"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["Width"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["Depth"].ToString());
                lvi.SubItems.Add(Convert.ToDecimal(dt.Rows[i]["RefrigerantCharge"]).ToString("N0") + " LBS");
                lvi.SubItems.Add(Convert.ToDecimal(dt.Rows[i]["ShippingWeight"]).ToString("N0") + " LBS");
                lvGravityCoil.Items.Add(lvi);
                decimal capDiff = Convert.ToInt32(Math.Abs(Convert.ToDecimal(dt.Rows[i]["CurrentCapacity"].ToString()) - Convert.ToInt32(numCapacity.Value)));
                if (capDiff < bestCapDiff)
                {
                    bestCapDiff = capDiff;
                    index = i;
                }
            }
            lvGravityCoil.Refresh();
            lvGravityCoil.Items[index].Selected = true;
            lvGravityCoil.Select();
        }

        private void ExecuteSelection()
        {
            decimal minMultiplier = (Convert.ToDecimal(cboMinCapacityPercentage.Text.Substring(0, cboMinCapacityPercentage.Text.Length - 1))) / 100m;
            decimal maxMultiplier = (Convert.ToDecimal(cboMaxCapacityPercentage.Text.Substring(0, cboMaxCapacityPercentage.Text.Length - 1))) / 100m;

            _minCapacityResult = Convert.ToDecimal(numCapacity.Value) - (Convert.ToDecimal(numCapacity.Value) * minMultiplier);
            _maxCapacityResult = Convert.ToDecimal(numCapacity.Value) + (Convert.ToDecimal(numCapacity.Value) * maxMultiplier);

            //minCapacityResult = (minCapacityResult / 15) * numTD.Value;
            //maxCapacityResult = (maxCapacityResult / 15) * numTD.Value;

            _minCapacityResult = _minCapacityResult / numQuantity.Value;
            _maxCapacityResult = _maxCapacityResult / numQuantity.Value;

            //minCapacityResult = (minCapacityResult / numTD.Value) * 15;
            //maxCapacityResult = (maxCapacityResult / numTD.Value) * 15;

            _dtRecentSelection = _backgroundCode.RunSelection(Public.DSDatabase.Tables["v_SelectGravityCoilModels"], FaceTubeParameter(), _minCapacityResult, _maxCapacityResult, Convert.ToInt32(numCapacity.Value), Convert.ToInt32(numTD.Value), RatingParameter(), cboModel.Text);

            if (_dtRecentSelection.Rows.Count > 0)
            {
                DisplayResults(_dtRecentSelection);
                FillCoilCoating();
            }
            else
            {
                lvGravityCoil.Items.Clear();
                Public.LanguageBox("No results match your criteria. Please revise your search criteria.", "Aucun résultat ne correspond à vos critères. S'il vous plaît réviser vos critères de recherche.");
            }

        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (lvGravityCoil.SelectedItems.Count > 0)
            {
                if (_bolQuoteSelection)
                {
                    int newIndexToPush;
                    ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                    if (_intIndex != -1)
                    {
                        var savingoption = new FrmSavingOption();

                        ThreadProcess.Stop();
                        Focus();

                        if (savingoption.ShowDialog() == DialogResult.Yes)
                        {//if he want to overwrite

                            //it's a modification unit so we delete and recreate records
                            _quoteform.DeleteFromQuoteGravityCoil(_intIndex);
                            newIndexToPush = _intIndex;
                            _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.GravityCoil), newIndexToPush);
                            //Quoteform.DeleteFromQuoteAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.GravityCoil));
                        }
                        else
                        {
                            //since we actually always recreate the record
                            // save as new is simple, all i have to do is copy the additionnal items
                            //if reused the update function to instead duplicate record.
                            newIndexToPush = _quoteform.GetNextID("GravityCoils");
                            _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.GravityCoil), newIndexToPush);

                        }

                        ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                    }
                    else
                    {
                        newIndexToPush = _quoteform.GetNextID("GravityCoils");
                    }

                    AddToQuote(newIndexToPush);

                    _quoteform.RefreshBasketList();
                    _quoteform.SetQuoteIsModified(true);
                    ThreadProcess.Stop();
                    Focus();
                    Dispose();
                    //since even on update we need recreate the unit we will always add
                }
                else
                {
                    _lstFileNames.Clear();
                    ThreadProcess.Start(Public.LanguageString("Generating Report", "Création du rapport"));
                    //generate the report for non-quote also
                    //add if to check to either generate or
                    //save to quote
                    _dtSaveTable = GetSaveTable();
                    _lstFileNames.Add(GravityCoilReport.GenerateDataReport(_dtSaveTable, false, 0, ""));

                    for (int iGravityCoil = 0; iGravityCoil < _dtSaveTable.Rows.Count; iGravityCoil++)
                    {
                        string strDrawingName = DrawingManager.GetDrawingName(Public.DSDatabase.Tables["Drawings"], _dtSaveTable.Rows[iGravityCoil]["Model"].ToString());
                        if (strDrawingName != "")
                        {
                            byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS");
                            if (bfile != null)
                            {
                                string strDrawingFileLocation = DrawingManager.SaveDrawingToDisk(bfile, strDrawingName);
                                if (strDrawingFileLocation != "")
                                {
                                    _lstFileNames.Add(strDrawingFileLocation);
                                }
                            }
                        }
                    }
                    MergeReport(_lstFileNames, "");
                    //CreateReport();
                    ThreadProcess.Stop();
                    Focus();
                }
            }
        }

        private void AddToQuote(int itemID)
        {
            _dtSaveTable = GetSaveTable();
            _intIndex = _quoteform.GetNextID("GravityCoils");
            _dtSaveTable.Rows[0]["ItemID"] = itemID;
            _dsQuoteData.Tables["GravityCoils"].Rows.Add(_dtSaveTable.Rows[0].ItemArray);

            DataTable copy = _dsQuoteData.Tables["GravityCoils"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["GravityCoils"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["GravityCoils"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Input_Tag"], row["Quantity"], row["Description"], row["CapacityInput"], row["MinMultiplierInput"], row["MaxMultiplierInput"], row["FaceTubesInput"], row["RefrigerantInput"], row["CoilCoatingInput"], row["SSTInput"], row["TDInput"], row["SelectionInput"], row["Model"], row["Evaporator"], row["Gravity"], row["AirDefrost"], row["FaceTubes"], row["Slab"], row["FPI"], row["FinPattern"], row["FinLength"], row["Capacity"], row["ListPrice"], row["CoatingPrice"], row["Depth"], row["Height"], row["Width"], row["RefrigerantCharge"], row["ShippingWeight"], row["SuctionTemp"], row["CapacityPerTD"], row["ApprovalDrawing"]);
            }
        }

        private DataTable GetSaveTable()
        {
            _dtGravityCoil = Tables.DtGravityCoil();
            DataRow[] dtData = Public.DSDatabase.Tables["v_SelectGravityCoilModels"].Copy().Select("Model = '" + lvGravityCoil.SelectedItems[0].Text + "'");

            DataRow drSaveTable = _dtGravityCoil.NewRow();
            //header
            drSaveTable["QuoteID"] = 0;
            drSaveTable["QuoteRevision"] = 0;
            drSaveTable["QuoteRevisionText"] = "";
            drSaveTable["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.GravityCoil);
            drSaveTable["ItemID"] = 0;
            drSaveTable["Username"] = "";

            drSaveTable["Input_Tag"] = txtTag.Text;
            drSaveTable["Quantity"] = 1;

            drSaveTable["CapacityInput"] = Convert.ToInt32(numCapacity.Value);
            drSaveTable["MinMultiplierInput"] = cboMinCapacityPercentage.Text;
            drSaveTable["MaxMultiplierInput"] = cboMaxCapacityPercentage.Text;
            drSaveTable["FaceTubesInput"] = cboFaceTubes.Text;
            drSaveTable["RefrigerantInput"] = cboRefrigerant.Text;
            drSaveTable["CoilCoatingInput"] = cboCoilCoating.Text;
            drSaveTable["SSTInput"] = Convert.ToInt32(numSuctionTemp.Value);
            drSaveTable["TDInput"] = Convert.ToInt32(numTD.Value);
            drSaveTable["SelectionInput"] = cboSelection.Text;
            drSaveTable["Model"] = dtData[0]["Model"];
            drSaveTable["Evaporator"] = dtData[0]["Evaporator"];
            drSaveTable["Gravity"] = dtData[0]["Gravity"];
            drSaveTable["AirDefrost"] = dtData[0]["AirDefrost"];
            drSaveTable["FaceTubes"] = Convert.ToInt32(dtData[0]["FaceTubes"].ToString());
            drSaveTable["Slab"] = Convert.ToInt32(dtData[0]["Slab"].ToString());
            drSaveTable["FPI"] = dtData[0]["FPI"];
            drSaveTable["FinPattern"] = dtData[0]["FinPattern"];
            drSaveTable["FinLength"] = Convert.ToInt32(dtData[0]["FinLength"].ToString());
            drSaveTable["Capacity"] = Convert.ToInt32(dtData[0]["Capacity"].ToString());
            drSaveTable["ListPrice"] = Convert.ToDecimal(dtData[0]["FPIListPrice"].ToString());
            drSaveTable["CoatingPrice"] = cboCoilCoating.Text == @"None" ? 0m : Convert.ToDecimal(dtData[0]["BlygoldCoating"].ToString());
            drSaveTable["Depth"] = Convert.ToInt32(dtData[0]["Depth"].ToString());
            drSaveTable["Height"] = dtData[0]["Height"];
            drSaveTable["Width"] = dtData[0]["Width"];
            drSaveTable["RefrigerantCharge"] = Convert.ToDecimal(dtData[0]["RefrigerantCharge"].ToString());
            drSaveTable["ShippingWeight"] = Convert.ToInt32(dtData[0]["ShippingWeight"].ToString());
            drSaveTable["SuctionTemp"] = Convert.ToInt32(numSuctionTemp.Value);
            drSaveTable["CapacityPerTD"] = Convert.ToDecimal(dtData[0]["CapacityPerTD"].ToString());

            //2012-05-23 : #1355 : adding dwg name on all reports
            string strDrawingName = DrawingManager.GetDrawingName(DrawingManager.DrawingCategory.GravityCoil, drSaveTable["Model"].ToString());
            drSaveTable["ApprovalDrawing"] = strDrawingName;

            //fill the description
            drSaveTable["Description"] = "Gravity Coil: " + lvGravityCoil.SelectedItems[0].Text;

            _dtGravityCoil.Rows.Add(drSaveTable);

            return _dtGravityCoil;
        }

        private void MergeReport(List<string> lstFileNames, string coverPageFile)
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
                string strMergeReportLocation = Public.GenerateFileNameAndPath("SpecReport", "pdf");

                //Merge and create the file
                pdf.Merge(strMergeReportLocation);

                //open up the file
                System.Diagnostics.Process.Start(strMergeReportLocation);
            }
        }

        private void cboSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelection.Text == @"SELECTION")
            {
                cboModel.Enabled = false;
                cboFaceTubes.Enabled = true;
                numCapacity.Enabled = true;
                cboMinCapacityPercentage.Enabled = true;
                cboMaxCapacityPercentage.Enabled = true;
            }
            else
            {
                cboModel.Enabled = true;
                cboFaceTubes.Enabled = false;
                numCapacity.Enabled = false;
                cboMinCapacityPercentage.Enabled = false;
                cboMaxCapacityPercentage.Enabled = false;
            }
        }

        private void frmGravityCoil_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }
    }
}