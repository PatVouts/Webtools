using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    public partial class FrmModelSelector : Form
    {
        private readonly string _kitID;
        private readonly string _type;
        private readonly bool _openedFromList;
        private List<string> _models; 
     
        public FrmModelSelector(string id, string type, bool openedFromList)
        {
            _kitID = id;
            _type = type;
            InitializeComponent();
            _openedFromList = openedFromList;
            cmbType.SelectedItem = "Condensing Unit";
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);
        }

        //Function that fills all the lists according to what models can be found in the database.
        private void Fill_Lists()
        {
            if(cmbType.SelectedItem.ToString() == "Condensing Unit")
            {
                ThreadProcess.Start(Public.LanguageString("Filling lists", "Remplissage des listes"));
                Fill_FirstPart();
                    
                Fill_ThirdPart();

                Fill_Compressor();

                Fill_Voltage();
    
                Fill_Options();
                ThreadProcess.Stop();
                Focus();
            }
            else if (cmbType.SelectedItem.ToString() == "Evaporator")
            {
                Fill_FillSerie();

                Fill_EVVoltage();
            }
        }

        private void Fill_FillSerie()
        {
            lvSerie.Items.Clear();

            DataTable dtSerie = Query.Select("Select * from EvaporatorSerie");

            foreach (DataRow drSerie in dtSerie.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvSerie);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drSerie["Type"].ToString();
                myItem.SubItems[2].Text = drSerie["Style"].ToString();
                myItem.SubItems[3].Text = drSerie["DefrostType"].ToString();
                lvSerie.Items.Add(myItem);
            }

            lvSerie.Refresh();
        }

        private void Fill_EVVoltage()
        {
            lvEVVoltage.Items.Clear();

            DataTable dtVoltage = Query.Select("Select * from EvaporatorVoltage");

            foreach (DataRow drVoltage in dtVoltage.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvVoltage);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drVoltage["VoltDescription"].ToString();
                myItem.SubItems[2].Text = drVoltage["VoltageID"].ToString();
                lvEVVoltage.Items.Add(myItem);
            }

            lvVoltage.Refresh();
        }


        //Function called for both select all and unselect all.  The boolean checkValueToSet is the value to be set all around.
        private void SetAllCheckValues(GlacialComponents.Controls.GlacialList lv, bool checkValueToSet)
        {
            for (int iItem = 0; iItem < lv.Items.Count; iItem++)
            {
                lv.Items[iItem].SubItems[0].Checked = checkValueToSet;
            }
        }

        //Checks what exists in the database for the first three possible letters of a condensing unit, and offers all those combinations to the user.
        private void Fill_FirstPart()
        {
            lvFirstPart.Items.Clear();

            DataTable dtFirstPart = Query.Select("Select Distinct (UnitType + AirFlow + CompressorType) as ret from CondensingUnitModel order by ret");

            foreach (DataRow drFirstPart in dtFirstPart.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvFirstPart);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = (drFirstPart["ret"].ToString()).Substring(0, 1);
                myItem.SubItems[2].Text = (drFirstPart["ret"].ToString()).Substring(1, 1);
                myItem.SubItems[3].Text = (drFirstPart["ret"].ToString()).Substring(2, 1);
                lvFirstPart.Items.Add(myItem);
            }

            lvFirstPart.Refresh();
        }


        //Checks what exists in the database for the third part of a condensing unit (1H1, 1H7, etc), and offers all those combinations to the user.
        private void Fill_ThirdPart()
        {
            lvThirdPart.Items.Clear();

            DataTable dtThirdPart = Query.Select("Select Distinct (cast(CompressorManufacturer as varchar(1))+ Application + cast(RefrigerantID as varchar(1))) as ret from CondensingUnitModel order by ret");

            foreach (DataRow drThirdPart in dtThirdPart.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvThirdPart);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = (drThirdPart["ret"].ToString()).Substring(0, 1);
                myItem.SubItems[2].Text = (drThirdPart["ret"].ToString()).Substring(1, 1);
                myItem.SubItems[3].Text = (drThirdPart["ret"].ToString()).Substring(2, 1);
                lvThirdPart.Items.Add(myItem);
            }

            lvThirdPart.Refresh();
        }

        //Selects all compressor numbers, limited to 9
        private void Fill_Compressor()
        {
            lvCompressor.Items.Clear();

            DataTable dtCompressor = Query.Select("Select Distinct(number) from CondensingUnitCompressorAmount where number < 10");

            foreach (DataRow drCompressor in dtCompressor.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvCompressor);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drCompressor["Number"].ToString();
                lvCompressor.Items.Add(myItem);
            }

            lvCompressor.Refresh();
        }

        //Fills the voltage table according to what's available in the database (table Voltage)
        private void Fill_Voltage()
        {
            lvVoltage.Items.Clear();
            DataTable dtVoltage = Query.Select("Select VoltDescription, VoltageID from voltage order by voltageID");
            foreach (DataRow drVoltage in dtVoltage.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvVoltage);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = drVoltage["VoltageID"].ToString();
                lvVoltage.Items.Add(myItem);
            }

            lvVoltage.Refresh();
        }

        //Offers a list of all the letters of the alphabet.
        private void Fill_Options()
        {
            var letters = new[]
                {
                    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                    "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                    "U", "V", "W", "X", "Y", "Z"
                };
            lvOption.Items.Clear();
            foreach (string letter in letters)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvOption);
                myItem.SubItems[0].Text = "";
                myItem.SubItems[1].Text = letter;
                lvOption.Items.Add(myItem);
            }

            lvOption.Refresh();
        }
    
        // simply calls the list creator.
        private void frmModelSelector_Load(object sender, EventArgs e)
        {
            Fill_Lists();
        }

        //All the following functions are to pick or unpick all items from one of the lists.
        private void cmdFirstPartPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvFirstPart, true);
        }

        private void cmdFirstPartUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvFirstPart, false);
        }

        private void cmdCompressorPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvCompressor , true);
        }

        private void cmdCompressorUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvCompressor, false);
        }

        private void cmdThirdPartPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvThirdPart, true);
        }

        private void cmdThirdPartUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvThirdPart ,false);
        }

        private void cmdVoltagePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage, true);
        }

        private void cmdVoltageUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvVoltage ,false);
        }
        private void cmdOptionPickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvOption, true);
        }

        private void cmdOptionUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvOption, false);
        }

        //This function is to generate a list.  
        private void cmdGenerateList_Click(object sender, EventArgs e)
        {
            ThreadProcess.Start(Public.LanguageString("Generating list", "Génération de la liste"));
            var listFirstPart = new string[lvFirstPart.Items.Count];
            var listThirdPart = new string[lvThirdPart.Items.Count];
            var listVoltage = new string[lvVoltage.Items.Count];
            var listCompressors = new string[lvCompressor.Items.Count];
            var listOptions = new string[lvOption.Items.Count];
           
            //IF there's no ticks, means the min = max, so it's one searched value.  if not, calculate how big the HP array has to be.
            string[] listHP = numticks.Value == 0 ? new string[1] : new string[Convert.ToInt64((numMaxHP.Value - numMinHP.Value) / numticks.Value) + 1];
            int countFirst = 0;
            int countThird = 0;
            int countVoltage = 0;
            int countCompressors = 0;
            int countHP = 0;
            int countOption = 0;
           
            int nextToFill = 0;
            //Count each separate check, saving the item checked in a list, and counting the amount.
            for (int i = 0; i < lvFirstPart.Items.Count; ++i)
            {
                if (lvFirstPart.Items[i].SubItems[0].Checked)
                {
                    listFirstPart[nextToFill] = lvFirstPart.Items[i].SubItems[1].Text + lvFirstPart.Items[i].SubItems[2].Text + lvFirstPart.Items[i].SubItems[3].Text;
                    ++nextToFill;
                    ++countFirst;
                }
            }
            nextToFill = 0;
            for (int i = 0; i < lvThirdPart.Items.Count; ++i)
            {
                if (lvThirdPart.Items[i].SubItems[0].Checked)
                {
                    listThirdPart[nextToFill] = lvThirdPart.Items[i].SubItems[1].Text + lvThirdPart.Items[i].SubItems[2].Text + lvThirdPart.Items[i].SubItems[3].Text;
                    ++nextToFill;
                    ++countThird;
                }
            }
            nextToFill = 0;
            for (int i = 0; i < lvVoltage.Items.Count; ++i)
            {
                if (lvVoltage.Items[i].SubItems[0].Checked)
                {
                    listVoltage[nextToFill] = lvVoltage.Items[i].SubItems[1].Text;
                    ++nextToFill;
                    ++countVoltage;
                }
            }
            nextToFill = 0;
            for (int i = 0; i < lvCompressor.Items.Count; ++i)
            {
                if (lvCompressor.Items[i].SubItems[0].Checked)
                {
                    listCompressors[nextToFill] = lvCompressor.Items[i].SubItems[1].Text;
                    ++nextToFill;
                    ++countCompressors;
                }
            }
            nextToFill = 0;
            if (numticks.Value == 0)
            {
                numticks.Value = 0.01M;
            }
            for (decimal i = numMinHP.Value; i <= numMaxHP.Value ;)
            {
                listHP[nextToFill] = i.ToString(CultureInfo.InvariantCulture);
                ++nextToFill;
                i += numticks.Value;
                ++countHP;
            }
            nextToFill = 0;
            for (int i = 0; i < lvOption.Items.Count; ++i)
            {
                if (lvOption.Items[i].SubItems[0].Checked)
                {
                    listOptions[nextToFill] = lvOption.Items[i].SubItems[1].Text;
                    ++nextToFill;
                    ++countOption;
                }
            }

            if (countOption > 23)
            {
                Public.LanguageBox("Your computer won't have enough memory to find all the options you checked.  Please try with less then 24 letters checked. Thank you!", "Votre ordinateur n'a pas la mémoire suffisante pour créer toutes les combinaisons de lettres d'options demandées.  Assurez-vous que votre total de lettres cochées est moins de 24. Merci!");
            }
            else
            {
                //Call the right function to fill all options.
                var listOptionsToCompile = new List<string>();
                foreach (string option in listOptions)
                {
                    if (option != null)
                    {
                        listOptionsToCompile.Add(option);
                    }
                }

                long optionFactorial = Factor(countOption);
                long sizeOfArray = (countCompressors*countFirst*countHP*countThird*countVoltage)*(optionFactorial);
                var compiledOptions = new List<string> {""};
                if (listOptionsToCompile.Count != 0)
                {
                    compiledOptions.AddRange(FillOptionsCompiledList(listOptionsToCompile));
                }

                //Calculate size of models list to make sure no problems stem from having too huge a model's list.  if the value == 0 means one of the fields isn't checked.  If value is negative
                //Means the int size overflowed, so we won't be able to fit all.  In all other cases, we have between 1 and Int.MAXVALUE items.
                if (sizeOfArray == 0)
                {
                    Public.LanguageBox(
                        "You forgot to check something in one of the list.  Make sure in every list you have at least one checked item and click on this button again.  Thank you!",
                        "Vous avez oublié de cocher les éléments d'une liste.  Assurez-vous que chaque liste a au moins un élément de coché.  Merci!");
                }
                else if(sizeOfArray < 0)
                {
                    Public.LanguageBox(
                        "Your choices let too many possible units pass in the system. Make sure you select less options (taking away some letters from the last table will probably be enough).  Thank you!",
                        "Vos choix laissent une trop grande quantité d'unités possibles dans le système.  Veuillez choisir moins d'options (en enlevant certaines lettres du dernier tableau, par exemple). Merci!");
                }else{

                    var listModels = new List<string>();
                    //imbricated fors to build the models one by one.
                    for (int i = 0; i < countFirst; ++i)
                    {
                        for (int j = 0; j < countHP; ++j)
                        {
                            for (int k = 0; k < countThird; ++k)
                            {
                                for (int l = 0; l < countCompressors; ++l)
                                {
                                    for (int m = 0; m < countVoltage; ++m)
                                    { 
                                        for(int n=0; n<compiledOptions.Count; ++n)
                                        {
                                            if(compiledOptions[n].Length <= 3)
                                            {
                                                listModels.Add(listFirstPart[i] + "-" + GetHPComp(listHP[j], listCompressors[l]) + "-" + listThirdPart[k] + "-" + listVoltage[m] + compiledOptions[n]);
                                            }    
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ThreadProcess.Stop();
                    Focus();
                    //IF the form was opened from the model list, we need to switch invisible so the model list can grab the new models
                    if (_openedFromList)
                    {
                        Visible = false;
                        _models = listModels;
                    }
                    else
                    {
                        //IF the form wasn't opened from the model list, we need to open the model list form while giving it the model list
                        var frm = new FrmModelList(_kitID, _type, listModels, "Condensing Unit");
                        frm.ShowDialog();
                        Close();
                    }
                    
                }

            }
        }

        //Builds a list of string containing all the possible options from the list of chosen options.  All sizes of options, with all the possible letters (in alphabetical order) are recursively built.
        public List<string> FillOptionsCompiledList(List<string> options)
        {
            if (options.Count == 0)
            {
                var ret = new List<string> {""};
                return ret;
            }
            var result = new List<string>();
            for (int i = 0; i < options.Count; ++i)
            {
                var recOptions = new List<string>();
                result.Add(options[i]);
                if (options.Count - i - 1 > 0)
                {
                    for (int j = 1 + i; j < options.Count; ++j)
                    {
                        recOptions.Add(options[j]);
                    }
                    foreach (string option in FillOptionsCompiledList(recOptions))
                    {
                        result.Add(options[i] + option);
                    }
                }
            }
            return result;
        }
        

        //Calculate the factorial of a given number
        public long Factor(int number)
        {
            long result = 1;
            if(number != 0)
            {
                do
                {
                    result = result*number;
                    --number;
                } while (number > 0);
            }
            return result;
        }

        //Builds the HP + compressor string.
        public string GetHPComp(string hp, string compressor)
        {
            if (Convert.ToDecimal(hp) >= 100)
            {
                return hp.Substring(0, 3) + ((compressor == "1") ? hp.Substring(4,1) : compressor);
            }
            if (Convert.ToDecimal(hp) >= 10)
            {
                return hp.Substring(0, 2) + ((compressor == "1") ? hp.Substring(3, 1) : compressor);
            }
            if (hp.Length == 1)
            {
                return "0" + hp + ((compressor == "1") ? "0" : compressor);
            }
            return "0" + hp.Substring(0,1) + ((compressor == "1") ? hp.Substring(2,1) : compressor);
        }


        // public function so the model list can grab the list of models to add before closing this form.
        public List<string> GetModels()
        {
            return _models;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem.ToString() == "Condensing Unit")
            {
                grpInsideCU.Visible = true;
                grpInsideEV.Visible = false;
            }
            else if (cmbType.SelectedItem.ToString() == "Evaporator")
            {
                grpInsideCU.Visible = false;
                grpInsideEV.Visible = true;       
            }
            else if (cmbType.SelectedItem.ToString() == "Fluid Cooler" || cmbType.SelectedItem.ToString() == "Gravity Coil" || cmbType.SelectedItem.ToString() == "Condenser")
            {
                if(Public.LanguageQuestionBox("Switching to this type of unit involves a long list to be created.  It will also change the interface to the list generated, where you will be able to delete and add units.  Do you really want to change?","Appuyer sur ce bouton signifie une génération d'une liste de toutes les unités existantes pour ce type, ainsi qu'un changement d'interface où vous verrez cette liste et pourrez la changer à loisir.  Voulez-vous vraiment sélectionner ce type?",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var frm = new FrmModelList(_kitID, _type, _models, cmbType.SelectedItem.ToString());
                    frm.ShowDialog();
                    Close();
                }
                else
                {
                    cmbType.SelectedItem = "Condensing Unit";
                }

            }
            Fill_Lists();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            int countSerie = 0;
            int countVoltage = 0;
            int countCoolant = 0;

            for (int i = 0; i < lvSerie.Items.Count; ++i)
            {
                if (lvSerie.Items[i].SubItems[0].Checked)
                {
                    ++countSerie;
                }
            }
            for (int i = 0; i < lvEVVoltage.Items.Count; ++i)
            {
                if (lvEVVoltage.Items[i].SubItems[0].Checked)
                {
                    ++countVoltage;
                }
            }
            countCoolant += (chkRefrigerant.Checked ? 1:0) + (chkWater.Checked ? 1:0);

            if (countVoltage*countSerie*countCoolant == 0 ||
                (numMaxCapacity.Value == numMinCapacity.Value && numMaxCapacity.Value == 0))
            {
                Public.LanguageBox("Please make sure you selected one of each list at least. Thank you!","Veuillez vous assurer d'avoir sélectionné au moins un élément de chaque liste. Merci!");
            }
            else
            {
                var models = new List<string>();
                if (chkRefrigerant.Checked)
                {
                    for (int i = 0; i < lvSerie.Items.Count; ++i)
                    {
                        
                            if(lvSerie.Items[i].SubItems[0].Checked)
                            {
                                DataTable modelsToAdd =
                                    Query.Select(
                                        "Select Distinct(EvaporatorID) as ID from Evaporators where Left(EvaporatorID, 3) = '" +
                                        lvSerie.Items[i].SubItems[1].Text + lvSerie.Items[i].SubItems[2].Text + lvSerie.Items[i].SubItems[3].Text + "' and CapacityAt10TD <= " +
                                        numMaxCapacity.Value + " and CapacityAt10TD >= " +
                                        numMinCapacity.Value);
                            for (int j = 0; j < lvEVVoltage.Items.Count; ++j)
                            {
                                if (lvEVVoltage.Items[j].SubItems[0].Checked)
                                {
                                    foreach (DataRow row in modelsToAdd.Rows)
                                    {
                                        models.Add(row["ID"] + "-" + lvEVVoltage.Items[j].SubItems[1].Text);
                                    }
                                }
                            }
                        }
                    }
                }
                if (chkWater.Checked)
                {
                    for (int i = 0; i < lvSerie.Items.Count; ++i)
                    {
                       
                            if (lvSerie.Items[i].SubItems[0].Checked)
                            {
                                DataTable modelsToAdd =
                                    Query.Select(
                                        "Select Distinct(EvaporatorID) as ID from Evaporators where Left(EvaporatorID, 3) = '" +
                                        lvSerie.Items[i].SubItems[1].Text + lvSerie.Items[i].SubItems[2].Text + lvSerie.Items[i].SubItems[3].Text + "' and CapacityAt10TD <= " +
                                        numMaxCapacity.Value + " and CapacityAt10TD >= " +
                                        numMinCapacity.Value + " and WaterCoilSelection = 1");
                                for (int j = 0; j < lvEVVoltage.Items.Count; ++j)
                                {
                                    if (lvEVVoltage.Items[j].SubItems[0].Checked)
                                    {
                                        foreach (DataRow row in modelsToAdd.Rows)
                                        {
                                            models.Add(row["ID"] + "-" + lvEVVoltage.Items[j].SubItems[1].Text + "W");
                                        }
                                    }
                            }
                        }
                    }
                }
                if (_openedFromList)
                {
                    Visible = false;
                    _models = models;
                }
                else
                {
                    //IF the form wasn't opened from the model list, we need to open the model list form while giving it the model list
                    var frm = new FrmModelList(_kitID, _type, models, "Evaporator");
                    frm.ShowDialog();
                    Close();
                }
            }
        }

        private void cmdSeriePickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSerie, true);
        }

        private void cmdSerieUnpickAll_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvSerie, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvEVVoltage, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetAllCheckValues(lvEVVoltage, false);
        }

        private void cmdCapacityPickAll_Click(object sender, EventArgs e)
        {
            numMaxCapacity.Value = 10000000;
            numMinCapacity.Value = 0;
        }

        private void cmdCapacityUnpickAll_Click(object sender, EventArgs e)
        {
            numMaxCapacity.Value = 0;
            numMinCapacity.Value = 0;
        }
    }
}
