using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Drawing;

namespace RefplusWebtoolsUpdater
{
    class Public
    {
        //this dataset hold the whole list of controls and their
        //text value depending on the selected language
        public static DataSet dsLanguage = new DataSet();


        //is true if online mode, false offline mode
        public static bool bolOnline = true; //hardcode true for the moment

        //this is the version of the software
        public static string ApplicationVersion = Application.ProductVersion.ToString();

        //this is the biggest Dataset of the program. It has the biggest use
        //it contain all the readable tables that exist. nearly a perfect
        //copy of the database
        public static DataSet dsDATABASE = new DataSet();

        //color for each site
        public static Color RefplusColor = Color.FromArgb(179, 211, 233);
        public static Color EcosaireColor = Color.FromArgb(250, 200, 100);
        public static Color DectronColor = Color.FromArgb(195, 210, 225);
        public static Color CirculaireColor = Color.FromArgb(195, 210, 225);

        //this is the key string pass to the dll's to return the reports
        public static string ReportKey = "RefplusWebtools";

        public const decimal InvalidPrice = -1000000m;

        //2011-08-22 : #1167 they want default multiplier to be 0 now
        public const decimal DefaultMultiplier = 0m;
        //public const decimal DefaultMultiplier = 0.305m;

        //2012-07-25 : #2998 : integrating the .net DLL
        public const string COIL_DLL_KEY = "fQ#╗)ε<3∞}?$%⌠G1τ3ç±µsC©ª§3¼1¹£¥¤{%42Ω™…•≠≥≈‡ˇ˙©ª˚˛˜˝——@ε)⌠#$?(╗ 1(q{f3τç4<╗ qτ@ε3⌠ª§9ε]∞µ1©4©ª╗τçQ#,%@(F?#(%⌠ª§^Y~ 35 4R,FE^>╗4τç©ª|╗ |^&[4@7τ5Ω™…•ε8*- 1+.ª§43ª╗1⌐à₧s?.>k<k⌂≈‡ˇ˙˚@p·√≡∙⌠≈3π╘51>ª§`τε∞∩";

        



        //function that update the version of the software in the xml
        public static void UpdateXMLversion(string version)
        {
            try
            {

            version = version[0] + "." + version[1] + "." + version[2] + "." + version[3];
            //this update the current version in the local xml file
            DataSet dsVersion = new DataSet();
            if (System.IO.File.Exists("Version.xml"))
            {//if the file exist just read and overwrite the field
                dsVersion.ReadXml("Version.xml");
                dsVersion.Tables[0].Rows[0][0] = version;
            }
            else
            {//if the file don't exist, create the table and the row and add the value
                DataTable dtVersion = new DataTable("ProgramVersion");
                dtVersion.Columns.Add("Version", typeof(string));
                DataRow drVersion = dtVersion.NewRow();
                drVersion[0] = version;
                dtVersion.Rows.Add(drVersion);
                dsVersion.Tables.Add(dtVersion);
                dtVersion.Dispose();
            }
            //save the file
            dsVersion.WriteXml("Version.xml");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


    }
}
