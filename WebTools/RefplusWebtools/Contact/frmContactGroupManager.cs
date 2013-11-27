using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RefplusWebtools.Contact
{
    public partial class FrmContactGroupManager : Form
    {
        private TreeNode _oldNode;

        //Basic constructor, initializing components on form
        public FrmContactGroupManager()
        {
            InitializeComponent();
        }

        //when you drag and drop a group from the group list to the group relations, it links them together.
        private void lvGroups_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string strGroupID = ((ListViewItem)e.Item).SubItems[0].Text;
            lvGroups.DoDragDrop(strGroupID, DragDropEffects.Link);
        }

        //Standard load.  Starts by changing the color and the language according to the user's parameters, then fill the two lists with the data
        private void frmContactGroupManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
            //FIlls the tables with the existing data from the base
            FillGroups();
            FillParentGrouping();
        }

        //WHen entering (tab or click) a text box, autoselect the text in it
        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        //auto-select content of numerical up and down on tab or click
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        //Method to refresh the leftmost panel, showing every group relating to the site you're in.
        private void FillGroups()
        {

            //we start by clearing the list and the combobx
            lvGroups.Items.Clear();
            cboGroupName.Items.Clear();

            // we select all in the current site that aren't deleted.
            DataTable dtGroup = Query.Select("SELECT * FROM ContactGroup_NEW WHERE Site = '" + UserInformation.CurrentSite + "' AND Deleted = 0 ORDER BY GroupName ASC");
            //default group
            ComboBoxControl.AddItem(cboGroupName, "[ADD NEW]", "[ADD NEW]");
            //looping on every group name to add it to both the combobox and the list of groups
            for (int iGroup = 0; iGroup < dtGroup.Rows.Count; iGroup++)
            {
                lvGroups.Items.Add(new ListViewItem(new[] { dtGroup.Rows[iGroup]["GroupID"].ToString(), dtGroup.Rows[iGroup]["GroupName"].ToString(), dtGroup.Rows[iGroup]["DefaultMultiplier"].ToString() }));
                ComboBoxControl.AddItem(cboGroupName, dtGroup.Rows[iGroup]["GroupID"] + "|" + dtGroup.Rows[iGroup]["DefaultMultiplier"], dtGroup.Rows[iGroup]["GroupName"].ToString());
            }
            //selecting the default group
            cboGroupName.SelectedIndex = 0;
        }

        //When you release a drag and drop from the group to the group relations
        private void tvParentGrouping_DragDrop(object sender, DragEventArgs e)
        {
            //That boolean will switch to true if something worth changing the display happens.  
            bool bolRefresh = false;

            //if there is a node with different colors, revert them to normal
            if (_oldNode != null)
            {
                _oldNode.BackColor = Color.White;
                _oldNode.ForeColor = Color.Black;
            }

            //Find the click point
            Point clickPoint = PointToScreen(tvParentGrouping.Location);
            clickPoint.X = e.X - clickPoint.X;
            clickPoint.Y = e.Y - clickPoint.Y;
            TreeNode aNode = tvParentGrouping.GetNodeAt(clickPoint);

            //if there is a node where we released our drag and drop
            if (aNode != null)
            {
                //if it's a parentless group
                if (aNode.Level == 0)
                {
                    //Get the dragged group
                    string strGroupID = e.Data.GetData(typeof(string)).ToString();

                    //Find all info pertaining to the group
                    DataTable dtGetGroupData = Query.Select("SELECT * FROM ContactGroup_NEW WHERE GroupID = " + strGroupID);
                    string strGroupName = dtGetGroupData.Rows[0]["GroupName"].ToString();

                    //if the dragged group's id is the same as the dropped group's, we cannot add, since it's adding a group to itself
                    if (strGroupID == aNode.Tag.ToString())
                    {
                        Public.LanguageBox("Cannot assign a group to itself", "Vous ne pouvez pas assigner un groupe à lui-même");
                    }
                    else
                    {
                        //if dragged group is not a sub group
                        if (Convert.ToInt32(dtGetGroupData.Rows[0]["ParentGroupID"]) == -1)
                        {
                            //check if the dragged group have sub groups
                            DataTable dtGetSubGroupData = Query.Select("SELECT * FROM ContactGroup_NEW WHERE ParentGroupID = " + strGroupID);

                            //if there's at least one row, we have a parent group, so it cannot be added as a subgroup to anything.
                            if (dtGetSubGroupData.Rows.Count > 0)
                            {
                                Public.LanguageBox("This group " + strGroupName + " is already a parent group it cannot be a sub group", "Le groupe " + strGroupName + " est déja un groupe parent il ne peut donc pas être un sous-groupe.");
                            }
                            else
                            {
                                //checking if there is a contact in the parent group.  A parent group can only have subgroups, it cannot have contacts associated to it.
                                DataTable dtGetDraggedToGroupContactData = Query.Select("SELECT * FROM Contact_NEW WHERE GroupID = " + aNode.Tag);

                                if (dtGetDraggedToGroupContactData.Rows.Count > 0)
                                {
                                    Public.LanguageBox("The group " + aNode.Text + " contains contacts. It cannot become a parent group.", "Le groupe " + aNode.Text + " contient des contacts. Il ne peut donc pas devenir un groupe parent.");
                                }
                                else
                                {
                                    //check if someone had permission on the future parent because
                                    //that cannot be done.  It means the group is associated to a user in a "special" way (as in linked to an external rep), so it cannot become a parent.
                                    DataTable dtGetDraggedToGroupSpecialPermission = Query.Select("SELECT * FROM SpecialGroupAccess WHERE GroupID = " + aNode.Tag);

                                    if (dtGetDraggedToGroupSpecialPermission.Rows.Count > 0)
                                    {
                                        Public.LanguageBox("The group " + aNode.Text + " has a user with special access attached to it. It cannot become a parent group.", "Le groupe " + aNode.Text + " contient un utilisateur avec des accès speciaux. Il ne peut donc pas devenir un groupe parent.");
                                    }
                                    else
                                    {
                                        //Last check : making sure there is no quotes associated to that group.
                                        DataTable dtGetGroupQuotes = Query.Select("SELECT * FROM QuoteData WHERE QuotationByGroupID = " + aNode.Tag + " OR GroupID = " + aNode.Tag);

                                        if (dtGetGroupQuotes.Rows.Count > 0)
                                        {
                                            Public.LanguageBox("the group " + aNode.Text + " cannot become a parent group because it have quotes attached to it", "Le groupe " + aNode.Text + " ne peut etre devenir un groupe parent car il y a des soumission de rattachées à celui-ci.");
                                        }
                                        //Means we're good to go
                                        else
                                        {
                                            //add group parent to be the same as where we drop it.
                                            Query.Execute("UPDATE ContactGroup_NEW SET ParentGroupID = " + aNode.Tag + " WHERE GroupID = " + strGroupID);
                                            bolRefresh = true;
                                        }
                                    }
                                }
                            }
                        }
                        //Cannot add to child groups
                        else
                        {
                            Public.LanguageBox("The group " + strGroupName + " is already a sub group of another parent group. You must detach it from the parent group first", "Le groupe " + strGroupName + " est déja un sous groupe rattacher a un groupe parent. Vous devez le détacher de son parent d'abord.");
                        }
                    }
                }
            }

            //if a relationship was added, we need to refresh the list of relations
            if (bolRefresh)
            {
                FillParentGrouping();
            }
        }

        //Passing the link effect to the dragEvent.
        private void tvParentGrouping_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        //Whenever you drag over a parent, the text goes white and the back color goes blue
        private void tvParentGrouping_DragOver(object sender, DragEventArgs e)
        {
            //Passing the link effect to the event.
            e.Effect = DragDropEffects.Link;
       
            //Finding the right position to gind the parent node.
            Point clickPoint = PointToScreen(tvParentGrouping.Location);
            clickPoint.X = e.X - clickPoint.X;
            clickPoint.Y = e.Y - clickPoint.Y;

            TreeNode aNode = tvParentGrouping.GetNodeAt(clickPoint);
            
            //if there is a parent selected, change it's colors.
            if (aNode != null)
            {
                if (aNode.Level == 0)
                {
                    aNode.BackColor = Color.DarkBlue;
                    aNode.ForeColor = Color.White;

                    //Reverting the "old node" we selected previously to its default colors
                    if ((_oldNode != null) && (_oldNode != aNode))
                    {
                        _oldNode.BackColor = Color.White;
                        _oldNode.ForeColor = Color.Black;
                    }
                    _oldNode = aNode;
                }

            }
        }

        //Filling the relationship's list
        private void FillParentGrouping()
        {
            //Clearing the group
            tvParentGrouping.Nodes.Clear();

            //Make a list of parentless groups to show at the top level
            DataTable dtGroupWithNoParent = Query.Select("SELECT parents.GroupName as pGroupName, parents.GroupID as pGroupID, COUNT(child.GroupName) as childrenC  FROM RefplusWebtools.dbo.ContactGroup_NEW as parents left outer join RefplusWebtools.dbo.ContactGroup_NEW as child on parents.GroupID = child.ParentGroupID and parents.Site = child.Site and parents.Deleted = child.Deleted WHERE parents.ParentGroupID = -1 AND parents.Site = 'REFPLUS' AND parents.Deleted = 0 group by parents.GroupID, parents.GroupName ORDER BY parents.GroupName ASC");
            //Foreach parentless group, check if that group has some children.
            for (int iGroupWithNoParent = 0; iGroupWithNoParent < dtGroupWithNoParent.Rows.Count; iGroupWithNoParent++)
            {
                //Create a tree level node for the parentless group.
                var tn = new TreeNode
                {
                    Text = dtGroupWithNoParent.Rows[iGroupWithNoParent]["pGroupName"].ToString(),
                    Tag = dtGroupWithNoParent.Rows[iGroupWithNoParent]["pGroupID"].ToString()
                };

                if (dtGroupWithNoParent.Rows[iGroupWithNoParent]["childrenC"].ToString() != "0")
                {
                    DataTable dtChildGroup = Query.Select("SELECT * FROM ContactGroup_NEW WHERE ParentGroupID = " + dtGroupWithNoParent.Rows[iGroupWithNoParent]["pGroupID"] + " AND Site = '" + UserInformation.CurrentSite + "' AND Deleted = 0 ORDER BY GroupName ASC");
                    for (int iChild = 0; iChild < dtChildGroup.Rows.Count; iChild++)
                    {
                        //Create a new treenode for the children of the parentless group and add it one level below.
                        var tnChild = new TreeNode
                        {
                            Text = dtChildGroup.Rows[iChild]["GroupName"].ToString(),
                            Tag = dtChildGroup.Rows[iChild]["GroupID"].ToString()
                        };
                        tn.Nodes.Add(tnChild);
                    }
                }
                //Add the hierarchy created to the relations
                tvParentGrouping.Nodes.Add(tn);

            }
            //Expand every parent so we see the children.
            tvParentGrouping.ExpandAll();
        }

        //When you release a mouse button (not on key pressed to make sure the drag and drop works), this calls the right contextual menu.
        private void tvParentGrouping_MouseUp(object sender, MouseEventArgs e)
        {
            //if the button is the right one, we call the menu, if not, we call nothing.
            if (e.Button == MouseButtons.Right)
            {
                //Make sure we get the group "targeted"
                TreeNode aNode = tvParentGrouping.GetNodeAt(e.X, e.Y);

                if (aNode != null)
                {
                    //if it's not a parent  (then it's a child)
                    if (aNode.Level != 0)
                    {
                        //we select the group at the right position
                        tvParentGrouping.SelectedNode = aNode;
                        tvParentGrouping.Select();

                        Point clickPoint = PointToScreen(tvParentGrouping.Location);
                        //Changing the contextual menu to show unattach
                        tsUnAttach.Visible = true;
                        tsDelete.Visible = false;
                        //show the contextual menu at the right point.
                        contextParentGroupList.Show(clickPoint.X + e.X, clickPoint.Y + e.Y);
                    }
                }
            }
        }

        //When right-clicking on the relations tab, you have a choice to unattach.  If you click on it, this method is called.  
        private void tsUnAttach_Click(object sender, EventArgs e)
        {
            //Validating the user wants to unattach
            if (Public.LanguageQuestionBox("Are you sure you want to unattach this group ?", "Êtes-vous sûr de vouloir détacher ce groupe ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string strGroupID = tvParentGrouping.SelectedNode.Tag.ToString();
                //Updating the table so the group isn't attached anymore.
                Query.Execute("UPDATE ContactGroup_NEW SET ParentGroupID = -1 WHERE GroupID = " + strGroupID);
                //Refresh the list for the Relationships 
                FillParentGrouping();
            }
        }

        //closes form
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Method called whenever the selected index of the combobox containing all group names changes.
        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if the group selected is "ADD NEW", means the user wants to create a group, so we can reset the multiplier to default and the text to something indicative of the needed change
            if (cboGroupName.Text == @"[ADD NEW]")
            {
                txtGroupName.Text = @"[Enter Group Name]";
                numMultiplier.Value = 0.65m;
            }
            else
            {
                //if the user selected an existing group, load the values of the group in the form
                txtGroupName.Text = cboGroupName.Text;
                //since the combobox contains both 
                numMultiplier.Value = Convert.ToDecimal(ComboBoxControl.IndexInformation(cboGroupName).Split('|')[1]);
            }
        }

        //Simple validation of intent, then save using the save method
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save ?", "Etes-vous sûr de vouloir sauvegarder ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Save();
            }
        }

        //Method to save the changes in group to the database
        private void Save()
        {
            //start by validating fields and then save them
            if (ValidFields())
            {
                //If something happens to change the group lists, we'll need a reload.  This boolean manages that
                bool reload = false;

                if (cboGroupName.Text == @"[ADD NEW]")
                {//insert
                    if (Query.Select("SELECT * FROM ContactGroup_NEW WHERE GroupName = '" + txtGroupName.Text.Replace("'", "''") + "'").Rows.Count > 0)
                    {
                        Public.LanguageBox("Group name already exist.", "Le nom du groupe existe déja.");
                    }
                    else
                    {
                        if (Query.Execute("INSERT INTO ContactGroup_NEW ([ParentGroupID],[GroupName],[Site],[DefaultMultiplier],[Deleted]) VALUES (-1,'" + txtGroupName.Text.Replace("'", "''") + "','" + UserInformation.CurrentSite + "'," + numMultiplier.Value + ",0)"))
                        {
                            Public.LanguageBox("Save successful", "Sauvegarde réussie");
                            reload = true;
                        }
                    }
                }
                else
                {//update
                    if (Query.Execute("UPDATE ContactGroup_NEW SET GroupName = '" + txtGroupName.Text.Replace("'", "''") + "', DefaultMultiplier = " + numMultiplier.Value + " WHERE GroupID = " + ComboBoxControl.IndexInformation(cboGroupName).Split('|')[0]))
                    {
                        Public.LanguageBox("Save successful", "Sauvegarde réussie");
                        reload = true;
                    }
                }

                //If a line was inserted or updated in the contactGroup table, we made an update, so we need a full reload.
                if (reload)
                {
                    FillGroups();
                    FillParentGrouping();
                }
            } 
        }

        //Validating the fields before a save, making sure the group name is ok (doesn't contain any quotation mark OR contains only white spaces)
        private bool ValidFields()
        {
            if (txtGroupName.Text.Trim() == "" || txtGroupName.Text.Contains("\""))
            {
                Public.LanguageBox("Please enter a valid group name, without any quotation mark. Thank you!", "Veuillez entrer un nom de groupe valide, sans aucun guillement. Merci!");
                return false;
            }
            return true;
        }

        //When the user right clicks on the left panel and chooses delete, it calls this method.
        private void tsDelete_Click(object sender, EventArgs e)
        {
            //Validating the intent
            if (Public.LanguageQuestionBox("Are you sure you want to delete this group ?", "Êtes-vous sûr de vouloir supprimer ce groupe ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Checking if group has quotations attached to it
                string strGroupID = lvGroups.SelectedItems[0].SubItems[0].Text;
                DataTable dtGetGroupQuotes = Query.Select("SELECT * FROM QuoteData WHERE QuotationByGroupID = " + strGroupID + " OR GroupID = " + strGroupID);

                if (dtGetGroupQuotes.Rows.Count > 0)
                {
                    Public.LanguageBox("This group cannot be deleted because it has quotes attached to it", "Ce groupe ne peut être supprimé car il a des soumission de rattachées à lui");
                }
                else
                {
                    //Check if the group has other users attached to it.
                    DataTable dtGetGroupContact = Query.Select("SELECT * FROM Contact_NEW WHERE GroupID = " + strGroupID);

                    if (dtGetGroupContact.Rows.Count > 0)
                    {
                        Public.LanguageBox("This group cannot be deleted because it has contacts attached to it.", "Ce groupe ne peut être supprimé car il a des contacts d'attachés à lui.");
                    }
                    else
                    {
                        //check if the user is a parent group (selecting all groups with it as a parent)
                        DataTable dtGetGroupInfo = Query.Select("SELECT * FROM ContactGroup_NEW WHERE ParentGroupID = " + strGroupID);

                        if (dtGetGroupInfo.Rows.Count != 0)
                        {
                            Public.LanguageBox("Cannot delete a parent group.", "Il est impossible de supprimer un groupe parent");
                        }
                        else
                        {
                            //Deleting the group then refreshing both panels
                            Query.Execute("DELETE FROM ContactGroup_NEW WHERE GroupID = " + strGroupID);

                            FillGroups();
                            FillParentGrouping();
                        }
                    }
                }
            }
        }

        //When you release a mouse button (on up instead of pressed for the drag and drop to still work)
        private void lvGroups_MouseUp(object sender, MouseEventArgs e)
        {
            //if you're right-clicking
            if (e.Button == MouseButtons.Right)
            {
                //Getting the item targeted by the mouse
                ListViewItem myItem = lvGroups.GetItemAt(e.X, e.Y);

                //if you are on an item
                if (myItem != null)
                {
                    //Select the item, call the method to select in the group
                    myItem.Selected = true;
                    lvGroups.Select();
                    Point clickPoint = PointToScreen(lvGroups.Location);
                    //Make sure the unattach goes away and the delete is shown
                    tsUnAttach.Visible = false;
                    tsDelete.Visible = true;
                    //summon the contextual menu at the right spot
                    contextParentGroupList.Show(clickPoint.X + e.X, clickPoint.Y + e.Y);
                }
            }
        }

        //Opens the special group permission form whenever the user requests it.  
        private void cmdManageSpecialGroupPermission_Click(object sender, EventArgs e)
        {
            var frmSpecialPermission = new FrmSpecialGroupPermission();
            frmSpecialPermission.ShowDialog();
        }

        // If user presses F1, summons the help files for this form
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        //Summons the help files for the form you're in.
        private void frmContactGroupManager_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}