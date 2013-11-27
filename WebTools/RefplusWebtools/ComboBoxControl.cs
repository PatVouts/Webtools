using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools
{
    class ComboBoxControl
    {
        /// <summary>
        /// Add and item to a combobox using an id and a text value
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="index"></param>
        /// <param name="text"></param>
        public static void AddItem(ComboBox cbo, string index, string text)
        {
            //create the combobox Item class
            var item = new CBOITEM();
            //set the display member and value member to bind the
            //combobox item to it
            cbo.DisplayMember = "Text";
            cbo.ValueMember = "ID";
            //create the combobox item
            item.CreateItem(text, index);
            //add the comboboxitem to the combobox
            cbo.Items.Add(item);
        }

        /// <summary>
        /// select the item that you are looking for by using the id value
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="defaultValue"></param>
        public static void SetIDDefaultValue(ComboBox cbo, string defaultValue)
        {
            //the value we want to select in the end
            string currentValue = defaultValue;
            //create the combobox Item class
            //this will become true if it found the item
            bool valueFound = false;
            //for each item in the combobox
            //i is the index of the combobox
            for (int intCboIndex = 0; intCboIndex < cbo.Items.Count; intCboIndex++)
            {
                //make sure our object is new and empty
                // ReSharper disable ObjectCreationAsStatement
                new CBOITEM();
                // ReSharper restore ObjectCreationAsStatement
                //cast the combobox as the combobox object
                var item = (CBOITEM)cbo.Items[intCboIndex];
                //compare if the id are what we are looking for
                if (item.ID == currentValue)
                {
                    //if it's what we want, turn true the boolean so it
                    //jump the following if that is selectign the first item
                    //by default
                    valueFound = true;
                    //select the good item in the combobox
                    cbo.SelectedIndex = intCboIndex;
                }

            }
            if (valueFound == false)
            {//if nothing was found
                if (cbo.Items.Count > 0)
                {//if we have items in the combobox
                    //select the first item
                    cbo.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// select the item that you are looking for by using the id value
        /// Different from SetIDDefaultValue result, this one only select if our deafult
        /// still there, if not it doesn't select anything in the combobox
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="defaultValue"></param>
        public static void SetIDDefaultValueIfExistOnly(ComboBox cbo, string defaultValue)
        {
            //the value we want to select in the end
            string currentValue = defaultValue;
            //create the combobox Item class
            //for each item in the combobox
            //i is the index of the combobox
            for (int intCboIndex = 0; intCboIndex < cbo.Items.Count; intCboIndex++)
            {
                //make sure our object is new and empty
                // ReSharper disable ObjectCreationAsStatement
                new CBOITEM();
                // ReSharper restore ObjectCreationAsStatement
                //cast the combobox as the combobox object
                var item = (CBOITEM)cbo.Items[intCboIndex];
                //compare if the id are what we are looking for
                if (item.ID == currentValue)
                {
                    //select the good item in the combobox
                    cbo.SelectedIndex = cbo.FindString(item.Text);
                }

            }
        }

        /// <summary>
        /// select the item that you are looking for by using the text value
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="defaultValue"></param>
        public static void SetDefaultValue(ComboBox cbo, string defaultValue)
        {
            //basiclly does a findstring of the value we are looking for
            if (cbo.FindString(defaultValue) >= 0)
            {//if the result >= 0 that mean the item exist
                //set the index to the index returned by the findstring
                cbo.SelectedIndex = cbo.FindString(defaultValue);
            }
            else
            {//that mean nothing is found
                if (cbo.Items.Count > 0)
                {//if we have items in the combobox
                    //select the first item
                    cbo.SelectedIndex = 0;
                }
            }
        }


        /// <summary>
        /// return the id of the selected index
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public static string IndexInformation(ComboBox cbo)
        {
            //this variable will return the index
            string index = "";
            //create the combobox Item class
            //if we have item in the combobox
            if (cbo.Items.Count > 0)
            {
                //cast and set the combobox item object to the combobox
                //selected item
                var item = (CBOITEM)cbo.Items[cbo.SelectedIndex];
                //set the index to the ID value of the object
                index = item.ID;
            }
            //return the index
            return index;
        }

        public static DataRow[] ItemInformations(ComboBox cbo, DataTable dtSourceTable, string strIDColumn)
        {
            //do a select on the table pass using the ID column of the table and 
            //comparing it to the Id of the combobox item

            DataRow[] drItemInformations = dtSourceTable.Columns[strIDColumn].DataType == typeof(string) ? dtSourceTable.Select(strIDColumn + " = '" + IndexInformation(cbo) + "'") : dtSourceTable.Select(strIDColumn + " = " + IndexInformation(cbo));

            //return the array which and array of 1;
            return drItemInformations;
        }
    }
    /// <summary>
    /// item object class for combobox
    /// </summary>
    public class CBOITEM
    {
        //variable set to the display member (Text Showing in the cbo)
        private string _text;
        //variable set to the Value member (Id of each item)
        private string _id;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        //create an item
        public void CreateItem(string text, string id)
        {
            _text = text;
            _id = id;
        }

    }

    public class ComboboxDefault
    {
        //hold the id value of the combobox
        private readonly string _strID = "";
        //is the combobox itself
        readonly ComboBox _cboMyCombobox;

        public ComboboxDefault(ComboBox cboMyCombobox)
        {
            if (cboMyCombobox == null) throw new ArgumentNullException("cboMyCombobox");
            _cboMyCombobox = cboMyCombobox;
            _strID = _cboMyCombobox.SelectedIndex >= 0 ? ComboBoxControl.IndexInformation(_cboMyCombobox) : "NO_ITEM_SELECTED";
        }

        public void ReDefault_Existing()
        {
            if (_strID != "NO_ITEM_SELECTED")
            {
                ComboBoxControl.SetIDDefaultValueIfExistOnly(_cboMyCombobox, _strID);
            }
        }

        public void ReDefault()
        {
            if (_strID != "NO_ITEM_SELECTED")
            {
                ComboBoxControl.SetIDDefaultValue(_cboMyCombobox, _strID);
            }
        }
    }

}
