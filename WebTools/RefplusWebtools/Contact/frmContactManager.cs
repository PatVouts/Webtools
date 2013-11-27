using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace RefplusWebtools.Contact
{
    public partial class FrmContactManager : Form
    {
        private readonly bool _bolOpenedFromQuote;
        private int _intSelectedContactID = -1;
        private readonly Color _colorForContactThatAreUser = Color.LightPink;

        readonly List<Label> _letterFilter = new List<Label>();

        public FrmContactManager()
        {
            InitializeComponent();
        }

        public FrmContactManager(bool openedFromQuote)
        {
            InitializeComponent();
            _bolOpenedFromQuote = openedFromQuote;
        }

        private void frmContactManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillLetterFilterLabels();

            SetSpecificLetterFilter("ALL");

            FillGroupList();

            ValidateUserManager();
        }

        private void ValidateUserManager()
        {
            if (UserInformation.AccessUserManager)
            {
                chkUserManagingMode.Visible = true;
            }
        }

        private string GetLetterFilterParameter()
        {
            string letterFilterParam = "";

            foreach (Label lbl in _letterFilter)
            {
                if (lbl.ForeColor == Color.Red)
                {
                    letterFilterParam = lbl.Text;
                }
            }

            if (letterFilterParam == "ALL")
            {
                letterFilterParam = "";
            }

            return letterFilterParam;
        }

        private void FillLetterFilterLabels()
        {
            BuildLetterLabelList();
            PositionLetterFilterLabels();
        }

        private void SetSpecificLetterFilter(string letter)
        {
            foreach (Label lbl in _letterFilter)
            {
                if (lbl.Text != letter)
                {
                    lbl.BorderStyle = BorderStyle.None;
                    lbl.ForeColor = Color.Blue;
                }
                else
                {
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.ForeColor = Color.Red;
                }
            }
        }

        private void PositionLetterFilterLabels()
        {
            int basePosition = (Width - (_letterFilter.Count * _letterFilter[0].Width)) / 2;

            for (int i = 0; i < _letterFilter.Count; i++)
            {
                Controls.Add(_letterFilter[i]);
                _letterFilter[i].Left = basePosition + (_letterFilter[i].Width * i);
                _letterFilter[i].Top = lblFilterByLetter.Top + lblFilterByLetter.Height;
            }
        }

        private Label GetLetterLabel(string strText)
        {
            var lbl = new Label
            {
                AutoSize = false,
                ForeColor = Color.Blue,
                Height = 20,
                Width = 28,
                Text = strText,
                TextAlign = ContentAlignment.MiddleCenter
            };
            lbl.Click += LetterLabel_Click;

            return lbl;
        }

        private void LetterLabel_Click(object sender, EventArgs e)
        {
            SetSpecificLetterFilter(((Label)sender).Text);
            RefreshContactList();
        }

        private void BuildLetterLabelList()
        {
            for (int i = 65; i <= 90; i++)
            {
                _letterFilter.Add(GetLetterLabel(char.ConvertFromUtf32(i)));
            }

            _letterFilter.Add(GetLetterLabel("ALL"));
        }

        private int GroupFilter()
        {
            return Convert.ToInt32(ComboBoxControl.IndexInformation(cboGroupList));
        }

        public void FillGroupList()
        {
            cboGroupList.Items.Clear();

            DataTable dtGroup = Query.Select("SELECT * FROM ContactGroup_NEW WHERE Site = '" + UserInformation.CurrentSite + "' AND Deleted = 0 " + (UserInformation.RequiredPermissionLevel(90) ? "" : " AND GroupID IN (" + UserInformation.UserGroups + ")") + " ORDER BY GroupName ASC");

            ComboBoxControl.AddItem(cboGroupList, "-99", "ALL");

            for (int iGroup = 0; iGroup < dtGroup.Rows.Count; iGroup++)
            {
                ComboBoxControl.AddItem(cboGroupList, dtGroup.Rows[iGroup]["GroupID"].ToString(), dtGroup.Rows[iGroup]["GroupName"].ToString());
            }

            cboGroupList.SelectedIndex = 0;
        }

        public void RefreshContactList()
        {
            ThreadProcess.Start(Public.LanguageString("Loading Contact List","Chargement de la liste des contacts"), 0);

            lstContact.Items.Clear();
            DataTable dtContact =
                Query.Select(@"SELECT 
                                Contact_NEW.*, 
                                ISNULL(UserAccount_NEW.UserID, 0) as 'UserID',
                                ContactGroup_NEW.* 
                            FROM Contact_NEW 
                            LEFT JOIN UserAccount_NEW on UserAccount_NEW.UserID = Contact_NEW.ContactID 
                            LEFT JOIN ContactGroup_NEW on Contact_NEW.GroupID = ContactGroup_NEW.GroupID 
                            WHERE ContactGroup_NEW.Deleted = 0 "
                                + GetGroupFilter()  +
                                @" AND Contact_NEW.Name Like '" + GetLetterFilterParameter() + @"%'" +
                                @" AND Contact_NEW.Deleted = 0 ORDER BY Contact_NEW.Name ASC");

            int intAmountOfContact = dtContact.Rows.Count;

            for (int icontact = 0; icontact < dtContact.Rows.Count; icontact++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstContact);
                myItem.SubItems[0].Text = dtContact.Rows[icontact]["ContactID"].ToString();
                myItem.SubItems[1].Text = dtContact.Rows[icontact]["Name"].ToString();
                myItem.SubItems[2].Text = dtContact.Rows[icontact]["Title"].ToString();
                myItem.SubItems[3].Text = dtContact.Rows[icontact]["CompanyName"].ToString();
                myItem.SubItems[4].Text = dtContact.Rows[icontact]["Phone"].ToString();
                myItem.SubItems[5].Text = dtContact.Rows[icontact]["PhoneExt"].ToString();
                myItem.SubItems[6].Text = dtContact.Rows[icontact]["Email"].ToString();
                myItem.SubItems[7].Control = CmdEditContact(dtContact.Rows[icontact]["ContactID"].ToString());
                myItem.BackColor = (Convert.ToInt32(dtContact.Rows[icontact]["UserID"]) != 0 ? _colorForContactThatAreUser : Color.White);
                lstContact.Items.Add(myItem);
                ThreadProcess.UpdateProgress(Convert.ToInt32(((icontact + 1m) / intAmountOfContact) * 100m));
            }
            lstContact.Refresh();

            ThreadProcess.Stop();
            Focus();
        }

        private string GetGroupFilter()
        {
            string strGroupFilter = "";

            
            if (GroupFilter() != -99)
            {//if specific group only pick from within
                strGroupFilter += " AND Contact_NEW.GroupID = " + GroupFilter();
            }
            else
            {// on all only pick on groups you have access to except internal
                if (!UserInformation.RequiredPermissionLevel(90))
                {
                    strGroupFilter += " AND Contact_NEW.GroupID IN (" + UserInformation.UserGroups + ")";
                }
            }

            if (UserInformation.ExactRequiredPermission(80))
            {
                strGroupFilter += " AND Contact_NEW.CreatedByGroup = " + UserInformation.CreatedByGroupID;
            }
            else if (UserInformation.RequiredPermissionLevel(90))
            {
                strGroupFilter += " AND Contact_NEW.CreatedByGroup = " + UserInformation.GroupID;
            }

            strGroupFilter += " AND ContactGroup_NEW.Site = '" + UserInformation.CurrentSite + "'";

            return strGroupFilter;
        }

      
        private Button CmdEditContact(string strContactID)
        {
            var cmd = new Button {Text = @"Edit", Tag = strContactID};
            cmd.Click += cmdEditContact_Click;
            return cmd;
        }

        private void cmdEditContact_Click(object sender, EventArgs e)
        {
            int intContactID = Convert.ToInt32(((Button)sender).Tag.ToString());

            if (intContactID == 1 && !UserInformation.ExactRequiredPermission(99))
            {
                Public.LanguageBox("Cannot modify administrator account", "Vous ne pouvez pas modifier le compte administrateur");
            }
            else
            {
                if (chkUserManagingMode.Checked)
                {
                    //open user edit mode
                    var frmUserInfo = new FrmUserInformations(intContactID);
                    frmUserInfo.ShowDialog();
                }
                else
                {
                    //open contact edit mode
                    var frmContactInfo = new FrmContactInformations(intContactID, -1);
                    frmContactInfo.ShowDialog();
                }
                RefreshContactList();
            }
        }

        private void cmdAddContact_Click(object sender, EventArgs e)
        {
            int highlightedContactID = -1;
            if (lstContact.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(Public.LanguageString("Do you want to create the new contact using company related information of highlighted contact as default ?", "Voulez-vous créer le nouveau contact en utilisant les informations reliées à la compagnie du contact surligné comme valeurs par défaut ?"), Public.LanguageString("Question", "Question"), MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    ArrayList arSelectedItems = lstContact.SelectedItems;
                    highlightedContactID = Convert.ToInt32(((GlacialComponents.Controls.GLItem)arSelectedItems[0]).SubItems[7].Control.Tag.ToString());
                }
            }


            var frmContactInfo = new FrmContactInformations(-1, highlightedContactID);
            frmContactInfo.ShowDialog();

            RefreshContactList();
        }

        private void cboGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if group selected is not all (probably a company) we select all in for the
            //name filter because it highly probable that the user want to see everyone if he
            //specificly selected a group.
            if (GroupFilter() != -99) SetSpecificLetterFilter("ALL");
            RefreshContactList();
        }

        private void lstContact_DoubleClick(object sender, EventArgs e)
        {
            if (_bolOpenedFromQuote)
            {
                if (lstContact.SelectedItems.Count > 0)
                {
                    ArrayList myItem = lstContact.SelectedItems;
                    _intSelectedContactID = Convert.ToInt32(((GlacialComponents.Controls.GLItem)myItem[0]).SubItems[0].Text);
                    DialogResult = DialogResult.Yes;
                    Close();
                }
            }
        }

        public int GetSelectedContactID()
        {
            return _intSelectedContactID;
        }

        private void cmdManageGroups_Click(object sender, EventArgs e)
        {
            if (UserInformation.RequiredPermissionLevel(90))
            {
                var frmParentSubGroupManager = new FrmContactGroupManager();
                frmParentSubGroupManager.ShowDialog();

                FillGroupList();
            }
            else
            {
                Public.NoPermissionMessage();
            }
        }

        private void lstContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstContact.SelectedItems.Count > 0 && UserInformation.RequiredPermissionLevel(90))
            {
                if (Public.LanguageQuestionBox("Are you sure you want to delete this contact ?", "Êtes vous sûr de vouloir supprimer ce contact ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool canDelete = true;

                    string strContactID = ((GlacialComponents.Controls.GLItem)lstContact.SelectedItems[0]).SubItems[0].Text;

                    DataTable dtUserInfo = Query.Select("SELECT * FROM UserAccount_NEW WHERE UserID = " + strContactID);

                    if (dtUserInfo.Rows.Count > 0)
                    {
                        if (UserInformation.AccessUserManager)
                        {
                            if (Public.LanguageQuestionBox("This contact is also a user. Are you sure you want to delete him ?", "Ce contact est aussi un utilisateur. Êtes vous sûr de vouloir le supprimer ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (Convert.ToInt32(dtUserInfo.Rows[0]["UserLevel"]) == 99)
                                {
                                    canDelete = false;
                                    Public.LanguageBox("Administrators cannot be deleted", "Les administrateurs ne peuvent pas être supprimés");
                                }
                            }
                            else
                            {
                                canDelete = false;
                            }
                        }
                        else
                        {
                            canDelete = false;
                            Public.LanguageBox("You do not have rights to delete a contact that is also a user", "Vous n'avez pas les droits nécessaire pour supprimer un contact qui est aussi un utilisateur");
                        }
                    }

                    if (canDelete)
                    {
                        Query.Execute("DELETE FROM Contact_NEW WHERE ContactID = " + strContactID);
                        Query.Execute("DELETE FROM UserAccount_NEW WHERE UserID = " + strContactID);
                        Query.Execute("DELETE FROM SpecialGroupAccess WHERE UserID = " + strContactID);

                        RefreshContactList();
                    }
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmContactManager_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}