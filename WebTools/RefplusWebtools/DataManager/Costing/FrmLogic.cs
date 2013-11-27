using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using RefplusWebtools.QuickCoil;

namespace RefplusWebtools.DataManager.Costing
{
    public partial class FrmLogic : Form
    {
        private readonly string _moduleName;
        private readonly string _typeName;
        private readonly bool _asNew;
        private readonly string _previousName;

        //COnstructor for the form.  Associates a module name and a type name to the form so we know what we're working with, then 
        //initializes what needs to be.
        public FrmLogic(string moduleName, string typeName, bool asNew, string previousName)
        {
            _asNew = asNew;
            InitializeComponent();
            _moduleName = moduleName;
            _typeName = typeName;
            _previousName = previousName;
            if (_typeName.Contains("COMPRESSOR"))
            {
                InitializeCompressor();
            }
            else if (_typeName.Contains("MOTOR"))
            {
                InitializeMotor();
            }
            else if (_typeName.Contains("COIL"))
            {
                //Special.  Since a lot of data depends on what's in the tables, we start by loading every coil table so the rest will go easy.
                Query.LoadTables(new[]
                {
                    "CoilFinMaterial", "v_CoilFinDefaults", "CoilFinType", "CoilFinShape", "CoilfinThickness",
                    "CoilTubeThickness", "CoilTubeMaterial", "v_CoilTubeDefaults", "v_CoilCasingMaterialDefaults", "CoilCasingThickness",
                    "ConnectionSize_PoundsPerFoot"
                });
                InitializeCoil();
            }
            else if (_typeName.Contains("RECEIVER"))
            {
                InitializeReceiver();
            }
            else if (_typeName.Contains("BASE"))
            {
                InitializeBase();
            }
            else if (_typeName.Contains("WCC"))
            {
                InitializeWCC();
            }
            else if (_typeName.Contains("GENERIC"))
            {
                InitializeGeneric();
            }
        }

        //This is to view the details (read, open the CompressorData form with the right compressor selected) of a compressor
        private void btn_Details_Click(object sender, EventArgs e)
        {
            var compressor = new Generic.FrmCompressor(
                cboModel.Text.Substring(0, cboModel.Text.IndexOf(" - ", StringComparison.Ordinal)),
                cboModel.Text.Substring(cboModel.Text.IndexOf(" - ", StringComparison.Ordinal) + 3,
                    (cboModel.Text.LastIndexOf(" - ", StringComparison.Ordinal) -
                     cboModel.Text.IndexOf(" - ", StringComparison.Ordinal) - 3)),
                cboModel.Text.Substring(cboModel.Text.LastIndexOf(" - ", StringComparison.Ordinal) + 3));
            compressor.ShowDialog();

        }

        //When you select a new model in the compressor drop-down, the rest of the information is dynamically populated
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable chosenCompressor =
                Query.Select("Select * from CompressorData where Compressor = '" +
                             cboModel.Text.Substring(0, cboModel.Text.IndexOf(" - ", StringComparison.Ordinal)) +
                             "' and refrigerantId = (Select RefrigerantID from Refrigerant where Refrigerant = '" +
                             cboModel.Text.Substring(cboModel.Text.IndexOf(" - ", StringComparison.Ordinal) + 3,
                                 (cboModel.Text.LastIndexOf(" - ", StringComparison.Ordinal) -
                                  cboModel.Text.IndexOf(" - ", StringComparison.Ordinal) - 3)) +
                             "') and VoltageID = (Select VoltageID from Voltage where VoltDescription = '" +
                             cboModel.Text.Substring(cboModel.Text.LastIndexOf(" - ", StringComparison.Ordinal) + 3) +
                             "')");
            if (chosenCompressor.Rows.Count == 1)
            {
                lblRefrigerantValue.Text = chosenCompressor.Rows[0]["RefrigerantID"].ToString();
                lblLRAValue.Text = chosenCompressor.Rows[0]["LRA"].ToString();
                lblManufacturerValue.Text = chosenCompressor.Rows[0]["Manufacturer"].ToString();
                lblRLAValue.Text = chosenCompressor.Rows[0]["RLA"].ToString();
                lblTandemValue.Text = chosenCompressor.Rows[0]["SinglePhaseTandem"].ToString();
                lblTypeValue.Text = chosenCompressor.Rows[0]["Type"].ToString();
                lblVoltageValue.Text = chosenCompressor.Rows[0]["VoltageID"].ToString();
                lblCapacity1Value.Text = chosenCompressor.Rows[0]["Capacity1"].ToString();
                lblPower1Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power1"]).ToString("0.00#");
                lblCapacity2Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity2"]).ToString("0.00########");
                lblPower2Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power2"]).ToString("0.00########");
                lblCapacity3Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity3"]).ToString("0.00########");
                lblPower3Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power3"]).ToString("0.00########");
                lblCapacity4Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity4"]).ToString("0.00########");
                lblPower4Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power4"]).ToString("0.00########");
                lblCapacity5Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity5"]).ToString("0.00########");
                lblPower5Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power5"]).ToString("0.00########");
                lblCapacity6Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity6"]).ToString("0.00########");
                lblPower6Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power6"]).ToString("0.00########");
                lblCapacity7Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity7"]).ToString("0.00########");
                lblPower7Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power7"]).ToString("0.00########");
                lblCapacity8Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity8"]).ToString("0.00########");
                lblPower8Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power8"]).ToString("0.00########");
                lblCapacity9Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity9"]).ToString("0.00########");
                lblPower9Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power9"]).ToString("0.00########");
                lblCapacity10Value.Text =
                    Convert.ToDecimal(chosenCompressor.Rows[0]["Capacity10"]).ToString("0.00########");
                lblPower10Value.Text = Convert.ToDecimal(chosenCompressor.Rows[0]["Power10"]).ToString("0.00########");
            }
        }

