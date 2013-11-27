using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RefplusWebtools.DataManager.Costing;
using RefplusWebtools.DataManager.Generic;
using RefplusWebtools.Report.SalesReport;

namespace RefplusWebtools
{
    public partial class FrmMain : Form
    {
        private readonly string[] _strTableList = { "Language" };
        private bool _standardClosing = true;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //change mdi parent background
            ChangeMDIParentBackground();
            
            //update the version.xml
            Public.UpdateXMLversion();

            //2010-12-17 : Sylvain said to domenico to remove the label version
            //so we put in title instead
            //show version on title
            Text += @" v." + Public.ApplicationVersion;

            if (CheckIfServerHasNewVersion())
            {
                Public.StartUpdater();
            }
            
            try
            {
                //maximize the window
                WindowState = FormWindowState.Maximized;

                //load tables  
                Query.LoadTables(_strTableList);

                //change language for test purpose
                string preferenceLanguage = Reg.Get(Reg.Key.Language);

                Public.SetLanguage((preferenceLanguage != "" ? preferenceLanguage : Tools.LanguageType.English));

                SetLanguageCheck();

                //refresh all forms
                Public.RefreshMdiFormLanguage(this);

                //clear and recreate temp folder
                Public.ClearAndRecreateTempFolder();
                DataTable custom = Query.Select("Select * from QuoteCustomUnitData where QuoteID = 971 and QuoteRevision = 0 and ItemId = 1");
                custom.TableName = "CustomUnitTable";
                QuickCustomUnit.CustomUnitReport.GenerateDataReport(custom, false, 971, "A");

                var loginScreen = new FrmLogin(this);
                loginScreen.ShowDialog();
                if(UserInformation.UserName == "")
                {
                    Close();
                }
                
                if (UserInformation.UserName == "pvoutsinas")
                {
                    cmdTest.Visible = true;
                }
                if (UserInformation.UserName == "jblanchard" || UserInformation.UserName == "mcardinal" || UserInformation.UserName == "pvoutsinas")
                {
                    sReportsToolStripMenuItem.Visible = true;
                }
                mnuAdmin.Visible = UserInformation.ExactRequiredPermission(99);

                cmdReportBug.Visible = UserInformation.Userlevel > 89;

                if (UserInformation.AccessDataManager)
                {
                    mnuDataManager.Enabled = true;
                }

                if (UserInformation.AccessBalancingModule)
                {
                    mnuBalancing.Enabled = true;
                }
                sKitsToolStripMenuItem.Visible = (UserInformation.Name == "SIMON TRÉPANIER" || UserInformation.Name == "Patrice Voutsinas");

                //adding special admin text to the title bar to know the server
                if (UserInformation.UserName == "admin" || UserInformation.UserName == "pvoutsinas")
                {
                    Text += @" - Webservice (" + Query.GetWebServiceUrl() + @")";
                }
                LaunchPublicity();
                var lead = new FrmLeadTime {MdiParent = this};
                lead.Show();
                
                

                //put the main form visible
                ShowInTaskbar = true;
                Opacity = 1d;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmMain frmMain_Load");
                MessageBox.Show(@"An error occured while checking for connection to the update server" + @"/n/n/n" + ex);
                Environment.Exit(0);
            }
        }

        private void LaunchPublicity()
        {
            if (Screen.PrimaryScreen.Bounds.Width >= 1024 && Screen.PrimaryScreen.Bounds.Height >= 768)
            {
                DataTable dtPublicityCount = Query.Select("SELECT * FROM PublicityRotation WHERE Rotation = 1");

                if (dtPublicityCount.Rows.Count > 0)
                {
                    var publicity = new FrmPublicity(dtPublicityCount);
                    publicity.ShowDialog();
                }
            }
        }

        private void SetLanguageCheck()
        {

            switch (Public.Language)
            {
                case Tools.LanguageType.French:
                    mnuFrancais.Checked = true;
                    mnuEnglish.Checked = false;
                    break;
                case Tools.LanguageType.English:
                    mnuFrancais.Checked = false;
                    mnuEnglish.Checked = true;
                    break;
            }
        }

        //check the server status

        //this function resize the menu when clicked
        private void MenuResizing(object sender, EventArgs e)
        {
            //this will state if it has to show or hid the controls
            //and since the toolstrip is on Autosize, if we
            //hide item it resize automaticly
            bool bolVisibility = false;

            //i use the tag of the label that is bind to this
            //function o nthe click to know if i have
            //to show ir hide object
            if (((ToolStripLabel)sender).Tag.ToString() == "Open")
            {
                ((ToolStripLabel)sender).Tag = "Close";
            }
            else
            {
                ((ToolStripLabel)sender).Tag = "Open";
                bolVisibility = true;
            }

            //this one store the control name that you click on for later use
            string strHeaderControl = ((ToolStripLabel)sender).Name;

            //loop throught each object of the contain that the current control
            //is part off, for each of them, set them either visible or invisible
            //(see bolVisibility comment for details)
            for (int intItems = 0; intItems < ((ToolStripLabel)sender).Owner.Items.Count; intItems++)
            {
                //we do not want to hide the control is it's the control that
                //has been clicked which should be the title label, we want him to
                //always be visible so the user can reclick it and then perform
                //the inverse (eitehr show or hide, see bolVisibility comment for details)
                if (((ToolStripLabel)sender).Owner.Items[intItems].Name != strHeaderControl)
                {
                    ((ToolStripLabel)sender).Owner.Items[intItems].Visible = bolVisibility;
                }
            }
        }

