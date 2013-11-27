using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;

namespace RefplusWebtools
{
    class Public
    {
        //this dataset hold the whole list of controls and their
        //text value depending on the selected language
        public static DataSet DSLanguage = new DataSet();

        //contain the current language
        public static string Language = Tools.LanguageType.English;

        //is true if online mode, false offline mode
        public static bool BolOnline = true; //hardcode true for the moment

        //this is the version of the software
        public static string ApplicationVersion = Application.ProductVersion;

        //this is the biggest Dataset of the program. It has the biggest use
        //it contain all the readable tables that exist. nearly a perfect
        //copy of the database
        public static DataSet DSDatabase = new DataSet();

        //color for each site
        public static Color RefplusColor = Color.FromArgb(179, 211, 233);
        public static Color EcosaireColor = Color.FromArgb(250, 200, 100);
        

        //this is the key string pass to the dll's to return the reports
        public static string ReportKey = "RefplusWebtools";

        public const decimal InvalidPrice = -1000000m;

        //2011-08-22 : #1167 they want default multiplier to be 0 now
        public const decimal DefaultMultiplier = 0m;
        //public const decimal DefaultMultiplier = 0.305m;

        //2012-07-25 : #2998 : integrating the .net DLL
        public const string CoilDllKey = "fQ#╗)ε<3∞}?$%⌠G1τ3ç±µsC©ª§3¼1¹£¥¤{%42Ω™…•≠≥≈‡ˇ˙©ª˚˛˜˝——@ε)⌠#$?(╗ 1(q{f3τç4<╗ qτ@ε3⌠ª§9ε]∞µ1©4©ª╗τçQ#,%@(F?#(%⌠ª§^Y~ 35 4R,FE^>╗4τç©ª|╗ |^&[4@7τ5Ω™…•ε8*- 1+.ª§43ª╗1⌐à₧s?.>k<k⌂≈‡ˇ˙˚@p·√≡∙⌠≈3π╘51>ª§`τε∞∩";

        //change the color of a form according to the site
        public static void ChangeColor(Form frmMyForm)
        {
           frmMyForm.BackColor = GetSiteColor();
        }

        public static Color GetSiteColor()
        {
            Color c = RefplusColor;
            if (UserInformation.CurrentSite == "REFPLUS")
            {
                c = RefplusColor;
            }
            else if (UserInformation.CurrentSite == "ECOSAIRE")
            {
                c = EcosaireColor;
            }
            return c;
        }

        //change the selected language
        public static void SetLanguage(string strLanguage)
        {
            Language = strLanguage;
        }

        public static DialogResult LanguageQuestionBox(string strEnglish, string strFrench, MessageBoxButtons mbb)
        {
            if (Language == Tools.LanguageType.English)
            {
                return MessageBox.Show(strEnglish, @"Question", mbb);
            }
            return MessageBox.Show(strFrench, @"Question", mbb);
        }

        //this function shows the good thex of a message box depending on the language
        public static void LanguageBox(string strEnglish,string strFrench)
        {
            MessageBox.Show(Language == Tools.LanguageType.English ? strEnglish : strFrench);
        }

        public static void NoPermissionMessage()
        {
            LanguageBox("You do not have the required permissions to use this option", "Vous n'avez pas les permissions requises pour utiliser cette option");
        }

        public static string LanguageString(string strEnglish, string strFrench)
        {
            if (Language == Tools.LanguageType.English)
            {
                return strEnglish;
            }
            return strFrench;
        }


        //update all control according to selected language using mdiparent
        public static void RefreshMdiFormLanguage(Form frmMdiParent)
        {
            //instanciate the language class
            var language = new Tools.Language();
            //change the language of the mdi parent
            language.SetLanguage(frmMdiParent);

            //loop througth all mdi children and also change their value
            foreach (Form frmChild in frmMdiParent.MdiChildren)
            {
                language.SetLanguage(frmChild);
            }
            //clean the memory
        }

        /// <summary>
        /// This change the language of all control of the form pass
        /// to this function to the language previously selected by the user
        /// </summary>
        /// <param name="frmLanguage"></param>
        public static void ChangeFormLanguage(Form frmLanguage)
        {

            //instanciate the language class
            var language = new Tools.Language();
            //change the language of all the control in the form
            language.SetLanguage(frmLanguage);
            //clean the memory
        }