        //Depending on the name in the type that is saved, we throw different queries at the database.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_typeName.Contains("COMPRESSOR"))
            {
                SaveCompressor();
                CheckAllCondensing();
            }
            else if (_typeName.Contains("MOTOR"))
            {
                SaveMotor();
                CheckAllCondensing();
            }
            else if (_typeName.Contains("BASE"))
            {
                SaveBase();
            }
            else if (_typeName.Contains("RECEIVER"))
            {
                SaveReceiver();
            }
            else if (_typeName.Contains("COIL"))
            {
                SaveCoil();
                CheckAllCondensing();
            }
            else if (_typeName.Contains("WCC"))
            {
                SaveWCC();
            }
            else if (_typeName.Contains("GENERIC"))
            {
                SaveGeneric();
            }
        }

        //This function checks the module that was just updated
        private void CheckAllCondensing()
        {
            DataTable machines =
                Query.Select("Select MachineID, MachineName from Machine where MachineID in (Select distinct(MachineID) from MachinePieces where PieceName like '%" + _moduleName + "') Order by machineName");
            


            string machineNames = ""; 

            foreach (DataRow machine in machines.Rows)
            {
                machineNames += machine["MachineName"] + "\n";
            }
            if (!String.IsNullOrEmpty(machineNames))
            {
                DialogResult result =
                    Public.LanguageQuestionBox("Your update just changed all the following machines \n" + machineNames + " \n  Yes = Update the balancing on those machines  \n No = Don't update the machines now, but put them in the backlog. \n  Cancel = don't update and don't put in the backlog",
                        "Votre mise a jour vient de potentiellement influencer les machines suivantes \n" + machineNames + " \n  Yes = Rebalancer les machines concernées  \n No = Ne pas rebalancer les machines, mais les mettre dans la table de backlog. \n  Cancel = Ne pas rebalancer et ne pas mettre en backlog.",
                        MessageBoxButtons.YesNoCancel);
                string rebal;
                string show;
                if (result == DialogResult.Yes)
                {
                    
                    ThreadProcess.Start("Updating machines");
                    int i = 1;
                    var stopWatch = new Stopwatch();
                    foreach (DataRow machine in machines.Rows)
                    {

                            stopWatch.Start();
                            DataTable machineInfo =
                                Query.Select("Select machineID from machine where machineName = '" + machine["machineName"] +
                                             "'");
                            if (machineInfo.Rows.Count > 0)
                            {
                                Public.ForceUpdateOnMachine(Convert.ToInt32(machineInfo.Rows[0]["machineID"].ToString()));
                            }

                            stopWatch.Stop();
                            // Get the elapsed time as a TimeSpan value.
                            TimeSpan ts = stopWatch.Elapsed;
                            int secondsForOne = 0;
                            if (secondsForOne == 0)
                            {
                                secondsForOne = ts.Seconds;
                            }
                            ThreadProcess.UpdateMessage("Time left : " + secondsForOne * (machines.Rows.Count - i) + " seconds");
                            ++i;
                        }
                        ThreadProcess.Stop();
                    
                    rebal = "1";
                    show = "1";
                }
                else if (result == DialogResult.No)
                {
                    rebal = "0";
                    show = "1";
                }
                else
                {
                    rebal = "0";
                    show = "0";
                }
                foreach (DataRow machine in machines.Rows)
                {
                    Query.Execute("Insert into machineUpdateBacklog VALUES('" + machine["machineName"] + "','" + _moduleName + "','" + DateTime.Now.ToShortDateString() + "','" + UserInformation.Name + "'," + rebal +"," + show + ")");
                }
            }
        }


        //Validating the generic data, then saving it
        private void SaveGeneric()
        {
            if (ValidateForGeneric())
            {
                DataTable module = Query.Select("Select KitID from KitInfo where KitName = '" + _moduleName + "'");
                Query.Execute("Delete from moduleGenericLogic where moduleId = " + module.Rows[0]["kitID"]);
               if( Query.Execute("Insert into moduleGenericLogic VALUES(" + module.Rows[0]["kitID"] + "," +
                              nUdGenericWeight.Value + ")"))
                                {
                    Public.LanguageBox("Save Successful!", "Sauvegarde Complète!");
                    Close();
                }
                else
                {
                    Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                }

            }
        }

        //No Validation
        private bool ValidateForGeneric()
        {
            return true;
        }

        //Validating the coil data, then saving it
        private void SaveCoil()
        {
            if (ValidateForCoil())
            {
                DataTable module = Query.Select("Select KitID from KitInfo where KitName = '" + _moduleName + "'");
                Query.Execute("Delete from moduleCoilLogic where moduleId = " + module.Rows[0]["kitID"]);
                if(Query.Execute(
                    "Insert into moduleCoilLogic VALUES(" + module.Rows[0]["kitID"] + ",'" + cboFinType.Text + "','" +
                    cboFinShape.Text + "'," + cboCircuits.Text + "," + cboFinHeight.Text + "," + nUdFinLength.Value +
                    "," + nUdRows.Value + "," + cboFPI.Text + ",'" + cboFinMaterial.Text + "','" + cboFinThickness.Text +
                    "','" + cboTubeMaterial.Text + "','" + cboTubeThickness.Text + "'," + nUdFanWide.Value + "," +
                    nUdFanLong.Value + "," + (cboSubCooler.Text == @"YES" ? "1" : "0") + "," +
                    (nUdFaceTube.Enabled ? nUdFaceTube.Value.ToString(CultureInfo.InvariantCulture) : "''") + "," +
                    (cboSubCoolerCircuits.Enabled ? cboSubCoolerCircuits.Text : "''") + "," + nUdCoilWeight.Value + ")"))
                {
                    Public.LanguageBox("Save Successful!", "Sauvegarde Complète!");
                    Close();
                }
                else
                {
                    Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                }
            }
        }

        //Validation that no comboBox is left empty
        private bool ValidateForCoil()
        {
            if (cboFinType.Text == "" || cboFinShape.Text == "" || cboCircuits.Text == "" || cboFinHeight.Text == "" ||
                nUdFinLength.Value == 0 || nUdRows.Value == 0 || cboFPI.Text == "" || cboFinMaterial.Text == "" ||
                cboFinThickness.Text == "" || cboTubeMaterial.Text == "" || cboTubeThickness.Text == "" ||
                nUdFanWide.Value == 0 || nUdFanLong.Value == 0 || !(cboSubCooler.Text == @"NO" ||
                (cboSubCooler.Text == @"YES" && (nUdFaceTube.Value != 0 && cboSubCoolerCircuits.Text != ""))))
            {
                Public.LanguageBox("Please make sure you enter a value for every requested line of data.  Thank you!","Veuillez s'il vous plaît choisir une entrée pour chaque ligne de donnée demandée.  Merci!");
                return false;
            }
            return true;
        }

        //Validating the data for Water Cooled Condenser and then inserting a line in the system for it.
        private void SaveWCC()
        {
            if (ValidateForWCC())
            {
                DataTable module = Query.Select("Select KitID from KitInfo where KitName = '" + _moduleName + "'");
                Query.Execute("Delete from moduleWCCLogic where moduleId = " + module.Rows[0]["kitID"]);
                if(Query.Execute("Insert into moduleWCCLogic VALUES(" + module.Rows[0]["kitID"] + "," + txtWCCR22.Text +
                              "," + txtWCCR134A.Text + "," + txtWCCR404A.Text + "," + txtWCCR407C.Text + "," +
                              txtWCCR507A.Text + "," + txtWCCR410A.Text + "," + txtWCCR407A.Text + "," + txtWCCR744.Text +
                              ",'" + txtWCCModel.Text + "'," + nUdWCCWeight.Value + ")"))
                {
                    Public.LanguageBox("Save Successful!", "Sauvegarde Complète!");
                    Close();
                }
                else
                {
                    Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                }
            }
        }

        //Checking that every textbox isn't empty, that every refrigerant is filled with a charge value, and that weight isn't 0
        private bool ValidateForWCC()
        {
            decimal test;
            if (!Decimal.TryParse(txtWCCR134A.Text, out test) || !Decimal.TryParse(txtWCCR22.Text, out test) ||
                !Decimal.TryParse(txtWCCR404A.Text, out test) || !Decimal.TryParse(txtWCCR407A.Text, out test) ||
                !Decimal.TryParse(txtWCCR407C.Text, out test) || !Decimal.TryParse(txtWCCR410A.Text, out test) ||
                !Decimal.TryParse(txtWCCR507A.Text, out test) || !Decimal.TryParse(txtWCCR507A.Text, out test) ||
                !Decimal.TryParse(txtWCCR744.Text, out test))
            {
                Public.LanguageBox("Please make sure you inputted a numerical charge for every refrigerant before you save.  Thank you!", "Veuillez vous assurer d'entrer une charge pour chaque réfrigérant.  Merci!");
                return false;
            }

            if (txtWCCModel.Text == "")
            {
                Public.LanguageBox("Please enter a model.  Thank you!", "Veuillez entrer un modèle.  Merci!");
                return false;
            }
            return true;
        }

        //First a validation of the Data to check if the compressor will be valid, then creating the queries to add it to the table.
        private void SaveCompressor()
        {
            if (ValidateForCompressor())
            {
                DataTable module = Query.Select("Select KitID from KitInfo where KitName = '" + _moduleName + "'");
                Query.Execute("Delete from moduleCompressorLogic where moduleId = " + module.Rows[0]["kitID"]);
                DataTable refrigerant =
                    Query.Select("Select RefrigerantID from Refrigerant where Refrigerant = '" +
                                 cboModel.Text.Substring(cboModel.Text.IndexOf(" - ", StringComparison.Ordinal) + 3,
                                     (cboModel.Text.LastIndexOf(" - ", StringComparison.Ordinal) - cboModel.Text.IndexOf(" - ", StringComparison.Ordinal) - 3)) + "'");
                DataTable voltage =
                    Query.Select("Select VoltageID from Voltage where VoltDescription = '" +
                                 cboModel.Text.Substring(cboModel.Text.LastIndexOf(" - ", StringComparison.Ordinal) + 3) + "'");
                DataTable suction =
                    Query.Select("Select ConnexionValue from ConnexionSize where ConnexionSize = '" + cboSuction.Text +
                                 "'");
                DataTable liquid =
                    Query.Select("Select ConnexionValue from ConnexionSize where ConnexionSize = '" + cboLiquid.Text +
                                 "'");
                DataTable discharge =
                    Query.Select("Select ConnexionValue from ConnexionSize where ConnexionSize = '" + cboDischarge.Text +
                                 "'");

                if(Query.Execute("Insert into moduleCompressorLogic VALUES(" + module.Rows[0]["KitID"] + ", '" +
                              cboModel.Text.Substring(0, cboModel.Text.IndexOf(" - ", StringComparison.Ordinal)) + "', " +
                              refrigerant.Rows[0]["RefrigerantID"] + "," + voltage.Rows[0]["voltageID"] + "," +
                              liquid.Rows[0]["ConnexionValue"] + "," + suction.Rows[0]["ConnexionValue"] + "," +
                discharge.Rows[0]["ConnexionValue"] + "," + nUdCompressorWeight.Value + ")"))
                {
                    Public.LanguageBox("Save Successful!", "Sauvegarde Complète!");
                    Close();
                }
                else
                {
                    Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                }
                
            }
        }

        //Simple check on the comboboxes to make sure everything is selected.
        private bool ValidateForCompressor()
        {
            if (cboLiquid.Text == "" || cboDischarge.Text == "" || cboSuction.Text == "" || cboModel.Text == "")
            {
                Public.LanguageBox("Please make sure you select a value for every value asked before you save. thank you!", "Veuillez vous assurer que vous choisissez une valeur pour chaque ligne demandée.  Merci!");
                return false;
            }
           
            if (Convert.ToDecimal(cboSuction.SelectedIndex) > Convert.ToDecimal(cboDischarge.SelectedIndex) &&
               Convert.ToDecimal(cboDischarge.SelectedIndex) >= Convert.ToDecimal(cboLiquid.SelectedIndex))
            {
                return true;
            }
            return true;
            
        }

        //Save for receiver.  Validating the data is OK, then pushing an insert.
        private void SaveReceiver()
        {
            if (ValidateForReceiver())
            {
                DataTable module = Query.Select("Select KitID from KitInfo where KitName = '" + _moduleName + "'");
                Query.Execute("Delete from moduleReceiverLogic where moduleId = " + module.Rows[0]["kitID"]);
                
                if(Query.Execute("insert into moduleReceiverLogic VALUES(" + module.Rows[0]["kitID"] + "," + txtR22.Text +
                              "," + txtR134A.Text + "," + txtR404A.Text + "," + txtR407C.Text + "," + txtR507A.Text +
                              "," + txtR410A.Text + "," + txtR407A.Text + "," + txtR744.Text + ",'" + txtSize.Text +
                              "'," + nUdReceiverWeight.Value + ")"))
                {
                    Public.LanguageBox("Save Successful!", "Sauvegarde Complète!");
                    Close();
                }
                else
                {
                    Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                }
            }
        }

        //Checking that every textbox is filled with numbers, that the weight isn't 0, and that the size is an existing one
        public bool ValidateForReceiver()
        {
            decimal test;
            if (!Decimal.TryParse(txtR134A.Text, out test) || !Decimal.TryParse(txtR22.Text, out test) ||
                !Decimal.TryParse(txtR404A.Text, out test) || !Decimal.TryParse(txtR407A.Text, out test) ||
                !Decimal.TryParse(txtR407C.Text, out test) || !Decimal.TryParse(txtR410A.Text, out test) ||
                !Decimal.TryParse(txtR507A.Text, out test) || !Decimal.TryParse(txtR507A.Text, out test) ||
                !Decimal.TryParse(txtR744.Text, out test))
            {
                Public.LanguageBox("Please make sure you inputted a numerical charge for every refrigerant before you save.  Thank you!", "Veuillez vous assurer d'entrer une charge pour chaque réfrigérant.  Merci!");
                return false;
            }
            DataTable receiver = Query.Select("Select DIstinct(ReceiverModel) from condensingUnitReceiver where receiverModel = '" + txtSize.Text + "'");
            if (receiver.Rows.Count == 0)
            {
                return (Public.LanguageQuestionBox("The Size you input for your receiver isn't in the database yet.  A lot of that can come from a different formatting of the name.  If your size is new, the system will save it.  If it's not, please check to make sure you have the right format.  Is your size new?", "La taille du réservoir que vous avez séléctionnée est nouveau dans la base.  Il est possible que ça ne soit qu'un erreur de formattage.  Si votre taille est nouvelle, elle sera ajoutée à la base.  Si elle ne l'est pas, appuyez sur le bouton voir tailles, qui vous montrera les formats courants dans la base.  Est-ce une nouvelle taille",MessageBoxButtons.YesNo) == DialogResult.Yes);
                
            }
            return true;
        }

        //First validate if the info for the motor is ok, then save it.
        private void SaveMotor()
        {
            if(ValidateForMotor())
            {
                DataTable module = Query.Select("Select KitID from KitInfo where KitName = '" + _moduleName + "'");
                string id = module.Rows[0]["kitID"].ToString();
                Query.Execute("Delete from moduleMotorLogic where moduleId = " + id);
                if(Query.Execute("Insert into ModuleMotorLogic VALUES(" + module.Rows[0]["kitID"] + "," + nUdHP.Value + "," +
                              nUdRPM.Value + ",'" + cboVoltage.Text + "'," + nUdFLA.Value + "," + txtTempMin.Text + "," +
                              txtTempMax.Text + ",'" + cboMotorType.Text + "'," + nUdMotorWeight.Value + ")"))
                {
                    Query.Execute("Delete from moduleMotorCFM where moduleId = " + id);
                    foreach (DataGridViewRow row in dgCFM.Rows)
                    {
                        if (!Query.Execute("INSERT INTO modulemotorcfm values (" + id + "," + row.Cells[1].Value + ",'" + row.Cells[0].Value + "')"))
                        {
                            Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                            break;
                        }
                    }
                    Public.LanguageBox("Save Successful!", "Sauvegarde Complète!");
                    Close();
                }
                else
                {
                    Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                }
            }
        }

        //Checking so that the values entered in the logic form for motors is ready to be saved.  Testing the numbers to be actual numbers,
        //The weight to NOt be at 0, and the combo boxes to have values selected
        private bool ValidateForMotor()
        {
            decimal test;
            if(!Decimal.TryParse(txtTempMin.Text, out test) || !Decimal.TryParse(txtTempMax.Text, out test))
            {
                Public.LanguageBox("Please enter numbers in the values for Temperature range, thank you!", "Veuillez entrer des chiffres comme valeurs pour l'intervalle de température.  Merci!");
                return false;
            }
            foreach (DataGridViewRow row in dgCFM.Rows)
            {
                if(!Decimal.TryParse(row.Cells[1].Value.ToString(),out test))
                {
                    Public.LanguageBox("Please enter numbers in the values for CFM, thank you!", "Veuillez entrer des chiffres comme valeurs pour le CFM.  Merci!");
                    return false;
                }
                if (row.Cells[0].Value.ToString() == "")
                {
                    Public.LanguageBox("Please make sure you select a coilModel for every coil model available..  Thank you!", "Veuillez vous assurer que vous avez séléctionné une valeur modèle de serpentin pour chaque ligne. Merci!");
                    return false;
                }
            }
            return true;

        }

        //Validating the base informations before saving it.  
        private void SaveBase()
        {
            if (ValidateForBase())
            {
                DataTable module = Query.Select("Select KitID from KitInfo where KitName = '" + _moduleName + "'");
                string id = module.Rows[0]["kitID"].ToString();
                Query.Execute("Delete from moduleBaseLogic where moduleID = " + id);
                if (
                    Query.Execute("Insert into moduleBaseLogic VALUES(" + id + "," + txtLength.Text + "," +
                                  txtWidth.Text + "," + txtHeight.Text + "," + nUdBaseWeight.Value + ")"))
                {
                        Public.LanguageBox("Save Successful!", "Sauvegarde Complète!");
                        Close();
                }
                else
                {
                    Public.LanguageBox("Save Failed!", "Sauvegarde Échouée!");
                }
                
            }
        }

        //Checking that the sizes are entered and not empty, and are numbers.  Checking so that the weight != 0
        private bool ValidateForBase()
        {
            decimal test;
            if (txtLength.Text == "" || !Decimal.TryParse(txtLength.Text, out test) || txtWidth.Text == "" ||
                !Decimal.TryParse(txtWidth.Text, out test) || txtHeight.Text == "" ||
                !Decimal.TryParse(txtHeight.Text, out test) )
            {
                Public.LanguageBox("Please enter a numerical value for every line.  Thank you!",
                    "Veuillez entrer une valeur numérique pour chaque ligne.  Merci!");
                return false;
            }
            return true;
        }

        //if the form is opened with a receiver, make the groups for other modules invisible, and make the receiver visible.
        //After that check is the receiver exists.
        private void InitializeReceiver()
        {
            grpCompressor.Visible = false;
            btnSave.Visible = true;
            grpCoil.Visible = false;
            grpMotor.Visible = false;
            grpReceiver.Visible = true;
            grpBase.Visible = false;
            btnSave.Top = 270;
            grpWCC.Visible = false;
            grpGeneric.Visible = false;
            CheckIfModuleReceiverExists();
        }

        //If the receiver is saved in the database. if it is, load the data in the form
        private void CheckIfModuleReceiverExists()
        {
            DataTable info = Query.Select("Select * from moduleReceiverLogic where ModuleID = (Select KitID from kitInfo where KitName = '" + (!_asNew ? _moduleName : _previousName) + "')");
            if (info.Rows.Count != 0)
            {
                txtR22.Text = info.Rows[0]["R-22"].ToString();
                txtR134A.Text = info.Rows[0]["R-134A"].ToString();
                txtR404A.Text = info.Rows[0]["R-404A"].ToString();
                txtR407A.Text = info.Rows[0]["R-407A"].ToString();
                txtR407C.Text = info.Rows[0]["R-407C"].ToString();
                txtR410A.Text = info.Rows[0]["R-410A"].ToString();
                txtR507A.Text = info.Rows[0]["R-507A"].ToString();
                txtR744.Text = info.Rows[0]["R-744"].ToString();
                txtSize.Text = info.Rows[0]["Size"].ToString();
                nUdReceiverWeight.Value = Convert.ToDecimal(info.Rows[0]["Weight"].ToString());
            }
        }

        //Nothing else to do to Initialize the base except checking if the base is saved already after displaying the correct groups.
        private void InitializeBase()
        {
            grpCompressor.Visible = false;
            btnSave.Visible = true;
            grpCoil.Visible = false;
            grpMotor.Visible = false;
            grpReceiver.Visible = false;
            grpBase.Visible = true;
            grpWCC.Visible = false;
            btnSave.Top = 200;
            grpGeneric.Visible = false;
            CheckIfModuleBaseExists();
        }

        //When opening the form with a base, checking if the database contains information about this base.  If it does, load the info in the form.
        private void CheckIfModuleBaseExists()
        {
            DataTable info = Query.Select("Select * from moduleBaseLogic where ModuleID = (Select KitID from kitInfo where KitName = '" + (!_asNew ? _moduleName : _previousName) + "')");
            if (info.Rows.Count != 0)
            {
                txtLength.Text = info.Rows[0]["Length"].ToString();
                txtWidth.Text = info.Rows[0]["Width"].ToString();
                txtHeight.Text = info.Rows[0]["Height"].ToString();
                nUdBaseWeight.Value = Convert.ToDecimal(info.Rows[0]["Weight"]);
            }
        }
                
        //When you open the form with a compressor, it takes out the grps not needed, makes sure you show the compressor groups, then it fills the 
        //comboboxes, and finally fills the data (if it exists)
        private void InitializeCompressor()
        {
            grpCompressor.Visible = true;
            btnSave.Visible = true;
            grpCoil.Visible = false;
            grpReceiver.Visible = false;
            grpBase.Visible = false;
            grpWCC.Visible = false;
            grpMotor.Visible = false;
            lblCompressorValue.Text = _moduleName;
            grpWCC.Visible = false;
            FillCompressors();
            FillConnexions();
            grpGeneric.Visible = false;
            CheckIfModuleCompressorExists();
        }
        
        //Select all compressors and their associated data to put them in the combobox
        private void FillCompressors()
        {
            DataTable compressors = Query.Select("SELECT CompressorData.*, Voltage.VoltDescription, Refrigerant.Refrigerant FROM CompressorData LEFT JOIN Voltage on CompressorData.VoltageID = Voltage.VoltageID LEFT JOIN Refrigerant on CompressorData.RefrigerantID = Refrigerant.RefrigerantID ORDER BY Compressor, CompressorData.RefrigerantID, CompressorData.VoltageID");
            foreach (DataRow dr in compressors.Rows)
            {
                ComboBoxControl.AddItem(cboModel, dr["Compressor"] + "|" + dr["RefrigerantID"] + "|" + dr["VoltageID"], dr["Compressor"] + " - " + dr["Refrigerant"] + " - " + dr["VoltDescription"]);
            }
        }

        //Getting the correct connexions from the database and adding them to the combobox.
        private void FillConnexions()
        {
            DataTable connexions = Query.Select("SELECT * from ConnexionSize");
            foreach (DataRow dr in connexions.Rows)
            {
                ComboBoxControl.AddItem(cboLiquid, dr["ConnexionValue"].ToString(), dr["ConnexionSize"].ToString());
                ComboBoxControl.AddItem(cboSuction, dr["ConnexionValue"].ToString(), dr["ConnexionSize"].ToString());
                ComboBoxControl.AddItem(cboDischarge, dr["ConnexionValue"].ToString(), dr["ConnexionSize"].ToString());
            }
        }

        //On open with a Compressor as a module, make sure said compressor doesn't already have info saved with it.  If it does, load said data.
        private void CheckIfModuleCompressorExists()
        {
            DataTable info = Query.Select("Select * from moduleCompressorLogic where ModuleID = (Select KitID from kitInfo where KitName = '" + (!_asNew ? _moduleName : _previousName) + "')");
            if (info.Rows.Count != 0)
            {
                DataTable refrigerant = Query.Select("Select Refrigerant from Refrigerant where refrigerantID = " + info.Rows[0]["RefrigerantID"]);
                DataTable voltage = Query.Select("Select VoltDescription from voltage where voltageID = " + info.Rows[0]["voltageID"]);
                DataTable liquidText = Query.Select("Select ConnexionSize from connexionSize where connexionValue = " + info.Rows[0]["liquidValue"]);
                DataTable suctionText = Query.Select("Select ConnexionSize from connexionSize where connexionValue = " + info.Rows[0]["suctionValue"]);
                DataTable dischargeText = Query.Select("Select ConnexionSize from connexionSize where connexionValue = " + info.Rows[0]["dischargeValue"]);

                cboLiquid.SelectedIndex = cboLiquid.FindString(liquidText.Rows[0]["connexionSize"].ToString());
                cboSuction.SelectedIndex = cboSuction.FindString(suctionText.Rows[0]["connexionSize"].ToString());
                cboDischarge.SelectedIndex = cboDischarge.FindString(dischargeText.Rows[0]["connexionSize"].ToString());

                cboModel.SelectedIndex = cboModel.FindString(info.Rows[0]["CompressorName"] + " - " + refrigerant.Rows[0]["Refrigerant"] + " - " + voltage.Rows[0]["voltDescription"]);
                nUdCompressorWeight.Value = Convert.ToDecimal(info.Rows[0]["Weight"].ToString());
            }
        }


        //Making the correct controls invisible, the correct ones visible, and then loading the data (if it exists) 
        private void InitializeMotor()
        {
            grpCompressor.Visible = false;
            btnSave.Visible = true;
            grpMotor.Visible = true;
            grpCoil.Visible = false;
            grpReceiver.Visible = false;
            grpWCC.Visible = false;
            grpBase.Visible = false;
            grpGeneric.Visible = false;
            lblMotorValue.Text = _moduleName;
             
            CheckIfModuleMotorExists();
        }

        //On open with a Motor as module, make sure the motor doesn't have informations saved.  if it does,  load the data.
        private void CheckIfModuleMotorExists()
        {
            DataTable info =
                Query.Select(
                    "Select * from moduleMotorLogic as mml inner join KitInfo on KitID = mml.ModuleID where KitName = '" + (!_asNew ? _moduleName : _previousName) + "'");
            if (info.Rows.Count != 0)
            {
                lblMotorValue.Text = info.Rows[0]["kitName"].ToString();
                nUdHP.Value = Convert.ToDecimal(info.Rows[0]["HP"]);
                nUdRPM.Value = Convert.ToInt32(info.Rows[0]["RPM"]);
                cboVoltage.SelectedIndex = cboVoltage.FindString(info.Rows[0]["Voltage"].ToString());
                nUdFLA.Value = Convert.ToDecimal(info.Rows[0]["FLA"]);
                txtTempMin.Text = info.Rows[0]["TempMinimum"].ToString();
                txtTempMax.Text = info.Rows[0]["TempMaximum"].ToString();
                nUdMotorWeight.Value = Convert.ToDecimal(info.Rows[0]["Weight"]);
                cboMotorType.SelectedIndex = cboMotorType.FindString(info.Rows[0]["MotorType"].ToString());
                DataTable cfms = Query.Select("Select * from moduleMotorCFM where moduleID = " + info.Rows[0]["ModuleID"]);
                foreach (DataRow cfm in cfms.Rows)
                {
                    dgCFM.Rows.Add(new object[] {cfm["CoilName"].ToString(), cfm["cfm"].ToString()});
                }
            }
        }

        //When initialising for water cooled cooler, turn every other group box invisible. Then check if the database has that specific water cooled condenser saved.
        private void InitializeWCC()
        {
            grpCompressor.Visible = false;
            btnSave.Visible = true;
            grpCoil.Visible = false;
            grpMotor.Visible = false;
            grpReceiver.Visible = false;
            grpBase.Visible = false;
            grpWCC.Visible = true;
            grpGeneric.Visible = false;
            btnSave.Top = 260;
            CheckIfModuleWCCExists();
        }

        //Make a select with the moduleName to check if the WaterCooledCondenser exists.  If it does, fill every textBox with the correct info.
        private void CheckIfModuleWCCExists()
        {
            DataTable info =
               Query.Select(
                   "Select * from moduleWCCLogic as mmw inner join KitInfo on KitID = mmw.ModuleID where KitName = '" + (!_asNew ? _moduleName : _previousName) + "'");
            if (info.Rows.Count != 0)
            {
                txtWCCR22.Text = info.Rows[0]["R-22"].ToString();
                txtWCCR134A.Text = info.Rows[0]["R-134A"].ToString();
                txtWCCR404A.Text = info.Rows[0]["R-404A"].ToString();
                txtWCCR407A.Text = info.Rows[0]["R-407A"].ToString();
                txtWCCR407C.Text = info.Rows[0]["R-407C"].ToString();
                txtWCCR410A.Text = info.Rows[0]["R-410A"].ToString();
                txtWCCR507A.Text = info.Rows[0]["R-507A"].ToString();
                txtWCCR744.Text = info.Rows[0]["R-744"].ToString();
                txtWCCModel.Text = info.Rows[0]["Model"].ToString();
                nUdWCCWeight.Value = Convert.ToDecimal(info.Rows[0]["Weight"].ToString());
            }
        }

        //When initialising for generic module, turn every other group box invisible. Then check if the database has that specific module saved.
        private void InitializeGeneric()
        {
            grpCompressor.Visible = false;
            btnSave.Visible = true;
            grpCoil.Visible = false;
            grpMotor.Visible = false;
            grpReceiver.Visible = false;
            grpBase.Visible = false;
            grpWCC.Visible = false;
            grpGeneric.Visible = true;
            btnSave.Top = 100;
            CheckIfModuleGenericExists();
        }

        //Make a select with the moduleName to check if the Generic module exists.  If it does, fill every The weight upDown with the correct info.
        private void CheckIfModuleGenericExists()
        {
            DataTable info =
            Query.Select(
            "Select * from moduleGenericLogic as mmg inner join KitInfo on KitID = mmg.ModuleID where KitName = '" + (!_asNew ? _moduleName : _previousName) + "'");
            if (info.Rows.Count != 0)
            {
                nUdGenericWeight.Value = Convert.ToDecimal(info.Rows[0]["Weight"].ToString());
            }
        }
       
        //When initializing a coil, turn every other group box invisible, then check if the database has the specific coil already saved.
        private void InitializeCoil()
        {
            grpCompressor.Visible = false;
            btnSave.Visible = true;
            grpCoil.Visible = true;
            grpMotor.Visible = false;
            grpReceiver.Visible = false;
            grpBase.Visible = false;
            grpWCC.Visible = false;
            grpGeneric.Visible = false;
            FillFinType();
            CheckIfModuleCoilExists();
        }

       //If the coil does exist in the database, extract all the related info from that coil and Fill every combobox/numeric updown with the correct data.
        private void CheckIfModuleCoilExists()
        {
            DataTable info =
           Query.Select(
           "Select * from moduleCoilLogic as mcl inner join KitInfo on KitID = mcl.ModuleID where KitName = '" + (!_asNew ? _moduleName : _previousName) + "'");
            if (info.Rows.Count != 0)
            {
                string test = info.Rows[0]["FinType"].ToString();
                cboFinType.SelectedIndex = cboFinType.FindString(test);
                cboFinShape.SelectedIndex = cboFinShape.FindString(info.Rows[0]["FinShape"].ToString());
                cboCircuits.SelectedIndex = cboCircuits.FindString(info.Rows[0]["Circuits"].ToString());
                cboFinHeight.SelectedIndex = cboFinHeight.FindString(Convert.ToDecimal(info.Rows[0]["FinHeight"]).ToString("0"));
                nUdFinLength.Value = Convert.ToDecimal(info.Rows[0]["FinLength"].ToString());
                nUdRows.Value = Convert.ToDecimal(info.Rows[0]["Rows"].ToString());
                cboFPI.SelectedIndex = cboFPI.FindString(Convert.ToDecimal(info.Rows[0]["FPI"]).ToString("0"));
                cboFinMaterial.SelectedIndex = cboFinMaterial.FindString(info.Rows[0]["FinMaterial"].ToString());
                cboFinThickness.SelectedIndex = cboFinThickness.FindString(info.Rows[0]["FinThickness"].ToString());
                cboTubeMaterial.SelectedIndex = cboTubeMaterial.FindString(info.Rows[0]["TubeMaterial"].ToString());
                cboTubeThickness.SelectedIndex = cboTubeThickness.FindString(info.Rows[0]["TubeThickness"].ToString());
                nUdFanWide.Value = Convert.ToInt32(info.Rows[0]["FanWide"].ToString());
                nUdFanLong.Value = Convert.ToInt32(info.Rows[0]["FanLong"].ToString());
                cboSubCooler.SelectedIndex =
                    cboSubCooler.FindString(info.Rows[0]["SubCooler"].ToString() == "False" ? "NO" : "YES");
                if (info.Rows[0]["SubCooler"].ToString() == "True")
                {
                    nUdFaceTube.Value = Convert.ToDecimal(info.Rows[0]["FaceTube"].ToString());
                    cboSubCoolerCircuits.SelectedIndex =
                        cboSubCoolerCircuits.FindString(info.Rows[0]["SubCoolerCircuits"].ToString());
                }
                nUdCoilWeight.Value = Convert.ToDecimal(info.Rows[0]["Weight"].ToString());
                }
        }

       //Selecting all the fin types (and their various info), and putting those in the finType combobox
        private void FillFinType()
        {
            DataTable fintypes = Query.Select("Select * from CoilFinType where Active = 1");
            foreach (DataRow row in fintypes.Rows)
            {
                ComboBoxControl.AddItem(cboFinType, row["UniqueID"].ToString(), row["FinType"] + " - " + row["TubeDiameter"] + @""", " + row["FaceTube"] + @""" X " + row["TubeRow"] + @"""");
            }
        }

        //Standard load to change color and apply language.  Then we add the name of the module to the name of the form.
        private void FrmLogic_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
            Text += @" : " + _moduleName;
        }

        //Calling the method to add a row
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddEmptyCFMRow();
        }

        //Checking if the number of rows is ok.  If it is, adding a new, empty row.  If it's not, warn the user.
        private void AddEmptyCFMRow()
        {
            if (dgCFM.Rows.Count > 17)
            {
                Public.LanguageBox("You cannot add more than 18 rows to this table, sorry.",
                    "Vous ne pouvez ajouter plus de 18 rangées à cette table, désolé");
            }
            else
            {
                dgCFM.Rows.Add(new object[] { "",  "" });    
            }
        }

        //sending the same command as if we pressed delete, to remove the selected row in the table
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteSelectedCFMRow();
        }

        //Checking the whole list of CFMs to delete the right one
        private void DeleteSelectedCFMRow()
        {
            foreach (DataGridViewRow row in dgCFM.Rows)
            {
                if (row.Selected)
                {
                    dgCFM.Rows.Remove(row);
                }
            }
        }   

        //Displaying the saved sizes in the database in a messageBox.
        private void btnShowSizes_Click(object sender, EventArgs e)
        {
            Public.LanguageBox("Here is an example of the format needed for the receiver size:  x\" X x\".  For instance, a receiver 6 by 10 will be shown as such : 6\" X 10\" ", "Voici un exemple du format demandé pour afficher la taille des réservoirs :  x\" X x\".  Par exemple, un réservoir 6 par 10 aura le format suivant :  6\" X 10\" ");
        }

        //If you put a subCooler, the rest of the subCooler related combobox and numeric up down will be enabled.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubCooler.Text == @"YES")
            {
                nUdFaceTube.Enabled = true;
                cboSubCoolerCircuits.Enabled = true;
            }
            else
            {
                nUdFaceTube.Enabled = false;
                cboSubCoolerCircuits.Enabled = false;
            }
            RecalculateWeight();
        }

        //Whenever you choose a fintype, change the rest of the data to empty, then refill what you can, and update the name of the coil
        private void cboFinType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFinShape.Text = "";
            cboFinHeight.Text = "";
            Fill_FinShape();
            Fill_FinHeight();
            Fill_FPI();
            Fill_FinMaterial();
            Fill_FinThickness();
            Fill_TubeMaterial();
            Fill_TubeThickness();
            UpdateCoilModel();
            RecalculateWeight();
        }

        //Whenever this method is called, we simply select all the finShapes available for the fintype selected, then add all those to the finShape combobox
        private void Fill_FinShape()
        {
            cboFinShape.Items.Clear();
            string letterForType = cboFinType.Text.Substring(0, 1);
            DataTable shapes = Query.Select(
                "Select [CoilFinShape].FinShape,[CoilFinShape].UniqueID from coilFinShape inner Join coilFinTypeShape on coilFinTypeShape.FinShape = CoilFinShape.FinShapeParameter where finType ='" +
                letterForType + "'");
            foreach (DataRow row in shapes.Rows)
            {
                ComboBoxControl.AddItem(cboFinShape,row["UniqueID"].ToString(),row["FinShape"].ToString());
            }
            if (cboFinShape.Items.Count > 0)
            {
                cboFinShape.SelectedIndex = 0;
            }
        }

        //Whenever we call this method, we create every height in the combo box for the fin height, depending on the info already selected.
        private void Fill_FinHeight()
        {
            cboFinHeight.Items.Clear();
            DataTable finType = Query.Select("select * from CoilFinType");
            decimal decFaceTubes = Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, finType, "UniqueID")[0]["FaceTube"]);

            const decimal decMaxFinHeight = 240m;

            //for each increment of face tubes, add the height
            for (decimal decFinHeight = decFaceTubes * QuickCoilCode.DecMinHeightInFaceTubes; decFinHeight < decMaxFinHeight; decFinHeight += decFaceTubes)
            {
                ComboBoxControl.AddItem(cboFinHeight, decFinHeight.ToString(CultureInfo.InvariantCulture), decFinHeight.ToString(CultureInfo.InvariantCulture));
            }

            cboFinHeight.SelectedIndex = 0;
        }

        //Use the CoilCode class to determine which FPI is available depending on the rest of the info entered, then fill the drop down.
        private void Fill_FPI()
        {
            var coilBackCode = new QuickCoilCode();

            cboFPI.Items.Clear();
            DataTable finType = Query.Select("select * from CoilFinType");
            //min and max fpi
            int intMinFPI = 0;
            int intMaxFPI = 0;

            //pass by reference the 2 variable which will return me the min and max fpi
            //available for this fin type
      
            coilBackCode.MinMaxFPI(Public.DSDatabase.Tables["v_CoilFinDefaults"], ComboBoxControl.ItemInformations(cboFinType, finType , "UniqueID")[0]["FinType"].ToString(), ref intMinFPI, ref intMaxFPI);

            //from the min to the max we add an item
            for (int intFPI = intMinFPI; intFPI <= intMaxFPI; intFPI++)
            {
                ComboBoxControl.AddItem(cboFPI, intFPI.ToString(CultureInfo.InvariantCulture), intFPI.ToString(CultureInfo.InvariantCulture));
            }
            cboFPI.SelectedIndex = cboFPI.FindString("10");
        }

        //Use the CoilCode class to make sure which FinMaterials are available depending on the info entered.  Then we fill the drop down with the correct materials
        private void Fill_FinMaterial()
        {
            var coilBackCode = new QuickCoilCode();

            cboFinMaterial.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            if (cboFinShape.Text != "" && cboFPI.Text != "")
            {
                //for each fin type
                foreach (DataRow drFinMaterial in Public.DSDatabase.Tables["CoilFinMaterial"].Rows)
                {
                    //if we can found the fintype in the table that mean it's available for
                    //the selected coil type so we can show it
                    if (coilBackCode.IsFinMaterialAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString(), ComboBoxControl.ItemInformations(cboFinShape, Public.DSDatabase.Tables["CoilFinShape"], "UniqueID")[0]["FinShapeParameter"].ToString(), Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI)), drFinMaterial["UniqueID"].ToString()))
                    {
                        string strIndex = drFinMaterial["UniqueID"].ToString();
                        string strText = drFinMaterial["FinMaterial"].ToString();
                        ComboBoxControl.AddItem(cboFinMaterial, strIndex, strText);
                    }
                }
            }

            if (cboFinMaterial.Items.Count > 0)
            {
                cboFinMaterial.SelectedIndex = 0;
            }
        }

        //When we chose the finMaterial, we can put in the thickness correctly, so we use the CoilCode class to make sure it's correct.
        private void Fill_FinThickness()
        {
            var coilBackCode = new QuickCoilCode();

            cboFinThickness.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            if (cboFinShape.Text != "" && cboFPI.Text != "" && cboFinMaterial.Text != "")
            {
                foreach (DataRow drFinThickness in Public.DSDatabase.Tables["CoilfinThickness"].Rows)
                {
                    //is fin thickness available for the following parameter
                    if (coilBackCode.IsFinThicknessAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString(), Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI)), ComboBoxControl.IndexInformation(cboFinMaterial),
                        drFinThickness["FinThickness"].ToString()))
                    {
                        string strIndex = drFinThickness["UniqueID"].ToString();
                        string strText = drFinThickness["FinThickness"].ToString();
                        ComboBoxControl.AddItem(cboFinThickness, strIndex, strText);
                    }
                }
                var quickCode = new QuickCoilCode();
                ComboBoxControl.SetDefaultValue(cboFinThickness, quickCode.FinThicknessDefault(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString(), ComboBoxControl.ItemInformations(cboFinShape, Public.DSDatabase.Tables["CoilFinShape"], "UniqueID")[0]["FinShapeParameter"].ToString(), Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI)), ComboBoxControl.IndexInformation(cboFinMaterial)));
            }
           
        }

        //When the finType is selected, we already know which tubes we can and can't use.  So we use the coilCode class to check which ones we can use, and then put these in
        //the correct combobox
        private void Fill_TubeMaterial()
        {
            var coilBackCode = new QuickCoilCode();

            cboTubeMaterial.Items.Clear();

            if (cboFinType.SelectedIndex >= 0)
            {

                //these variable as use for easier modification of index or text showing
                //in the combobox

                DataTable dtTubeMaterial =
                    Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CoilTubeMaterial"].Copy());

                //for each material type
                foreach (DataRow drTubeMaterial in dtTubeMaterial.Rows)
                {
                    if (coilBackCode.IsTubeMaterialAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], (cboFinType.Text[0] == 'P'?"ST":"HR"),
                        ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString(), drTubeMaterial["UniqueID"].ToString(), false))
                    {
                        string strIndex = drTubeMaterial["UniqueID"].ToString();
                        string strText = drTubeMaterial["TubeMaterial"].ToString();
                        ComboBoxControl.AddItem(cboTubeMaterial, strIndex, strText);
                    }
                }
                dtTubeMaterial.Dispose();
                if (cboTubeMaterial.Items.Count > 0)
                {
                    cboTubeMaterial.SelectedIndex = 0;
                }
            }
        }

        //We fill the Tube Thickness dropDown.  It all depends on the tube material, so we make sure, when we try to fill the tube thickness, that the tube material isn't empty.
        //Then we use the coilCode to give us which thicknesses are ok.
        private void Fill_TubeThickness()
        {
            var coilBackCode = new QuickCoilCode();

            cboTubeThickness.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            if(cboTubeMaterial.Text != "")
            {
                foreach (DataRow drTubeThickness in Public.DSDatabase.Tables["CoilTubeThickness"].Rows)
                {
    
                    if (coilBackCode.IsTubeThicknessAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], "" , ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString(), ComboBoxControl.IndexInformation(cboTubeMaterial), drTubeThickness["TubeThickness"].ToString(), false))
                    {
                        string strIndex = drTubeThickness["UniqueID"].ToString();
                        string strText = drTubeThickness["TubeThickness"].ToString();
                        ComboBoxControl.AddItem(cboTubeThickness, strIndex, strText);
                    }
                }
            }
            var quickCode = new QuickCoilCode();
            ComboBoxControl.SetDefaultValue(cboTubeThickness, quickCode.TubeThicknessDefault(Public.DSDatabase.Tables["v_CoilTubeDefaults"], "", ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString(), ComboBoxControl.IndexInformation(cboTubeMaterial), false));
        }

      

        //Whenever we change the finShape, we need to unselect the FPI, then fill a lot of info.  Finally, we can update the coil model
        private void cboFinShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_FinMaterial();
            Fill_FinThickness();
            Fill_TubeMaterial();
            Fill_TubeThickness();
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When the FPI is selected, we have access to the FinMaterial, so we need to fill it in accordance.  Also the name of the model changes, since FPI is directly in the name.
        //so we update the name.
        private void cboFPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            Fill_FinMaterial();
            RecalculateWeight();
        }

        //When you select a new TubeMaterial, the TubeThickness becomes available, so we need to fill it.  Also the name of the coil could change, so we need to update that.
        private void cboTubeMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCoilModel(); 
            Fill_TubeThickness();
            RecalculateWeight();
        }

        //When you select a new finMaterial, the FinThickness becomes available, so we need to fill it.  Also the name of the coil could change, so we need to update that.
        private void cboFinMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCoilModel(); 
            Fill_FinThickness();
            RecalculateWeight();
        }

        //Create the model name, but change every unknown with ??.  Will make it dynamic instead of only generating at the end
        private void UpdateCoilModel()
        {
            string strReturnValue = "C";

            //add the fin Type
            if (cboFinType.Text != "")
            {
                strReturnValue = strReturnValue + ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"];
            }
            else
            {
                strReturnValue = strReturnValue + "?";
            }

            //add the fin shape
            if(cboFinShape.Text != "")
            {
                strReturnValue = strReturnValue + ComboBoxControl.ItemInformations(cboFinShape, Public.DSDatabase.Tables["CoilFinShape"], "UniqueID")[0]["FinShapeParameter"];
            }
            else
            {
                strReturnValue = strReturnValue + "?";
            }
            
            //add a dash
            strReturnValue = strReturnValue + "-";

            //add the tubes
            if(cboFinHeight.Text != "" && cboFinType.Text != "")
            {
                strReturnValue = strReturnValue + Convert.ToInt32(Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight)) / Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FaceTube"])).ToString(CultureInfo.InvariantCulture).PadLeft(2, Convert.ToChar("0"));
            }
            else
            {
                strReturnValue += "??";
            }
            //add a dash
            strReturnValue = strReturnValue + "-";

            //add number of rows (make usre always 2 characters so use padleft)
            if(nUdRows.Value != 0)
            {
                strReturnValue = strReturnValue + Convert.ToInt32(nUdRows.Value).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            }
            else
            {
                strReturnValue += "??";
            }

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add FPI (make usre always 2 characters so use padleft)
            if(cboFPI.Text != "")
            {
                strReturnValue = strReturnValue + cboFPI.Text.PadLeft(2, '0');
            }
            else
            {
                strReturnValue += "??";
            }

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add fin length (make usre always 2 characters so use padleft)
            if (nUdFinLength.Value != 0)
            {
                strReturnValue = strReturnValue + nUdFinLength.Value.ToString("0#.###");
            }
            else 
            {
                strReturnValue += "??";
            }
            txtModel.Text = strReturnValue;
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void cboCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void cboFinHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void nUdFinLength_ValueChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void nUdRows_ValueChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void cboFinThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void cboTubeThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void nUdFanWide_ValueChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        //When one value on the coil Group changes, try to regenerate the model name
        private void nUdFanLong_ValueChanged(object sender, EventArgs e)
        {
            UpdateCoilModel();
            RecalculateWeight();
        }

        private void cboSubCoolerCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculateWeight();
        }

        private void nUdFaceTube_ValueChanged(object sender, EventArgs e)
        {
            RecalculateWeight();
        }

        private void RecalculateWeight()
        {
            //Need to validate first all data is properly entered, then calculate weight
            if (cboFinType.Text != "" && cboFinHeight.Text != "" && nUdFinLength.Value != 0 && nUdRows.Value != 0 &&
                cboFPI.Text != "" && 
                cboFinMaterial.Text != "" && cboFinThickness.Text !="" && cboTubeMaterial.Text != "" && cboTubeThickness.Text != "")
            {
                var cw = new CoilWeight();
                var quickCode = new QuickCoilCode();
                decimal finHeight = Convert.ToDecimal(cboFinHeight.Text);
                decimal finLength = nUdFinLength.Value;
                decimal faceTubes = Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FaceTube"]);
                decimal tubeDiameter = Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["TubeDiameter"]);
                decimal tubeRow= Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["TubeRow"]);
                decimal numberOfRows = nUdRows.Value;
                decimal fpi = Convert.ToDecimal(cboFPI.Text);
                decimal finDensity = Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinMaterial, Public.DSDatabase.Tables["CoilFinMaterial"], "UniqueID")[0]["MaterialDensity"]);
                decimal finThickness = Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinThickness, Public.DSDatabase.Tables["CoilfinThickness"], "UniqueID")[0]["FinThickness"].ToString());
                decimal tubeDensity = Convert.ToDecimal(ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["MaterialDensity"]);
                decimal tubeThickness = Convert.ToDecimal(ComboBoxControl.ItemInformations(cboTubeThickness, Public.DSDatabase.Tables["CoilTubeThickness"], "UniqueID")[0]["TubeThickness"].ToString());
                decimal headerPoundsPerSquareFoot = quickCode.ConnectionSizePoundsPerFoot(Public.DSDatabase.Tables["ConnectionSize_PoundsPerFoot"], 2.625m);
                nUdCoilWeight.Value = cw.GetCoilTotalWeight(finHeight,finLength,faceTubes,tubeDiameter,tubeRow,numberOfRows,fpi,0.29m,0.052m,finDensity,finThickness,tubeDensity,tubeThickness,headerPoundsPerSquareFoot);
            }
        }

        private void nUdHP_Enter(object sender, EventArgs e)
        {
            nUdHP.Select(0, nUdHP.Text.Length);
        }

        private void nUdRPM_Enter(object sender, EventArgs e)
        {
            nUdRPM.Select(0, nUdRPM.Text.Length);
        }

        private void nUdFLA_Enter(object sender, EventArgs e)
        {
            nUdFLA.Select(0, nUdFLA.Text.Length);
        }

        private void txtTempMin_Enter(object sender, EventArgs e)
        {
            txtTempMin.SelectAll();
        }

        private void txtTempMax_Enter(object sender, EventArgs e)
        {
            txtTempMax.SelectAll();
        }

        private void nUdMotorWeight_Enter(object sender, EventArgs e)
        {
            nUdMotorWeight.Select(0, nUdMotorWeight.Text.Length);
        }

        private void nUdFinLength_Enter(object sender, EventArgs e)
        {
            nUdFinLength.Select(0,nUdFinLength.Text.Length);
        }

        private void nUdRows_Enter(object sender, EventArgs e)
        {
            nUdRows.Select(0,nUdRows.Text.Length);
        }

        private void nUdFanWide_Enter(object sender, EventArgs e)
        {
            nUdFanWide.Select(0, nUdFanWide.Text.Length);
        }

        private void nUdFanLong_Enter(object sender, EventArgs e)
        {
            nUdFanLong.Select(0, nUdFanLong.Text.Length);
        }

        private void nUdFaceTube_Enter(object sender, EventArgs e)
        {
            nUdFaceTube.Select(0, nUdFaceTube.Text.Length);
        }

        private void nUdCoilWeight_Enter(object sender, EventArgs e)
        {
            nUdCoilWeight.Select(0,nUdCoilWeight.Text.Length);
        }

        private void txtWCCR22_Enter(object sender, EventArgs e)
        {
            txtWCCR22.SelectAll();
        }

        private void txtWCCR134A_Enter(object sender, EventArgs e)
        {
            txtWCCR134A.SelectAll();
        }

        private void txtWCCR404A_Enter(object sender, EventArgs e)
        {
            txtWCCR404A.SelectAll();
        }

        private void txtWCCR407C_Enter(object sender, EventArgs e)
        {
            txtWCCR407C.SelectAll();
        }

        private void txtWCCR507A_Enter(object sender, EventArgs e)
        {
            txtWCCR507A.SelectAll();
        }

        private void txtWCCR410A_Enter(object sender, EventArgs e)
        {
            txtWCCR410A.SelectAll();
        }

        private void txtWCCR407A_Enter(object sender, EventArgs e)
        {
            txtWCCR407A.SelectAll();
        }

        private void txtWCCR744_Enter(object sender, EventArgs e)
        {
            txtWCCR744.SelectAll();
        }

        private void txtWCCModel_Enter(object sender, EventArgs e)
        {
            txtWCCModel.SelectAll();
        }

        private void nUdWCCWeight_Enter(object sender, EventArgs e)
        {
            nUdWCCWeight.Select(0,nUdWCCWeight.Text.Length);
        }

        private void txtLength_Enter(object sender, EventArgs e)
        {
            txtLength.SelectAll();
        }

        private void txtWidth_Enter(object sender, EventArgs e)
        {
            txtWidth.SelectAll();
        }

        private void txtHeight_Enter(object sender, EventArgs e)
        {
            txtHeight.SelectAll();
        }

        private void nUdBaseWeight_Enter(object sender, EventArgs e)
        {
            nUdBaseWeight.Select(0,nUdBaseWeight.Text.Length);
        }

        private void nUdGenericWeight_ValueChanged(object sender, EventArgs e)
        {
            nUdGenericWeight.Select(0, nUdGenericWeight.Text.Length);
        }

        private void txtR22_Enter(object sender, EventArgs e)
        {
            txtR22.SelectAll();
        }

        private void txtR134A_Enter(object sender, EventArgs e)
        {
            txtR134A.SelectAll();
        }

        private void txtR404A_Enter(object sender, EventArgs e)
        {
            txtR404A.SelectAll();
        }

        private void txtR407C_Enter(object sender, EventArgs e)
        {
            txtR407C.SelectAll();
        }

        private void txtR507A_Enter(object sender, EventArgs e)
        {
            txtR507A.SelectAll();
        }

        private void txtR410A_Enter(object sender, EventArgs e)
        {
            txtR410A.SelectAll();
        }

        private void txtR407A_Enter(object sender, EventArgs e)
        {
            txtR407A.SelectAll();
        }

        private void txtR744_Enter(object sender, EventArgs e)
        {
            txtR744.SelectAll();
        }

        private void txtSize_Enter(object sender, EventArgs e)
        {
            txtSize.SelectAll();
        }

        private void nUdReceiverWeight_Enter(object sender, EventArgs e)
        {
            nUdReceiverWeight.Select(0, nUdReceiverWeight.Text.Length);
        }

        private void nUdCompressorWeight_Enter(object sender, EventArgs e)
        {
            nUdCompressorWeight.Select(0,nUdCompressorWeight.Text.Length);
        }


    }
}