        //change mdi parent background to background color
        //because in design time you cannot change background of a MDI
        private void ChangeMDIParentBackground()
        {
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctlMDIControl in Controls)
            {
                if(ctlMDIControl is MdiClient)
                {
                    // Set the BackColor of the MdiClient control.
                    ctlMDIControl.BackColor = BackColor;
                }
            }
        }

        private void mnuEnglish_Click(object sender, EventArgs e)
        {
            if (mnuEnglish.Checked)
            {//if after clicked the menu is check
                //uncheck other language
                mnuFrancais.Checked = false;
                //change the language of all forms
                ChangeLanguage(Tools.LanguageType.English);
                Reg.Set(Reg.Key.Language, Tools.LanguageType.English);
            }
            else
            {//if the menu is uncheck
                //recheck it, you have to have 1 selected
                //recheking the menu manke it work like Radio button
                //always 1 is selected
                mnuEnglish.Checked = true;
            }
        }

        private void mnuFrancais_Click(object sender, EventArgs e)
        {
            if (mnuFrancais.Checked)
            {//if after clicked the menu is check
                //uncheck other language
                mnuEnglish.Checked = false;
                //change the language of all forms
                ChangeLanguage(Tools.LanguageType.French);
                Reg.Set(Reg.Key.Language, Tools.LanguageType.French);
            }
            else
            {//if the menu is uncheck
                //recheck it, you have to have 1 selected
                //recheking the menu manke it work like Radio button
                //always 1 is selected
                mnuFrancais.Checked = true;
            }
        }

        public void ChangeLanguage(string strLanguage)
        {
            //change the language variable
            Public.SetLanguage(strLanguage);

            //refresh the mdi parent and the shild with the new language
            Public.RefreshMdiFormLanguage(this);
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            //this is to make sure the background picture refresh correctly
            Refresh();
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            //layout all form cascade
            LayoutMdi(MdiLayout.Cascade);
        }

        private void cmdConversionTools_Click(object sender, EventArgs e)
        {
            //open the converter
            System.Diagnostics.Process.Start("Convert.exe");
        }

        private void cmdContactManager_Click(object sender, EventArgs e)
        {
            //open Contact manager
            var contactManager = new Contact.FrmContactManager {MdiParent = this};
            contactManager.Show();
        }

        private void cmdQuickCoil_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickCoil)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Coil Selection", "Préparation de la sélection des Serpentins"));
                //open quick coil
                var coil = new QuickCoil.FrmQuickCoil {MdiParent = this};
                coil.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdQuickEvaporator_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickEvaporator)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Evaporator Selection", "Préparation de la sélection d'Évaporateur"));
                //open quick evaporator
                var evaporator = new QuickEvaporator.FrmQuickEvaporator {MdiParent = this};
                evaporator.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdQuickCondenser_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickCondenser)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Condenser Selection", "Préparation de la sélection de Condenseur"));
                //open quick ocndenser
                var condenser = new QuickCondenser.FrmQuickCondenser {MdiParent = this};
                condenser.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdQuickCondensingUnit_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickCondensingUnit)
            {
                Public.OpenBitzerMessage();
                ThreadProcess.Start(Public.LanguageString("Preparing Condensing Unit Selection", "Préparation de la sélection du groupe compresseur-condenseur"));
                //open quick condensing unit
                var condensingunit = new QuickCondensingUnit.FrmQuickCondensingUnit {MdiParent = this};
                condensingunit.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdQuickFluidCooler_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickFluidCooler)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Fluid Cooler Selection", "Préparation de la sélection de Refroidisseur Liquide"));
                //open quick fluid cooler
                var fluidcooler = new QuickFluidCooler.FrmQuickFluidCooler {MdiParent = this};
                fluidcooler.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdQuickHeatPipe_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickHeatPipe)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Heat Pipe Selection", "Préparation de la sélection de Caloduc"));
                //open quick Heat Pipe
                var heatpipe = new QuickHeatPipe.FrmQuickHeatPipe {MdiParent = this};
                heatpipe.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdNewQuote_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuote)
            {
                
                //Quotes
                var quoteform = new Quotes.FrmQuotes(0, 0, true) {MdiParent = this};
                quoteform.Show();
               
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        public void LoadQuote(int intQuoteID, int revision)
        {
            if (UserInformation.AccessQuote)
            {
                //Quotes
                var quoteform = new Quotes.FrmQuotes(intQuoteID, revision, false) {MdiParent = this};
                quoteform.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        public void OpenAdvancedSearch()
        {
            var advancedSearchform = new AdvancedSearch.FrmAdvancedSearch(this) {MdiParent = this};
            advancedSearchform.Show();
        }

        private void cmdOpenQuote_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuote)
            {
                //open Quotes
                var openQuoteform = new Quotes.FrmOpenQuote(this) {MdiParent = this};
                openQuoteform.Show();
              
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void cmdQuickCustomUnit_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickCustomUnit)
            {
                //open quick Custom Unit
                ThreadProcess.Start(Public.LanguageString("Preparing Custom Unit Selection", "Préparation de la sélection de l'Unité Personnalisée"));
                var customUnit = new QuickCustomUnit.FrmQuickCustomUnit {MdiParent = this};
                customUnit.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        //change the color of the menus
        public void ChangeToSiteColor(Color siteColor)
        {
            mnufrmMain.BackColor = siteColor;
            mnuActions.BackColor = siteColor;
            mnuQuotes.BackColor = siteColor;
            mnuQuickSelection.BackColor = siteColor;
            mnuUnitHistory.BackColor = siteColor;
            mnuTools.BackColor = siteColor;
            toolStripMainMenu.ContentPanel.BackColor = siteColor;
        }

        private void mnuFanModel_Click(object sender, EventArgs e)
        {
            var fanModel = new FrmFanModel {MdiParent = this};
            fanModel.Show();
        }

        private void mnuFanGuard_Click(object sender, EventArgs e)
        {
            var fanGuard = new FrmFanGuard {MdiParent = this};
            fanGuard.Show();
        }

        private void mnuMotorMount_Click(object sender, EventArgs e)
        {
            var motorMount = new FrmMotorMount {MdiParent = this};
            motorMount.Show();
        }

        private void mnuMotorModel_Click(object sender, EventArgs e)
        {
            var motorModel = new FrmMotorModel {MdiParent = this};
            motorModel.Show();
        }

        private void mnuCompressorData_Click(object sender, EventArgs e)
        {
            var compressor = new FrmCompressor {MdiParent = this};
            compressor.Show();
        }

        private void cmdQuickGravityCoil_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickGravityCoil)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Gravity Coil Selection", "Préparation de la sélection du Serpentin Gravité"));
                var gravityCoil = new QuickGravityCoil.FrmGravityCoil {MdiParent = this};
                gravityCoil.Show();
            }
        }

        private void TimerFingerPrint_Tick(object sender, EventArgs e)
        {
            if (!FingerPrintHandler.RecurrentCheckForActivity())
            {
                //that will bypass the code that set the logout process.
                _standardClosing = false;

                Public.LanguageBox("You are being kicked from the software for sharing your username and password with another person.","Vous êtes sur le point de vous faire déconnecter pour avoir partagé votre nom d'utilisateur et mot de passe avec un autre usager.");

                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(
                Public.LanguageString("You are about to leave the application.  Are you sure you want to close?",
                                      "Vous êtes sur le point de quitter l'application.  Êtes-vous certain de vouloir fermer Webtools?"),
                Public.LanguageString("Closing", "Fermeture"), MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (_standardClosing)
                {
                    FingerPrintHandler.LogoutProcess();
                }   
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void mnuBalanceCondenserCoilAndCompressors_Click(object sender, EventArgs e)
        {
            var compressorCondenserCoilBalancing = new Balancing.FrmCompressorCondenserCoilBalancing {MdiParent = this};
            compressorCondenserCoilBalancing.Show();
        }

        private void mnuManageCondensingUnit_Click(object sender, EventArgs e)
        {
        
        }

        private void mnuCondensingUnitModels_Click(object sender, EventArgs e)
        {
            var condensingUnit = new DataManager.CondensingUnit.FrmCondensingUnitModel {MdiParent = this};
            condensingUnit.Show();
        }

        private void mnuCondensingUnitReceivers_Click(object sender, EventArgs e)
        {
            var receiver = new DataManager.CondensingUnit.FrmCondensingUnitReceiver {MdiParent = this};
            receiver.Show();
        }

        private void mnuCondensingUnitWaterCooledCondenser_Click(object sender, EventArgs e)
        {
            var waterCooled = new DataManager.CondensingUnit.FrmCondensingUnitWaterCooledCondenser {MdiParent = this};
            waterCooled.Show();
        }

        private void mnuCondensingUnitOptions_Click(object sender, EventArgs e)
        {
            var options = new DataManager.CondensingUnit.FrmCondensingUnitOptions {MdiParent = this};
            options.Show();
        }

        private void mnuEvaporatorModels_Click(object sender, EventArgs e)
        {
            var evaporatorModel = new DataManager.Evaporator.FrmEvaporatorModel {MdiParent = this};
            evaporatorModel.Show();
        }


        private void mnuCondenserModels_Click(object sender, EventArgs e)
        {
            var condenserModel = new DataManager.Condenser.FrmCondenserManager {MdiParent = this};
            condenserModel.Show();
        }

        private void mnuCondenserParts_Click(object sender, EventArgs e)
        {
            var condenserParts = new DataManager.Condenser.FrmCondenserParts {MdiParent = this};
            condenserParts.Show();
        }

        private void mnuManageFinMaterialDensityAndPrice_Click(object sender, EventArgs e)
        {
            var finMat = new DataManager.Pricing.FrmFinMaterialDensityPrices {MdiParent = this};
            finMat.Show();
        }

        private void mnuManageTubeMaterialDensityAndPrice_Click(object sender, EventArgs e)
        {
            var tubeMat = new DataManager.Pricing.FrmTubeMaterialDensityPrices {MdiParent = this};
            tubeMat.Show();
        }

        private void mnuManageCasingMaterialDensityAndPrice_Click(object sender, EventArgs e)
        {
            var casingMat = new DataManager.Pricing.FrmCasingMaterialDensityPrices {MdiParent = this};
            casingMat.Show();
        }

        private void mnuManageCoilBlygold_Click(object sender, EventArgs e)
        {
            var coilBlyGold = new DataManager.Pricing.FrmPricingCoilBlygold {MdiParent = this};
            coilBlyGold.Show();
        }

        private void mnuManagePricingCoilHeader_Click(object sender, EventArgs e)
        {
            var coilHeader = new DataManager.Pricing.FrmPricingCoilHeader {MdiParent = this};
            coilHeader.Show();
        }

        private void mnuManagePricingCoilSettings_Click(object sender, EventArgs e)
        {
            var coilSettings = new DataManager.Pricing.FrmPricingCoilSettings {MdiParent = this};
            coilSettings.Show();
        }

        private void mnuManagePricingElectroFinRate_Click(object sender, EventArgs e)
        {
            var electroFin = new DataManager.Pricing.FrmPricingElectroFinRate {MdiParent = this};
            electroFin.Show();
        }

        private void mnuManageMadocRate_Click(object sender, EventArgs e)
        {
            var madocRate = new DataManager.Pricing.FrmPricingMadocRate {MdiParent = this};
            madocRate.Show();
        }

        private void mnuManagePricingMiscSettings_Click(object sender, EventArgs e)
        {
            var miscSettings = new DataManager.Pricing.FrmPricingMiscSettings {MdiParent = this};
            miscSettings.Show();
        }

        private void mnuManagePricingReturnBendCost_Click(object sender, EventArgs e)
        {
            var returnBendCost = new DataManager.Pricing.FrmPricingReturnBendCost {MdiParent = this};
            returnBendCost.Show();
        }

        private void mnuManageElectrofinAdjustement_Click(object sender, EventArgs e)
        {
            var electroFin = new DataManager.Pricing.FrmElectroFinAdjustement {MdiParent = this};
            electroFin.Show();
        }
        
        private void mnuDefrostHeater_Click(object sender, EventArgs e)
        {
            var defrostHeaterManager = new FrmDefrostHeater {MdiParent = this};
            defrostHeaterManager.Show();
        }

        private void mnuManageOEMCoilHeaderInformation_Click(object sender, EventArgs e)
        {
            var oemHeaderInfo = new DataManager.OEMCoil.FrmOEMCoilHeaderInformation {MdiParent = this};
            oemHeaderInfo.Show();
        }

        private void mnuManageHeresiteSafety_Click(object sender, EventArgs e)
        {
            var heresite = new DataManager.Pricing.FrmHeresiteSafety {MdiParent = this};
            heresite.Show();
        }

        private void mnuManageOEMCoilMaterialInformation_Click(object sender, EventArgs e)
        {
            var oemMatInfo = new DataManager.OEMCoil.FrmOEMCoilMaterialInformation {MdiParent = this};
            oemMatInfo.Show();
        }

        private void cmdChangePassword_Click(object sender, EventArgs e)
        {
            var changePass = new FrmChangePassword();
            changePass.ShowDialog();
        }

        private void mnuManagePricingEvaporatorModel_Click(object sender, EventArgs e)
        {
            var evapPrice = new DataManager.Pricing.FrmEvaporatorPricingIncrease();
            evapPrice.ShowDialog();
        }

        private void mnuManagePricingCondenserModel_Click(object sender, EventArgs e)
        {
            var condPrice = new DataManager.Pricing.FrmCondenserPricingIncrease();
            condPrice.ShowDialog();
        }

        private void mnuManagePricingFluidCoolerModel_Click(object sender, EventArgs e)
        {
            var fluidPrice = new DataManager.Pricing.FrmFluidCoolerPricingIncrease();
            fluidPrice.ShowDialog();
        }

        private void mnuManagePricingGravityCoilModel_Click(object sender, EventArgs e)
        {
            var gravityPrice = new DataManager.Pricing.FrmGravityCoilPricingIncrease();
            gravityPrice.ShowDialog();
        }

        private void mnuManagePricingCondensingUnitModel_Click(object sender, EventArgs e)
        {
            var condensingUnitPrice = new DataManager.Pricing.FrmCondensingUnitPricingIncrease();
            condensingUnitPrice.ShowDialog();
        }

        private void sHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

       /* private void mnuCondensingUnitPartUpdaterMotor_Click(object sender, EventArgs e)
        {
            DataManager.CondensingUnit.frmCondensingUnitMotorUpdater motorupdater = new DataManager.CondensingUnit.frmCondensingUnitMotorUpdater();
            motorupdater.MdiParent = this;
            motorupdater.Show();
        }

        private void mnuCondensingUnitPartUpdaterMotorMount_Click(object sender, EventArgs e)
        {
            DataManager.CondensingUnit.frmCondensingUnitMotorMountUpdater motormountupdater = new DataManager.CondensingUnit.frmCondensingUnitMotorMountUpdater();
            motormountupdater.MdiParent = this;
            motormountupdater.Show();
        }

        private void mnuCondensingUnitPartUpdaterFan_Click(object sender, EventArgs e)
        {
            DataManager.CondensingUnit.frmCondensingUnitFanUpdater fanUpdater = new DataManager.CondensingUnit.frmCondensingUnitFanUpdater();
            fanUpdater.MdiParent = this;
            fanUpdater.Show();
        }

        private void mnuCondensingUnitPartUpdaterFanGuard_Click(object sender, EventArgs e)
        {
            DataManager.CondensingUnit.frmCondensingUnitFanGuardUpdater fanGuardUpdater = new DataManager.CondensingUnit.frmCondensingUnitFanGuardUpdater();
            fanGuardUpdater.MdiParent = this;
            fanGuardUpdater.Show();
        }*/

        private void mnuEvaporatorOptions_Click(object sender, EventArgs e)
        {
            var evapOptions = new DataManager.Evaporator.FrmEvaporatorOptions {MdiParent = this};
            evapOptions.Show();
        }

        private void mnuManagePricingCondensingUnitOption_Click(object sender, EventArgs e)
        {
            var cuOptionPricing = new DataManager.Pricing.FrmCondensingUnitOptionsPriceIncrease();
            cuOptionPricing.ShowDialog();
        }

        private void mnuManagePricingEvaporatorOption_Click(object sender, EventArgs e)
        {
            var evapOptionPricing = new DataManager.Pricing.FrmEvaporatorOptionsPricingIncrease();
            evapOptionPricing.ShowDialog();
        }

        private void mnuCondensingUnitDrawingManager_Click(object sender, EventArgs e)
        {
            var cuDrawings = new DataManager.CondensingUnit.FrmDrawingManagerCondesingUnit();
            cuDrawings.ShowDialog();
        }

        private void mnuDrawingFileManager_Click(object sender, EventArgs e)
        {
            var dfm = new FrmDrawingFileManager {MdiParent = this};
            dfm.Show();
        }

        private void mnuPublicityManager_Click(object sender, EventArgs e)
        {
            var pm = new FrmPublicityManager();
            pm.ShowDialog();
        }

        private void mnuManageFluidCoolerModels_Click(object sender, EventArgs e)
        {
            var fcm = new DataManager.FluidCooler.FrmFluidCoolerManager();
            fcm.ShowDialog();
        }

        private void mnuDataManagerControlPanelAndOptionPrice_Click(object sender, EventArgs e)
        {
            var control = new DataManager.Pricing.FrmControlPanelPanelAndOptionPrices();
            control.ShowDialog();
        }

        private void mnuManageEvaporatorBlygoldPricing_Click(object sender, EventArgs e)
        {
            var evapBlygold = new DataManager.Pricing.FrmEvaporatorBlygoldPricingIncrease();
            evapBlygold.ShowDialog();
        }

        private void mnuManageGravityCoilBlygoldPricing_Click(object sender, EventArgs e)
        {
            var gravityBlygold = new DataManager.Pricing.FrmGravityCoilBlygoldPricingIncrease();
            gravityBlygold.ShowDialog();
        }

        private void mnuEvaporatorDrawingManager_Click(object sender, EventArgs e)
        {
            //DataManager.Generic.frmGenericDrawingManager drawingsmanager = new DataManager.Generic.frmGenericDrawingManager(DrawingManager.DrawingCategory.Evaporator);
            //drawingsmanager.ShowDialog();
            var drawingsmanager = new DataManager.Evaporator.FrmEvaporatorDrawingManager();
            drawingsmanager.ShowDialog();
        }

        private void mnuGravityCoilDrawingManager_Click(object sender, EventArgs e)
        {
            var drawingsmanager = new FrmGenericDrawingManager(DrawingManager.DrawingCategory.GravityCoil);
            drawingsmanager.ShowDialog();
        }

        private void mnuPanelAndLogicManager_Click(object sender, EventArgs e)
        {
            var panelmanager = new DataManager.ControlPanel.FrmControlPanelPanelManager();
            panelmanager.ShowDialog();
        }

        private void mnuOptionAndLogicManager_Click(object sender, EventArgs e)
        {
            var optionmanager = new DataManager.ControlPanel.FrmControlPanelOptionManager();
            optionmanager.ShowDialog();
        }

        private void mnuCustomReportLogo_Click(object sender, EventArgs e)
        {
            var crl = new FrmCustomReportLogo();
            crl.ShowDialog();
        }

        private void mnuDataManagerControlPanelAndOptionPricingIncrease_Click(object sender, EventArgs e)
        {
            var controlPanelPriceIncrease = new DataManager.Pricing.FrmControlPanelAndOptionPriceIncrease();
            controlPanelPriceIncrease.ShowDialog();
        }

        private void mnuCondenserListPriceAndBlygoldReport_Click(object sender, EventArgs e)
        {
            var cpr = new DataManager.Condenser.FrmCondenserPricingReport();
            cpr.ShowDialog();
        }

        private void mnuFluidCoolerListPriceAndBlygoldReport_Click(object sender, EventArgs e)
        {
            var fpr = new DataManager.FluidCooler.FrmFluidCoolerPricingReport();
            fpr.ShowDialog();
        }

        private void cmdQuickWaterEvaporator_Click(object sender, EventArgs e)
        {
            if (UserInformation.AccessQuickWaterEvaporator)
            {
                ThreadProcess.Start(Public.LanguageString("Preparing Water Evaporator Selection", "Préparation de la sélection d'Évaporateur à eau"));
                //open quick water evaporator
                var evaporator = new QuickWaterEvaporator.FrmQuickWaterEvaporator {MdiParent = this};
                evaporator.Show();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void sKitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionPack = new FrmOptionPack {MdiParent = this};
            optionPack.Show();
        }


        private void cmdReportBug_Click(object sender, EventArgs e)
        {
            var bugReport = new FrmBugReport();
            bugReport.ShowDialog();
        }
        private bool CheckIfServerHasNewVersion()
        {
            int clientVersionToNumber = 0;

            try
            {
                var dsLocalVersion = new DataSet();
                dsLocalVersion.ReadXml("Version.xml");
                string clientVersion = dsLocalVersion.Tables[0].Rows[0][0].ToString();
                //client version contain the local client version.
                //if the server is higher than the client it will ask for update
                clientVersionToNumber = Convert.ToInt32(clientVersion.Replace(".", ""));
            }  
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmMain CheckIfServerHasNewVersion");
                MessageBox.Show(@"An error occured while checking version");
                Environment.Exit(0);
            }


            DataTable serverTable = Query.Select("SELECT MAX([Version Number]) AS V FROM UpdateTable as tab INNER Join UpdateInfo as info ON tab.[Version Number] = info.[VersionNumber] " + (File.Exists("Sales.txt") ? "" : "where Released = 1 or DATEDIFF(day,info.Date,GETDATE()) > 0"));

            var serverVersion = (int)serverTable.Rows[0]["V"];

            return (serverVersion > clientVersionToNumber);
        }

        private void cmdSeeUpdates_Click(object sender, EventArgs e)
        {
            var updates = new FrmUpdates {MdiParent = this};
            updates.Show();
        }

        private void cmdLeadTime_Click(object sender, EventArgs e)
        {
            var leadTime = new FrmLeadTime {MdiParent = this};
            leadTime.Show();
        }

        private void sReportManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reportManager = new FrmReportUpload {MdiParent = this};
            reportManager.Show();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            var test = new FrmOneCompressor();
            test.Show();

            //TEST NUMBER TWO:  FILLING PRICES FOR QUOTATIONS

            /* DataTable quotes = Query.Select("Select quoteID, quoterevision, QuotationByUsername, multiplier, cn.Name, cn.CompanyName from quoteData as qd left join contact_new as cn on qd.ContactID = cn.ContactID  where ((quoteID + quoteRevision) not in (select (quoteID + quoteREvision)from quotePrice)) order by quoteID DESC ,quoteRevision");
            decimal price = 0;
            decimal tempPrice = 0;
            foreach (DataRow quote in quotes.Rows)
            {
                string quoteID = quote["QuoteID"].ToString();
                string quoteRevision = quote["QuoteRevision"].ToString();
                string itemType = "3";
                //Evaporators  - price for unit, price for coating, price for material, and price for options, then additionnal item.  Times amount of unit.
                DataTable evaps = Query.Select("select qed.ItemId, MAX( qed.Quantity) as evapQuantity, (Max(qed.Price) + Max(coilCoatingPrice) + Max(FinMaterialPrice)) as evapPrice from quoteEvaporatorData as qed where qed.quoteID = " + quoteID + " and qed.QuoteRevision = " + quoteRevision + " group by qed.ItemId ");
                foreach (DataRow evap in evaps.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(evap["evapPrice"].ToString())? 0: Convert.ToDecimal(evap["evapPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + evap["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                    DataTable options =
                        Query.Select(
                            "Select Sum(Price) as optionsPrice from quoteEvaporatorOptionsData where quoteId = " +
                            quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " +
                            evap["ItemId"].ToString());
                    if (options.Rows.Count > 0 && options.Rows[0]["optionsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(options.Rows[0]["optionsPrice"].ToString());
                    }
                    options.Dispose();
                                 
                                 
                    price += tempPrice*Convert.ToDecimal(evap["evapquantity"].ToString());
                }
                evaps.Dispose();
                itemType = "11";
                //WaterEvaps, same system as Evaporators.  WaterEvap, with options, and advanced items.
                DataTable waterEvaps = Query.Select("select qwed.ItemId, MAX( qwed.Quantity) as WaterEvapQuantity, (Max(qwed.EvaporatorPrice) + Max(coilCoatingPrice) + Max(FinMaterialPrice)) as waterEvapPrice from quoteWaterEvaporatorData as qwed where qwed.quoteID = " + quoteID + " and qwed.QuoteRevision = " + quoteRevision + " group by qwed.ItemId ");
                foreach (DataRow waterEvap in waterEvaps.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(waterEvap["waterEvapPrice"].ToString())? 0: Convert.ToDecimal(waterEvap["waterEvapPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + waterEvap["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                    DataTable options = Query.Select("Select Sum(Price) as optionsPrice from quoteWaterEvaporatorOptionsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + waterEvap["ItemId"].ToString());
                    if (options.Rows.Count > 0 && options.Rows[0]["optionsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(options.Rows[0]["optionsPrice"].ToString());
                    }
                    options.Dispose();             

                    price += tempPrice * Convert.ToDecimal(waterEvap["WaterEvapquantity"].ToString());
                }
                waterEvaps.Dispose();
                itemType = "1";
                //Condensers, has receiverINputs, condenser, condenserOption, controlPanel, controlPanelOption, secondaryoption, advanceditems
                DataTable condensers = Query.Select("Select c.ItemId, Max(c.Quantity) as condenserQuantity, Max(condenserPrice) as cPrice FROM quoteCondenserData as c where c.QuoteID = " + quoteID + " and c.quoteRevision = " + quoteRevision + " group by c.ItemID");
                foreach (DataRow condenser in condensers.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(condenser["cPrice"].ToString())? 0: Convert.ToDecimal(condenser["cPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + condenser["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    DataTable controlPanels = Query.Select("Select (Sum(OptionPrice) + Max(Price)) as cpItemsPrice from quoteControlPanelData  where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + condenser["ItemId"].ToString() + " group by itemID");
                    if (controlPanels.Rows.Count > 0 && controlPanels.Rows[0]["cpItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(controlPanels.Rows[0]["cpItemsPrice"].ToString());
                    }
                    controlPanels.Dispose();
                    DataTable secondaryOptions =Query.Select("Select Sum(FinMaterialPrice + TubeMaterialPrice + CoilCoatingPrice + CasingFinishPrice) as soPrice, Sum(legsPrice) as legPrice from QuoteSecondaryOptionsData where quoteId = " +quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " +condenser["ItemId"].ToString() + " group by itemID");
                    if (secondaryOptions.Rows.Count > 0 && secondaryOptions.Rows[0]["soPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(secondaryOptions.Rows[0]["soPrice"].ToString());
                        if (!String.IsNullOrEmpty(secondaryOptions.Rows[0]["LegPrice"].ToString()) && Convert.ToDecimal(secondaryOptions.Rows[0]["LegPrice"].ToString()) >= 0)
                        {
                            tempPrice += Convert.ToDecimal(secondaryOptions.Rows[0]["legPrice"].ToString());
                        }
                    }
                    secondaryOptions.Dispose();

                    DataTable receivers = Query.Select("select SUM( (Receiver1ValveQty * Receiver1ValvePriceIndividual) + (Receiver1PatchHeaterQty * Receiver1PatchHeaterPriceIndividual) + (Receiver1SightGlassQty * Receiver1SightGlassPrice) + (Receiver1InsulationQty * Receiver1InsulationPrice) + (Receiver1ReliefValveQty * Receiver1ReliefValvePrice) + Receiver2Price + Receiver1Price + (Receiver2ValvePriceIndividual * Receiver2ValveQty) + (Receiver2PatchHeaterQty * Receiver2PatchHeaterPriceIndividual) + (Receiver2SightGlassQty * Receiver2SightGlassPrice) + (Receiver2InsulationQty * Receiver2InsulationPrice) + (Receiver2ReliefValvePrice * Receiver2ReliefValveQty) + (ReceiverTransformer1Price * ReceiverTransformer1Qty) + (ReceiverTransformer2Price * ReceiverTransformer2Qty) + (ReceiverReinforcedBasePrice * ReceiverReinforcedBaseQty) )as recPrice from QuoteReceiverData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + condenser["ItemId"].ToString() + " group by itemID");
                    if (receivers.Rows.Count > 0 && receivers.Rows[0]["recPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(receivers.Rows[0]["recPrice"].ToString());
                    }
                    receivers.Dispose();
                    price += tempPrice * Convert.ToDecimal(condenser["condenserQuantity"].ToString());
                }
                condensers.Dispose();
                //CustomUnits, only has price and advanced Items

                itemType = "8";
                DataTable customUnits = Query.Select("Select cu.ItemID, Max(cu.Quantity) as customUnitsQuantity, Max(cu.Price) as cuPrice FROM QuoteCustomUnitData as cu where cu.QuoteID = " + quoteID + " and cu.quoteRevision = " + quoteRevision + " group by cu.ItemID");
                foreach (DataRow customUnit in customUnits.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(customUnit["cuPrice"].ToString())? 0: Convert.ToDecimal(customUnit["cuPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + customUnit["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();        
                    price += tempPrice * Convert.ToDecimal(customUnit["customUnitsQuantity"].ToString());
                }
                customUnits.Dispose();

                itemType = "7";
                //Gravity coil, again only the unit and its additional items
                DataTable gravityCoils =Query.Select("Select gc.ItemID, Max(gc.Quantity) as gravityCoilQuantity, (Max(gc.ListPrice) + MAX(CoatingPrice)) as gravityCoilPrice FROM QuoteGravityCoilData as gc where gc.QuoteID = " + quoteID + " and gc.quoteRevision = " + quoteRevision + " group by gc.ItemID");
                foreach (DataRow gravityCoil in gravityCoils.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(gravityCoil["gravityCoilPrice"].ToString())? 0: Convert.ToDecimal(gravityCoil["gravityCoilPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + gravityCoil["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                    price += tempPrice * Convert.ToDecimal(gravityCoil["gravityCoilQuantity"].ToString());
                }
                gravityCoils.Dispose();

                itemType = "6";
                DataTable heatPipes = Query.Select("Select hp.ItemId, Max(hp.Quantity) as heatPipeQuantity, (Max(hp.Price)) as heatPipePrice FROM QuoteHeatPipeData as hp where hp.QuoteID = " + quoteID + " and hp.quoteRevision = " + quoteRevision + " group by hp.ItemID");
                foreach (DataRow heatPipe in heatPipes.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(heatPipe["heatPipePrice"].ToString())? 0: Convert.ToDecimal(heatPipe["heatPipePrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + heatPipe["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                    price += tempPrice * Convert.ToDecimal(heatPipe["heatPipeQuantity"].ToString());
                }
                heatPipes.Dispose();

                itemType = "5";
                DataTable manualCoils = Query.Select("Select mc.ItemId, Max(mc.Quantity) as manualCoilQuantity, (Max(mc.Price) + Max(mc.CoatingPrice) + Max(mc.turbulatorPrice)) as ManualCoilPrice FROM QuoteManualCoilData as mc where mc.QuoteID = " + quoteID + " and mc.quoteRevision = " + quoteRevision + " group by mc.ItemID");
                foreach (DataRow manualCoil in manualCoils.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(manualCoil["manualCoilPrice"].ToString())? 0: Convert.ToDecimal(manualCoil["manualCoilPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + manualCoil["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                              
                    price += tempPrice * Convert.ToDecimal(manualCoil["manualCoilQuantity"].ToString());
                }
                manualCoils.Dispose();

                itemType = "0";
                DataTable quickCoils = Query.Select("Select c.ItemId, Max(c.Quantity) as quickCoilQuantity, (Max(c.CoilPrice) + Max(c.CoatingPrice) + Max(c.turbulatorPrice)) as QuickCoilPrice FROM QuoteCoilData as c  where c.QuoteID = " + quoteID + " and c.quoteRevision = " + quoteRevision + " group by c.ItemID");
                foreach (DataRow quickCoil in quickCoils.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(quickCoil["quickCoilPrice"].ToString())? 0: Convert.ToDecimal(quickCoil["quickCoilPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + quickCoil["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                    price += tempPrice * Convert.ToDecimal(quickCoil["quickCoilQuantity"].ToString());
                }
                quickCoils.Dispose();

                itemType = "2";
                DataTable condensingUnits = Query.Select("Select cu.ItemId, Max(cu.Quantity) as condensingUnitQuantity, (Max(cu.Price) + Max(cu.CoilCoatingPrice) + Max(cu.FinMaterialPrice)) as CondensingUnitPrice FROM QuoteCondensingUnitData as cu  where cu.QuoteID = " + quoteID + " and cu.quoteRevision = " + quoteRevision + " group by cu.ItemId");
                foreach (DataRow condensingUnit in condensingUnits.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(condensingUnit["condensingUnitPrice"].ToString())? 0: Convert.ToDecimal(condensingUnit["condensingUnitPrice"].ToString()));
                    DataTable advancedItems = Query.Select("Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + condensingUnit["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                    DataTable options = Query.Select("Select Sum(Price) as optionsPrice from quoteCondensingUnitOptionData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + condensingUnit["ItemId"].ToString());
                    if (options.Rows.Count > 0 && options.Rows[0]["optionsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(options.Rows[0]["optionsPrice"].ToString());
                    }
                    options.Dispose();           
                              
                    price += tempPrice * Convert.ToDecimal(condensingUnit["condensingUnitQuantity"].ToString());
                }
                condensingUnits.Dispose();

                itemType = "4";
                DataTable fluidCoolers = Query.Select("Select fc.ItemId, Max(fc.Quantity) as fluidCoolerQuantity,  (Max(fc.Price)) as fluidCoolerPrice FROM QuotefluidCoolerData as fc where fc.QuoteID = " + quoteID + " and fc.quoteRevision = " + quoteRevision + " group by fc.ItemID");
                foreach (DataRow fluidCooler in fluidCoolers.Rows)
                {
                    tempPrice = (String.IsNullOrEmpty(fluidCooler["fluidCoolerPrice"].ToString())? 0: Convert.ToDecimal(fluidCooler["fluidCoolerPrice"].ToString()));
                    DataTable advancedItems =
                        Query.Select(
                            "Select Sum(Price * Quantity) as adItemsPrice from quoteAdditionalItemsData where quoteId = " +quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " +fluidCooler["ItemId"].ToString() + " and ItemType = " + itemType);
                    if (advancedItems.Rows.Count > 0 && advancedItems.Rows[0]["adItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(advancedItems.Rows[0]["adItemsPrice"].ToString());
                    }
                    advancedItems.Dispose();
                    DataTable controlPanels = Query.Select("Select (Sum(OptionPrice) + Max(Price)) as cpItemsPrice from quoteControlPanelData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + fluidCooler["ItemId"].ToString() + " group by itemID");
                    if (controlPanels.Rows.Count > 0 && controlPanels.Rows[0]["cpItemsPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(controlPanels.Rows[0]["cpItemsPrice"].ToString());
                    }
                    controlPanels.Dispose();
                    DataTable secondaryOptions = Query.Select("Select Sum(FinMaterialPrice + TubeMaterialPrice + CoilCoatingPrice + CasingFinishPrice) as soPrice, Sum(legsPrice) as legPrice from QuoteSecondaryOptionsData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + fluidCooler["ItemId"].ToString() + " group by itemID");
                    if (secondaryOptions.Rows.Count > 0 && secondaryOptions.Rows[0]["soPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(secondaryOptions.Rows[0]["soPrice"].ToString());
                        if (!String.IsNullOrEmpty(secondaryOptions.Rows[0]["LegPrice"].ToString()) && Convert.ToDecimal(secondaryOptions.Rows[0]["LegPrice"].ToString()) >= 0)
                        {
                            tempPrice += Convert.ToDecimal(secondaryOptions.Rows[0]["legPrice"].ToString());
                        }
                    }
                    secondaryOptions.Dispose();
                    DataTable pumps = Query.Select("Select (Sum(OptionPrice) + Max(valvePrice) + Max(ExpansionTankKitPrice) + Max(PumpPrice)) as pumpPrice from quotePumpData where quoteId = " + quoteID + " and quoteRevision =" + quoteRevision + " and itemID = " + fluidCooler["ItemId"].ToString());
                    if (pumps.Rows.Count > 0 && pumps.Rows[0]["pumpPrice"].ToString() != "")
                    {
                        tempPrice += Convert.ToDecimal(pumps.Rows[0]["pumpPrice"].ToString());
                    }
                    pumps.Dispose();  
                    price += tempPrice * Convert.ToDecimal(fluidCooler["fluidCoolerQuantity"].ToString());
                }
                fluidCoolers.Dispose();
                Query.Execute("Insert into QuotePrice VALUES(" + quoteID + "," + quoteRevision + "," +
                              quote["multiplier"].ToString() + "," + (price*Convert.ToDecimal(quote["multiplier"].ToString())) + ")")
                    ;
                price = 0;
                tempPrice = 0;
            }
            quotes.Dispose();
            


            // TEST NUMBER ONE - AUGUST 2013  - SUCCESSFULL
            //This is just to test the new drawing dynamic generator, august 9 2013
            /*DataTable condensers = Query.Select("Select QuoteID, QUoteRevision, ItemType, ItemID, Input_RatingModel, ApprovalDrawing, Motor, CondenserType, CoilArr, FanWide,FanLong, AirFlowType  from QUoteCondenserData");
            var errorList = new List<string>();
            foreach (DataRow row in condensers.Rows)
            {
                string whereClause = "where QuoteID = " + row["QuoteID"] + " and QuoteRevision = " + row["QuoteRevision"] + " and ItemType = " + row["ItemType"] + " and ItemID = " + row["ItemID"];
                DataTable rec = Query.Select("Select ReceiverReinforcedBaseQty, Receiver1Model,Receiver2Model,ReceiverInstall from QuoteReceiverData " + whereClause);
                DataTable legs = Query.Select("Select LegSize from QuoteSecondaryOptionsData " + whereClause);
                string legNomenclature;

                //Finding the way legs are called in the system
                if (legs.Rows.Count == 0)
                {
                    legNomenclature = "N00";
                }
                else if (legs.Rows[0]["LegSize"].ToString() == "0")
                {
                    legNomenclature = "N00";
                }
                else
                {
                    legNomenclature = "L" + legs.Rows[0]["LegSize"];
                }

                //With the receiver table, find if base is installed, receiver is installed, and the quantity of receivers with the unit
                int quantityOfReceiver = 0;
                bool baseInstalled = false;
                bool receiverInstalled = false;
                if (rec.Rows.Count > 0)
                {
                    if (rec.Rows[0]["Receiver1Model"].ToString() != "" && rec.Rows[0]["Receiver1Model"] != null)
                    {
                        ++quantityOfReceiver;
                    }

                    if (rec.Rows[0]["Receiver2Model"].ToString() != "" && rec.Rows[0]["Receiver2Model"] != null)
                    {
                        ++quantityOfReceiver;
                    }
                    receiverInstalled = rec.Rows[0]["ReceiverInstall"].ToString().Contains("INSTALLED");
                    baseInstalled = (Convert.ToInt32(rec.Rows[0]["ReceiverReinforcedBaseQty"].ToString()) >= 1);
                }

                //Generating the approval name at runtime to see if it's accessible
                string strDrawingName = QuickCondenser.FrmQuickCondenser.GetApprovalDrawing(row["Motor"].ToString(), row["CoilArr"].ToString(), row["CondenserType"].ToString(), row["FanWide"].ToString(), row["FanLong"].ToString(), baseInstalled, row["AirFlowType"].ToString(), receiverInstalled, quantityOfReceiver, legNomenclature);
                strDrawingName += ".PDF";
                if (strDrawingName != "")
                {
                    byte[] bfile = DrawingManager.GetDrawingFile(strDrawingName, "REFPLUS", DrawingManager.DrawingCategory.Condenser);
                    if (bfile != null)
                    {
                    }
                    else
                    {
                        errorList.Add(strDrawingName);
                    }
                }
            }
            var list = new string[19000];
            int i = 0;
            foreach(string stri in errorList)
            {
                list[i] = stri;
                ++i;
            }*/
        }

        private void mnuCondensingUnitPartUpdaterMotor_Click(object sender, EventArgs e)
        {
            var motorupdater = new DataManager.CondensingUnit.FrmCondensingUnitMotorUpdater {MdiParent = this};
            motorupdater.Show();
        }

        private void sCostingManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var costing = new FrmCosting();
            costing.Show();
        }

        private void sSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var search = new FrmSalesReport(this);
            search.Show();
        }
        
    }
}
