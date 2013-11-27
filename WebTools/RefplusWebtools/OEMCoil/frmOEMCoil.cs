using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.OEMCoil
{
    public partial class FrmOEMCoil : Form
    {
        private OEMCoilFormat _oemcoil;

        private readonly OEMCode _backgroundCode = new OEMCode();

        private readonly string[] _strTableList = { "v_CoilCasingMaterialDefaults", "CoilCasingThickness", "v_CoilFinDefaults", "CoilFinMaterial", "CoilfinThickness", "CoilTubeMaterial", "v_CoilTubeDefaults", "CoilTubeThickness", "HeaderInformation", "FlareFittings", "MaterialInformation", "Distributor", "PricingCoilSetup", "OEMProfitMarginsWithPermission", "OEMProfitMargins" };

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        private DataRow _drSavedInfo;
        private DataTable _dtSavedInfo;
        private string _strErrors;

        private bool _modelChanged;
        private bool _importantAttributeChanged;
        private bool _connectionCountChanged;
        private bool _secondTabChanged;
        private bool _thirdTabChanged;
        private bool _fourthTabChanged;
        private bool _fifthTabChanged;

        Pricing.OEMCoilPricing _oemPricing;

        //table used for saving
        DataTable _dtOEMCoil;
        DataTable _dtOEMCoilConnection;
        DataTable _dtOEMCoilFlareFitting;
        DataTable _dtOEMCoilDistributors;
        DataTable _dtOEMCoilPrice;

        public FrmOEMCoil()
        {
            InitializeComponent();
        }

        public FrmOEMCoil(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;
            _modelChanged = false;
            _connectionCountChanged = false;
            _importantAttributeChanged = false;
            _secondTabChanged = false;
            _thirdTabChanged = false;
            _fourthTabChanged = false;
            _fifthTabChanged = false;
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void frmOEMCoil_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
            Query.LoadTables(_strTableList);


            tabOEMCoil.TabPages.Remove(tabMaterial);
            tabOEMCoil.TabPages.Remove(tabBendsCasingAndConnections);
            tabOEMCoil.TabPages.Remove(tabOptions);
            tabOEMCoil.TabPages.Remove(tabPricing);


            if (_bolQuoteSelection && _intIndex != -1)
            {
                ThreadProcess.UpdateMessage(Public.LanguageString("Loading saved data", "Chargement des données"));
                LoadSavedData();
            }

            if (UserInformation.UserName == "jblanchard" || UserInformation.UserName == "pvoutsinas" ||
                UserInformation.UserName == "mcardinal")
            {
                chkOverhead.Visible = true;
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

        private void LoadSavedData()
        {
            //will contain all errors
            _strErrors = "";

            _dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoils"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil).ToString(CultureInfo.InvariantCulture) + " AND ItemID = " + _intIndex.ToString(CultureInfo.InvariantCulture), "");
            _drSavedInfo = _dtSavedInfo.NewRow();
            _drSavedInfo.ItemArray = _dtSavedInfo.Rows[0].ItemArray;

            //First tab
            txtCoilModel.Text = _drSavedInfo["Input_Model"].ToString();
            txtTag.Text = _drSavedInfo["Input_Tag"].ToString();
            txtCustomerDrawingNumber.Text = _drSavedInfo["Input_CustomerDrawingNumber"].ToString();
            txtRefplusDrawingNo.Text = _drSavedInfo["Input_RefplusDrawingNumber"].ToString();

            //Validate normally and go next tab
            NextMaterial();

            //Second tab
            ValidateSecondTab();

            if (_strErrors == "")
            {
                //Validate normally and go to next tab
                NextBendsCasingAndConnections();

                //Third tab
                ValidateThirdTab();

                if (_strErrors == "")
                {
                    NextOptions();

                    ValidateFourthTab();
                }
                if (_strErrors == "")
                {
                    NextPricing();
                    ValidateFifthTab();
                }
            }
            tabOEMCoil.TabPages.Remove(tabPricing);
            tabOEMCoil.TabPages.Add(tabModel);
            _importantAttributeChanged = false;
            _modelChanged = false;
            _connectionCountChanged = false;
            if (_strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivante(s) sont survenue(s) lors du chargement") + Environment.NewLine + _strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tmMoreOption_Tick(object sender, EventArgs e)
        {
            if (lblAnchor.Top > pnlOptions.Height)
            {

            }
        }

        private bool IsCoilValid()
        {
            bool coilValid = false;

            _oemcoil = new OEMCoilFormat(txtCoilModel.Text);

            if (_oemcoil.IsValid())
            {
                txtCoilModel.Text = _oemcoil.Model;
                coilValid = true;
            }
            else
            {
                Public.LanguageBox("An error occured while validating the coil model see below for more detail." + Environment.NewLine + _oemcoil.Errors, "Un erreur est survenue lors de la validation du modèle du serpentin.  Voir raison ci-dessous." + Environment.NewLine + _oemcoil.Errors);
            }

            return coilValid;
        }

        private void PricingValidation()
        {
            Fill_CoilComplexity();

            Fill_ProfitMargin();

            Fill_PricingList();

            cboCoilComplexity.SelectedIndex = 0;
            cboProfitMargin.SelectedIndex = UserInformation.AccessQuoteOEMCoilProfitMargin ? cboProfitMargin.FindString("30") : 0;
        }

        private void Fill_ProfitMargin()
        {
            cboProfitMargin.Items.Clear();

            DataTable dtProfits = Public.SelectAndSortTable(UserInformation.AccessQuoteOEMCoilProfitMargin ? Public.DSDatabase.Tables["OEMProfitMarginsWithPermission"] : Public.DSDatabase.Tables["OEMProfitMargins"], "", "Profit");

            foreach (DataRow drProfit in dtProfits.Rows)
            {
                if (chkOverhead.Checked && Convert.ToDecimal(drProfit["Profit"].ToString()) >21m)
                {
                    ComboBoxControl.AddItem(cboProfitMargin, (Convert.ToDecimal(drProfit["Profit"]) + 100m).ToString(CultureInfo.InvariantCulture), drProfit["Profit"].ToString());
                }
                else if (!chkOverhead.Checked)
                {
                    ComboBoxControl.AddItem(cboProfitMargin, (Convert.ToDecimal(drProfit["Profit"]) + 100m).ToString(CultureInfo.InvariantCulture), drProfit["Profit"].ToString());
                }
            }

        }

        private void Fill_PricingList()
        {
            lstPrice.Items.Clear();
            lstPrice.Items.Add(GetPricingListItem(1, 2));
            lstPrice.Items.Add(GetPricingListItem(3, 4));
            lstPrice.Items.Add(GetPricingListItem(5, 9));
            lstPrice.Items.Add(GetPricingListItem(10, 14));
            lstPrice.Items.Add(GetPricingListItem(15, 19));
            lstPrice.Items.Add(GetPricingListItem(20, 29));
            lstPrice.Items.Add(GetPricingListItem(30, 49));
            lstPrice.Items.Add(GetPricingListItem(50, 74));
            lstPrice.Items.Add(GetPricingListItem(75, 100));
            lstPrice.Refresh();
        }

        private GlacialComponents.Controls.GLItem GetPricingListItem(int @from, int to)
        {
            var myItem = new GlacialComponents.Controls.GLItem(lstPrice);

            myItem.SubItems[0].Control = GetPriceFromToNumericUpDown(@from);
            myItem.SubItems[1].Text = Public.LanguageString("to", "à");
            myItem.SubItems[2].Control = GetPriceFromToNumericUpDown(to);
            myItem.SubItems[3].Text = "0.00 $";

            return myItem;
        }

        private NumericUpDown GetPriceFromToNumericUpDown(decimal value)
        {
            var num = new NumericUpDown
            {
                Minimum = 1m,
                Maximum = 100m,
                DecimalPlaces = 0,
                Value = value,
                TextAlign = HorizontalAlignment.Center,
                Enabled = false,
                BackColor = Color.White,
                ForeColor = Color.Black
            };


            num.ValueChanged += numPriceFromTo_ValueChanged;
            return num;
        }

        private void numPriceFromTo_ValueChanged(object sender, EventArgs e)
        {
            PriceCoil();
        }

        private void Fill_CoilComplexity()
        {
            cboCoilComplexity.Items.Clear();

            foreach (DataRow drComplexity in Public.DSDatabase.Tables["PricingCoilSetup"].Rows)
            {
                ComboBoxControl.AddItem(cboCoilComplexity, drComplexity["Value"].ToString(), drComplexity["Setup"].ToString());
            }
        }

        private void MaterialClear()
        {
            cboCasingMaterial.Items.Clear();
            cboCasingThickness.Items.Clear();
            cboFinMaterial.Items.Clear();
            cboFinThickness.Items.Clear();
            cboTubeMaterial.Items.Clear();
            cboTubeThickness.Items.Clear();
        }

        private void MaterialValidation()
        {
            MaterialClear();
            Fill_CasingMaterial();
            Fill_FinMaterial();
            Fill_TubeMaterial();
        }

        private void ReturnBendsCasingConnectionClear()
        {
            numReturnBends.Value = 0m;

            numEndPlate.Value = 2m;
            numEndPlateHeight.Value = 0m;
            numEndPlateWidth.Value = 0m;

            numTopPlate.Value = 1m;
            numTopPlateHeight.Value = 0m;
            numTopPlateWidth.Value = 0m;

            numBottomPlate.Value = 1m;
            numBottomPlateHeight.Value = 0m;
            numBottomPlateWidth.Value = 0m;

            numCenterPlate.Value = 1m;
            numCenterPlateHeight.Value = 0m;
            numCenterPlateWidth.Value = 0m;

            cboWeldedCasing.Items.Clear();

            lstConnections.Items.Clear();
        }

        private void ReturnBendsCasingConnectionValidation()
        {
            ReturnBendsCasingConnectionClear();

            numReturnBends.Value = _backgroundCode.GetReturnBendsQty(_oemcoil.FinType, _oemcoil.FaceTubes, _oemcoil.Rows, cboFinMaterial.Text, _oemcoil.FinLength);

            numEndPlate.Value = 2m;
            numEndPlateHeight.Value = _backgroundCode.GetDefaultEndPlateHeight(_oemcoil.FinHeight);
            numEndPlateWidth.Value = _backgroundCode.GetDefaultEndPlateWidth(_oemcoil.TubeRow, _oemcoil.Rows);

            numTopPlate.Value = 1m;
            numTopPlateHeight.Value = _backgroundCode.GetDefaultTopAndBottomPlateHeight(_oemcoil.FinLength);
            numTopPlateWidth.Value = _backgroundCode.GetDefaultTopAndBottomPlateWidth(_oemcoil.TubeRow, _oemcoil.Rows);

            numBottomPlate.Value = 1m;
            numBottomPlateHeight.Value = _backgroundCode.GetDefaultTopAndBottomPlateHeight(_oemcoil.FinLength);
            numBottomPlateWidth.Value = _backgroundCode.GetDefaultTopAndBottomPlateWidth(_oemcoil.TubeRow, _oemcoil.Rows);

            numCenterPlate.Value = 1m;
            numCenterPlateHeight.Value = _backgroundCode.GetDefaultCenterPlateHeight(_oemcoil.FinHeight);
            numCenterPlateWidth.Value = _backgroundCode.GetDefaultCenterPlateWidth(_oemcoil.TubeRow, _oemcoil.Rows);

            Fill_WeldedCasing();
        }

        private void Fill_WeldedCasing()
        {
            cboWeldedCasing.Items.Clear();

            ComboBoxControl.AddItem(cboWeldedCasing, "0", "NO");
            ComboBoxControl.AddItem(cboWeldedCasing, "1", "YES");
        }

        private ComboBox GetHeaderCombobox()
        {
            var cbo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

            foreach (DataRow drHeader in Public.DSDatabase.Tables["HeaderInformation"].Rows)
            {
                ComboBoxControl.AddItem(cbo, drHeader["CopperHeaderDiameter"].ToString(), drHeader["CopperHeaderDiameter"].ToString());
            }

            return cbo;
        }

        private NumericUpDown GetHeaderLengthNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 400m,
                DecimalPlaces = 3,
                Value = _backgroundCode.GetHeaderLength(_oemcoil.FinHeight),
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private bool OptionsValidateInputs()
        {
            bool valid = true;
            string strErrors = "";

            if (pnlFlareFittings.Visible && cboFlareFittings.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select flare fittings option.", "Vous devez choisir une option de raccord pour tube évasé.") + Environment.NewLine;
            }

            if (pnlFlareFittingsOptions.Visible)
            {
                for (int i = 0; i < lstFlareFittings.Items.Count; i++)
                {
                    if (((NumericUpDown)lstFlareFittings.Items[i].SubItems[0].Control).Value == 0m)
                    {
                        valid = false;
                        strErrors += Public.LanguageString("You must select quantity of flare fittings for connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".", "Vous devez choisir une quantité de raccords pour tube évasé pour la connexion #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".") + Environment.NewLine;
                    }

                    if ((lstFlareFittings.Items[i].SubItems[1].Control).Text == "")
                    {
                        valid = false;
                        strErrors += Public.LanguageString("You must select the type of flare fittings for connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".", "Vous devez choisir le type de raccord pour tube évasé pour la connexion #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".") + Environment.NewLine;
                    }

                    if ((lstFlareFittings.Items[i].SubItems[2].Control).Text == "")
                    {
                        valid = false;
                        strErrors += Public.LanguageString("You must select the model of flare fittings for connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".", "Vous devez choisir le modèle de raccord pour tube évasé pour la connexion #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".") + Environment.NewLine;
                    }
                }
            }

            if (pnlDistributor.Visible && cboDistributors.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select distributor option.", "Vous devez choisir une option de distributeur.") + Environment.NewLine;
            }

            if (pnlDistributorOptions.Visible)
            {
                for (int i = 0; i < lstDistributor.Items.Count; i++)
                {
                    if (((NumericUpDown)lstDistributor.Items[i].SubItems[0].Control).Value == 0m)
                    {
                        valid = false;
                        strErrors += Public.LanguageString("You must select quantity of circuit for connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".", "Vous devez choisir une quantité de circuits pour la connexion #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".") + Environment.NewLine;
                    }

                    if (lstDistributor.Items[i].SubItems[3].Control.Text == "")
                    {
                        valid = false;
                        strErrors += Public.LanguageString("You must select the distributor manufacturer for connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".", "Vous devez choisir le manufacturier du distributeur pour la connexion #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".") + Environment.NewLine;
                    }

                    if ((lstDistributor.Items[i].SubItems[4].Control).Text == "")
                    {
                        valid = false;
                        strErrors += Public.LanguageString("You must select the model of distributor for connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".", "Vous devez choisir le modèle de distributeur pour la connexion #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture) + ".") + Environment.NewLine;
                    }
                }
            }

            if (pnlAuxiliarySideConnection.Visible && cboAuxiliarySideConnection.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select auxiliary side connection option.", "Vous devez choisir une option de connexion côté auxiliaires.") + Environment.NewLine;
            }

            if (pnlWeldNut.Visible && cboWeldNut.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select auxiliary side connection option.", "Vous devez choisir une option de connexion côté auxiliaires.") + Environment.NewLine;
            }

            if (pnlWeldNutOptions.Visible)
            {
                if (numWeldNutQuantity.Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must enter a quantity of welded nuts.", "Vous devez choisir une quantité d'écrous soudés.") + Environment.NewLine;
                }
            }

            if (pnlDrainPan.Visible && cboDrainPan.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select drain pan option.", "Vous devez choisir une option d'égouttoir.") + Environment.NewLine;
            }

            if (pnlDrainPanOptions.Visible)
            {
                if (((NumericUpDown)lstDrainPan.Items[0].SubItems[0].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select quantity of drain pan.", "Vous devez choisir une quantité d'égouttoirs.") + Environment.NewLine;
                }

                if ((lstDrainPan.Items[0].SubItems[1].Control).Text == "")
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select the drain pan material.", "Vous devez choisir le matériau de l'égouttoir.") + Environment.NewLine;
                }

                if (((NumericUpDown)lstDrainPan.Items[0].SubItems[2].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select the height of drain pan.", "Vous devez choisir la hauteur de l'égouttoir.") + Environment.NewLine;
                }

                if (((NumericUpDown)lstDrainPan.Items[0].SubItems[3].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select the width of drain pan.", "Vous devez choisir la largeur de l'égouttoir.") + Environment.NewLine;
                }
            }

            if (pnlDamper.Visible && cboDamper.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select damper option.", "Vous devez choisir une option de régulateur.") + Environment.NewLine;
            }

            if (pnlDamperOptions.Visible)
            {
                if (((NumericUpDown)lstDamper.Items[0].SubItems[0].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select quantity of damper.", "Vous devez choisir une quantité de régulateurs.") + Environment.NewLine;
                }

                if (((NumericUpDown)lstDamper.Items[0].SubItems[1].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select the height of damper.", "Vous devez choisir la hauteur du régulateur.") + Environment.NewLine;
                }

                if (((NumericUpDown)lstDamper.Items[0].SubItems[2].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select the width of damper.", "Vous devez choisir la largeur du régulateur.") + Environment.NewLine;
                }
            }

            if (pnlSpecialCustomFitting.Visible && cboSpecialCustomFitting.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select special custom fittings option.", "Vous devez choisir une option de raccord spécial personalisé.") + Environment.NewLine;
            }

            if (pnlSpecialCustomFittingOptions.Visible)
            {
                if (lstSpecialCustomFitting.Items[0].SubItems[0].Text == "")
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must enter special custom fittings descriptionr.", "Vous devez entrer une description du raccord spécial personalisé.") + Environment.NewLine;
                }

                if (((NumericUpDown)lstSpecialCustomFitting.Items[0].SubItems[1].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select the estimated cost of the special custom fittings.", "Vous devez entrer le prix estimé du raccord spécial personalisé.") + Environment.NewLine;
                }

            }

            if (pnlThreadedConnections.Visible && cboThreadedConnections.Text == "")
            {
                valid = false;
                strErrors += Public.LanguageString("You must select threaded connection option.", "Vous devez choisir une option de raccord fileté.") + Environment.NewLine;
            }

            if (pnlThreadedConnectionsOptionsNo.Visible)
            {
                if (((NumericUpDown)lstThreadedConnectionNo.Items[0].SubItems[0].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select quantity of spigot.", "Vous devez choisir une quantité de robinets.") + Environment.NewLine;
                }
            }

            if (pnlThreadedConnectionsOptionsYes.Visible)
            {
                if (((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[0].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select quantity of threaded connection.", "Vous devez choisir une quantité de raccords filetés.") + Environment.NewLine;
                }

                if ((lstThreadedConnectionYes.Items[0].SubItems[1].Control).Text == "")
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select the threaded connection diameter.", "Vous devez choisir le diamètre du raccord fileté.") + Environment.NewLine;
                }

                if (((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[2].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select quantity of vents.", "Vous devez choisir une quantité d'évents.") + Environment.NewLine;
                }

                if (((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[3].Control).Value == 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must select quantity of spigot.", "Vous devez choisir une quantité de robinets.") + Environment.NewLine;
                }
            }

            if (!valid)
            {
                MessageBox.Show(strErrors);
            }

            return valid;
        }

        private bool ReturnBendsCasingConnectionValidateInputs()
        {
            bool valid = true;
            string strErrors = "";

            //validate welded casing
            if (cboWeldedCasing.SelectedIndex == -1)
            {
                valid = false;
                strErrors += Public.LanguageString("You must select welded casing option.", "Vous devez choisir une option de soudage du boîter.") + Environment.NewLine;
            }

            //validate for return bends
            if (numReturnBends.Value < 1m)
            {
                valid = false;
                strErrors += Public.LanguageString("You must have at least 1 return bend.", "Vous devez avoir au moins 1 coude de retour.") + Environment.NewLine;
            }

            //validate if header properly filled
            for (int itemindex = 0; itemindex < lstConnections.Items.Count; itemindex++)
            {
                bool errorOnConnection = false;

                if (((ComboBox)lstConnections.Items[itemindex].SubItems[0].Control).SelectedIndex == -1)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You forgot to pick a header diameter on one or more connection.", "Vous avez oublié de choisir le diamètre d'une ou plusieurs des connexions.") + Environment.NewLine;
                    errorOnConnection = true;
                }

                if (((NumericUpDown)lstConnections.Items[itemindex].SubItems[1].Control).Value <= 0m)
                {
                    valid = false;
                    strErrors += Public.LanguageString("Header Length must be greater than 0.", "La longueur des connexions doit être plus grande que 0.") + Environment.NewLine;
                    errorOnConnection = true;
                }

                if (errorOnConnection)
                {
                    itemindex = lstConnections.Items.Count;
                }
            }

            //validate quantity of headers

            if (_oemcoil.CoilType == "W" || _oemcoil.CoilType == "B" || _oemcoil.CoilType == "S" || _oemcoil.CoilType == "N")
            {
                //min 2 connections
                if (lstConnections.Items.Count < 2)
                {
                    valid = false;
                    strErrors += Public.LanguageString("You must have a minimum of 2 headers.", "Vous devez avoir un minimum de 2 connexions.") + Environment.NewLine;
                }
            }

            //validate water coil that must have same header size
            if (_oemcoil.CoilType == "W" || _oemcoil.CoilType == "B")
            {
                //same header size
                for (int itemindex = 0; itemindex < lstConnections.Items.Count; itemindex++)
                {
                    if ((lstConnections.Items[itemindex].SubItems[0].Control).Text != lstConnections.Items[0].SubItems[0].Control.Text)
                    {
                        valid = false;
                        strErrors += Public.LanguageString("All headers must be of same size.", "Toutes les connexions doivent être de dimension identique.") + Environment.NewLine;
                        itemindex = lstConnections.Items.Count;
                    }
                }
            }

            if (!valid)
            {
                MessageBox.Show(strErrors);
            }

            return valid;
        }

        private void SetAllOptionsPanelInvisible()
        {
            pnlFlareFittings.Visible = false;
            pnlFlareFittingsOptions.Visible = false;
            pnlDistributor.Visible = false;
            pnlDistributorOptions.Visible = false;
            pnlAuxiliarySideConnection.Visible = false;
            pnlWeldNut.Visible = false;
            pnlWeldNutOptions.Visible = false;
            pnlDrainPan.Visible = false;
            pnlDrainPanOptions.Visible = false;
            pnlDamper.Visible = false;
            pnlDamperOptions.Visible = false;
            pnlSpecialCustomFitting.Visible = false;
            pnlSpecialCustomFittingOptions.Visible = false;
            pnlThreadedConnections.Visible = false;
            pnlThreadedConnectionsOptionsNo.Visible = false;
            pnlThreadedConnectionsOptionsYes.Visible = false;
        }

        private void OptionsClear()
        {
            pnlFlareFittings.Visible = false;
            cboFlareFittings.Items.Clear();
            pnlFlareFittingsOptions.Visible = false;
            lstFlareFittings.Items.Clear();
            lstFlareFittings.Refresh();

            pnlDistributor.Visible = false;
            cboDistributors.Items.Clear();
            pnlDistributorOptions.Visible = false;
            lstDistributor.Items.Clear();
            lstDistributor.Refresh();

            pnlAuxiliarySideConnection.Visible = false;
            cboAuxiliarySideConnection.Items.Clear();

            pnlWeldNut.Visible = false;
            cboWeldNut.Items.Clear();
            pnlWeldNutOptions.Visible = false;
            numWeldNutQuantity.Value = 0m;

            pnlDrainPan.Visible = false;
            cboDrainPan.Items.Clear();
            pnlDrainPanOptions.Visible = false;
            lstDrainPan.Items.Clear();
            lstDrainPan.Refresh();

            pnlDamper.Visible = false;
            cboDamper.Items.Clear();
            pnlDamperOptions.Visible = false;
            lstDamper.Items.Clear();
            lstDamper.Refresh();

            pnlSpecialCustomFitting.Visible = false;
            cboSpecialCustomFitting.Items.Clear();
            pnlSpecialCustomFittingOptions.Visible = false;
            lstSpecialCustomFitting.Items.Clear();
            lstSpecialCustomFitting.Refresh();

            pnlThreadedConnections.Visible = false;
            cboThreadedConnections.Items.Clear();
            pnlThreadedConnectionsOptionsNo.Visible = false;
            lstThreadedConnectionNo.Items.Clear();
            lstThreadedConnectionNo.Refresh();
            pnlThreadedConnectionsOptionsYes.Visible = false;
            lstThreadedConnectionYes.Items.Clear();
            lstThreadedConnectionYes.Refresh();
        }

        private void Fill_FlareFittings()
        {
            cboFlareFittings.Items.Clear();

            ComboBoxControl.AddItem(cboFlareFittings, "0", "NO");
            ComboBoxControl.AddItem(cboFlareFittings, "1", "YES");
        }

        private void Fill_FlareFittingsOptions()
        {
            lstFlareFittings.Items.Clear();

            //there is 1 item by default since sometime you can have NO connections
            var myItem = new GlacialComponents.Controls.GLItem(lstFlareFittings);

            myItem.SubItems[0].Control = GetFlareFittingQuantityNumericUpDown();
            //i do pass 0 as parameter below in case there is actually connection so
            //the control can point out to index 0 of the connection list.
            myItem.SubItems[1].Control = GetFlareFittingTypeCombobox(0);
            myItem.SubItems[2].Control = GetFlareFittingModelCombobox(0);

            lstFlareFittings.Items.Add(myItem);

            //for each connection subsequent we add them
            for (int i = 1; i < lstConnections.Items.Count; i++)
            {
                var myOtherItem = new GlacialComponents.Controls.GLItem(lstFlareFittings);

                myOtherItem.SubItems[0].Control = GetFlareFittingQuantityNumericUpDown();
                myOtherItem.SubItems[1].Control = GetFlareFittingTypeCombobox(i);
                myOtherItem.SubItems[2].Control = GetFlareFittingModelCombobox(i);

                lstFlareFittings.Items.Add(myOtherItem);
            }

            lstFlareFittings.Refresh();
        }

        private NumericUpDown GetFlareFittingQuantityNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                TextAlign = HorizontalAlignment.Center
            };

            int intNumberOfHeader = GetNumberOfHeaders();
            num.Value = (intNumberOfHeader == 0 ? 2m : intNumberOfHeader);
            return num;
        }

        private int GetNumberOfHeaders()
        {
            //straight how vb6 works.
            //noticed the header in flex grid count as a row
            //so when vb6 say = row - 1 the result will be 4 when
            //4 connection are there because there is actually 5 rows
            //since it count the header as 1
            return GetNumberOfConnections();
        }

        private int GetNumberOfConnections()
        {
            return lstConnections.Items.Count;
        }

        private void PanelValidation(object sender)
        {
            //this will validate what panel visible when and the location of each of them
            SetAllOptionsPanelInvisible();

            pnlOptions.AutoScroll = false;

            switch (_oemcoil.CoilType)
            {
                case "W":
                case "B":
                case "S":
                case "N":
                    pnlThreadedConnections.Visible = true;
                    pnlThreadedConnections.Top = 0;

                    if (cboThreadedConnections.Text == @"YES")
                    {
                        pnlThreadedConnectionsOptionsYes.Visible = true;
                        pnlThreadedConnectionsOptionsYes.Top = pnlThreadedConnections.Bottom;
                    }
                    else if (cboThreadedConnections.Text == @"NO")
                    {
                        pnlThreadedConnectionsOptionsNo.Visible = true;
                        pnlThreadedConnectionsOptionsNo.Top = pnlThreadedConnections.Bottom;
                    }

                    pnlFlareFittings.Visible = true;

                    if (pnlThreadedConnectionsOptionsNo.Visible || pnlThreadedConnectionsOptionsYes.Visible)
                    {
                        pnlFlareFittings.Top = (pnlThreadedConnectionsOptionsNo.Visible ? pnlThreadedConnectionsOptionsNo.Bottom : pnlThreadedConnectionsOptionsYes.Bottom);
                    }
                    else
                    {
                        pnlFlareFittings.Top = pnlThreadedConnections.Bottom;
                    }

                    if (cboFlareFittings.Text == @"YES")
                    {
                        pnlFlareFittingsOptions.Visible = true;
                        pnlFlareFittingsOptions.Top = pnlFlareFittings.Bottom;
                    }

                    pnlWeldNut.Visible = true;
                    pnlWeldNut.Top = (pnlFlareFittingsOptions.Visible ? pnlFlareFittingsOptions.Bottom : pnlFlareFittings.Bottom);

                    if (cboWeldNut.Text == @"YES")
                    {
                        pnlWeldNutOptions.Visible = true;
                        pnlWeldNutOptions.Top = pnlWeldNut.Bottom;
                    }

                    pnlDrainPan.Visible = true;
                    pnlDrainPan.Top = (pnlWeldNutOptions.Visible ? pnlWeldNutOptions.Bottom : pnlWeldNut.Bottom);

                    if (cboDrainPan.Text == @"YES")
                    {
                        pnlDrainPanOptions.Visible = true;
                        pnlDrainPanOptions.Top = pnlDrainPan.Bottom;
                    }

                    pnlDamper.Visible = true;
                    pnlDamper.Top = (pnlDrainPanOptions.Visible ? pnlDrainPanOptions.Bottom : pnlDrainPan.Bottom);

                    if (cboDamper.Text == @"YES")
                    {
                        pnlDamperOptions.Visible = true;
                        pnlDamperOptions.Top = pnlDamper.Bottom;
                    }

                    pnlSpecialCustomFitting.Visible = true;
                    pnlSpecialCustomFitting.Top = (pnlDamperOptions.Visible ? pnlDamperOptions.Bottom : pnlDamper.Bottom);

                    if (cboSpecialCustomFitting.Text == @"YES")
                    {
                        pnlSpecialCustomFittingOptions.Visible = true;
                        pnlSpecialCustomFittingOptions.Top = pnlSpecialCustomFitting.Bottom;
                    }

                    lblAnchor.Top = (pnlSpecialCustomFittingOptions.Visible ? pnlSpecialCustomFittingOptions.Bottom : pnlSpecialCustomFitting.Bottom);

                    break;
                case "C":
                    pnlThreadedConnectionsOptionsNo.Visible = true;
                    pnlThreadedConnectionsOptionsNo.Top = 0;

                    pnlFlareFittings.Visible = true;
                    pnlFlareFittings.Top = pnlThreadedConnectionsOptionsNo.Bottom;

                    if (cboFlareFittings.Text == @"YES")
                    {
                        pnlFlareFittingsOptions.Visible = true;
                        pnlFlareFittingsOptions.Top = pnlFlareFittings.Bottom;
                    }

                    pnlWeldNut.Visible = true;
                    pnlWeldNut.Top = (pnlFlareFittingsOptions.Visible ? pnlFlareFittingsOptions.Bottom : pnlFlareFittings.Bottom);

                    if (cboWeldNut.Text == @"YES")
                    {
                        pnlWeldNutOptions.Visible = true;
                        pnlWeldNutOptions.Top = pnlWeldNut.Bottom;
                    }

                    pnlSpecialCustomFitting.Visible = true;
                    pnlSpecialCustomFitting.Top = (pnlWeldNutOptions.Visible ? pnlWeldNutOptions.Bottom : pnlWeldNut.Bottom);

                    if (cboSpecialCustomFitting.Text == @"YES")
                    {
                        pnlSpecialCustomFittingOptions.Visible = true;
                        pnlSpecialCustomFittingOptions.Top = pnlSpecialCustomFitting.Bottom;
                    }

                    lblAnchor.Top = (pnlSpecialCustomFittingOptions.Visible ? pnlSpecialCustomFittingOptions.Bottom : pnlSpecialCustomFitting.Bottom);

                    break;
                case "D":
                    if (GetNumberOfConnections() == 0)
                    {
                        pnlThreadedConnectionsOptionsNo.Visible = true;
                        pnlThreadedConnectionsOptionsNo.Top = 0;

                        pnlFlareFittings.Visible = true;
                        pnlFlareFittings.Top = pnlThreadedConnectionsOptionsNo.Bottom;

                        if (cboFlareFittings.Text == @"YES")
                        {
                            pnlFlareFittingsOptions.Visible = true;
                            pnlFlareFittingsOptions.Top = pnlFlareFittings.Bottom;
                        }

                        pnlDrainPan.Visible = true;
                        pnlDrainPan.Top = (pnlFlareFittingsOptions.Visible ? pnlFlareFittingsOptions.Bottom : pnlFlareFittings.Bottom);

                        if (cboDrainPan.Text == @"YES")
                        {
                            pnlDrainPanOptions.Visible = true;
                            pnlDrainPanOptions.Top = pnlDrainPan.Bottom;
                        }

                        pnlDamper.Visible = true;
                        pnlDamper.Top = (pnlDrainPanOptions.Visible ? pnlDrainPanOptions.Bottom : pnlDrainPan.Bottom);

                        if (cboDamper.Text == @"YES")
                        {
                            pnlDamperOptions.Visible = true;
                            pnlDamperOptions.Top = pnlDamper.Bottom;
                        }

                        pnlSpecialCustomFitting.Visible = true;
                        pnlSpecialCustomFitting.Top = (pnlDamperOptions.Visible ? pnlDamperOptions.Bottom : pnlDamper.Bottom);

                        if (cboSpecialCustomFitting.Text == @"YES")
                        {
                            pnlSpecialCustomFittingOptions.Visible = true;
                            pnlSpecialCustomFittingOptions.Top = pnlSpecialCustomFitting.Bottom;
                        }

                        lblAnchor.Top = (pnlSpecialCustomFittingOptions.Visible ? pnlSpecialCustomFittingOptions.Bottom : pnlSpecialCustomFitting.Bottom);

                    }
                    else
                    {
                        pnlDistributor.Visible = true;
                        pnlDistributor.Top = 0;

                        if (cboDistributors.Text == @"YES")
                        {
                            pnlDistributorOptions.Visible = true;
                            pnlDistributorOptions.Top = pnlDistributor.Bottom;

                            pnlAuxiliarySideConnection.Visible = true;
                            pnlAuxiliarySideConnection.Top = pnlDistributorOptions.Bottom;
                        }

                        pnlFlareFittings.Visible = true;
                        pnlFlareFittings.Top = (pnlAuxiliarySideConnection.Visible ? pnlAuxiliarySideConnection.Bottom : pnlDistributor.Bottom);

                        if (cboFlareFittings.Text == @"YES")
                        {
                            pnlFlareFittingsOptions.Visible = true;
                            pnlFlareFittingsOptions.Top = pnlFlareFittings.Bottom;
                        }

                        pnlWeldNut.Visible = true;
                        pnlWeldNut.Top = (pnlFlareFittingsOptions.Visible ? pnlFlareFittingsOptions.Bottom : pnlFlareFittings.Bottom);

                        if (cboWeldNut.Text == @"YES")
                        {
                            pnlWeldNutOptions.Visible = true;
                            pnlWeldNutOptions.Top = pnlWeldNut.Bottom;
                        }

                        pnlDrainPan.Visible = true;
                        pnlDrainPan.Top = (pnlWeldNutOptions.Visible ? pnlWeldNutOptions.Bottom : pnlWeldNut.Bottom);

                        if (cboDrainPan.Text == @"YES")
                        {
                            pnlDrainPanOptions.Visible = true;
                            pnlDrainPanOptions.Top = pnlDrainPan.Bottom;
                        }

                        pnlDamper.Visible = true;
                        pnlDamper.Top = (pnlDrainPanOptions.Visible ? pnlDrainPanOptions.Bottom : pnlDrainPan.Bottom);

                        if (cboDamper.Text == @"YES")
                        {
                            pnlDamperOptions.Visible = true;
                            pnlDamperOptions.Top = pnlDamper.Bottom;
                        }

                        pnlSpecialCustomFitting.Visible = true;
                        pnlSpecialCustomFitting.Top = (pnlDamperOptions.Visible ? pnlDamperOptions.Bottom : pnlDamper.Bottom);

                        if (cboSpecialCustomFitting.Text == @"YES")
                        {
                            pnlSpecialCustomFittingOptions.Visible = true;
                            pnlSpecialCustomFittingOptions.Top = pnlSpecialCustomFitting.Bottom;
                        }

                        lblAnchor.Top = (pnlSpecialCustomFittingOptions.Visible ? pnlSpecialCustomFittingOptions.Bottom : pnlSpecialCustomFitting.Bottom);

                    }

                    break;
            }

            pnlOptions.AutoScroll = true;

            //check if the function trigger from combobox
            if (sender != null)
            {
                //since i removed autoscroll before refreshing the location get lost.
                //but not removing autoscroll cause issue since it take the current
                //scrolled top as 0 therefore the list keep increasing in length
                //now i find the panel containing the control the user just clicked after movement occured
                //and find it's location and for the autoscoll over there.
                //It doesn't give a perfect position but at least you can see the control after being scrolled
                Point p = ((ComboBox)sender).Parent.Location;
                pnlOptions.AutoScrollPosition = p;
            }
        }

        private ComboBox GetFlareFittingTypeCombobox(int tag)
        {
            var cbo = new ComboBox { Tag = tag, DropDownStyle = ComboBoxStyle.DropDownList };

            DataTable dtListOfFittings = Public.SelectAndSortTable(Public.DSDatabase.Tables["FlareFittings"], "Size <> 0 AND Price > 0", "Type");

            var validFittings = new List<string>();

            //select distinc fittings
            foreach (DataRow dr in dtListOfFittings.Rows)
            {
                bool fittingExist = false;

                foreach (string str in validFittings)
                {
                    if (str == dr["Type"].ToString())
                    {
                        fittingExist = true;
                    }
                }

                if (!fittingExist)
                {
                    validFittings.Add(dr["Type"].ToString());
                }
            }

            cbo.SelectedIndexChanged += cboFlareFittingType_SelectedIndexChanged;

            foreach (string fittings in validFittings)
            {
                ComboBoxControl.AddItem(cbo, fittings, fittings);
            }

            return cbo;
        }


        private ComboBox GetFlareFittingModelCombobox(int tag)
        {
            //items are added dynamicly from the fitting type combobox
            var cbo = new ComboBox { Tag = tag, DropDownStyle = ComboBoxStyle.DropDownList };
            return cbo;
        }

        private void cboFlareFittingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //to handle later
            int tag = Convert.ToInt32(((ComboBox)sender).Tag);

            Fill_FlareFittingModel(tag);
        }

        private void Fill_FlareFittingModel(int tag)
        {
            for (int index = 0; index < lstFlareFittings.Items.Count; index++)
            {
                //find the proper flare fitting
                if (Convert.ToInt32((lstFlareFittings.Items[index].SubItems[2].Control).Tag) == tag)
                {
                    Fill_FlareFittingModelCombobox(((ComboBox)lstFlareFittings.Items[index].SubItems[2].Control), (lstFlareFittings.Items[index].SubItems[1].Control).Text, tag);
                    index = lstFlareFittings.Items.Count;
                }
            }
        }

        private void Fill_FlareFittingModelCombobox(ComboBox cbo, string fittingType, int tag)
        {
            cbo.Items.Clear();

            DataTable dtList = GetFlareFittingModelList(fittingType, tag);

            if (dtList != null)
            {
                foreach (DataRow drModels in dtList.Rows)
                {
                    ComboBoxControl.AddItem(cbo, drModels["Model"].ToString(), drModels["Model"].ToString());
                }
            }
        }

        private DataTable GetFlareFittingModelList(string fittingType, int tag)
        {
            DataTable dtList = GetNumberOfHeaders() == 0 ? Public.SelectAndSortTable(Public.DSDatabase.Tables["FlareFittings"], "Type = '" + fittingType + "' AND (Size = " + _oemcoil.TubeDiameter.ToString(CultureInfo.InvariantCulture) + " OR Size = -99)", "Type") : Public.SelectAndSortTable(Public.DSDatabase.Tables["FlareFittings"], "Type = '" + fittingType + "' AND (Size = " + (lstConnections.Items[tag].SubItems[0].Control).Text + " OR Size = -99)", "Type");

            return dtList;
        }

        private void Fill_ThreadedConnection()
        {
            cboThreadedConnections.Items.Clear();

            ComboBoxControl.AddItem(cboThreadedConnections, "0", "NO");
            ComboBoxControl.AddItem(cboThreadedConnections, "1", "YES");
        }

        private void Fill_ThreadedConnectionOptionsYes()
        {
            lstThreadedConnectionYes.Items.Clear();

            var myItem = new GlacialComponents.Controls.GLItem(lstThreadedConnectionYes);

            myItem.SubItems[0].Control = GetThreadedConnectionQuantityOfThreadedConnectorNumericUpDown();
            myItem.SubItems[1].Control = GetThreadedConnectionDiameterCombobox();
            myItem.SubItems[2].Control = GetThreadedConnectionQuantityOfVentsNumericUpDown();
            myItem.SubItems[3].Control = GetThreadedConnectionQuantityOfSpigotNumericUpDown();

            lstThreadedConnectionYes.Items.Add(myItem);

            lstThreadedConnectionYes.Refresh();

        }

        private void Fill_ThreadedConnectionOptionsNo()
        {
            lstThreadedConnectionNo.Items.Clear();

            var myItem = new GlacialComponents.Controls.GLItem(lstThreadedConnectionNo);

            myItem.SubItems[0].Control = GetThreadedConnectionQuantityOfSpigotNumericUpDown();

            lstThreadedConnectionNo.Items.Add(myItem);

            lstThreadedConnectionNo.Refresh();

        }

        private NumericUpDown GetThreadedConnectionQuantityOfSpigotNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = _oemcoil.FaceTubes * 2m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private ComboBox GetThreadedConnectionDiameterCombobox()
        {
            var cbo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

            foreach (DataRow drHeader in Public.DSDatabase.Tables["HeaderInformation"].Rows)
            {
                ComboBoxControl.AddItem(cbo, drHeader["CopperHeaderDiameter"].ToString(), drHeader["CopperHeaderDiameter"].ToString());
            }

            return cbo;
        }


        private NumericUpDown GetThreadedConnectionQuantityOfThreadedConnectorNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = GetNumberOfHeaders(),
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private NumericUpDown GetThreadedConnectionQuantityOfVentsNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = GetNumberOfHeaders(),
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private void Fill_WeldedNuts()
        {
            cboWeldNut.Items.Clear();

            ComboBoxControl.AddItem(cboWeldNut, "0", "NO");
            ComboBoxControl.AddItem(cboWeldNut, "1", "YES");
        }

        private void FillWeldedNutsOptions()
        {
            numWeldNutQuantity.Value = 0m;
        }

        private void Fill_DrainPan()
        {
            cboDrainPan.Items.Clear();

            ComboBoxControl.AddItem(cboDrainPan, "0", "NO");
            ComboBoxControl.AddItem(cboDrainPan, "1", "YES");
        }

        private void Fill_DrainPanOptions()
        {
            lstDrainPan.Items.Clear();

            var myItem = new GlacialComponents.Controls.GLItem(lstDrainPan);

            myItem.SubItems[0].Control = GetDrainPanQuantityNumericUpDown();
            myItem.SubItems[1].Control = GetDrainPanMaterialCombobox();
            myItem.SubItems[2].Control = GetDrainPanHeightNumericUpDown();
            myItem.SubItems[3].Control = GetDrainPanWidthNumericUpDown();

            lstDrainPan.Items.Add(myItem);

            lstDrainPan.Refresh();
        }

        private NumericUpDown GetDrainPanHeightNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 4,
                Value = _oemcoil.FinLength + 12m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private NumericUpDown GetDrainPanWidthNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 4,
                Value = _backgroundCode.GetDefaultEndPlateHeight(_oemcoil.FinHeight) + 6m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private NumericUpDown GetDrainPanQuantityNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = 1m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private ComboBox GetDrainPanMaterialCombobox()
        {
            var cbo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

            DataTable dtValidMaterial = Public.SelectAndSortTable(Public.DSDatabase.Tables["MaterialInformation"], "DrainPanCostPerLbs <> -99", "CoilFinMaterial");

            foreach (DataRow drMaterial in dtValidMaterial.Rows)
            {
                ComboBoxControl.AddItem(cbo, drMaterial["CoilFinMaterial"].ToString(), drMaterial["CoilFinMaterial"].ToString());
            }

            return cbo;
        }

        private void Fill_Damper()
        {
            cboDamper.Items.Clear();

            ComboBoxControl.AddItem(cboDamper, "0", "NO");
            ComboBoxControl.AddItem(cboDamper, "1", "YES");
        }

        private NumericUpDown GetDamperQuantityNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = 1m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private NumericUpDown GetDamperHeightNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 4,
                Value = 0m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private NumericUpDown GetDamperWidthNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 4,
                Value = 0m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private void Fill_DamperOptions()
        {
            lstDamper.Items.Clear();

            var myItem = new GlacialComponents.Controls.GLItem(lstDamper);

            myItem.SubItems[0].Control = GetDamperQuantityNumericUpDown();
            myItem.SubItems[1].Control = GetDamperHeightNumericUpDown();
            myItem.SubItems[2].Control = GetDamperWidthNumericUpDown();

            lstDamper.Items.Add(myItem);

            lstDamper.Refresh();
        }

        private void Fill_SpecialCustomFittings()
        {
            cboSpecialCustomFitting.Items.Clear();

            ComboBoxControl.AddItem(cboSpecialCustomFitting, "0", "NO");
            ComboBoxControl.AddItem(cboSpecialCustomFitting, "1", "YES");
        }

        private NumericUpDown GetSpecialCustomFittingsPriceNumericUpDown()
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 10000000m,
                DecimalPlaces = 2,
                Value = 0m,
                TextAlign = HorizontalAlignment.Center
            };

            return num;
        }

        private void Fill_SpecialCustomFittingsOptions()
        {
            lstSpecialCustomFitting.Items.Clear();

            var myItem = new GlacialComponents.Controls.GLItem(lstSpecialCustomFitting);

            myItem.SubItems[0].Text = "";
            myItem.SubItems[1].Control = GetSpecialCustomFittingsPriceNumericUpDown();

            lstSpecialCustomFitting.Items.Add(myItem);

            lstSpecialCustomFitting.Refresh();
        }

        private void Fill_AuxiliarySideConnection()
        {
            cboAuxiliarySideConnection.Items.Clear();

            ComboBoxControl.AddItem(cboAuxiliarySideConnection, "0", "NO");
            ComboBoxControl.AddItem(cboAuxiliarySideConnection, "1", "YES");
        }

        private void Fill_Distributors()
        {
            cboDistributors.Items.Clear();

            ComboBoxControl.AddItem(cboDistributors, "0", "NO");
            ComboBoxControl.AddItem(cboDistributors, "1", "YES");
        }

        private NumericUpDown GetDistributorsCircuitNumericUpDown(int tag)
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = 0m,
                TextAlign = HorizontalAlignment.Center,
                Tag = tag
            };
            num.ValueChanged += numDistributorsCircuit_ValueChanged;
            return num;
        }

        private NumericUpDown GetDistributorsLineNumericUpDown(int tag)
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = 0m,
                TextAlign = HorizontalAlignment.Center,
                Tag = tag,
                Enabled = false,
                BackColor = Color.White
            };
            return num;
        }

        private NumericUpDown GetDistributorsSpigotNumericUpDown(int tag)
        {
            var num = new NumericUpDown
            {
                Minimum = 0m,
                Maximum = 1000m,
                DecimalPlaces = 0,
                Value = 0m,
                TextAlign = HorizontalAlignment.Center,
                Tag = tag,
                Enabled = false,
                BackColor = Color.White
            };
            return num;
        }

        private void numDistributorsCircuit_ValueChanged(object sender, EventArgs e)
        {
            Fill_DistributorsModel(Convert.ToInt32(((NumericUpDown)sender).Tag));
            ChangeDistributorLineAndSpigot(Convert.ToInt32(((NumericUpDown)sender).Tag));
        }

        private void ChangeDistributorLineAndSpigot(int tag)
        {
            for (int index = 0; index < lstDistributor.Items.Count; index++)
            {
                //find the proper distributor
                if (Convert.ToInt32((lstDistributor.Items[index].SubItems[0].Control).Tag) == tag)
                {
                    ((NumericUpDown)lstDistributor.Items[index].SubItems[1].Control).Value = ((NumericUpDown)lstDistributor.Items[index].SubItems[0].Control).Value;
                    ((NumericUpDown)lstDistributor.Items[index].SubItems[2].Control).Value = ((NumericUpDown)lstDistributor.Items[index].SubItems[0].Control).Value;
                    index = lstDistributor.Items.Count;
                }
            }
        }

        private ComboBox GetDistributorsManufacturerCombobox(int tag)
        {
            var cbo = new ComboBox { Tag = tag, DropDownStyle = ComboBoxStyle.DropDownList };

            DataTable dtListingOfManufacturer = Public.SelectAndSortTable(Public.DSDatabase.Tables["Distributor"], "", "Manufacturer");

            var validManufacturers = new List<string>();

            //select distinct manufacturer
            foreach (DataRow dr in dtListingOfManufacturer.Rows)
            {
                bool manufacturerExist = false;

                foreach (string str in validManufacturers)
                {
                    if (str == dr["Manufacturer"].ToString())
                    {
                        manufacturerExist = true;
                    }
                }

                if (!manufacturerExist)
                {
                    validManufacturers.Add(dr["Manufacturer"].ToString());
                }
            }

            cbo.SelectedIndexChanged += cboDistributorsManufacturer_SelectedIndexChanged;

            foreach (string manufacturer in validManufacturers)
            {
                ComboBoxControl.AddItem(cbo, manufacturer, manufacturer);
            }

            return cbo;
        }

        private void cboDistributorsManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_DistributorsModel(Convert.ToInt32(((ComboBox)sender).Tag));
        }

        private ComboBox GetDistributorsModelCombobox(int tag)
        {
            var cbo = new ComboBox { Tag = tag, DropDownStyle = ComboBoxStyle.DropDownList };
            return cbo;
        }

        private void Fill_DistributorsModel(int tag)
        {
            for (int index = 0; index < lstDistributor.Items.Count; index++)
            {
                //find the proper flare fitting
                if (Convert.ToInt32(lstDistributor.Items[index].SubItems[4].Control.Tag) == tag)
                {
                    Fill_DistributorsModelCombobox(((ComboBox)lstDistributor.Items[index].SubItems[4].Control), (lstDistributor.Items[index].SubItems[3].Control).Text, Convert.ToInt32(((NumericUpDown)lstDistributor.Items[index].SubItems[0].Control).Value));
                    index = lstDistributor.Items.Count;
                }
            }
        }

        private void Fill_DistributorsModelCombobox(ComboBox cbo, string manufacturer, int circuits)
        {
            cbo.Items.Clear();

            IEnumerable<string> validModels = GetDistributorsAvailableModels(manufacturer, circuits);

            foreach (string strModel in validModels)
            {
                ComboBoxControl.AddItem(cbo, strModel, strModel);
            }
        }

        private IEnumerable<string> GetDistributorsAvailableModels(string manufacturer, int circuits)
        {
            DataTable dtValidFilteredModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["Distributor"], "Manufacturer = '" + manufacturer + "' AND NumberOfCircuits = " + circuits.ToString(CultureInfo.InvariantCulture) + " AND Price <> 0", "");

            var validModels = new List<string>();

            //select distinct models
            foreach (DataRow dr in dtValidFilteredModel.Rows)
            {
                bool modelExist = false;

                foreach (string str in validModels)
                {
                    if (str == ModifyModelDisplay(dr["DistributorModel"].ToString()))
                    {
                        modelExist = true;
                    }
                }

                if (!modelExist)
                {
                    validModels.Add(ModifyModelDisplay(dr["DistributorModel"].ToString()));
                }
            }

            return validModels;
        }

        private string ModifyModelDisplay(string strModel)
        {
            string finalModelText = strModel;

            //according to vb code model with / dont keep the last part after the last dash.
            //last dash included
            //1116-16-3/16-E2
            //become
            //1116-16-3/16
            //the "-E2" get removed
            //other model without / stay untouched
            //new thing. it only keep the first 3 split
            //ex: 701-5-3/16-G2-1/2 dont become
            //701-5-3/16-G2 but
            //701-5-3/16
            if (strModel.Contains("/"))
            {

                string[] modelSplit = strModel.Split('-');

                finalModelText = "";

                for (int i = 0; i < 3; i++)
                {
                    finalModelText += modelSplit[i] + "-";
                }

                finalModelText = finalModelText.Substring(0, finalModelText.Length - 1);
            }

            return finalModelText;
        }

        private void Fill_DistributorsOptions()
        {
            lstDistributor.Items.Clear();

            //for each connection subsequent we add them
            for (int i = 0; i < lstConnections.Items.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstDistributor);

                myItem.SubItems[0].Control = GetDistributorsCircuitNumericUpDown(i);
                myItem.SubItems[1].Control = GetDistributorsLineNumericUpDown(i);
                myItem.SubItems[2].Control = GetDistributorsSpigotNumericUpDown(i);
                myItem.SubItems[3].Control = GetDistributorsManufacturerCombobox(i);
                myItem.SubItems[4].Control = GetDistributorsModelCombobox(i);

                lstDistributor.Items.Add(myItem);
            }

            lstDistributor.Refresh();

        }

        private void OptionsValidation()
        {
            OptionsClear();

            switch (_oemcoil.CoilType)
            {
                case "W":
                case "B":
                    Fill_ThreadedConnection();
                    Fill_ThreadedConnectionOptionsYes();
                    Fill_ThreadedConnectionOptionsNo();
                    Fill_FlareFittings();
                    Fill_FlareFittingsOptions();
                    Fill_WeldedNuts();
                    FillWeldedNutsOptions();
                    Fill_DrainPan();
                    Fill_DrainPanOptions();
                    Fill_Damper();
                    Fill_DamperOptions();
                    Fill_SpecialCustomFittings();
                    Fill_SpecialCustomFittingsOptions();
                    break;
                case "S":
                case "N":
                    Fill_ThreadedConnection();
                    Fill_ThreadedConnectionOptionsYes();
                    Fill_ThreadedConnectionOptionsNo();
                    Fill_FlareFittings();
                    Fill_FlareFittingsOptions();
                    Fill_WeldedNuts();
                    FillWeldedNutsOptions();
                    Fill_DrainPan();
                    Fill_DrainPanOptions();
                    Fill_Damper();
                    Fill_DamperOptions();
                    Fill_SpecialCustomFittings();
                    Fill_SpecialCustomFittingsOptions();
                    break;
                case "C":
                    Fill_ThreadedConnectionOptionsNo();
                    Fill_FlareFittings();
                    Fill_FlareFittingsOptions();
                    Fill_WeldedNuts();
                    FillWeldedNutsOptions();
                    Fill_SpecialCustomFittings();
                    Fill_SpecialCustomFittingsOptions();
                    break;
                case "D":
                    if (GetNumberOfConnections() == 0)
                    {
                        Fill_ThreadedConnectionOptionsNo();
                        Fill_FlareFittings();
                        Fill_FlareFittingsOptions();
                        Fill_DrainPan();
                        Fill_DrainPanOptions();
                        Fill_Damper();
                        Fill_DamperOptions();
                        Fill_SpecialCustomFittings();
                        Fill_SpecialCustomFittingsOptions();
                    }
                    else
                    {
                        Fill_Distributors();
                        Fill_DistributorsOptions();
                        Fill_AuxiliarySideConnection();
                        Fill_FlareFittings();
                        Fill_FlareFittingsOptions();
                        Fill_WeldedNuts();
                        FillWeldedNutsOptions();
                        Fill_DrainPan();
                        Fill_DrainPanOptions();
                        Fill_Damper();
                        Fill_DamperOptions();
                        Fill_SpecialCustomFittings();
                        Fill_SpecialCustomFittingsOptions();
                    }
                    break;
            }

            PanelValidation(null);
        }


        //return the casing material ID for refernece in other tables
        private int CasingMaterialID()
        {
            return Convert.ToInt32(ComboBoxControl.ItemInformations(cboCasingMaterial, Public.DSDatabase.Tables["v_CoilCasingMaterialDefaults"], "UniqueID")[0]["CasingMaterialID"]);
        }

        private void Fill_CasingMaterial()
        {
            cboCasingMaterial.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtCasingMaterial = Public.SelectAndSortTable(Public.DSDatabase.Tables["v_CoilCasingMaterialDefaults"], "CoilTypeParameter = '" + _oemcoil.CoilTypeParameter + "'", "CasingMaterial");

            //for each casing material
            foreach (DataRow drCasingMaterial in dtCasingMaterial.Rows)
            {
                string strIndex = drCasingMaterial["UniqueID"].ToString();
                string strText = drCasingMaterial["CasingMaterial"].ToString();
                ComboBoxControl.AddItem(cboCasingMaterial, strIndex, strText);
            }

            //2011-08-24 : #1177 : Simon wants Galv. as default for casing material
            ////if we have something inside select first one
            if (cboCasingMaterial.Items.Count > 0)
            {
                cboCasingMaterial.SelectedIndex = cboCasingMaterial.FindString("Galvanized Steel") >= 0 ? cboCasingMaterial.FindString("Galvanized Steel") : 0;
            }

            //dispose
            dtCasingMaterial.Dispose();
        }

        private void Fill_CasingThickness()
        {
            cboCasingThickness.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtCasingThickness = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingThickness"], "CasingMaterialID = " + CasingMaterialID().ToString(CultureInfo.InvariantCulture), "");
            //for each casing material
            foreach (DataRow drCasingThickness in dtCasingThickness.Rows)
            {
                string strIndex = drCasingThickness["UniqueID"].ToString();
                string strText = drCasingThickness["CasingThickness"].ToString();
                ComboBoxControl.AddItem(cboCasingThickness, strIndex, strText);
            }

            //if we have something inside select first one
            if (cboCasingThickness.Items.Count > 0)
            {
                cboCasingThickness.SelectedIndex = 0;
            }

            //dispose
            dtCasingThickness.Dispose();
        }

        private void cboCasingMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            _secondTabChanged = true;
            Fill_CasingThickness();
        }

        private void Fill_FinMaterial()
        {
            cboFinMaterial.Items.Clear();

            var qcc = new QuickCoil.QuickCoilCode();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinMaterial in Public.DSDatabase.Tables["CoilFinMaterial"].Rows)
            {
                //if we can found the fintype in the table that mean it's available for
                //the selected coil type so we can show it
                if (qcc.IsFinMaterialAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), _oemcoil.FinType, _oemcoil.FinShape, _oemcoil.FPI, drFinMaterial["UniqueID"].ToString()))
                {
                    string strIndex = drFinMaterial["UniqueID"].ToString();
                    string strText = drFinMaterial["FinMaterial"].ToString();
                    ComboBoxControl.AddItem(cboFinMaterial, strIndex, strText);
                }
            }


            if (cboFinMaterial.Items.Count > 0)
            {
                cboFinMaterial.SelectedIndex = 0;
            }
        }

        private void Fill_FinThickness()
        {
            cboFinThickness.Items.Clear();

            var qcc = new QuickCoil.QuickCoilCode();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinThickness in Public.DSDatabase.Tables["CoilfinThickness"].Rows)
            {
                //is fin thickness available for the following parameter
                if (qcc.IsFinThicknessAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), _oemcoil.FinType, _oemcoil.FPI, ComboBoxControl.IndexInformation(cboFinMaterial), drFinThickness["FinThickness"].ToString()))
                {
                    string strIndex = drFinThickness["UniqueID"].ToString();
                    string strText = drFinThickness["FinThickness"].ToString();
                    ComboBoxControl.AddItem(cboFinThickness, strIndex, strText);
                }
            }


            //select the default thickness
            ComboBoxControl.SetDefaultValue(cboFinThickness, qcc.FinThicknessDefault(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), _oemcoil.CoilTypeParameter, _oemcoil.FinShape, _oemcoil.FPI, ComboBoxControl.IndexInformation(cboFinMaterial)));
        }

        private void cboFinMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            _secondTabChanged = true;
            Fill_FinThickness();
        }

        private void Fill_TubeMaterial()
        {
            cboTubeMaterial.Items.Clear();

            var qcc = new QuickCoil.QuickCoilCode();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtTubeMaterial = Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CoilTubeMaterial"].Copy());

            //for each material type
            foreach (DataRow drTubeMaterial in dtTubeMaterial.Rows)
            {
                //2010-09-23 : As per email confirmation of Simon on 2010-09-22 3:09 PM
                //Question : 
                //Toutes les restrictions sur quoi que ce soit, qui ont rapport au R-410a 
                //et qui touche au Coil ou au Condensers doivent etre enlevées. 
                //Answer : 
                //Oui c’est confirmé.

                if (qcc.IsTubeMaterialAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], _oemcoil.CoilTypeParameter, _oemcoil.FinType, drTubeMaterial["UniqueID"].ToString(), false))
                {
                    //2010-09-21 : Steam Distributing Cannot have Stainless Steel
                    //so the change is easier to hardcode what being showed when the control is being
                    //filled
                    bool validMaterial = !((Convert.ToInt32(drTubeMaterial["UniqueID"]) == 4 || Convert.ToInt32(drTubeMaterial["UniqueID"]) == 5) && _oemcoil.CoilTypeParameter == "ST" && _oemcoil.CoilType == "N");


                    if (validMaterial)
                    {
                        string strIndex = drTubeMaterial["UniqueID"].ToString();
                        string strText = drTubeMaterial["TubeMaterial"].ToString();
                        ComboBoxControl.AddItem(cboTubeMaterial, strIndex, strText);
                    }
                }
            }

            dtTubeMaterial.Dispose();

            if (cboTubeMaterial.Items.Count > 0)
            {
                cboTubeMaterial.SelectedIndex = 0;
            }
        }

        private void Fill_TubeThickness()
        {
            cboTubeThickness.Items.Clear();

            var qcc = new QuickCoil.QuickCoilCode();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drTubeThickness in Public.DSDatabase.Tables["CoilTubeThickness"].Rows)
            {
                //2010-09-23 : As per email confirmation of Simon on 2010-09-22 3:09 PM
                //Question : 
                //Toutes les restrictions sur quoi que ce soit, qui ont rapport au R-410a 
                //et qui touche au Coil ou au Condensers doivent etre enlevées. 
                //Answer : 
                //Oui c’est confirmé.

                //is tube thickness available for the following parameter
                if (qcc.IsTubeThicknessAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], _oemcoil.CoilTypeParameter, _oemcoil.FinType, ComboBoxControl.IndexInformation(cboTubeMaterial), drTubeThickness["TubeThickness"].ToString(), false))
                {
                    string strIndex = drTubeThickness["UniqueID"].ToString();
                    string strText = drTubeThickness["TubeThickness"].ToString();
                    ComboBoxControl.AddItem(cboTubeThickness, strIndex, strText);
                }
            }

            //select the default thickness
            ComboBoxControl.SetDefaultValue(cboTubeThickness, qcc.TubeThicknessDefault(Public.DSDatabase.Tables["v_CoilTubeDefaults"], _oemcoil.CoilTypeParameter, _oemcoil.FinType, ComboBoxControl.IndexInformation(cboTubeMaterial), false));
        }

        private void cboTubeMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            _secondTabChanged = true;
            Fill_TubeThickness();
        }

        private void cmdNextMaterial_Click(object sender, EventArgs e)
        {
            if (_modelChanged && _intIndex > 0)
            {
                if (MessageBox.Show(Public.LanguageString("You just changed the model for your OEM coil.  Changing this means the whole set of data after is changed.  So you will lose all the data saved from the coil. Is that ok?", "Vous venez de changer le modèle.  Changer celui-ci implique que toutes les données suivantes qui étaient sauvegardées sur le serpentin devront être rentrées à nouveau."), Public.LanguageString("Warning!", "Attention"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _importantAttributeChanged = true;
                    NextMaterial();
                }
                else
                {
                    LoadSavedData();
                }
            }
            else
            {
                if (_bolQuoteSelection && _intIndex != -1 && !_importantAttributeChanged)
                {
                    tabOEMCoil.TabPages.Remove(tabPricing);
                    NextMaterial();
                    ValidateSecondTab();
                    _secondTabChanged = false;
                }
                else
                {
                    NextMaterial();
                }
            }
        }

        private void NextMaterial()
        {
            if (IsCoilValid())
            {
                MaterialValidation();
                tabOEMCoil.TabPages.Remove(tabModel);
                tabOEMCoil.TabPages.Add(tabMaterial);
            }
        }

        private void cmdPreviousModel_Click(object sender, EventArgs e)
        {
            if (_secondTabChanged && _bolQuoteSelection && _intIndex != -1)
            {
                if (MessageBox.Show(Public.LanguageString("If you go back, the changes made on this tab will be lost.  Do you still want to go back?", "Si vous reculez à l'onglet précédent, les changements faits sur celui-ci seront perdus.  Voulez-vous reculer?"), Public.LanguageString("Warning!", "Attention!"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tabOEMCoil.TabPages.Remove(tabMaterial);
                    tabOEMCoil.TabPages.Add(tabModel);
                }
            }
            else
            {
                tabOEMCoil.TabPages.Remove(tabMaterial);
                tabOEMCoil.TabPages.Add(tabModel);
            }
        }

        private void cmdNextBendsCasingAndConnections_Click(object sender, EventArgs e)
        {
            if (_bolQuoteSelection && _intIndex != -1 && !_importantAttributeChanged)
            {
                tabOEMCoil.TabPages.Remove(tabPricing);
                NextBendsCasingAndConnections();
                ValidateThirdTab();
                _thirdTabChanged = false;
            }
            else
            {
                NextBendsCasingAndConnections();
            }
        }

        private void NextBendsCasingAndConnections()
        {
            ReturnBendsCasingConnectionValidation();
            tabOEMCoil.TabPages.Remove(tabMaterial);
            tabOEMCoil.TabPages.Add(tabBendsCasingAndConnections);
        }

        private void cmdPreviousMaterial_Click(object sender, EventArgs e)
        {
            if (_thirdTabChanged && _bolQuoteSelection && _intIndex != -1)
            {
                if (MessageBox.Show(Public.LanguageString("If you go back, the changes made on this tab will be lost.  Do you still want to go back?", "Si vous reculez à l'onglet précédent, les changements faits sur celui-ci seront perdus.  Voulez-vous reculer?"), Public.LanguageString("Warning!", "Attention!"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tabOEMCoil.TabPages.Remove(tabBendsCasingAndConnections);
                    tabOEMCoil.TabPages.Add(tabMaterial);
                    _connectionCountChanged = false;
                }
            }
            else
            {
                tabOEMCoil.TabPages.Remove(tabBendsCasingAndConnections);
                tabOEMCoil.TabPages.Add(tabMaterial);
            }

        }

        private void cmdNextOptions_Click(object sender, EventArgs e)
        {
            if (_connectionCountChanged && _intIndex > 0)
            {
                if (MessageBox.Show(Public.LanguageString("You just changed the number of connections for your OEM coil.  Changing this means the whole set of data after is changed.  So you will lose all the data saved from the coil. Is that ok?", "Vous venez de changer le nombre de connexions de votre serpentin.  Changer ceci implique que toutes les données suivantes qui étaient sauvegardées sur le serpentin devront être rentrées à nouveau."), Public.LanguageString("Warning!", "Attention"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _importantAttributeChanged = true;
                    NextOptions();
                }
                else
                {
                    LoadSavedData();
                }
            }
            else
            {
                if (_bolQuoteSelection && _intIndex != -1 && !_importantAttributeChanged)
                {
                    tabOEMCoil.TabPages.Remove(tabPricing);
                    NextOptions();
                    ValidateFourthTab();
                    _fourthTabChanged = false;
                }
                else
                {
                    NextOptions();
                }
            }


        }

        private void NextOptions()
        {
            if (ReturnBendsCasingConnectionValidateInputs())
            {
                OptionsValidation();
                tabOEMCoil.TabPages.Remove(tabBendsCasingAndConnections);
                tabOEMCoil.TabPages.Add(tabOptions);

            }
        }

        private void cmdPreviousBendsCasingAndConnections_Click(object sender, EventArgs e)
        {
            if (_fourthTabChanged && _bolQuoteSelection && _intIndex != -1)
            {
                if (MessageBox.Show(Public.LanguageString("If you go back, the changes made on this tab will be lost.  Do you still want to go back?", "Si vous reculez à l'onglet précédent, les changements faits sur celui-ci seront perdus.  Voulez-vous reculer?"), Public.LanguageString("Warning!", "Attention!"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tabOEMCoil.TabPages.Remove(tabOptions);
                    tabOEMCoil.TabPages.Add(tabBendsCasingAndConnections);
                }
            }
            else
            {
                tabOEMCoil.TabPages.Remove(tabOptions);
                tabOEMCoil.TabPages.Add(tabBendsCasingAndConnections);
            }


        }

        private void cmdNextPricing_Click(object sender, EventArgs e)
        {
            if (_bolQuoteSelection && _intIndex != -1 && !_importantAttributeChanged)
            {
                tabOEMCoil.TabPages.Remove(tabPricing);
                NextPricing();
                ValidateFifthTab();
                _fifthTabChanged = false;
            }
            else
            {
                NextPricing();
            }


        }

        private void NextPricing()
        {
            if (OptionsValidateInputs())
            {
                PricingValidation();
                tabOEMCoil.TabPages.Remove(tabOptions);
                tabOEMCoil.TabPages.Add(tabPricing);
            }
        }

        private void cmdPreviousOptions_Click(object sender, EventArgs e)
        {
            if (_fifthTabChanged && _bolQuoteSelection && _intIndex != -1)
            {
                if (MessageBox.Show(Public.LanguageString("If you go back, the changes made on this tab will be lost.  Do you still want to go back?", "Si vous reculez à l'onglet précédent, les changements faits sur celui-ci seront perdus.  Voulez-vous reculer?"), Public.LanguageString("Warning!", "Attention!"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tabOEMCoil.TabPages.Remove(tabPricing);
                    tabOEMCoil.TabPages.Add(tabOptions);
                }
            }
            else
            {
                tabOEMCoil.TabPages.Remove(tabPricing);
                tabOEMCoil.TabPages.Add(tabOptions);
            }
        }

        private void cmdAddConnection_Click(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
            _connectionCountChanged = true;


            AddConnection();
        }

        private void AddConnection()
        {
            if (lstConnections.Items.Count < 4)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstConnections);
                myItem.SubItems[0].Control = GetHeaderCombobox();
                myItem.SubItems[1].Control = GetHeaderLengthNumericUpDown();
                lstConnections.Items.Add(myItem);
                lstConnections.Refresh();
            }
            else
            {
                Public.LanguageBox("Maximum amount of connection reached. A maximum of 4 connections are allowed", "Nombre de connexions maximale atteinte. Un maximum de 4 connexions est autorisé");
            }
        }

        private void cmdRemoveConnection_Click(object sender, EventArgs e)
        {
            _connectionCountChanged = true;
            _thirdTabChanged = true;
            RemoveConnection();
        }

        private void RemoveConnection()
        {
            if (lstConnections.SelectedItems.Count > 0)
            {
                lstConnections.Items.Remove(((GlacialComponents.Controls.GLItem)lstConnections.SelectedItems[0]));

                lstConnections.Refresh();
            }
            else
            {
                Public.LanguageBox("No connection selected", "Aucune connexion sélectionnée");
            }
        }

        private void cboFlareFittings_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void cboDistributors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void cboAuxiliarySideConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void cboWeldNut_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void cboDrainPan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void cboDamper_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void cboSpecialCustomFitting_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void cboThreadedConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
            PanelValidation(sender);
        }

        private void PriceCoil()
        {
            if (cboCoilComplexity.SelectedIndex >= 0 && cboProfitMargin.SelectedIndex >= 0)
            {
                decimal exchangeRate = numExchangeRate.Value;
                decimal profit = Convert.ToDecimal(ComboBoxControl.IndexInformation(cboProfitMargin));
                string coilType = _oemcoil.CoilType;
                string finType = _oemcoil.FinType;
                decimal tubeRow = _oemcoil.TubeRow;
                decimal tubeDiameter = _oemcoil.TubeDiameter;
                decimal faceTubeSize = _oemcoil.FaceTubeSize;
                decimal pressStrokeMin = _oemcoil.PressStrokeMin;
                decimal rowWidth = _oemcoil.RowWidth;
                int faceTubes = _oemcoil.FaceTubes;
                decimal finHeight = _oemcoil.FinHeight;
                decimal finLength = _oemcoil.FinLength;
                int rows = _oemcoil.Rows;
                int fpi = _oemcoil.FPI;
                string finMaterial = cboFinMaterial.Text;
                decimal finThickness = Convert.ToDecimal(cboFinThickness.Text);
                string tubeMaterial = cboTubeMaterial.Text;
                decimal tubeThickness = Convert.ToDecimal(cboTubeThickness.Text);
                string casingMaterial = cboCasingMaterial.Text;
                decimal casingThickness = Convert.ToDecimal(cboCasingThickness.Text);
                int endPlateQuantity = Convert.ToInt32(numEndPlate.Value);
                decimal endPlateHeight = numEndPlateHeight.Value;
                decimal endPlateWidth = numEndPlateWidth.Value;
                int topPlateQuantity = Convert.ToInt32(numTopPlate.Value);
                decimal topPlateHeight = numTopPlateHeight.Value;
                decimal topPlateWidth = numTopPlateWidth.Value;
                int bottomPlateQuantity = Convert.ToInt32(numBottomPlate.Value);
                decimal bottomPlateHeight = numBottomPlateHeight.Value;
                decimal bottomPlateWidth = numBottomPlateWidth.Value;
                int centerPlateQuantity = Convert.ToInt32(numCenterPlate.Value);
                decimal centerPlateHeight = numCenterPlateHeight.Value;
                decimal centerPlateWidth = numCenterPlateWidth.Value;
                int returnBendsQty = Convert.ToInt32(numReturnBends.Value);

                int drainPanQuantity = 0;
                string drainPanMaterial = "";
                decimal drainPanHeight = 0m;
                decimal drainPanWidth = 0m;

                if (cboDrainPan.Text == @"YES")
                {
                    drainPanQuantity = Convert.ToInt32(((NumericUpDown)lstDrainPan.Items[0].SubItems[0].Control).Value);
                    drainPanMaterial = lstDrainPan.Items[0].SubItems[1].Control.Text;
                    drainPanHeight = ((NumericUpDown)lstDrainPan.Items[0].SubItems[2].Control).Value;
                    drainPanWidth = ((NumericUpDown)lstDrainPan.Items[0].SubItems[3].Control).Value;
                }

                int damperQuantity = 0;
                decimal damperHeight = 0m;
                decimal damperWidth = 0m;

                if (cboDamper.Text == @"YES")
                {
                    damperQuantity = Convert.ToInt32(((NumericUpDown)lstDamper.Items[0].SubItems[0].Control).Value);
                    damperHeight = ((NumericUpDown)lstDamper.Items[0].SubItems[1].Control).Value;
                    damperWidth = ((NumericUpDown)lstDamper.Items[0].SubItems[2].Control).Value;
                }

                bool selectedThreadedConnection = (cboThreadedConnections.Text == @"YES");
                int threadedConnectionQuantity = 0;
                decimal threadedConnectionDiameter = 0m;
                int ventsQuantity = 0;
                int spigotQuantity = 0;

                if (selectedThreadedConnection)
                {
                    threadedConnectionQuantity = Convert.ToInt32(((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[0].Control).Value);
                    threadedConnectionDiameter = Convert.ToDecimal(lstThreadedConnectionYes.Items[0].SubItems[1].Control.Text);
                    ventsQuantity = Convert.ToInt32(((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[2].Control).Value);
                    spigotQuantity = Convert.ToInt32(((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[3].Control).Value);
                }

                if (pnlThreadedConnectionsOptionsNo.Visible)
                {
                    spigotQuantity = Convert.ToInt32(((NumericUpDown)lstThreadedConnectionNo.Items[0].SubItems[0].Control).Value);
                }

                var connections = new List<Pricing.Headers>();

                for (int index = 0; index < lstConnections.Items.Count; index++)
                {
                    connections.Add(new Pricing.Headers(Convert.ToDecimal(lstConnections.Items[index].SubItems[0].Control.Text), ((NumericUpDown)lstConnections.Items[index].SubItems[1].Control).Value));
                }

                bool selectedDistributor = (cboDistributors.Text == @"YES");
                var distributors = new List<Pricing.Distributor>();

                for (int index = 0; index < lstDistributor.Items.Count; index++)
                {
                    distributors.Add(new Pricing.Distributor(((NumericUpDown)lstDistributor.Items[index].SubItems[0].Control).Value, ((NumericUpDown)lstDistributor.Items[index].SubItems[1].Control).Value, ((NumericUpDown)lstDistributor.Items[index].SubItems[2].Control).Value, lstDistributor.Items[index].SubItems[3].Control.Text, lstDistributor.Items[index].SubItems[4].Control.Text));
                }

                bool selectedFlareFitting = (cboFlareFittings.Text == @"YES");
                var flareFittings = new List<Pricing.FlareFitting>();

                for (int index = 0; index < lstFlareFittings.Items.Count; index++)
                {
                    flareFittings.Add(new Pricing.FlareFitting(Convert.ToInt32(((NumericUpDown)lstFlareFittings.Items[index].SubItems[0].Control).Value), (lstFlareFittings.Items[index].SubItems[1].Control).Text, (lstFlareFittings.Items[index].SubItems[2].Control).Text));
                }

                bool selectedAuxiliarySideConnection = (cboAuxiliarySideConnection.Text == @"YES");
                bool selectedWeldNuts = (cboWeldNut.Text == @"YES");
                int weldNutQuantity = 0;

                if (selectedWeldNuts)
                {
                    weldNutQuantity = Convert.ToInt32(numWeldNutQuantity.Value);
                }

                bool selectedSpecialCustomFitting = (cboSpecialCustomFitting.Text == @"YES");
                decimal specialCustomFittingPrice = 0m;

                if (selectedSpecialCustomFitting)
                {
                    specialCustomFittingPrice = ((NumericUpDown)lstSpecialCustomFitting.Items[0].SubItems[1].Control).Value;
                }

                bool selectedWeldCasing = (cboWeldedCasing.Text == @"YES");
                bool selectedDrainPan = (cboDrainPan.Text == @"YES");
                bool selectedDamper = (cboDamper.Text == @"YES");

                _oemPricing = new Pricing.OEMCoilPricing(exchangeRate,
                 profit,
                 coilType,
                 finType,
                 tubeRow,
                 tubeDiameter,
                 faceTubeSize,
                 pressStrokeMin,
                 rowWidth,
                 faceTubes,
                 finHeight,
                 finLength,
                 rows,
                 fpi,
                 finMaterial,
                 finThickness,
                 tubeMaterial,
                 tubeThickness,
                 casingMaterial,
                 casingThickness,
                 endPlateQuantity,
                 endPlateHeight,
                 endPlateWidth,
                 topPlateQuantity,
                 topPlateHeight,
                 topPlateWidth,
                 bottomPlateQuantity,
                 bottomPlateHeight,
                 bottomPlateWidth,
                 centerPlateQuantity,
                 centerPlateHeight,
                 centerPlateWidth,
                 returnBendsQty,
                 drainPanQuantity,
                 drainPanMaterial,
                 drainPanHeight,
                 drainPanWidth,
                 damperQuantity,
                 damperHeight,
                 damperWidth,
                 selectedThreadedConnection,
                 threadedConnectionQuantity,
                 threadedConnectionDiameter,
                 ventsQuantity,
                 spigotQuantity,
                 connections,
                 selectedDistributor,
                 distributors,
                 selectedFlareFitting,
                 flareFittings,
                 selectedAuxiliarySideConnection,
                 selectedWeldNuts,
                 weldNutQuantity,
                 selectedSpecialCustomFitting,
                 specialCustomFittingPrice,
                 selectedWeldCasing,
                 selectedDrainPan,
                 selectedDamper,
                 chkOverhead.Checked );

                decimal setupCost = Convert.ToDecimal(ComboBoxControl.IndexInformation(cboCoilComplexity));

                for (int index = 0; index < lstPrice.Items.Count; index++)
                {
                    decimal from = ((NumericUpDown)lstPrice.Items[index].SubItems[0].Control).Value;
                    decimal to = ((NumericUpDown)lstPrice.Items[index].SubItems[2].Control).Value;

                    decimal price = 0m;

                    try
                    {
                        if (index <= 1)
                        {
                            //first 2 have different formula
                            price = setupCost / ((from + to) / 2m) + _oemPricing.getNetCostOfHorizontal_WithProfitMargin();
                        }
                        else
                        {
                            price = setupCost / ((from + to) / 2m) + _oemPricing.getNetCostOfCoil_WithProfitMargin();
                        }
                    }
                    catch (Exception ex)
                    {
                        Public.PushLog(ex.ToString(),"frmOEMCoil PriceCoil");
                        MessageBox.Show(ex.ToString());
                    }

                    lstPrice.Items[index].SubItems[3].Text = price.ToString("N2") + " $";
                }

                lstPrice.Refresh();

                DisplayAdditionnalInformations();
            }
        }

        private string FilterTubeMaterial(string tubeMaterial)
        {
            return tubeMaterial.Replace("RIFFLE ", "");
        }

        private void DisplayAdditionnalInformations()
        {
            string strAdditionalInfo = "";

            if (numTopPlate.Value > 0m || numBottomPlate.Value > 0m)
            {
                strAdditionalInfo += "C/W " + (numTopPlate.Value == 0m ? "No" : numTopPlate.Value.ToString(CultureInfo.InvariantCulture)) + " Top & " + (numBottomPlate.Value == 0m ? "No" : numBottomPlate.Value.ToString(CultureInfo.InvariantCulture)) + " Bottom Plates" + Environment.NewLine;
            }

            if (lstConnections.Items.Count > 0)
            {
                strAdditionalInfo += lstConnections.Items.Count.ToString(CultureInfo.InvariantCulture) + " " + FilterTubeMaterial(cboTubeMaterial.Text) + " Header(s)" + Environment.NewLine;
            }
            else
            {
                strAdditionalInfo += "No " + FilterTubeMaterial(cboTubeMaterial.Text) + " Header(s)" + (_oemcoil.CoilType == "D" ? " & No Distributor(s)" : "") + Environment.NewLine;
            }

            if (_oemcoil.CoilType == "D")
            {
                strAdditionalInfo += "Evaporator Coil " + (cboDistributors.Text == @"YES" ? "/ " + lstConnections.Items.Count.ToString(CultureInfo.InvariantCulture) + " Distributor(s)" : "") + Environment.NewLine;
            }
            else if (_oemcoil.CoilType == "W" || _oemcoil.CoilType == "B")
            {
                strAdditionalInfo += "Water Coil " + (cboThreadedConnections.Text == @"YES" ? "/ " + ((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[0].Control).Value.ToString(CultureInfo.InvariantCulture) + " Sweat Conn.(s)" : "") + Environment.NewLine;

            }
            else if (_oemcoil.CoilType == "S")
            {
                strAdditionalInfo += "Steam Coil " + (cboThreadedConnections.Text == @"YES" ? "/ " + ((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[0].Control).Value.ToString(CultureInfo.InvariantCulture) + " Sweat Conn.(s)" : "") + Environment.NewLine;

            }
            else if (_oemcoil.CoilType == "N")
            {
                strAdditionalInfo += "Non-Freeze Steam Coil " + (cboThreadedConnections.Text == @"YES" ? "/ " + ((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[0].Control).Value.ToString(CultureInfo.InvariantCulture) + " Sweat Conn.(s)" : "") + Environment.NewLine;
            }
            else if (_oemcoil.CoilType == "C")
            {
                strAdditionalInfo += "Condenser Coil " + " Sweat Conn.(s)" + Environment.NewLine;
            }

            txtAdditionalInformations.Text = strAdditionalInfo;
        }

        private void cboCoilComplexity_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fifthTabChanged = true;
            PriceCoil();
        }

        private void cboProfitMargin_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fifthTabChanged = true;
            PriceCoil();
        }

        private void numExchangeRate_ValueChanged(object sender, EventArgs e)
        {
            _fifthTabChanged = true;
            PriceCoil();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ThreadProcess.Start(Public.LanguageString("Preparing data", "Préparation des données"));

            FillTable_OEMCoil();
            FillTable_OEMCoilConnections();
            FillTable_OEMCoilDistributors();
            FillTable_OEMCoilFlareFittings();
            FillTable_OEMCoilPrice();

            //if press when form loaded from quote form
            if (_bolQuoteSelection)
            {
                int newIndexToPush;
                ThreadProcess.UpdateMessage(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                if (_intIndex != -1)
                {
                    var savingoption = new FrmSavingOption();

                    ThreadProcess.Stop();
                    Focus();
                    if (savingoption.ShowDialog() == DialogResult.Yes)
                    {//if he want to overwrite

                        //it's a modification unit so we delete and recreate records
                        _quoteform.DeleteFromQuoteOEMCoil(_intIndex);
                        newIndexToPush = _intIndex;
                        _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil), newIndexToPush);
                        //Quoteform.DeleteFromQuoteAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil));
                    }
                    else
                    {
                        //since we actually always recreate the record
                        // save as new is simple, all i have to do is copy the additionnal items
                        //if reused the update function to instead duplicate record.
                        newIndexToPush = _quoteform.GetNextID("OEMCoils");
                        _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil), newIndexToPush);

                    }

                    ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                }
                else
                {
                    newIndexToPush = _quoteform.GetNextID("OEMCoils");
                }

                AddToQuote(newIndexToPush);
                _quoteform.RefreshBasketList();
                _quoteform.SetQuoteIsModified(true);
                ThreadProcess.Stop();
                Focus();
                Dispose();
                //since even on update we need recreate the unit we will always add
            }
        }


        private void AddToQuote(int itemID)
        {
            _dtOEMCoil.Rows[0]["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil);
            _dtOEMCoil.Rows[0]["ItemID"] = itemID;
            _dsQuoteData.Tables["OEMCoils"].Rows.Add(_dtOEMCoil.Rows[0].ItemArray);
            DataTable copy = _dsQuoteData.Tables["OEMCoils"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["OEMCoils"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["OEMCoils"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Input_Tag"], row["Input_Quantity"], row["Input_Model"], row["Input_CustomerDrawingNumber"], row["Input_RefplusDrawingNumber"], row["Input_CasingMaterial"], row["Input_CasingThickness"], row["Input_FinMaterial"], row["Input_FinThickness"], row["Input_TubeMaterial"], row["Input_TubeThickness"], row["Input_ReturnBendsQuantity"], row["Input_EndPlateQuantity"], row["Input_EndPlateHeight"], row["Input_EndPlateWidth"], row["Input_TopPlateQuantity"], row["Input_TopPlateHeight"], row["Input_TopPlateWidth"], row["Input_BottomPlateQuantity"], row["Input_BottomPlateHeight"], row["Input_BottomPlateWidth"], row["Input_CenterPlateQuantity"], row["Input_CenterPlateHeight"], row["Input_CenterPlateWidth"], row["Input_WeldedCasing"], row["WeldedCasing"], row["NumberOfHeader"], row["Input_FlareFittings"], row["FlareFittings"], row["Input_Distributors"], row["Distributors"], row["Input_AuxiliarySideConnection"], row["AuxiliarySideConnection"], row["Input_WeldNut"], row["WeldNut"], row["Input_WeldNutQuantity"], row["Input_DrainPan"], row["DrainPan"], row["DrainPanQuantity"], row["DrainPanMaterial"], row["DrainPanHeight"], row["DrainPanWidth"], row["Input_Damper"], row["Damper"], row["DamperQuantity"], row["DamperHeight"], row["DamperWidth"], row["Input_SpecialCustomFittings"], row["SpecialCustomFittings"], row["SpecialCustomFittingsDescription"], row["SpecialCustomFittingsEstimatedCost"], row["Input_ThreadedConnections"], row["ThreadedConnections"], row["ThreadedConnectionsQuantity"], row["ThreadedConnectionsDiameter"], row["ThreadedConnectionsVentQuantity"], row["ThreadedConnectionsSpigotQuantity"], row["Input_CoilComplexity"], row["Input_ProfitMargin"], row["Input_ExchangeRate"], row["INput_AdditionalInformations"], row["MaterialCost"], row["LabourCalculated"], row["LabourCalculatedWithCorrection"], row["ManufacturingOverhead"], row["HourlyRate"], row["NetCostOfOEMCoil"], row["CoilWeight"]);
            }

            foreach (DataRow drOEMCoilConnection in _dtOEMCoilConnection.Rows)
            {
                drOEMCoilConnection["ItemType"] = _dtOEMCoil.Rows[0]["ItemType"];
                drOEMCoilConnection["ItemID"] = _dtOEMCoil.Rows[0]["ItemID"];
                _dsQuoteData.Tables["OEMCoilConnections"].Rows.Add(drOEMCoilConnection.ItemArray);
            }

            foreach (DataRow drOEMCoilDistributors in _dtOEMCoilDistributors.Rows)
            {
                drOEMCoilDistributors["ItemType"] = _dtOEMCoil.Rows[0]["ItemType"];
                drOEMCoilDistributors["ItemID"] = _dtOEMCoil.Rows[0]["ItemID"];
                _dsQuoteData.Tables["OEMCoilDistributors"].Rows.Add(drOEMCoilDistributors.ItemArray);
            }

            foreach (DataRow drOEMCoilFlareFitting in _dtOEMCoilFlareFitting.Rows)
            {
                drOEMCoilFlareFitting["ItemType"] = _dtOEMCoil.Rows[0]["ItemType"];
                drOEMCoilFlareFitting["ItemID"] = _dtOEMCoil.Rows[0]["ItemID"];
                _dsQuoteData.Tables["OEMCoilFlareFittings"].Rows.Add(drOEMCoilFlareFitting.ItemArray);
            }

            foreach (DataRow drOEMCoilPrice in _dtOEMCoilPrice.Rows)
            {
                drOEMCoilPrice["ItemType"] = _dtOEMCoil.Rows[0]["ItemType"];
                drOEMCoilPrice["ItemID"] = _dtOEMCoil.Rows[0]["ItemID"];
                _dsQuoteData.Tables["OEMCoilPrice"].Rows.Add(drOEMCoilPrice.ItemArray);
            }
        }

        private void FillTable_OEMCoilPrice()
        {
            _dtOEMCoilPrice = Tables.DtOEMCoilPrice();

            for (int i = 0; i < lstPrice.Items.Count; i++)
            {
                DataRow drOEMCoilPrice = _dtOEMCoilPrice.NewRow();

                drOEMCoilPrice["QuoteID"] = 0;
                drOEMCoilPrice["QuoteRevision"] = 0;
                drOEMCoilPrice["QuoteRevisionText"] = "";
                drOEMCoilPrice["ItemType"] = 0;
                drOEMCoilPrice["ItemID"] = 0;
                drOEMCoilPrice["Username"] = "";
                drOEMCoilPrice["PriceID"] = i;
                drOEMCoilPrice["Input_From"] = Convert.ToInt32(((NumericUpDown)lstPrice.Items[i].SubItems[0].Control).Value);
                drOEMCoilPrice["Input_To"] = Convert.ToInt32(((NumericUpDown)lstPrice.Items[i].SubItems[2].Control).Value);
                drOEMCoilPrice["Input_Price"] = Convert.ToDecimal(lstPrice.Items[i].SubItems[3].Text.Replace("$", "").Trim());

                _dtOEMCoilPrice.Rows.Add(drOEMCoilPrice);
            }
        }

        private void FillTable_OEMCoilFlareFittings()
        {
            _dtOEMCoilFlareFitting = Tables.DtOEMCoilFlareFittings();

            if (cboFlareFittings.Text == @"YES")
            {
                for (int i = 0; i < lstFlareFittings.Items.Count; i++)
                {
                    DataRow drOEMCoilFlareFittings = _dtOEMCoilFlareFitting.NewRow();

                    drOEMCoilFlareFittings["QuoteID"] = 0;
                    drOEMCoilFlareFittings["QuoteRevision"] = 0;
                    drOEMCoilFlareFittings["QuoteRevisionText"] = "";
                    drOEMCoilFlareFittings["ItemType"] = 0;
                    drOEMCoilFlareFittings["ItemID"] = 0;
                    drOEMCoilFlareFittings["Username"] = "";
                    drOEMCoilFlareFittings["FlareFittingsID"] = i;
                    drOEMCoilFlareFittings["Input_Quantity"] = Convert.ToInt32(((NumericUpDown)lstFlareFittings.Items[i].SubItems[0].Control).Value);
                    drOEMCoilFlareFittings["Input_Type"] = lstFlareFittings.Items[i].SubItems[1].Control.Text;
                    drOEMCoilFlareFittings["Input_Model"] = lstFlareFittings.Items[i].SubItems[2].Control.Text;

                    _dtOEMCoilFlareFitting.Rows.Add(drOEMCoilFlareFittings);
                }
            }
        }

        private void FillTable_OEMCoilDistributors()
        {
            _dtOEMCoilDistributors = Tables.DtOEMCoilDistributors();

            if (cboDistributors.Text == @"YES")
            {
                for (int i = 0; i < lstDistributor.Items.Count; i++)
                {
                    DataRow drOEMCoilDistributors = _dtOEMCoilDistributors.NewRow();

                    drOEMCoilDistributors["QuoteID"] = 0;
                    drOEMCoilDistributors["QuoteRevision"] = 0;
                    drOEMCoilDistributors["QuoteRevisionText"] = "";
                    drOEMCoilDistributors["ItemType"] = 0;
                    drOEMCoilDistributors["ItemID"] = 0;
                    drOEMCoilDistributors["Username"] = "";
                    drOEMCoilDistributors["DistributorsID"] = i;
                    drOEMCoilDistributors["Input_Circuit"] = Convert.ToInt32(((NumericUpDown)lstDistributor.Items[i].SubItems[0].Control).Value);
                    drOEMCoilDistributors["Input_Line"] = Convert.ToInt32(((NumericUpDown)lstDistributor.Items[i].SubItems[1].Control).Value);
                    drOEMCoilDistributors["Input_Spigot"] = Convert.ToInt32(((NumericUpDown)lstDistributor.Items[i].SubItems[2].Control).Value);
                    drOEMCoilDistributors["Input_Brand"] = lstDistributor.Items[i].SubItems[3].Control.Text;
                    drOEMCoilDistributors["Input_Model"] = lstDistributor.Items[i].SubItems[4].Control.Text;

                    _dtOEMCoilDistributors.Rows.Add(drOEMCoilDistributors);
                }
            }
        }

        private void FillTable_OEMCoilConnections()
        {
            _dtOEMCoilConnection = Tables.DtOEMCoilConnections();

            for (int i = 0; i < lstConnections.Items.Count; i++)
            {
                DataRow drOEMCoilConnections = _dtOEMCoilConnection.NewRow();

                drOEMCoilConnections["QuoteID"] = 0;
                drOEMCoilConnections["QuoteRevision"] = 0;
                drOEMCoilConnections["QuoteRevisionText"] = "";
                drOEMCoilConnections["ItemType"] = 0;
                drOEMCoilConnections["ItemID"] = 0;
                drOEMCoilConnections["Username"] = "";
                drOEMCoilConnections["ConnectionID"] = i;
                drOEMCoilConnections["Input_Size"] = Convert.ToDecimal(lstConnections.Items[i].SubItems[0].Control.Text);
                drOEMCoilConnections["Input_Length"] = ((NumericUpDown)lstConnections.Items[i].SubItems[1].Control).Value;

                _dtOEMCoilConnection.Rows.Add(drOEMCoilConnections);
            }
        }

        private void FillTable_OEMCoil()
        {
            _dtOEMCoil = Tables.DtOEMCoil();
            DataRow drOEMCoil = _dtOEMCoil.NewRow();

            drOEMCoil["QuoteID"] = 0;
            drOEMCoil["QuoteRevision"] = 0;
            drOEMCoil["QuoteRevisionText"] = "";
            drOEMCoil["ItemType"] = 0;
            drOEMCoil["ItemID"] = 0;
            drOEMCoil["Username"] = "";
            drOEMCoil["Input_Tag"] = txtTag.Text;
            drOEMCoil["Input_Quantity"] = 1;

            drOEMCoil["Input_Model"] = txtCoilModel.Text;
            drOEMCoil["Input_CustomerDrawingNumber"] = txtCustomerDrawingNumber.Text;
            drOEMCoil["Input_RefplusDrawingNumber"] = txtRefplusDrawingNo.Text;
            drOEMCoil["Input_CasingMaterial"] = cboCasingMaterial.Text;
            drOEMCoil["Input_CasingThickness"] = Convert.ToDecimal(cboCasingThickness.Text);
            drOEMCoil["Input_FinMaterial"] = cboFinMaterial.Text;
            drOEMCoil["Input_FinThickness"] = Convert.ToDecimal(cboFinThickness.Text);
            drOEMCoil["Input_TubeMaterial"] = cboTubeMaterial.Text;
            drOEMCoil["Input_TubeThickness"] = Convert.ToDecimal(cboTubeThickness.Text);
            drOEMCoil["Input_ReturnBendsQuantity"] = Convert.ToInt32(numReturnBends.Value);
            drOEMCoil["Input_EndPlateQuantity"] = Convert.ToInt32(numEndPlate.Value);
            drOEMCoil["Input_EndPlateHeight"] = numEndPlateHeight.Value;
            drOEMCoil["Input_EndPlateWidth"] = numEndPlateWidth.Value;
            drOEMCoil["Input_TopPlateQuantity"] = Convert.ToInt32(numTopPlate.Value);
            drOEMCoil["Input_TopPlateHeight"] = numTopPlateHeight.Value;
            drOEMCoil["Input_TopPlateWidth"] = numTopPlateWidth.Value;
            drOEMCoil["Input_BottomPlateQuantity"] = Convert.ToInt32(numBottomPlate.Value);
            drOEMCoil["Input_BottomPlateHeight"] = numBottomPlateHeight.Value;
            drOEMCoil["Input_BottomPlateWidth"] = numBottomPlateWidth.Value;
            drOEMCoil["Input_CenterPlateQuantity"] = Convert.ToInt32(numCenterPlate.Value);
            drOEMCoil["Input_CenterPlateHeight"] = numCenterPlateHeight.Value;
            drOEMCoil["Input_CenterPlateWidth"] = numCenterPlateWidth.Value;
            drOEMCoil["Input_WeldedCasing"] = cboWeldedCasing.Text;
            drOEMCoil["WeldedCasing"] = (cboWeldedCasing.Text == @"YES" ? 1 : 0);
            drOEMCoil["NumberOfHeader"] = lstConnections.Items.Count;
            drOEMCoil["Input_FlareFittings"] = cboFlareFittings.Text;
            drOEMCoil["FlareFittings"] = (cboFlareFittings.Text == @"YES" ? 1 : 0);
            drOEMCoil["Input_Distributors"] = cboDistributors.Text;
            drOEMCoil["Distributors"] = (cboDistributors.Text == @"YES" ? 1 : 0);
            drOEMCoil["Input_AuxiliarySideConnection"] = cboAuxiliarySideConnection.Text;
            drOEMCoil["AuxiliarySideConnection"] = (cboAuxiliarySideConnection.Text == @"YES" ? 1 : 0);
            drOEMCoil["Input_WeldNut"] = cboWeldNut.Text;
            drOEMCoil["WeldNut"] = (cboWeldNut.Text == @"YES" ? 1 : 0);
            drOEMCoil["Input_WeldNutQuantity"] = Convert.ToInt32(numWeldNutQuantity.Value);
            drOEMCoil["Input_DrainPan"] = cboDrainPan.Text;
            drOEMCoil["DrainPan"] = (cboDrainPan.Text == @"YES" ? 1 : 0);
            drOEMCoil["DrainPanQuantity"] = (cboDrainPan.Text == @"YES" ? Convert.ToInt32(((NumericUpDown)lstDrainPan.Items[0].SubItems[0].Control).Value) : 0);
            drOEMCoil["DrainPanMaterial"] = (cboDrainPan.Text == @"YES" ? lstDrainPan.Items[0].SubItems[1].Control.Text : "");
            drOEMCoil["DrainPanHeight"] = (cboDrainPan.Text == @"YES" ? ((NumericUpDown)lstDrainPan.Items[0].SubItems[2].Control).Value : 0m);
            drOEMCoil["DrainPanWidth"] = (cboDrainPan.Text == @"YES" ? ((NumericUpDown)lstDrainPan.Items[0].SubItems[3].Control).Value : 0m);
            drOEMCoil["Input_Damper"] = cboDamper.Text;
            drOEMCoil["Damper"] = (cboDamper.Text == @"YES" ? 1 : 0);
            drOEMCoil["DamperQuantity"] = (cboDamper.Text == @"YES" ? Convert.ToInt32(((NumericUpDown)lstDamper.Items[0].SubItems[0].Control).Value) : 0);
            drOEMCoil["DamperHeight"] = (cboDamper.Text == @"YES" ? ((NumericUpDown)lstDamper.Items[0].SubItems[1].Control).Value : 0m);
            drOEMCoil["DamperWidth"] = (cboDamper.Text == @"YES" ? ((NumericUpDown)lstDamper.Items[0].SubItems[2].Control).Value : 0m);
            drOEMCoil["Input_SpecialCustomFittings"] = cboSpecialCustomFitting.Text;
            drOEMCoil["SpecialCustomFittings"] = (cboSpecialCustomFitting.Text == @"YES" ? 1 : 0);
            drOEMCoil["SpecialCustomFittingsDescription"] = (cboSpecialCustomFitting.Text == @"YES" ? lstSpecialCustomFitting.Items[0].SubItems[0].Text : "");
            drOEMCoil["SpecialCustomFittingsEstimatedCost"] = (cboSpecialCustomFitting.Text == @"YES" ? ((NumericUpDown)lstSpecialCustomFitting.Items[0].SubItems[1].Control).Value : 0m);
            drOEMCoil["Input_ThreadedConnections"] = cboThreadedConnections.Text;
            drOEMCoil["ThreadedConnections"] = (cboThreadedConnections.Text == @"YES" ? 1 : 0);
            drOEMCoil["ThreadedConnectionsQuantity"] = (cboThreadedConnections.Text == @"YES" ? Convert.ToInt32(((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[0].Control).Value) : 0);
            drOEMCoil["ThreadedConnectionsDiameter"] = (cboThreadedConnections.Text == @"YES" ? Convert.ToDecimal(lstThreadedConnectionYes.Items[0].SubItems[1].Control.Text) : 0m);
            drOEMCoil["ThreadedConnectionsVentQuantity"] = (cboThreadedConnections.Text == @"YES" ? Convert.ToInt32(((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[2].Control).Value) : 0);
            drOEMCoil["ThreadedConnectionsSpigotQuantity"] = 0;
            if (pnlThreadedConnectionsOptionsNo.Visible)
            {
                drOEMCoil["ThreadedConnectionsSpigotQuantity"] = Convert.ToInt32(((NumericUpDown)lstThreadedConnectionNo.Items[0].SubItems[0].Control).Value);
            }
            if (pnlThreadedConnectionsOptionsYes.Visible)
            {
                drOEMCoil["ThreadedConnectionsSpigotQuantity"] = Convert.ToInt32(((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[3].Control).Value);
            }
            drOEMCoil["Input_CoilComplexity"] = cboCoilComplexity.Text;
            drOEMCoil["Input_ProfitMargin"] = Convert.ToDecimal(cboProfitMargin.Text);
            drOEMCoil["Input_ExchangeRate"] = numExchangeRate.Value;
            drOEMCoil["Input_AdditionalInformations"] = txtAdditionalInformations.Text;
            drOEMCoil["MaterialCost"] = _oemPricing.GetMaterialCost();
            drOEMCoil["LabourCalculated"] = _oemPricing.GetLabourCalculated();
            drOEMCoil["LabourCalculatedWithCorrection"] = _oemPricing.GetLabourCalculatedWithCorrection();
            drOEMCoil["ManufacturingOverhead"] = _oemPricing.GetManufacturingOverhead();
            drOEMCoil["HourlyRate"] = _oemPricing.GetHourlyRate();
            drOEMCoil["NetCostOfOEMCoil"] = _oemPricing.GetNetCostOfOEMCoil();
            drOEMCoil["CoilWeight"] = _oemPricing.GetWeight();

            _dtOEMCoil.Rows.Add(drOEMCoil);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmOEMCoil_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
        private void ValidateSecondTab()
        {
            if (cboCasingMaterial.FindString(_drSavedInfo["Input_CasingMaterial"].ToString()) >= 0)
            {
                cboCasingMaterial.SelectedIndex = cboCasingMaterial.FindString(_drSavedInfo["Input_CasingMaterial"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected casing material", "- Incapable de trouver le matériau de boîtier utilisé") + Environment.NewLine;
            }

            if (cboCasingThickness.FindString(_drSavedInfo["Input_CasingThickness"].ToString()) >= 0)
            {
                cboCasingThickness.SelectedIndex = cboCasingThickness.FindString(_drSavedInfo["Input_CasingThickness"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected casing thickness", "- Incapable de trouver l'épaisseur du matériau de boîtier") + Environment.NewLine;
            }

            if (cboFinMaterial.FindString(_drSavedInfo["Input_FinMaterial"].ToString()) >= 0)
            {
                cboFinMaterial.SelectedIndex = cboFinMaterial.FindString(_drSavedInfo["Input_FinMaterial"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected fin material", "- Incapable de trouver le matériau des ailettes utilisé") + Environment.NewLine;
            }

            if (cboFinThickness.FindString(_drSavedInfo["Input_FinThickness"].ToString()) >= 0)
            {
                cboFinThickness.SelectedIndex = cboFinThickness.FindString(_drSavedInfo["Input_FinThickness"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected fin thickness", "- Incapable de trouver l'épaisseur du matériau des ailettes") + Environment.NewLine;
            }

            if (cboTubeMaterial.FindString(_drSavedInfo["Input_TubeMaterial"].ToString()) >= 0)
            {
                cboTubeMaterial.SelectedIndex = cboTubeMaterial.FindString(_drSavedInfo["Input_TubeMaterial"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected tube material", "- Incapable de trouver le matériau des tubes utilisé") + Environment.NewLine;
            }

            if (cboTubeThickness.FindString(_drSavedInfo["Input_TubeThickness"].ToString()) >= 0)
            {
                cboTubeThickness.SelectedIndex = cboTubeThickness.FindString(_drSavedInfo["Input_TubeThickness"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected tube thickness", "- Incapable de trouver l'épaisseur du matériau des tubes") + Environment.NewLine;
            }
        }
        private void ValidateThirdTab()
        {
            numReturnBends.Value = Convert.ToDecimal(_drSavedInfo["Input_ReturnBendsQuantity"]);

            numEndPlate.Value = Convert.ToDecimal(_drSavedInfo["Input_EndPlateQuantity"]);
            numEndPlateHeight.Value = Convert.ToDecimal(_drSavedInfo["Input_EndPlateHeight"]);
            numEndPlateWidth.Value = Convert.ToDecimal(_drSavedInfo["Input_EndPlateWidth"]);

            numTopPlate.Value = Convert.ToDecimal(_drSavedInfo["Input_TopPlateQuantity"]);
            numTopPlateHeight.Value = Convert.ToDecimal(_drSavedInfo["Input_TopPlateHeight"]);
            numTopPlateWidth.Value = Convert.ToDecimal(_drSavedInfo["Input_TopPlateWidth"]);

            numBottomPlate.Value = Convert.ToDecimal(_drSavedInfo["Input_BottomPlateQuantity"]);
            numBottomPlateHeight.Value = Convert.ToDecimal(_drSavedInfo["Input_BottomPlateHeight"]);
            numBottomPlateWidth.Value = Convert.ToDecimal(_drSavedInfo["Input_BottomPlateWidth"]);

            numCenterPlate.Value = Convert.ToDecimal(_drSavedInfo["Input_CenterPlateQuantity"]);
            numCenterPlateHeight.Value = Convert.ToDecimal(_drSavedInfo["Input_CenterPlateHeight"]);
            numCenterPlateWidth.Value = Convert.ToDecimal(_drSavedInfo["Input_CenterPlateWidth"]);

            if (cboWeldedCasing.FindString(_drSavedInfo["Input_WeldedCasing"].ToString()) >= 0)
            {
                cboWeldedCasing.SelectedIndex = cboWeldedCasing.FindString(_drSavedInfo["Input_WeldedCasing"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected welded casing option", "- Incapable de trouver l'option sélectionnée pour le boîtier soudé") + Environment.NewLine;
            }

            if (_strErrors == "")
            {
                DataTable dtConnections = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilConnections"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil).ToString(CultureInfo.InvariantCulture) + " AND ItemID = " + _intIndex.ToString(CultureInfo.InvariantCulture), "ConnectionID");

                for (int i = 0; i < dtConnections.Rows.Count; i++)
                {
                    AddConnection();

                    if (((ComboBox)lstConnections.Items[i].SubItems[0].Control).FindString(dtConnections.Rows[i]["Input_Size"].ToString()) >= 0)
                    {
                        ((ComboBox)lstConnections.Items[i].SubItems[0].Control).SelectedIndex = ((ComboBox)lstConnections.Items[i].SubItems[0].Control).FindString(dtConnections.Rows[i]["Input_Size"].ToString());
                    }
                    else
                    {
                        _strErrors = _strErrors + Public.LanguageString("- Cannot find selected size for connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture), "- Incapable de trouver la grosseur de la connection #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture)) + Environment.NewLine;
                    }

                    ((NumericUpDown)lstConnections.Items[i].SubItems[1].Control).Value = Convert.ToDecimal(dtConnections.Rows[i]["Input_Length"]);
                }


            }
        }
        private void ValidateFourthTab()
        {
            if (pnlFlareFittings.Visible)
            {
                if (cboFlareFittings.FindString(_drSavedInfo["Input_FlareFittings"].ToString()) >= 0)
                {
                    cboFlareFittings.SelectedIndex = cboFlareFittings.FindString(_drSavedInfo["Input_FlareFittings"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected flare fittings option", "- Incapable de trouver l'option sélectionnée pour les tubes évasés") + Environment.NewLine;
                }
            }

            if (pnlFlareFittingsOptions.Visible)
            {
                DataTable dtFlare = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilFlareFittings"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil).ToString(CultureInfo.InvariantCulture) + " AND ItemID = " + _intIndex.ToString(CultureInfo.InvariantCulture), "FlareFittingsID");

                for (int i = 0; i < dtFlare.Rows.Count; i++)
                {
                    ((NumericUpDown)lstFlareFittings.Items[i].SubItems[0].Control).Value = Convert.ToDecimal(dtFlare.Rows[i]["Input_Quantity"]);

                    if (((ComboBox)lstFlareFittings.Items[i].SubItems[1].Control).FindString(dtFlare.Rows[i]["Input_Type"].ToString()) >= 0)
                    {
                        ((ComboBox)lstFlareFittings.Items[i].SubItems[1].Control).SelectedIndex = ((ComboBox)lstFlareFittings.Items[i].SubItems[1].Control).FindString(dtFlare.Rows[i]["Input_Type"].ToString());
                    }
                    else
                    {
                        _strErrors = _strErrors + Public.LanguageString("- Cannot find selected type for flare fitting #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture), "- Incapable de trouver le type pour le raccord pour tube évasé #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture)) + Environment.NewLine;
                    }

                    if (((ComboBox)lstFlareFittings.Items[i].SubItems[2].Control).FindString(dtFlare.Rows[i]["Input_Model"].ToString()) >= 0)
                    {
                        ((ComboBox)lstFlareFittings.Items[i].SubItems[2].Control).SelectedIndex = ((ComboBox)lstFlareFittings.Items[i].SubItems[2].Control).FindString(dtFlare.Rows[i]["Input_Model"].ToString());
                    }
                    else
                    {
                        _strErrors = _strErrors + Public.LanguageString("- Cannot find selected model for flare fitting #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture), "- Incapable de trouver le modèle pour le raccord pour tube évasé #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture)) + Environment.NewLine;
                    }
                }
            }

            if (pnlDistributor.Visible)
            {
                if (cboDistributors.FindString(_drSavedInfo["Input_Distributors"].ToString()) >= 0)
                {
                    cboDistributors.SelectedIndex = cboDistributors.FindString(_drSavedInfo["Input_Distributors"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected distributor option", "- Incapable de trouver l'option sélectionnée pour les distributeurs") + Environment.NewLine;
                }
            }

            if (pnlDistributorOptions.Visible)
            {
                DataTable dtDistributors = Public.SelectAndSortTable(_dsQuoteData.Tables["OEMCoilDistributors"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.OEMCoil).ToString(CultureInfo.InvariantCulture) + " AND ItemID = " + _intIndex.ToString(CultureInfo.InvariantCulture), "DistributorsID");

                for (int i = 0; i < dtDistributors.Rows.Count; i++)
                {
                    ((NumericUpDown)lstDistributor.Items[i].SubItems[0].Control).Value = Convert.ToDecimal(dtDistributors.Rows[i]["Input_Circuit"]);
                    ((NumericUpDown)lstDistributor.Items[i].SubItems[1].Control).Value = Convert.ToDecimal(dtDistributors.Rows[i]["Input_Line"]);
                    ((NumericUpDown)lstDistributor.Items[i].SubItems[2].Control).Value = Convert.ToDecimal(dtDistributors.Rows[i]["Input_Spigot"]);

                    if (((ComboBox)lstDistributor.Items[i].SubItems[3].Control).FindString(dtDistributors.Rows[i]["Input_Brand"].ToString()) >= 0)
                    {
                        ((ComboBox)lstDistributor.Items[i].SubItems[3].Control).SelectedIndex = ((ComboBox)lstDistributor.Items[i].SubItems[3].Control).FindString(dtDistributors.Rows[i]["Input_Brand"].ToString());
                    }
                    else
                    {
                        _strErrors = _strErrors + Public.LanguageString("- Cannot find selected brand for distributor #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture), "- Incapable de trouver la marque pour le distributeur #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture)) + Environment.NewLine;
                    }

                    if (((ComboBox)lstDistributor.Items[i].SubItems[4].Control).FindString(dtDistributors.Rows[i]["Input_Model"].ToString()) >= 0)
                    {
                        ((ComboBox)lstDistributor.Items[i].SubItems[4].Control).SelectedIndex = ((ComboBox)lstDistributor.Items[i].SubItems[4].Control).FindString(dtDistributors.Rows[i]["Input_Model"].ToString());
                    }
                    else
                    {
                        _strErrors = _strErrors + Public.LanguageString("- Cannot find selected model for distributor #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture), "- Incapable de trouver la modèle pour le distributeur #" + Convert.ToInt32(i + 1).ToString(CultureInfo.InvariantCulture)) + Environment.NewLine;
                    }
                }
            }

            if (pnlAuxiliarySideConnection.Visible)
            {
                if (cboAuxiliarySideConnection.FindString(_drSavedInfo["Input_AuxiliarySideConnection"].ToString()) >= 0)
                {
                    cboAuxiliarySideConnection.SelectedIndex = cboAuxiliarySideConnection.FindString(_drSavedInfo["Input_AuxiliarySideConnection"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected auxiliary side connection option", "- Incapable de trouver l'option sélectionnée pour les connections auxiliaires") + Environment.NewLine;
                }
            }

            if (pnlWeldNut.Visible)
            {
                if (cboWeldNut.FindString(_drSavedInfo["Input_WeldNut"].ToString()) >= 0)
                {
                    cboWeldNut.SelectedIndex = cboWeldNut.FindString(_drSavedInfo["Input_WeldNut"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected weld nut option", "- Incapable de trouver l'option sélectionner pour les écrous soudés") + Environment.NewLine;
                }

                if (pnlWeldNutOptions.Visible)
                {
                    numWeldNutQuantity.Value = Convert.ToDecimal(_drSavedInfo["Input_WeldNutQuantity"]);
                }
            }

            if (pnlDrainPan.Visible)
            {
                if (cboDrainPan.FindString(_drSavedInfo["Input_DrainPan"].ToString()) >= 0)
                {
                    cboDrainPan.SelectedIndex = cboDrainPan.FindString(_drSavedInfo["Input_DrainPan"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected drain pan option", "- Incapable de trouver l'option sélectionnée pour les égouttoirs") + Environment.NewLine;
                }

                if (pnlDrainPanOptions.Visible)
                {
                    ((NumericUpDown)lstDrainPan.Items[0].SubItems[0].Control).Value = Convert.ToDecimal(_drSavedInfo["DrainPanQuantity"]);

                    if (((ComboBox)lstDrainPan.Items[0].SubItems[1].Control).FindString(_drSavedInfo["DrainPanMaterial"].ToString()) >= 0)
                    {
                        ((ComboBox)lstDrainPan.Items[0].SubItems[1].Control).SelectedIndex = ((ComboBox)lstDrainPan.Items[0].SubItems[1].Control).FindString(_drSavedInfo["DrainPanMaterial"].ToString());
                    }
                    else
                    {
                        _strErrors = _strErrors + Public.LanguageString("- Cannot find selected drain pan material", "- Incapable de trouver le matériel sélectionné pour les égouttoirs") + Environment.NewLine;
                    }

                    ((NumericUpDown)lstDrainPan.Items[0].SubItems[2].Control).Value = Convert.ToDecimal(_drSavedInfo["DrainPanHeight"]);
                    ((NumericUpDown)lstDrainPan.Items[0].SubItems[3].Control).Value = Convert.ToDecimal(_drSavedInfo["DrainPanWidth"]);
                }
            }

            if (pnlDamper.Visible)
            {
                if (cboDamper.FindString(_drSavedInfo["Input_Damper"].ToString()) >= 0)
                {
                    cboDamper.SelectedIndex = cboDamper.FindString(_drSavedInfo["Input_Damper"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected damper option", "- Incapable de trouver l'option sélectionnée pour les amortisseurs") + Environment.NewLine;
                }

                if (pnlDamperOptions.Visible)
                {
                    ((NumericUpDown)lstDamper.Items[0].SubItems[0].Control).Value = Convert.ToDecimal(_drSavedInfo["DamperQuantity"]);
                    ((NumericUpDown)lstDamper.Items[0].SubItems[1].Control).Value = Convert.ToDecimal(_drSavedInfo["DamperHeight"]);
                    ((NumericUpDown)lstDamper.Items[0].SubItems[2].Control).Value = Convert.ToDecimal(_drSavedInfo["DamperWidth"]);
                }
            }

            if (pnlSpecialCustomFitting.Visible)
            {
                if (cboSpecialCustomFitting.FindString(_drSavedInfo["Input_SpecialCustomFittings"].ToString()) >= 0)
                {
                    cboSpecialCustomFitting.SelectedIndex = cboSpecialCustomFitting.FindString(_drSavedInfo["Input_SpecialCustomFittings"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected special custom fittings option", "- Incapable de trouver l'option sélectionnée pour les raccords spéciaux personalisés") + Environment.NewLine;
                }

                if (pnlSpecialCustomFittingOptions.Visible)
                {
                    lstSpecialCustomFitting.Items[0].SubItems[0].Text = _drSavedInfo["SpecialCustomFittingsDescription"].ToString();
                    ((NumericUpDown)lstSpecialCustomFitting.Items[0].SubItems[1].Control).Value = Convert.ToDecimal(_drSavedInfo["SpecialCustomFittingsEstimatedCost"]);
                }
            }

            if (pnlThreadedConnections.Visible)
            {
                if (cboThreadedConnections.FindString(_drSavedInfo["Input_ThreadedConnections"].ToString()) >= 0)
                {
                    cboThreadedConnections.SelectedIndex = cboThreadedConnections.FindString(_drSavedInfo["Input_ThreadedConnections"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected threaded connections option", "- Incapable de trouver l'option sélectionnée pour les raccords filetés") + Environment.NewLine;
                }
            }

            if (pnlThreadedConnectionsOptionsNo.Visible)
            {
                ((NumericUpDown)lstThreadedConnectionNo.Items[0].SubItems[0].Control).Value = Convert.ToDecimal(_drSavedInfo["ThreadedConnectionsSpigotQuantity"]);
            }

            if (pnlThreadedConnectionsOptionsYes.Visible)
            {
                ((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[0].Control).Value = Convert.ToDecimal(_drSavedInfo["ThreadedConnectionsQuantity"]);

                if (((ComboBox)lstThreadedConnectionYes.Items[0].SubItems[1].Control).FindString(_drSavedInfo["ThreadedConnectionsDiameter"].ToString()) >= 0)
                {
                    ((ComboBox)lstThreadedConnectionYes.Items[0].SubItems[1].Control).SelectedIndex = ((ComboBox)lstThreadedConnectionYes.Items[0].SubItems[1].Control).FindString(_drSavedInfo["ThreadedConnectionsDiameter"].ToString());
                }
                else
                {
                    _strErrors = _strErrors + Public.LanguageString("- Cannot find selected threaded connections option", "- Incapable de trouver l'option sélectionnée pour les raccords fileté") + Environment.NewLine;
                }

                ((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[2].Control).Value = Convert.ToDecimal(_drSavedInfo["ThreadedConnectionsVentQuantity"]);
                ((NumericUpDown)lstThreadedConnectionYes.Items[0].SubItems[3].Control).Value = Convert.ToDecimal(_drSavedInfo["ThreadedConnectionsSpigotQuantity"]);
            }
        }
        private void ValidateFifthTab()
        {
            if (cboCoilComplexity.FindString(_drSavedInfo["Input_CoilComplexity"].ToString()) >= 0)
            {
                cboCoilComplexity.SelectedIndex = cboCoilComplexity.FindString(_drSavedInfo["Input_CoilComplexity"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected coil complexity", "- Incapable de trouver la complexité du serpentin sélectionné") + Environment.NewLine;
            }

            if (cboProfitMargin.FindString(_drSavedInfo["Input_ProfitMargin"].ToString()) >= 0)
            {
                cboProfitMargin.SelectedIndex = cboProfitMargin.FindString(_drSavedInfo["Input_ProfitMargin"].ToString());
            }
            else
            {
                _strErrors = _strErrors + Public.LanguageString("- Cannot find selected profit margin ", "- Incapable de trouver la marge de profit sélectionnée") + Environment.NewLine;
            }

            numExchangeRate.Value = Convert.ToDecimal(_drSavedInfo["Input_ExchangeRate"]);

            txtAdditionalInformations.Text = _drSavedInfo["Input_AdditionalInformations"].ToString();
        }

        private void txtCoilModel_TextChanged(object sender, EventArgs e)
        {
            _modelChanged = true;
        }

        private void cboCasingThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            _secondTabChanged = true;
        }

        private void cboFinThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            _secondTabChanged = true;
        }

        private void cboTubeThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            _secondTabChanged = true;
        }

        private void numReturnBends_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numEndPlate_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numEndPlateHeight_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numEndPlateWidth_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numTopPlate_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numTopPlateHeight_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numTopPlateWidth_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numBottomPlate_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numBottomPlateHeight_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numBottomPlateWidth_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numCenterPlate_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numCenterPlateHeight_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numCenterPlateWidth_ValueChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void cboWeldedCasing_SelectedIndexChanged(object sender, EventArgs e)
        {
            _thirdTabChanged = true;
        }

        private void numWeldNutQuantity_ValueChanged(object sender, EventArgs e)
        {
            _fourthTabChanged = true;
        }


    }


}