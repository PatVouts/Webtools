using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.Contact
{
    public partial class FrmContactInformations : Form
    {
        private readonly int _contactID = -1;
        private readonly int _highlightedContactID = -1;

        public FrmContactInformations(int contactID, int highlightedContactID)
        {
            InitializeComponent();
            _contactID = contactID;
            _highlightedContactID = highlightedContactID;
        }

       
        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void frmContactInformations_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            cboCountry.SelectedIndex = 0;

            FillGroupList();

            //if we are loading
            if (_contactID != -1)
            {
                DataRow drContactInfo = Public.GetContactInfo(_contactID);
                txtName.Text = drContactInfo["Name"].ToString();
                txtTitle.Text = drContactInfo["Title"].ToString();
                txtCompany.Text = drContactInfo["CompanyName"].ToString();
                txtPhone.Text = drContactInfo["Phone"].ToString();
                txtPhoneExt.Text = drContactInfo["PhoneExt"].ToString();
                txtCellphone.Text = drContactInfo["Cellphone"].ToString();
                txtFax.Text = drContactInfo["Fax"].ToString();
                txtEmail.Text = drContactInfo["Email"].ToString();
                txtWebsite.Text = drContactInfo["Website"].ToString();
                txtStreet.Text = drContactInfo["Street"].ToString();
                txtCity.Text = drContactInfo["City"].ToString();
                txtState.Text = drContactInfo["State"].ToString();

                if (cboCountry.FindString(drContactInfo["Country"].ToString()) >= 0)
                {
                    cboCountry.SelectedIndex = cboCountry.FindString(drContactInfo["Country"].ToString());
                }
                else
                {
                    cboCountry.SelectedIndex = cboCountry.FindString("Other");
                    txtCountry.Text = drContactInfo["Country"].ToString();
                }

                txtZip.Text = drContactInfo["Zip"].ToString();
                txtComment.Text = drContactInfo["Comment"].ToString();
                ComboBoxControl.SetIDDefaultValue(cboGroup, drContactInfo["GroupID"].ToString());
                
                if (ContactIsUser())
                {
                    if (UserInformation.RequiredPermissionLevel(90))
                    {
                        //all permission on the contact since admin or internal sales (level 90++)
                    }
                    else
                    {
                        Public.LanguageBox("This contact is also a user. You are not allowed to change his informations", "Ce contact est aussi un utilisateur. Vous ne pouvez pas changer ces informations");
                    }
                }
            }
            else
            {
                if (_highlightedContactID != -1)
                {
                    //if a contact was highlighted and we are creating new we load up same company info
                    //i.e. company name, adress, group...
                    DataRow drContactInfo = Public.GetContactInfo(_highlightedContactID);
                    txtCompany.Text = drContactInfo["CompanyName"].ToString();
                    txtPhone.Text = drContactInfo["Phone"].ToString();
                    txtFax.Text = drContactInfo["Fax"].ToString();
                    txtWebsite.Text = drContactInfo["Website"].ToString();
                    txtStreet.Text = drContactInfo["Street"].ToString();
                    txtCity.Text = drContactInfo["City"].ToString();
                    txtState.Text = drContactInfo["State"].ToString();

                    if (cboCountry.FindString(drContactInfo["Country"].ToString()) >= 0)
                    {
                        cboCountry.SelectedIndex = cboCountry.FindString(drContactInfo["Country"].ToString());
                    }
                    else
                    {
                        cboCountry.SelectedIndex = cboCountry.FindString("Other");
                        txtCountry.Text = drContactInfo["Country"].ToString();
                    }

                    txtZip.Text = drContactInfo["Zip"].ToString();
                    ComboBoxControl.SetIDDefaultValue(cboGroup, drContactInfo["GroupID"].ToString());
                }
            }
        }

        public void FillGroupList()
        {
            DataTable dtGroup = Query.Select("SELECT * FROM ContactGroup_NEW WHERE Site = '" + UserInformation.CurrentSite + "' AND Deleted = 0 " + (UserInformation.RequiredPermissionLevel(90) ? "" : " AND GroupID IN (" + UserInformation.UserGroups + ")") + " ORDER BY GroupName ASC");

            for (int iGroup = 0; iGroup < dtGroup.Rows.Count; iGroup++)
            {
                ComboBoxControl.AddItem(cboGroup, dtGroup.Rows[iGroup]["GroupID"].ToString(), dtGroup.Rows[iGroup]["GroupName"].ToString());
            }

            cboGroup.SelectedIndex = 0;
        }

        private void cmdCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void picEmail_Click(object sender, EventArgs e)
        {
            //if the email is valid
            if (Public.IsEmailValid(txtEmail.Text))
            {
                //open default Email software and fill the "TO"
                System.Diagnostics.Process.Start("mailto:" + txtEmail.Text);
            }
            else
            {
                Public.LanguageBox("The email is not valid", "Le courriel indiqué n'est pas valide");
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveContact();
        }

        private void SaveContact()
        {
            bool saveContact = true;

            if (ContactIsUser())
            {
                if (UserInformation.RequiredPermissionLevel(90))
                {
                    //all permission on the contact since admin or internal sales (level 90++)
                }
                else
                {
                    saveContact = false;
                    Public.LanguageBox("This contact is also a user. You are not allowed to change his informations", "Ce contact est aussi un utilisateur. Vous ne pouvez pas changer ces informations");
                }
            }

            //extrenal sales
            if (UserInformation.ExactRequiredPermission(80) && saveContact)
            {
                saveContact = false;
                Public.LanguageBox("External sales are not allowed to create or modify a contact", "Les ventes externes ne sont pas autorisées à créer ou modifier un contact");
            }

            if (saveContact)
            {
                if (MessageBox.Show(Public.LanguageString("Are you sure you want to save this contact ?", "Êtes-vous sûr de vouloir sauvegarder ce contact ?"), Public.LanguageString("Save contact", "Sauvegarder le contact"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (CheckIfFieldsFilled())
                    {
                        ThreadProcess.Start(Public.LanguageString("Saving contact", "Sauvegarde du contact"));
                        string tsql = _contactID == -1 ? GetInsertString() : GetUpdateString();

                        if (Query.Execute(tsql))
                        {
                            ThreadProcess.Stop();
                            Focus();
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            Close();
                        }
                        else
                        {
                            ThreadProcess.Stop();
                            Focus();
                            Public.LanguageBox("An error occured while saving", "Une erreur est survenue lors de la sauvegarde");
                            Close();
                        }
                    }
                }
            }
        }

        private string GetUpdateString()
        {
            string tsql = "UPDATE Contact_NEW SET " + "GroupID = " + GetGroupID() + ",";
            tsql += "Name = '" + txtName.Text.Replace("'","''") + "',";
            tsql += "Title = '" + txtTitle.Text.Replace("'", "''") + "',";
            tsql += "CompanyName = '" + txtCompany.Text.Replace("'", "''") + "',";
            tsql += "Phone = '" + txtPhone.Text.Replace("'", "''") + "',";
            tsql += "PhoneExt = '" + txtPhoneExt.Text.Replace("'", "''") + "',";
            tsql += "Cellphone = '" + txtCellphone.Text.Replace("'", "''") + "',";
            tsql += "Fax = '" + txtFax.Text.Replace("'", "''") + "',";
            tsql += "Email = '" + txtEmail.Text.Replace("'", "''") + "',";
            tsql += "Website = '" + txtWebsite.Text.Replace("'", "''") + "',";
            tsql += "Street = '" + txtStreet.Text.Replace("'", "''") + "',";
            tsql += "City = '" + txtCity.Text.Replace("'", "''") + "',";
            tsql += "State = '" + txtState.Text.Replace("'", "''") + "',";
            tsql += "Country = '" + txtCountry.Text.Replace("'", "''") + "',";
            tsql += "Zip = '" + txtZip.Text.Replace("'", "''") + "',";
            tsql += "Comment = '" + txtComment.Text.Replace("'", "''") + "'";
            tsql += " WHERE ContactID = " + _contactID;

            return tsql;
        }

        //Method to find the ID of the group a specific contact is to be assigned to
        private int GetGroupID()
        {
            //Since the index of the group is also the order of the comboBox list, we can just return the index of the selected group and we have the groupID.
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboGroup));
        }

        //Builds the correct insert string whenever we need to add the contact in the table of contacts.
        private string GetInsertString()
        {
            //Getting all the required values from the form, replacing '  with '' to make sure the string managers parses it as a "'" for the sql.
             string tsql = "INSERT INTO Contact_NEW (GroupID,Name,Title,CompanyName,Phone,PhoneExt,Cellphone,Fax,Email,Website,Street,City,State,Country,Zip,Comment,CreatedBy,CreatedByGroup)";
             tsql += "VALUES (";
             tsql += GetGroupID() + ",";
             tsql += "'" + txtName.Text.Replace("'","''") + "',";
             tsql += "'" + txtTitle.Text.Replace("'","''") + "',";
             tsql += "'" + txtCompany.Text.Replace("'","''") + "',";
             tsql += "'" + txtPhone.Text.Replace("'","''") + "',";
             tsql += "'" + txtPhoneExt.Text.Replace("'","''") + "',";
             tsql += "'" + txtCellphone.Text.Replace("'","''") + "',";
             tsql += "'" + txtFax.Text.Replace("'","''") + "',";
             tsql += "'" + txtEmail.Text.Replace("'","''") + "',";
             tsql += "'" + txtWebsite.Text.Replace("'","''") + "',";
             tsql += "'" + txtStreet.Text.Replace("'","''") + "',";
             tsql += "'" + txtCity.Text.Replace("'","''") + "',";
             tsql += "'" + txtState.Text.Replace("'","''") + "',";
             tsql += "'" + txtCountry.Text.Replace("'","''") + "',";
             tsql += "'" + txtZip.Text.Replace("'","''") + "',";
             tsql += "'" + txtComment.Text.Replace("'","''") + "',";
             tsql += UserInformation.UserID + ",";
             tsql += UserInformation.GroupID + ")";
             return tsql;
        }

        //Only information mandatory is the name.  If you don't have a name, warn the user and return false
        private bool CheckIfFieldsFilled()
        {
            if (txtName.Text == "")
            {
                Public.LanguageBox("You must input a name for the contact", "Vous devez entrer le nom du contact");
                return false;
            }

            return true;
        }

        //Checks if the contact ID the administrator is currently editing is also a user
        private bool ContactIsUser()
        {
            //Since userID = contactID if it exists, look up which users have this ID
            DataTable dtUser = Query.Select("SELECT * FROM UserAccount_NEW WHERE UserID = " + _contactID);
            
            //if a user exists return true, if not return false
            return dtUser.Rows.Count == 1;
        }

        //Checks everytime the country of a given user changes.  If the country is "other", we need to add a "specify : " label and the txtbox associated
        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCountry.Text = cboCountry.Text;

            //show specify only on "other" as a country
            txtCountry.Visible = (cboCountry.Text == @"Other");
            lblSpecify.Visible = txtCountry.Visible;

        }

        // If user presses F1, summons the help files for this form
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        //Summons the help files for the form you're in.
        private void frmContactInformations_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}