        //function that update the version of the software in the xml
        public static void UpdateXMLversion()
        {
            //this update the current version in the local xml file
            var dsVersion = new DataSet();
            if (!File.Exists("Version.xml"))
            {
//if the file don't exist, create the table and the row and add the value
                var dtVersion = new DataTable("ProgramVersion");
                dtVersion.Columns.Add("Version", typeof (string));
                DataRow drVersion = dtVersion.NewRow();
                drVersion[0] = ApplicationVersion;
                dtVersion.Rows.Add(drVersion);
                dsVersion.Tables.Add(dtVersion);
                dtVersion.Dispose();

                //save the file
                dsVersion.WriteXml("Version.xml");
            }
        }

        public static void StartUpdater()
        {
            //if the updater exist
            if (File.Exists("RefplusWebtoolsUpdater.exe"))
            {
                //start the updater
                Process p = Process.Start("RefplusWebtoolsUpdater.exe");
                //wait until the updater process ends
                if (p != null) p.WaitForExit();
            }
        }

        //clear temp folder adn recreate it
        public static void ClearAndRecreateTempFolder()
        {
            try
            {
                //delete the temp folder if not exist (and it's content
                if (Directory.Exists(Application.StartupPath + @"\temp"))
                {
                    Directory.Delete(Application.StartupPath + @"\temp", true);
                }

                //recreate it
                Directory.CreateDirectory(Application.StartupPath + @"\temp");

                //put it hidden
                // ReSharper disable once ObjectCreationAsStatement
                new DirectoryInfo(Application.StartupPath + @"\temp") {Attributes = FileAttributes.Hidden};

                //dispose object
            }
            catch (Exception ex)
            {
                PushLog(ex.ToString(), "Public ClearAndRecreateTempFolder");
            }
        }

        public static string GenerateFileNameAndPath(string strFileName, string strFileFormat)
        {
            long lngRandomizeNumber = DateTime.Now.Ticks;

            //create the temp folder if not exist
            if (!Directory.Exists(Application.StartupPath + @"\temp"))
            {
                ClearAndRecreateTempFolder();
            }

            //make sure the file save to the good path
            //path of the application + temp folder + filename + random + extension
            return Application.StartupPath + @"\temp\" + strFileName + "_" + lngRandomizeNumber + "." + strFileFormat;
        }


