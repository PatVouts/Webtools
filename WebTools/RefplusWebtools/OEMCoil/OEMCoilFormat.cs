using System;
using System.Data;
using System.Globalization;

namespace RefplusWebtools.OEMCoil
{
    class OEMCoilFormat
    {
        //C = condenser
        //D = DX
        //W = water
        //B = booster water
        //S = standard steam
        //N = steam distributing

        private readonly string[] _strTableList = { "CoilFinType", "v_CoilFinTypeDefaults", "CoilFinTypeShape" };

        public OEMCoilFormat(string coilModel)
        {
            FinShape = "";
            FinType = "";
            CoilTypeParameter = "";
            CoilType = "";
            Errors = "";
            Query.LoadTables(_strTableList);  

            Model = coilModel;

            ValidateCoilModel();

            ReFormatCoilModel();
        }

        private bool HaveAccessToKFinAndR744()
        {
            //admin and Refplus group
            return (UserInformation.UserName == "admin" || UserInformation.GroupID == 0);
        }

        private void ReFormatCoilModel()
        {
            //sometime they type the model differently so we simply
            //standarise the model to follow nomenclature
            if (IsValid())
            {
                Model = CoilType + FinType + FinShape + "-" + FaceTubes.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + "-" + Rows.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + "-" + FPI.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + "-" + FinLength;
                
                //caps all letters
                Model = Model.ToUpper();
            }
        }

        public bool IsValid()
        {
            return Errors.Length == 0;
        }

