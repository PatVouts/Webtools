using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools
{
    class HelpFiles
    {
        private static string GetHelpFileName(Form form)
        {
            string helpFile = "";
            DataTable dtHelpFile = Query.Select("Select * from helpfiles where formname = '" + form.Name + "' and language = '" + Public.Language + "'");

            if (dtHelpFile.Rows.Count > 0)
            {
                helpFile = dtHelpFile.Rows[0]["HelpFileName"].ToString();
            }
            return helpFile;
        }

        public static void Show(Form form)
        {
            string helpFile = GetHelpFileName(form);

            if (helpFile.Length > 0)
            {
                System.Diagnostics.Process.Start(Query.GetWebServiceUrl().Replace("Service.asmx", "") + "HelpFiles/" + helpFile);
            }

        }
    }
}