        //export a report to different format
        //the function return the location of the file it just created if needed
        //the value is the full path with name and everything
        public static string ExportReportToFormat(ReportDocument rptReportToExport, string strFileName, string strFileFormat,bool bolOpenAfterCreate)
        {
            //randomize number
            long lngRandomizeNumber = DateTime.Now.Ticks;

            //create the temp folder if not exist
            if (!Directory.Exists(Application.StartupPath + @"\temp"))
            {
                ClearAndRecreateTempFolder();
            }

            //make sure the file save to the good path
            //path of the application + temp folder + filename + random + extension
            string strFileFullNameAndPath = (strFileName.Contains(@"\") ? strFileName : Application.StartupPath + @"\temp\" + strFileName + "_" + lngRandomizeNumber + "." + strFileFormat);

            try
             {
                if (strFileFormat == "PDF")
                {
                    //export
                    rptReportToExport.ExportToDisk(ExportFormatType.PortableDocFormat, strFileFullNameAndPath);
                    //pdf format need a report object refresh or else the file leech
                    //more ram and cause problem when loading multiple pdf report back to back
                    rptReportToExport.Refresh(); 
                }
                else
                {
                    //exports
                    rptReportToExport.ExportToDisk(ExportFormatType.WordForWindows, strFileFullNameAndPath);
                }

                if (bolOpenAfterCreate)
                {
                    //open the file
                    Process.Start(strFileFullNameAndPath);
                }

                //return the file
                return strFileFullNameAndPath;  
            }
            catch(Exception ex)
            {
                PushLog(ex.ToString(), "Public ExportReportToFormat");
                if (UserInformation.UserName == "")
                {
                }
                else
                {
                    MessageBox.Show(@"Error, this report is already open.
 If you are trying to compare to another report please save this report then generate a new one.");
                }
                //return nothing
                return "";
            }
        }

        //validate and email, return true is the email is valid
        public static bool IsEmailValid(string strEmail)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var re = new Regex(strRegex);
            return re.IsMatch(strEmail);
        }

        public static bool IsStringAlphanumeric(string s)
        {
            var re = new Regex(@"^[a-zA-Z0-9]+$");
            return re.IsMatch(s);
        }

        //mix temperature formula
        public static decimal MixTemperature(decimal decFreshAirCFM, decimal decReturnAirCFM, decimal decFreshAirValue,decimal decReturnAirValue)
        {
            try
            {
                return ((((decFreshAirCFM + decReturnAirCFM) - decFreshAirCFM) * decReturnAirValue) + (decFreshAirCFM * decFreshAirValue)) / (decFreshAirCFM + decReturnAirCFM);
            }
            catch(Exception ex)
            {
                PushLog(ex.ToString(), "Public MixTemperature");
                return -9999m;
            }
        }

        //mix Wet Bulb formula
        public static decimal MixWetBulbTemperature(decimal decFreshAirCFM, decimal decReturnAirCFM, decimal decFreshAirDryBulbValue, decimal decReturnAirDryBulbValue, decimal decFreshAirWetBulbValue, decimal decReturnAirWetBulbValue, int altitude)
        {
            float fltFreshGrains = Tools.PsyCalcFormula.WetBulbToGrains((float)decFreshAirDryBulbValue, (float)decFreshAirWetBulbValue, altitude);
            float fltReturnGrains = Tools.PsyCalcFormula.WetBulbToGrains((float)decReturnAirDryBulbValue, (float)decReturnAirWetBulbValue, altitude);

// ReSharper disable CompareOfFloatsByEqualityOperator
            if (fltFreshGrains != -9999f && fltReturnGrains != -9999f)

            {
                var mixedGrains = (float)MixTemperature(decFreshAirCFM, decReturnAirCFM, (decimal)fltFreshGrains, (decimal)fltReturnGrains);
                var mixedDryBulb = (float)MixTemperature(decFreshAirCFM, decReturnAirCFM, decFreshAirDryBulbValue, decReturnAirDryBulbValue);

                if (mixedGrains != -9999f && mixedDryBulb != -9999f)
                {
                    float mixedWetBulb = Tools.PsyCalcFormula.WetBulb(mixedDryBulb, mixedGrains, altitude);

                    if (mixedWetBulb != -9999f)
                    {
                        return (decimal)mixedWetBulb;
                    }
                    return -9999m;
                }
                return -9999m;
            }
            return -9999m;
// ReSharper restore CompareOfFloatsByEqualityOperator
        }

        //mix CFM formula
        public static decimal MixCFM(decimal decFreshAirCFM, decimal decReturnAirCFM)
        {
            return decFreshAirCFM + decReturnAirCFM;
        }

        //make sure no error happend when changing numerical up down min man
        public static void SetNumericalUpDownMinMax(NumericUpDown numMyControl, decimal decMin, decimal decMax)
        {
            //set impossible min
            numMyControl.Minimum = -10000000m;

            //set impossible max
            numMyControl.Maximum = 10000000m;

            //store the old value
            decimal decOldValue = numMyControl.Value;

            //put the min and max
            numMyControl.Minimum = decMin;
            numMyControl.Maximum = decMax;

            //if the old value is in the range of the min max set it
            if (decOldValue >= decMin && decOldValue <= decMax)
            {
                numMyControl.Value = decOldValue;
            }
            else
            {
                numMyControl.Value = decMin;
            }
        }

         //make sure no error happend when changing numerical up down value
        public static void SetNumericalUpDownValue(NumericUpDown numMyControl, decimal decValue)
        {
            if (decValue < numMyControl.Minimum)
            {
                numMyControl.Value = numMyControl.Minimum;
            }
            else if (decValue > numMyControl.Maximum)
            {
                numMyControl.Value = numMyControl.Maximum;
            }
            else
            {
                numMyControl.Value = decValue;
            }
        }

        //sort and return a table
        public static DataTable SortTable(DataTable dtSourceTable, string strSort)
        {
            //create a view
            DataView dvSort = dtSourceTable.DefaultView;

            //sort the view
            dvSort.Sort = strSort;

            //return the view converted into a table
            return dvSort.ToTable();
        }

        public static DataTable SelectAndSortTable(DataTable dtSourceTable, string strSelect, string strSort)
        {
            DataTable ret = null;
            try
            {
                //select
                DataRow[] drSelect = dtSourceTable.Select(strSelect);

                //clone the table
                DataTable dtSourceTableClone = dtSourceTable.Clone();

                
                //for each result add the row to the clone table
                for (int intSelect = 0; intSelect < drSelect.Length; intSelect++)
                {
                    dtSourceTableClone.Rows.Add(drSelect[intSelect].ItemArray);
                }
                ret = SortTable(dtSourceTableClone, strSort);
            }
            catch (Exception ex)
            {
                PushLog(ex.ToString(),"Public SelectAndSortTable");
                MessageBox.Show(ex.ToString());
            }
            return ret;
        }

        public static string KFRefplus_VERSION()
        {
            //In order, D = DX, H = CondenserCoil, C = ChillWaterCoil, H = HotWaterCoil, S = SteamCoil

            return "D2H2C2H2S1";

        }

        public static string RevisionID_To_Letter(int intRevisionID)
        {
            int intLeftOver = intRevisionID;

            int fourLetters = Convert.ToInt32(Math.Floor(intLeftOver / 26d / 26d / 26d));
            intLeftOver = intLeftOver - (fourLetters * 26 * 26 * 26);
            int threeLetters = Convert.ToInt32(Math.Floor(intLeftOver / 26d / 26d));
            intLeftOver = intLeftOver - (threeLetters * 26 * 26);
            int twoLetters = Convert.ToInt32(Math.Floor(intLeftOver / 26d));
            intLeftOver = intLeftOver - (twoLetters * 26);
            int oneLetters = Convert.ToInt32(Math.Floor((double)intLeftOver));

            if (fourLetters > 0)
            {
                return Convert.ToString((char)(64 + fourLetters)) + Convert.ToString((char)(64 + threeLetters)) + Convert.ToString((char)(64 + twoLetters)) + Convert.ToString((char)(65 + oneLetters));
            }
            if (threeLetters > 0)
            {
                return Convert.ToString((char)(64 + threeLetters)) + Convert.ToString((char)(64 + twoLetters)) + Convert.ToString((char)(65 + oneLetters));
            }
            if (twoLetters > 0)
            {
                return Convert.ToString((char)(64 + twoLetters)) +Convert.ToString((char)(65 + oneLetters));
            }
            return Convert.ToString((char)(65 + oneLetters));
        }

        public static DataRow GetContactInfo(int contactID)
        {
            DataTable dtContactInfo = Query.Select("SELECT * FROM Contact_NEW LEFT JOIN ContactGroup_NEW on Contact_NEW.GroupID = ContactGroup_NEW.GroupID WHERE Contact_NEW.ContactID = " + contactID);

            return dtContactInfo.Rows[0];
        }

        public static string MergePDFFiles(List<string> lstFileNames)
        {
            string filePath = "";
            if (lstFileNames.Count > 0)
            {
                var pdf = new PDFMerge();

                //for each file that has been generated the file path has
                //been saved into that string array we jsut have to merge them
                for (int iFile = 0; iFile < lstFileNames.Count; iFile++)
                {
                    //last test : check if file exist just in case
                    if (File.Exists(lstFileNames[iFile]))
                    {
                        //add the file to the list of files to be merged
                        pdf.AddFile(lstFileNames[iFile]);
                    }
                }

                //get a randomly generated filename
                string strMergeReportLocation = GenerateFileNameAndPath("Merge", "pdf");

                //Merge and create the file
                if(pdf.Merge(strMergeReportLocation))
                {
                    //if merge sucessfull
                    //store the file path to be returned
                    filePath = strMergeReportLocation;
                }
            }

            return filePath;
        }

        public static void OpenSpecificFile(string strFileNameAndPath)
        {
            if (File.Exists(strFileNameAndPath))
            {
                Process.Start(strFileNameAndPath);
            }
        }

        public static void ExportTableToCSV(DataTable dt, string fileName)
        {
            ExportTableToCSV(dt, fileName, true);
        }

        public static void ExportTableToCSV(DataTable dt, string fileName, bool addQuotesToText)
        {
            var sr = new StreamWriter(fileName);

            string col = "";
            foreach (DataColumn dc in dt.Columns)
            {
                col += dc.ColumnName + ",";
            }

            col = col.Substring(0, col.Length - 1);

            sr.WriteLine(col);

            foreach (DataRow dr in dt.Rows)
            {
                string line = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType == typeof(string) && addQuotesToText)
                    {
                        line += "\"" + dr[dc] + "\",";
                    }
                    else
                    {
                        line += dr[dc] + ",";
                    }
                }

                line = line.Substring(0, line.Length - 1);

                sr.WriteLine(line);
            }
            sr.Close();
        }

