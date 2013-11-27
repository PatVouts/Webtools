using System.Windows.Forms;
using System.Data;

namespace RefplusWebtools.Tools
{
    class Language
    {
        //will containt the form name for filtering purpose
        private string _strFormName = "";

        //this datatable will contain the filtered language
        //table according to the current form being modified
        private DataTable _dtFilteredLanguage = new DataTable();

        //Function to call to Set the language of the controls on the form
        //Pass the form we want to modify
        public void SetLanguage(Form frmLanguage)
        {
            //save the form name because it's used as a filter
            _strFormName = frmLanguage.Name;
            //filter the language on the form
            FilterLanguageOnForm();
            //set the form text language first
            frmLanguage.Text = ReturnControlText("FORM", frmLanguage.Text);
            //change the menustrip text
            ChangeMenuStripText(frmLanguage);
            //loop throught the control of the form and set their language
            LoopFormControl(frmLanguage);
        }

        private void ChangeMenuStripText(Form frmLanguage)
        {
            //first check if the form have a menustrip or else it will give an error
            if (frmLanguage.MainMenuStrip != null)
            {
                //loop throught all item of this menustrip
                foreach (ToolStripMenuItem itemStrip in frmLanguage.MainMenuStrip.Items)
                {
                    //set the menustrip item text
                    itemStrip.Text = ReturnControlText(itemStrip.Name, itemStrip.Text);
                    //loop through all subitem of this menustrip item
                    foreach (ToolStripItem subitemStrip in itemStrip.DropDownItems)
                    {
                        //set the menustrip subitem text
                        subitemStrip.Text = ReturnControlText(subitemStrip.Name, subitemStrip.Text);
                        TestControlType(subitemStrip);
                    }
                }
            }
        }

        private void FilterLanguageOnForm()
        {
            //initial Dataset containing all Forms
            _dtFilteredLanguage = new DataTable();
            //filtering on language
            DataRow[] drLanguageFiltered = Public.DSDatabase.Tables["Language"].Select("FormName = '" + _strFormName + "' AND Type = '" + Public.Language + "'");
            //clone it
            _dtFilteredLanguage = Public.DSDatabase.Tables["Language"].Clone();
            //fill it back with filtered values
            for (int intFilterCount = 0; intFilterCount < drLanguageFiltered.Length; intFilterCount++)
            {
                _dtFilteredLanguage.Rows.Add(drLanguageFiltered[intFilterCount].ItemArray);
            }
        }

        //Loop throught all form controls
        private void LoopFormControl(Form frmLanguage)
        {
            foreach (object ctrlControl in frmLanguage.Controls)
            {
                //test control type
                TestControlType(ctrlControl);
            }
        }

        //test the control type
        private void TestControlType(object myControl)
        {

            if (myControl.GetType() == typeof(GroupBox) || myControl.GetType() == typeof(ToolStripContainer) || myControl.GetType() == typeof(Panel) || myControl.GetType() == typeof(TabControl) || myControl.GetType() == typeof(ToolStrip) || myControl.GetType() == typeof(ListView) || myControl.GetType() == typeof(GlacialComponents.Controls.GlacialList) || myControl.GetType() == typeof(ToolStripDropDownButton) || myControl.GetType() == typeof(ToolStripMenuItem))
            {//if control is Groupbox OR Panel OR TabControl OR ToolStrip OR ListView
             //we need to loop throught his control (ListView it's his column that matters)
                GroupControl(myControl);
            }
            else
            {//else it's a simple control not in group so we can modify it right away
                SimpleControl(myControl);
            }
        }

