using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace UpdatePusher
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

                //Set the webservice according to the XML file 
                Properties.Settings.Default["RefplusWebtools_WebService_Service"] = Query.GetWebServiceUrl();//UserManager.webserviceUrl;
                //Save it
                Properties.Settings.Default.Save();

                var updater = new FrmUpdater();
                updater.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}