        public static DataTable ImportCSVToTable(DataTable dtBaseTableFormat, string fileName, string strTableName)
        {
            try
            {
                var sr = new StreamReader(fileName);

                var dt = new DataTable();

                string filenameWithExt = fileName.Split('\\')[fileName.Split('\\').Length - 1];
                string filenameWithoutExt = filenameWithExt.Replace(".csv", "");

                if (filenameWithoutExt == strTableName)
                {
// ReSharper disable once PossibleNullReferenceException
                    string[] strColumns = sr.ReadLine().Split(',');

                    foreach (string scol in strColumns)
                    {
                        dt.Columns.Add(scol, typeof(string));
                    }

// ReSharper disable once RedundantAssignment
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitLine = line.Split(',');

                        if (splitLine.Length != strColumns.Length) throw new Exception("Invalid amount of column for a row");

                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < strColumns.Length; i++)
                        {
                            dr[i] = splitLine[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                sr.Close();

                return (CompareTableFormat(dt, dtBaseTableFormat) ? dt : null);

            }
            catch(Exception ex)
            {
                PushLog(ex.ToString(),"Public ImportCSVToTable");
                return null;
            }
        }

        public static bool CompareTableFormat(DataTable dtTable, DataTable dtBaseTableFormat)
        {
            bool tablesMatch = true;

            try
            {
                //match column count first
                if (dtTable.Columns.Count != dtBaseTableFormat.Columns.Count)
                {
                    tablesMatch = false;
                }

                //match column name
                if (tablesMatch)
                {
                    for (int iCol = 0; iCol < dtBaseTableFormat.Columns.Count; iCol++)
                    {
                        if (dtBaseTableFormat.Columns[iCol].ColumnName != dtTable.Columns[iCol].ColumnName)
                        {
                            tablesMatch = false;
                            iCol = dtBaseTableFormat.Columns.Count;
                        }
                    }
                }

                //match value type
                if (tablesMatch)
                {
                    for (int iRow = 0; iRow < dtTable.Rows.Count; iRow++)
                    {
                        for (int iCol = 0; iCol < dtBaseTableFormat.Columns.Count; iCol++)
                        {
// ReSharper disable OperatorIsCanBeUsed
                            if (dtBaseTableFormat.Columns[iCol].GetType() == typeof(decimal) ||
                                    dtBaseTableFormat.Columns[iCol].GetType() == typeof(float))
                                {
                                    decimal testDecimal;
                                    if (!Decimal.TryParse(dtTable.Rows[iRow][iCol].ToString(), out testDecimal))
                                    {
                                        return false;
                                    }
                                }
                                else if (dtBaseTableFormat.Columns[iCol].GetType() == typeof(DateTime))
                                {
                                    DateTime testDateTime;
                                    if (!DateTime.TryParse(dtTable.Rows[iRow][iCol].ToString(), out testDateTime))
                                    {
                                        return false;
                                    }
                                }
                                else if (dtBaseTableFormat.Columns[iCol].GetType() == typeof(int) || 
                                         dtBaseTableFormat.Columns[iCol].GetType() == typeof(Int32))
                                {
                                    int testInt;
                                    if(int.TryParse(dtTable.Rows[iRow][iCol].ToString(), out testInt))
                                    {
                                        return false;
                                    }
                                }
                                else if (dtBaseTableFormat.Columns[iCol].GetType() == typeof(bool))
                                {
                                    bool testBool;
                                    if (bool.TryParse(dtTable.Rows[iRow][iCol].ToString(), out testBool))
                                    {
                                        return false;
                                    }
                                }
// ReSharper restore OperatorIsCanBeUsed
                            }
                        }
                    }
            }
            catch(Exception ex)
            {
                PushLog(ex.ToString(),"Public CompareTableFormat");
                tablesMatch = false;
            }
            
            return tablesMatch;
        }

        public static void PushLog(string exception, string location)
        {
            Query.Execute("Insert into errorLog VALUES('" + DateTime.Today + "','" + UserInformation.UserName + "','" + location + "','" + exception.Substring(0,exception.Length > 500? 500: exception.Length).Replace('\'',' ') + "')");
        }

        public static Label GetDottedLine()
        {
            var l = new Label();
            while (TextRenderer.MeasureText(l.Text, l.Font).Width < 290)
            {
                l.Text += @".";
            }
            l.AutoSize = true;
            return l;
        }

        public static DateTime GetServerDate()
        {
            DataTable dtGetDate = Query.Select("SELECT getdate()");
            string serverDate = dtGetDate.Rows[0][0].ToString();
            dtGetDate.Dispose();

            return Convert.ToDateTime(serverDate);
        }
        //2013-10-02  :  PV0001
        //in frmMain, whenever you press "new quote" or "quick Condensing Unit", that message has to appear.  In less than a week I'll be taking it out because ppl will bitch it shows up too often.
        public static void OpenBitzerMessage()
        {
            LanguageBox("Please note that compressor models from Bitzer changed.  Because of that, capacities or amperages will differ from one model to the next.  We suggest you double-check with Refplus’ internal sales department for any quotation including a Bitzer’s compressor.", "Veuillez prendre note que les modèles de compresseur de marque Bitzer ont changés. De ce fait, il se peut que les capacités ou ampérages varient d’un modèle à l’autre. Nous vous conseillons de vérifier avec le département de ventes internes pour toute soumission incluant une appareil comprenant des compresseurs de marque Bitzer.");
        }

        public static string SortStringAlphabeticalOrder(string strToSort)
        {
            string toReturn = "";
            char charToAdd =' ';
            foreach(char chr in strToSort)
            {
                if(!toReturn.Contains(chr.ToString(CultureInfo.InvariantCulture)))
                {
                    charToAdd = chr;
                }
                foreach (char chr2 in strToSort)
                {
                    if (charToAdd == ' ' && !toReturn.Contains(chr2.ToString(CultureInfo.InvariantCulture)))
                    {
                        charToAdd = chr2;
                    }

                    if (chr2 < charToAdd && ! toReturn.Contains(chr2.ToString(CultureInfo.InvariantCulture)))
                    {
                        charToAdd = chr2;
                    }
                }
                toReturn += charToAdd;
                charToAdd = ' ';
            }
            return toReturn;
        }

        public static void ForceUpdateOnMachine(int machineID)
        {
            DataTable type = Query.Select("Select MachineType from machine where machineID = " + machineID);
            if (type.Rows.Count > 0)
            {
                switch (type.Rows[0]["machinetype"].ToString())
                {
                    case("Condensing Unit"):
                        ForceCondensingUpdate(machineID);
                        break;
                }
            }

        }


        public static void ForceCondensingUpdate(int machineID)
        {
            try
            {
                DataTable weight = Query.Select("Select weightManual from Machine where machineID = " + machineID);
                if (weight.Rows.Count > 0)
                {
                    //If the weightManual attribute is at 1 for the machine, it means the weight isn't automatic, so we can skip this.  If you change a module on a weight that is manually entered, it won't change the manually entered weight of the machine
                    if (weight.Rows[0]["weightManual"].ToString() == "False")
                    {
                        decimal newWeight = 0;
                        DataTable piecesNames =
                            Query.Select("Select PieceName, Qty from machinePieces where machineID = " + machineID);
                        foreach (DataRow pieceName in piecesNames.Rows)
                        {
                            bool found = false;
                            DataTable pieceWeight =
                                Query.Select(
                                    "Select Weight from moduleBaseLogic where moduleID = (select KitID from kitInfo where kitname like '" +
                                    pieceName["pieceName"].ToString()
                                        .Substring(pieceName["pieceName"].ToString().LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "')");
                            if (pieceWeight.Rows.Count > 0)
                            {
                                newWeight += Convert.ToDecimal(pieceWeight.Rows[0]["weight"].ToString())*
                                             Convert.ToDecimal(pieceName["qty"].ToString());
                                found = true;
                            }

                            pieceWeight =
                                Query.Select(
                                    "Select Weight from moduleCoilLogic where moduleID = (select KitID from kitInfo where kitname like '" +
                                    pieceName["pieceName"].ToString()
                                        .Substring(pieceName["pieceName"].ToString().LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "')");
                            if (pieceWeight.Rows.Count > 0 && !found)
                            {
                                newWeight += Convert.ToDecimal(pieceWeight.Rows[0]["weight"].ToString())*
                                             Convert.ToDecimal(pieceName["qty"].ToString());
                                found = true;
                            }
                            pieceWeight =
                                Query.Select(
                                    "Select Weight from moduleCompressorLogic where moduleID = (select KitID from kitInfo where kitname like '" +
                                    pieceName["pieceName"].ToString()
                                        .Substring(pieceName["pieceName"].ToString().LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "')");
                            if (pieceWeight.Rows.Count > 0 && !found)
                            {
                                newWeight += Convert.ToDecimal(pieceWeight.Rows[0]["weight"].ToString())*
                                             Convert.ToDecimal(pieceName["qty"].ToString());
                                found = true;
                            }
                            pieceWeight =
                                Query.Select(
                                    "Select Weight from moduleGenericLogic where moduleID = (select KitID from kitInfo where kitname like '" +
                                    pieceName["pieceName"].ToString()
                                        .Substring(pieceName["pieceName"].ToString().LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "')");
                            if (pieceWeight.Rows.Count > 0 && !found)
                            {
                                newWeight += Convert.ToDecimal(pieceWeight.Rows[0]["weight"].ToString())*
                                             Convert.ToDecimal(pieceName["qty"].ToString());
                                found = true;
                            }
                            pieceWeight =
                                Query.Select(
                                    "Select Weight from moduleMotorLogic where moduleID = (select KitID from kitInfo where kitname like '" +
                                    pieceName["pieceName"].ToString()
                                        .Substring(pieceName["pieceName"].ToString().LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "')");
                            if (pieceWeight.Rows.Count > 0 && !found)
                            {
                                newWeight += Convert.ToDecimal(pieceWeight.Rows[0]["weight"].ToString())*
                                             Convert.ToDecimal(pieceName["qty"].ToString());
                                found = true;
                            }
                            pieceWeight =
                                Query.Select(
                                    "Select Weight from moduleReceiverLogic where moduleID = (select KitID from kitInfo where kitname like '" +
                                    pieceName["pieceName"].ToString()
                                        .Substring(pieceName["pieceName"].ToString().LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "')");
                            if (pieceWeight.Rows.Count > 0 && !found)
                            {
                                newWeight += Convert.ToDecimal(pieceWeight.Rows[0]["weight"].ToString())*
                                             Convert.ToDecimal(pieceName["qty"].ToString());
                                found = true;
                            }
                            pieceWeight =
                                Query.Select(
                                    "Select Weight from moduleWCCLogic where moduleID = (select KitID from kitInfo where kitname like '" +
                                    pieceName["pieceName"].ToString()
                                        .Substring(pieceName["pieceName"].ToString().LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "')");
                            if (pieceWeight.Rows.Count > 0 && !found)
                            {
                                newWeight += Convert.ToDecimal(pieceWeight.Rows[0]["weight"].ToString())*
                                             Convert.ToDecimal(pieceName["qty"].ToString());

                            }
                        }
                        Query.Execute("Update Machine set weight = " + newWeight + " where machineID = " + machineID);
                    }
                }

                DataTable oldBalancing =
                    Query.Select(
                        "Select Min(Balancing) as minBal, Max(Balancing) as maxBal, Min(SST) as minSST, max(SST) as maxSST from condensingUnitBalancingTEST where Model = (Select machineName from Machine where MachineID = " +
                        machineID + ")");
                if (oldBalancing.Rows.Count != 0)
                {
                    DataTable machine = Query.Select("Select machineName from machine where machineID = " + machineID);
                    if (machine.Rows.Count > 0)
                    {
                        string machineName = machine.Rows[0]["machineName"].ToString();
                        DataTable coil =
                            Query.Select(
                                "Select * from moduleCoilLogic where moduleID = (Select kitID from kitInfo where kitName IN (Select right(pieceName, Len(pieceName) - 18) from machinePieces where machineID = " +
                                machineID + " and pieceName like 'MODULE(CU)-COIL%'))");
                       
                        if(coil.Rows.Count > 0)
                        {
                            DataTable faceTube =
                                Query.Select("Select FaceTube from coilFinType where finType = '" +
                                             coil.Rows[0]["FinType"].ToString()[0] + "'");
                            DataTable finMaterial =
                                   Query.Select("Select FinMaterialParameter from CoilFinMaterial where finMaterial = '" +
                                                coil.Rows[0]["FinMaterial"] + "'");
                            DataTable tubeMaterial =
                                Query.Select("Select tubeMaterialParameter, TubeType from CoilTubeMaterial where TubeMaterial = '" +
                                             coil.Rows[0]["TubeMaterial"] + "'");
                            DataTable refrigerant =
                                Query.Select("Select Refrigerant from Refrigerant where refrigerantID = " +
                                             machineName[10]);

                            DataTable cfm =
                                Query.Select("Select CFM from moduleMotorCFM where coilName like 'C" +
                                             coil.Rows[0]["FinType"].ToString()[0] +
                                             coil.Rows[0]["FinShape"].ToString()[0] + "-" +
                                             (Convert.ToDecimal(coil.Rows[0]["FinHeight"].ToString())/Convert.ToDecimal(faceTube.Rows[0]["FaceTube"].ToString())).ToString("00").PadLeft(2, '0') +
                                             "-" + coil.Rows[0]["Rows"].ToString().PadLeft(2, '0') + "-" + Convert.ToDecimal(coil.Rows[0]["FPI"].ToString()).ToString("00").PadLeft(2, '0') + "" + "-" + Convert.ToDecimal(coil.Rows[0]["FinLength"].ToString()).ToString("00").PadLeft(2, '0') + "' and moduleID = (Select kitID from kitInfo where kitName IN (Select right(pieceName, Len(pieceName) - 19) from machinePieces where machineID = " + 
                                             machineID + " and pieceName like 'MODULE(CU)-MOTOR%'))");
                            if(tubeMaterial.Rows.Count > 0 &&  finMaterial.Rows.Count > 0 && refrigerant.Rows.Count > 0 && cfm.Rows.Count > 0 )
                            {
                                List<BalancingData> newBalancing = Balancing.CompressorCondenserCoil.GetBalancingData(
                                Convert.ToDecimal(oldBalancing.Rows[0]["minBal"].ToString()),
                                Convert.ToDecimal(oldBalancing.Rows[0]["maxBal"].ToString()),
                               Convert.ToDecimal(oldBalancing.Rows[0]["minSST"].ToString()),
                                Convert.ToDecimal(oldBalancing.Rows[0]["maxSST"].ToString()),
                                GetCompressors(machineID),
                                coil.Rows[0]["FinType"].ToString()[0] + coil.Rows[0]["FinShape"].ToString()[0].ToString(CultureInfo.InvariantCulture),
                                Convert.ToDecimal(coil.Rows[0]["FinHeight"].ToString()),
                                Convert.ToDecimal(coil.Rows[0]["FinLength"].ToString()),
                                Convert.ToDecimal(cfm.Rows[0]["CFM"].ToString()),
                                refrigerant.Rows[0]["Refrigerant"].ToString(),
                                Convert.ToDecimal(coil.Rows[0]["FPI"].ToString()),
                                Convert.ToInt32(coil.Rows[0]["Circuits"].ToString()),
                                Convert.ToDecimal(coil.Rows[0]["Rows"].ToString()),
                                finMaterial.Rows[0]["FinMaterialParameter"].ToString(),
                                Convert.ToDecimal(coil.Rows[0]["FinThickness"].ToString()),
                                tubeMaterial.Rows[0]["TubeMaterialParameter"].ToString(),
                                Convert.ToDecimal(coil.Rows[0]["tubeThickness"].ToString()),
                                tubeMaterial.Rows[0]["tubeType"].ToString());

                    
                                Query.Execute("Delete from condensingUnitBalancingTest where model = '" + machineName + "'");
                                foreach (BalancingData balancing in newBalancing)
                                {
                                    Query.Execute("Insert into condensingUnitBalancingTest Values('" + machineName + "'," +
                                                  balancing.AMBIENT + "," + balancing.SST + "," + (balancing.CAPACITY/1000).ToString("0.00") + ")");
                                }
                            }
                        }
                    }
                }
                Query.Execute("Update machinesToUpdate set rebalanced = 1 where machineID = " + machineID);
            }
            catch (Exception ex)
            {
                PushLog(ex.ToString(), "Public    ForceCondensingUpdate");
            }
        }

        private static List<Compressor> GetCompressors(int machineID)
        {
            var listOfCompressors = new List<Compressor>();
            DataTable compressors = Query.Select("Select * from moduleCompressorLogic where moduleID = (Select kitID from kitInfo where kitType = 7 and kitName IN (Select right(pieceName, Len(pieceName) - 24) from machinePieces where machineID = " + machineID + " and pieceName like 'MODULE(CU)-COMPRESSOR%'))");

            foreach(DataRow compressor in compressors.Rows)
            {
                DataTable dtCompressorData = Query.Select("Select * from CompressorData where Compressor = '" + compressor["CompressorName"] + "' AND RefrigerantID = " + compressor["RefrigerantID"] + " AND VoltageID = " + compressor["VoltageID"]);

                if (dtCompressorData.Rows.Count == 0)
                {
                    listOfCompressors.Clear();
                    break;
                }
                listOfCompressors.Add(new Compressor(
                    compressor["CompressorName"].ToString(),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity1"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity2"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity3"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity4"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity5"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity6"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity7"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity8"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity9"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity10"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power1"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power2"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power3"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power4"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power5"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power6"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power7"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power8"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power9"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power10"]),
                    0m,
                    ""));
            }

            return listOfCompressors;
        }
        }
    

    public class MyPolicy : ICertificatePolicy {
    public bool CheckValidationResult(
          ServicePoint srvPoint
        , X509Certificate certificate
        , WebRequest request
        , int certificateProblem) {

        //Return True to force the certificate to be accepted.
        return true;

    } // end CheckValidationResult
} // class MyPolicy
}
