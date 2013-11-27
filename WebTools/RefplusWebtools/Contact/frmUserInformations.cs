using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.Contact
{
    public partial class FrmUserInformations : Form
    {
        private readonly int _contactID = -1;
        private int _userID = -1;
        private DataTable _dtUserData;

        public FrmUserInformations(int contactID)
        {
            InitializeComponent();
            _contactID = contactID;
        }

        private void frmUserInformations_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            FillControls();
            SetDefaults();
            SetAvailableRightAssignation();
            CheckAndLoadUserInfo();

            ThreadProcess.Stop();
            Focus();
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void CheckAndLoadUserInfo()
        {
            _dtUserData = Query.Select("SELECT * FROM UserAccount_NEW WHERE UserID = " + _contactID);

            if (_dtUserData.Rows.Count > 0)
            {
                _userID = _contactID;
                txtUsername.Enabled = false;
                LoadUserData();
            }
            else
            {
                chkQuote.Checked = true;
                chkQuoteCoil.Checked = true;
                chkQuoteCondenser.Checked = true;
                chkQuoteCondensingUnit.Checked = true;
                chkQuoteEvaporator.Checked = true;
                chkQuoteFluidCooler.Checked = true;
                chkQuoteGravityCoil.Checked = true;
                chkQuoteHeatPipe.Checked = true;
                chkQuoteManualCoil.Checked = true;
                chkQuoteAdditionnalItems.Checked = true;
                chkQuickCoil.Checked = true;
                chkQuickCondenser.Checked = true;
                chkQuickCondensingUnit.Checked = true;
                chkQuickEvaporator.Checked = true;
                chkQuickFluidCooler.Checked = true;
                chkQuickGravityCoil.Checked = true;
                chkQuickHeatPipe.Checked = true;
                chkAdvancedSearch.Checked = true;
            }
        }

        private void LoadUserData()
        {
            txtUsername.Text = _dtUserData.Rows[0]["Username"].ToString();
            txtPassword.Text = _dtUserData.Rows[0]["Password"].ToString();
            txtPassword2.Text = _dtUserData.Rows[0]["Password"].ToString();

            string[] sites = _dtUserData.Rows[0]["Sites"].ToString().Split(',');
            foreach (string site in sites)
            {
                if (site == "ECOSAIRE")
                {
                    chkEcosaire.Checked = true;
                }
                else if (site == "REFPLUS")
                {
                    chkRefplus.Checked = true;
                }
            }

            ComboBoxControl.SetIDDefaultValue(cboUserLevel, _dtUserData.Rows[0]["UserLevel"].ToString());
            chkActive.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["IsActive"]) == 1);
            numMinMultiplier.Value = Convert.ToDecimal(_dtUserData.Rows[0]["MinMultiplier"]);
            numMaxMultiplier.Value = Convert.ToDecimal(_dtUserData.Rows[0]["MaxMultiplier"]);
            chkQuote.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTE"]) == 1);
            chkQuoteCoil.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTECOIL"]) == 1);
            chkQuoteManualCoil.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEMANUALCOIL"]) == 1);
            chkQuoteCondenser.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTECONDENSER"]) == 1);
            chkQuoteCondensingUnit.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTECONDENSINGUNIT"]) == 1);
            chkQuoteCustomUnit.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTECUSTOMUNIT"]) == 1);
            chkQuoteEvaporator.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEEVAPORATOR"]) == 1);
            chkQuoteWaterEvaporator.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEWATEREVAPORATOR"]) == 1);
            chkQuoteGravityCoil.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEGRAVITYCOIL"]) == 1);
            chkQuoteFluidCooler.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEFLUIDCOOLER"]) == 1);
            chkQuoteHeatPipe.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEHEATPIPE"]) == 1);
            chkQuoteAdditionnalItems.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEADDITIONNALITEMS"]) == 1);
            chkQuoteOEMCoil.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUOTEOEMCOIL"]) == 1);
            chkQuickCoil.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKCOIL"]) == 1);
            chkQuickCondenser.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKCONDENSER"]) == 1);
            chkQuickCondensingUnit.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKCONDENSINGUNIT"]) == 1);
            chkQuickCustomUnit.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKCUSTOMUNIT"]) == 1);
            chkQuickEvaporator.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKEVAPORATOR"]) == 1);
            chkQuickWaterEvaporator.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKWATEREVAPORATOR"]) == 1);
            chkQuickGravityCoil.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKGRAVITYCOIL"]) == 1);
            chkQuickFluidCooler.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKFLUIDCOOLER"]) == 1);
            chkQuickHeatPipe.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSQUICKHEATPIPE"]) == 1);
            chkUserManager.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSUSERMANAGER"]) == 1);
            chkAdvancedSearch.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSADVANCEDSEARCH"]) == 1);
            chkBalancingModule.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSBALANCINGMODULE"]) == 1);
            chkDataManager.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSDATAMANAGER"]) == 1);
            chkReport.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSREPORT"]) == 1);
            chkEngineeringReport.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSREPORTENGINEERINGREPORT"]) == 1);
            chkAdvancedSalesReport.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSREPORTADVANCEDSALESREPORT"]) == 1);
            chkOEMCoilProfitMargin.Checked = (Convert.ToInt32(_dtUserData.Rows[0]["ACCESSOEMPROFITMARGIN"]) == 1);
        }

        private void SetAvailableRightAssignation()
        {
            chkQuote.Enabled = UserInformation.AccessQuote;
            chkQuoteCoil.Enabled = UserInformation.AccessQuoteCoil;
            chkQuoteManualCoil.Enabled = UserInformation.AccessQuoteManualCoil;
            chkQuoteCondenser.Enabled = UserInformation.AccessQuoteCondenser;
            chkQuoteCondensingUnit.Enabled = UserInformation.AccessQuoteCondensingUnit;
            chkQuoteCustomUnit.Enabled = UserInformation.AccessQuoteCustomUnit;
            chkQuoteEvaporator.Enabled = UserInformation.AccessQuoteEvaporator;
            chkQuoteWaterEvaporator.Enabled = UserInformation.AccessQuoteWaterEvaporator;
            chkQuoteGravityCoil.Enabled = UserInformation.AccessQuoteGravityCoil;
            chkQuoteFluidCooler.Enabled = UserInformation.AccessQuoteFluidCooler;
            chkQuoteHeatPipe.Enabled = UserInformation.AccessQuoteHeatPipe;
            chkQuoteAdditionnalItems.Enabled = UserInformation.AccessQuoteAdditionnalItems;
            chkQuoteOEMCoil.Enabled = UserInformation.AccessQuoteOEMCoil;
            chkQuickCoil.Enabled = UserInformation.AccessQuickCoil;
            chkQuickCondenser.Enabled = UserInformation.AccessQuickCondenser;
            chkQuickCondensingUnit.Enabled = UserInformation.AccessQuickCondensingUnit;
            chkQuickCustomUnit.Enabled = UserInformation.AccessQuickCustomUnit;
            chkQuickEvaporator.Enabled = UserInformation.AccessQuickEvaporator;
            chkQuickWaterEvaporator.Enabled = UserInformation.AccessQuickWaterEvaporator;
            chkQuickGravityCoil.Enabled = UserInformation.AccessQuickGravityCoil;
            chkQuickFluidCooler.Enabled = UserInformation.AccessQuickFluidCooler;
            chkQuickHeatPipe.Enabled = UserInformation.AccessQuickHeatPipe;
            chkUserManager.Enabled = UserInformation.AccessUserManager;
            chkAdvancedSearch.Enabled = UserInformation.AccessAdvancedSearch;
            chkBalancingModule.Enabled = UserInformation.AccessBalancingModule;
            chkDataManager.Enabled = UserInformation.AccessDataManager;
            chkReport.Enabled = UserInformation.AccessReport;
            chkEngineeringReport.Enabled = UserInformation.AccessReportEngineeringReport;
            chkAdvancedSalesReport.Enabled = UserInformation.AccessReportAdvancedSalesReport;
            chkOEMCoilProfitMargin.Enabled = UserInformation.AccessQuoteOEMCoilProfitMargin;
        }

        private void SetDefaults()
        {
            ComboBoxControl.SetIDDefaultValue(cboUserLevel, "0");
        }

        private void FillControls()
        {
            FillUserLevel();
        }

        private void FillUserLevel()
        {
            ComboBoxControl.AddItem(cboUserLevel, "0", "00 - Standard User");
            ComboBoxControl.AddItem(cboUserLevel, "80", "80 - External Sales");
            ComboBoxControl.AddItem(cboUserLevel, "90", "90 - Internal Sales");

            if (UserInformation.ExactRequiredPermission(99))
            {
                ComboBoxControl.AddItem(cboUserLevel, "99", "99 - Full Administrator");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if ( chkEcosaire.Checked || chkRefplus.Checked)
            {
                if (Public.IsStringAlphanumeric(txtPassword.Text) && txtPassword.Text.Length > 0)
                {
                    if (txtPassword.Text == txtPassword2.Text)
                    {
                        if (_contactID == _userID)
                        {
                            //user already exist we just want to update
                            if(UpdateUser())
                            {
                                Public.LanguageBox("Save successful", "Sauvegarde réussie");
                                Close();
                            }
                            else
                            {
                                Public.LanguageBox("Save failed", "Erreur de savegarde");
                            }

                            
                            
                        }
                        else
                        {
                            //new user we need to insert
                            //also check for username to not be taken
                            if (Public.IsStringAlphanumeric(txtUsername.Text) && txtUsername.Text.Length > 0)
                            {
                                DataTable dtUsernameCheck = Query.Select("SELECT * FROM UserAccount_NEW WHERE Username = '" + txtUsername.Text + "'");
                                if (dtUsernameCheck.Rows.Count == 0)
                                {
                                    InsertUser();
                                    Public.LanguageBox("The user was created correctly.", "Cet utilisateur a été créé correctement.");
                                    Close();
                                }
                                else
                                {
                                    Public.LanguageBox("This username is already in use.", "Ce nom d'utilisateur est déja utilisé.");
                                }
                            }
                            else
                            {
                                Public.LanguageBox("The username is not in a valid format. Only alphanumeric characters are allowed", "Le nom d'utilisateur n'est pas valide. Seul les caractères alphanumerique sont acceptés.");
                            }
                        }
                    }
                    else
                    {
                        Public.LanguageBox("The 2 passwords don't match. Please re-type.", "Les 2 mots de passe ne correspondent pas. Veuillez les entrer de nouveau.");
                    }
                }
                else
                {
                    Public.LanguageBox("The password is not in a valid format. Only alphanumeric characters are allowed", "Le mots de passe n'est pas valide. Seul les caractères alphanumerique sont acceptés.");
                }
            }
            else
            {
                Public.LanguageBox("You must check at least 1 site.", "Vous devez sélectionner au moins 1 site.");
            }
        }

        private void InsertUser()
        {
            string tsql = "";
            tsql += "INSERT INTO UserAccount_NEW ";
            tsql += "(UserID";
            tsql += ",Username";
            tsql += ",Password";
            tsql += ",Sites";
            tsql += ",UserLevel";
            tsql += ",IsActive";
            tsql += ",MaxMultiplier";
            tsql += ",MinMultiplier";
            tsql += ",CreatedBy";
            tsql += ",UpdatedBy";
            tsql += ",AccessQuote";
            tsql += ",AccessQuoteCoil";
            tsql += ",AccessQuoteManualCoil";
            tsql += ",AccessQuoteCondenser";
            tsql += ",AccessQuoteCondensingUnit";
            tsql += ",AccessQuoteEvaporator";
            tsql += ",AccessQuoteWaterEvaporator";
            tsql += ",AccessQuoteGravityCoil";
            tsql += ",AccessQuoteFluidCooler";
            tsql += ",AccessQuoteHeatPipe";
            tsql += ",AccessQuoteCustomUnit";
            tsql += ",AccessQuoteAdditionnalItems";
            tsql += ",AccessQuoteOEMCoil";
            tsql += ",AccessQuickCoil";
            tsql += ",AccessQuickCondenser";
            tsql += ",AccessQuickCondensingUnit";
            tsql += ",AccessQuickEvaporator";
            tsql += ",AccessQuickWaterEvaporator";
            tsql += ",AccessQuickGravityCoil";
            tsql += ",AccessQuickFluidCooler";
            tsql += ",AccessQuickHeatPipe";
            tsql += ",AccessQuickCustomUnit";
            tsql += ",AccessAdvancedSearch";
            tsql += ",AccessUserManager";
            tsql += ",AccessBalancingModule";
            tsql += ",AccessDataManager";
            tsql += ",AccessReport";
            tsql += ",AccessReportEngineeringReport";
            tsql += ",AccessReportAdvancedSalesReport";
            tsql += ",AccessOEMProfitMargin)";
            tsql += " VALUES (";
            tsql += _contactID + ",";
            tsql += "'" + txtUsername.Text + "',";
            tsql += "'" + txtPassword.Text + "',";

            string sites = "";
            if (chkEcosaire.Checked)
            {
                sites += "ECOSAIRE,";
            }
            if (chkRefplus.Checked)
            {
                sites += "REFPLUS,";
            }
            sites = sites.Substring(0, sites.Length - 1);
            
            tsql += "'" + sites + "',";
            tsql +=  ComboBoxControl.IndexInformation(cboUserLevel) + ",";
            tsql += (chkActive.Checked ? "1" : "0") + ",";
            tsql += numMaxMultiplier.Value + ",";
            tsql += numMinMultiplier.Value + ",";
            tsql += UserInformation.UserID + ",";
            tsql += UserInformation.UserID + ",";
            tsql += (chkQuote.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteCoil.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteManualCoil.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteCondenser.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteCondensingUnit.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteEvaporator.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteWaterEvaporator.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteGravityCoil.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteFluidCooler.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteHeatPipe.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteCustomUnit.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteAdditionnalItems.Checked ? "1" : "0") + ",";
            tsql += (chkQuoteOEMCoil.Checked ? "1" : "0") + ",";
            tsql += (chkQuickCoil.Checked ? "1" : "0") + ",";
            tsql += (chkQuickCondenser.Checked ? "1" : "0") + ",";
            tsql += (chkQuickCondensingUnit.Checked ? "1" : "0") + ",";
            tsql += (chkQuickEvaporator.Checked ? "1" : "0") + ",";
            tsql += (chkQuickWaterEvaporator.Checked ? "1" : "0") + ",";
            tsql += (chkQuickGravityCoil.Checked ? "1" : "0") + ",";
            tsql += (chkQuickFluidCooler.Checked ? "1" : "0") + ",";
            tsql += (chkQuickHeatPipe.Checked ? "1" : "0") + ",";
            tsql += (chkQuickCustomUnit.Checked ? "1" : "0") + ",";
            tsql += (chkAdvancedSearch.Checked ? "1" : "0") + ",";
            tsql += (chkUserManager.Checked ? "1" : "0") + ",";
            tsql += (chkBalancingModule.Checked ? "1" : "0") + ",";
            tsql += (chkDataManager.Checked ? "1" : "0") + ",";
            tsql += (chkReport.Checked ? "1" : "0") + ",";
            tsql += (chkEngineeringReport.Checked ? "1" : "0") + ",";
            tsql += (chkAdvancedSalesReport.Checked ? "1" : "0") + ",";
            tsql += (chkOEMCoilProfitMargin.Checked ? "1" : "0") + ")";
            Query.Execute(tsql);
           
        }

        private bool UpdateUser()
        {
            string tsql = "";
            tsql += "UPDATE UserAccount_NEW SET ";
            tsql += "Password = '" + txtPassword.Text + "'";
            string sites = "";
           if (chkEcosaire.Checked)
            {
                sites += "ECOSAIRE,";
            }
            if (chkRefplus.Checked)
            {
                sites += "REFPLUS,";
            }
            sites = sites.Substring(0, sites.Length - 1);

            tsql += ",Sites = '" +sites+ "'";
            tsql += ",UserLevel = " + ComboBoxControl.IndexInformation(cboUserLevel);
            tsql += ",IsActive = " + (chkActive.Checked ? "1" : "0");
            tsql += ",MaxMultiplier = " + numMaxMultiplier.Value;
            tsql += ",MinMultiplier = " + numMinMultiplier.Value;
            tsql += ",UpdatedBy = " + UserInformation.UserID;
            tsql += ",AccessQuote = " + (chkQuote.Checked ? "1" : "0");
            tsql += ",AccessQuoteCoil = " + (chkQuoteCoil.Checked ? "1" : "0");
            tsql += ",AccessQuoteManualCoil = " + (chkQuoteManualCoil.Checked ? "1" : "0");
            tsql += ",AccessQuoteCondenser = " + (chkQuoteCondenser.Checked ? "1" : "0");
            tsql += ",AccessQuoteCondensingUnit = " + (chkQuoteCondensingUnit.Checked ? "1" : "0");
            tsql += ",AccessQuoteEvaporator = " + (chkQuoteEvaporator.Checked ? "1" : "0");
            tsql += ",AccessQuoteWaterEvaporator = " + (chkQuoteWaterEvaporator.Checked ? "1" : "0");
            tsql += ",AccessQuoteGravityCoil = " + (chkQuoteGravityCoil.Checked ? "1" : "0");
            tsql += ",AccessQuoteFluidCooler = " + (chkQuoteFluidCooler.Checked ? "1" : "0");
            tsql += ",AccessQuoteHeatPipe = " + (chkQuoteHeatPipe.Checked ? "1" : "0");
            tsql += ",AccessQuoteCustomUnit = " + (chkQuoteCustomUnit.Checked ? "1" : "0");
            tsql += ",AccessQuoteAdditionnalItems = " + (chkQuoteAdditionnalItems.Checked ? "1" : "0");
            tsql += ",AccessQuoteOEMCoil = " + (chkQuoteOEMCoil.Checked ? "1" : "0");
            tsql += ",AccessQuickCoil = " + (chkQuickCoil.Checked ? "1" : "0");
            tsql += ",AccessQuickCondenser = " + (chkQuickCondenser.Checked ? "1" : "0");
            tsql += ",AccessQuickCondensingUnit = " + (chkQuickCondensingUnit.Checked ? "1" : "0");
            tsql += ",AccessQuickEvaporator = " + (chkQuickEvaporator.Checked ? "1" : "0");
            tsql += ",AccessQuickWaterEvaporator = " + (chkQuickWaterEvaporator.Checked ? "1" : "0");
            tsql += ",AccessQuickGravityCoil = " + (chkQuickGravityCoil.Checked ? "1" : "0");
            tsql += ",AccessQuickFluidCooler = " + (chkQuickFluidCooler.Checked ? "1" : "0");
            tsql += ",AccessQuickHeatPipe = " + (chkQuickHeatPipe.Checked ? "1" : "0");
            tsql += ",AccessQuickCustomUnit = " + (chkQuickCustomUnit.Checked ? "1" : "0");
            tsql += ",AccessAdvancedSearch = " + (chkAdvancedSearch.Checked ? "1" : "0");
            tsql += ",AccessUserManager = " + (chkUserManager.Checked ? "1" : "0");
            tsql += ",AccessBalancingModule = " + (chkBalancingModule.Checked ? "1" : "0");
            tsql += ",AccessDataManager = " + (chkDataManager.Checked ? "1" : "0");
            tsql += ",AccessReport = " + (chkReport.Checked ? "1" : "0");
            tsql += ",AccessReportEngineeringReport = " + (chkEngineeringReport.Checked ? "1" : "0");
            tsql += ",AccessReportAdvancedSalesReport = " + (chkAdvancedSalesReport.Checked ? "1" : "0");
            tsql += ",AccessOEMProfitMargin = " + (chkOEMCoilProfitMargin.Checked ? "1" : "0");
            tsql += " WHERE UserID = " + _userID;

            return Query.Execute(tsql);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmUserInformations_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        
    }
}