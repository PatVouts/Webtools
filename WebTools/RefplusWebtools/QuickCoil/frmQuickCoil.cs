using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCoil
{
    public partial class FrmQuickCoil : Form
    {
        //form need access to his background code
        private readonly QuickCoilCode _backgroundCode = new QuickCoilCode();

        private decimal _freezingP;
        //table containing all the coil information and return value
        private readonly DataTable _dtQuickCoil = Tables.DtQuickCoil();

        //tabel that contain the Manual Coil Data
        private readonly DataTable _dtQuickManualCoil = Tables.DtQuickManualCoil();

        //contains temporary sqls to run whenever customFluid is confirmed
        private string _sqlToRun;

        //this is the list of tables the form need to work
        private readonly string[] _strTableList = { "CoilFinType", "v_CoilfinDefaults", "v_CoilTubeDefaults", "CoilFinShape", "v_CoilFinTypeDefaults", "CoilType", "CoilFinMaterial", "CoilfinThickness", "CoilTubeMaterial", "CoilTubeThickness", "CoilFluidType", "v_CoilCasingMaterialDefaults", "CoilCasingThickness", "v_CoilHeaderDiameter", "Weather", "FreezingPointEthylene", "FreezingPointPropylene", "CoilFinTypeShape", "ElectroFinAdjustement", "HeresiteSafety", "CoilSteamMPTConnection", "ConnectionSize_Condenser", "ConnectionSize_DX", "ConnectionSize_FluidHeating_FluidCooling", "ConnectionSize_HeatReclaim", "ConnectionSize_PoundsPerFoot", "StandardConnectionCondenserInlet", "StandardConnectionCondenserOutlet", "StandardConnectionDXInlet", "StandardConnectionDXOutlet", "CoilFrameSize", "CoilTurbulatorPriceFactor", "CoilCasingMaterial" };
        //boolean used in the connection size to prevent a possible endless
        //loop in the selection of the connection, since Heat reclaim need
        //to match same size on both connection it can cause problem
        private bool _bolHRConnectionPreventEndlessLoop = true;

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;

        private readonly int _intPosition = -1;

        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        public enum CoilOpenType { Manual, Selection };

        private readonly CoilOpenType _openType = CoilOpenType.Selection;

        public Label LblCoatingPriceDetail = new Label();

        private bool _formIsLoading = true;

        private FrmOtherFluid _otherFluid;

        public FrmQuickCoil()
        {
            InitializeComponent();
        }

        public FrmQuickCoil(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex, CoilOpenType openType, int intPosition)
        {
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;
            _openType = openType;
            _intPosition = intPosition;

            if (_openType == CoilOpenType.Manual)
            {
                InitializeComponentManualMode();
                InstanciateCoatingPriceDetailLabel();
                txtManualModelName.LostFocus += txtManualModelName_LostFocus;
                cboManualConnectionSize.SelectedIndexChanged += cboManualConnectionSize_SelectedIndexChanged;
                pnlSelectionMode.Visible = false;
                pnlSelectionMode.SendToBack();
                OverwriteSteamConnectionsForManualSelection();
                AddManualControlToForm();
                RellocateAllControlsForManualSelectionMode();
            }
            else
            {
                InitializeComponent();
            }
        }

        private bool HaveAccessToKFinAndR744()
        {
            //admin and Refplus group
            return (UserInformation.UserName == "admin" || UserInformation.GroupID == 0 || UserInformation.Userlevel > 79);
        }

        private void TemporaryR744Blocking()
        {
            //2012-07-30 : #2998 : temporary blocking co2. also code for k fin in fill_fintype
            if (!HaveAccessToKFinAndR744())
            {
                cboDX_RefrigerantType.Items.RemoveAt(cboDX_RefrigerantType.Items.Count - 1);
                cboHR_RefrigerantType.Items.RemoveAt(cboHR_RefrigerantType.Items.Count - 1);
            }
        }

        private void cboManualConnectionSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strCoilType = CoilTypeParameter();

            switch (strCoilType)
            {
                case "DX":
                    cboDX_ConnectionSizeInlet.SelectedIndex = cboDX_ConnectionSizeInlet.FindString(cboManualConnectionSize.Text);
                    cboDX_ConnectionSizeOutlet.SelectedIndex = cboDX_ConnectionSizeOutlet.FindString(cboManualConnectionSize.Text);
                    break;
                case "HR":
                    cboHR_ConnectionSizeIn.SelectedIndex = cboHR_ConnectionSizeIn.FindString(cboManualConnectionSize.Text);
                    cboHR_ConnectionSizeOut.SelectedIndex = cboHR_ConnectionSizeOut.FindString(cboManualConnectionSize.Text);
                    break;
                case "FH":
                    cboFH_ConnectionSize.SelectedIndex = cboFH_ConnectionSize.FindString(cboManualConnectionSize.Text);
                    break;
                case "FC":
                    cboFC_ConnectionSize.SelectedIndex = cboFC_ConnectionSize.FindString(cboManualConnectionSize.Text);
                    break;
                case "ST":
                    cboSTEAM_SteamConnection.SelectedIndex = cboSTEAM_SteamConnection.FindString(cboManualConnectionSize.Text);
                    cboSTEAM_CondensateConnection.SelectedIndex = cboSTEAM_CondensateConnection.FindString(cboManualConnectionSize.Text);
                    break;
            }

            //Fill_CoilCoatingManualSelection();
        }

        private void txtManualModelName_LostFocus(object sender, EventArgs e)
        {
            ValidateManualModel();
        }


        private void OverwriteSteamConnectionsForManualSelection()
        {
            cboSTEAM_SteamConnection.Items.Clear();
            cboSTEAM_SteamConnection.Items.Add("0.50");
            cboSTEAM_SteamConnection.Items.Add("1.00");
            cboSTEAM_SteamConnection.Items.Add("1.50");
            cboSTEAM_SteamConnection.Items.Add("2.00");
            cboSTEAM_SteamConnection.Items.Add("2.50");
            cboSTEAM_SteamConnection.Items.Add("3.00");
            cboSTEAM_SteamConnection.Items.Add("3.50");
            cboSTEAM_SteamConnection.Items.Add("4.00");
            cboSTEAM_SteamConnection.Items.Add("4.50");

            cboSTEAM_CondensateConnection.Items.Clear();
            cboSTEAM_CondensateConnection.Items.Add("0.50");
            cboSTEAM_CondensateConnection.Items.Add("1.00");
            cboSTEAM_CondensateConnection.Items.Add("1.50");
            cboSTEAM_CondensateConnection.Items.Add("2.00");
            cboSTEAM_CondensateConnection.Items.Add("2.50");
            cboSTEAM_CondensateConnection.Items.Add("3.00");
            cboSTEAM_CondensateConnection.Items.Add("3.50");
            cboSTEAM_CondensateConnection.Items.Add("4.00");
            cboSTEAM_CondensateConnection.Items.Add("4.50");
        }

        private void InstanciateCoatingPriceDetailLabel()
        {
            LblCoatingPriceDetail = new Label
            {
                AutoSize = false,
                Width = 80,
                Height = 20,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            Controls.Add(LblCoatingPriceDetail);
        }

        private void RellocateAllControlsForManualSelectionMode()
        {
            try
            {
                //LABEL
                //X = 10, Y = 10
                //INCREMENT
                //X = X, Y = Y + 10

                //CONTROL
                //X = Label X + 176
                //Y = Label Y - 3

                const int x = 10;
                int y = 10;

                const int yincrement = 23;

                const int xadder = 176;
                const int yAdder = -3;

                int controlWidth = cboCoilType.Width;

                lblModelName.Left = x;
                lblModelName.Top = y;
                txtManualModelName.Left = x + xadder;
                txtManualModelName.Top = y + yAdder;
                y += yincrement;

                lblCoilType.Visible = false;
                cboCoilType.Visible = false;

                //lblCoilType.Left = X; lblCoilType.Top = Y;
                //cboCoilType.Left = X + Xadder; cboCoilType.Top = Y + YAdder;
                //Y += Yincrement;

                lblConstructionType.Visible = false;
                cboConstructionType.Visible = false;
                //lblConstructionType.Left = X; lblConstructionType.Top = Y;
                //cboConstructionType.Left = X + Xadder; cboConstructionType.Top = Y + YAdder;
                //cboConstructionType.Width = ControlWidth;
                //Y += Yincrement;

                lblConnectionSide.Left = x;
                lblConnectionSide.Top = y;
                cboConnectionSide.Left = x + xadder;
                cboConnectionSide.Top = y + yAdder;
                cboConnectionSide.Width = controlWidth;
                y += yincrement;

                lblCasingMaterial.Left = x;
                lblCasingMaterial.Top = y;
                cboCasingMaterial.Left = x + xadder;
                cboCasingMaterial.Top = y + yAdder;
                cboCasingMaterial.Width = controlWidth;
                y += yincrement;

                lblCasingThickness.Left = x;
                lblCasingThickness.Top = y;
                cboCasingThickness.Left = x + xadder;
                cboCasingThickness.Top = y + yAdder;
                cboCasingThickness.Width = controlWidth;
                y += yincrement;

                lblTag.Left = x;
                lblTag.Top = y;
                txtTag.Left = x + xadder;
                txtTag.Top = y + yAdder;
                txtTag.Width = controlWidth;
                y += yincrement;

                lblQuantity.Left = x;
                lblQuantity.Top = y;
                numQuantity.Left = x + xadder;
                numQuantity.Top = y + yAdder;
                numQuantity.Width = controlWidth;
                y += yincrement;

                lblFinType.Left = x;
                lblFinType.Top = y;
                cboFinType.Left = x + xadder;
                cboFinType.Top = y + yAdder;
                cboFinType.Width = controlWidth;
                y += yincrement;
                cboFinType.Enabled = false;
                cboFinType.BackColor = Color.White;

                lblFinShape.Left = x;
                lblFinShape.Top = y;
                cboFinShape.Left = x + xadder;
                cboFinShape.Top = y + yAdder;
                cboFinShape.Width = controlWidth;
                y += yincrement;
                cboFinShape.Enabled = false;
                cboFinShape.BackColor = Color.White;

                lblFinHeight.Left = x;
                lblFinHeight.Top = y;
                cboFinHeight.Left = x + xadder;
                cboFinHeight.Top = y + yAdder;
                cboFinHeight.Width = controlWidth;
                y += yincrement;
                cboFinHeight.Enabled = false;
                cboFinHeight.BackColor = Color.White;

                lblFinLength.Left = x;
                lblFinLength.Top = y;
                numFinLength.Left = x + xadder;
                numFinLength.Top = y + yAdder;
                numFinLength.Width = controlWidth;
                y += yincrement;
                numFinLength.Enabled = false;
                numFinLength.BackColor = Color.White;

                lblRow.Left = x;
                lblRow.Top = y;
                numRow.Left = x + xadder;
                numRow.Top = y + yAdder;
                numRow.Width = controlWidth;
                y += yincrement;
                numRow.Enabled = false;
                numRow.BackColor = Color.White;

                lblFPI.Left = x;
                lblFPI.Top = y;
                cboFPI.Left = x + xadder;
                cboFPI.Top = y + yAdder;
                cboFPI.Width = controlWidth;
                y += yincrement;
                cboFPI.Enabled = false;
                cboFPI.BackColor = Color.White;

                lblFinMaterial.Left = x;
                lblFinMaterial.Top = y;
                cboFinMaterial.Left = x + xadder;
                cboFinMaterial.Top = y + yAdder;
                cboFinMaterial.Width = controlWidth;
                y += yincrement;

                lblFinThickness.Left = x;
                lblFinThickness.Top = y;
                cboFinThickness.Left = x + xadder;
                cboFinThickness.Top = y + yAdder;
                cboFinThickness.Width = controlWidth;
                y += yincrement;

                lblTubeMaterial.Left = x;
                lblTubeMaterial.Top = y;
                cboTubeMaterial.Left = x + xadder;
                cboTubeMaterial.Top = y + yAdder;
                cboTubeMaterial.Width = controlWidth;
                y += yincrement;

                lblTubeThickness.Left = x;
                lblTubeThickness.Top = y;
                cboTubeThickness.Left = x + xadder;
                cboTubeThickness.Top = y + yAdder;
                cboTubeThickness.Width = controlWidth;
                y += yincrement;

                lblTurbulators.Left = x;
                lblTurbulators.Top = y;
                cboTurbulator.Left = x + xadder;
                cboTurbulator.Top = y + yAdder;
                cboTurbulator.Width = controlWidth;
                y += yincrement;


                lblFH_DesignType.Visible = false;
                cboFH_DesignType.Visible = false;
                lblFH_ConnectionSize.Visible = false;
                cboFH_ConnectionSize.Visible = false;
                lblFH_HeaderQuantity.Visible = false;
                cboFH_HeaderQuantity.Visible = false;
                lblHR_CoilDesign.Visible = false;
                cboHR_CoilDesign.Visible = false;
                lblHR_HeaderQuantity.Visible = false;
                cboHR_HeaderQuantity.Visible = false;
                lblHR_ConnectionSizeIn.Visible = false;
                cboHR_ConnectionSizeIn.Visible = false;
                lblHR_ConnectionSizeOut.Visible = false;
                cboHR_ConnectionSizeOut.Visible = false;
                lblFC_DesignType.Visible = false;
                cboFC_DesignType.Visible = false;
                lblFC_ConnectionSize.Visible = false;
                cboFC_ConnectionSize.Visible = false;
                lblFC_ConnectionType.Visible = false;
                cboFC_ConnectionType.Visible = false;
                lblFC_HeaderQuantity.Visible = false;
                cboFC_HeaderQuantity.Visible = false;
                lblDX_ConnectionSizeInlet.Visible = false;
                cboDX_ConnectionSizeInlet.Visible = false;
                lblDX_ConnectionSizeOutput.Visible = false;
                cboDX_ConnectionSizeOutlet.Visible = false;
                lblDX_HeaderQuantity.Visible = false;
                cboDX_HeaderQuantity.Visible = false;
                lblSTEAM_CoilType.Visible = false;
                cboSTEAM_CoilType.Visible = false;
                lblSTEAM_SteamConnection.Visible = false;
                cboSTEAM_SteamConnection.Visible = false;
                lblSTEAM_CondensateConnection.Visible = false;
                cboSTEAM_CondensateConnection.Visible = false;

                Fill_ManualSelectionConnections();

                if (CoilTypeParameter() == "FC")
                {
                    lblFC_ConnectionType.Visible = true;
                    cboFC_ConnectionType.Visible = true;
                    lblFC_ConnectionType.Left = x;
                    lblFC_ConnectionType.Top = y;
                    cboFC_ConnectionType.Left = x + xadder;
                    cboFC_ConnectionType.Top = y + yAdder;
                    cboFC_ConnectionType.Width = controlWidth;
                    y += yincrement;
                }

                lblManualConnectionSize.Left = x;
                lblManualConnectionSize.Top = y;
                cboManualConnectionSize.Left = x + xadder;
                cboManualConnectionSize.Top = y + yAdder;
                cboManualConnectionSize.Width = controlWidth;
                y += yincrement;

                lblCoilCoating.Left = x;
                lblCoilCoating.Top = y;
                cboCoilCoating.Left = x + xadder;
                cboCoilCoating.Top = y + yAdder;
                cboCoilCoating.Width = controlWidth - LblCoatingPriceDetail.Width /*Price shows up aside*/- 5
                    /*let a little distance in between*/;

                LblCoatingPriceDetail.Left = cboCoilCoating.Right /*put it aside the coating*/+ 5
                    /*add little gap in between*/;
                LblCoatingPriceDetail.Top = y + yAdder;
                y += yincrement;

                lblSampleCoil.Left = x;
                lblSampleCoil.Top = y;
                chkSampleCoil.Left = x + xadder;
                chkSampleCoil.Top = y + yAdder;
                y += yincrement;

                cmdSave.Left = x;
                cmdSave.Top = y;
                cmdSave.Width = xadder + controlWidth;
                y += yincrement;

                Height = y + cmdSave.Height + x;
                Width = x + xadder + controlWidth + x;
                Refresh();

            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickCoil RellocateAllControlsForManualSelectionMode");
            }
        }

        private void Fill_ManualSelectionConnections()
        {
            cboManualConnectionSize.Items.Clear();

            string strCoilType = CoilTypeParameter();
            switch (strCoilType)
            {
                case "DX":
                    for (int i = 0; i < cboDX_ConnectionSizeInlet.Items.Count; i++)
                    {
                        var cConnection = (CBOITEM)cboDX_ConnectionSizeInlet.Items[i];
                        cboManualConnectionSize.Items.Add(cConnection.Text);
                    }
                    if (cboDX_ConnectionSizeInlet.SelectedIndex >= 0)
                    {
                        cboManualConnectionSize.SelectedIndex = cboDX_ConnectionSizeInlet.SelectedIndex;
                    }
                    break;
                case "HR":

                    for (int i = 0; i < cboHR_ConnectionSizeIn.Items.Count; i++)
                    {
                        var cConnection = (CBOITEM)cboHR_ConnectionSizeIn.Items[i];
                        cboManualConnectionSize.Items.Add(cConnection.Text);
                    }
                    if (cboHR_ConnectionSizeIn.SelectedIndex >= 0)
                    {
                        cboManualConnectionSize.SelectedIndex = cboHR_ConnectionSizeIn.SelectedIndex;
                    }
                    break;
                case "FH":

                    for (int i = 0; i < cboFH_ConnectionSize.Items.Count; i++)
                    {
                        var cConnection = (CBOITEM)cboFH_ConnectionSize.Items[i];
                        cboManualConnectionSize.Items.Add(cConnection.Text);
                    }
                    if (cboFH_ConnectionSize.SelectedIndex >= 0)
                    {
                        cboManualConnectionSize.SelectedIndex = cboFH_ConnectionSize.SelectedIndex;
                    }

                    break;
                case "FC":

                    for (int i = 0; i < cboFC_ConnectionSize.Items.Count; i++)
                    {
                        var cConnection = (CBOITEM)cboFC_ConnectionSize.Items[i];
                        cboManualConnectionSize.Items.Add(cConnection.Text);
                    }
                    if (cboFC_ConnectionSize.SelectedIndex >= 0)
                    {
                        cboManualConnectionSize.SelectedIndex = cboFC_ConnectionSize.SelectedIndex;
                    }

                    break;
                case "ST":

                    for (int i = 0; i < cboSTEAM_SteamConnection.Items.Count; i++)
                    {
                        cboManualConnectionSize.Items.Add(cboSTEAM_SteamConnection.Items[i].ToString());
                    }
                    if (cboSTEAM_SteamConnection.SelectedIndex >= 0)
                    {
                        cboManualConnectionSize.SelectedIndex = cboSTEAM_SteamConnection.SelectedIndex;
                    }
                    break;
            }
        }

        private void AddManualControlToForm()
        {
            Controls.Add(lblCoilType);
            Controls.Add(cboCoilType);
            Controls.Add(lblConstructionType);
            Controls.Add(cboConstructionType);
            Controls.Add(lblConnectionSide);
            Controls.Add(cboConnectionSide);
            Controls.Add(lblCasingMaterial);
            Controls.Add(cboCasingMaterial);
            Controls.Add(lblCasingThickness);
            Controls.Add(cboCasingThickness);
            Controls.Add(lblTag);
            Controls.Add(txtTag);
            Controls.Add(lblQuantity);
            Controls.Add(numQuantity);

            Controls.Add(lblFH_DesignType);
            Controls.Add(cboFH_DesignType);
            Controls.Add(lblFH_ConnectionSize);
            Controls.Add(cboFH_ConnectionSize);
            Controls.Add(lblFH_HeaderQuantity);
            Controls.Add(cboFH_HeaderQuantity);
            Controls.Add(lblHR_CoilDesign);
            Controls.Add(cboHR_CoilDesign);
            Controls.Add(lblHR_HeaderQuantity);
            Controls.Add(cboHR_HeaderQuantity);
            Controls.Add(lblHR_ConnectionSizeIn);
            Controls.Add(cboHR_ConnectionSizeIn);
            Controls.Add(lblHR_ConnectionSizeOut);
            Controls.Add(lblFC_DesignType);
            Controls.Add(cboFC_DesignType);
            Controls.Add(lblFC_ConnectionSize);
            Controls.Add(cboFC_ConnectionSize);
            Controls.Add(lblFC_ConnectionType);
            Controls.Add(cboFC_ConnectionType);
            Controls.Add(lblFC_HeaderQuantity);
            Controls.Add(cboFC_HeaderQuantity);
            Controls.Add(lblDX_ConnectionSizeInlet);
            Controls.Add(cboDX_ConnectionSizeInlet);
            Controls.Add(lblDX_ConnectionSizeOutput);
            Controls.Add(cboDX_ConnectionSizeOutlet);
            Controls.Add(lblDX_HeaderQuantity);
            Controls.Add(cboDX_HeaderQuantity);
            Controls.Add(lblSTEAM_CoilType);
            Controls.Add(cboSTEAM_CoilType);
            Controls.Add(lblSTEAM_SteamConnection);
            Controls.Add(cboSTEAM_SteamConnection);
            Controls.Add(lblSTEAM_CondensateConnection);
            Controls.Add(cboSTEAM_CondensateConnection);
            Controls.Add(lblFinType);
            Controls.Add(cboFinType);
            Controls.Add(lblFinShape);
            Controls.Add(cboFinShape);
            Controls.Add(lblFinHeight);
            Controls.Add(cboFinHeight);
            Controls.Add(lblFinLength);
            Controls.Add(numFinLength);
            Controls.Add(lblRow);
            Controls.Add(numRow);
            Controls.Add(lblFPI);
            Controls.Add(cboFPI);
            Controls.Add(lblFinMaterial);
            Controls.Add(cboFinMaterial);
            Controls.Add(lblFinThickness);
            Controls.Add(cboFinThickness);
            Controls.Add(lblTubeMaterial);
            Controls.Add(cboTubeMaterial);
            Controls.Add(lblTubeThickness);
            Controls.Add(cboTubeThickness);
            Controls.Add(lblCoilCoating);
            Controls.Add(cboCoilCoating);
            Controls.Add(cmdSave);
            Controls.Add(lblTurbulators);
            Controls.Add(cboTurbulator);
            Controls.Add(lblSampleCoil);
            Controls.Add(chkSampleCoil);
        }

        //this funciton hide all coil panels one after each other and disable them
        private void HideAllCoilPanels()
        {
            try
            {
                pnlDX.Visible = false;
                pnlHR.Visible = false;
                pnlFH.Visible = false;
                pnlFC.Visible = false;
                pnlSTEAM.Visible = false;
                if (_openType.ToString() != "Manual")
                {
                    pnlGC.Visible = false;
                    pnlGC.Enabled = false;
                }


                lblTurbulators.Visible = false;
                cboTurbulator.Visible = false;

                pnlDX.Enabled = false;
                pnlHR.Enabled = false;
                pnlFH.Enabled = false;
                pnlFC.Enabled = false;
                pnlSTEAM.Enabled = false;


            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickCoil HideAllCoilPanel");
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmQuickCoil_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
            Query.LoadTables(_strTableList);

            //fill all the combobox
            Fill_Combobox();

            //set defaults
            SetDefaults();

            //2012-07-30 : #2998 : temporary blocking co2. also code for k fin in fill_fintype
            TemporaryR744Blocking();

            _formIsLoading = false;

            if (_bolQuoteSelection && _intIndex != -1)
            {
                ThreadProcess.UpdateMessage(Public.LanguageString("Loading saved data", "Chargement des données"));
                if (_openType == CoilOpenType.Selection)
                {
                    LoadSavedData();
                }
                else
                {
                    LoadSavedDataManualSelection();
                }
            }

            ThreadProcess.Stop();
            Focus();

            //changeListView();
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void LoadSavedDataManualSelection()
        {
            //will contain all errors
            string strErrors = "";

            DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["QuickManualCoil"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.ManualCoil) + " AND ItemID = " + _intIndex, "");
            DataRow drSavedInfo = dtSavedInfo.NewRow();
            drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;

            //coil model    
            txtManualModelName.Text = drSavedInfo["CoilModel"].ToString();

            //validate the model name
            ValidateManualModel();

            //Connection Side
            if (cboConnectionSide.FindString(drSavedInfo["Input_ConnectionSide"].ToString()) >= 0)
            {
                cboConnectionSide.SelectedIndex = cboConnectionSide.FindString(drSavedInfo["Input_ConnectionSide"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find Connection Side", "- Incapable de trouver l'emplacement du raccord") + Environment.NewLine;
            }

            //casing material
            if (cboCasingMaterial.FindString(drSavedInfo["Input_CasingMaterial"].ToString()) >= 0)
            {
                cboCasingMaterial.SelectedIndex = cboCasingMaterial.FindString(drSavedInfo["Input_CasingMaterial"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find Casing Material", "- Incapable de trouver le matériau du boîtier") + Environment.NewLine;
            }

            //casing thickness
            if (cboCasingThickness.FindString(drSavedInfo["Input_CasingThickness"].ToString()) >= 0)
            {
                cboCasingThickness.SelectedIndex = cboCasingThickness.FindString(drSavedInfo["Input_CasingThickness"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find Casing Thickness", "- Incapable de trouver l'épaisseur du matériau du boîtier") + Environment.NewLine;
            }

            //tag
            txtTag.Text = drSavedInfo["Tag"].ToString();

            //quantity
            numQuantity.Value = Convert.ToDecimal(drSavedInfo["Quantity"]);

            //Fin Material
            if (cboFinMaterial.FindString(drSavedInfo["Input_FinMaterial"].ToString()) >= 0)
            {
                cboFinMaterial.SelectedIndex = cboFinMaterial.FindString(drSavedInfo["Input_FinMaterial"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find fin material", "- Incapable de trouver le matériau des ailettes") + Environment.NewLine;
            }

            //Fin thickness
            if (cboFinThickness.FindString(drSavedInfo["Input_FinThickness"].ToString()) >= 0)
            {
                cboFinThickness.SelectedIndex = cboFinThickness.FindString(drSavedInfo["Input_FinThickness"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find fin thickness", "- Incapable de trouver l'épaisseur des ailettes") + Environment.NewLine;
            }

            //Tube Material
            if (cboTubeMaterial.FindString(drSavedInfo["Input_TubeMaterial"].ToString()) >= 0)
            {
                cboTubeMaterial.SelectedIndex = cboTubeMaterial.FindString(drSavedInfo["Input_TubeMaterial"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find tube material", "- Incapable de trouver le matériau des tubes") + Environment.NewLine;
            }

            //Tube thickness
            if (cboTubeThickness.FindString(drSavedInfo["Input_TubeThickness"].ToString()) >= 0)
            {
                cboTubeThickness.SelectedIndex = cboTubeThickness.FindString(drSavedInfo["Input_TubeThickness"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find tube thickness", "- Incapable de trouver l'épaisseur des tubes") + Environment.NewLine;
            }

            //2011-01-19 : adding conenction Type but only for water coil
            //that a special patching. it probably wont work anymore if we have to change it again.
            if (txtManualModelName.Text.StartsWith("W") || txtManualModelName.Text.StartsWith("B"))
            {
                //Connection type
                if (cboFC_ConnectionType.FindString(drSavedInfo["Input_ConnectionType"].ToString()) >= 0)
                {
                    cboFC_ConnectionType.SelectedIndex = cboFC_ConnectionType.FindString(drSavedInfo["Input_ConnectionType"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find connection type", "- Incapable de trouver le type de connection") + Environment.NewLine;
                }
            }

            //Connection Size
            if (cboManualConnectionSize.FindString(drSavedInfo["Input_ConnectionSize"].ToString()) >= 0)
            {
                cboManualConnectionSize.SelectedIndex = cboManualConnectionSize.FindString(drSavedInfo["Input_ConnectionSize"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find connection size", "- Incapable de trouver la connection") + Environment.NewLine;
            }

            //turbulator
            if (cboTurbulator.FindString(drSavedInfo["Input_Turbulator"].ToString()) >= 0)
            {
                cboTurbulator.SelectedIndex = cboTurbulator.FindString(drSavedInfo["Input_Turbulator"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find turbulators", "- Incapable de trouver le turbulateur") + Environment.NewLine;
            }

            Fill_CoilCoatingManualSelection();

            //coating
            if (cboCoilCoating.FindString(drSavedInfo["Input_CoilCoating"].ToString()) >= 0)
            {
                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(drSavedInfo["Input_CoilCoating"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find coating", "- Incapable de trouver le revêtement") + Environment.NewLine;
            }

            //2012-04-24 : #2992 : adding sample coil option loading
            chkSampleCoil.Checked = (Convert.ToInt32(drSavedInfo["Input_SampleCoil"]) == 1);

            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivantes sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadSavedData()
        {
            //will contain all errors
            string strErrors = "";

            DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Coil) + " AND ItemID = " + _intIndex, "");
            DataRow drSavedInfo = dtSavedInfo.NewRow();
            drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;

            if (cboCoilType.FindString(drSavedInfo["Input_CoilType"].ToString()) >= 0)
            {
                //coil fin type
                cboCoilType.SelectedIndex = cboCoilType.FindString(drSavedInfo["Input_CoilType"].ToString());

                //constuction
                if (cboConstructionType.FindString(drSavedInfo["Input_ConstructionType"].ToString()) >= 0)
                {
                    cboConstructionType.SelectedIndex = cboConstructionType.FindString(drSavedInfo["Input_ConstructionType"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find Construction Type", "- Incapable de trouver le type de construction") + Environment.NewLine;
                }

                //tag
                txtTag.Text = drSavedInfo["Tag"].ToString();

                //Connection Side
                if (cboConnectionSide.FindString(drSavedInfo["Input_ConnectionSide"].ToString()) >= 0)
                {
                    cboConnectionSide.SelectedIndex = cboConnectionSide.FindString(drSavedInfo["Input_ConnectionSide"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find Connection Side", "- Incapable de trouver l'emplacement du raccord") + Environment.NewLine;
                }

                //casing material
                if (cboCasingMaterial.FindString(drSavedInfo["Input_CasingMaterial"].ToString()) >= 0)
                {
                    cboCasingMaterial.SelectedIndex = cboCasingMaterial.FindString(drSavedInfo["Input_CasingMaterial"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find Casing Material", "- Incapable de trouver le matériau du boîtier") + Environment.NewLine;
                }

                //casing thickness
                if (cboCasingThickness.FindString(drSavedInfo["Input_CasingThickness"].ToString()) >= 0)
                {
                    cboCasingThickness.SelectedIndex = cboCasingThickness.FindString(drSavedInfo["Input_CasingThickness"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find Casing Thickness", "- Incapable de trouver le matériau du boitier") + Environment.NewLine;
                }

                //Location
                if (cboLocation.FindString(drSavedInfo["Input_Location"].ToString()) >= 0)
                {
                    cboLocation.SelectedIndex = cboLocation.FindString(drSavedInfo["Input_Location"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find location", "- Incapable de trouver la localisation") + Environment.NewLine;
                }

                //quantity
                numQuantity.Value = Convert.ToDecimal(drSavedInfo["Quantity"]);

                switch (drSavedInfo["CoilType"].ToString())
                {
                    case "DX":
                        //refrigerant type
                        if (cboDX_RefrigerantType.FindString(drSavedInfo["Input_DX_RefrigerantType"].ToString()) >= 0)
                        {
                            cboDX_RefrigerantType.SelectedIndex = cboDX_RefrigerantType.FindString(drSavedInfo["Input_DX_RefrigerantType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find refrigerant type", "- Incapable de trouver le type de réfrigérant") + Environment.NewLine;
                        }

                        //Conn inlet
                        if (cboDX_ConnectionSizeInlet.FindString(drSavedInfo["Input_DX_ConnectionSizeInlet"].ToString()) >= 0)
                        {
                            cboDX_ConnectionSizeInlet.SelectedIndex = cboDX_ConnectionSizeInlet.FindString(drSavedInfo["Input_DX_ConnectionSizeInlet"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find inlet connection size", "- Incapable de trouver la connection d'entrée") + Environment.NewLine;
                        }

                        //Conn outlet
                        if (cboDX_ConnectionSizeOutlet.FindString(drSavedInfo["Input_DX_ConnectionSizeOutlet"].ToString()) >= 0)
                        {
                            cboDX_ConnectionSizeOutlet.SelectedIndex = cboDX_ConnectionSizeOutlet.FindString(drSavedInfo["Input_DX_ConnectionSizeOutlet"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find outlet connection size", "- Incapable de trouver la connection de sortie") + Environment.NewLine;
                        }

                        //Header Quantity
                        if (cboDX_HeaderQuantity.FindString(drSavedInfo["Input_DX_HeaderQuantity"].ToString()) >= 0)
                        {
                            cboDX_HeaderQuantity.SelectedIndex = cboDX_HeaderQuantity.FindString(drSavedInfo["Input_DX_HeaderQuantity"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find header quantity", "- Incapable de trouver la quantité de collecteurs") + Environment.NewLine;
                        }

                        numDX_FreshCFM.Value = Convert.ToDecimal(drSavedInfo["DXFreshCFM"]);
                        numDX_FreshEDB.Value = Convert.ToDecimal(drSavedInfo["DXFreshEDB"]);
                        numDX_FreshEWB.Value = Convert.ToDecimal(drSavedInfo["DXFreshEWB"]);

                        numDX_ReturnCFM.Value = Convert.ToDecimal(drSavedInfo["DXReturnCFM"]);
                        numDX_ReturnEDB.Value = Convert.ToDecimal(drSavedInfo["DXReturnEDB"]);
                        numDX_ReturnEWB.Value = Convert.ToDecimal(drSavedInfo["DXReturnEWB"]);

                        numDX_Altitude.Value = Convert.ToDecimal(drSavedInfo["DXAltitude"]);

                        numDX_SuctionTemperature.Value = Convert.ToDecimal(drSavedInfo["DXSuctionTemperature"]);

                        numDX_LiquidTemperature.Value = Convert.ToDecimal(drSavedInfo["DXLiquidTemp"]);

                        //# circuit
                        if (cboDX_NumberOfCircuits.FindString(drSavedInfo["DXNumberOfCircuit"].ToString()) >= 0)
                        {
                            cboDX_NumberOfCircuits.SelectedIndex = cboDX_NumberOfCircuits.FindString(drSavedInfo["DXNumberOfCircuit"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find # of circuits", "- Incapable de trouver la quantité de circuits") + Environment.NewLine;
                        }
                        break;
                    case "HR":
                        //Coil Design
                        if (cboHR_CoilDesign.FindString(drSavedInfo["Input_HR_CoilDesign"].ToString()) >= 0)
                        {
                            cboHR_CoilDesign.SelectedIndex = cboHR_CoilDesign.FindString(drSavedInfo["Input_HR_CoilDesign"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find coil design", "- Incapable de trouver le design du serpentin") + Environment.NewLine;
                        }

                        //Conn inlet
                        if (cboHR_ConnectionSizeIn.FindString(drSavedInfo["Input_HR_ConnectionSizeInlet"].ToString()) >= 0)
                        {
                            cboHR_ConnectionSizeIn.SelectedIndex = cboHR_ConnectionSizeIn.FindString(drSavedInfo["Input_HR_ConnectionSizeInlet"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find inlet connection size", "- Incapable de trouver la connection d'entrée") + Environment.NewLine;
                        }

                        //Conn outlet
                        if (cboHR_ConnectionSizeOut.FindString(drSavedInfo["Input_HR_ConnectionSizeOutlet"].ToString()) >= 0)
                        {
                            cboHR_ConnectionSizeOut.SelectedIndex = cboHR_ConnectionSizeOut.FindString(drSavedInfo["Input_HR_ConnectionSizeOutlet"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find outlet connection size", "- Incapable de trouver la connection de sortie") + Environment.NewLine;
                        }

                        //Header Quantity
                        if (cboHR_HeaderQuantity.FindString(drSavedInfo["Input_HR_HeaderQuantity"].ToString()) >= 0)
                        {
                            cboHR_HeaderQuantity.SelectedIndex = cboHR_HeaderQuantity.FindString(drSavedInfo["Input_HR_HeaderQuantity"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find header quantity", "- Incapable de trouver la quantité de collecteurs") + Environment.NewLine;
                        }

                        numHR_FreshCFM.Value = Convert.ToDecimal(drSavedInfo["HRFreshCFM"]);
                        numHR_FreshEDB.Value = Convert.ToDecimal(drSavedInfo["HRFreshEDB"]);

                        numHR_ReturnCFM.Value = Convert.ToDecimal(drSavedInfo["HRReturnCFM"]);
                        numHR_ReturnEDB.Value = Convert.ToDecimal(drSavedInfo["HRReturnEDB"]);

                        numHR_Altitude.Value = Convert.ToDecimal(drSavedInfo["HRAltitude"]);

                        //Refrigerant Type
                        if (cboHR_RefrigerantType.FindString(drSavedInfo["HRRefrigerantType"].ToString()) >= 0)
                        {
                            cboHR_RefrigerantType.SelectedIndex = cboHR_RefrigerantType.FindString(drSavedInfo["HRRefrigerantType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find refrigerant type", "- Incapable de trouver le type de réfrigérant") + Environment.NewLine;
                        }

                        numHR_CondensingTemperature.Value = Convert.ToDecimal(drSavedInfo["HRCondensingTemperature"]);
                        numHR_SuctionTemperature.Value = Convert.ToDecimal(drSavedInfo["HRSuctionTemperature"]);

                        //# of circuits
                        if (cboHR_NumberOfCircuits.FindString(drSavedInfo["HRNumberOfCircuit"].ToString()) >= 0)
                        {
                            cboHR_NumberOfCircuits.SelectedIndex = cboHR_NumberOfCircuits.FindString(drSavedInfo["HRNumberOfCircuit"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find number of circuit", "- Incapable de trouver le nombre de circuits") + Environment.NewLine;
                        }

                        //heat recovery
                        numHR_HeatRecovery.Value = Convert.ToDecimal(drSavedInfo["HRHeatRecovery"]);

                        //sub cooler
                        if (cboHR_SubCooler.FindString(drSavedInfo["HRSubCooler"].ToString()) >= 0)
                        {
                            cboHR_SubCooler.SelectedIndex = cboHR_SubCooler.FindString(drSavedInfo["HRSubCooler"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find sub cooler", "- Incapable de trouver le sous-refroidisseur") + Environment.NewLine;
                        }

                        //sub conn in
                        if (cboHR_SubCoolerConnectionSizeIn.FindString(drSavedInfo["Input_HR_SubCoolerConnIn"].ToString()) >= 0)
                        {
                            cboHR_SubCoolerConnectionSizeIn.SelectedIndex = cboHR_SubCoolerConnectionSizeIn.FindString(drSavedInfo["Input_HR_SubCoolerConnIn"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find sub cooler conn. in", "- Incapable de trouver la connection entrante du sous-refroidisseur") + Environment.NewLine;
                        }

                        //sub conn out
                        if (cboHR_SubCoolerConnectionSizeOut.FindString(drSavedInfo["Input_HR_SubCoolerConnOut"].ToString()) >= 0)
                        {
                            cboHR_SubCoolerConnectionSizeOut.SelectedIndex = cboHR_SubCoolerConnectionSizeOut.FindString(drSavedInfo["Input_HR_SubCoolerConnOut"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find sub cooler conn. out", "- Incapable de trouver la connection sortante du sous-refroidisseur") + Environment.NewLine;
                        }

                        numHR_FaceTubes.Value = Convert.ToDecimal(drSavedInfo["HRFaceTubes"]);

                        numHR_Circuit.Value = Convert.ToDecimal(drSavedInfo["HRCircuits"]);

                        break;
                    case "FH":
                        //Coil Design
                        if (cboFH_DesignType.FindString(drSavedInfo["Input_FH_DesignType"].ToString()) >= 0)
                        {
                            cboFH_DesignType.SelectedIndex = cboFH_DesignType.FindString(drSavedInfo["Input_FH_DesignType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find design type", "- Incapable de trouver le type de design") + Environment.NewLine;
                        }

                        //connection type
                        if (cboFH_ConnectionType.FindString(drSavedInfo["FHConnectionType"].ToString()) >= 0)
                        {
                            cboFH_ConnectionType.SelectedIndex = cboFH_ConnectionType.FindString(drSavedInfo["FHConnectionType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find connection type", "- Incapable de trouver le type de connection") + Environment.NewLine;
                        }

                        //connection size
                        if (cboFH_ConnectionSize.FindString(drSavedInfo["Input_FH_ConnectionSize"].ToString()) >= 0)
                        {
                            cboFH_ConnectionSize.SelectedIndex = cboFH_ConnectionSize.FindString(drSavedInfo["Input_FH_ConnectionSize"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find connection size", "- Incapable de trouver la connection") + Environment.NewLine;
                        }

                        //header quantity
                        if (cboFH_HeaderQuantity.FindString(drSavedInfo["Input_FH_HeaderQuantity"].ToString()) >= 0)
                        {
                            cboFH_HeaderQuantity.SelectedIndex = cboFH_HeaderQuantity.FindString(drSavedInfo["Input_FH_HeaderQuantity"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find header quantity", "- Incapable de trouver le nombre de collecteurs") + Environment.NewLine;
                        }

                        numFH_FreshCFM.Value = Convert.ToDecimal(drSavedInfo["FHFreshCFM"]);
                        numFH_FreshEDB.Value = Convert.ToDecimal(drSavedInfo["FHFreshEDB"]);

                        numFH_ReturnCFM.Value = Convert.ToDecimal(drSavedInfo["FHReturnCFM"]);
                        numFH_ReturnEDB.Value = Convert.ToDecimal(drSavedInfo["FHReturnEDB"]);

                        numFH_Altitude.Value = Convert.ToDecimal(drSavedInfo["FHAltitude"]);

                        numFH_ELT.Value = Convert.ToDecimal(drSavedInfo["FHEnteringLiquidTemperature"]);
                        numFH_SpecificHeat.Value = Convert.ToDecimal(drSavedInfo["FHSpecificHeat"]);
                        numFH_Density.Value = Convert.ToDecimal(drSavedInfo["FHDensity"]);
                        numFH_Viscosity.Value = Convert.ToDecimal(drSavedInfo["FHViscosity"]);
                        numFH_ThermalConductivity.Value = Convert.ToDecimal(drSavedInfo["FHThermalConductivity"]);
                        txtFH_FluidTypeName.Text = drSavedInfo["FHFluidTypeName"].ToString();

                        //fluid type
                        string strFHFluidType = "";
                        switch (drSavedInfo["FHFluidType"].ToString())
                        {
                            case "WTR":
                                strFHFluidType = "Water";
                                break;
                            case "EG":
                                strFHFluidType = "Ethylene Glycol";
                                break;
                            case "PG":
                                strFHFluidType = "Propylene Glycol";
                                break;
                            case "OTHER":
                                strFHFluidType = "Other";
                                break;
                        }

                        if (cboFH_FluidType.FindString(strFHFluidType) >= 0)
                        {
                            cboFH_FluidType.SelectedIndex = cboFH_FluidType.FindString(strFHFluidType);
                            numFH_Concentration.Value = Convert.ToDecimal(drSavedInfo["FHConcentration"]);

                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find fluid type", "- Incapable de trouver le type de liquide") + Environment.NewLine;
                        }

                        //gpm llt
                        if (cboFH_GPM_LeavingLiquidTemp.FindString(drSavedInfo["Input_FH_GPM_LLT"].ToString()) >= 0)
                        {
                            cboFH_GPM_LeavingLiquidTemp.SelectedIndex = cboFH_GPM_LeavingLiquidTemp.FindString(drSavedInfo["Input_FH_GPM_LLT"].ToString());

                            if (drSavedInfo["Input_FH_GPM_LLT"].ToString().Contains("GPM"))
                            {
                                numFH_USGPM.Value = Convert.ToDecimal(drSavedInfo["FHUSGPM"]);
                            }
                            else
                            {
                                numFH_LeavingLiquidTemperature.Value = Convert.ToDecimal(drSavedInfo["FHLeavingLiquidTemperature"]);
                            }
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find if selection on gpm or leaving liquid temperature", "- Incapable de trouver si la selection a été faite par gpm ou leaving liquid temperature") + Environment.NewLine;
                        }

                        //# of circuit
                        if (cboFH_NumberOfCircuits.FindString(drSavedInfo["FHNumberOfCircuit"].ToString()) >= 0)
                        {
                            cboFH_NumberOfCircuits.SelectedIndex = cboFH_NumberOfCircuits.FindString(drSavedInfo["FHNumberOfCircuit"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find number of circuit", "- Incapable de trouver le nombre de circuits") + Environment.NewLine;
                        }

                        numFH_MaxPressure.Value = Convert.ToDecimal(drSavedInfo["FHMaxPressure"]);

                        break;
                    case "FC":

                        //Coil Design
                        if (cboFC_DesignType.FindString(drSavedInfo["Input_FC_DesignType"].ToString()) >= 0)
                        {
                            cboFC_DesignType.SelectedIndex = cboFC_DesignType.FindString(drSavedInfo["Input_FC_DesignType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find design type", "- Incapable de trouver le type de design") + Environment.NewLine;
                        }

                        //connection type
                        if (cboFC_ConnectionType.FindString(drSavedInfo["FCConnectionType"].ToString()) >= 0)
                        {
                            cboFC_ConnectionType.SelectedIndex = cboFC_ConnectionType.FindString(drSavedInfo["FCConnectionType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find connection type", "- Incapable de trouver le type de connection") + Environment.NewLine;
                        }

                        //connection size
                        if (cboFC_ConnectionSize.FindString(drSavedInfo["Input_FC_ConnectionSize"].ToString()) >= 0)
                        {
                            cboFC_ConnectionSize.SelectedIndex = cboFC_ConnectionSize.FindString(drSavedInfo["Input_FC_ConnectionSize"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find connection size", "- Incapable de trouver la connection") + Environment.NewLine;
                        }

                        //header quantity
                        if (cboFC_HeaderQuantity.FindString(drSavedInfo["Input_FC_HeaderQuantity"].ToString()) >= 0)
                        {
                            cboFC_HeaderQuantity.SelectedIndex = cboFC_HeaderQuantity.FindString(drSavedInfo["Input_FC_HeaderQuantity"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find header quantity", "- Incapable de trouver le nombre de collecteurs") + Environment.NewLine;
                        }

                        numFC_FreshCFM.Value = Convert.ToDecimal(drSavedInfo["FCFreshCFM"]);
                        numFC_FreshEDB.Value = Convert.ToDecimal(drSavedInfo["FCFreshEDB"]);
                        numFC_FreshEWB.Value = Convert.ToDecimal(drSavedInfo["FCFreshEWB"]);

                        numFC_ReturnCFM.Value = Convert.ToDecimal(drSavedInfo["FCReturnCFM"]);
                        numFC_ReturnEDB.Value = Convert.ToDecimal(drSavedInfo["FCReturnEDB"]);
                        numFC_ReturnEWB.Value = Convert.ToDecimal(drSavedInfo["FCReturnEWB"]);

                        numFC_Altitude.Value = Convert.ToDecimal(drSavedInfo["FCAltitude"]);

                        numFC_ELT.Value = Convert.ToDecimal(drSavedInfo["FCEnteringLiquidTemperature"]);

                        numFC_SpecificHeat.Value = Convert.ToDecimal(drSavedInfo["FCSpecificHeat"]);
                        numFC_Density.Value = Convert.ToDecimal(drSavedInfo["FCDensity"]);
                        numFC_Viscosity.Value = Convert.ToDecimal(drSavedInfo["FCViscosity"]);
                        numFC_ThermalConductivity.Value = Convert.ToDecimal(drSavedInfo["FCThermalConductivity"]);
                        txtFC_FluidTypeName.Text = drSavedInfo["FCFluidTypeName"].ToString();

                        //Fluid Type
                        string strFCFluidType = "";
                        switch (drSavedInfo["FCFluidType"].ToString())
                        {
                            case "WTR":
                                strFCFluidType = "Water";
                                break;
                            case "EG":
                                strFCFluidType = "Ethylene Glycol";
                                break;
                            case "PG":
                                strFCFluidType = "Propylene Glycol";
                                break;
                            case "OTHER":
                                strFCFluidType = "Other";
                                break;
                        }
                        if (cboFC_FluidType.FindString(strFCFluidType) >= 0)
                        {
                            cboFC_FluidType.SelectedIndex = cboFC_FluidType.FindString(strFCFluidType);
                            numFC_Concentration.Value = Convert.ToDecimal(drSavedInfo["FCConcentration"]);
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find fluid type", "- Incapable de trouver le type de liquide") + Environment.NewLine;
                        }

                        //gpm llt
                        if (cboFC_GPM_LeavingLiquidTemp.FindString(drSavedInfo["Input_FC_GPM_LLT"].ToString()) >= 0)
                        {
                            cboFC_GPM_LeavingLiquidTemp.SelectedIndex = cboFC_GPM_LeavingLiquidTemp.FindString(drSavedInfo["Input_FC_GPM_LLT"].ToString());

                            if (drSavedInfo["Input_FC_GPM_LLT"].ToString().Contains("GPM"))
                            {
                                numFC_USGPM.Value = Convert.ToDecimal(drSavedInfo["FCUSGPM"]);
                            }
                            else
                            {
                                numFC_LeavingLiquidTemperature.Value = Convert.ToDecimal(drSavedInfo["FCLeavingLiquidTemperature"]);
                            }
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find if selection on gpm or leaving liquid temperature", "- Incapable de trouver si la sélection a été faite par gpm ou leaving liquid temperature") + Environment.NewLine;
                        }

                        //# of circuit
                        if (cboFC_NumberOfCircuits.FindString(drSavedInfo["FCNumberOfCircuits"].ToString()) >= 0)
                        {
                            cboFC_NumberOfCircuits.SelectedIndex = cboFC_NumberOfCircuits.FindString(drSavedInfo["FCNumberOfCircuits"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find number of circuit", "- Incapable de trouver le nombre de circuits") + Environment.NewLine;
                        }

                        numFC_MaxPressure.Value = Convert.ToDecimal(drSavedInfo["FCMaxPressure"]);

                        break;
                    case "ST":

                        //coil type
                        if (cboSTEAM_CoilType.FindString(drSavedInfo["STEAMSteamCoilType"].ToString()) >= 0)
                        {
                            cboSTEAM_CoilType.SelectedIndex = cboSTEAM_CoilType.FindString(drSavedInfo["STEAMSteamCoilType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find steam coil type", "- Incapable de trouver le type de serpentin à vapeur") + Environment.NewLine;
                        }

                        //tube orientation
                        if (cboSTEAMTubeOrientation.FindString(drSavedInfo["Input_STEAM_TubeOrientation"].ToString()) >= 0)
                        {
                            cboSTEAMTubeOrientation.SelectedIndex = cboSTEAMTubeOrientation.FindString(drSavedInfo["Input_STEAM_TubeOrientation"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find tube orientation", "- Incapable de trouver l'orientation des tubes") + Environment.NewLine;
                        }

                        //connection type
                        if (cboSTEAM_ConnectionType.FindString(drSavedInfo["STEAMConnectionType"].ToString()) >= 0)
                        {
                            cboSTEAM_ConnectionType.SelectedIndex = cboSTEAM_ConnectionType.FindString(drSavedInfo["STEAMConnectionType"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find connection type", "- Incapable de trouver le type de connection") + Environment.NewLine;
                        }

                        //steam connection
                        if (cboSTEAM_SteamConnection.FindString(drSavedInfo["STEAMSteamConnection"].ToString()) >= 0)
                        {
                            cboSTEAM_SteamConnection.SelectedIndex = cboSTEAM_SteamConnection.FindString(drSavedInfo["STEAMSteamConnection"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find steam connection type", "- Incapable de trouver le type de raccord pour la vapeur") + Environment.NewLine;
                        }

                        //condensate connection
                        if (cboSTEAM_CondensateConnection.FindString(drSavedInfo["STEAMCondensateConnection"].ToString()) >= 0)
                        {
                            cboSTEAM_CondensateConnection.SelectedIndex = cboSTEAM_CondensateConnection.FindString(drSavedInfo["STEAMCondensateConnection"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find condensate connection type", "- Incapable de trouver le type de raccord de condensat") + Environment.NewLine;
                        }

                        numSTEAM_FreshCFM.Value = Convert.ToDecimal(drSavedInfo["STEAMFreshCFM"]);
                        numSTEAM_FreshEDB.Value = Convert.ToDecimal(drSavedInfo["STEAMFreshEDB"]);

                        numSTEAM_ReturnCFM.Value = Convert.ToDecimal(drSavedInfo["STEAMReturnCFM"]);
                        numSTEAM_ReturnEDB.Value = Convert.ToDecimal(drSavedInfo["STEAMReturnEDB"]);

                        numSTEAM_Altitude.Value = Convert.ToDecimal(drSavedInfo["STEAMAltitude"]);

                        numSTEAM_SteamPressure.Value = Convert.ToDecimal(drSavedInfo["STEAMSaturatedSteamPressure"]);

                        break;
                    case "GC":
                        //refrigerant type

                        numGC_Altitude.Value = Convert.ToDecimal(drSavedInfo["GCAltitude"]);
                        numGC_GIN.Value = Convert.ToDecimal(drSavedInfo["GCGIN"]);
                        numGC_GFLO.Value = Convert.ToDecimal(drSavedInfo["GCGFLO"]);

                        numGC_GPSI.Value = Convert.ToDecimal(drSavedInfo["GCGPSI"]);
                        numGC_FreshCFM.Value = Convert.ToDecimal(drSavedInfo["GCAirFlowRate"]);
                        numGC_FreshEDB.Value = Convert.ToDecimal(drSavedInfo["GCEnteringDryBulb"]);

                        //# circuit
                        if (cboDX_NumberOfCircuits.FindString(drSavedInfo["GCNumberOfCircuits"].ToString()) >= 0)
                        {
                            cboGC_Circuits.SelectedIndex = cboGC_Circuits.FindString(drSavedInfo["GCNumberOfCircuits"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find # of circuits", "- Incapable de trouver la quantité de circuits") + Environment.NewLine;
                        }
                        break;
                }

                //Fin Type
                if (cboFinType.FindString(drSavedInfo["FinTypeText"].ToString()) >= 0)
                {
                    cboFinType.SelectedIndex = cboFinType.FindString(drSavedInfo["FinTypeText"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find fin type", "- Incapable de trouver le type d'ailette") + Environment.NewLine;
                }

                //Fin Shape
                if (cboFinShape.FindString(drSavedInfo["FinShapeText"].ToString()) >= 0)
                {
                    cboFinShape.SelectedIndex = cboFinShape.FindString(drSavedInfo["FinShapeText"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find fin shape", "- Incapable de trouver la forme d'ailette") + Environment.NewLine;
                }

                //Fin Height
                if (cboFinHeight.FindString(drSavedInfo["FinHeight"].ToString()) >= 0)
                {
                    cboFinHeight.SelectedIndex = cboFinHeight.FindString(drSavedInfo["FinHeight"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find fin height", "- Incapable de trouver la hauteur des ailettes") + Environment.NewLine;
                }

                numFinLength.Value = Convert.ToDecimal(drSavedInfo["FinLength"]);
                numRow.Value = Convert.ToDecimal(drSavedInfo["Row"]);

                //Fpi
                if (cboFPI.FindString(drSavedInfo["FPI"].ToString()) >= 0)
                {
                    cboFPI.SelectedIndex = cboFPI.FindString(drSavedInfo["FPI"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find fpi", "- Incapable de trouver le nombre d'ailettes par pouce") + Environment.NewLine;
                }

                //Fin Material
                if (cboFinMaterial.FindString(drSavedInfo["FinMaterialText"].ToString()) >= 0)
                {
                    cboFinMaterial.SelectedIndex = cboFinMaterial.FindString(drSavedInfo["FinMaterialText"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find fin material", "- Incapable de trouver le matériau des ailettes") + Environment.NewLine;
                }

                //Fin thickness
                if (cboFinThickness.FindString(drSavedInfo["FinThickness"].ToString()) >= 0)
                {
                    cboFinThickness.SelectedIndex = cboFinThickness.FindString(drSavedInfo["FinThickness"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find fin thickness", "- Incapable de trouver l'épaisseur des ailettes") + Environment.NewLine;
                }

                //Tube Material
                if (cboTubeMaterial.FindString(drSavedInfo["TubeMaterialText"].ToString()) >= 0)
                {
                    cboTubeMaterial.SelectedIndex = cboTubeMaterial.FindString(drSavedInfo["TubeMaterialText"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find tube material", "- Incapable de trouver le matériau des tubes") + Environment.NewLine;
                }

                //Tube thickness
                if (cboTubeThickness.FindString(drSavedInfo["TubeThickness"].ToString()) >= 0)
                {
                    cboTubeThickness.SelectedIndex = cboTubeThickness.FindString(drSavedInfo["TubeThickness"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find tube thickness", "- Incapable de trouver l'épaisseur des tubes") + Environment.NewLine;
                }

                switch (drSavedInfo["CoilType"].ToString())
                {
                    case "FH":
                    case "FC":
                        //turbulator
                        if (cboTurbulator.FindString(drSavedInfo["Turbulators"].ToString()) >= 0)
                        {
                            cboTurbulator.SelectedIndex = cboTurbulator.FindString(drSavedInfo["Turbulators"].ToString());
                        }
                        else
                        {
                            strErrors = strErrors + Public.LanguageString("- Cannot find turbulators", "- Incapable de trouver le turbulateur") + Environment.NewLine;
                        }
                        break;
                }

            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find Coil Type", "- Incapable de trouver le type de serpentin") + Environment.NewLine;
            }

            RunSelection();

            //coating
            if (cboCoilCoating.FindString(drSavedInfo["CoilCoating"].ToString()) >= 0)
            {
                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(drSavedInfo["CoilCoating"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find coating", "- Incapable de trouver le revêtement") + Environment.NewLine;
            }


            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivantes sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetDefaults()
        {
            //select DX as default
            ComboBoxControl.SetIDDefaultValue(cboCoilType, "1");

            //select R22 is DX as default
            ComboBoxControl.SetDefaultValue(cboDX_RefrigerantType, "R-22");

            //select R22 as HR default
            ComboBoxControl.SetDefaultValue(cboHR_RefrigerantType, "R-22");

            //select condenser for HR
            ComboBoxControl.SetDefaultValue(cboHR_CoilDesign, "Condenser");

            //select no subcooler for HR
            ComboBoxControl.SetDefaultValue(cboHR_SubCooler, "NO");

            //select Tubulator No for FH/FC
            ComboBoxControl.SetDefaultValue(cboTurbulator, "NO");

            //select USGPM for FH
            ComboBoxControl.SetDefaultValue(cboFH_GPM_LeavingLiquidTemp, "USGPM");

            //select MPT for FH
            ComboBoxControl.SetDefaultValue(cboFH_ConnectionType, "MPT");

            //select STD for FH
            ComboBoxControl.SetDefaultValue(cboFH_ConnectionSize, "STD");

            //select Water for FH
            ComboBoxControl.SetIDDefaultValue(cboFH_FluidType, "1");

            //select USGPM for FC
            ComboBoxControl.SetDefaultValue(cboFC_GPM_LeavingLiquidTemp, "USGPM");

            //select MPT for FC
            ComboBoxControl.SetDefaultValue(cboFC_ConnectionType, "MPT");

            //select STD for FC
            ComboBoxControl.SetDefaultValue(cboFC_ConnectionSize, "STD");

            //select Water for FC
            ComboBoxControl.SetIDDefaultValue(cboFC_FluidType, "1");

            //Standard Steam for Steam
            ComboBoxControl.SetDefaultValue(cboSTEAM_CoilType, "Standard Steam");

            //MPT connection for Steam
            ComboBoxControl.SetDefaultValue(cboSTEAM_ConnectionType, "MPT");

            //STD condensate for Steam
            ComboBoxControl.SetDefaultValue(cboSTEAM_CondensateConnection, "STD");

            //STD Steam for Steam
            ComboBoxControl.SetDefaultValue(cboSTEAM_SteamConnection, "STD");

            //select N/A default connection side
            cboConnectionSide.SelectedIndex = 0;

            //select standard construction
            cboConstructionType.SelectedIndex = 0;

            //select STD Dx conn
            cboDX_ConnectionSizeInlet.SelectedIndex = 0;
            cboDX_ConnectionSizeOutlet.SelectedIndex = 0;

            //select STD FC conn
            cboFC_ConnectionSize.SelectedIndex = 0;

            //select STD FH conn
            cboFH_ConnectionSize.SelectedIndex = 0;

            //select STD HR conn
            cboHR_ConnectionSizeIn.SelectedIndex = 0;
            cboHR_ConnectionSizeOut.SelectedIndex = 0;
            cboHR_SubCoolerConnectionSizeIn.SelectedIndex = 0;
            cboHR_SubCoolerConnectionSizeOut.SelectedIndex = 0;

            //select design type for FH and FC on Standard
            cboFH_DesignType.SelectedIndex = 0;
            cboFC_DesignType.SelectedIndex = 0;
        }

        private void Fill_Combobox()
        {
            //fill the coil type
            Fill_CoilType();

            //fill FinShape
            //Fill_FinShape();

            ////fill the tube material
            //Fill_TubeMaterial();

            //fill FH fluidType
            Fill_FH_FluidType();

            //fill FC fluidtype
            Fill_FC_FluidType();

            //fill the circuits once
            Fill_Circuits();

            //fill all the locations
            Fill_Location();

            //fill DX hader quantity
            Fill_HeaderQuantity(cboDX_HeaderQuantity);
            Fill_HeaderQuantity(cboHR_HeaderQuantity);
            Fill_HeaderQuantity(cboFC_HeaderQuantity);
            Fill_HeaderQuantity(cboFH_HeaderQuantity);

            //fill connection size
            Fill_DX_ConnectionSize();
            Fill_HR_COND_ConnectionSize();

            //2011-01-18: with new change to connnections this wont work anymore.
            //they are getting triggered when the connection type change.
            //Fill_FC_ConnectionSize();
            //Fill_FH_ConnectionSize();
        }

        private void Fill_CoilCoatingManualSelection()
        {

            LblCoatingPriceDetail.Text = Convert.ToDecimal(0m).ToString("N2") + @" $";

            string strPreviousOptionSelected = cboCoilCoating.Text;

            //clear the list
            cboCoilCoating.Items.Clear();

            //add none
            ComboBoxControl.AddItem(cboCoilCoating, "1", "None");

            //2008-11-07: Sylvain Told me Hypoxy Alu and Epoxy alu fins
            //is already a coating and you cannot bake it of put any extra coating
            //on it. He said it happen that we does special case and coat it
            //but that's really really special and this if 1 of millions coil done
            //so it's going into custom unit at that point
            if (cboFinMaterial.Text != @"EPOXY ALUMINIUM" && cboFinMaterial.Text != @"HYPOXY ALUMINIUM")
            {
                //add blygold
                ComboBoxControl.AddItem(cboCoilCoating, "2", "Blygold");

                //check if electro fin available, if yes add it
                if (Query.IsElectroFinAvailable(Public.DSDatabase.Tables["ElectroFinAdjustement"].Copy(), Convert.ToInt32(numRow.Value), Convert.ToInt32((cboFPI.Text.Length == 0 ? "0" : cboFPI.Text))))
                {
                    ComboBoxControl.AddItem(cboCoilCoating, "3", "ElectroFin");
                }

                //check if heresite available, if yes add it
                if (Query.IsHeresiteAvailable(Public.DSDatabase.Tables["HeresiteSafety"].Copy(), Convert.ToDecimal((cboFinHeight.Text.Length == 0 ? "0" : cboFinHeight.Text)), numFinLength.Value))
                {
                    ComboBoxControl.AddItem(cboCoilCoating, "4", "Heresite");
                }
            }

            cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(strPreviousOptionSelected) >= 0 ? cboCoilCoating.FindString(strPreviousOptionSelected) : 0;
        }


        //fill coil coating
        private void Fill_CoilCoating()
        {
            //if we have a coil selected
            if (_dtQuickCoil.Rows.Count > 0)
            {
                string strPreviousOptionSelected = cboCoilCoating.Text;

                //clear the list
                cboCoilCoating.Items.Clear();

                //add none
                ComboBoxControl.AddItem(cboCoilCoating, "1", "None");

                //2008-11-07: Sylvain Told me Hypoxy Alu and Epoxy alu fins
                //is already a coating and you cannot bake it of put any extra coating
                //on it. He said it happen that we does special case and coat it
                //but that's really really special and this if 1 of millions coil done
                //so it's going into custom unit at that point
                if (_dtQuickCoil.Rows[0]["FinMaterialText"].ToString() != "EPOXY ALUMINIUM" && _dtQuickCoil.Rows[0]["FinMaterialText"].ToString() != "HYPOXY ALUMINIUM")
                {
                    //add blygold
                    ComboBoxControl.AddItem(cboCoilCoating, "2", "Blygold");

                    //check if electro fin available, if yes add it
                    if (Query.IsElectroFinAvailable(Public.DSDatabase.Tables["ElectroFinAdjustement"].Copy(), Convert.ToInt32(_dtQuickCoil.Rows[0]["R_Rows"]), Convert.ToInt32(_dtQuickCoil.Rows[0]["FPI"])))
                    {
                        ComboBoxControl.AddItem(cboCoilCoating, "3", "ElectroFin");
                    }

                    //check if heresite available, if yes add it
                    if (Query.IsHeresiteAvailable(Public.DSDatabase.Tables["HeresiteSafety"].Copy(), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinLength"])))
                    {
                        ComboBoxControl.AddItem(cboCoilCoating, "4", "Heresite");
                    }
                }

                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(strPreviousOptionSelected) >= 0 ? cboCoilCoating.FindString(strPreviousOptionSelected) : 0;
            }
        }

        //return the location Winter DB
        private decimal LocationWinterDB()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboLocation, Public.DSDatabase.Tables["Weather"], "UniqueID")[0]["WinterDryBulb"]);
        }

       
        //return the location Summer DB
        private decimal LocationSummerDB()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboLocation, Public.DSDatabase.Tables["Weather"], "UniqueID")[0]["SummerDryBulb"]);
        }

        //return the location Summer WB
        private decimal LocationSummerWB()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboLocation, Public.DSDatabase.Tables["Weather"], "UniqueID")[0]["SummerWetBulb"]);
        }

        //return the location altitude
        private decimal LocationAltitude()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboLocation, Public.DSDatabase.Tables["Weather"], "UniqueID")[0]["Altitude"]);
        }

        //fill locations
        private void Fill_Location()
        {
            cboLocation.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            //sort the weather informations
            DataTable dtSortedWeather = _backgroundCode.OrderWeatherInformations(Public.DSDatabase.Tables["Weather"]);

            //for each location
            foreach (DataRow drLocation in dtSortedWeather.Rows)
            {
                string strIndex = drLocation["UniqueID"].ToString();
                //format ex : "CAN, QC, Montréal"
                string strText = drLocation["Country"] + ", " + drLocation["State"] + ", " + drLocation["City"];
                ComboBoxControl.AddItem(cboLocation, strIndex, strText);
            }

            //select the one we have saved in registry or first if nothing
            ComboBoxControl.SetIDDefaultValue(cboLocation, Reg.Get(Reg.Key.Location));
        }

        //fill circuits
        private void Fill_Circuits()
        {
            ////store the quantity of headers
            //decimal decNumberOfHeader = HeaderQuantity();

            //refresh the multiple circuits combobox
            _backgroundCode.Fill_Circuit(cboDX_NumberOfCircuits, 1);//, decNumberOfHeade);
            _backgroundCode.Fill_Circuit(cboHR_NumberOfCircuits/*, decNumberOfHeader*/);

            //FC and FH use new logic because of design type
            //BackgroundCode.Fill_Circuit(cboFH_NumberOfCircuits/*, decNumberOfHeader*/);
            //BackgroundCode.Fill_Circuit(cboFC_NumberOfCircuits/*, decNumberOfHeader*/);
        }

        //return the connection size selected
        private decimal FH_ConnectionSize()
        {
            //put connection size = 10 if it standard selected, that will
            //allow me to know the connection is STD in the report.
            //I needed to put a the value a number because there is
            //calculation involve in the crystal report with this value
            //in the drawing portion
            return cboFH_ConnectionSize.Text == @"STD" ? 10m : Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFH_ConnectionSize, Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], "UniqueID")[0]["Value"]);
        }

        //return the connection size selected
        private decimal FC_ConnectionSize()
        {
            //put connection size = 10 if it standard selected, that will
            //allow me to know the connection is STD in the report.
            //I needed to put a the value a number because there is
            //calculation involve in the crystal report with this value
            //in the drawing portion
            return cboFC_ConnectionSize.Text == @"STD" ? 10m : Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFC_ConnectionSize, Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], "UniqueID")[0]["Value"]);
        }

        //fill the FC connection
        private void Fill_FC_ConnectionSize()
        {
            cboFC_ConnectionSize.Items.Clear();

            if (_openType == CoilOpenType.Selection ||
                (_openType == CoilOpenType.Manual && cboFC_DesignType.Text == @"Booster" && cboFC_ConnectionType.Text == @"SWEAT"))
            {
                //add standard option
                ComboBoxControl.AddItem(cboFC_ConnectionSize, "STD", "STD");
            }

            string strFilter;
            bool isBoosterSweat = false;

            if (cboFC_DesignType.Text == @"Standard")
            {
                strFilter = cboFC_ConnectionType.Text + "NB";
            }
            else
            {
                strFilter = cboFC_ConnectionType.Text + "B";

                if (cboFC_ConnectionType.Text == @"SWEAT")
                {
                    isBoosterSweat = true;
                }
            }


            if (!isBoosterSweat)
            {
                //these variable as use for easier modification of index or text showing
                //in the combobox

                DataTable dtConnection = Public.SelectAndSortTable(Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], "Availability Like '%" + strFilter + "%'", "Value ASC");

                //for each connection size
                foreach (DataRow drFCConnection in dtConnection.Rows)
                {
                    string strIndex = drFCConnection["UniqueID"].ToString();
                    string strText = drFCConnection["Size"].ToString();
                    ComboBoxControl.AddItem(cboFC_ConnectionSize, strIndex, strText);
                }
            }

            cboFC_ConnectionSize.SelectedIndex = 0;
        }

        //fill the FH connection
        private void Fill_FH_ConnectionSize()
        {
            cboFH_ConnectionSize.Items.Clear();

            if (_openType == CoilOpenType.Selection ||
                (_openType == CoilOpenType.Manual && cboFH_DesignType.Text == @"Booster" && cboFH_ConnectionType.Text == @"SWEAT"))
            {
                //add standard option
                ComboBoxControl.AddItem(cboFH_ConnectionSize, "STD", "STD");
            }

            string strFilter;
            bool isBoosterSweat = false;

            if (cboFH_DesignType.Text == @"Standard")
            {
                strFilter = cboFH_ConnectionType.Text + "NB";
            }
            else
            {
                strFilter = cboFH_ConnectionType.Text + "B";

                if (cboFH_ConnectionType.Text == @"SWEAT")
                {
                    isBoosterSweat = true;
                }
            }


            if (!isBoosterSweat)
            {
                //these variable as use for easier modification of index or text showing
                //in the combobox

                DataTable dtConnection = Public.SelectAndSortTable(Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], "Availability Like '%" + strFilter + "%'", "Value ASC");

                //for each connection size
                foreach (DataRow drFHConnection in dtConnection.Rows)
                {
                    string strIndex = drFHConnection["UniqueID"].ToString();
                    string strText = drFHConnection["Size"].ToString();
                    ComboBoxControl.AddItem(cboFH_ConnectionSize, strIndex, strText);
                }
            }

            cboFH_ConnectionSize.SelectedIndex = 0;
        }

        //return the connection size selected
        private decimal DX_ConnectionSizeInlet()
        {
            //put connection size = 10 if it standard selected, that will
            //allow me to know the connection is STD in the report.
            //I needed to put a the value a number because there is
            //calculation involve in the crystal report with this value
            //in the drawing portion
            return cboDX_ConnectionSizeInlet.Text == @"STD" ? 10m : Convert.ToDecimal(ComboBoxControl.ItemInformations(cboDX_ConnectionSizeInlet, Public.DSDatabase.Tables["ConnectionSize_DX"], "UniqueID")[0]["Value"]);
        }


        //fill the dx connection
        private void Fill_DX_ConnectionSize()
        {
            cboDX_ConnectionSizeInlet.Items.Clear();
            cboDX_ConnectionSizeOutlet.Items.Clear();

            if (_openType == CoilOpenType.Selection)
            {
                //add standard option
                ComboBoxControl.AddItem(cboDX_ConnectionSizeInlet, "STD", "STD");
                ComboBoxControl.AddItem(cboDX_ConnectionSizeOutlet, "STD", "STD");
            }

            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each connection size
            foreach (DataRow drDXConnection in Public.DSDatabase.Tables["ConnectionSize_DX"].Rows)
            {
                string strIndex = drDXConnection["UniqueID"].ToString();
                string strText = drDXConnection["Size"].ToString();
                ComboBoxControl.AddItem(cboDX_ConnectionSizeInlet, strIndex, strText);
                ComboBoxControl.AddItem(cboDX_ConnectionSizeOutlet, strIndex, strText);
            }
        }

        //return the connection size selected
        private decimal HR_SubCoolerConnectionSizeOut()
        {
            //put connection size = 10 if it standard selected, that will
            //allow me to know the connection is STD in the report.
            //I needed to put a the value a number because there is
            //calculation involve in the crystal report with this value
            //in the drawing portion
            return cboHR_SubCoolerConnectionSizeOut.Text == @"STD" ? 10m : Convert.ToDecimal(ComboBoxControl.ItemInformations(cboHR_SubCoolerConnectionSizeOut, Public.DSDatabase.Tables["ConnectionSize_HeatReclaim"], "UniqueID")[0]["Value"]);
        }

        //return the connection size selected
        private decimal HR_SubCoolerConnectionSizeIn()
        {
            //put connection size = 10 if it standard selected, that will
            //allow me to know the connection is STD in the report.
            //I needed to put a the value a number because there is
            //calculation involve in the crystal report with this value
            //in the drawing portion
            return cboHR_SubCoolerConnectionSizeIn.Text == @"STD" ? 10m : Convert.ToDecimal(ComboBoxControl.ItemInformations(cboHR_SubCoolerConnectionSizeIn, Public.DSDatabase.Tables["ConnectionSize_HeatReclaim"], "UniqueID")[0]["Value"]);
        }

        //return the connection size selected
        private decimal HR_ConnectionSizeIn()
        {
            //put connection size = 10 if it standard selected, that will
            //allow me to know the connection is STD in the report.
            //I needed to put a the value a number because there is
            //calculation involve in the crystal report with this value
            //in the drawing portion
            return cboHR_ConnectionSizeIn.Text == @"STD" ? 10m : Convert.ToDecimal(ComboBoxControl.ItemInformations(cboHR_ConnectionSizeIn, Public.DSDatabase.Tables["ConnectionSize_HeatReclaim"], "UniqueID")[0]["Value"]);
        }

        //return the connection size selected
        private decimal HR_ConnectionSizeOut()
        {
            //put connection size = 10 if it standard selected, that will
            //allow me to know the connection is STD in the report.
            //I needed to put a the value a number because there is
            //calculation involve in the crystal report with this value
            //in the drawing portion
            return cboHR_ConnectionSizeOut.Text == @"STD" ? 10m : Convert.ToDecimal(ComboBoxControl.ItemInformations(cboHR_ConnectionSizeOut, Public.DSDatabase.Tables["ConnectionSize_HeatReclaim"], "UniqueID")[0]["Value"]);
        }

        //fill the HR and COND connection
        private void Fill_HR_COND_ConnectionSize()
        {
            cboHR_ConnectionSizeIn.Items.Clear();
            cboHR_ConnectionSizeOut.Items.Clear();
            cboHR_SubCoolerConnectionSizeIn.Items.Clear();
            cboHR_SubCoolerConnectionSizeOut.Items.Clear();

            if (_openType == CoilOpenType.Selection)
            {
                //add standard option
                ComboBoxControl.AddItem(cboHR_ConnectionSizeIn, "STD", "STD");
                ComboBoxControl.AddItem(cboHR_ConnectionSizeOut, "STD", "STD");
                ComboBoxControl.AddItem(cboHR_SubCoolerConnectionSizeIn, "STD", "STD");
                ComboBoxControl.AddItem(cboHR_SubCoolerConnectionSizeOut, "STD", "STD");
            }

            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each connection size
            //NOTE : i use heat reclaim table because it has the easiest format to
            //wor with, i do not need to filter the table in order to show the list
            foreach (DataRow drHRCondConnection in Public.DSDatabase.Tables["ConnectionSize_HeatReclaim"].Rows)
            {
                string strIndex = drHRCondConnection["UniqueID"].ToString();
                string strText = drHRCondConnection["Size"].ToString();
                ComboBoxControl.AddItem(cboHR_ConnectionSizeIn, strIndex, strText);
                ComboBoxControl.AddItem(cboHR_ConnectionSizeOut, strIndex, strText);
                ComboBoxControl.AddItem(cboHR_SubCoolerConnectionSizeIn, strIndex, strText);
                ComboBoxControl.AddItem(cboHR_SubCoolerConnectionSizeOut, strIndex, strText);
            }
        }

        ////get the header lbs per foot
        //private decimal HeaderLbsPerFoot()
        //{
        //    return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboHeaderDiameter, Public.dsDATABASE.Tables["v_CoilHeaderDiameter"], "UniqueID")[0]["HeaderLbsPerFoot"]);
        //}

        ////get the header diameter
        //private decimal HeaderDiameter()
        //{
        //    return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboHeaderDiameter, Public.dsDATABASE.Tables["v_CoilHeaderDiameter"], "UniqueID")[0]["HeaderDiameterValue"]);
        //}

        ////fill header diameter
        //private void Fill_HeaderDiameter()
        //{
        //    cboHeaderDiameter.Items.Clear();
        //    //these variable as use for easier modification of index or text showing
        //    //in the combobox
        //    string strIndex = "";
        //    string strText = "";

        //    DataTable dtHeaderDiameter = BackgroundCode.FilterHeaderDiameter(Public.dsDATABASE.Tables["v_CoilHeaderDiameter"], CoilTypeParameter());
        //    //for each casing material
        //    foreach (DataRow drHeaderDiameter in dtHeaderDiameter.Rows)
        //    {
        //        strIndex = drHeaderDiameter["UniqueID"].ToString();
        //        strText = drHeaderDiameter["HeaderDiameter"].ToString();
        //        ComboBoxControl.AddItem(cboHeaderDiameter, strIndex, strText);
        //    }

        //    //if we have something inside select first one
        //    if (cboHeaderDiameter.Items.Count > 0)
        //    {
        //        cboHeaderDiameter.SelectedIndex = 0;
        //    }

        //    //dispose
        //    dtHeaderDiameter.Dispose();
        //    dtHeaderDiameter = null;
        //}

        //fill the casing Thickness
        private void Fill_CasingThickness()
        {
            cboCasingThickness.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtCasingThickness = _backgroundCode.FilterCasingThickness(Public.DSDatabase.Tables["CoilCasingThickness"], CasingMaterialID());
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
                cboCasingThickness.SelectedIndex = cboCasingThickness.Items.IndexOf("0.064") >= 0 ? cboCasingThickness.Items.IndexOf("0.064") : 0;
            }

            //dispose
            dtCasingThickness.Dispose();
        }

        //return the Casing Price Per Lbs
        private decimal CasingPricePerLbs()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboCasingMaterial, Public.DSDatabase.Tables["v_CoilCasingMaterialDefaults"], "UniqueID")[0]["PricePerLbs"]);
        }

        //return the Casing Density
        private decimal CasingDensity()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboCasingMaterial, Public.DSDatabase.Tables["v_CoilCasingMaterialDefaults"], "UniqueID")[0]["MaterialDensity"]);
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

            DataTable dtCasingMaterial = _backgroundCode.FilterCasingMaterial(Public.DSDatabase.Tables["v_CoilCasingMaterialDefaults"], CoilTypeParameter());
            //for each casing material
            foreach (DataRow drCasingMaterial in dtCasingMaterial.Rows)
            {
                string strIndex = drCasingMaterial["UniqueID"].ToString();
                string strText = drCasingMaterial["CasingMaterial"].ToString();
                ComboBoxControl.AddItem(cboCasingMaterial, strIndex, strText);
            }

            //if we have something inside select first one
            if (cboCasingMaterial.Items.Count > 0)
            {
                cboCasingMaterial.SelectedIndex = 0;
            }

            //dispose
            dtCasingMaterial.Dispose();
        }

        private string FH_FluidTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFH_FluidType, Public.DSDatabase.Tables["CoilFluidType"], "UniqueID")[0]["FluidTypeParameter"].ToString();
        }

        private void Fill_FH_FluidType()
        {
            cboFH_FluidType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each fluid type
            foreach (DataRow drFHFluidType in Public.DSDatabase.Tables["CoilFluidType"].Rows)
            {
                string strIndex = drFHFluidType["UniqueID"].ToString();
                string strText = drFHFluidType["FluidType"].ToString();
                ComboBoxControl.AddItem(cboFH_FluidType, strIndex, strText);
            }
        }

        private string FC_FluidTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFC_FluidType, Public.DSDatabase.Tables["CoilFluidType"], "UniqueID")[0]["FluidTypeParameter"].ToString();
        }

        private void Fill_FC_FluidType()
        {
            cboFC_FluidType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each fluid type
            foreach (DataRow drFCFluidType in Public.DSDatabase.Tables["CoilFluidType"].Rows)
            {
                string strIndex = drFCFluidType["UniqueID"].ToString();
                string strText = drFCFluidType["FluidType"].ToString();
                ComboBoxControl.AddItem(cboFC_FluidType, strIndex, strText);
            }
        }

        //return the Fin shape Image Location
        private string FinShapeImageLocation()
        {
            return ComboBoxControl.ItemInformations(cboFinShape, Public.DSDatabase.Tables["CoilFinShape"], "UniqueID")[0]["FinShapePictureRelativePath"].ToString();
        }

        //return the Fin shape parameter needed i nthe DLL and maybe some conditions
        private string FinShapeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinShape, Public.DSDatabase.Tables["CoilFinShape"], "UniqueID")[0]["FinShapeParameter"].ToString();
        }

        private void Fill_FinShape()
        {
            cboFinShape.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //fin type
            string strFinType = FinTypeParameter();
            //for each fin Shape
            foreach (DataRow drFinShape in Public.DSDatabase.Tables["CoilFinShape"].Rows)
            {
                if (_backgroundCode.IsFinShapeAvailable(Public.DSDatabase.Tables["CoilFinTypeShape"], strFinType, drFinShape["FinShapeParameter"].ToString()))
                {
                    string strIndex = drFinShape["UniqueID"].ToString();
                    string strText = drFinShape["FinShape"].ToString();
                    ComboBoxControl.AddItem(cboFinShape, strIndex, strText);
                }
            }
            if (cboFinShape.Items.Count > 0)
            {
                cboFinShape.SelectedIndex = 0;
            }
        }

        //return Connection side model parameter
        private string ModelNameFormatedConstructionSide()
        {
            //value that will be returned
            string strReturnValue;

            //depend on the connection side, diferent value returned
            if (cboConnectionSide.Text == @"Right side (air flow towards you)")
            {
                strReturnValue = "-RH";
            }
            else if (cboConnectionSide.Text == @"Left side (air flow towards you)")
            {
                strReturnValue = "-LH";
            }
            else //n\a is selected we want no text to show
            {
                strReturnValue = "";
            }

            return strReturnValue;
        }

        //return Formated  (Fin Height / face tubes)
        private string ModelNameFormatedFinHeightDivideByFaceTube()
        {
            return Convert.ToInt32(FinHeightParameter() / FinTypeFaceTube()).ToString(CultureInfo.InvariantCulture).PadLeft(2, Convert.ToChar("0"));
        }

        //return the Coil Model Name Prefix
        private string CoilModelNamePrefix()
        {
            //value to return
            string strReturnValue = "";

            //depending on the coil different prefix
            switch (CoilTypeParameter())
            {
                case "DX":
                    strReturnValue = "D";
                    break;
                case "HR":
                    strReturnValue = "C";
                    break;
                case "FH":
                    strReturnValue = cboFH_DesignType.Text == @"Standard" ? "W" : "B";
                    break;
                case "FC":
                    strReturnValue = cboFC_DesignType.Text == @"Standard" ? "W" : "B";
                    break;
                case "ST":
                    //if steam coil type is standard then S else N
                    strReturnValue = cboSTEAM_CoilType.Text == @"Standard Steam" ? "S" : "N";
                    break;
            }

            return strReturnValue;
        }

        //Coil Model Name
        private string CoilModelName()
        {
            //variable that will be return and contian the model name

            //add the prefix
            string strReturnValue = CoilModelNamePrefix();

            //add the fin Type
            strReturnValue = strReturnValue + FinTypeParameter();

            //add the fin shape
            strReturnValue = strReturnValue + FinShapeParameter();

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add the tubes
            strReturnValue = strReturnValue + ModelNameFormatedFinHeightDivideByFaceTube();

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add number of rows (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + Convert.ToInt32(numRow.Value).ToString(CultureInfo.InvariantCulture).PadLeft(2, Convert.ToChar("0"));

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add FPI (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + cboFPI.Text.PadLeft(2, Convert.ToChar("0"));

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add fin length (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + numFinLength.Value.ToString("0#.###");

            //add the contruction side
            strReturnValue = strReturnValue + ModelNameFormatedConstructionSide();

            return strReturnValue;
        }

        //return the coil type parameter
        private string CoilTypeParameter()
        {
            if (cboCoilType.Items.Count == 0)
                return null;
            return ComboBoxControl.ItemInformations(cboCoilType, Public.DSDatabase.Tables["CoilType"], "UniqueID")[0]["CoilTypeParameter"].ToString();
        }

        private void Fill_CoilType()
        {
            cboCoilType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each coil type
            foreach (DataRow drCoilType in Public.DSDatabase.Tables["CoilType"].Rows)
            {
                //this is an output example
                //C - 3/8", 1" X 3/4"
                string strIndex = drCoilType["UniqueID"].ToString();
                string strText = drCoilType["CoilType"].ToString();
                if (strText != "Gas Cooler" || UserInformation.Userlevel >= 99)
                {
                    ComboBoxControl.AddItem(cboCoilType, strIndex, strText);
                }
            }
        }

        //return the TubeDiagonal
        private decimal FinTypeTubeDiagonal()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["TubeDiagonal"]);
        }

        //return the TubeDiameter 
        private decimal FinTypeTubeDiameter()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["TubeDiameter"]);
        }

        //return the TubeRow Amount of the selected FinType
        private decimal FinTypeTubeRow()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["TubeRow"]);
        }

        //return the FaceTube Amount of the selected FinType
        private decimal FinTypeFaceTube()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FaceTube"]);
        }

        //return the FinType Parameter
        private string FinTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString();
        }

        private void Fill_FinType()
        {
            //default class
            var cd = new ComboboxDefault(cboFinType);

            cboFinType.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinType in Public.DSDatabase.Tables["CoilFinType"].Rows)
            {
                //if we can found the fintype in the table that mean it's available for
                //the selected coil type so we can show it

                //2010-09-23 : As per email confirmation of Simon on 2010-09-22 3:09 PM
                //Question : 
                //Toutes les restrictions sur quoi que ce soit, qui ont rapport au R-410a 
                //et qui touche au Coil ou au Condensers doivent etre enlevées. 
                //Answer : 
                //Oui c’est confirmé.
                //if (BackgroundCode.IsFinTypeAvailableForThisCoil(Public.dsDATABASE.Tables["v_CoilFinTypeDefaults"].Copy(), drFinType["UniqueID"].ToString(), ComboBoxControl.IndexInformation(cboCoilType), (CoilTypeParameter() == "HR" && cboHR_RefrigerantType.Text.ToUpper() == "R-410A" ? true : false)))
                //{

                //2012-05-22 : #3065 : adding restriction the the Heat reclaim so it cannot have G on r410A
                //i'll reuse the boolean that was there before and re-enable the code. i already changed
                //the database to have the new records
                if (_backgroundCode.IsFinTypeAvailableForThisCoil(Public.DSDatabase.Tables["v_CoilFinTypeDefaults"].Copy(), drFinType["UniqueID"].ToString(), ComboBoxControl.IndexInformation(cboCoilType), (CoilTypeParameter() == "HR" && cboHR_RefrigerantType.Text.ToUpper() == "R-410A")))
                {
                    //2012-07-30 : #2998 Temporary code to prevent K fin for non refplus people
                    if (!(drFinType["FinType"].ToString() == "K" && !HaveAccessToKFinAndR744() && !(UserInformation.UserName == "ahomsy" || UserInformation.UserName == "drobichaud")))
                    {
                        //this is an output example
                        //C - 3/8", 1" X 3/4"
                        string strIndex = drFinType["UniqueID"].ToString();
                        string strText = drFinType["FinType"] + " - " + drFinType["TubeDiameter"] + "\", " + drFinType["FaceTube"] + "\" X " + drFinType["TubeRow"] + "\"";
                        ComboBoxControl.AddItem(cboFinType, strIndex, strText);
                    }
                }
            }


            //re default the item if still exist
            cd.ReDefault_Existing();
          
        }

        private bool IsNormalSelectionAndPerformanceOpened()
        {
            bool bolResult = false;

            if (_openType == CoilOpenType.Selection)
            {
                foreach (object obj in Controls)
                {
                    var panel = obj as Panel;
                    if (panel != null)
                    {
                        try
                        {
                            if (panel.Tag != null)
                            {
                                if (panel.Tag.ToString() == "RESULTPANEL")
                                {
                                    bolResult = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Public.PushLog(ex.ToString(), "frmQuickCoil IsNormalSelectionAndPerformanceOpened");
                        }
                    }
                }
            }

            return bolResult;
        }

        private void DeletePerformanceControls()
        {
            for (int iObj = 0; iObj < Controls.Count; iObj++)
            {
                if (Controls[iObj].GetType() == typeof(Panel))
                {
                    if (Controls[iObj].Tag.ToString() == "RESULTPANEL")
                    {
                        for (int iInnerObj = 0; iInnerObj < Controls[iObj].Controls.Count; iInnerObj++)
                        {
                            if (Controls[iObj].Controls[iInnerObj].GetType() == typeof(GlacialComponents.Controls.GlacialList))
                            {
                                Controls[iObj].Controls[iInnerObj].Dispose();
                            }
                        }
                        Controls[iObj].Dispose();
                    }
                }
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

            if (_quoteform != null)
            {
                _quoteform.ClearSQL(_intIndex);
            }
            Dispose();
            
        }

        private void cboCoilType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //hide all coil panels
            HideAllCoilPanels();

            string strCoilType = CoilTypeParameter();
            //show the panel we want
            switch (strCoilType)
            {
                case "DX":
                    pnlDX.Visible = true;
                    pnlDX.Enabled = true;
                    ValidateRefWithShape();
                    break;
                case "HR":
                    pnlHR.Visible = true;
                    pnlHR.Enabled = true;
                    ValidateRefWithShape();
                    break;
                case "FH":
                    pnlFH.Visible = true;
                    pnlFH.Enabled = true;
                    lblTurbulators.Visible = true;
                    cboTurbulator.Visible = true;
                    break;
                case "FC":
                    pnlFC.Visible = true;
                    pnlFC.Enabled = true;
                    lblTurbulators.Visible = true;
                    cboTurbulator.Visible = true;
                    break;
                case "ST":
                    pnlSTEAM.Visible = true;
                    pnlSTEAM.Enabled = true;
                    break;
                case "GC":
                    pnlGC.Visible = true;
                    pnlGC.Enabled = true;
                    break;
            }

            //validate rows
            ValidateRows();

            //fin height is dependent on FinType
            cboFinHeight.Items.Clear();
            //fintype as a bearing on FPI
            cboFPI.Items.Clear();
            //FPI as a bearing on Fin material
            cboFinMaterial.Items.Clear();
            //fin material as a bearing on fin thickness
            cboFinThickness.Items.Clear();

            cboTubeMaterial.Items.Clear();
            cboTubeThickness.Items.Clear();

            //now call the fill of the fintype
            Fill_FinType();

            //fill the casing material, since it depend on coil type
            Fill_CasingMaterial();

            //validate turbulator
            ValidateTurbulator();

            //validate the fin length
            ValidateFinLength(strCoilType);

            if (_openType == CoilOpenType.Manual)
            {
                RellocateAllControlsForManualSelectionMode();
            }
        }

        //validate the rows
        private void ValidateRows()
        {
            switch (CoilTypeParameter())
            {
                case "DX":
                case "FC":
                    //make sure the range wont cause problem when changing value
                    numRow.Minimum = 0m;
                    numRow.Maximum = 100m;
                    //set the value
                    numRow.Value = 4m;
                    //set the limits
                    numRow.Minimum = 1m;
                    numRow.Maximum = 20m;
                    break;
                case "ST":
                    //make sure the range wont cause problem when changing value
                    numRow.Minimum = 0m;
                    numRow.Maximum = 100m;
                    //set the value
                    numRow.Value = 2m;
                    //set the limits
                    numRow.Minimum = 1m;
                    numRow.Maximum = 2m;
                    break;
                case "HR":
                case "FH":
                    //make sure the range wont cause problem when changing value
                    numRow.Minimum = 0m;
                    numRow.Maximum = 100m;
                    //set the value
                    numRow.Value = 2m;
                    //set the limits
                    numRow.Minimum = 1m;
                    numRow.Maximum = 20m;
                    break;
            }
        }

        private void cmdRunSelection_Click(object sender, EventArgs e)
        {
            RunSelection();
        }

        private void RunSelection()
        {
            //if all the required fields are filled
            if (AllFieldsFilled())
            {
                cmdCancel.Visible = false;
                decimal decFHFreezeStat = -99m;
                if (ValidateFieldsValue(ref decFHFreezeStat))
                {
                    //start working process
                    ThreadProcess.Start(Public.LanguageString("Running Selection", "Sélection en cours"));

                    //refresh the QuickCoil datatable to have the latest 
                    //information loaded into memory
                    RefreshQuickCoilTable();

                    bool bolSelectionResult = true;

                    string errorMessage = "";

                    //set the freeze stat value
                    _dtQuickCoil.Rows[0]["FHFreezeStat"] = decFHFreezeStat;

                    switch (CoilTypeParameter())
                    {
                        case "DX"://DX
                            //execute the DX coil selection
                            bolSelectionResult = _backgroundCode.Run_DX_Selection(_dtQuickCoil, ref errorMessage);

                            _dtQuickCoil.Rows[0]["R_ARI_STANDARD"] = _backgroundCode.ARI_Standard_DX();

                            //if entering WetBuld =0 and Total heat = 0 then total heat = sensible heat
                            if (Convert.ToDecimal(_dtQuickCoil.Rows[0]["DXEnteringWetBulb"]) == 0m && Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]) == 0m)
                            {
                                _dtQuickCoil.Rows[0]["R_TotalHeat"] = _dtQuickCoil.Rows[0]["R_SensibleHeat"];
                            }

                            //if the selection was good, change the connections
                            //if they were STD
                            if (bolSelectionResult && Convert.ToDecimal(_dtQuickCoil.Rows[0]["DXConnectionSizeIn"]) == 10m)
                            {
                                _dtQuickCoil.Rows[0]["DXConnectionSizeIn"] = _backgroundCode.GetConnectionSizeDXInlet(Public.DSDatabase.Tables["StandardConnectionDXInlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]), 100m, _dtQuickCoil.Rows[0]["DXRefrigerantType"].ToString());
                            }
                            if (bolSelectionResult && Convert.ToDecimal(_dtQuickCoil.Rows[0]["DXConnectionSizeOut"]) == 10m)
                            {
                                _dtQuickCoil.Rows[0]["DXConnectionSizeOut"] = _backgroundCode.GetConnectionSizeDXOutlet(Public.DSDatabase.Tables["StandardConnectionDXOutlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["DXSuctionTemperature"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]), 100m, _dtQuickCoil.Rows[0]["DXRefrigerantType"].ToString());
                            }

                            //calculate the weight
                            _dtQuickCoil.Rows[0]["Weight"] = _backgroundCode.GetCoilWeight(FinHeightParameter(), numFinLength.Value, FinTypeFaceTube(), FinTypeTubeDiameter(), FinTypeTubeRow(), numRow.Value, Convert.ToDecimal(cboFPI.Text), CasingDensity(), Convert.ToDecimal(cboCasingThickness.Text), FinDensity(), Convert.ToDecimal(FinThicknessParameter()), TubeDensity(), Convert.ToDecimal(TubeThicknessParameter()), _backgroundCode.ConnectionSizePoundsPerFoot(Public.DSDatabase.Tables["ConnectionSize_PoundsPerFoot"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["DXConnectionSizeIn"])));
                            break;
                        case "HR"://Heat Reclaim
                            //execute the HR coil selection
                            bolSelectionResult = _backgroundCode.Run_HR_Selection(_dtQuickCoil, ref errorMessage);

                            _dtQuickCoil.Rows[0]["R_ARI_STANDARD"] = _backgroundCode.ARI_Standard_HR();
                            //if the selection was good, change the connections
                            //if they were STD
                            if (bolSelectionResult)
                            {
                                //condenser use different table than the Heat reclaim
                                if (_dtQuickCoil.Rows[0]["HRCoilDesign"].ToString() == "Condenser")
                                {
                                    //if inlet is STD
                                    if (Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRConnectionSizeIn"]) == 10m)
                                    {
                                        _dtQuickCoil.Rows[0]["HRConnectionSizeIn"] = _backgroundCode.GetConnectionSizeHRInlet(Public.DSDatabase.Tables["StandardConnectionCondenserInlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]), 100m, _dtQuickCoil.Rows[0]["HRRefrigerantType"].ToString());
                                    }

                                    //if outlet is STD
                                    if (Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRConnectionSizeOut"]) == 10m)
                                    {
                                        _dtQuickCoil.Rows[0]["HRConnectionSizeOut"] = _backgroundCode.GetConnectionSizeHROutlet(Public.DSDatabase.Tables["StandardConnectionCondenserOutlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]), 100m, _dtQuickCoil.Rows[0]["HRRefrigerantType"].ToString());
                                    }

                                    if (_dtQuickCoil.Rows[0]["HRSubCooler"].ToString().ToUpper() == "YES")
                                    {
                                        //if inlet is STD
                                        if (Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRSubCoolerConnectionSizeIn"]) == 10m)
                                        {
                                            _dtQuickCoil.Rows[0]["HRSubCoolerConnectionSizeIn"] = _backgroundCode.GetConnectionSizeHRInlet(Public.DSDatabase.Tables["StandardConnectionCondenserInlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]) + Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SubCoolerCapacity"]), 100m, _dtQuickCoil.Rows[0]["HRRefrigerantType"].ToString());
                                        }

                                        //if outlet is STD
                                        if (Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRSubCoolerConnectionSizeOut"]) == 10m)
                                        {
                                            _dtQuickCoil.Rows[0]["HRSubCoolerConnectionSizeOut"] = _backgroundCode.GetConnectionSizeHROutlet(Public.DSDatabase.Tables["StandardConnectionCondenserOutlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]) + Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SubCoolerCapacity"]), 100m, _dtQuickCoil.Rows[0]["HRRefrigerantType"].ToString());
                                        }
                                    }

                                }
                                else
                                {
                                    if (Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRConnectionSizeIn"]) == 10m)
                                    {
                                        _dtQuickCoil.Rows[0]["HRConnectionSizeIn"] = _backgroundCode.GetConnectionSizeHROutlet(Public.DSDatabase.Tables["StandardConnectionCondenserInlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]), 100m, _dtQuickCoil.Rows[0]["HRRefrigerantType"].ToString());
                                    }

                                    if (Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRConnectionSizeOut"]) == 10m)
                                    {
                                        _dtQuickCoil.Rows[0]["HRConnectionSizeOut"] = _backgroundCode.GetConnectionSizeHROutlet(Public.DSDatabase.Tables["StandardConnectionCondenserInlet"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]), 100m, _dtQuickCoil.Rows[0]["HRRefrigerantType"].ToString());
                                    }

                                }
                            }
                            //calculate the weight
                            _dtQuickCoil.Rows[0]["Weight"] = _backgroundCode.GetCoilWeight(FinHeightParameter(), numFinLength.Value, FinTypeFaceTube(), FinTypeTubeDiameter(), FinTypeTubeRow(), numRow.Value, Convert.ToDecimal(cboFPI.Text), CasingDensity(), Convert.ToDecimal(cboCasingThickness.Text), FinDensity(), Convert.ToDecimal(FinThicknessParameter()), TubeDensity(), Convert.ToDecimal(TubeThicknessParameter()), _backgroundCode.ConnectionSizePoundsPerFoot(Public.DSDatabase.Tables["ConnectionSize_PoundsPerFoot"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRConnectionSizeIn"])));
                            break;
                        case "FH"://Fluid Heating
                            //execute the FH coil selection
                            bolSelectionResult = _backgroundCode.Run_FH_Selection(_dtQuickCoil, ref errorMessage);

                            _dtQuickCoil.Rows[0]["R_ARI_STANDARD"] = _backgroundCode.ARI_Standard_FH(_dtQuickCoil.Rows[0]["FinType"].ToString(), FinHeightParameter(), FinTypeFaceTube(), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FHEnteringDryBulb"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_WaterVelocity"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FHEnteringLiquidTemperature"]), _dtQuickCoil.Rows[0]["FHFluidType"].ToString(), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FHConcentration"]));
                            //if the function is successfull and the connection is 10
                            //it mean it was a standard selected connection
                            if (bolSelectionResult && Convert.ToDecimal(_dtQuickCoil.Rows[0]["FHConnectionSizeIn"]) == 10m)
                            {
                                if (_dtQuickCoil.Rows[0]["FHDesignType"].ToString() == "Booster" && _dtQuickCoil.Rows[0]["FHConnectionType"].ToString() == "SWEAT")
                                {
                                    _dtQuickCoil.Rows[0]["FHConnectionSizeIn"] = _dtQuickCoil.Rows[0]["TubeDiameter"];
                                }
                                else
                                {
                                    //set the 2 connections
                                    _dtQuickCoil.Rows[0]["FHConnectionSizeIn"] = _backgroundCode.GetConnectionSizeFCFH(Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_GPM"]) / Convert.ToDecimal(_dtQuickCoil.Rows[0]["HeaderQuantity"]), cboFH_DesignType.Text, cboFH_ConnectionType.Text);
                                }

                                _dtQuickCoil.Rows[0]["FHConnectionSizeOut"] = _dtQuickCoil.Rows[0]["FHConnectionSizeIn"];

                                //re-execute the FC coil selection
                                bolSelectionResult = _backgroundCode.Run_FH_Selection(_dtQuickCoil, ref errorMessage);
                            }
                            //calculate the weight
                            _dtQuickCoil.Rows[0]["Weight"] = _backgroundCode.GetCoilWeight(FinHeightParameter(), numFinLength.Value, FinTypeFaceTube(), FinTypeTubeDiameter(), FinTypeTubeRow(), numRow.Value, Convert.ToDecimal(cboFPI.Text), CasingDensity(), Convert.ToDecimal(cboCasingThickness.Text), FinDensity(), Convert.ToDecimal(FinThicknessParameter()), TubeDensity(), Convert.ToDecimal(TubeThicknessParameter()), _backgroundCode.ConnectionSizePoundsPerFoot(Public.DSDatabase.Tables["ConnectionSize_PoundsPerFoot"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["FHConnectionSizeIn"])));

                            break;
                        case "FC"://Fluid Cooling
                            //execute the FC coil selection
                            bolSelectionResult = _backgroundCode.Run_FC_Selection(_dtQuickCoil, ref errorMessage);

                            _dtQuickCoil.Rows[0]["R_ARI_STANDARD"] = _backgroundCode.ARI_Standard_FC(_dtQuickCoil.Rows[0]["FinType"].ToString(), FinHeightParameter(), FinTypeFaceTube(), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FCEnteringDryBulb"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FCEnteringWetBulb"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_WaterVelocity"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FCEnteringLiquidTemperature"]), _dtQuickCoil.Rows[0]["FCFluidType"].ToString(), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FCConcentration"]));

                            //if the function is successfull and the connection is 10
                            //it mean it was a standard selected connection
                            if (bolSelectionResult && Convert.ToDecimal(_dtQuickCoil.Rows[0]["FCConnectionSizeIn"]) == 10m)
                            {
                                if (_dtQuickCoil.Rows[0]["FCDesignType"].ToString() == "Booster" && _dtQuickCoil.Rows[0]["FCConnectionType"].ToString() == "SWEAT")
                                {
                                    _dtQuickCoil.Rows[0]["FCConnectionSizeIn"] = _dtQuickCoil.Rows[0]["TubeDiameter"];
                                }
                                else
                                {
                                    _dtQuickCoil.Rows[0]["FCConnectionSizeIn"] = _backgroundCode.GetConnectionSizeFCFH(Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_GPM"]) / Convert.ToDecimal(_dtQuickCoil.Rows[0]["HeaderQuantity"]), cboFC_DesignType.Text, cboFC_ConnectionType.Text);

                                }
                                _dtQuickCoil.Rows[0]["FCConnectionSizeOut"] = _dtQuickCoil.Rows[0]["FCConnectionSizeIn"];

                                //re-execute the FC coil selection
                                bolSelectionResult = _backgroundCode.Run_FC_Selection(_dtQuickCoil, ref errorMessage);
                            }
                            //calculate the weight
                            _dtQuickCoil.Rows[0]["Weight"] = _backgroundCode.GetCoilWeight(FinHeightParameter(), numFinLength.Value, FinTypeFaceTube(), FinTypeTubeDiameter(), FinTypeTubeRow(), numRow.Value, Convert.ToDecimal(cboFPI.Text), CasingDensity(), Convert.ToDecimal(cboCasingThickness.Text), FinDensity(), Convert.ToDecimal(FinThicknessParameter()), TubeDensity(), Convert.ToDecimal(TubeThicknessParameter()), _backgroundCode.ConnectionSizePoundsPerFoot(Public.DSDatabase.Tables["ConnectionSize_PoundsPerFoot"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["FCConnectionSizeIn"])));

                            break;
                        case "ST"://Steam
                            //execute the STEAM coil selection
                            bolSelectionResult = _backgroundCode.Run_STEAM_Selection(_dtQuickCoil, ref errorMessage);

                            _dtQuickCoil.Rows[0]["R_ARI_STANDARD"] = _backgroundCode.ARI_Standard_STEAM();

                            //calculate the weight
                            _dtQuickCoil.Rows[0]["Weight"] = _backgroundCode.GetCoilWeight(FinHeightParameter(), numFinLength.Value, FinTypeFaceTube(), FinTypeTubeDiameter(), FinTypeTubeRow(), numRow.Value, Convert.ToDecimal(cboFPI.Text), CasingDensity(), Convert.ToDecimal(cboCasingThickness.Text), FinDensity(), Convert.ToDecimal(FinThicknessParameter()), TubeDensity(), Convert.ToDecimal(TubeThicknessParameter()), _backgroundCode.ConnectionSizePoundsPerFoot(Public.DSDatabase.Tables["ConnectionSize_PoundsPerFoot"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["STEAMSteamConnection"])));

                            break;
                        case "GC"://
                            //execute the GC coil selection
                            bolSelectionResult = _backgroundCode.Run_GC_Selection(_dtQuickCoil, ref errorMessage);

                            //calculate the weight
                            _dtQuickCoil.Rows[0]["Weight"] = _backgroundCode.GetCoilWeight(FinHeightParameter(), numFinLength.Value, FinTypeFaceTube(), FinTypeTubeDiameter(), FinTypeTubeRow(), numRow.Value, Convert.ToDecimal(cboFPI.Text), CasingDensity(), Convert.ToDecimal(cboCasingThickness.Text), FinDensity(), Convert.ToDecimal(FinThicknessParameter()), TubeDensity(), Convert.ToDecimal(TubeThicknessParameter()), _backgroundCode.ConnectionSizePoundsPerFoot(Public.DSDatabase.Tables["ConnectionSize_PoundsPerFoot"], Convert.ToDecimal(_dtQuickCoil.Rows[0]["DXConnectionSizeIn"])));
                            break;
                    }

                    if (bolSelectionResult)
                    {
                        DisplayResults(BuildData());

                        //fill the possible coating
                        Fill_CoilCoating();
                    }
                    else
                    {
                        ThreadProcess.Stop();
                        Focus();
                        //popup the error message that the dll cannot calculate
                        MessageForErrorInDLL(errorMessage);
                    }

                    //stop working process
                    ThreadProcess.Stop();
                    Focus();
                    
                }
            }
            else
            {
                Public.LanguageBox("Some fields are not filled", "Certain champs ne sont pas remplis");
            }
        }

        private decimal GetTurbulatorFactor()
        {
            decimal turbulatorFactor = 0m;

            if (Public.DSDatabase.Tables["CoilTurbulatorPriceFactor"].Rows.Count > 0)
            {
                turbulatorFactor = Convert.ToDecimal(Public.DSDatabase.Tables["CoilTurbulatorPriceFactor"].Rows[0]["Factor"]);
            }

            return turbulatorFactor;
        }

        private decimal GetCoilPriceManualSelection(ref decimal decTurbulatorAdder)
        {
            decimal decCoilPrice;

            //if the coil is a steam and the type is non freeze it
            //use a different calculation for the coil pricing
            if (CoilTypeParameter() == "ST" && cboSTEAM_CoilType.Text == @"Steam Distributing")
            {
                //coil pricing
                var steamCoil = new Pricing.SteamCoil(
                    FinTypeParameter(),
                    numQuantity.Value,
                    numRow.Value,
                    Convert.ToDecimal(cboFPI.Text),
                    FinHeightParameter(),
                    numFinLength.Value,
                    Convert.ToDecimal(cboManualConnectionSize.Text),
                   Convert.ToDecimal(FinThicknessParameter()),
                    cboTubeMaterial.Text,
                    Convert.ToDecimal(TubeThicknessParameter()),
                    Convert.ToDecimal(cboCasingThickness.Text),
                    FinDensity(),
                    FinPricePerLbs(),
                    CasingDensity(),
                    CasingPricePerLbs(),
                    TubeDensity(),
                    TubePricePerLbs(),
                    _backgroundCode.GetHeaderQuantity_ST("Steam Distributing", numFinLength.Value));

                //get the coil price
                decCoilPrice = steamCoil.Price;

                //dispose
            }
            else
            {
                decimal decHeaderDiameter = 0m;

                //fluid cooling and heating use the connection size generated
                //by the dll, others use header diameter the control
                switch (CoilTypeParameter())
                {
                    case "DX":
                        decHeaderDiameter = DX_ConnectionSizeInlet();
                        break;
                    case "FC":
                        decHeaderDiameter = FC_ConnectionSize();
                        break;
                    case "FH":
                        decHeaderDiameter = FH_ConnectionSize();
                        break;
                    case "HR":
                        decHeaderDiameter = HR_ConnectionSizeIn();
                        break;
                    case "ST":
                        decHeaderDiameter = Math.Max(Convert.ToDecimal(cboSTEAM_SteamConnection.Text), Convert.ToDecimal(cboSTEAM_CondensateConnection.Text));
                        break;
                }

                if (txtManualModelName.Text.StartsWith("B"))
                {
                    if (cboTurbulator.Text == @"YES")
                    {
                        //coil pricing
                        var coilForTurbulator = new Pricing.BoosterCoil(
                            FinTypeParameter(),
                            numQuantity.Value,
                            numRow.Value,
                            Convert.ToDecimal(cboFPI.Text),
                            FinHeightParameter(),
                            numFinLength.Value,
                            0.625m,
                            0.006m,
                            "COPPER",
                            0.016m,
                            0.064m,
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]),
                            2m/*In refplus quote it use 2 headers at 0.625" all the time*/);

                        decTurbulatorAdder = coilForTurbulator.Price * GetTurbulatorFactor();
                    }

                    //coil pricing
                    var boosterCoil = new Pricing.BoosterCoil(
                        FinTypeParameter(),
                        numQuantity.Value,
                        numRow.Value,
                        Convert.ToDecimal(cboFPI.Text),
                        FinHeightParameter(),
                        numFinLength.Value,
                        0.625m,
                        Convert.ToDecimal(FinThicknessParameter()),
                        cboTubeMaterial.Text,
                        Convert.ToDecimal(TubeThicknessParameter()),
                        Convert.ToDecimal(cboCasingThickness.Text),
                        FinDensity(),
                        FinPricePerLbs(),
                        CasingDensity(),
                        CasingPricePerLbs(),
                        TubeDensity(),
                        TubePricePerLbs(),
                        2m/*In refplus quote it use 2 headers at 0.625" all the time*/);

                    //get the coil price
                    decCoilPrice = boosterCoil.Price;

                    //dispose
                }
                else
                {
                    if (cboTurbulator.Text == @"YES")
                    {
                        //coil pricing
                        var coilForTurbulator = new Pricing.StandardCoil(
                            FinTypeParameter(),
                            numQuantity.Value,
                            numRow.Value,
                            Convert.ToDecimal(cboFPI.Text),
                            FinHeightParameter(),
                            numFinLength.Value,
                            decHeaderDiameter,
                            0.006m,
                            "COPPER",
                            0.016m,
                            0.064m,
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]));

                        decTurbulatorAdder = coilForTurbulator.Price * GetTurbulatorFactor();
                    }

                    //coil pricing
                    var standardCoil = new Pricing.StandardCoil(
                        FinTypeParameter(),
                        numQuantity.Value,
                        numRow.Value,
                        Convert.ToDecimal(cboFPI.Text),
                        FinHeightParameter(),
                        numFinLength.Value,
                        decHeaderDiameter,
                        Convert.ToDecimal(FinThicknessParameter()),
                        cboTubeMaterial.Text,
                        Convert.ToDecimal(TubeThicknessParameter()),
                        Convert.ToDecimal(cboCasingThickness.Text),
                        FinDensity(),
                        FinPricePerLbs(),
                        CasingDensity(),
                        CasingPricePerLbs(),
                        TubeDensity(),
                        TubePricePerLbs());

                    //get the coil price
                    decCoilPrice = standardCoil.Price;

                    //dispose
                }
            }

            //2012-04-24 : #2992 : coil price + 30% if sample coil checked off
            if (chkSampleCoil.Checked)
            {
                decCoilPrice *= 1.3m;
            }

            return decCoilPrice;
        }

        private decimal GetCoilPrice(ref decimal decTurbulatorAdder)
        {
            decimal decCoilPrice;

            //if the coil is a steam and the type is steam distributing it
            //use a different calculation for the coil pricing
            if (_dtQuickCoil.Rows[0]["CoilType"].ToString() == "ST" && _dtQuickCoil.Rows[0]["STEAMSteamCoilType"].ToString() == "Steam Distributing")
            {
                //coil pricing
                var steamCoil = new Pricing.SteamCoil(
                    _dtQuickCoil.Rows[0]["FinType"].ToString(),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["Quantity"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_Rows"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["FPI"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinHeight"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinLength"]),
                    Math.Max(Convert.ToDecimal(_dtQuickCoil.Rows[0]["STEAMSteamConnection"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["STEAMCondensateConnection"])),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinThickness"]),
                    _dtQuickCoil.Rows[0]["TubeMaterialText"].ToString(),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubeThickness"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingThickness"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinDensity"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinPricePerLbs"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingDensity"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingPricePerLbs"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubeDensity"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubePricePerLbs"]),
                    Convert.ToDecimal(_dtQuickCoil.Rows[0]["HeaderQuantity"]));

                //get the coil price
                decCoilPrice = steamCoil.Price;

                //dispose
            }

            else
            {
                decimal decHeaderDiameter = 0m;
                //fluid cooling and heating use the connection size generated
                //by the dll, others use header diameter the control
                switch (_dtQuickCoil.Rows[0]["CoilType"].ToString())
                {
                    case "DX":
                        decHeaderDiameter = Convert.ToDecimal(_dtQuickCoil.Rows[0]["DXConnectionSizeIn"]);
                        break;
                    case "FC":
                        decHeaderDiameter = Convert.ToDecimal(_dtQuickCoil.Rows[0]["FCConnectionSizeIn"]);
                        break;
                    case "FH":
                        decHeaderDiameter = Convert.ToDecimal(_dtQuickCoil.Rows[0]["FHConnectionSizeIn"]);
                        break;
                    case "HR":
                        decHeaderDiameter = Convert.ToDecimal(_dtQuickCoil.Rows[0]["HRConnectionSizeIn"]);
                        break;
                    case "ST":
                        decHeaderDiameter = Math.Max(Convert.ToDecimal(_dtQuickCoil.Rows[0]["STEAMSteamConnection"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["STEAMCondensateConnection"]));
                        break;
                }

                if (_dtQuickCoil.Rows[0]["CoilModel"].ToString().StartsWith("B"))
                {
                    if (cboTurbulator.Text == @"YES")
                    {
                        //coil pricing
                        var coilForTurbulator = new Pricing.BoosterCoil(
                            FinTypeParameter(),
                            numQuantity.Value,
                            numRow.Value,
                            Convert.ToDecimal(cboFPI.Text),
                            FinHeightParameter(),
                            numFinLength.Value,
                            0.625m,
                            0.006m,
                            "COPPER",
                            0.016m,
                            0.064m,
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]),
                            2m/*In refplus quote it use 2 headers at 0.625" all the time*/);

                        decTurbulatorAdder = coilForTurbulator.Price * GetTurbulatorFactor();
                    }

                    //coil pricing
                    var boosterCoil = new Pricing.BoosterCoil(
                        _dtQuickCoil.Rows[0]["FinType"].ToString(),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["Quantity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_Rows"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FPI"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinHeight"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinLength"]),
                        0.625m,
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinThickness"]),
                        _dtQuickCoil.Rows[0]["TubeMaterialText"].ToString(),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubeThickness"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingThickness"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinDensity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinPricePerLbs"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingDensity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingPricePerLbs"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubeDensity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubePricePerLbs"]),
                        2m/*In refplus quote it use 2 headers at 0.625" all the time*/);

                    //get the coil price
                    decCoilPrice = boosterCoil.Price;

                    //dispose
                }
                else
                {
                    if (cboTurbulator.Text == @"YES")
                    {
                        //coil pricing
                        var coilForTurbulator = new Pricing.StandardCoil(
                            FinTypeParameter(),
                            numQuantity.Value,
                            numRow.Value,
                            Convert.ToDecimal(cboFPI.Text),
                            FinHeightParameter(),
                            numFinLength.Value,
                            decHeaderDiameter,
                            0.006m,
                            "COPPER",
                            0.016m,
                            0.064m,
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = 'ALUMINIUM'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["PricePerLbs"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
                            Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]));

                        decTurbulatorAdder = coilForTurbulator.Price * GetTurbulatorFactor();
                    }

                    //coil pricing
                    var standardCoil = new Pricing.StandardCoil(
                        _dtQuickCoil.Rows[0]["FinType"].ToString(),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["Quantity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_Rows"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FPI"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinHeight"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinLength"]),
                        decHeaderDiameter,
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinThickness"]),
                        _dtQuickCoil.Rows[0]["TubeMaterialText"].ToString(),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubeThickness"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingThickness"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinDensity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinPricePerLbs"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingDensity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["CasingPricePerLbs"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubeDensity"]),
                        Convert.ToDecimal(_dtQuickCoil.Rows[0]["TubePricePerLbs"]));

                    //get the coil price
                    decCoilPrice = standardCoil.Price;

                    //dispose
                }
            }

            return decCoilPrice;
        }

        private decimal GetCoatingPriceManualSelection()
        {
            decimal decCoatingPrice = 0m;

            switch (cboCoilCoating.Text)
            {
                case "Blygold":
                    var blyGoldCoating = new Pricing.BlyGoldCoating(FinTypeParameter(), numQuantity.Value, numRow.Value, Convert.ToDecimal(cboFPI.Text), FinHeightParameter(), numFinLength.Value);

                    //set value
                    decCoatingPrice = blyGoldCoating.Price;

                    ////get price
                    //BlyGoldCoating = new Pricing.BlyGoldCoating(FinTypeParameter(), numQuantity.Value, numRow.Value, Convert.ToDecimal(cboFPI.Text), FinHeightParameter(), numFinLength.Value);

                    ////set value
                    //decCoatingPrice = BlyGoldCoating.Price;

                    //dispose

                    break;
                case "ElectroFin":
                    var electroFinCoating = new Pricing.ElectroFinCoating(numQuantity.Value, numRow.Value, Convert.ToDecimal(cboFPI.Text), FinHeightParameter(), numFinLength.Value);

                    //set value
                    decCoatingPrice = electroFinCoating.Price;

                    ////get price
                    //ElectroFinCoating = new Pricing.ElectroFinCoating(FinTypeParameter(), numQuantity.Value, numRow.Value, Convert.ToDecimal(cboFPI.Text), FinHeightParameter(), numFinLength.Value);

                    ////set value
                    //decCoatingPrice = ElectroFinCoating.Price;

                    //dispose

                    break;
                case "Heresite":
                    var heresiteCoating = new Pricing.HeresiteCoating(numQuantity.Value, numRow.Value, FinHeightParameter(), numFinLength.Value);

                    //set value
                    decCoatingPrice = heresiteCoating.Price;

                    ////get price
                    //HeresiteCoating = new Pricing.HeresiteCoating(FinTypeParameter(), numQuantity.Value, numRow.Value, FinHeightParameter(), numFinLength.Value);

                    ////set value
                    //decCoatingPrice = HeresiteCoating.Price;

                    //dispose

                    break;
            }

            return decCoatingPrice;
        }

        private decimal GetCoatingPrice()
        {
            decimal decCoatingPrice = 0m;

            switch (cboCoilCoating.Text)
            {
                case "Blygold":
                    var blyGoldCoating = new Pricing.BlyGoldCoating(_dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Quantity"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_Rows"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FPI"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinLength"]));

                    //set value
                    decCoatingPrice = blyGoldCoating.Price;

                    ////get price
                    //BlyGoldCoating = new Pricing.BlyGoldCoating(dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Quantity"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["R_Rows"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FPI"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]));

                    ////set value
                    //decCoatingPrice = BlyGoldCoating.Price;

                    //dispose

                    break;
                case "ElectroFin":
                    var electroFinCoating = new Pricing.ElectroFinCoating(Convert.ToDecimal(_dtQuickCoil.Rows[0]["Quantity"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_Rows"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FPI"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinLength"]));

                    //set value
                    decCoatingPrice = electroFinCoating.Price;

                    ////get price
                    //ElectroFinCoating = new Pricing.ElectroFinCoating(dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Quantity"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["R_Rows"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FPI"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]));

                    ////set value
                    //decCoatingPrice = ElectroFinCoating.Price;

                    //dispose

                    break;
                case "Heresite":
                    var heresiteCoating = new Pricing.HeresiteCoating(Convert.ToDecimal(_dtQuickCoil.Rows[0]["Quantity"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_Rows"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(_dtQuickCoil.Rows[0]["FinLength"]));

                    //set value
                    decCoatingPrice = heresiteCoating.Price;

                    ////get price
                    //HeresiteCoating = new Pricing.HeresiteCoating(dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Quantity"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["R_Rows"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]));

                    ////set value
                    //decCoatingPrice = HeresiteCoating.Price;

                    //dispose

                    break;
            }

            return decCoatingPrice;
        }

        //check if all fields are filled
        private bool AllFieldsFilled()
        {
            bool bolAllFieldsFilled = true;

            //use of else if to go out as soon 1 field isn't selected

            if (cboFinType.SelectedIndex == -1)
            {
                bolAllFieldsFilled = false;
            }
            else if (cboFinShape.SelectedIndex == -1)
            {
                bolAllFieldsFilled = false;
            }
            else if (cboFinHeight.SelectedIndex == -1)
            {
                bolAllFieldsFilled = false;
            }
            else if (cboFPI.SelectedIndex == -1)
            {
                bolAllFieldsFilled = false;
            }
            else if (cboFinThickness.SelectedIndex == -1)
            {
                bolAllFieldsFilled = false;
            }
            else if (cboTubeMaterial.SelectedIndex == -1)
            {
                bolAllFieldsFilled = false;
            }
            else if (cboTubeThickness.SelectedIndex == -1)
            {
                bolAllFieldsFilled = false;
            }
            else
            {
                //this else will take care of the different coil minimum informations
                switch (CoilTypeParameter())
                {
                    case "DX"://DX

                        break;
                    case "HR"://Heat Reclaim

                        break;
                    case "FH"://Fluid Heating
                        if (cboTurbulator.SelectedIndex == -1)
                        {
                            bolAllFieldsFilled = false;
                        }
                        break;
                    case "FC"://Fluid Cooling
                        if (cboTurbulator.SelectedIndex == -1)
                        {
                            bolAllFieldsFilled = false;
                        }
                        break;
                    case "ST"://Steam

                        break;
                    case "GC"://Gas Cooler 
                        if (cboGC_Circuits.SelectedIndex == -1)
                        {
                            bolAllFieldsFilled = false;
                        }
                        break;
                }
            }

            return bolAllFieldsFilled;
        }

        //this validate value of fields for some coil and controls
        private bool ValidateFieldsValue(ref decimal decFHFreezeStat)
        {
            bool bolReturnValue = true;

            decimal decMinEDBEWB;
            decimal decMaxEDBEWB = 0m;
            decimal decFreezingPoint;

            switch (CoilTypeParameter())
            {
                case "DX"://DX

                    break;
                case "HR"://Heat Reclaim

                    break;
                case "FH"://Fluid Heating
                    //check min max EDB EWB
                    decFreezingPoint = 0m;
                    //get min max and freezing point
                    switch (FH_FluidTypeParameter())
                    {
                        case "WTR":
                            decFreezingPoint = 34m;
                            break;
                        case "EG":
                            decFreezingPoint = _backgroundCode.GetFreezingPoint(Public.DSDatabase.Tables["FreezingPointEthylene"], Convert.ToInt32(numFH_Concentration.Value));
                            break;
                        case "PG":
                            decFreezingPoint = _backgroundCode.GetFreezingPoint(Public.DSDatabase.Tables["FreezingPointPropylene"], Convert.ToInt32(numFH_Concentration.Value));
                            break;
                        case "OTHER":
                            decFreezingPoint = _freezingP;
                            break;
                    }
                    decMinEDBEWB = decFreezingPoint + 10m;
                    decMaxEDBEWB = 350m;
                    //validations
                    if (Convert.ToDecimal(lblFH_MixingEDB.Text) < decMinEDBEWB || Convert.ToDecimal(lblFH_MixingEDB.Text) > decMaxEDBEWB)
                    {
                        decFHFreezeStat = decMinEDBEWB;
                        //bolReturnValue = false;
                        //Public.LanguageBox("EDB must be between " + decMinEDBEWB.ToString() + " and " + decMaxEDBEWB.ToString(), "EDB doit être entre " + decMinEDBEWB.ToString() + " et " + decMaxEDBEWB.ToString());
                    }
                    if (numFH_ELT.Value < Convert.ToDecimal(lblFH_MixingEDB.Text) + 1m || numFH_ELT.Value > 350m)
                    {
                        bolReturnValue = false;
                        Public.LanguageBox("ELT must be between " + Convert.ToDecimal(Convert.ToDecimal(lblFH_MixingEDB.Text) + 1m) + " and 350", "ELT doit être entre " + Convert.ToDecimal(Convert.ToDecimal(lblFH_MixingEDB.Text) + 1m) + " et 350");
                    }
                    else if (cboFH_GPM_LeavingLiquidTemp.Text != @"USGPM" && numFH_LeavingLiquidTemperature.Value > numFH_ELT.Value)
                    {
                        bolReturnValue = false;
                        Public.LanguageBox("LLT must be smaller or equal to ELT", "LLT doit être plus petit ou égal à ELT");
                    }
                    break;
                case "FC"://Fluid Cooling
                    //check min max EDB EWB

                    decFreezingPoint = 0m;
                    //get min max and freezing point
                    switch (FC_FluidTypeParameter())
                    {
                        case "WTR":
                            decFreezingPoint = 34m;
                            break;
                        case "EG":
                            decFreezingPoint = _backgroundCode.GetFreezingPoint(Public.DSDatabase.Tables["FreezingPointEthylene"], Convert.ToInt32(numFC_Concentration.Value));
                            break;
                        case "PG":
                            decFreezingPoint = _backgroundCode.GetFreezingPoint(Public.DSDatabase.Tables["FreezingPointPropylene"], Convert.ToInt32(numFC_Concentration.Value));
                            break;
                        case "OTHER":
                            decFreezingPoint = _freezingP;
                            break;
                    }
                    decMinEDBEWB = decFreezingPoint + 10m;
                    decMaxEDBEWB = 350m;
                    //validations
                    if (Convert.ToDecimal(lblFC_MixingEDB.Text) < decMinEDBEWB || Convert.ToDecimal(lblFC_MixingEDB.Text) > decMaxEDBEWB)
                    {
                        bolReturnValue = false;
                        Public.LanguageBox("EDB must be between " + decMinEDBEWB + " and " + decMaxEDBEWB, "EDB doit être entre " + decMinEDBEWB + " et " + decMaxEDBEWB);
                    }
                    else if (numFC_ELT.Value > Convert.ToDecimal(lblFC_MixingEDB.Text) - 1m || numFC_ELT.Value < decFreezingPoint)
                    {
                        bolReturnValue = false;
                        Public.LanguageBox("ELT must be between " + decFreezingPoint + " and " + Convert.ToDecimal(Convert.ToDecimal(lblFC_MixingEDB.Text) - 1m), "ELT doit être entre " + decFreezingPoint + " et " + Convert.ToDecimal(Convert.ToDecimal(lblFC_MixingEDB.Text) - 1m));
                    }
                    else if (Convert.ToDecimal(lblFC_MixingEWB.Text) > Convert.ToDecimal(lblFC_MixingEDB.Text))
                    {
                        bolReturnValue = false;
                        Public.LanguageBox("EWB must be smaller or equal to EDB", "EWB doit être plus petit ou égal à l'EDB");
                    }
                    else if (cboFC_GPM_LeavingLiquidTemp.Text != @"USGPM" && numFC_LeavingLiquidTemperature.Value < numFC_ELT.Value)
                    {
                        bolReturnValue = false;
                        Public.LanguageBox("LLT must be bigger or equal to ELT", "LLT doit être plus grand ou égal à l'ELT");
                    }
                    else if (cboFC_GPM_LeavingLiquidTemp.Text != @"USGPM" && numFC_LeavingLiquidTemperature.Value >= Convert.ToDecimal(lblFC_MixingEDB.Text))
                    {
                        bolReturnValue = false;
                        Public.LanguageBox("LLT must be smaller than EDB", "LLT doit être plus petit que le EDB");
                    }

                    break;
                case "ST"://Steam

                    //2010-09-14 : this logic only apply to vertical steam coil
                    if (cboSTEAMTubeOrientation.Text == @"VERTICAL")
                    {
                        decMinEDBEWB = 44m;
                        //validations
                        if (Convert.ToDecimal(lblSTEAM_MixingEDB.Text) < decMinEDBEWB || Convert.ToDecimal(lblSTEAM_MixingEDB.Text) > decMaxEDBEWB)
                        {
                            decFHFreezeStat = decMinEDBEWB;
                        }
                    }

                    //if steam distributing
                    if (cboSTEAM_CoilType.Text == @"Steam Distributing")
                    {
                        if (Convert.ToDecimal(lblSTEAM_MixingEDB.Text) < -50m || Convert.ToDecimal(lblSTEAM_MixingEDB.Text) > 150m)
                        {
                            bolReturnValue = false;
                            Public.LanguageBox("EDB must be between -50 and 150", "EDB doit être entre -50 et 150");
                        }
                    }
                    else
                    {
                        if (Convert.ToDecimal(lblSTEAM_MixingEDB.Text) < 34m || Convert.ToDecimal(lblSTEAM_MixingEDB.Text) > 150m)
                        {
                            bolReturnValue = false;
                            Public.LanguageBox("EDB must be between 34 and 150", "EDB doit être entre 34 et 150");
                        }
                    }
                    break;
                case "GC"://Gas Cooler


                    break;
            }
            return bolReturnValue;
        }

        //show the message when an error or somethign happen in the KFRefplus DLL
        private static void MessageForErrorInDLL(string errorMessage)
        {
            Public.LanguageBox("An error occured when running coil performance :\n" + errorMessage, "Une erreur est survenue lors du calcul de performance du serpentin :\n" + errorMessage);
        }



        private void RefreshQuickCoilTable()
        {
            //if there is not at least 1 row, create one
            if (_dtQuickCoil.Rows.Count < 1)
            {
                //add empty row
                DataRow drQuickCoil = _dtQuickCoil.NewRow();
                _dtQuickCoil.Rows.Add(drQuickCoil);
            }

            foreach (DataColumn dc in _dtQuickCoil.Columns)
            {
                if (dc.DataType == typeof(string))
                {
                    _dtQuickCoil.Rows[0][dc.ColumnName] = "";
                }
                else if (dc.DataType == typeof(decimal))
                {
                    _dtQuickCoil.Rows[0][dc.ColumnName] = 0m;
                }
                else if (dc.DataType == typeof(int))
                {
                    _dtQuickCoil.Rows[0][dc.ColumnName] = 0;
                }
                else if (dc.DataType == typeof(bool))
                {
                    _dtQuickCoil.Rows[0][dc.ColumnName] = true;
                }
                else if (dc.DataType == typeof(float))
                {
                    _dtQuickCoil.Rows[0][dc.ColumnName] = 0;
                }
                else if (dc.DataType == typeof(double))
                {
                    _dtQuickCoil.Rows[0][dc.ColumnName] = 0;
                }
            }

            //set the values

            //this is the common part
            _dtQuickCoil.Rows[0]["CoilModel"] = CoilModelName();
            _dtQuickCoil.Rows[0]["Tag"] = txtTag.Text;
            _dtQuickCoil.Rows[0]["Quantity"] = numQuantity.Value;
            _dtQuickCoil.Rows[0]["CasingMaterial"] = cboCasingMaterial.Text;
            _dtQuickCoil.Rows[0]["CasingThickness"] = cboCasingThickness.Text;
            //dtQuickCoil.Rows[0]["HeaderDiameter"] = HeaderDiameter();
            //dtQuickCoil.Rows[0]["HeaderQuantity"] = HeaderQuantity(); 
            _dtQuickCoil.Rows[0]["ConnectionSide"] = cboConnectionSide.Text;
            _dtQuickCoil.Rows[0]["ConstructionType"] = cboConstructionType.Text;
            _dtQuickCoil.Rows[0]["CoilCoating"] = cboCoilCoating.Text;
            _dtQuickCoil.Rows[0]["FinType"] = FinTypeParameter();
            _dtQuickCoil.Rows[0]["FinTypeText"] = cboFinType.Text;
            _dtQuickCoil.Rows[0]["TubeDiameter"] = FinTypeTubeDiameter();
            _dtQuickCoil.Rows[0]["FaceTube"] = FinTypeFaceTube();
            _dtQuickCoil.Rows[0]["TubeRow"] = FinTypeTubeRow();
            _dtQuickCoil.Rows[0]["TubeDiagonal"] = FinTypeTubeDiagonal();
            _dtQuickCoil.Rows[0]["FinShape"] = FinShapeParameter();
            _dtQuickCoil.Rows[0]["FinShapeText"] = cboFinShape.Text;
            _dtQuickCoil.Rows[0]["TubeType"] = ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["TubeType"].ToString();
            _dtQuickCoil.Rows[0]["Turbulators"] = cboTurbulator.Text;
            _dtQuickCoil.Rows[0]["FinHeight"] = FinHeightParameter();
            _dtQuickCoil.Rows[0]["FinLength"] = numFinLength.Value;
            _dtQuickCoil.Rows[0]["Row"] = numRow.Value;
            _dtQuickCoil.Rows[0]["FPI"] = Convert.ToDecimal(cboFPI.Text);
            _dtQuickCoil.Rows[0]["TubeMaterial"] = TubeMaterialParameter();
            _dtQuickCoil.Rows[0]["TubeMaterialText"] = cboTubeMaterial.Text;
            _dtQuickCoil.Rows[0]["TubeThickness"] = TubeThicknessParameter();
            _dtQuickCoil.Rows[0]["FinMaterial"] = FinMaterialParameter();
            _dtQuickCoil.Rows[0]["FinMaterialText"] = cboFinMaterial.Text;
            _dtQuickCoil.Rows[0]["FinThickness"] = FinThicknessParameter();
            _dtQuickCoil.Rows[0]["CasingDensity"] = CasingDensity();
            _dtQuickCoil.Rows[0]["CasingPricePerLbs"] = CasingPricePerLbs();
            _dtQuickCoil.Rows[0]["FinDensity"] = FinDensity();
            _dtQuickCoil.Rows[0]["FinPricePerLbs"] = FinPricePerLbs();
            _dtQuickCoil.Rows[0]["TubeDensity"] = TubeDensity();
            _dtQuickCoil.Rows[0]["TubePricePerLbs"] = TubePricePerLbs();
            //dtQuickCoil.Rows[0]["Weight"] = BackgroundCode.GetCoilWeight(FinHeightParameter(), numFinLength.Value, FinTypeFaceTube(), FinTypeTubeDiameter(), FinTypeTubeRow(), numRow.Value, Convert.ToDecimal(cboFPI.Text), CasingDensity(), Convert.ToDecimal(cboCasingThickness.Text), FinDensity(), Convert.ToDecimal(FinThicknessParameter()), TubeDensity(), Convert.ToDecimal(TubeThicknessParameter()), HeaderLbsPerFoot());
            //specific to each coil type
            switch (CoilTypeParameter())
            {
                case "DX"://DX
                    _dtQuickCoil.Rows[0]["CoilType"] = "DX";
                    _dtQuickCoil.Rows[0]["DXRefrigerantType"] = cboDX_RefrigerantType.Text.ToUpper();
                    _dtQuickCoil.Rows[0]["DXAirFlowRate"] = Convert.ToDecimal(lblDX_MixingCFM.Text);
                    _dtQuickCoil.Rows[0]["DXEnteringDryBulb"] = Convert.ToDecimal(lblDX_MixingEDB.Text);
                    _dtQuickCoil.Rows[0]["DXEnteringWetBulb"] = Convert.ToDecimal(lblDX_MixingEWB.Text);
                    _dtQuickCoil.Rows[0]["DXFreshCFM"] = numDX_FreshCFM.Value;
                    _dtQuickCoil.Rows[0]["DXFreshEDB"] = numDX_FreshEDB.Value;
                    _dtQuickCoil.Rows[0]["DXFreshEWB"] = numDX_FreshEWB.Value;
                    _dtQuickCoil.Rows[0]["DXReturnCFM"] = numDX_ReturnCFM.Value;
                    _dtQuickCoil.Rows[0]["DXReturnEDB"] = numDX_ReturnEDB.Value;
                    _dtQuickCoil.Rows[0]["DXReturnEWB"] = numDX_ReturnEWB.Value;
                    _dtQuickCoil.Rows[0]["DXSuctionTemperature"] = numDX_SuctionTemperature.Value;
                    _dtQuickCoil.Rows[0]["DXAltitude"] = numDX_Altitude.Value;
                    _dtQuickCoil.Rows[0]["DXLiquidTemp"] = numDX_LiquidTemperature.Value;
                    _dtQuickCoil.Rows[0]["DXNumberOfCircuit"] = cboDX_NumberOfCircuits.Text;
                    _dtQuickCoil.Rows[0]["DXConnectionSizeIn"] = DX_ConnectionSizeInlet();
                    _dtQuickCoil.Rows[0]["DXConnectionSizeOut"] = _dtQuickCoil.Rows[0]["DXConnectionSizeIn"];
                    if (cboDX_HeaderQuantity.Text == @"AUTOMATIC")
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = _backgroundCode.GetHeaderQuantity_FC_FH_DX_HR(Public.DSDatabase.Tables["CoilFinType"], FinHeightParameter(), FinTypeParameter());
                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = Convert.ToInt32(cboDX_HeaderQuantity.Text);
                    }
                    break;
                case "HR"://Heat Reclaim
                    _dtQuickCoil.Rows[0]["CoilType"] = "HR";
                    _dtQuickCoil.Rows[0]["HRRefrigerantType"] = cboHR_RefrigerantType.Text.ToUpper();
                    _dtQuickCoil.Rows[0]["HRAirFlowRate"] = Convert.ToDecimal(lblHR_MixingCFM.Text);
                    _dtQuickCoil.Rows[0]["HREnteringDryBulb"] = Convert.ToDecimal(lblHR_MixingEDB.Text);
                    _dtQuickCoil.Rows[0]["HRFreshCFM"] = numHR_FreshCFM.Value;
                    _dtQuickCoil.Rows[0]["HRFreshEDB"] = numHR_FreshEDB.Value;
                    _dtQuickCoil.Rows[0]["HRReturnCFM"] = numHR_ReturnCFM.Value;
                    _dtQuickCoil.Rows[0]["HRReturnEDB"] = numHR_ReturnEDB.Value;
                    _dtQuickCoil.Rows[0]["HRCondensingTemperature"] = numHR_CondensingTemperature.Value;
                    _dtQuickCoil.Rows[0]["HRSuctionTemperature"] = numHR_SuctionTemperature.Value;
                    _dtQuickCoil.Rows[0]["HRAltitude"] = numHR_Altitude.Value;
                    _dtQuickCoil.Rows[0]["HRNumberOfCircuit"] = cboHR_NumberOfCircuits.Text;
                    _dtQuickCoil.Rows[0]["HRCoilDesign"] = cboHR_CoilDesign.Text;
                    _dtQuickCoil.Rows[0]["HRSubCooler"] = cboHR_SubCooler.Text;
                    _dtQuickCoil.Rows[0]["HRFaceTubes"] = numHR_FaceTubes.Value;
                    _dtQuickCoil.Rows[0]["HRCircuits"] = numHR_Circuit.Value;
                    _dtQuickCoil.Rows[0]["HRHeatRecovery"] = numHR_HeatRecovery.Value;
                    _dtQuickCoil.Rows[0]["HRConnectionSizeIn"] = HR_ConnectionSizeIn();
                    _dtQuickCoil.Rows[0]["HRConnectionSizeOut"] = HR_ConnectionSizeOut();
                    _dtQuickCoil.Rows[0]["HRSubCoolerConnectionSizeIn"] = HR_SubCoolerConnectionSizeIn();
                    _dtQuickCoil.Rows[0]["HRSubCoolerConnectionSizeOut"] = HR_SubCoolerConnectionSizeOut();
                    if (cboHR_HeaderQuantity.Text == @"AUTOMATIC")
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = _backgroundCode.GetHeaderQuantity_FC_FH_DX_HR(Public.DSDatabase.Tables["CoilFinType"], FinHeightParameter(), FinTypeParameter());
                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = Convert.ToInt32(cboHR_HeaderQuantity.Text);
                    }
                    break;
                case "FH"://Fluid Heating
                    _dtQuickCoil.Rows[0]["CoilType"] = "FH";
                    _dtQuickCoil.Rows[0]["FHDesignType"] = cboFH_DesignType.Text;
                    _dtQuickCoil.Rows[0]["FHConnectionType"] = cboFH_ConnectionType.Text;
                    //put connection size = 0 if it standard selected, that will
                    //allow me to know the connection is STD in the report.
                    //I needed to put a the value a number because there is
                    //calculation involve in the crystal report with this value
                    //in the drawing portion
                    _dtQuickCoil.Rows[0]["FHConnectionSizeIn"] = FH_ConnectionSize();
                    _dtQuickCoil.Rows[0]["FHConnectionSizeOut"] = _dtQuickCoil.Rows[0]["FHConnectionSizeIn"];
                    _dtQuickCoil.Rows[0]["FHAirFlowRate"] = Convert.ToDecimal(lblFH_MixingCFM.Text);
                    _dtQuickCoil.Rows[0]["FHEnteringDryBulb"] = Convert.ToDecimal(lblFH_MixingEDB.Text);
                    _dtQuickCoil.Rows[0]["FHFreshCFM"] = numFH_FreshCFM.Value;
                    _dtQuickCoil.Rows[0]["FHFreshEDB"] = numFH_FreshEDB.Value;
                    _dtQuickCoil.Rows[0]["FHReturnCFM"] = numFH_ReturnCFM.Value;
                    _dtQuickCoil.Rows[0]["FHReturnEDB"] = numFH_ReturnEDB.Value;
                    _dtQuickCoil.Rows[0]["FHEnteringLiquidTemperature"] = numFH_ELT.Value;
                    _dtQuickCoil.Rows[0]["FHAltitude"] = numFH_Altitude.Value;
                    _dtQuickCoil.Rows[0]["FHFluidType"] = FH_FluidTypeParameter();
                    _dtQuickCoil.Rows[0]["FHConcentration"] = numFH_Concentration.Value;
                    //this if is to set the USGPM to 0 if we are not base on GPM
                    //the class to runn the dll check if gpm = 0 then it use the leaving
                    //liquid temperature. Since i'm doing it for USGPM i'm doing it for the
                    //leaving liquid temp so we keep the same logic.
                    if (cboFH_GPM_LeavingLiquidTemp.Text == @"USGPM")
                    {
                        _dtQuickCoil.Rows[0]["FHUSGPM"] = numFH_USGPM.Value;
                        _dtQuickCoil.Rows[0]["FHLeavingLiquidTemperature"] = -1;

                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["FHUSGPM"] = -1;
                        _dtQuickCoil.Rows[0]["FHLeavingLiquidTemperature"] = numFH_LeavingLiquidTemperature.Value;
                    }
                    _dtQuickCoil.Rows[0]["FHNumberOfCircuit"] = cboFH_NumberOfCircuits.Text;
                    _dtQuickCoil.Rows[0]["FHMaxPressure"] = numFH_MaxPressure.Value;
                    if (_otherFluid != null)
                    {
                        _dtQuickCoil.Rows[0]["FHFluidTypeName"] = _otherFluid.GetFluidName();
                        _dtQuickCoil.Rows[0]["FHSpecificHeat"] = _otherFluid.GetSpecificHeat();
                        _dtQuickCoil.Rows[0]["FHDensity"] = _otherFluid.GetDensity();
                        _dtQuickCoil.Rows[0]["FHViscosity"] = _otherFluid.GetViscosity();
                        _dtQuickCoil.Rows[0]["FHThermalConductivity"] = _otherFluid.GetThermalConductivity();
                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["FHFluidTypeName"] = txtFH_FluidTypeName.Text;
                        _dtQuickCoil.Rows[0]["FHSpecificHeat"] = numFH_SpecificHeat.Value;
                        _dtQuickCoil.Rows[0]["FHDensity"] = numFH_Density.Value;
                        _dtQuickCoil.Rows[0]["FHViscosity"] = numFH_Viscosity.Value;
                        _dtQuickCoil.Rows[0]["FHThermalConductivity"] = numFH_ThermalConductivity.Value;
                    }
                    if (cboFH_HeaderQuantity.Text == @"AUTOMATIC")
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = _backgroundCode.GetHeaderQuantity_FC_FH_DX_HR(Public.DSDatabase.Tables["CoilFinType"], FinHeightParameter(), FinTypeParameter());
                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = Convert.ToInt32(cboFH_HeaderQuantity.Text);
                    }
                    break;
                case "FC"://Fluid Cooling
                    _dtQuickCoil.Rows[0]["CoilType"] = "FC";
                    _dtQuickCoil.Rows[0]["FCDesignType"] = cboFC_DesignType.Text;
                    _dtQuickCoil.Rows[0]["FCConnectionType"] = cboFC_ConnectionType.Text;
                    //put connection size = 0 if it standard selected, that will
                    //allow me to know the connection is STD in the report.
                    //I needed to put a the value a number because there is
                    //calculation involve in the crystal report with this value
                    //in the drawing portion
                    _dtQuickCoil.Rows[0]["FCConnectionSizeIn"] = FC_ConnectionSize();
                    _dtQuickCoil.Rows[0]["FCConnectionSizeOut"] = _dtQuickCoil.Rows[0]["FCConnectionSizeIn"];
                    _dtQuickCoil.Rows[0]["FCAirFlowRate"] = Convert.ToDecimal(lblFC_MixingCFM.Text);
                    _dtQuickCoil.Rows[0]["FCEnteringDryBulb"] = Convert.ToDecimal(lblFC_MixingEDB.Text);
                    _dtQuickCoil.Rows[0]["FCEnteringWetBulb"] = Convert.ToDecimal(lblFC_MixingEWB.Text);
                    _dtQuickCoil.Rows[0]["FCFreshCFM"] = numFC_FreshCFM.Value;
                    _dtQuickCoil.Rows[0]["FCFreshEDB"] = numFC_FreshEDB.Value;
                    _dtQuickCoil.Rows[0]["FCFreshEWB"] = numFC_FreshEWB.Value;
                    _dtQuickCoil.Rows[0]["FCReturnCFM"] = numFC_ReturnCFM.Value;
                    _dtQuickCoil.Rows[0]["FCReturnEDB"] = numFC_ReturnEDB.Value;
                    _dtQuickCoil.Rows[0]["FCReturnEWB"] = numFC_ReturnEWB.Value;
                    _dtQuickCoil.Rows[0]["FCEnteringLiquidTemperature"] = numFC_ELT.Value;
                    _dtQuickCoil.Rows[0]["FCAltitude"] = numFC_Altitude.Value;
                    _dtQuickCoil.Rows[0]["FCFluidType"] = FC_FluidTypeParameter();
                    _dtQuickCoil.Rows[0]["FCConcentration"] = numFC_Concentration.Value;
                    //this if is to set the USGPM to 0 if we are not base on GPM
                    //the class to runn the dll check if gpm = 0 then it use the leaving
                    //liquid temperature. Since i'm doing it for USGPM i'm doing it for the
                    //leaving liquid temp so we keep the same logic.
                    if (cboFC_GPM_LeavingLiquidTemp.Text == @"USGPM")
                    {
                        _dtQuickCoil.Rows[0]["FCUSGPM"] = numFC_USGPM.Value;
                        _dtQuickCoil.Rows[0]["FCLeavingLiquidTemperature"] = -1;

                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["FCUSGPM"] = -1;
                        _dtQuickCoil.Rows[0]["FCLeavingLiquidTemperature"] = numFC_LeavingLiquidTemperature.Value;
                    }
                    _dtQuickCoil.Rows[0]["FCNumberOfCircuits"] = cboFC_NumberOfCircuits.Text;
                    _dtQuickCoil.Rows[0]["FCMaxPressure"] = numFC_MaxPressure.Value;
                    if (_otherFluid != null)
                    {
                        _dtQuickCoil.Rows[0]["FCFluidTypeName"] = _otherFluid.GetFluidName();
                        _dtQuickCoil.Rows[0]["FCSpecificHeat"] = _otherFluid.GetSpecificHeat();
                        _dtQuickCoil.Rows[0]["FCDensity"] = _otherFluid.GetDensity();
                        _dtQuickCoil.Rows[0]["FCViscosity"] = _otherFluid.GetViscosity();
                        _dtQuickCoil.Rows[0]["FCThermalConductivity"] = _otherFluid.GetThermalConductivity();
                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["FCFluidTypeName"] = txtFC_FluidTypeName.Text;
                        _dtQuickCoil.Rows[0]["FCSpecificHeat"] = numFC_SpecificHeat.Value;
                        _dtQuickCoil.Rows[0]["FCDensity"] = numFC_Density.Value;
                        _dtQuickCoil.Rows[0]["FCViscosity"] = numFC_Viscosity.Value;
                        _dtQuickCoil.Rows[0]["FCThermalConductivity"] = numFC_ThermalConductivity.Value;
                    }
                    //dtQuickCoil.Rows[0]["FCFluidTypeName"] = txtFC_FluidTypeName.Text;
                    //dtQuickCoil.Rows[0]["FCSpecificHeat"] = numFC_SpecificHeat.Value;
                    //dtQuickCoil.Rows[0]["FCDensity"] = numFC_Density.Value;
                    //dtQuickCoil.Rows[0]["FCViscosity"] = numFC_Viscosity.Value;
                    //dtQuickCoil.Rows[0]["FCThermalConductivity"] = numFC_ThermalConductivity.Value;
                    if (cboFC_HeaderQuantity.Text == @"AUTOMATIC")
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = _backgroundCode.GetHeaderQuantity_FC_FH_DX_HR(Public.DSDatabase.Tables["CoilFinType"], FinHeightParameter(), FinTypeParameter());
                    }
                    else
                    {
                        _dtQuickCoil.Rows[0]["HeaderQuantity"] = Convert.ToInt32(cboFC_HeaderQuantity.Text);
                    }
                    break;
                case "ST"://Steam
                    _dtQuickCoil.Rows[0]["CoilType"] = "ST";
                    _dtQuickCoil.Rows[0]["STEAMSteamCoilType"] = cboSTEAM_CoilType.Text;
                    _dtQuickCoil.Rows[0]["STEAMConnectionType"] = cboSTEAM_ConnectionType.Text;
                    _dtQuickCoil.Rows[0]["STEAMCondensateConnection"] = _backgroundCode.GetSteamConnection(Public.DSDatabase.Tables["CoilSteamMPTConnection"], cboSTEAM_CoilType.Text, FinHeightParameter(), numFinLength.Value, numRow.Value, cboSTEAM_CondensateConnection.Text, QuickCoilCode.SteamCoilConnection.Condensate);
                    _dtQuickCoil.Rows[0]["STEAMSteamConnection"] = _backgroundCode.GetSteamConnection(Public.DSDatabase.Tables["CoilSteamMPTConnection"], cboSTEAM_CoilType.Text, FinHeightParameter(), numFinLength.Value, numRow.Value, cboSTEAM_SteamConnection.Text, QuickCoilCode.SteamCoilConnection.Steam);
                    _dtQuickCoil.Rows[0]["STEAMAirFlowRate"] = Convert.ToDecimal(lblSTEAM_MixingCFM.Text);
                    _dtQuickCoil.Rows[0]["STEAMEnteringDryBulb"] = Convert.ToDecimal(lblSTEAM_MixingEDB.Text);
                    _dtQuickCoil.Rows[0]["STEAMFreshCFM"] = numSTEAM_FreshCFM.Value;
                    _dtQuickCoil.Rows[0]["STEAMFreshEDB"] = numSTEAM_FreshEDB.Value;
                    _dtQuickCoil.Rows[0]["STEAMReturnCFM"] = numSTEAM_ReturnCFM.Value;
                    _dtQuickCoil.Rows[0]["STEAMReturnEDB"] = numSTEAM_ReturnEDB.Value;
                    _dtQuickCoil.Rows[0]["STEAMSaturatedSteamPressure"] = numSTEAM_SteamPressure.Value;
                    _dtQuickCoil.Rows[0]["STEAMAltitude"] = numSTEAM_Altitude.Value;
                    _dtQuickCoil.Rows[0]["HeaderQuantity"] = _backgroundCode.GetHeaderQuantity_ST(cboSTEAM_CoilType.Text, numFinLength.Value);
                    break;
                case "GC"://Gas Cooler
                    _dtQuickCoil.Rows[0]["CoilType"] = "GC";
                    _dtQuickCoil.Rows[0]["GCAltitude"] = numGC_Altitude.Value;
                    _dtQuickCoil.Rows[0]["GCAirFlowRate"] = numGC_FreshCFM.Text;
                    _dtQuickCoil.Rows[0]["GCEnteringDryBulb"] = Convert.ToDecimal(numGC_FreshEDB.Text);
                    _dtQuickCoil.Rows[0]["GCNumberOfCircuits"] = cboGC_Circuits.Text;
                    _dtQuickCoil.Rows[0]["GCGIN"] = numGC_GIN.Value;
                    _dtQuickCoil.Rows[0]["GCGPSI"] = numGC_GPSI.Value;
                    _dtQuickCoil.Rows[0]["GCGFLO"] = numGC_GFLO.Value;
                    break;
            }

            //R_ is a prefix for return values
            _dtQuickCoil.Rows[0]["R_Rows"] = 0;
            _dtQuickCoil.Rows[0]["R_Circuiting"] = 0;
            _dtQuickCoil.Rows[0]["R_NumberOfCircuits"] = 0;
            _dtQuickCoil.Rows[0]["R_FPI"] = 0;
            _dtQuickCoil.Rows[0]["R_CoilFaceArea"] = 0;
            _dtQuickCoil.Rows[0]["R_FaceVelocity"] = 0;
            _dtQuickCoil.Rows[0]["R_AirPressureDrop"] = 0;
            _dtQuickCoil.Rows[0]["R_LeavingDryBulb"] = 0;
            _dtQuickCoil.Rows[0]["R_LeavingWetBulb"] = 0;
            _dtQuickCoil.Rows[0]["R_TotalHeat"] = 0;
            _dtQuickCoil.Rows[0]["R_SensibleHeat"] = 0;
            _dtQuickCoil.Rows[0]["R_LeavingLiquidTemperature"] = 0;
            _dtQuickCoil.Rows[0]["R_CircuitLoad"] = 0;
            _dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"] = 0;
            _dtQuickCoil.Rows[0]["R_RefrigerantPressureDropPerDegree"] = 0;
            _dtQuickCoil.Rows[0]["R_FaceTube"] = 0;
            _dtQuickCoil.Rows[0]["R_SteamConsumption"] = 0;
            _dtQuickCoil.Rows[0]["R_SteamTemperature"] = 0;
            _dtQuickCoil.Rows[0]["R_SubCoolerCapacity"] = 0;
            _dtQuickCoil.Rows[0]["R_SubCoolerRefrigerantLeavingTemperature"] = 0;
            _dtQuickCoil.Rows[0]["R_SubCoolerPressureDrop"] = 0;
            _dtQuickCoil.Rows[0]["R_ConnectionSize"] = 0;
            _dtQuickCoil.Rows[0]["R_GPM"] = 0;
            _dtQuickCoil.Rows[0]["R_WaterVelocity"] = 0;
        }

        //validate the fin length
        private void ValidateFinLength(string strCoilType)
        {
            numFinLength.Minimum = 0m;
            numFinLength.Maximum = 1000m;
            numFinLength.Value = 4m;
            switch (strCoilType)
            {
                case "DX":
                case "HR":
                case "FH":
                case "FC":
                    numFinLength.Minimum = 4m;
                    numFinLength.Maximum = 360m;
                    break;
                case "ST":
                    numFinLength.Minimum = 4m;
                    numFinLength.Maximum = 240m;
                    break;
            }
        }

        private void cboFinType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFinType.SelectedIndex != -1)
            {
                ClearSelection();
                //clear these 2 combobox that are depended on following selected values
                cboFinMaterial.Items.Clear();
                cboFinThickness.Items.Clear();
                cboTubeThickness.Items.Clear();

                //fill fins shape
                Fill_FinShape();

                //fill fin height
                Fill_FinHeight();

                //fill the fpi
                Fill_FPI();

                //fill tube material
                Fill_TubeMaterial();

                //validate the turbulator
                ValidateTurbulator();

                ValidateRefWithShape();

                ValidateRowWithShape();
            }
        }

        private void ValidateRowWithShape()
        {
            if (cboFinType.Text.Contains("C") && numRow.Value == 1)
            {
                MessageBox.Show(Public.LanguageString("It is impossible to have a coil with a C pattern and only 1 row.  Therefore the number of rows automatically changed to 2. Thank you", "Il est impossible de créer un serpentin avec le patron C qui ne contient qu'une seule rangée.  Le nombre de rangées vient donc de changer à 2.  Merci"));
                numRow.Value = 2;

            }
        }
        //validate turbulator
        private void ValidateTurbulator()
        {
            //if we don;t have any fin type selected we disable
            //automaticly the turbulator and put it to NO
            //i used this if statement 
            //because FinTypeParameter() if nothing selected
            //in the combobox crash because no index selected
            //so that if prevent bug and also take care of when
            //you change coil type, it will prevent this problem from hapenning
            if (cboFinType.SelectedIndex < 0)
            {
                cboTurbulator.SelectedIndex = 0;
                cboTurbulator.Enabled = false;
            }
            else
            {
                //only on G fin we can have turbulator
                if (FinTypeParameter() == "G")
                {
                    cboTurbulator.Enabled = true;
                }
                else
                {
                    cboTurbulator.SelectedIndex = 0;
                    cboTurbulator.Enabled = false;
                }
            }
        }

        //return the Fin Price Per Lbs
        private decimal FinPricePerLbs()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinMaterial, Public.DSDatabase.Tables["CoilFinMaterial"], "UniqueID")[0]["PricePerLbs"]);
        }

        //return the Fin Density
        private decimal FinDensity()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinMaterial, Public.DSDatabase.Tables["CoilFinMaterial"], "UniqueID")[0]["MaterialDensity"]);
        }

        //return the fin material parameter
        private string FinMaterialParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinMaterial, Public.DSDatabase.Tables["CoilFinMaterial"], "UniqueID")[0]["FinMaterialParameter"].ToString();
        }

        private void Fill_FinMaterial()
        {
            cboFinMaterial.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinMaterial in Public.DSDatabase.Tables["CoilFinMaterial"].Rows)
            {
                //if we can found the fintype in the table that mean it's available for
                //the selected coil type so we can show it
                if (_backgroundCode.IsFinMaterialAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), FinTypeParameter(), FinShapeParameter(), FPIParameter(), drFinMaterial["UniqueID"].ToString()))
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

        private int FPIParameter()
        {
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI));
        }

        private void Fill_FPI()
        {
            cboFPI.Items.Clear();

            //min and max fpi
            int intMinFPI = 0;
            int intMaxFPI = 0;

            //pass by reference the 2 variable which will return me the min and max fpi
            //available for this fin type
            _backgroundCode.MinMaxFPI(Public.DSDatabase.Tables["v_CoilFinDefaults"], FinTypeParameter(), ref intMinFPI, ref intMaxFPI);

            //from the min to the max we add an item
            for (int intFPI = intMinFPI; intFPI <= intMaxFPI; intFPI++)
            {
                ComboBoxControl.AddItem(cboFPI, intFPI.ToString(CultureInfo.InvariantCulture), intFPI.ToString(CultureInfo.InvariantCulture));
            }

            if (cboFPI.Items.Count > 0)
            {
                switch (CoilTypeParameter())
                {
                    case "DX":
                    case "FC":
                        cboFPI.SelectedIndex = cboFPI.FindString("10");
                        break;
                    case "FH":
                    case "HR":
                    case "ST":
                        cboFPI.SelectedIndex = cboFPI.FindString("12");
                        break;
                    default:
                        cboFPI.SelectedIndex = 0;
                        break;
                }
            }
        }

        private decimal FinHeightParameter()
        {

            return Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight));
        }

        private void Fill_FinHeight()
        {
            //this variable will be set to the height selected if one selected
            //since 0 in not possible as a choice it is used to check if there was something 
            //selected in the first place.
            decimal decSelectedHeight = 0;

            //if we have something selected save the selected value
            if (cboFinHeight.SelectedIndex >= 0)
            {
                decSelectedHeight = Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight));
            }
            cboFinHeight.Items.Clear();

            //this is the face tube value (i.e. 1.5,1.25,1) this number
            //is the "Steps" of possible fin height. If we have 1.5 the 3 first
            //possible height will be 1.5,3,4.5...
            decimal decFaceTubes = FinTypeFaceTube();

            decimal decMaxFinHeight = _backgroundCode.MaxFinHeight(CoilTypeParameter());

            //for each increment of face tubes, add the height
            for (decimal decFinHeight = decFaceTubes * QuickCoilCode.DecMinHeightInFaceTubes; decFinHeight < decMaxFinHeight; decFinHeight += decFaceTubes)
            {
                ComboBoxControl.AddItem(cboFinHeight, decFinHeight.ToString(CultureInfo.InvariantCulture), decFinHeight.ToString(CultureInfo.InvariantCulture));
            }

            //now if the decSelectedHeight is Different than 0 it mean something was 
            //selected.
            if (decSelectedHeight != 0)
            {
                ComboBoxControl.SetIDDefaultValue(cboFinHeight, _backgroundCode.FinHeightSelectClosestValueOfPreviouslySelectedOne(decSelectedHeight, decFaceTubes));
            }
            else
            {
                cboFinHeight.SelectedIndex = 0;
            }
        }

        private void cboFPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //clear fin thickness
            cboFinThickness.Items.Clear();

            //fill the fin material
            Fill_FinMaterial();

            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }
        }

        private void cboFinMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //fill the fins thickness
            Fill_FinThickness();

            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }
        }

        //return the fin thickness parameter
        private string FinThicknessParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinThickness, Public.DSDatabase.Tables["CoilfinThickness"], "UniqueID")[0]["FinThickness"].ToString();
        }

        private void Fill_FinThickness()
        {
            cboFinThickness.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinThickness in Public.DSDatabase.Tables["CoilfinThickness"].Rows)
            {
                //is fin thickness available for the following parameter
                if (_backgroundCode.IsFinThicknessAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), FinTypeParameter(), FPIParameter(), ComboBoxControl.IndexInformation(cboFinMaterial), drFinThickness["FinThickness"].ToString()))
                {
                    string strIndex = drFinThickness["UniqueID"].ToString();
                    string strText = drFinThickness["FinThickness"].ToString();
                    ComboBoxControl.AddItem(cboFinThickness, strIndex, strText);
                }
            }

            //select the default thickness
            ComboBoxControl.SetDefaultValue(cboFinThickness, _backgroundCode.FinThicknessDefault(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), FinTypeParameter(), FinShapeParameter(), FPIParameter(), ComboBoxControl.IndexInformation(cboFinMaterial)));
        }

        //return the Tube Price Per Lbs
        private decimal TubePricePerLbs()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["PricePerLbs"]);
        }

        //return the Tube Density
        private decimal TubeDensity()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["MaterialDensity"]);
        }

        //get tube material parameter
        private string TubeMaterialParameter()
        {
            return ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["TubeMaterialParameter"].ToString();
        }

 

        private void Fill_TubeMaterial()
        {
            cboTubeMaterial.Items.Clear();

            if (cboFinType.SelectedIndex >= 0)
            {

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

                    //is tube material available for the following parameter
                    //if (BackgroundCode.IsTubeMaterialAvailable(Public.dsDATABASE.Tables["v_CoilTubeDefaults"], CoilTypeParameter(), FinTypeParameter(), drTubeMaterial["UniqueID"].ToString(), (CoilTypeParameter() == "HR" && cboHR_RefrigerantType.Text.ToUpper() == "R-410A" ? true : false)))
                    //{
                    if (_backgroundCode.IsTubeMaterialAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], CoilTypeParameter(), FinTypeParameter(), drTubeMaterial["UniqueID"].ToString(), false))
                    {
                        //2010-09-21 : Steam Distributing Cannot have Stainless Steel
                        //so the change is easier to hardcode what being showed when the control is being
                        //filled
                        bool validMaterial = true;

                        if (_openType == CoilOpenType.Selection)
                        {
                            if ((Convert.ToInt32(drTubeMaterial["UniqueID"]) == 4 || Convert.ToInt32(drTubeMaterial["UniqueID"]) == 5) && CoilTypeParameter() == "ST" && cboSTEAM_CoilType.Text == @"Steam Distributing")
                            {
                                //4 and 5 are stainless steel
                                validMaterial = false;
                            }
                        }
                        else
                        {
                            if ((Convert.ToInt32(drTubeMaterial["UniqueID"]) == 4 || Convert.ToInt32(drTubeMaterial["UniqueID"]) == 5) && CoilTypeParameter() == "ST" && txtManualModelName.Text.StartsWith("N"))
                            {
                                //4 and 5 are stainless steel
                                validMaterial = false;
                            }
                        }

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
        }

        private void cboTubeMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //fill tube thickness
            Fill_TubeThickness();

            if (Convert.ToDecimal(ComboBoxControl.IndexInformation(cboTubeMaterial)) == 5)
            {
                cboTurbulator.SelectedIndex = 0;
                cboTurbulator.Enabled = false;
            }
            else
            {
                cboTurbulator.Enabled = true;
            }
            if (numFinLength.Value > 171 && cboTubeMaterial.Text.Contains("Stainless"))
            {
                Public.LanguageBox(
                    "You can't have stainless tubes with a finlength over 171.  The fin length automatically changed to 171.  Thank you!",
                    "Il est impossible d'avoir une longueur de fin au dessus de 171 pouces si le matériel du tube est en inox.  La valeur de la fin length a été automatiquement changée à 171. Merci");
                numFinLength.Value = 171;
            }
            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }
        }

        private string TubeThicknessParameter()
        {
            return ComboBoxControl.ItemInformations(cboTubeThickness, Public.DSDatabase.Tables["CoilTubeThickness"], "UniqueID")[0]["TubeThickness"].ToString();
        }

        private void Fill_TubeThickness()
        {
            cboTubeThickness.Items.Clear();

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
                //if (BackgroundCode.IsTubeThicknessAvailable(Public.dsDATABASE.Tables["v_CoilTubeDefaults"],CoilTypeParameter(),FinTypeParameter(), ComboBoxControl.IndexInformation(cboTubeMaterial), drTubeThickness["TubeThickness"].ToString(),(CoilTypeParameter() == "HR" && cboHR_RefrigerantType.Text.ToUpper() == "R-410A" ? true : false)))
                //{
                if (_backgroundCode.IsTubeThicknessAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], CoilTypeParameter(), FinTypeParameter(), ComboBoxControl.IndexInformation(cboTubeMaterial), drTubeThickness["TubeThickness"].ToString(), false))
                {
                    string strIndex = drTubeThickness["UniqueID"].ToString();
                    string strText = drTubeThickness["TubeThickness"].ToString();
                    ComboBoxControl.AddItem(cboTubeThickness, strIndex, strText);
                }
            }

            //select the default thickness
            //ComboBoxControl.SetDefaultValue(cboTubeThickness, BackgroundCode.TubeThicknessDefault(Public.dsDATABASE.Tables["v_CoilTubeDefaults"], CoilTypeParameter(), FinTypeParameter(), ComboBoxControl.IndexInformation(cboTubeMaterial),(CoilTypeParameter() == "HR" && cboHR_RefrigerantType.Text.ToUpper() == "R-410A" ? true : false)));
            ComboBoxControl.SetDefaultValue(cboTubeThickness, _backgroundCode.TubeThicknessDefault(Public.DSDatabase.Tables["v_CoilTubeDefaults"], CoilTypeParameter(), FinTypeParameter(), ComboBoxControl.IndexInformation(cboTubeMaterial), false));
        }

        private void cboHR_SubCooler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //if it's condenser and subcooler is yes then is enable else disable
            if (cboHR_CoilDesign.Text == @"Condenser" && cboHR_SubCooler.Text == @"YES")
            {
                numHR_FaceTubes.Enabled = true;
                numHR_Circuit.Enabled = true;
                cboHR_SubCoolerConnectionSizeIn.Enabled = true;
                cboHR_SubCoolerConnectionSizeOut.Enabled = true;
            }
            else
            {
                numHR_FaceTubes.Enabled = false;
                numHR_Circuit.Enabled = false;
                cboHR_SubCoolerConnectionSizeIn.Enabled = false;
                cboHR_SubCoolerConnectionSizeOut.Enabled = false;
            }
        }

        private void cboHR_CoilDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //if condenser selected sub cooler enable and heat recovery disable else inverse
            if (cboHR_CoilDesign.Text == @"Condenser")
            {
                cboHR_SubCooler.Enabled = true;
                //if the sub cooler in enable back check if yes then reenable his control
                if (cboHR_SubCooler.Text == @"YES")
                {
                    numHR_FaceTubes.Enabled = true;
                    numHR_Circuit.Enabled = true;
                }
                numHR_HeatRecovery.Enabled = false;
            }
            else
            {
                cboHR_SubCooler.Enabled = false;
                numHR_FaceTubes.Enabled = false;
                numHR_Circuit.Enabled = false;
                numHR_HeatRecovery.Enabled = true;

                //prevent the code from running the code in both connection combobox
                _bolHRConnectionPreventEndlessLoop = true;
                //change both for standard
                cboHR_ConnectionSizeIn.SelectedIndex = 0;
                cboHR_ConnectionSizeOut.SelectedIndex = 0;
                //re enable the code
                _bolHRConnectionPreventEndlessLoop = false;

            }
        }

        private void cboFH_GPM_LeavingLiquidTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //toggle visible the good control
            if (cboFH_GPM_LeavingLiquidTemp.Text == @"USGPM")
            {
                numFH_USGPM.Visible = true;
                numFH_LeavingLiquidTemperature.Visible = false;
            }
            else
            {
                numFH_USGPM.Visible = false;
                numFH_LeavingLiquidTemperature.Visible = true;
            }
        }

        private void cboFH_FluidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            switch (FH_FluidTypeParameter())
            {
                case "OTHER":
                    numFH_Concentration.Minimum = 0;
                    numFH_Concentration.Maximum = 100;
                    numFH_Concentration.Value = 100;
                    numFH_Concentration.Enabled = false;

                    //cboFH_GPM_LeavingLiquidTemp.SelectedIndex = cboFH_GPM_LeavingLiquidTemp.FindString("USGPM");
                    //cboFH_GPM_LeavingLiquidTemp.Enabled = false;
                    numFH_Concentration.Enabled = false;
                    btnFHOtherFluid.Visible = true;
                    break;
                case "WTR": //water is 100% and cannot be changed
                    numFH_Concentration.Minimum = 0;
                    numFH_Concentration.Maximum = 100;
                    numFH_Concentration.Value = 100;
                    numFH_Concentration.Enabled = false;

                    //cboFH_GPM_LeavingLiquidTemp.Enabled = true;
                    //cboFH_FluidType.Enabled = true;
                    btnFHOtherFluid.Visible = false;
                    break;
                case "EG":
                case "PG"://PG and EG are default to 40 and the range is 10-60 and we can
                    //change the value
                    numFH_Concentration.Value = 40;
                    numFH_Concentration.Minimum = 10;
                    numFH_Concentration.Maximum = 60;
                    numFH_Concentration.Enabled = true;

                    //cboFH_GPM_LeavingLiquidTemp.Enabled = true;
                    //cboFH_FluidType.Enabled = true;
                    btnFHOtherFluid.Visible = false;
                    break;
            }
        }

        private void cboFC_FluidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            string strFluidType = FC_FluidTypeParameter();
            switch (strFluidType)
            {
                case "OTHER":
                    numFC_Concentration.Minimum = 0;
                    numFC_Concentration.Maximum = 100;
                    numFC_Concentration.Value = 100;
                    numFC_Concentration.Enabled = false;
                    cboFC_GPM_LeavingLiquidTemp.SelectedIndex = cboFC_GPM_LeavingLiquidTemp.FindString("USGPM");
                    cboFC_GPM_LeavingLiquidTemp.Enabled = false;
                    btnOtherFluid.Visible = true;
                    break;
                case "WTR": //water is 100% and cannot be changed
                    numFC_Concentration.Minimum = 0;
                    numFC_Concentration.Maximum = 100;
                    numFC_Concentration.Value = 100;
                    numFC_Concentration.Enabled = false;

                    cboFC_GPM_LeavingLiquidTemp.Enabled = true;
                    btnOtherFluid.Visible = false;
                    break;
                case "EG":
                case "PG"://PG and EG are default to 40 and the range is 10-60 and we can
                    //change the value
                    numFC_Concentration.Value = 40;
                    numFC_Concentration.Minimum = 10;
                    numFC_Concentration.Maximum = 60;
                    numFC_Concentration.Enabled = true;

                    cboFC_GPM_LeavingLiquidTemp.Enabled = true;
                    btnOtherFluid.Visible = false;
                    break;
            }
        }

        private void cboFC_GPM_LeavingLiquidTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //toggle visible the good control
            if (cboFC_GPM_LeavingLiquidTemp.Text == @"USGPM")
            {
                numFC_USGPM.Visible = true;
                numFC_LeavingLiquidTemperature.Visible = false;
            }
            else
            {
                numFC_USGPM.Visible = false;
                numFC_LeavingLiquidTemperature.Visible = true;
            }
        }

        private void cmdPrintSpecification_Click(object sender, EventArgs e)
        {
            //if we have a coil selected
            if (_dtQuickCoil.Rows.Count > 0)
            {
                ThreadProcess.Start(Public.LanguageString("Generating Report", "Création du rapport"));

                CoilReport.GenerateDataReport(_dtQuickCoil, true, 0, "");

                ThreadProcess.Stop();
                Focus();
            }
            else
            {
                Public.LanguageBox("No coil selected", "Aucun serpentin n'est sélectionné");
            }
        }

        private void cboCasingMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //when the material change the possible thickness also change
            Fill_CasingThickness();

            //2008-11-11 : Sylvain want me to add that logic. He told me
            //it on last thursday. if selected item is galvanized, 
            //select 0.064 by default
            if (cboCasingMaterial.Text == @"Galvanized Steel")
            {
                if (cboCasingThickness.FindString("0.064") >= 0)
                {
                    cboCasingThickness.SelectedIndex = cboCasingThickness.FindString("0.064");
                }
            }

        }

        private void cboConstructionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //if standard is selected then make sure the warning message is hidden
            lblConstructionTypeMessage.Visible = cboConstructionType.SelectedIndex != 0;
        }

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //refresh the location informations
            RefreshLocationWeatherInfromations();

            //save the city in the registry key
            Reg.Set(Reg.Key.Location, ComboBoxControl.IndexInformation(cboLocation));
        }

        private void RefreshLocationWeatherInfromations()
        {
            //change Altitudes
            decimal decAltitude = LocationAltitude();
            numDX_Altitude.Value = decAltitude;
            numHR_Altitude.Value = decAltitude;
            numFC_Altitude.Value = decAltitude;
            numFH_Altitude.Value = decAltitude;
            numSTEAM_Altitude.Value = decAltitude;

            //change DB fresh and return
            decimal decSummerDryBulb = LocationSummerDB();
            decimal decWinterDryBulb = LocationWinterDB();
            numDX_FreshEDB.Value = decSummerDryBulb;
            numDX_ReturnEDB.Value = decSummerDryBulb;
            numHR_FreshEDB.Value = decSummerDryBulb;
            numHR_ReturnEDB.Value = decSummerDryBulb;
            numFC_FreshEDB.Value = decSummerDryBulb;
            numFC_ReturnEDB.Value = decSummerDryBulb;
            numFH_FreshEDB.Value = decWinterDryBulb;
            numFH_ReturnEDB.Value = decWinterDryBulb;
            numSTEAM_FreshEDB.Value = decWinterDryBulb;
            numSTEAM_ReturnEDB.Value = decWinterDryBulb;

            //change WB fresh and return
            decimal decSummerWetBulb = LocationSummerWB();
            numDX_FreshEWB.Value = decSummerWetBulb;
            numDX_ReturnEWB.Value = decSummerWetBulb;
            numFC_FreshEWB.Value = decSummerWetBulb;
            numFC_ReturnEWB.Value = decSummerWetBulb;
        }

        private void DX_CFM(object sender, EventArgs e)
        {
            ClearSelection();
            lblDX_MixingCFM.Text = Public.MixCFM(numDX_FreshCFM.Value, numDX_ReturnCFM.Value).ToString(CultureInfo.InvariantCulture);
            decimal mixDB = Public.MixTemperature(numDX_FreshCFM.Value, numDX_ReturnCFM.Value, numDX_FreshEDB.Value, numDX_ReturnEDB.Value);
            lblDX_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
            decimal mixWB = Public.MixWetBulbTemperature(numDX_FreshCFM.Value, numDX_ReturnCFM.Value, numDX_FreshEDB.Value, numDX_ReturnEDB.Value, numDX_FreshEWB.Value, numDX_ReturnEWB.Value, Convert.ToInt32(numDX_Altitude.Value));
            lblDX_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void DX_EDB(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixDB = Public.MixTemperature(numDX_FreshCFM.Value, numDX_ReturnCFM.Value, numDX_FreshEDB.Value, numDX_ReturnEDB.Value);
            lblDX_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
            decimal mixWB = Public.MixWetBulbTemperature(numDX_FreshCFM.Value, numDX_ReturnCFM.Value, numDX_FreshEDB.Value, numDX_ReturnEDB.Value, numDX_FreshEWB.Value, numDX_ReturnEWB.Value, Convert.ToInt32(numDX_Altitude.Value));
            lblDX_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void DX_EWB(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixWB = Public.MixWetBulbTemperature(numDX_FreshCFM.Value, numDX_ReturnCFM.Value, numDX_FreshEDB.Value, numDX_ReturnEDB.Value, numDX_FreshEWB.Value, numDX_ReturnEWB.Value, Convert.ToInt32(numDX_Altitude.Value));
            lblDX_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void HR_CFM(object sender, EventArgs e)
        {
            ClearSelection();
            lblHR_MixingCFM.Text = Public.MixCFM(numHR_FreshCFM.Value, numHR_ReturnCFM.Value).ToString(CultureInfo.InvariantCulture);
            decimal mixDB = Public.MixTemperature(numHR_FreshCFM.Value, numHR_ReturnCFM.Value, numHR_FreshEDB.Value, numHR_ReturnEDB.Value);
            lblHR_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
        }

        private void HR_EDB(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixDB = Public.MixTemperature(numHR_FreshCFM.Value, numHR_ReturnCFM.Value, numHR_FreshEDB.Value, numHR_ReturnEDB.Value);
            lblHR_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
        }

        private void STEAM_CFM(object sender, EventArgs e)
        {
            ClearSelection();
            lblSTEAM_MixingCFM.Text = Public.MixCFM(numSTEAM_FreshCFM.Value, numSTEAM_ReturnCFM.Value).ToString(CultureInfo.InvariantCulture);
            decimal mixDB = Public.MixTemperature(numSTEAM_FreshCFM.Value, numSTEAM_ReturnCFM.Value, numSTEAM_FreshEDB.Value, numSTEAM_ReturnEDB.Value);
            lblSTEAM_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
        }

        private void STEAM_EDB(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixDB = Public.MixTemperature(numSTEAM_FreshCFM.Value, numSTEAM_ReturnCFM.Value, numSTEAM_FreshEDB.Value, numSTEAM_ReturnEDB.Value);
            lblSTEAM_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
        }

        private void FC_CFM(object sender, EventArgs e)
        {
            ClearSelection();
            lblFC_MixingCFM.Text = Public.MixCFM(numFC_FreshCFM.Value, numFC_ReturnCFM.Value).ToString(CultureInfo.InvariantCulture);
            decimal mixDB = Public.MixTemperature(numFC_FreshCFM.Value, numFC_ReturnCFM.Value, numFC_FreshEDB.Value, numFC_ReturnEDB.Value);
            lblFC_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
            decimal mixWB = Public.MixWetBulbTemperature(numFC_FreshCFM.Value, numFC_ReturnCFM.Value, numFC_FreshEDB.Value, numFC_ReturnEDB.Value, numFC_FreshEWB.Value, numFC_ReturnEWB.Value, Convert.ToInt32(numFC_Altitude.Value));
            lblFC_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void FC_EDB(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixDB = Public.MixTemperature(numFC_FreshCFM.Value, numFC_ReturnCFM.Value, numFC_FreshEDB.Value, numFC_ReturnEDB.Value);
            lblFC_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
            decimal mixWB = Public.MixWetBulbTemperature(numFC_FreshCFM.Value, numFC_ReturnCFM.Value, numFC_FreshEDB.Value, numFC_ReturnEDB.Value, numFC_FreshEWB.Value, numFC_ReturnEWB.Value, Convert.ToInt32(numFC_Altitude.Value));
            lblFC_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void FC_EWB(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixWB = Public.MixWetBulbTemperature(numFC_FreshCFM.Value, numFC_ReturnCFM.Value, numFC_FreshEDB.Value, numFC_ReturnEDB.Value, numFC_FreshEWB.Value, numFC_ReturnEWB.Value, Convert.ToInt32(numFC_Altitude.Value));
            lblFC_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void FH_CFM(object sender, EventArgs e)
        {
            ClearSelection();
            lblFH_MixingCFM.Text = Public.MixCFM(numFH_FreshCFM.Value, numFH_ReturnCFM.Value).ToString(CultureInfo.InvariantCulture);
            decimal mixDB = Public.MixTemperature(numFH_FreshCFM.Value, numFH_ReturnCFM.Value, numFH_FreshEDB.Value, numFH_ReturnEDB.Value);
            lblFH_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
        }

        private void FH_EDB(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixDB = Public.MixTemperature(numFH_FreshCFM.Value, numFH_ReturnCFM.Value, numFH_FreshEDB.Value, numFH_ReturnEDB.Value);
            lblFH_MixingEDB.Text = (mixDB == -9999m ? "0" : mixDB.ToString(CultureInfo.InvariantCulture));
        }

        private void picFinShape_MouseHover(object sender, EventArgs e)
        {
            //if there is a fin shape selected
            if (cboFinShape.SelectedIndex >= 0)
            {
                if (System.IO.File.Exists(FinShapeImageLocation()))
                {
                    //load the associated picture
                    picFinShapePicture.Load(FinShapeImageLocation());
                    //bring to front the panel
                    pnlFinShape.BringToFront();
                    //show the panel
                    pnlFinShape.Visible = true;
                }
            }
        }

        private void picFinShape_MouseLeave(object sender, EventArgs e)
        {
            //hide the panel
            pnlFinShape.Visible = false;
        }

        private void picFinType_MouseHover(object sender, EventArgs e)
        {
            //if there is a fin type selected
            if (cboFinType.SelectedIndex >= 0)
            {
                //change the value of labels
                lblTubeDiameterValue.Text = FinTypeTubeDiameter() + @"""";
                lblTubeRowValue.Text = FinTypeTubeRow() + @"""";
                lblFaceTubeValue.Text = FinTypeFaceTube() + @"""";
                lblTubeDiagonalValue.Text = FinTypeTubeDiagonal() + @"""";
                //bring to front the panel
                pnlFinType.BringToFront();
                //show the panel
                pnlFinType.Visible = true;
            }
        }

        private void picFinType_MouseLeave(object sender, EventArgs e)
        {
            //hide the panel
            pnlFinType.Visible = false;
        }

        private void numFinLength_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }
            if (numFinLength.Value > 171 && cboTubeMaterial.Text.Contains("Stainless"))
            {
                Public.LanguageBox(
                    "You can't have stainless tubes with a finlength over 171.  The fin length automatically changed to 171.  Thank you!",
                    "Il est impossible d'avoir une longueur de fin au dessus de 171 pouces si le matériel du tube est en inox.  La valeur de la fin length a été automatiquement changée à 171. Merci");
                numFinLength.Value = 171;
            }
            //2012-05-22 : #2686 : casing material and tickness default depending on face area now
            AutoSelectCasingMaterialAndThickness();



            ////only steam has the header changing depending on the
            ////fin length so we don't need to refresh for nothing on other coil.
            //if (CoilTypeParameter() == "ST")
            //{
            //    ValidateHeaderQuantity();
            //}
        }

        //private decimal HeaderQuantity()
        //{
        //    return Convert.ToDecimal(ComboBoxControl.IndexInformation(cboHeaderQuantity));
        //}

        ////fill the header quantity for FC and FH
        //private void Fill_FC_FH_HeaderQuantity()
        //{
        //    //clear
        //    cboHeaderQuantity.Items.Clear();
        //    //add automatic
        //    ComboBoxControl.AddItem(cboHeaderQuantity, "2", "AUTOMATIC");
        //    //for each quantity with jump of 2 starting at 2 add them
        //    for (int intQuantity = 2; intQuantity <= 30; intQuantity = intQuantity + 2)
        //    {
        //        ComboBoxControl.AddItem(cboHeaderQuantity, intQuantity.ToString(), intQuantity.ToString());
        //    }

        //    //select first
        //    cboHeaderQuantity.SelectedIndex = 0;
        //}

        //fill the header quantity (pass the combobox) multiple use the same logic
        private void Fill_HeaderQuantity(ComboBox cboCoilHeaderQuantity)
        {
            //clear
            cboCoilHeaderQuantity.Items.Clear();
            //add automatic
            ComboBoxControl.AddItem(cboCoilHeaderQuantity, "0", "AUTOMATIC");
            //for each quantity from 1 to 30
            for (int intQuantity = 1; intQuantity <= 30; intQuantity++)
            {
                ComboBoxControl.AddItem(cboCoilHeaderQuantity, intQuantity.ToString(CultureInfo.InvariantCulture), intQuantity.ToString(CultureInfo.InvariantCulture));
            }

            //select first
            cboCoilHeaderQuantity.SelectedIndex = 0;
        }

        ////validate the header quantity
        //private void ValidateHeaderQuantity()
        //{
        //    switch (CoilTypeParameter())
        //    { 
        //        case "ST":
        //            //clear
        //            cboHeaderQuantity.Items.Clear();
        //            //steam distributing 2 different range while standar only 1
        //            if (cboSTEAM_CoilType.Text == "Steam Distributing")
        //            {
        //                if (numFinLength.Value <= 84m)
        //                {
        //                    //add
        //                    ComboBoxControl.AddItem(cboHeaderQuantity, "1", "1");
        //                }
        //                else
        //                {
        //                    //add
        //                    ComboBoxControl.AddItem(cboHeaderQuantity, "2", "2");
        //                }
        //            }
        //            else
        //            {
        //                //add
        //                ComboBoxControl.AddItem(cboHeaderQuantity, "2", "2");
        //            }
        //            //select first
        //            cboHeaderQuantity.SelectedIndex = 0;
        //            break;
        //        case "FC":
        //        case "FH":
        //            Fill_FC_FH_HeaderQuantity();
        //            break;
        //        case "HR":
        //        case "DX":
        //            Fill_HeaderQuantity();
        //            break;
        //    }
        //}

        private void cboSTEAM_CoilType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            ////header quantity are related to steam coil type
            //ValidateHeaderQuantity();

            if (cboSTEAM_CoilType.Text == @"Standard Steam")
            {
                cboSTEAMTubeOrientation.SelectedIndex = 0;
                cboSTEAMTubeOrientation.Enabled = true;
            }
            else
            {
                cboSTEAMTubeOrientation.SelectedIndex = 0;
                cboSTEAMTubeOrientation.Enabled = false;
            }

            if (!_formIsLoading)
            {
                Fill_TubeMaterial();
            }
        }

        private void cboFinShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //fill the fpi
            Fill_FPI();

            //fin material is related to fin shape
            Fill_FinMaterial();
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void cboCoilCoating_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////when the coating change, recalculate the pricing
            if (_openType == CoilOpenType.Manual)
            {
                LblCoatingPriceDetail.Text = GetCoatingPriceManualSelection().ToString("N2") + @" $";
            }
        }

        private void cboFinHeight_Leave(object sender, EventArgs e)
        {
            //we do it only if we have items in the control
            if (cboFinHeight.Items.Count > 0)
            {
                try
                {
                    //try to convert in decimal
                    decimal decEnteredValue = Convert.ToDecimal(((ComboBox)sender).Text);

                    //find and select the closest value
                    ComboBoxControl.SetIDDefaultValue(((ComboBox)sender), _backgroundCode.FinHeightSelectClosestValueOfPreviouslySelectedOne(decEnteredValue, FinTypeFaceTube()));
                }
                catch(Exception ex)
                {
                    Public.PushLog(ex.ToString(),"frmQuickCoil cboFinHeigth_Leave");
                    //if it catch it mean what was entered wasn't a number or valid
                    //selection
                    ((ComboBox)sender).SelectedIndex = 0;
                }
            }
        }

        private void cboFinHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboFinHeight.Items.Count == 0)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void cboFPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboFPI.Items.Count == 0)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void cboFPI_Leave(object sender, EventArgs e)
        {
            //we do it only if we have items in the control
            if (cboFPI.Items.Count > 0)
            {
                try
                {
                    //try to convert in int
                    int intEnteredValue = Convert.ToInt32(cboFPI.Text);

                    //since fpi is only integer we can let the default function for combobox
                    //handle the auto select. If the number entered isn't found
                    //the function autoselect the first item.
                    ComboBoxControl.SetIDDefaultValue(cboFPI, intEnteredValue.ToString(CultureInfo.InvariantCulture));
                }
                catch(Exception ex)
                {
                    Public.PushLog(ex.ToString(),"frmQuickCoil cboFPI_Leave");
                    //if it catch it mean what was entered wasn't a number or valid
                    //selection
                    cboFPI.SelectedIndex = 0;
                }
            }
        }

        private void cboFinHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //get quantity of face tubes
            decimal decQuantityOfFaceTubes = Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight)) / FinTypeFaceTube();

            //check if the number is divisible by 2 (odd or even)
            lblFinHeightOddFaceTube.Visible = decQuantityOfFaceTubes / 2m != Math.Ceiling(decQuantityOfFaceTubes / 2m);

            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }

            //2012-05-22 : #2686 : casing material and tickness default depending on face area now
            AutoSelectCasingMaterialAndThickness();

            
        }

        //Function to check that, in no case, there ever is more tube faces then circuits.  If we have more, it opens a message box asking the user to verify his design with Sales.
        private void VerifyIfMoreCircuitsThanTubeFaces(int tubeFace, int circuits)
        {
            
            //Let's find the right type of coil first, and then associate the right circuits to it
            string strCoilType = CoilTypeParameter();
           
            //Steam Coils don't have circuits, so it doesn't matter for them.
            if(strCoilType != "ST")
            {
                if (tubeFace < Convert.ToDecimal(circuits))
                {
                        Public.LanguageBox(
                            "Your design needs reviewing : You have more circuits than tube faces.  The system will still save your coil, but please verify it with Refplus' sales departement.  Thank you!",
                            "Votre design doit être révisé: Votre serpentin possède plus de circuits que de tubes-faces.  Le système le sauvegardera quand même, mais veuillez vérifier ce serpentin avec l'équipe de ventes de Refplus. Merci!");
                }
            }
        }
    
        private void cboFH_NumberOfCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            if (cboFH_NumberOfCircuits.Text == @"AUTOMATIC")
            {
                lblFH_MaxPressure.Enabled = true;
                numFH_MaxPressure.Enabled = true;
            }
            else
            {
                lblFH_MaxPressure.Enabled = false;
                numFH_MaxPressure.Enabled = false;
            }
        }

        private void cboFC_NumberOfCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            if (cboFC_NumberOfCircuits.Text == @"AUTOMATIC")
            {
                lblFC_MaxPressure.Enabled = true;
                numFC_MaxPressure.Enabled = true;
            }
            else
            {
                lblFC_MaxPressure.Enabled = false;
                numFC_MaxPressure.Enabled = false;
            }
        }

        private void cboHR_ConnectionSizeIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //if we can run throught and it's heat reclaim (only heat reclaim have
            //the same connection on both inlet and outlet)
            if (!_bolHRConnectionPreventEndlessLoop && cboHR_CoilDesign.Text == @"Heat Reclaim")
            {
                //prevent the code from running in the outlet connection
                _bolHRConnectionPreventEndlessLoop = true;
                //auto select the same size in the outlet
                cboHR_ConnectionSizeOut.SelectedIndex = cboHR_ConnectionSizeIn.SelectedIndex;
                //re enable the code for later uses
                _bolHRConnectionPreventEndlessLoop = false;
            }
        }

        private void cboHR_ConnectionSizeOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //if we can run throught and it's heat reclaim (only heat reclaim have
            //the same connection on both inlet and outlet)
            if (!_bolHRConnectionPreventEndlessLoop && cboHR_CoilDesign.Text == @"Heat Reclaim")
            {
                //prevent the code from running in the outlet connection
                _bolHRConnectionPreventEndlessLoop = true;
                //auto select the same size in the inlet
                cboHR_ConnectionSizeIn.SelectedIndex = cboHR_ConnectionSizeOut.SelectedIndex;
                //re enable the code for later uses
                _bolHRConnectionPreventEndlessLoop = false;
            }
        }

        private void ValidateUpDownEmpty(object sender, CancelEventArgs e)
        {
            ((NumericUpDown)sender).Text = ((NumericUpDown)sender).Value.ToString(CultureInfo.InvariantCulture);
        }

        private void cboHR_RefrigerantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            //fin height is dependent on FinType
            cboFinHeight.Items.Clear();
            //fintype has a bearing on FPI
            cboFPI.Items.Clear();
            //FPI has a bearing on Fin material
            cboFinMaterial.Items.Clear();
            //fin material as a bearing on fin thickness
            cboFinThickness.Items.Clear();

            cboTubeMaterial.Items.Clear();
            cboTubeThickness.Items.Clear();

            //now call the fill of the fintype
            Fill_FinType();

            ValidateRefWithShape();
        }

        private void cboFH_DesignType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            _backgroundCode.Fill_FC_FH_Circuits(cboFH_NumberOfCircuits,
                cboFH_DesignType.SelectedIndex == 0 ? DesignType.Standard : DesignType.Booster);
            if (cboFH_DesignType.Text == @"Booster")
            {
                cboFH_ConnectionType.SelectedIndex = cboFH_ConnectionType.FindString("SWEAT");
            }
            if (cboFH_ConnectionType.SelectedIndex >= 0)
            {
                Fill_FH_ConnectionSize();
            }
        }

        private void cboFC_DesignType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
            _backgroundCode.Fill_FC_FH_Circuits(cboFC_NumberOfCircuits,
                cboFC_DesignType.SelectedIndex == 0 ? DesignType.Standard : DesignType.Booster);
            if (cboFC_DesignType.Text == @"Booster")
            {
                cboFC_ConnectionType.SelectedIndex = cboFC_ConnectionType.FindString("SWEAT");
            }
            if (cboFC_ConnectionType.SelectedIndex >= 0)
            {
                Fill_FC_ConnectionSize();
            }
        }

        private bool SelectCoilCoating()
        {
            bool coilCoatingSelected = false;
            string previousSelection = cboCoilCoating.Text;

            if (_openType == CoilOpenType.Selection)
            {
                Fill_CoilCoating();
            }
            else
            {
                Fill_CoilCoatingManualSelection();
            }

            var selectCoating = new FrmCoilCoating(cboCoilCoating, previousSelection);

            if (selectCoating.ShowDialog() == DialogResult.Yes)
            {
                coilCoatingSelected = true;
                cboCoilCoating.SelectedIndex = cboCoilCoating.FindString(selectCoating.GetCoilCoating());
            }
            selectCoating.Dispose();

            return coilCoatingSelected;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (_openType == CoilOpenType.Selection)
            {
                if (_dtQuickCoil.Rows.Count > 0)
                {
                    if (SelectCoilCoating())
                    {
                        VerifyIfMoreCircuitsThanTubeFaces(Convert.ToInt32(_dtQuickCoil.Rows[0]["CoilModel"].ToString().Substring(_dtQuickCoil.Rows[0]["CoilModel"].ToString().IndexOf('-') + 1, 2)), Convert.ToInt32(_dtQuickCoil.Rows[0]["R_NumberOfCircuits"].ToString()));
                        if (_bolQuoteSelection)
                        {
                            ThreadProcess.UpdateMessage(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                            int newIndexToPush;
                            if (_intIndex != -1)
                            {
                                var savingoption = new FrmSavingOption();

                                ThreadProcess.Stop();
                                Focus();

                                if (savingoption.ShowDialog() == DialogResult.Yes)
                                {   
                                    //if he want to overwrite
                                    //it's a modification unit so we delete and recreate records
                                    _quoteform.DeleteFromQuoteCoil(_intIndex);
                                    newIndexToPush = _intIndex;
                                    _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Coil), newIndexToPush);
                                }
                                else
                                {
                                    _quoteform.ClearSQL(_intIndex);
                                    //since we actually always recreate the record
                                    //save as new is simple, all i have to do is copy the additionnal items
                                    //if reused the update function to instead duplicate record.
                                    newIndexToPush = _quoteform.GetNextID("QuickCoil");
                                    _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Coil), newIndexToPush);
                                }
                                ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                            }
                            else
                            {
                                newIndexToPush = _quoteform.GetNextID("QuickCoil");
                            }

                            FillInformations();
                            AddToQuote(newIndexToPush);

                            _quoteform.RefreshBasketList();
                            _quoteform.SetQuoteIsModified(true);

                            ThreadProcess.Stop();
                            Focus();
                            Dispose();
                        }
                    }
                }
            }
            else
            {
                if (SelectCoilCoating())
                {
                    
                    if (AreAllValueFilledForManualSelection())
                    {
                        if (_bolQuoteSelection)
                        {
                            ThreadProcess.UpdateMessage(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                            int newIndexToPush;
                            if (_intIndex != -1)
                            {
                                //it's a modification unit so we delete and recreate records
                                _quoteform.DeleteFromQuoteManualCoil(_intIndex);
                                newIndexToPush = _intIndex;
                                _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.ManualCoil), newIndexToPush);
                            }
                            else
                            {
                                newIndexToPush = _quoteform.GetNextID("QuickManualCoil");
                            }
                            FillInformations();
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
                        Public.LanguageBox("Some fields are not filled", "Certains champs ne sont pas remplis");
                    }
                }
            }
        }
        private bool AreAllValueFilledForManualSelection()
        {
            bool bolAllValueFilled = true;

            if (ValidateManualModel(false))
            {
                if (ComboboxNotSelected(cboFinMaterial)) bolAllValueFilled = false;
                if (ComboboxNotSelected(cboFinThickness)) bolAllValueFilled = false;
                if (ComboboxNotSelected(cboTubeMaterial)) bolAllValueFilled = false;
                if (ComboboxNotSelected(cboTubeThickness)) bolAllValueFilled = false;
                if (ComboboxNotSelected(cboFinMaterial)) bolAllValueFilled = false;
                if (ComboboxNotSelected(cboManualConnectionSize)) bolAllValueFilled = false;
                if (ComboboxNotSelected(cboCoilCoating)) bolAllValueFilled = false;
            }
            else
            {
                bolAllValueFilled = false;
            }

            return bolAllValueFilled;
        }
        
        
        private bool ComboboxNotSelected(ComboBox cbo)
        {
            return (cbo.SelectedIndex == -1);
        }

        private void FillInformations()
        {
            if (_openType == CoilOpenType.Selection)
            {
                _dtQuickCoil.Rows[0]["CoilCoating"] = cboCoilCoating.Text;
                decimal decTurbulatorAdder = 0m;
                _dtQuickCoil.Rows[0]["CoilPrice"] = GetCoilPrice(ref decTurbulatorAdder);
                _dtQuickCoil.Rows[0]["CoatingPrice"] = GetCoatingPrice();
                _dtQuickCoil.Rows[0]["TurbulatorPrice"] = decTurbulatorAdder;
                _dtQuickCoil.Rows[0]["Input_CoilType"] = cboCoilType.Text;
                _dtQuickCoil.Rows[0]["Input_ConstructionType"] = cboConstructionType.Text;
                _dtQuickCoil.Rows[0]["Input_Location"] = cboLocation.Text;
                _dtQuickCoil.Rows[0]["Input_ConnectionSide"] = cboConnectionSide.Text;
                _dtQuickCoil.Rows[0]["Input_CasingMaterial"] = cboCasingMaterial.Text;
                _dtQuickCoil.Rows[0]["Input_CasingThickness"] = cboCasingThickness.Text;
                _dtQuickCoil.Rows[0]["Input_DX_RefrigerantType"] = cboDX_RefrigerantType.Text;
                _dtQuickCoil.Rows[0]["Input_DX_ConnectionSizeInlet"] = cboDX_ConnectionSizeInlet.Text;
                _dtQuickCoil.Rows[0]["Input_DX_ConnectionSizeOutlet"] = cboDX_ConnectionSizeOutlet.Text;
                _dtQuickCoil.Rows[0]["Input_DX_HeaderQuantity"] = cboDX_HeaderQuantity.Text;
                _dtQuickCoil.Rows[0]["Input_HR_CoilDesign"] = cboHR_CoilDesign.Text;
                _dtQuickCoil.Rows[0]["Input_HR_ConnectionSizeInlet"] = cboHR_ConnectionSizeIn.Text;
                _dtQuickCoil.Rows[0]["Input_HR_ConnectionSizeOutlet"] = cboHR_ConnectionSizeOut.Text;
                _dtQuickCoil.Rows[0]["Input_HR_HeaderQuantity"] = cboHR_HeaderQuantity.Text;
                _dtQuickCoil.Rows[0]["Input_HR_SubCoolerConnIn"] = cboHR_SubCoolerConnectionSizeIn.Text;
                _dtQuickCoil.Rows[0]["Input_HR_SubCoolerConnOut"] = cboHR_SubCoolerConnectionSizeOut.Text;
                _dtQuickCoil.Rows[0]["Input_FH_DesignType"] = cboFH_DesignType.Text;
                _dtQuickCoil.Rows[0]["Input_FH_ConnectionSize"] = cboFH_ConnectionSize.Text;
                _dtQuickCoil.Rows[0]["Input_FH_HeaderQuantity"] = cboFH_HeaderQuantity.Text;
                _dtQuickCoil.Rows[0]["Input_FH_GPM_LLT"] = cboFH_GPM_LeavingLiquidTemp.Text;
                _dtQuickCoil.Rows[0]["Input_FC_DesignType"] = cboFC_DesignType.Text;
                _dtQuickCoil.Rows[0]["Input_FC_ConnectionSize"] = cboFC_ConnectionSize.Text;
                _dtQuickCoil.Rows[0]["Input_FC_HeaderQuantity"] = cboFC_HeaderQuantity.Text;
                _dtQuickCoil.Rows[0]["Input_FC_GPM_LLT"] = cboFC_GPM_LeavingLiquidTemp.Text;
                _dtQuickCoil.Rows[0]["Input_STEAM_TubeOrientation"] = cboSTEAMTubeOrientation.Text;
                _dtQuickCoil.Rows[0]["GCAltitude"] = numGC_Altitude.Text;
                _dtQuickCoil.Rows[0]["GCGIN"] = numGC_GIN.Text;
                _dtQuickCoil.Rows[0]["GCGFLO"] = numGC_GFLO.Text;
                _dtQuickCoil.Rows[0]["GCGPSI"] = numGC_GPSI.Text;
                _dtQuickCoil.Rows[0]["GCNumberOfCircuits"] = cboGC_Circuits.Text;
                _dtQuickCoil.Rows[0]["GCAirFlowRate"] = numGC_FreshCFM.Text;
                _dtQuickCoil.Rows[0]["GCEnteringDryBulb"] = numGC_FreshEDB.Text;

            }
            else
            {
                _dtQuickManualCoil.Rows.Clear();
                DataRow drQuickManualCoil = _dtQuickManualCoil.NewRow();

                drQuickManualCoil["QuoteID"] = 0;
                drQuickManualCoil["QuoteRevision"] = 0;
                drQuickManualCoil["QuoteRevisionText"] = "";
                drQuickManualCoil["ItemType"] = 0;
                drQuickManualCoil["ItemID"] = 0;
                drQuickManualCoil["Username"] = "";

                drQuickManualCoil["Tag"] = txtTag.Text;
                drQuickManualCoil["CoilModel"] = txtManualModelName.Text;
                drQuickManualCoil["Input_ConnectionSide"] = cboConnectionSide.Text;
                drQuickManualCoil["Input_CasingMaterial"] = cboCasingMaterial.Text;
                drQuickManualCoil["Input_CasingThickness"] = cboCasingThickness.Text;
                drQuickManualCoil["Quantity"] = numQuantity.Value;
                drQuickManualCoil["Input_FinMaterial"] = cboFinMaterial.Text;
                drQuickManualCoil["Input_FinThickness"] = FinThicknessParameter();
                drQuickManualCoil["Input_TubeMaterial"] = cboTubeMaterial.Text;
                drQuickManualCoil["Input_TubeThickness"] = TubeThicknessParameter();
                //that will eventually ahve to change but ill check for FC or booster in the loading
                //anyway ot doesnt show anywhere it's just to be able to load back the same list of connection size
                drQuickManualCoil["Input_ConnectionType"] = cboFC_ConnectionType.Text;
                drQuickManualCoil["Input_ConnectionSize"] = cboManualConnectionSize.Text;
                drQuickManualCoil["Input_CoilCoating"] = cboCoilCoating.Text;
                drQuickManualCoil["Input_Turbulator"] = cboTurbulator.Text;
                drQuickManualCoil["Input_SampleCoil"] = (chkSampleCoil.Checked ? 1 : 0);

                decimal decTurbulatorAdder = 0m;
                drQuickManualCoil["Price"] = GetCoilPriceManualSelection(ref decTurbulatorAdder);
                drQuickManualCoil["CoatingPrice"] = GetCoatingPriceManualSelection();
                drQuickManualCoil["TurbulatorPrice"] = decTurbulatorAdder;

                _dtQuickManualCoil.Rows.Add(drQuickManualCoil);
            }
        }

        private void AddToQuote(int itemID)
        {
            if (_openType == CoilOpenType.Selection)
            {
                _dtQuickCoil.Rows[0]["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Coil);
                _dtQuickCoil.Rows[0]["ItemID"] = itemID;
                if (_intPosition == -1)
                {
                    _dsQuoteData.Tables["QuickCoil"].Rows.Add(_dtQuickCoil.Rows[0].ItemArray);
                }
                else
                {
                    DataRow dr = _dsQuoteData.Tables["QuickCoil"].NewRow();
                    dr.ItemArray = _dtQuickCoil.Rows[0].ItemArray;
                    _dsQuoteData.Tables["QuickCoil"].Rows.InsertAt(dr, _intPosition);
                }
            }
            else
            {
                _dtQuickManualCoil.Rows[0]["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.ManualCoil);
                _dtQuickManualCoil.Rows[0]["ItemID"] = itemID;
                _dsQuoteData.Tables["QuickManualCoil"].Rows.Add(_dtQuickManualCoil.Rows[0].ItemArray);
            }
            DataTable copy = _dsQuoteData.Tables["QuickCoil"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["QuickCoil"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["QuickCoil"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["CoilType"], row["CoilModel"], row["Tag"], row["Quantity"], row["CasingMaterial"], row["CasingThickness"], row["HeaderQuantity"], row["ConnectionSide"], row["ConstructionType"], row["CoilCoating"], row["DXRefrigerantType"], row["DXAirFlowRate"], row["DXEnteringDryBulb"], row["DXEnteringWetBulb"], row["DXFreshCFM"], row["DXFreshEDB"], row["DXFreshEWB"], row["DXReturnCFM"], row["DXReturnEDB"], row["DXReturnEWB"], row["DXSuctionTemperature"], row["DXAltitude"], row["DXLiquidTemp"], row["DXNumberOfCircuit"], row["DXConnectionSizeIn"], row["DXConnectionSizeOut"], row["HRRefrigerantType"], row["HRAirFlowRate"], row["HREnteringDryBulb"], row["HRFreshCFM"], row["HRFreshEDB"], row["HRReturnCFM"], row["HRReturnEDB"], row["HRCondensingTemperature"], row["HRSuctionTemperature"], row["HRAltitude"], row["HRNumberOfCircuit"], row["HRCoilDesign"], row["HRSubCooler"], row["HRFaceTubes"], row["HRCircuits"], row["HRHeatRecovery"], row["HRConnectionSizeIn"], row["HRConnectionSizeOut"], row["HRSubCoolerConnectionSizeIn"], row["HRSubCoolerConnectionSizeOut"], row["FCDesignType"], row["FCConnectionType"], row["FCConnectionSizeIn"], row["FCConnectionSizeOut"], row["FCAirFlowRate"], row["FCEnteringDryBulb"], row["FCEnteringWetBulb"], row["FCFreshCFM"], row["FCFreshEDB"], row["FCFreshEWB"], row["FCReturnCFM"], row["FCReturnEDB"], row["FCReturnEWB"], row["FCEnteringLiquidTemperature"], row["FCAltitude"], row["FCFluidType"], row["FCConcentration"], row["FCUSGPM"], row["FCLeavingLiquidTemperature"], row["FCNumberOfCircuits"], row["FCMaxPressure"], row["FCFluidTypeName"], row["FCSpecificHeat"], row["FCDensity"], row["FCViscosity"], row["FCThermalConductivity"], row["STEAMSteamCoilType"], row["STEAMConnectionType"], row["STEAMCondensateConnection"], row["STEAMSteamConnection"], row["STEAMAirFlowRate"], row["STEAMEnteringDryBulb"], row["STEAMFreshCFM"], row["STEAMFreshEDB"], row["STEAMReturnCFM"], row["STEAMReturnEDB"], row["STEAMSaturatedSteamPressure"], row["STEAMAltitude"], row["FHDesignType"], row["FHConnectionType"], row["FHConnectionSizeIn"], row["FHConnectionSizeOut"], row["FHAirFlowRate"], row["FHEnteringDryBulb"], row["FHFreshCFM"], row["FHFreshEDB"], row["FHReturnCFM"], row["FHReturnEDB"], row["FHEnteringLiquidTemperature"], row["FHAltitude"], row["FHFluidType"], row["FHConcentration"], row["FHUSGPM"], row["FHLeavingLiquidTemperature"], row["FHNumberOfCircuit"], row["FHMaxPressure"], row["FHFluidTypeName"], row["FHSpecificHeat"], row["FHDensity"], row["FHViscosity"], row["FHThermalConductivity"], row["FinType"], row["FinTypeText"], row["TubeDiameter"], row["FaceTube"], row["TubeRow"], row["TubeDiagonal"], row["FinShape"], row["FinShapeText"], row["TubeType"], row["Turbulators"], row["FinHeight"], row["FinLength"], row["Row"], row["FPI"], row["TubeMaterial"], row["TubeMaterialText"], row["TubeThickness"], row["FinMaterial"], row["FinMaterialText"], row["FinThickness"], row["CasingDensity"], row["CasingPricePerLbs"], row["FinDensity"], row["FinPricePerLbs"], row["TubeDensity"], row["TubePricePerLbs"], row["Weight"], row["R_Rows"], row["R_Circuiting"], row["R_NumberOfCircuits"], row["R_FPI"], row["R_CoilFaceArea"], row["R_FaceVelocity"], row["R_AirPressureDrop"], row["R_LeavingDryBulb"], row["R_LeavingWetBulb"], row["R_TotalHeat"], row["R_SensibleHeat"], row["R_LeavingLiquidTemperature"], row["R_CircuitLoad"], row["R_RefrigerantPressureDrop"], row["R_RefrigerantPressureDropPerDegree"], row["R_FaceTube"], row["R_SteamConsumption"], row["R_SteamTemperature"], row["R_SubCoolerCapacity"], row["R_SubCoolerRefrigerantLeavingTemperature"], row["R_SubCoolerPressureDrop"], row["R_ConnectionSize"], row["R_GPM"], row["R_WaterVelocity"], row["R_ARI_STANDARD"], row["FHFreezeStat"], row["CoilPrice"], row["CoatingPrice"], row["TurbulatorPrice"], row["Input_CoilType"], row["Input_ConstructionType"], row["Input_Location"], row["Input_ConnectionSide"], row["Input_CasingMaterial"], row["Input_CasingThickness"], row["Input_DX_RefrigerantType"], row["Input_DX_ConnectionSizeInlet"], row["Input_DX_ConnectionSizeOutlet"], row["Input_DX_HeaderQuantity"], row["Input_HR_CoilDesign"], row["Input_HR_ConnectionSizeInlet"], row["Input_HR_ConnectionSizeOutlet"], row["Input_HR_HeaderQuantity"], row["Input_HR_SubCoolerConnIn"], row["Input_HR_SubCoolerConnOut"], row["Input_FH_DesignType"], row["Input_FH_ConnectionSize"], row["Input_FH_HeaderQuantity"], row["Input_FH_GPM_LLT"], row["Input_FC_DesignType"], row["Input_FC_ConnectionSize"], row["Input_FC_HeaderQuantity"], row["Input_FC_GPM_LLT"], row["Input_STEAM_TubeOrientation"], row["FCFreezing"], row["FHFreezing"], row["GCAirFlowRate"], row["GCAltitude"], row["GCEnteringDryBulb"], row["GCGIN"], row["GCGPSI"], row["GCGFLO"], row["GCNumberOfCircuits"], row["R_GOUT"]);
            }

        }

        private void ClearSelection()
        {
            _dtQuickCoil.Rows.Clear();
            cboCoilCoating.Items.Clear();
            LblCoatingPriceDetail.Text = Convert.ToDecimal(0m).ToString("N2") + @" $";
        }

        private void txtTag_TextChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboConnectionSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboCasingThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void cboHR_HeaderQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numHR_Altitude_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numHR_CondensingTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numHR_SuctionTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboHR_NumberOfCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numHR_HeatRecovery_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboHR_SubCoolerConnectionSizeIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboHR_SubCoolerConnectionSizeOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numHR_FaceTubes_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numHR_Circuit_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboFC_ConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

            Fill_FC_ConnectionSize();

            if (_openType == CoilOpenType.Manual)
            {
                Fill_ManualSelectionConnections();
            }
        }

        private void cboFC_ConnectionSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboFC_HeaderQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFC_Altitude_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixWB = Public.MixWetBulbTemperature(numFC_FreshCFM.Value, numFC_ReturnCFM.Value, numFC_FreshEDB.Value, numFC_ReturnEDB.Value, numFC_FreshEWB.Value, numFC_ReturnEWB.Value, Convert.ToInt32(numFC_Altitude.Value));
            lblFC_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void numFC_ELT_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFC_Concentration_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFC_USGPM_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFC_LeavingLiquidTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFC_MaxPressure_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboDX_RefrigerantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

            ValidateRefWithShape();

        }

        private void cboDX_ConnectionSizeInlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboDX_ConnectionSizeOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboDX_HeaderQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numDX_Altitude_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
            decimal mixWB = Public.MixWetBulbTemperature(numDX_FreshCFM.Value, numDX_ReturnCFM.Value, numDX_FreshEDB.Value, numDX_ReturnEDB.Value, numDX_FreshEWB.Value, numDX_ReturnEWB.Value, Convert.ToInt32(numDX_Altitude.Value));
            lblDX_MixingEWB.Text = (mixWB == -9999m ? "0" : mixWB.ToString(CultureInfo.InvariantCulture));
        }

        private void numDX_SuctionTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numDX_LiquidTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboDX_NumberOfCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboSTEAMTubeOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboSTEAM_ConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboSTEAM_SteamConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboSTEAM_CondensateConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numSTEAM_Altitude_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numSTEAM_SteamPressure_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboFH_ConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

            Fill_FH_ConnectionSize();

            if (_openType == CoilOpenType.Manual)
            {
                Fill_ManualSelectionConnections();
            }
        }

        private void cboFH_ConnectionSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void cboFH_HeaderQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFH_Altitude_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFH_ELT_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFH_Concentration_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFH_LeavingLiquidTemperature_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFH_USGPM_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numFH_MaxPressure_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void numRow_ValueChanged(object sender, EventArgs e)
        {
            ClearSelection();
            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }
            ValidateRowWithShape();
        }

        private void cboFinThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }
        }

        private void cboTubeThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

            if (_openType == CoilOpenType.Manual)
            {
                Fill_CoilCoatingManualSelection();
            }
        }

        private void cboTurbulator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelection();

        }

        private void ValidateManualModel()
        {
            ValidateManualModel(true);
        }

        private bool ValidateManualModel(bool fillOrSelectControlsSameTime)
        {
            //2010-12-23 : added the boolean and override the functione becasue on saving the coating was changing because
            //for exmaple i found the cbo tube material refill the coating on index change.
            //only pass FALSE for saving

            bool bolError = false;

            try
            {
                txtManualModelName.Text = txtManualModelName.Text.ToUpper();
                string strModelName = txtManualModelName.Text;

                if (strModelName.Length == 0 || strModelName.Split('-').Length != 5)
                {
                    //check model name good in general (size of string and dashes)
                    bolError = true;
                }
                else
                {
                    //split and separate in different strings the model
                    string[] strModelSplitted = strModelName.Split('-');

                    string strCoil = strModelSplitted[0];
                    string strTubes = strModelSplitted[1];
                    string strRows = strModelSplitted[2];
                    string strFPI = strModelSplitted[3];
                    string strLength = strModelSplitted[4];

                    //reformat the model name
                    txtManualModelName.Text = strCoil + @"-" + strTubes.PadLeft(2, '0') + @"-" + strRows.PadLeft(2, '0') + @"-" + strFPI.PadLeft(2, '0') + @"-" + strLength;

                    //first group must be 3 characters
                    if (strCoil.Length == 3)
                    {
                        //get first letter which indicate the coil type
                        string strCoilType = strCoil.Substring(0, 1);
                        int intCoilTypeIndex = -1;
                        bool isBooster = false;

                        //find the coil type in the combobox
                        switch (strCoilType)
                        {
                            case "D":
                                intCoilTypeIndex = cboCoilType.FindString("DX Cooling Coil");
                                break;
                            case "C":
                                intCoilTypeIndex = cboCoilType.FindString("Heat Reclaim / Condenser Coil");
                                break;
                            case "W":
                                intCoilTypeIndex = cboCoilType.FindString("Fluid Cooling Coil");
                                break;
                            case "B":
                                intCoilTypeIndex = cboCoilType.FindString("Fluid Cooling Coil");
                                isBooster = true;
                                break;
                            case "S":
                            case "N":
                                intCoilTypeIndex = cboCoilType.FindString("Steam Coil");
                                break;
                        }


                        if (intCoilTypeIndex != -1)
                        {//if the coil type exist

                            //this is here because in case the person entered a WEC
                            //first and then decided to change to BEC (Water to Water booster)
                            //the selectindexchange() of the coiltype doesnt get triggered
                            //then it's not trigering the refresh of controls
                            if (intCoilTypeIndex == cboCoilType.SelectedIndex)
                            {
                                RellocateAllControlsForManualSelectionMode();
                            }
                            else
                            {
                                //select the coil type
                                cboCoilType.SelectedIndex = intCoilTypeIndex;
                            }

                            //steam coil need to switch the steam type otherwise the pricing
                            //doesnt work properly
                            if (strCoilType == "S")
                            {
                                cboSTEAM_CoilType.SelectedIndex = cboSTEAM_CoilType.FindString("Standard Steam");
                            }
                            else if (strCoilType == "N")
                            {
                                cboSTEAM_CoilType.SelectedIndex = cboSTEAM_CoilType.FindString("Steam Distributing");
                            }

                            if (isBooster)
                            {
                                cboFC_DesignType.SelectedIndex = cboFC_DesignType.FindString("Booster");
                            }

                            Fill_ManualSelectionConnections();

                            //check second character
                            string strFinType = strCoil.Substring(1, 1);

                            //find FinTypeIndex
                            int intFinTypeIndex = cboFinType.FindString(strFinType.ToUpper() + " -");

                            if (intFinTypeIndex != -1)
                            {//if the fin type exist

                                //select the fin type
                                cboFinType.SelectedIndex = intFinTypeIndex;

                                //check last character
                                string strFinShape = strCoil.Substring(2, 1);

                                //find fin hsape index
                                int intFinShapeIndex = cboFinShape.FindString(strFinShape.ToUpper() + " -");
                                if (intFinTypeIndex != -1)
                                {//if the fin shape exist

                                    //select the fin sha[e
                                    cboFinShape.SelectedIndex = intFinShapeIndex;

                                    //check second set of characters
                                    int intTubes = Convert.ToInt32(strTubes);
                                    decimal finHeight = FinTypeFaceTube() * intTubes;

                                    int intHeightIndex = -1;

                                    //check if height is possible
                                    for (int iHeight = 0; iHeight < cboFinHeight.Items.Count; iHeight++)
                                    {
                                        var myHeightItem = (CBOITEM)cboFinHeight.Items[iHeight];
                                        if (Convert.ToDecimal(myHeightItem.Text) == finHeight)
                                        {
                                            intHeightIndex = iHeight;
                                        }
                                    }

                                    if (intFinTypeIndex != -1)
                                    {//if the fin height is possible
                                        cboFinHeight.SelectedIndex = intHeightIndex;

                                        //check third set of characters
                                        numRow.Value = Convert.ToDecimal(strRows);

                                        int intFPI = Convert.ToInt32(strFPI);

                                        int intFPIIndex = -1;

                                        //check if FPI is possible
                                        for (int iFPI = 0; iFPI < cboFPI.Items.Count; iFPI++)
                                        {
                                            var myFPIItem = (CBOITEM)cboFPI.Items[iFPI];
                                            if (Convert.ToInt32(myFPIItem.Text) == intFPI)
                                            {
                                                intFPIIndex = iFPI;
                                            }
                                        }

                                        if (intFPIIndex != -1)
                                        {
                                            cboFPI.SelectedIndex = intFPIIndex;

                                            //last set of charater
                                            numFinLength.Value = Convert.ToDecimal(strLength);

                                            if (fillOrSelectControlsSameTime)
                                            {
                                                Fill_TubeMaterial();
                                            }
                                        }
                                        else
                                        {
                                            bolError = true;
                                        }
                                    }
                                    else
                                    {
                                        bolError = true;
                                    }
                                }
                                else
                                {
                                    bolError = true;
                                }
                            }
                            else
                            {
                                bolError = true;
                            }
                        }
                        else
                        {
                            bolError = true;
                        }
                    }
                    else
                    {
                        bolError = true;
                    }
                }
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickCoil ValidateManualModel");
                bolError = true;
            }

            if (bolError)
            {
                Public.LanguageBox("Invalid model name", "Nom de modèle invalide");
            }

            if (txtManualModelName.Text[0].ToString(CultureInfo.InvariantCulture) == "B")
            {
                //cboFC_ConnectionType.SelectedIndex = cboFC_ConnectionType.FindString("SWEAT");
            }

            return !bolError;
        }

        private void btnOtherFluid_Click(object sender, EventArgs e)
        {

            if (_intIndex != -1)
            {
                DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Coil) + " AND ItemID = " + _intIndex, "");
                DataRow drSavedInfo = dtSavedInfo.NewRow();
                drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;
                _otherFluid = new FrmOtherFluid(drSavedInfo["FCFluidTypeName"].ToString(), Convert.ToDecimal(drSavedInfo["FCSpecificHeat"]), Convert.ToDecimal(drSavedInfo["FCDensity"]), Convert.ToDecimal(drSavedInfo["FCViscosity"]), Convert.ToDecimal(drSavedInfo["FCThermalConductivity"]), Convert.ToDecimal(drSavedInfo["FCFreezing"]));
                _otherFluid.ShowDialog();

                if (_otherFluid.GetSaved())
                {
                    _sqlToRun = "Update QuoteCoilData set FCFLuidTypeName = '" + _otherFluid.GetFluidName() + "', [FCSpecificHeat] = " + _otherFluid.GetSpecificHeat() + ", FCDensity =" + _otherFluid.GetDensity() + ",FCViscosity =" + _otherFluid.GetViscosity() + ", FCThermalConductivity=" + _otherFluid.GetThermalConductivity() + ", FCFreezing =" + _otherFluid.GetFreezingPoint() + " Where QuoteID = 'QUOTEPH' AND QuoteRevision = 'REVPH' AND itemID = " + _intIndex;
                    _freezingP = _otherFluid.GetFreezingPoint();
                    _quoteform.PushSQL(_sqlToRun);
                }
                _otherFluid.Close();
            }
            else
            {
                _otherFluid = new FrmOtherFluid();
                _otherFluid.ShowDialog();
                if (_otherFluid.GetSaved())
                {
                    _sqlToRun = "Update QuoteCoilData set FCFLuidTypeName = '" + _otherFluid.GetFluidName() + "', [FCSpecificHeat] = " + _otherFluid.GetSpecificHeat() + ", FCDensity =" + _otherFluid.GetDensity() + ",FCViscosity =" + _otherFluid.GetViscosity() + ", FCThermalConductivity=" + _otherFluid.GetThermalConductivity() + ", FCFreezing =" + _otherFluid.GetFreezingPoint() + " Where QuoteID = 'QUOTEPH' AND QuoteRevision = 'REVPH' )";
                    _freezingP = _otherFluid.GetFreezingPoint();
                }
                _otherFluid.Close();
            }


        }

        private void btnFHOtherFluid_Click(object sender, EventArgs e)
        {
            if (_intIndex != -1)
            {
                DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["QuickCoil"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Coil) + " AND ItemID = " + _intIndex, "");
                DataRow drSavedInfo = dtSavedInfo.NewRow();
                drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;
                _otherFluid = new FrmOtherFluid(drSavedInfo["FHFluidTypeName"].ToString(), Convert.ToDecimal(drSavedInfo["FHSpecificHeat"]), Convert.ToDecimal(drSavedInfo["FHDensity"]), Convert.ToDecimal(drSavedInfo["FHViscosity"]), Convert.ToDecimal(drSavedInfo["FHThermalConductivity"]), Convert.ToDecimal(drSavedInfo["FHFreezing"]));

                _otherFluid.ShowDialog();
                if (_otherFluid.GetSaved())
                {
                    _sqlToRun = "Update QuoteCoilData set FHFLuidTypeName = '" + _otherFluid.GetFluidName() + "', [FHSpecificHeat] = " + _otherFluid.GetSpecificHeat() + ", FHDensity =" + _otherFluid.GetDensity() + ",FHViscosity =" + _otherFluid.GetViscosity() + ", FHThermalConductivity=" + _otherFluid.GetThermalConductivity() + ", FHFreezing =" + _otherFluid.GetFreezingPoint() + " Where QuoteID = 'QUOTEPH' AND QuoteRevision = 'REVPH' AND itemID = " + _intIndex;
                    _freezingP = _otherFluid.GetFreezingPoint();
                    _quoteform.PushSQL(_sqlToRun);
                }
                _otherFluid.Close();
            }
            else
            {
                _otherFluid = new FrmOtherFluid();
                _otherFluid.ShowDialog();
                if (_otherFluid.GetSaved())
                {
                    _sqlToRun = "Update QuoteCoilData set FCFLuidTypeName = '" + _otherFluid.GetFluidName() + "', [FCSpecificHeat] = " + _otherFluid.GetSpecificHeat() + ", FCDensity =" + _otherFluid.GetDensity() + ",FCViscosity =" + _otherFluid.GetViscosity() + ", FCThermalConductivity=" + _otherFluid.GetThermalConductivity() + ", FCFreezing =" + _otherFluid.GetFreezingPoint() + " Where QuoteID = 'QUOTEPH' AND QuoteRevision = 'REVPH' AND itemID = " + _quoteform.GetNextID("QuickCoil");
                    _freezingP = _otherFluid.GetFreezingPoint();
                    _quoteform.PushSQL(_sqlToRun);
                }
                _otherFluid.Close();
            }
        }

        private List<string[]> BuildData()
        {
            var data = new List<string[]>();
            string strCoilType = CoilTypeParameter();
            switch (strCoilType)
            {
                case "DX":

                    data.Add(new [] { Public.LanguageString("Coil Model", "Modèle de serpentin"), _dtQuickCoil.Rows[0]["CoilModel"].ToString(), "" });
                    data.Add(new [] { Public.LanguageString("Total Heat", "Chaleur Totale"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Sensible Heat", "Chaleur sensible"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SensibleHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingDryBulb"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Leaving Wet Bulb", "Bulbe Humide à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingWetBulb"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_AirPressureDrop"]).ToString("N2"), "in-wg" });
                    data.Add(new [] { Public.LanguageString("Refrigerant Pressure Drop", "Perte pression de Réfrigérant"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]).ToString("N2"), "PSI" });
                    data.Add(new [] { Public.LanguageString("Coil Face Area", "Surface à la façade du serpentin"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CoilFaceArea"]).ToString("N2"), "Sq.Ft" });
                    data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]).ToString("N0"), "FPM" });
                    data.Add(new [] { Public.LanguageString("# of Circuits", "# de Circuits"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_NumberOfCircuits"]).ToString("N0"), "" });
                    data.Add(new [] { Public.LanguageString("Circuit Load", "Circuit de charge"), Convert.ToDecimal(Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CircuitLoad"]) * 12000).ToString("N2"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Weight", "Poids"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Weight"]).ToString("N2"), "lbs" });
                    break;
                case "HR":
                    if (cboHR_CoilDesign.Text == @"Condenser")
                    {
                        data.Add(new [] { Public.LanguageString("Coil Model", "Modèle de serpentin"), _dtQuickCoil.Rows[0]["CoilModel"].ToString(), "" });
                        data.Add(new [] { Public.LanguageString("Sensible Heat", "Chaleur sensible"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SensibleHeat"]).ToString("###,###,###"), "Btu/hr" });
                        data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingDryBulb"]).ToString("N1"), "°F" });
                        data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_AirPressureDrop"]).ToString("N2"), "in-wg" });
                        data.Add(new [] { Public.LanguageString("Refrigerant Pressure Drop", "Perte pression de Réfrigérant"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]).ToString("N2"), "PSI" });
                        data.Add(new [] { Public.LanguageString("Coil Face Area", "Surface à la façade du coil"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CoilFaceArea"]).ToString("N2"), "Sq.Ft" });
                        data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]).ToString("N0"), "FPM" });
                        data.Add(new [] { Public.LanguageString("# of Condenser Circuits", "# de Circuits condenseur"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_NumberOfCircuits"]).ToString("N0"), "" });
                        data.Add(new [] { Public.LanguageString("Weight", "Poids"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Weight"]).ToString("N2"), "lbs" });
                    }
                    else
                    {
                        data.Add(new [] { Public.LanguageString("Coil Model", "Modèle de serpentin"), _dtQuickCoil.Rows[0]["CoilModel"].ToString(), "" });
                        data.Add(new [] { Public.LanguageString("Total Heat Rejection (THR)", "Rejet de chaleur totale"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]).ToString("###,###,###"), "Btu/hr" });
                        data.Add(new [] { Public.LanguageString("Reclaim Capacity", "Capacité de récupération"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SensibleHeat"]).ToString("###,###,###"), "Btu/hr" });
                        data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingDryBulb"]).ToString("N1"), "°F" });
                        data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_AirPressureDrop"]).ToString("N2"), "in-wg" });
                        data.Add(new [] { Public.LanguageString("Refrigerant Pressure Drop", "Perte pression de Réfrigérant"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]).ToString("N2"), "PSI" });
                        data.Add(new [] { Public.LanguageString("Fins / Inch", "Ailettes / Pouce"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FPI"]).ToString("N0"), "" });
                        data.Add(new [] { Public.LanguageString("Coil Face Area", "Surface à la façade du coil"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CoilFaceArea"]).ToString("N2"), "Sq.Ft" });
                        data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]).ToString("N0"), "FPM" });
                        data.Add(new [] { Public.LanguageString("# of Circuits", "# de Circuits"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_NumberOfCircuits"]).ToString("N0"), "" });
                        data.Add(new [] { Public.LanguageString("Weight", "Poids"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Weight"]).ToString("N2"), "lbs" });
                    }
                    if (cboHR_SubCooler.Text == @"YES")
                    {
                        data.Add(new [] { Public.LanguageString("Sub Cooler Capacity", "Capacité de sous refroidisseur"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SubCoolerCapacity"]).ToString("N2"), "Btu/hr" });
                        data.Add(new [] { Public.LanguageString("Sub Cooler Refrigerant Leaving Temp.", "Temp. à la sortie du réfrigérant de sous refroidisseur"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SubCoolerRefrigerantLeavingTemperature"]).ToString("N2"), "°F" });
                        data.Add(new [] { Public.LanguageString("Sub Cooler Pressure Drop", "Perte pression de sous refroidisseur"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SubCoolerPressureDrop"]).ToString("N2"), "PSI" });
                    }
                    break;
                case "FH":
                    data.Add(new [] { Public.LanguageString("Coil Model", "Modèle de serpentin"), _dtQuickCoil.Rows[0]["CoilModel"].ToString(), "" });
                    data.Add(new [] { Public.LanguageString("Sensible Heat", "Chaleur sensible"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SensibleHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingDryBulb"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_AirPressureDrop"]).ToString("N2"), "in-wg" });
                    data.Add(new [] { Public.LanguageString("Coil Face Area", "Surface à la façade du coil"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CoilFaceArea"]).ToString("N2"), "Sq.Ft" });
                    data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]).ToString("N0"), "FPM" });
                    data.Add(new [] { Public.LanguageString("Leaving Liquid Temperature", "Temp. de liquide à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingLiquidTemperature"]).ToString("N2"), "°F" });
                    data.Add(new [] { Public.LanguageString("GPM", "GPM"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_GPM"]).ToString("N2"), "" });
                    data.Add(new [] { Public.LanguageString("Liquid Velocity", "Vélocité liquide"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_WaterVelocity"]).ToString("N2"), "ft/sec" });
                    data.Add(new [] { Public.LanguageString("Liquid Pressure Drop", "Chute de pression de liquide"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]).ToString("N2") + " PSI / " + Convert.ToDecimal(Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]) * Convert.ToDecimal(2.306666666666)).ToString("N2") + " FT(H2O)", "" });
                    data.Add(new [] { Public.LanguageString("# of Circuits", "# de Circuits"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_NumberOfCircuits"]).ToString("N0"), "" });
                    data.Add(new [] { Public.LanguageString("Weight", "Poids"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Weight"]).ToString("N2"), "lbs" });
                    break;
                case "FC":
                    data.Add(new [] { Public.LanguageString("Coil Model", "Modèle de serpentin"), _dtQuickCoil.Rows[0]["CoilModel"].ToString(), "" });
                    data.Add(new [] { Public.LanguageString("Total Heat", "Chaleur Totale"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Sensible Heat", "Chaleur sensible"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SensibleHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingDryBulb"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Leaving Wet Bulb", "Bulbe Humide à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingWetBulb"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_AirPressureDrop"]).ToString("N2"), "in-wg" });
                    data.Add(new [] { Public.LanguageString("Coil Face Area", "Surface à la façade du coil"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CoilFaceArea"]).ToString("N2"), "Sq.Ft" });
                    data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]).ToString("N0"), "FPM" });
                    data.Add(new [] { Public.LanguageString("Leaving Liquid Temperature", "Temp. de liquide à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingLiquidTemperature"]).ToString("N2"), "°F" });
                    data.Add(new [] { Public.LanguageString("GPM", "GPM"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_GPM"]).ToString("N2"), "" });
                    data.Add(new [] { Public.LanguageString("Liquid Velocity", "Vélocité liquide"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_WaterVelocity"]).ToString("N2"), "ft/sec" });
                    data.Add(new [] { Public.LanguageString("Liquid Pressure Drop", "Chute de pression de liquide"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]).ToString("N2") + " PSI / " + Convert.ToDecimal(Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]) * Convert.ToDecimal(2.306666666666)).ToString("N2") + " FT(H2O)", "" });
                    data.Add(new [] { Public.LanguageString("# of Circuits", "# de Circuits"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_NumberOfCircuits"]).ToString("N0"), "" });
                    data.Add(new [] { Public.LanguageString("Weight", "Poids"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Weight"]).ToString("N2"), "lbs" });
                    break;
                case "ST":
                    data.Add(new [] { Public.LanguageString("Coil Model", "Modèle de serpentin"), _dtQuickCoil.Rows[0]["CoilModel"].ToString(), "" });
                    data.Add(new [] { Public.LanguageString("Total Heat", "Chaleur Totale"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Sensible Heat", "Chaleur sensible"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SensibleHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingDryBulb"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_AirPressureDrop"]).ToString("N2"), "in-wg" });
                    data.Add(new [] { Public.LanguageString("Steam Temperature", "Température de vapeur"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SteamTemperature"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Steam Consumption", "Consumption de vapeur"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_SteamConsumption"]).ToString("N2"), "lbs/hr" });
                    data.Add(new [] { Public.LanguageString("Coil Face Area", "Surface à la façade du coil"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CoilFaceArea"]).ToString("N2"), "Sq.Ft" });
                    data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]).ToString("N0"), "FPM" });
                    data.Add(new [] { Public.LanguageString("Weight", "Poids"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Weight"]).ToString("N2"), "lbs" });
                    break;
                case "GC":

                    data.Add(new [] { Public.LanguageString("Coil Model", "Modèle de serpentin"), _dtQuickCoil.Rows[0]["CoilModel"].ToString(), "" });
                    data.Add(new [] { Public.LanguageString("Total Heat", "Chaleur Totale"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_TotalHeat"]).ToString("###,###,###"), "Btu/hr" });
                    data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_LeavingDryBulb"]).ToString("N1"), "°F" });
                    data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_AirPressureDrop"]).ToString("N2"), "in-wg" });
                    data.Add(new [] { Public.LanguageString("Coil Face Area", "Surface à la façade du coil"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_CoilFaceArea"]).ToString("N2"), "Sq.Ft" });
                    data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_FaceVelocity"]).ToString("N0"), "FPM" });
                    data.Add(new [] { Public.LanguageString("Gas Pressure Drop", "Chute de pression du gas"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]).ToString("N2") + " PSI / " + Convert.ToDecimal(Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_RefrigerantPressureDrop"]) * Convert.ToDecimal(2.306666666666)).ToString("N2") + " FT(H2O)", "" });
                    data.Add(new [] { Public.LanguageString("Leaving Gas Temperature", "Temp. du gas à la sortie"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["R_GOUT"]).ToString("N2"), "°F" });
                    data.Add(new [] { Public.LanguageString("Weight", "Poids"), Convert.ToDecimal(_dtQuickCoil.Rows[0]["Weight"]).ToString("N2"), "lbs" });

                    break;
            }
            return data;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">string [3] {"Title", "Formated Value", "Unit of measure"}</param>
        private void DisplayResults(List<string[]> data)
        {
            if (data.Count > 0)
            {
                ChangeControlState(false);
                //add the panel
                var pnl = new Panel();
                var pnlHeader = new Panel();
                var closeButton = new Button {Text = @"X"};
                closeButton.Click += closeButton_Click;
                closeButton.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                var resultLabel = new Label
                {
                    Text = Public.Language == "EN" ? "Results" : "Résultats",
                    Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                    Top = pnlHeader.Top + 4,
                    Left = pnlHeader.Left
                };
                //resultLabel.TextAlign = ContentAlignment.MiddleCenter;
                closeButton.BackColor = Color.DarkRed;
                closeButton.ForeColor = Color.White;
                closeButton.Size = new Size(41, 28);
                closeButton.TextAlign = ContentAlignment.MiddleCenter;
                closeButton.FlatStyle = FlatStyle.Flat;
                pnlHeader.BackColor = SystemColors.ActiveCaption;
                pnl.Width = Width - 5;
                //pnl.Height = cboCoilCoating.Top - 5;
                pnl.Height = cboCoilCoating.Top - 125;
                pnl.Tag = "RESULTPANEL";
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnlHeader.Width = pnl.Width;
                pnlHeader.Height = closeButton.Height + 6;
                pnlHeader.Controls.Add(resultLabel);
                pnlHeader.Controls.Add(closeButton);
                closeButton.Top = pnlHeader.Top + 3;
                closeButton.Left = pnlHeader.Width - 8 - closeButton.Width;

                Controls.Add(pnl);
                //pnl.Top = 5;
                pnl.Top = 120;
                pnl.Left = 5;
                pnl.BringToFront();


                //create the list that will contain the data
                var glResult = new GlacialComponents.Controls.GlacialList
                {
                    HeaderVisible = false,
                    AlternatingColors = true,
                    AlternateBackground = Color.LightGray,
                    Width = pnl.Width,
                    Height = pnl.Height - pnlHeader.Height,
                    Selectable = false
                };
                //glResult.Height = pnl.Height - pnlHeader.Height - 5;

                var colTitle = new GlacialComponents.Controls.GLColumn {Width = 300};

                var colValue = new GlacialComponents.Controls.GLColumn
                {
                    Width = 200,
                    TextAlignment = ContentAlignment.MiddleCenter
                };

                var colUnit = new GlacialComponents.Controls.GLColumn
                {
                    Width = 80,
                    TextAlignment = ContentAlignment.MiddleCenter
                };

                glResult.Columns.Add(colTitle);
                glResult.Columns.Add(colValue);
                glResult.Columns.Add(colUnit);

                foreach (string[] strData in data)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(glResult);

                    myItem.SubItems[0].Text = strData[0];
                    myItem.SubItems[1].Text = strData[1];
                    myItem.SubItems[2].Text = strData[2];

                    glResult.Items.Add(myItem);
                }

                glResult.Refresh();
                pnl.Controls.Add(pnlHeader);
                pnl.Controls.Add(glResult);
                glResult.Left = pnlHeader.Left;
                glResult.Top = pnlHeader.Bottom;
                pnlHeader.Left = 0;
                pnlHeader.Top = 0;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (IsNormalSelectionAndPerformanceOpened())
            {
                //close performance
                DeletePerformanceControls();
                cmdCancel.Visible = true;
                ChangeControlState(true);
            }
        }

        private void ChangeControlState(bool state)
        {
            cboCoilType.Enabled = state;
            txtTag.Enabled = state;
            numQuantity.Enabled = state;
            cboLocation.Enabled = state;
            cboConstructionType.Enabled = state;
            cboConnectionSide.Enabled = state;
            cboCasingMaterial.Enabled = state;
            cboCasingThickness.Enabled = state;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuickCoil_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void lblConnectionSide_Click(object sender, EventArgs e)
        {

        }

        //2012-05-22 : #2686 : they want to autoselect the casing material and gage
        //depending on coil face area
        private void AutoSelectCasingMaterialAndThickness()
        {
            try
            {
                if(cboFinHeight.Items.Count != 0)
                {
                    decimal decHeight = FinHeightParameter();
                    decimal decLength = numFinLength.Value;

                    //If < 10 sq.ft. = 0.052 Galv. Standard
                    //If > or = 10 sq.ft. = 0.064 Galv. Standard 

                    if ((decHeight * decLength) / 144m < 10m)
                    {
                        if (cboCasingMaterial.FindString("Galvanized Steel") >= 0)
                        {

                            //UPDATE : 2013-04-16  By Patrice V.  Used to update casing material no matter what
                            //now it only changed the casing material if the casing material is not already selected (which
                            //won't happen since Galvanized Steel is default material, but in case default changes, will keep)

                            if (cboCasingMaterial.SelectedIndex == -1)
                                cboCasingMaterial.SelectedIndex = cboCasingMaterial.FindString("Galvanized Steel");

                            if (cboCasingThickness.FindString("0.052") >= 0)
                            {
                                cboCasingThickness.SelectedIndex = cboCasingThickness.FindString("0.052");
                            }
                        }
                    }
                    else
                    {
                        if (cboCasingMaterial.FindString("Galvanized Steel") >= 0)
                        {
                            //UPDATE : 2013-04-16  By Patrice V.  Used to update casing material no matter what
                            //now it only changed the casing material if the casing material is not already selected (which
                            //won't happen since Galvanized Steel is default material, but in case default changes, will keep)

                            if (cboCasingMaterial.SelectedIndex == -1)
                                cboCasingMaterial.SelectedIndex = cboCasingMaterial.FindString("Galvanized Steel");

                            if (cboCasingThickness.FindString("0.064") >= 0)
                            {
                                cboCasingThickness.SelectedIndex = cboCasingThickness.FindString("0.064");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickCoil AutoSelectCasingMaterialAndThickness");
            }
        }
        private void ValidateRefWithShape()
        {
            if (cboCoilType.SelectedIndex != -1 && cboFinType.SelectedIndex != -1)
            {
                string coilTypeParameter = CoilTypeParameter();
                if (coilTypeParameter == "HR" || coilTypeParameter == "DX")
                {
                    if (cboHR_RefrigerantType.SelectedIndex != -1)
                    {
                        if (coilTypeParameter == "HR")
                        {
                            if (FinTypeParameter() == "G" && cboHR_RefrigerantType.Text.ToUpper() == "R-410A")
                            {
                                Public.LanguageBox("Refplus can't offer a Heat Reclaim or DX coil with Type G and Refrigerant R-410A, sorry.  To ensure there is no mistake, the system changed your coil type to blank, please correct this.", "Refplus ne peut offrir un serpentin (heat reclaim ou DX) de type G avec le réfrigérant R-410A.  Pour éviter les erreurs, le système vient de réinitialiser le type de serpentin à vide.  Veuillez corriger");
                                cboFinType.SelectedIndex = -1;
                            }
                        }
                        if (coilTypeParameter == "DX")
                        {
                            if (FinTypeParameter() == "G" && cboDX_RefrigerantType.Text.ToUpper() == "R-410A")
                            {
                                Public.LanguageBox("Refplus can't offer a Heat Reclaim or DX coil with Type G and Refrigerant R-410A, sorry.  To ensure there is no mistake, the system changed your coil type to blank, please correct this.", "Refplus ne peut offrir un serpentin (heat reclaim ou DX) de type G avec le réfrigérant R-410A.  Pour éviter les erreurs, le système vient de réinitialiser le type de serpentin à vide.  Veuillez corriger");
                                cboFinType.SelectedIndex = -1;
                            }
                        }
                    }
                }
            }
        }








    }
}