using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCondenser
{
    public partial class FrmCircuitEdit : Form
    {
        private readonly string _typeOfCondenser = "";
        private readonly FrmQuickCondenser _condenserParentForm;
        private readonly int _index = -1;
        private readonly decimal _condenserParentAmbientTemperature;
        private bool _isTdOk = true;

        //form need access to his background code
        private readonly QuickCondenserCode _backgroundCode = new QuickCondenserCode();

        public FrmCircuitEdit(FrmQuickCondenser condenserParentForm, string typeOfCondenser, int index, decimal condenserParentAmbientTemperature)
        {
            InitializeComponent();

            _condenserParentForm = condenserParentForm;
            _typeOfCondenser = typeOfCondenser;
            _index = index;
            _condenserParentAmbientTemperature = condenserParentAmbientTemperature;
        }

        private void frmCircuitEdit_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);
            
            Fill_CompressorType();

            Fill_Refrigerant();

            ValidateCapacityType();

            cboCapacityType.SelectedIndex = 0;

            cboRefrigerant.SelectedIndex = 0;

            cboCompressorType.SelectedIndex = 0;

            if (_index != -1)
            {
                LoadCircuitData();
            }
            else
            {//if new we actually want to reload default

                cboCapacityType.SelectedIndex = cboCapacityType.FindString(_condenserParentForm.LastCapacityType);
                cboCompressorType.SelectedIndex = cboCompressorType.FindString(_condenserParentForm.LastCompressorType);
                numSST.Value = _condenserParentForm.LastSST;
                cboRefrigerant.SelectedIndex = cboRefrigerant.FindString(_condenserParentForm.LastRefrigerant);
                numCondenserTemperature.Value = _condenserParentForm.LastCondensingTemp;
                numTotalHeatRejection.Value = _condenserParentForm.LastTHR;
            }
        }

        private void LoadCircuitData()
        {
            cboRefrigerant.SelectedIndex = cboRefrigerant.FindString(_condenserParentForm.DtRefrigrantCircuit.Rows[_index]["RefrigerantType"].ToString());
            numCondenserTemperature.Value = Convert.ToDecimal(_condenserParentForm.DtRefrigrantCircuit.Rows[_index]["CondenserTemperature"]);
            
            
            if (_condenserParentForm.DtRefrigrantCircuit.Rows[_index]["CircuitType"].ToString() == "N")
            {//if NRE
                cboCapacityType.SelectedIndex = 1;
                cboCompressorType.SelectedIndex = cboCompressorType.FindString(_condenserParentForm.DtRefrigrantCircuit.Rows[_index]["CompressorType"].ToString());
                numSST.Value = Convert.ToDecimal(_condenserParentForm.DtRefrigrantCircuit.Rows[_index]["SST"]);
            }
            else
            {
                cboCapacityType.SelectedIndex = 0;
            }

            numTotalHeatRejection.Value = Convert.ToDecimal(_condenserParentForm.DtRefrigrantCircuit.Rows[_index]["NonConvertedTHR"]);
        }

        private string CompressorType()
        {
            return ComboBoxControl.IndexInformation(cboCompressorType);
        }

        private void Fill_CompressorType()
        {
            cboCompressorType.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            foreach (DataRow drCompressorType in Public.DSDatabase.Tables["CondenserNRECompressorType"].Rows)
            {
                string strIndex = drCompressorType["TypeParameter"].ToString();
                string strText = drCompressorType["Type"].ToString();
                ComboBoxControl.AddItem(cboCompressorType, strIndex, strText);
            }
        }

        private void cboCapacityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateCapacityType();
        }

        //get Refrigerant capacity adjustement
        private decimal RefrigerantCapacityAdjustment()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboRefrigerant, Public.DSDatabase.Tables["CondenserRefrigerant"], "RefrigerantID")[0]["CondenserCapMult"]);
        }

        //fill Refrigerant
        private void Fill_Refrigerant()
        {
            cboRefrigerant.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each refrigerant
            foreach (DataRow drRefrigerant in Public.DSDatabase.Tables["CondenserRefrigerant"].Rows)
            {
                string strIndex = drRefrigerant["RefrigerantID"].ToString();
                string strText = drRefrigerant["RefrigerantID"].ToString();
                ComboBoxControl.AddItem(cboRefrigerant, strIndex, strText);
            }
        }

        private void ValidateCapacityType()
        {

            //if heat reclaim is selected we can choose how much
            //heat recovery the unit will do in percentage
            if (_typeOfCondenser == "H")
            {
                lblReclaimCapacity.Visible = true;
                lblTotalHeatRejection.Visible = false;
                cboCapacityType.SelectedIndex = 0;
                cboCapacityType.Enabled = false;
                pnlNRE.Visible = false;
                lblNRE.Visible = false;
            }
            else
            {
                lblReclaimCapacity.Visible = false;
                lblTotalHeatRejection.Visible = false;
                pnlNRE.Visible = false;
                lblNRE.Visible = false;
                if (cboCapacityType.SelectedIndex == 0)
                {
                    lblTotalHeatRejection.Visible = true;
                }
                else
                {
                    lblNRE.Visible = true;
                    pnlNRE.Visible = true;
                }
                cboCapacityType.Enabled = true;
            }
        }

        private void cmdSaveCircuit_Click(object sender, EventArgs e)
        {
            if (_isTdOk)
            {
                decimal decCapacity = numTotalHeatRejection.Value;

                //if NRE
                if (cboCapacityType.SelectedIndex == 1)
                {
                    decCapacity = _backgroundCode.GetConvertedNRECapacityToTHR(Public.DSDatabase.Tables["CondenserNREHermeticFactor"], Public.DSDatabase.Tables["CondenserNREOpenDriveFactor"], decCapacity, numCondenserTemperature.Value, numSST.Value, CompressorType());
                }

                //-9999 is an hardcoded value for when the temperature are out of range of
                //the table refplus provided us.
                if (decCapacity != -9999)
                {
                    ThreadProcess.Start(Public.LanguageString("Running Selection", "Sélection en cours"));

                    if (_index == -1)
                    {//new circuit
                        _condenserParentForm.AddNewCircuit(cboRefrigerant.Text, numCondenserTemperature.Value, decCapacity, RefrigerantCapacityAdjustment(), (cboCapacityType.SelectedIndex == 0 ? "T" : "N"), numTotalHeatRejection.Value, cboCompressorType.Text, numSST.Value);

                        //these variable are used to store the latest value of all controls in the
                        //circuit add/edit form
                        _condenserParentForm.LastCapacityType = cboCapacityType.Text;
                        _condenserParentForm.LastCompressorType = cboCompressorType.Text;
                        _condenserParentForm.LastSST = numSST.Value;
                        _condenserParentForm.LastRefrigerant = cboRefrigerant.Text;
                        _condenserParentForm.LastCondensingTemp = numCondenserTemperature.Value;
                        _condenserParentForm.LastTHR = numTotalHeatRejection.Value;
                        
                    }
                    else
                    {//edit circuit
                        _condenserParentForm.EditCircuit(_index, cboRefrigerant.Text, numCondenserTemperature.Value, decCapacity, RefrigerantCapacityAdjustment(), (cboCapacityType.SelectedIndex == 0 ? "T" : "N"), numTotalHeatRejection.Value, cboCompressorType.Text, numSST.Value);
                    }

                    _condenserParentForm.ConfirmCircuits();

                    Close();
                }
                else
                {
                    Public.LanguageBox("Temperature outside range", "Temperature en dehors des limites permises");
                }
            }
            else
            {
                Public.LanguageBox("You must adjust your temperatures to have your TD below 31°F.", "Vous devez ajuster votre température afin d'avoir votre TD dessous de 31°F.");
            }
        }

        private void numCondenserTemperature_ValueChanged(object sender, EventArgs e)
        {
            if (_typeOfCondenser == "C")
            {
                if ((numCondenserTemperature.Value - _condenserParentAmbientTemperature) > 30)
                {
                    Public.LanguageBox("Maximum TD allowed is 30°F.", "Maximum TD autorisé est de 30°F.");
                    _isTdOk = false;
                }
                else
                {
                    _isTdOk = true;
                }
            }
        }
    }
}