using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public partial class FrmLogin : Form
    {
        readonly FrmMain _myParent;

        public FrmLogin(FrmMain myParent)
        {
            InitializeComponent();
            _myParent = myParent;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            txtUsername.Text = Reg.Get(Reg.Key.Username);
            cboSite.Text = Reg.Get(Reg.Key.Site) != "" ? Reg.Get(Reg.Key.Site) : "REFPLUS";

            if (txtUsername.Text.Length > 0)
            {
                txtPassword.Select();
            }
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (!CheckUserCredential(txtUsername.Text, txtPassword.Text))
            {
                Public.LanguageBox("Invalid Username or Password or you do not have access to that site.", "Nom d'utilisateur ou mot de passe invalide ou bien votre compte n'a pas accès à ce site.");
            }
            else
            {
                Dispose();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private bool CheckUserCredential(string strUsername, string strPassword)
        {
            bool bolLoginSuccessful = false;
            try
            {
                //value to return if the login is successful or not
               

                //make sure the strings are correct
                strUsername = strUsername.Replace("'", "''").ToLower();
                strPassword = strPassword.Replace("'", "''").ToLower();

                //select on the table
                DataTable dtUserInformations = Query.Select("SELECT * FROM UserAccount_NEW LEFT JOIN Contact_NEW on UserAccount_NEW.UserID = Contact_NEW.ContactID LEFT JOIN ContactGroup_NEW ON Contact_NEW.GroupID = ContactGroup_NEW.GroupID WHERE Username = '" + strUsername + "' AND Password = '" + strPassword + "' AND IsActive = 1 AND Sites like '%" + UserInformation.CurrentSite + "%'");

                //if we have record the login is successful
                if (dtUserInformations.Rows.Count != 0)
                {
                    //set user variable
                    UserInformation.UserName = dtUserInformations.Rows[0]["Username"].ToString();
                    UserInformation.Site = dtUserInformations.Rows[0]["Sites"].ToString();
                    UserInformation.UserID = Convert.ToInt32(dtUserInformations.Rows[0]["UserID"]);
                    UserInformation.ContactID = Convert.ToInt32(dtUserInformations.Rows[0]["ContactID"]);
                    UserInformation.GroupID = Convert.ToInt32(dtUserInformations.Rows[0]["GroupID"]);
                    UserInformation.CreatedByGroupID = Convert.ToInt32(dtUserInformations.Rows[0]["CreatedByGroup"]);
                    UserInformation.ParentGroupID = Convert.ToInt32(dtUserInformations.Rows[0]["ParentGroupID"]);
                    UserInformation.Userlevel = Convert.ToInt32(dtUserInformations.Rows[0]["UserLevel"]);
                    UserInformation.UserGroups = GetUserGroups();
                    UserInformation.Email = dtUserInformations.Rows[0]["Email"].ToString();
                    UserInformation.Name = dtUserInformations.Rows[0]["Name"].ToString();
                    UserInformation.CompanyName = dtUserInformations.Rows[0]["CompanyName"].ToString();
                    UserInformation.MinMultiplier = Convert.ToDecimal(dtUserInformations.Rows[0]["MinMultiplier"]);
                    UserInformation.MaxMultiplier = Convert.ToDecimal(dtUserInformations.Rows[0]["MaxMultiplier"]);


                    UserInformation.AccessQuote =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuote"]));
                    UserInformation.AccessQuoteCoil =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteCoil"]));
                    UserInformation.AccessQuoteManualCoil =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteManualCoil"]));
                    UserInformation.AccessQuoteCondenser =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteCondenser"]));
                    UserInformation.AccessQuoteCondensingUnit =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteCondensingUnit"]));
                    UserInformation.AccessQuoteEvaporator =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteEvaporator"]));
                    UserInformation.AccessQuoteWaterEvaporator =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteWaterEvaporator"]));
                    UserInformation.AccessQuoteGravityCoil =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteGravityCoil"]));
                    UserInformation.AccessQuoteFluidCooler =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteFluidCooler"]));
                    UserInformation.AccessQuoteHeatPipe =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteHeatPipe"]));
                    UserInformation.AccessQuoteCustomUnit =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteCustomUnit"]));
                    UserInformation.AccessQuoteAdditionnalItems =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteAdditionnalItems"]));
                    UserInformation.AccessQuoteOEMCoil =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuoteOEMCoil"]));
                    UserInformation.AccessQuickCoil =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickCoil"]));
                    UserInformation.AccessQuickCondenser =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickCondenser"]));
                    UserInformation.AccessQuickCondensingUnit =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickCondensingUnit"]));
                    UserInformation.AccessQuickEvaporator =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickEvaporator"]));
                    UserInformation.AccessQuickWaterEvaporator =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickWaterEvaporator"]));
                    UserInformation.AccessQuickGravityCoil =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickGravityCoil"]));
                    UserInformation.AccessQuickFluidCooler =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickFluidCooler"]));
                    UserInformation.AccessQuickHeatPipe =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickHeatPipe"]));
                    UserInformation.AccessQuickCustomUnit =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessQuickCustomUnit"]));
                    UserInformation.AccessUserManager =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessUserManager"]));
                    UserInformation.AccessAdvancedSearch =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessAdvancedSearch"]));
                    UserInformation.AccessBalancingModule =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessBalancingModule"]));
                    UserInformation.AccessDataManager =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessDataManager"]));
                    UserInformation.AccessReport =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessReport"]));
                    UserInformation.AccessReportEngineeringReport =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessReportEngineeringReport"]));
                    UserInformation.AccessReportAdvancedSalesReport =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessReportAdvancedSalesReport"]));
                    UserInformation.AccessQuoteOEMCoilProfitMargin =
                        ConvertRights(Convert.ToInt32(dtUserInformations.Rows[0]["AccessOEMProfitMargin"]));


                    //save to registry the username
                    Reg.Set(Reg.Key.Username, UserInformation.UserName);
                    Reg.Set(Reg.Key.Site, UserInformation.CurrentSite);

                    //make the login process with the fingerprint
                    FingerPrintHandler.LoginProcess();

                    bolLoginSuccessful = true;
                }

                //dispose
                dtUserInformations.Dispose();
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmLogin CheckUserCredential");
                MessageBox.Show(ex.ToString());
            }
          
            return bolLoginSuccessful;
        }

        private static string GetUserGroups()
        {
            string userGroups = UserInformation.GroupID.ToString(CultureInfo.InvariantCulture);

            if (UserInformation.ParentGroupID != -1)
            {
                userGroups += "," + UserInformation.ParentGroupID;
            }

            //the replace will prevent any selection of other group with no parent (aka -1)
            DataTable dtGetSpecialGroups = Query.Select(@"
                        SELECT GroupID FROM ContactGroup_NEW WHERE
                        GroupID IN (SELECT GroupID FROM SpecialGroupAccess WHERE UserID = " + UserInformation.UserID + @")
                        OR
                        ParentGroupID = " + UserInformation.ParentGroupID.ToString(CultureInfo.InvariantCulture).Replace("-1", "-99"));

            for (int i = 0; i < dtGetSpecialGroups.Rows.Count; i++)
            {
                userGroups += "," + dtGetSpecialGroups.Rows[i]["GroupID"];
            }

            dtGetSpecialGroups.Dispose();

            return userGroups;
        }

        private bool ConvertRights(int right)
        {
            return right == 1;
        }

        private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserInformation.CurrentSite = cboSite.Text;

            if (cboSite.Text == @"REFPLUS")
            {
                _myParent.BackgroundImage = Properties.Resources.RefplusBack;
                _myParent.ChangeToSiteColor(Public.RefplusColor);
            }
            else if (cboSite.Text == @"ECOSAIRE")
            {
                _myParent.BackgroundImage = Properties.Resources.EcosaireBack;
                _myParent.ChangeToSiteColor(Public.EcosaireColor);
            }
            else
            {
                _myParent.BackgroundImage = null;
                _myParent.ChangeToSiteColor(Public.RefplusColor);
            }
            Public.ChangeColor(this);
        }
    }
}