        //if control is Groupbox OR Panel OR TabControl OR ToolStrip OR ListView OR TaskPane
        //OR Expandos OR MenuStrip OR ToolStripItemCollection
        //we need to loop throught his control (ListView it's his column that matters)
        private void GroupControl(object myControl)
        {
            //if control is Groupbox
            if (myControl.GetType() == typeof(GroupBox))
            {
                //group box have text value so we change it
                SimpleControl(myControl);
                //for each controls in the groupbox we change his subcontrols
                foreach (object groupControl in ((GroupBox)myControl).Controls)
                {
                    //test the control type (recursive)
                    //I am doign that because Groupbox can contain another "Group type object"
                    TestControlType(groupControl);
                }
            }
            //if control is Panel
            else if (myControl.GetType() == typeof(Panel))
            {
                //for each controls in the Panel we change his subcontrols
                foreach (object groupControl in ((Panel)myControl).Controls)
                {
                    //test the control type (recursive)
                    //I am doign that because Panel can contain another "Group type object"
                    TestControlType(groupControl);
                }
            }
            //if control is ToolStripCollection
            else if (myControl.GetType() == typeof(ToolStripItemCollection))
            {
                //for each controls in the ToolStrip we change his subcontrols
                foreach (ToolStripItem groupControl in ((ToolStripItemCollection)myControl))
                {
                    //test the control type (recursive)
                    //I am doign that because ToolStrip can contain another "Group type object"
                    TestControlType(groupControl);
                }
            }
            //if control is TabControl
            else if (myControl.GetType() == typeof(TabControl))
            {
                foreach (TabPage page in ((TabControl)myControl).TabPages)
                {
                    page.Text = ReturnControlText(page.Name, page.Text);
                    //for each controls in the TabControl we change his subcontrols
                    foreach (object groupControl in page.Controls)
                    {
                        //test the control type (recursive)
                        //I am doign that because TabControl can contain another "Group type object"
                        TestControlType(groupControl);
                    }
                }
            }
            //if control is ToolStrip
            else if (myControl.GetType() == typeof(ToolStrip))
            {
                //for each controls in the ToolStrip we change his subcontrols
                foreach (object groupControl in ((ToolStrip)myControl).Items)
                {
                    //test the control type (recursive)
                    //I am doign that because ToolStrip can contain another "Group type object"
                    TestControlType(groupControl);
                }
            }
            //if control is ListView
            else if (myControl.GetType() == typeof(ListView))
            {
                //for each Columns in the ListView we change them
                //this one is special because the object cannot be access directly
                // without calling his parent I.E lvMyList.Column[""].text compare to lblModel.text
                for (int intColumn = 0; intColumn < ((ListView)myControl).Columns.Count;intColumn++ )
                {
                    ((ListView)myControl).Columns[intColumn].Text = ReturnControlText(((ListView)myControl).Name + "." + intColumn, ((ListView)myControl).Columns[intColumn].Text);
                }
            }
            //if control is glacial list view
            else if (myControl.GetType() == typeof(GlacialComponents.Controls.GlacialList))
            {
                //for each Columns in the ListView we change them
                //this one is special because the object cannot be access directly
                // without calling his parent I.E lvMyList.Column[""].text compare to lblModel.text
                for (int intColumn = 0; intColumn < ((GlacialComponents.Controls.GlacialList)myControl).Columns.Count; intColumn++)
                {
                    ((GlacialComponents.Controls.GlacialList)myControl).Columns[intColumn].Text = ReturnControlText(((GlacialComponents.Controls.GlacialList)myControl).Name + "." + intColumn, ((GlacialComponents.Controls.GlacialList)myControl).Columns[intColumn].Text);
                }
            }
            //if control is toolstripcontainer
            else if (myControl.GetType() == typeof(ToolStripContainer))
            {
                //for each controls in the ToolStrip we change his subcontrols
                foreach (object groupControl in ((ToolStripContainer)myControl).ContentPanel.Controls)
                {
                    //test the control type (recursive)
                    //I am doign that because ToolStrip can contain another "Group type object"
                    TestControlType(groupControl);
                }
            }
           //if control is a toolstripdropdownbutton
            else if (myControl.GetType() == typeof(ToolStripDropDownButton))
            {
                ((ToolStripDropDownButton)myControl).Text = ReturnControlText(((ToolStripDropDownButton)myControl).Name, ((ToolStripDropDownButton)myControl).Text);
                //for each controls in the ToolStrip we change his subcontrols
                foreach (object groupControl in ((ToolStripDropDownButton)myControl).DropDownItems)
                {
                    //test the control type (recursive)
                    //I am doign that because ToolStrip can contain another "Group type object"
                    TestControlType(groupControl);
                }
            }

            else if (myControl.GetType() == typeof(ToolStripMenuItem))
            {
                SimpleControl(myControl);
                //for each controls in the ToolStrip we change his subcontrols
                foreach (object groupControl in ((ToolStripMenuItem)myControl).DropDownItems)
                {
                    //test the control type (recursive)
                    //I am doign that because ToolStrip can contain another "Group type object"
                    TestControlType(groupControl);
                }
            }
        }

