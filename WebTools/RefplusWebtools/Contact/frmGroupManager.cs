using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RefplusWebtools.Contact
{
    public partial class frmGroupManager : Form
    {

        private Hashtable hsGroupData = new Hashtable();

        public frmGroupManager()
        {
            InitializeComponent();
        }

        private void frmGroupManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            FillGroupList();
        }

        private void FillGroupList()
        {
            //clear the list
            lstGroup.Items.Clear();

            //get from database the list
            DataTable dtGroup = Query.Select("SELECT * FROM ContactGroup ORDER BY GroupName ASC");

            //for each group add it ot the list
            foreach (DataRow drGroup in dtGroup.Rows)
            {
                //glacial list item
                GlacialComponents.Controls.GLItem MyItem = new GlacialComponents.Controls.GLItem(lstGroup);

                //set the column value to display
                MyItem.SubItems[0].Text = drGroup["GroupID"].ToString();
                MyItem.SubItems[1].Text =drGroup["GroupName"].ToString();
                MyItem.SubItems[2].Text = drGroup["DefaultMultiplier"].ToString();

                //add to hashtable the whole data so later on i can compare what 
                //has changed so i can know if we need to update or not.
                hsGroupData.Add(Convert.ToInt32(drGroup["GroupID"]), drGroup.ItemArray);

                //add the item to the list
                lstGroup.Items.Add(MyItem);
            }

            //refresh the list
            lstGroup.Refresh();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAddNewGroup_Click(object sender, EventArgs e)
        {
            //create a new item and use "[new]" as groupid so when i loop throught it when
            //trying to save i know i need to do an insert instead of update query
            GlacialComponents.Controls.GLItem MyItem = new GlacialComponents.Controls.GLItem(lstGroup);

            //set the values
            MyItem.SubItems[0].Text ="[New]";
            MyItem.SubItems[1].Text = "Enter Group Name";
            MyItem.SubItems[1].Text = Public.DefaultMultiplier.ToString();

            //add the item to the list
            lstGroup.Items.Add(MyItem);

            //this just scroll down to the end of the list where the new grouphave just been created
            //like that it's easier for them to fill the information
            lstGroup.SetScroll(lstGroup.Items.Count - 2);
            lstGroup.Refresh();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            //i decided to add a transaction to speed up the queries
            string strTSQL = "";

            strTSQL += "BEGIN TRANSACTION ";

            //loop for all item in the list
            for (int irow = 0; irow < lstGroup.Items.Count; irow++)
            {
                //if the groupid is "[new]" it's an insert since it doesnt exist yet
                //so no need to compare for changes
                if (lstGroup.Items[irow].SubItems[0].Text == "[New]")
                {//insert
                    strTSQL += " INSERT INTO ContactGroup (GroupName, DefaultMultiplier) VALUES ('" + lstGroup.Items[irow].SubItems[1].Text.Replace("'", "''") + "'," + lstGroup.Items[irow].SubItems[2].Text.Replace("'", "''") + ")";
                }
                else
                {//update
                    //here a bit more tricky. i don't want the update query to run for all item.
                    //so i'll compare with what the hashtable contains to see if any changes happened.
                    //only in case of change i update the record
                    bool RecordChanged = false;

                    //create object array because the object value saved in the hashtable is the datarow.itemarray of
                    //the table used to fill the list
                    object[] objData = (object[])hsGroupData[Convert.ToInt32(lstGroup.Items[irow].SubItems[0].Text)];

                    //now compare all fields i'm looking for
                    //by looking for any difference
                    if (objData[1].ToString() != lstGroup.Items[irow].SubItems[1].Text ||
                        Convert.ToDecimal(objData[2]) != Convert.ToDecimal(lstGroup.Items[irow].SubItems[2].Text))
                    {
                        //something is not the same, so we need to update the record
                        RecordChanged = true;
                    }

                    if (RecordChanged)
                    {
                        //update
                        strTSQL += " UPDATE ContactGroup SET GroupName = '" + lstGroup.Items[irow].SubItems[1].Text.Replace("'", "''") + "', DefaultMultiplier = " + lstGroup.Items[irow].SubItems[2].Text.Replace("'", "''") + " WHERE GroupID = " + lstGroup.Items[irow].SubItems[0].Text;
                    }
                }
            }

            strTSQL += " COMMIT TRANSACTION";

            if (Query.Execute(strTSQL))
            {
                Public.LanguageBox("Changes saved", "Changement sauvegardé");
                this.Close();
            }
            else
            {
                Public.LanguageBox("An error occured while trying to save changes.", "Une erreure est survenu pendant la sauvegarde.");
            }

        }

        private void lstGroup_ItemChangedEvent(object source, GlacialComponents.Controls.ChangedEventArgs e)
        {
            //i am looking for a subitem change event
            if (e.ChangedType == GlacialComponents.Controls.ChangedTypes.SubItemChanged)
            {
                //we only want to validate the multiplier. so we jsut wnat to make sure it's a number
                try
                {
                    Convert.ToDecimal(e.Item.SubItems[2].Text);
                }
                catch
                {
                    //if it crash it's not a number put it to default
                    e.Item.SubItems[2].Text = Public.DefaultMultiplier.ToString();
                    Public.LanguageBox("Invalid multiplier.\nDefaulting to REFPLUS defaults.", "Multiplicateur invalide.\nRemise au multiplicateur par defaut de REFPLUS.");
                }
            }
        }
    }
}