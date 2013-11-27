using System;
using System.Windows.Forms;

/* =======Controls=======
 * lbl - Labels
 * txt - TextBox
 * cbo - combobox
 * lv - ListView
 * mnu - MenuStrip
 * grp - GroupBox
 * rad - radio button
 * chk - checkbox
 * num - Numerica Up and Down
 * msk - Mask textbox
 * pnl - Panel
 * pic - picturebox
 * rtf - rich text box
 * tab - tab control
 * cmd - buttons
 * =======Variables=======
 * str - string
 * int - integer
 * dbl - double
 * lng - long(aka int64 in vs2005)
 * flt - float
 * dec - decimal
 * chr - char
 * date - datetime
 * bol - boolean
 * sng - single
 * byte - byte
 * =======Objects=======
 * o - Generic object (only used for class custom object)
 * ds - dataset
 * dt - datatable
 * dr - datarow
 * li - listitem
 * ar - array
 * dv - dataview
 * rpt - report (crystal report)
 * frm - forms
 * exp - Expando (dll object)
 * tsk - TaskItem (dll object)
 * taskpane - TaskPane (dll object)
 */

namespace RefplusWebtools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //set regional settings
                CustomRegionalSettings.UseDectronFormat();

                //if and update to the updater exist
                if (System.IO.File.Exists("RefplusWebtoolsUpdater2.exe"))
                {
                    System.IO.File.Delete("RefplusWebtoolsUpdater.exe");
                    System.IO.File.Move("RefplusWebtoolsUpdater2.exe", "RefplusWebtoolsUpdater.exe");
                }

                //Set the webservice according to the XML file 
                Properties.Settings.Default["RefplusWebtools_WebService_Service"] = Query.GetWebServiceUrl();
                //Save it
                Properties.Settings.Default.Save();

                Application.Run(new FrmMain());
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"Program Main");
                MessageBox.Show(ex.ToString());
            }
        }
    }
}