        //check the type of the control and cast it to be able to set his text value to
        //what it's supposed to be depending on the language
        private void SimpleControl(object myControl)
        {
            if (myControl.GetType() == typeof(Form))
            {
                //FORM are using special control name to differenciate them from controls
                ((Form)myControl).Text = ReturnControlText("FORM", ((Form)myControl).Text);
            }
            else
            {
                var client = myControl as MdiClient;
                if (client != null)
                {
                    //FORM are using special control name to differenciate them from controls
                    client.Text = ReturnControlText("FORM", client.Text);
                }
                else if (myControl.GetType() == typeof(Label))
                {
                    ((Label)myControl).Text = ReturnControlText(((Label)myControl).Name, ((Label)myControl).Text);
                }
                else if (myControl.GetType() == typeof(LinkLabel))
                {
                    ((LinkLabel)myControl).Text = ReturnControlText(((LinkLabel)myControl).Name, ((LinkLabel)myControl).Text);
                }
                else if (myControl.GetType() == typeof(Button))
                {
                    ((Button)myControl).Text = ReturnControlText(((Button)myControl).Name, ((Button)myControl).Text);
                }
                else if (myControl.GetType() == typeof(GroupBox))
                {
                    ((GroupBox)myControl).Text = ReturnControlText(((GroupBox)myControl).Name, ((GroupBox)myControl).Text);
                }
                else if (myControl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)myControl).Text = ReturnControlText(((CheckBox)myControl).Name, ((CheckBox)myControl).Text);
                }
                else if (myControl.GetType() == typeof(RadioButton))
                {
                    ((RadioButton)myControl).Text = ReturnControlText(((RadioButton)myControl).Name, ((RadioButton)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripItem)myControl).Text = ReturnControlText(((ToolStripItem)myControl).Name, ((ToolStripItem)myControl).Text);
                }
                else if (myControl.GetType() == typeof(TabControl))
                {
                    ((TabControl)myControl).Text = ReturnControlText(((TabControl)myControl).Name, ((TabControl)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolBar))
                {
                    ((ToolBar)myControl).Text = ReturnControlText(((ToolBar)myControl).Name, ((ToolBar)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolStripItem))
                {
                    ((ToolStripItem)myControl).Text = ReturnControlText(((ToolStripItem)myControl).Name, ((ToolStripItem)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ContextMenuStrip))
                {
                    ((ContextMenuStrip)myControl).Text = ReturnControlText(((ContextMenuStrip)myControl).Name, ((ContextMenuStrip)myControl).Text);
                }
                else if (myControl.GetType() == typeof(MenuStrip))
                {
                    ((MenuStrip)myControl).Text = ReturnControlText(((MenuStrip)myControl).Name, ((MenuStrip)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolStripButton))
                {
                    ((ToolStripButton)myControl).Text = ReturnControlText(((ToolStripButton)myControl).Name, ((ToolStripButton)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolStripComboBox))
                {
                    ((ToolStripComboBox)myControl).Text = ReturnControlText(((ToolStripComboBox)myControl).Name, ((ToolStripComboBox)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolStripDropDown))
                {
                    ((ToolStripDropDown)myControl).Text = ReturnControlText(((ToolStripDropDown)myControl).Name, ((ToolStripDropDown)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolStripDropDownItem))
                {
                    ((ToolStripDropDownItem)myControl).Text = ReturnControlText(((ToolStripDropDownItem)myControl).Name, ((ToolStripDropDownItem)myControl).Text);
                }
                else if (myControl.GetType() == typeof(ToolStripLabel))
                {
                    ((ToolStripLabel)myControl).Text = ReturnControlText(((ToolStripLabel)myControl).Name, ((ToolStripLabel)myControl).Text);
                }
            }
        }

        //this function return the text value to set the control to, if the control don't have
        //a text it return what it was before. Will be faster than doing a test if we found
        //a value and then change it.
        private string ReturnControlText(string strControlName, string strControlText)
        {
            //filtering on control
            DataRow[] drControlFilter = _dtFilteredLanguage.Select("ControlName = '" + strControlName + "'");
            
            //if something found return the text value
            if (drControlFilter.Length > 0)
            {
                DataRow drSingleLine = _dtFilteredLanguage.NewRow();
                drSingleLine.ItemArray = drControlFilter[0].ItemArray;
                strControlText = drSingleLine["Text"].ToString();
            }

            return strControlText;
        }
    }
    class LanguageType
    {
        //list of language Constant
        public const string French = "FR";
        public const string English = "EN";
    }
}
