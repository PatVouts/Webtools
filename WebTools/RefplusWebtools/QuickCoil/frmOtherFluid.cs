using System;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCoil
{

    /* This class lets the user input his own custom fluid for fluid coolers/ fluid heaters*/
    public partial class FrmOtherFluid : Form
    {
        //info to be saved
        private string _fluidName = "";
        private decimal _specificHeat;
        private decimal _density;
        private decimal _viscosity;
        private decimal _thermalConductivity;
        private decimal _freezingPoint;
        private bool _saved;

        public FrmOtherFluid()
        {
            InitializeComponent();
        }

        //Initializing in case we open a quotation with a custom fluid existing
        public FrmOtherFluid(string fluidName, decimal specificHeat, decimal density, decimal viscosity, decimal thermalConductivity, decimal freezingPoint)
        {
            InitializeComponent();
            _fluidName = fluidName;
            _specificHeat = specificHeat;
            _density = density;
            _viscosity = viscosity;
            _thermalConductivity = thermalConductivity;
            
            _freezingPoint = freezingPoint;
            _saved = false;
            LoadValues();
        }

        //simple gets for when we're done with the frmOtherFluid.
        public string GetFluidName()
        {
            return _fluidName;
        }

        public decimal GetSpecificHeat()
        {
            return _specificHeat;
        }

        public decimal GetDensity()
        {
            return _density;
        }

        public decimal GetViscosity()
        {
            return _viscosity;
        }

        public decimal GetThermalConductivity()
        {
            return _thermalConductivity;
        }
        public decimal GetFreezingPoint()
        {
            return _freezingPoint;
        }
        public bool GetSaved()
        {
            return _saved;
        }


        // when you click save, these are saved to be later grabbed by the parent process
        private void SetValues()
        {
            _fluidName = txtFluidTypeName.Text;
            _specificHeat = numSpecificHeat.Value;
            _density = numDensity.Value;
            _viscosity = numViscosity.Value;
            _thermalConductivity = numThermalConductivity.Value;
            _freezingPoint = numFreezing.Value;
            
        }


        //if it is opened with a set of existing values, need to show these values in the form)
        private void LoadValues()
        {
            txtFluidTypeName.Text = _fluidName == "" ? "" : _fluidName;
            numSpecificHeat.Value = _specificHeat;
            numDensity.Value = _density;
            numViscosity.Value = _viscosity;
            numThermalConductivity.Value = _thermalConductivity;
            numFreezing.Value = _freezingPoint;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            SetValues();
            _saved = true;
            Public.LanguageBox("Your custom fluid won't be saved until you fully save the coil AND the quote.  If you go back to the fluid before saving, old values will still be displayed.  The LAST update you make on the custom fluid before saving coil & quote will be the update in the database", "Votre fluide personnalisé ne sera pas sauvegardé tant que le serpentin ET la quotation ne seront pas sauvegardés également. Si vous retournez modifier le fluide avant de tout sauvegarder, les anciennes valeurs apparaîtront.  La dernière modification faite au fluide sera celle qui est appliquée");
            Close();
        }

        /*if you cancel by pressing close, we go to the parent, or we close this form if there's no parent (should always
        be a parent, but better be safe*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Show();
            }
            else
            {
                Close();
            }
        }

        private void frmOtherFluid_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        // this is for help files
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmOtherFluid_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}