        private void ValidateCoilModel()
        {
            string[] model = Model.Split('-');

            if (model.Length == 5)
            {
                if (model[0].Length == 3)
                {
                    if (IsAllLetter(model[0]))
                    {//"WEC"

                        CoilType = model[0].Substring(0, 1).ToUpper();
                        FinType = model[0].Substring(1, 1).ToUpper();
                        FinShape = model[0].Substring(2, 1).ToUpper();

                        if (CoilType == "D" || CoilType == "C" || CoilType == "W" || CoilType == "B" || CoilType == "S" || CoilType == "N")
                        {//check coil types

                            switch (CoilType)
                            {
                                case "D":
                                    CoilTypeParameter = "DX";
                                    break;
                                case "C":
                                    CoilTypeParameter = "HR";
                                    break;
                                case "W":
                                case "B":
                                    CoilTypeParameter = "FH";
                                    break;
                                case "S":
                                case "N":
                                    CoilTypeParameter = "ST";
                                    break;
                            }

                            DataTable dtPossibleFinType = Public.SelectAndSortTable(Public.DSDatabase.Tables["v_CoilFinTypeDefaults"], "CoilTypeParameter = '" + CoilTypeParameter + "'", "");

                            bool validFinType = false;

                            foreach (DataRow drPossibleFinType in dtPossibleFinType.Rows)
                            {
                                if (drPossibleFinType["FinType"].ToString() == FinType)
                                {
                                    validFinType = true;
                                }
                            }

                            //2012-09-26 : #3400 : prevent selection of K fin if not internal
                            if (FinType == "K" && !HaveAccessToKFinAndR744())
                            {
                                validFinType = false;
                            }

                            dtPossibleFinType.Dispose();

                            if (validFinType)
                            {//check fin type

                                DataTable dtPossibleFinShape = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinTypeShape"], "FinType = '" + FinType + "' AND FinShape = '" + FinShape + "'", "");

                                bool validFinShape = dtPossibleFinShape.Rows.Count > 0;

                                dtPossibleFinShape.Dispose();

                                if (validFinShape)
                                {//check fin shape

                                    if (IsAllNumeric(model[1]))
                                    {//face tubes

                                        FaceTubes = Convert.ToInt32(model[1]);

                                        if (IsAllNumeric(model[2]))
                                        {//rows

                                            Rows = Convert.ToInt32(model[2]);

                                            if (IsAllNumeric(model[3]))
                                            {//FPI

                                                FPI = Convert.ToInt32(model[3]);

                                                try
                                                {
                                                    FinLength = Convert.ToDecimal(model[4]);

                                                    DataTable dtFinType = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinType"], "FinType = '" + FinType + "'", "");

                                                    if (dtFinType.Rows.Count > 0)
                                                    {
                                                        FinHeight = FaceTubes * Convert.ToDecimal(dtFinType.Rows[0]["FaceTube"]);
                                                        TubeDiameter = Convert.ToDecimal(dtFinType.Rows[0]["TubeDiameter"]);
                                                        TubeRow = Convert.ToDecimal(dtFinType.Rows[0]["TubeRow"]);
                                                        PressStrokeMin = Convert.ToDecimal(dtFinType.Rows[0]["PressStrokeMin"]);
                                                        RowWidth = Convert.ToDecimal(dtFinType.Rows[0]["RowWidth"]);
                                                        FaceTubeSize = Convert.ToDecimal(dtFinType.Rows[0]["FaceTube"]);
                                                        
                                                    }
                                                    else
                                                    {
                                                        Errors += Public.LanguageString("Invalid fin type", "Le type d'ailette n'est pas correct") + Environment.NewLine;
                                                    }

                                                    dtFinType.Dispose();
                                                }
                                                catch(Exception ex)
                                                {
                                                    Public.PushLog(ex.ToString(),"OEMCoilFormat ValidateCoilModel");
                                                    Errors += Public.LanguageString("The fifth set must be numbers only", "Le cinquième groupe ne doit contenir que des nombres") + Environment.NewLine;
                                                }
                                            }
                                            else
                                            {
                                                Errors += Public.LanguageString("The fourth set must be numbers only", "Le quatrième groupe ne doit contenir que des nombres") + Environment.NewLine;
                                            }
                                        }
                                        else
                                        {
                                            Errors += Public.LanguageString("The third set must be numbers only", "Le troisième groupe ne doit contenir que des nombres") + Environment.NewLine;
                                        }
                                    }
                                    else
                                    {
                                        Errors += Public.LanguageString("The second set must be numbers only", "Le deuxième groupe ne doit contenir que des nombres") + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    Errors += Public.LanguageString("Invalid fin shape", "La forme des ailettes n'est pas valide") + Environment.NewLine;
                                }
                            }
                            else
                            {
                                Errors += Public.LanguageString("Invalid fin type selected", "Le type de d'ailette n'est pas valide") + Environment.NewLine;
                            }                            
                        }
                        else
                        {
                            Errors += Public.LanguageString("Coil type invalid", "Le type de serpentin n'est pas valide") + Environment.NewLine;

                        }
                    }
                    else
                    {
                        Errors += Public.LanguageString("The first set must be letters only", "Le premier groupe ne doit contenir que des lettres") + Environment.NewLine;
                    }
                }
                else
                {
                    Errors += Public.LanguageString("Nomenclature required 3 characters for the first set", "La nomenclature exige 3 caractères dans le premier groupe") + Environment.NewLine;
                }
            }
            else
            {
                Errors += Public.LanguageString("Invalid Format (ex: WEC-28-02-08-30 or WEC-28-2-8-30)", "Format non-valide (ex: WEC-28-02-08-30 ou WEC-28-2-8-30)") + Environment.NewLine;
            }
        }

        private bool IsNumeric(string character)
        {
            return char.IsNumber(character, 0);
        }

        private bool IsLetter(string character)
        {
            return char.IsLetter(character, 0);
        }


        private bool IsAllLetter(string text)
        {
            bool bolIsLetter = true;

            for (int i = 0; i < text.Length; i++)
            {
                if (!IsLetter(text.Substring(i, 1)))
                {
                    bolIsLetter = false;
                }
            }

            return bolIsLetter;
        }

        private bool IsAllNumeric(string text)
        {
            bool bolIsNumeric = true;

            for (int i = 0; i < text.Length; i++)
            {
                if (!IsNumeric(text.Substring(i, 1)))
                {
                    bolIsNumeric = false;
                }
            }

            return bolIsNumeric;
        }

        public string Model { get; private set; }

        public string Errors { get; private set; }

        public string CoilType { get; private set; }

        public string CoilTypeParameter { get; private set; }

        public string FinType { get; private set; }

        public string FinShape { get; private set; }

        public int FaceTubes { get; private set; }

        public decimal FaceTubeSize { get; private set; }

        public decimal FinHeight { get; private set; }

        public decimal FinLength { get; private set; }

        public int Rows { get; private set; }

        public int FPI { get; private set; }

        public decimal TubeDiameter { get; private set; }

        public decimal TubeRow { get; private set; }

        public decimal PressStrokeMin { get; private set; }

        public decimal RowWidth { get; private set; }
    }
}
