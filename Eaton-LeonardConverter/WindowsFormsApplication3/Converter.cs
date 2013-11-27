using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace EatonLeonardConverter
{
    public partial class Converter : Form
    {
        public const string Header = "\nMaterial\tTube Dia.\t Tube Qty\t Tube Length Per Unit\t Tube Length Total \n";
        private string _job;
        private string _model;
        private string _quantity;
        decimal _length38;
        decimal _length12;
        decimal _length58;
        decimal _length78;
        decimal _length118;
        decimal _length138;
        decimal _length158;
        decimal _length218;
        int _qty38;
        int _qty12;
        int _qty58;
        int _qty78;
        int _qty118;
        int _qty138;
        int _qty158;
        int _qty218;
        public List<Pair> Values;

        public Converter()
        {
            InitializeComponent();
            Values = new List<Pair>();
            FillValues();
        }

        public void FillValues()
        {
            Values.Add(new Pair(5, 0.044059));
            Values.Add(new Pair(10, 0.088117));
            Values.Add(new Pair(15, 0.132176));
            Values.Add(new Pair(20, 0.176235));
            Values.Add(new Pair(25, 0.221629));
            Values.Add(new Pair(30, 0.268358));
            Values.Add(new Pair(35, 0.315087));
            Values.Add(new Pair(40, 0.364486));
            Values.Add(new Pair(45, 0.413885));
            Values.Add(new Pair(50, 0.465955));
            Values.Add(new Pair(55, 0.520694));
            Values.Add(new Pair(60, 0.578104));
            Values.Add(new Pair(65, 0.636849));
            Values.Add(new Pair(70, 0.700935));
            Values.Add(new Pair(75, 0.76769));
            Values.Add(new Pair(80, 0.839786));
            Values.Add(new Pair(85, 0.917223));
            Values.Add(new Pair(90, 1));
            Values.Add(new Pair(95, 1.092123));
            Values.Add(new Pair(100, 1.192256));
            Values.Add(new Pair(105, 1.303071));
            Values.Add(new Pair(110, 1.428571));
            Values.Add(new Pair(115, 1.570093));
            Values.Add(new Pair(120, 1.732977));
            Values.Add(new Pair(125, 1.921228));
            Values.Add(new Pair(130, 2.145527));
            Values.Add(new Pair(135, 2.41522));
            Values.Add(new Pair(140, 2.747664));
            Values.Add(new Pair(145, 3.17223));
            Values.Add(new Pair(150, 3.732977));
            Values.Add(new Pair(155, 4.511348));
            Values.Add(new Pair(160, 5.672897));
            Values.Add(new Pair(165, 7.596796));
            Values.Add(new Pair(170, 11.43391));
            Values.Add(new Pair(175, 22.89319));
            Values.Add(new Pair(180, 1));
        }

        //Show all the files in thew selected browser in the list
        private void cmd_browse_Click(object sender, EventArgs e)
        {
            string folder = chooseFolder();
            txtBox_Folder.Text = folder;
            FilesView.Rows.Clear();
            string[] files = Directory.GetFiles(folder);
            foreach (string file in files)
            {
// ReSharper disable once PossiblyMistakenUseOfParamsMethod
                if (file != null) FilesView.Rows.Add(file.Substring(folder.Length + 1));
            }
        }

        //Simply to select the export folder so we know where the user wants to save his CSV.
        private void button3_Click(object sender, EventArgs e)
        {
            txtFolderExport.Text = chooseFolder();
        }

        //Opening a folderbrowser and returning the folderpath of the selected folder
        private string chooseFolder()
        {
            string folderPath = "";
            var folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            return folderPath;
        }

        //  Checks if a folder for import is selected, then opens it 
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBox_Folder.Text == "")
            {
                MessageBox.Show(@"Please select a folder to import your TXT from before clicking on this.  Thank you!");
            }
            else
            {
                Process.Start("explorer.exe", "\"" + txtBox_Folder.Text + "\"");
            }
        }

        //  Checks if a folder for export is selected, then opens it 
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtFolderExport.Text == "")
            {
                MessageBox.Show(@"Please select a folder to export your CSVs in before clicking on this.  Thank you!");
            }
            else
            {
                Process.Start("explorer.exe", "\"" + txtFolderExport.Text + "\"");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text38 = "";
            string text12 = "";
            string text58 = "";
            string text78 = "";
            string text118 = "";
            string text138 = "";
            string text158 = "";
            string text218 = "";
            _qty38 = 0;
            _qty12 = 0;
            _qty58 = 0;
            _qty78 = 0;
            _qty118 = 0;
            _qty138 = 0;
            _qty158 = 0;
            _qty218 = 0;
            _length38 = 0;
            _length12 = 0;
            _length58 = 0;
            _length78 = 0;
            _length118 = 0;
            _length138 = 0;
            _length158 = 0;
            _length218 = 0;
            _job = null;
            _model = null;
            _quantity = null;


            var jobInfo = new FrmJobInfo();
            jobInfo.ShowDialog();
            _job = jobInfo.GetJob();
            _model = jobInfo.GetModel();
            _quantity = jobInfo.GetQuantity();
            jobInfo.Close();
            if (_job != null)
            {

                foreach (DataGridViewRow row in FilesView.Rows)
                {
                    if (row.Cells["FileName"].Value.ToString().Contains(".txt"))
                    {
                        Tube t = LoadTextData(row.Cells["FileName"].Value.ToString());
                        t = ConvertDataToXYZ(t);
                        if (t.FullTube[1] != null)
                        {
                            PushDataToCsv(row.Cells["FileName"].Value.ToString(), t);
                        }


                        if (t.FullTube[0].BendRadius.ToString(CultureInfo.InvariantCulture) == "0")
                        {
                            MessageBox.Show(@"Text file """ + t.FileName + @""" doesn't contain any bend.  Please select tube diameter");
                            var tubeSize = new FrmTubeSize();
                            tubeSize.ShowDialog();
                            t.FullTube[0].BendRadius = tubeSize.GetBendRadius();
                            tubeSize.Close();
                        }
                        string straight = "";
                        switch (t.FullTube[0].BendRadius.ToString(CultureInfo.InvariantCulture))
                        {
                            case ("0.9375"):
                                if (text38 == "")
                                {
                                    text38 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   3/8" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text38 += "Quantity \tTube Number \tCut Length \tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length38 += t.CutLength;
                                
                                _qty38++;
                                break;
                            case ("0.75"):
                                if (text12 == "")
                                {
                                    text12 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   1/2" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text12 += "Quantity \tTube Number \tCut Length\tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length12 += t.CutLength;
                                _qty12++;
                                break;
                            case ("0.751"):
                                if (text58 == "")
                                {
                                    text58 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   5/8" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text58 += "Quantity \tTube Number \tCut Length\tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length58 += t.CutLength;
                                _qty58++;
                                break;
                            case ("1.25"):
                                if (text78 == "")
                                {
                                    text78 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   7/8" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text78 += "Quantity \tTube Number \tCut Length\tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length78 += t.CutLength;
                                _qty78++;
                                break;
                            case ("1.75"):
                                if (text118 == "")
                                {
                                    text118 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   1  1/8" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text118 += "Quantity \tTube Number \tCut Length\tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length118 += t.CutLength;
                                _qty118++;
                                break;
                            case ("2"):
                                if (text138 == "")
                                {
                                    text138 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   1  3/8" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text138 += "Quantity \tTube Number \tCut Length\tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length138 += t.CutLength;
                                _qty138++;
                                break;
                            case ("2.5"):
                                if (text158 == "")
                                {
                                    text158 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   1  5/8" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text158 += "Quantity \tTube Number \tCut Length\tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length158 += t.CutLength;
                                _qty158++;
                                break;
                            case ("4"):
                                if (text218 == "")
                                {
                                    text218 = "------------------------------------------------" + Environment.NewLine + "Tube Diameter    :   2  1/8" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                straight = ((t.FullTube[1] == null) ? "Yes" : "No");
                                text218 += "Quantity \tTube Number \tCut Length\tCut Length Total \tStraight?" + Environment.NewLine + _quantity + " \t \t" + row.Cells["FileName"].Value.ToString().Replace(".txt", "") + "\t\t" + formatToFraction(t.CutLength) + "\t" + formatToFraction(t.CutLength * Convert.ToDecimal(_quantity)) + "\t\t" + straight + Environment.NewLine + Environment.NewLine;
                                _length218 += t.CutLength;
                                _qty218++;
                                break;

                        }

                    }

                }
                    
                string text = "";
                text = _model + Environment.NewLine + "Job number: " + _job + Environment.NewLine + text;
                text = text + Environment.NewLine + text38 + Environment.NewLine + text12 + Environment.NewLine + text58 + Environment.NewLine + text78 + Environment.NewLine + text118 + Environment.NewLine + text138 + Environment.NewLine + text158 + Environment.NewLine + text218;
                File.WriteAllText(txtFolderExport.Text + "\\" + _job + ".txt", text);


                // creating BOM file
                CreateBOM();


                //Open everything
                MessageBox.Show(@"Done converting!  the resulting files are in your export folder and will open when you click ok");
                Process.Start(txtFolderExport.Text + "\\\\" + _job + ".txt");
                 Process.Start(Application.StartupPath + @"\BOM" + _job + ".doc");
            }

        }
        //this creates the bill of material file for the drafter
        private void CreateBOM()
        {
            try
            {
                Type applicationType = Type.GetTypeFromProgID("Word.Application");
                object applicationObject = Activator.CreateInstance(applicationType);

                object documentsObject = applicationType.InvokeMember("Documents", BindingFlags.GetProperty,
                 null, applicationObject, null);
                applicationType.InvokeMember("Visible", BindingFlags.SetProperty, null, applicationObject,
                 new object[] { false });

                Type documentsType = documentsObject.GetType();
                object documentObject = documentsType.InvokeMember("Open", BindingFlags.InvokeMethod, null, documentsObject,

                //TO CHANGE FOR LAPTOP LOCATION WHEN TESTING WITH LAPTOP new Object[] { @"P:\Refplus\Rpapps\Eaton-Leonard\BOMTemplate.docx" });
                new Object[] { Application.StartupPath + @"\BOMTemplate.docx" });

                Type documentType = documentObject.GetType();
                object fieldsObject = documentType.InvokeMember("Fields", BindingFlags.GetProperty, null,
                 documentObject, null);

                // For some reason, accessing the "Item" property of Fields below does not work if you get the Type by using 
                // fieldsObject.GetType(). Using Assembly.GetType appears to work.
                Type fieldsType = documentType.Assembly.GetType("Microsoft.Office.Interop.Word.Fields");

                var numFields = (int)fieldsType.InvokeMember("Count", BindingFlags.GetProperty, null, fieldsObject, null);

                if (numFields > 0)
                {
                    for (int i = 1; i <= numFields; i++)
                    {
                        PropertyInfo itemProperty = fieldsType.GetProperty("Item");
                        object fieldObject = itemProperty.GetValue(fieldsObject, new object[] { i });

                        Type fieldType = fieldObject.GetType();
                        object fieldRangeObject = fieldType.InvokeMember("Code", BindingFlags.GetProperty, null,
                         fieldObject, null);

                        Type fieldRangeType = fieldRangeObject.GetType();
                        var fieldText = (string)fieldRangeType.InvokeMember("Text", BindingFlags.GetProperty,
                         null, fieldRangeObject, null);

                        if (fieldText.StartsWith(" MERGEFIELD"))
                        {
                            int endMerge = fieldText.IndexOf("\\", StringComparison.Ordinal);
                            string fieldName = fieldText.Substring(11, endMerge - 11);
                            fieldName = fieldName.Trim();
                            object resultObject;
                            var arg = new object[1];

                            switch (fieldName)
                            {
                                case ("Model"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    Type resultType = resultObject.GetType();
                                    arg[0] = _model;
                                    resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    break;
                                case ("Quantity"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    arg[0] = _quantity;
                                    resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    break;
                                case ("JobNumber"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    arg[0] = _job;
                                    resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    break;
                                case ("Header38"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty38 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat38"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty38 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0104";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia38"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty38 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "3/8";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty38"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty38 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty38.ToString(CultureInfo.InvariantCulture);
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len38"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty38 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length38 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX38"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty38 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length38 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Header12"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty12 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat12"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty12 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0105";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia12"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty12 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "1/2";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty12"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty12 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty12.ToString(CultureInfo.InvariantCulture);
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len12"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty12 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length12 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX12"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty12 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length12 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Header58"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty58 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat58"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty58 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0106";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia58"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty58 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "5/8";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty58"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty58 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty58.ToString(CultureInfo.InvariantCulture);
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len58"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty58 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length58 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX58"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty58 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length58 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Header78"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty78 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat78"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty78 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0108";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia78"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty78 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "7/8";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty78"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty78 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty78.ToString(CultureInfo.InvariantCulture);
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len78"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty78 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length78 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX78"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty78 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length78 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Header118"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty118 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat118"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty118 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0109";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia118"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty118 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "1 1/8";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty118"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty118 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty118.ToString(CultureInfo.InvariantCulture);
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len118"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty118 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length118 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX118"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty118 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length118 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Header138"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty138 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat138"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty138 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0110";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia138"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty138 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "1 3/8";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty138"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty138 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty138.ToString(CultureInfo.InvariantCulture);
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len138"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty138 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length138 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX138"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty138 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length138 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Header158"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty158 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat158"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty158 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0111";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia158"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty158 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "1 5/8";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty158"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty158 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty158;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len158"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty158 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length158 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX158"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty158 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length158 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Header218"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty218 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = Header;
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Mat218"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty218 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "RCU-0112";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Dia218"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty218 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "2 1/8";
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Qty218"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty218 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = _qty218.ToString(CultureInfo.InvariantCulture);
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("Len218"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty218 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = (_length218 / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                                case ("LenX218"):
                                    fieldType.InvokeMember("Select", BindingFlags.InvokeMethod, null, fieldObject, null);
                                    resultObject = fieldType.InvokeMember("Result", BindingFlags.GetProperty, null,
                                    fieldObject, null);
                                    resultType = resultObject.GetType();
                                    if (_qty218 == 0)
                                    {
                                        resultType.InvokeMember("Delete", BindingFlags.InvokeMethod, null, resultObject, null);
                                    }
                                    else
                                    {
                                        arg[0] = "\t\t\t" + (_length218 * Convert.ToDecimal(_quantity) / 12m).ToString("0.000");
                                        resultType.InvokeMember("Text", BindingFlags.SetProperty, null, resultObject, arg);
                                    }
                                    break;
                            }

                        }
                    }
                }
                var args = new object[1];
                //TO BE TAKEN OFF ONCE exe ISN'T ON LAPTOP
                args[0] = Application.StartupPath + @"\BOM" + _job + ".doc";
                documentType.InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, documentObject,
                                           args);

                int lastPos = 0;
                for (int i = txtBox_Folder.Text.Length - 1; i >= 0; --i)
                {
                    if (txtBox_Folder.Text[i] == '\\')
                    {
                        lastPos = i + 1;
                    }
                }
                string folderBeforeTxt = txtBox_Folder.Text.Substring(0, txtBox_Folder.Text.Length - lastPos);
                args[0] = folderBeforeTxt + "BOM" + _job + ".doc";

                documentType.InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, documentObject,
                               args);

                applicationType.InvokeMember("Quit", BindingFlags.InvokeMethod, null, applicationObject,
                                             null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        //This takes the data from the given txtName and loads it in an array
        private Tube LoadTextData(string txtname)
        {
            var ret = new Tube();
            string pathFullName = txtBox_Folder.Text + "\\" + txtname;
            var sr = new StreamReader(pathFullName);
            String data = sr.ReadToEnd().TrimEnd();
            //First we manage the header of the file, taking care of the full size, doc name, etc
            int whereToStop = data.IndexOf("\r", StringComparison.Ordinal);
            ret.FileName = data.Substring(0, whereToStop);
            data = data.Substring(whereToStop + 16);
            whereToStop = data.IndexOf(" ", StringComparison.Ordinal);
            ret.CutLength = decimal.Round(Convert.ToDecimal(data.Substring(0, whereToStop)), 2);
            data = data.Substring(whereToStop + 111);
            if (data[0] == '\n')
            {
                data = data.Substring(1);
            }
            //then we cycle through line after line of text to save all that data
            var toAdd = new TubeSegment();
            int i = 0;
            do
            {
                whereToStop = data.IndexOf(" ", StringComparison.Ordinal);
                ret.Amount += 1;
                toAdd.SegmentNumber = Convert.ToInt16(data.Substring(0, whereToStop));
                data = data.Substring(20);
                whereToStop = data.IndexOf(" ", StringComparison.Ordinal);
                toAdd.L = Convert.ToDouble(data.Substring(0, whereToStop));
                if (data.Length >= 20)
                {
                    data = data.Substring(20);
                    whereToStop = data.IndexOf(" ", StringComparison.Ordinal);
                    toAdd.R = Convert.ToDouble(data.Substring(0, whereToStop));
                    data = data.Substring(20);
                    whereToStop = data.IndexOf(" ", StringComparison.Ordinal);
                    toAdd.BendRadius = Convert.ToDouble(data.Substring(0, whereToStop));
                    data = data.Substring(20);
                    whereToStop = data.IndexOf(" ", StringComparison.Ordinal);
                    toAdd.A = Convert.ToDouble(data.Substring(0, whereToStop));
                    data = data.Substring(23);
                }
                else
                {
                    toAdd.R = 0;
                    toAdd.BendRadius = 0;
                    toAdd.A = 0;
                    data = "";
                }
                ret.FullTube[i] = new TubeSegment {L = toAdd.L, R = toAdd.R, A = toAdd.A};
                if(toAdd.BendRadius == 0.749)
                {
                    if(MessageBox.Show(@"You have a bend radius of 0.749 on your tube, which is the old Bend Radius for the 3/8 tubes.  Did you mean 0.9375?  If you click yes the system will use your bend radius as 0.983.  If you say no the software will close so you can go change your drawings.",@"Bend Radius Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ret.FullTube[i].BendRadius = 0.9375;
                    }
                    else
                    {
                        Application.Restart();
                        Process.GetCurrentProcess().Kill();
                    }
                }
                else
                {
                    ret.FullTube[i].BendRadius = toAdd.BendRadius;
                     
                }
                ret.FullTube[i].SegmentNumber = toAdd.SegmentNumber;
                
                ++i;
            }
            while (data != "");
            return ret;
        }
        //This takes the data from the txtName that was previously loaded and does the math to change it to the needed XYZ format
        private Tube ConvertDataToXYZ(Tube t)
        {
            double diameter = 0;
            double bendRadius = 0;
            double lastBendRadiusWithAngle = 0;
            if (t.FullTube[1] == null)
            {
                t.CutLength = Convert.ToDecimal(t.FullTube[0].L);
            }
            else
            {

                int toAdd = 0;

                for (int l = t.Amount - 1; l >= 0;--l)
                {
                    if (l == t.Amount - 1)
                    {
                        toAdd = 7;
                        switch (t.FullTube[l-1].BendRadius.ToString(CultureInfo.InvariantCulture))
                        {

                            case ("0.9375"):
                                diameter = 0.375;
                                bendRadius = 0.9375;
                                break;
                            case ("0.75"):
                                diameter = 0.5;
                                bendRadius = 0.75;
                                break;
                            case ("0.751"):
                                diameter = 0.625;
                                bendRadius = 0.751;
                                break;
                            case ("1.25"):
                                diameter = 0.875;
                                bendRadius = 1.25;
                                break;
                            case ("1.75"):
                                diameter = 1.125;
                                bendRadius = 1.75;
                                toAdd = 11;
                                break;
                            case ("2"):
                                diameter = 1.375;
                                bendRadius = 2;
                                toAdd = 11;
                                break;
                            case ("2.5"):
                                diameter = 1.625;
                                bendRadius = 2.5;
                                toAdd = 11;
                                break;
                            case ("4"):
                                diameter = 2.125;
                                toAdd = 11;
                                bendRadius = 4;
                                break;
                        }
                        toAdd = (int)Math.Ceiling(toAdd - t.FullTube[l].L);
                        if (toAdd < 0)
                        {
                            toAdd = 0;
                        }

                    }

                    double bendRadiusWithAngle = 0;
                    if ((l==0?t.FullTube[l].A != 90  :t.FullTube[l - 1].A != 90 ))
                        {
                            bendRadiusWithAngle = CalculateBendRadiusToAdd(bendRadius, t.FullTube[l==0?l:l - 1].A);
                        }
                        else
                        {
                            bendRadiusWithAngle = bendRadius;
                        }
                    
                    if (l == t.Amount - 1)
                    {
                        lastBendRadiusWithAngle = bendRadiusWithAngle;
                    }
                    double feed = t.FullTube[l].L + ((l == 0 || l == t.Amount - 1) ? lastBendRadiusWithAngle : lastBendRadiusWithAngle + bendRadiusWithAngle) + toAdd;
                    lastBendRadiusWithAngle = bendRadiusWithAngle;
                    t.CutLength += toAdd;
                    toAdd = 0;
                    t.FullTube[l].X = 0;
                    t.FullTube[l].Y = 0;
                    t.FullTube[l].Z = 0;
                    double lastRho;
                    double lastTheta;
                    if (l == 0)
                    {
                        lastRho = 0;
                        lastTheta = 0;
                    }
                    else
                    {
                        lastRho = t.FullTube[l - 1].A;
                        lastTheta = t.FullTube[l - 1].R;
                    }
                    for (int i = l; i < t.Amount; ++i)
                    {
                        t.FullTube[i].X += feed ;
                        var vector = new Vect {X = t.FullTube[i].X, Y = t.FullTube[i].Y, Z = t.FullTube[i].Z};
                        vector.Bend(-DegreesToRadians(lastRho));
                        
                        vector.Rotate(-DegreesToRadians(lastTheta) );
                        
                        t.FullTube[i].X = vector.X;
                        t.FullTube[i].Y = vector.Y;
                        t.FullTube[i].Z = vector.Z;
                    }
                    


                }

            }
         
            for (int i = 0; i <= t.Amount - 1; ++i)
            {
                t.FullTube[i].Diameter = diameter;
                t.FullTube[i].BendRadius = bendRadius;
            }
            return t;
        }

         public double CalculateBendRadiusToAdd(double bendRadius, double angle)
            {
                double ret= 0;
                if (angle % 5 != 0)
                {
                    double tempAngle = angle - (angle % 5);
                    double angleBefore = 0;
                    double percentageBefore = 0;
                    double percentageAfter = 0;
                    foreach (Pair pair in Values)
                    {
                        if (pair.Angle == tempAngle)
                        {
                            angleBefore = pair.Angle;
                            percentageBefore = pair.Percentage;
                            break;
                        }
                    }
                    double angleAfter = angleBefore + 5;
                    foreach (Pair pair in Values)
                    {
                        if (pair.Angle == angleAfter)
                        {
                            percentageAfter = pair.Percentage;
                            break;
                        }
                    }

                    double forOneDegree = (percentageAfter - percentageBefore) / 5;
                    double forTotalDegrees = (angle - angleBefore) * forOneDegree + percentageBefore;
                    ret = forTotalDegrees * bendRadius;

                }
                else
                {
                    foreach (Pair pair in Values)
                    {
                        if (pair.Angle == angle)
                        {
                            ret = bendRadius * pair.Percentage;
                            break;
                        }
                    }
                }
                return ret;

            }
         private string formatToFraction(decimal length)
         {
             decimal modulo = length % 1;
             decimal integer = length - modulo;
             string ret = integer.ToString("0.");
             if (modulo > 0m && modulo <= 0.0625m)
             {
                 ret += " 1/16\t";
             }
             else if (modulo > 0.0625m && modulo <= 0.125m)
             {
                 ret += " 1/8\t";
             }
             else if (modulo > 0.125m && modulo <= 0.1875m)
             {
                 ret += " 3/16\t";
             }
             else if (modulo > 0.1875m && modulo <= 0.250m)
             {
                 ret += " 1/4\t";
             }
             else if (modulo > 0.250m && modulo <= 0.3125m)
             {
                 ret += " 5/16\t";
             }
             else if (modulo > 0.3125m && modulo <= 0.375m)
             {
                 ret += " 3/8\t";
             }
             else if (modulo > 0.375m && modulo <= 0.4375m)
             {
                 ret += " 7/16\t";
             }
             else if (modulo > 0.4375m && modulo <= 0.5m)
             {
                 ret += " 1/2\t";
             }
             else if (modulo > 0.5m && modulo <= 0.5625m)
             {
                 ret += " 9/16\t";
             }
             else if (modulo > 0.5625m && modulo <= 0.625m)
             {
                 ret += " 5/8\t";
             }
             else if (modulo > 0.625m && modulo <= 0.6875m)
             {
                 ret += " 11/16";
                 if (integer < 10)
                     ret += "\t";
             }
             else if (modulo > 0.6875m && modulo <= 0.750m)
             {
                 ret += " 3/4\t";
             }
             else if (modulo > 0.750m && modulo <= 0.8125m)
             {
                 ret += " 13/16";
                 if (integer < 10)
                     ret += "\t";
             }
             else if (modulo > 0.8125m && modulo <= 0.875m)
             {
                 ret += " 7/8\t";
             }
             else if (modulo > 0.875m && modulo <= 0.9375m)
             {
                 ret += " 15/16";
                 if (integer < 10)
                     ret += "\t";
             }
             else if (modulo > 0.9375m && modulo <= 1.0m)
             {
                 ret = (integer + 1).ToString("0.") + "\t";

                 if (integer < 9)
                     ret += "\t";
             }
             else if (modulo == 0)
             {
                 if (integer < 9)
                     ret += "\t";
             
             }
             return ret;

         }
        private double DegreesToRadians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        //This takes the data converted previously and pushes it correctly to a CSV format.
        private void PushDataToCsv(string txtname, Tube t)
        {
            string filePath = txtFolderExport.Text + "\\" + txtname.Substring(0, txtname.Length - 4) + ".csv";
            const string delimiter = ",";
            int segmentNumber = 2;


            var sb = new StringBuilder();
            sb.Append("Part Name," + txtname + ",,,,,\nComments,,,,,,\nUnit:,in,,,,,\n,,,,,,\nTube Coordinates:,,,,,,\nSEGMENT NUMBER,X,Y,Z,MAX DIAMETER OF SEGMENT,AXIS TOLERANCE,R\n1,0,0,0," + t.FullTube[0].Diameter + ",," + t.FullTube[0].BendRadius + "\n");

            for (int i = 0; i <= t.Amount - 1; ++i)
            {
                sb.Append(segmentNumber + delimiter + t.FullTube[i].X + delimiter + t.FullTube[i].Y + delimiter + t.FullTube[i].Z + delimiter + t.FullTube[i].Diameter + delimiter + "" + delimiter + ((i == t.Amount - 1) ? "" : t.FullTube[i].BendRadius.ToString(CultureInfo.InvariantCulture)) + "\n");
                segmentNumber++;
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        public class Vect
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public void Unit()
            {
                double norm = X * X + Y * Y + Z * Z;
                norm = Math.Pow(norm, 0.5);
                X = X / norm;
                Y = Y / norm;
                Z = Z / norm;
            }

            public void Rotate(double angle)
            {
                var vector = new Vect {X = 1, Y = 0, Z = 0};
                double x1 = X * (Math.Round(Math.Cos(angle), 4) + vector.X * vector.X * (1 - Math.Round(Math.Cos(angle), 4))) + Y * (vector.X * vector.Y * (1 - Math.Round(Math.Cos(angle), 4)) - vector.Z * Math.Round(Math.Sin(angle), 4)) + Z * (vector.X * vector.Z * (1 - Math.Round(Math.Cos(angle), 4)) + vector.Y * Math.Round(Math.Sin(angle), 4));
                double y1 = X * (vector.X * vector.Y * (1 - Math.Round(Math.Cos(angle), 4)) + vector.Z * Math.Round(Math.Sin(angle), 4)) + Y * (Math.Round(Math.Cos(angle), 4) + vector.Y * vector.Y * (1 - Math.Round(Math.Cos(angle), 4))) + Z * (vector.Y * vector.Z * (1 - Math.Round(Math.Cos(angle), 4)) - vector.X * Math.Round(Math.Sin(angle), 4));
                double z1 = X * (vector.Z * vector.X * (1 - Math.Round(Math.Cos(angle), 4)) - vector.Y * Math.Round(Math.Sin(angle), 4)) + Y * (vector.Z * vector.Y * (1 - Math.Round(Math.Cos(angle), 4)) + vector.X * Math.Round(Math.Sin(angle), 4)) + Z * (Math.Round(Math.Cos(angle), 4) + vector.Z * vector.Z * (1 - Math.Round(Math.Cos(angle), 4)));
                X = x1;
                Y = y1;
                Z = z1;
            }

            public void Bend(double angle)
            {
                var vector = new Vect {X = 0, Y = 1, Z = 0};
                double x1 = X * (Math.Round(Math.Cos(angle), 4) + vector.X * vector.X * (1 - Math.Round(Math.Cos(angle), 4))) + Y * (vector.X * vector.Y * (1 - Math.Round(Math.Cos(angle), 4)) - vector.Z * Math.Round(Math.Sin(angle), 4)) + Z * (vector.X * vector.Z * (1 - Math.Round(Math.Cos(angle), 4)) + vector.Y * Math.Round(Math.Sin(angle), 4));
                double y1 = X * (vector.X * vector.Y * (1 - Math.Round(Math.Cos(angle), 4)) + vector.Z * Math.Round(Math.Sin(angle), 4)) + Y * (Math.Round(Math.Cos(angle), 4) + vector.Y * vector.Y * (1 - Math.Round(Math.Cos(angle), 4))) + Z * (vector.Y * vector.Z * (1 - Math.Round(Math.Cos(angle), 4)) - vector.X * Math.Round(Math.Sin(angle), 4));
                double z1 = X * (vector.Z * vector.X * (1 - Math.Round(Math.Cos(angle), 4)) - vector.Y * Math.Round(Math.Sin(angle), 4)) + Y * (vector.Z * vector.Y * (1 - Math.Round(Math.Cos(angle), 4)) + vector.X * Math.Round(Math.Sin(angle), 4)) + Z * (Math.Round(Math.Cos(angle), 4) + vector.Z * vector.Z * (1 - Math.Round(Math.Cos(angle), 4)));
                X = x1;
                Y = y1;
                Z = z1;
            }

           }

        public class Tube
        {
            private readonly TubeSegment[] _fullTube = new TubeSegment[100];
            public string FileName { get; set; }
            public decimal CutLength { get; set; }
            public TubeSegment[] FullTube { get { return _fullTube; } }
            public int Amount = 0;
        }


        public class TubeSegment
        {
            public int SegmentNumber { get; set; }
            public double L { get; set; }
            public double R { get; set; }
            public double A { get; set; }
            public double BendRadius { get; set; }
            public double Diameter { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }
        public class Pair
        {
            public Pair(double angle, double percentage)
            {
                Percentage = percentage;
                Angle = angle;
            }

            public double Percentage { get; set; }
            public double Angle { get; set; }
        }
    }
}
