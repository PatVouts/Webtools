using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.Contact
{
    public partial class FrmSpecialGroupPermission : Form
    {
        public FrmSpecialGroupPermission()
        {
            InitializeComponent();
        }

        private void frmSpecialGroupPermission_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_UserList();

            Fill_UnAssignedGroups();
        }

        private void Fill_UserList()
        {
            //select on external rep (level 80)
            DataTable dtUser = Query.Select(@"SELECT UserAccount_NEW.*, Contact_NEW.* FROM UserAccount_NEW 
                                              LEFT JOIN Contact_NEW ON UserAccount_NEW.UserID = Contact_NEW.ContactID 
                                              LEFT JOIN ContactGroup_NEW ON Contact_NEW.GroupID = ContactGroup_NEW.GroupID
                                              WHERE UserAccount_NEW.UserLevel = 80 
                                              AND ContactGroup_NEW.Site = '" + UserInformation.CurrentSite + @"'
                                              ORDER BY Name ASC");

            lstUser.Items.Clear();

            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstUser);

                myItem.SubItems[0].Text = dtUser.Rows[i]["UserID"].ToString();
                myItem.SubItems[1].Text = dtUser.Rows[i]["Name"].ToString();

                lstUser.Items.Add(myItem);
            }

            lstUser.Refresh();
        }

        private void Fill_UnAssignedGroups()
        {
            //select all unassigned group
            DataTable dtUnassignedGroup = Query.Select(@"SELECT t1.* FROM (
                                                         SELECT * FROM ContactGroup_NEW as cgn
                                                         WHERE
                                                         ParentGroupID <> -1
                                                         UNION
                                                         SELECT * FROM ContactGroup_NEW
                                                         WHERE
                                                         GroupID NOT IN (SELECT ParentGroupID FROM ContactGroup_NEW)) as t1
                                                         WHERE t1.GroupID NOT IN (SELECT GroupID FROM SpecialGroupAccess)
                                                         AND t1.Site = '" + UserInformation.CurrentSite + @"'
                                                         ORDER BY t1.GroupName ASC");

            lstUnassignedGroups.Items.Clear();

            for (int i = 0; i < dtUnassignedGroup.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstUnassignedGroups);

                myItem.SubItems[0].Text = dtUnassignedGroup.Rows[i]["GroupID"].ToString();
                myItem.SubItems[1].Text = dtUnassignedGroup.Rows[i]["GroupName"].ToString();

                lstUnassignedGroups.Items.Add(myItem);
            }

            lstUnassignedGroups.Refresh();
        }

        private void Fill_AssignedGroups()
        {
            lstAssignedGroups.Items.Clear();

            if (lstUser.SelectedItems.Count > 0)
            {
                string strUserID = ((GlacialComponents.Controls.GLItem)lstUser.SelectedItems[0]).SubItems[0].Text;

                //select all assigned group or a user
                DataTable dtAssignedGroup = Query.Select(@"SELECT * FROM ContactGroup_NEW 
                                                          WHERE GroupID IN (SELECT GroupID FROM SpecialGroupAccess WHERE UserID = " + strUserID + @")
                                                          AND Site = '" + UserInformation.CurrentSite + @"'
                                                          ORDER BY GroupName ASC");

                for (int i = 0; i < dtAssignedGroup.Rows.Count; i++)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lstAssignedGroups);

                    myItem.SubItems[0].Text = dtAssignedGroup.Rows[i]["GroupID"].ToString();
                    myItem.SubItems[1].Text = dtAssignedGroup.Rows[i]["GroupName"].ToString();

                    lstAssignedGroups.Items.Add(myItem);
                }
            }

            lstAssignedGroups.Refresh();
        }

        private void lstUser_Click(object sender, EventArgs e)
        {
            Fill_UnAssignedGroups();
            Fill_AssignedGroups();
        }

        private void picAdd_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        private void AddGroup()
        {
            //can only add if a user is selected AND an unassigned group is selected
            if (lstUser.SelectedItems.Count > 0 && lstUnassignedGroups.SelectedItems.Count > 0)
            {
                string strUserID = ((GlacialComponents.Controls.GLItem)lstUser.SelectedItems[0]).SubItems[0].Text;
                string strGroupID = ((GlacialComponents.Controls.GLItem)lstUnassignedGroups.SelectedItems[0]).SubItems[0].Text;

                Query.Execute("INSERT INTO SpecialGroupAccess (UserID, GroupID) VALUES (" + strUserID + ", " + strGroupID + ")");

                Fill_UnAssignedGroups();
                Fill_AssignedGroups();
            }
        }

        private void picRemove_Click(object sender, EventArgs e)
        {
            RemoveGroup();
        }

        private void RemoveGroup()
        {
            //can only remove if a user is selected AND an assigned group is selected
            if (lstUser.SelectedItems.Count > 0 && lstAssignedGroups.SelectedItems.Count > 0)
            {
                string strGroupID = ((GlacialComponents.Controls.GLItem)lstAssignedGroups.SelectedItems[0]).SubItems[0].Text;

                Query.Execute("DELETE FROM SpecialGroupAccess WHERE GroupID = " + strGroupID);

                Fill_UnAssignedGroups();
                Fill_AssignedGroups();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmSpecialGroupPermission_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}