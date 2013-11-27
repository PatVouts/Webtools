
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Costing
{
    public partial class FrmBalancingInfo : Form
    {

        private decimal _ambientMin;
        private decimal _ambientMax;
        private decimal _sstMin;
        private decimal _sstMax;
        private decimal _commercialFactor;

        public FrmBalancingInfo()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, System.EventArgs e)
        {
            _ambientMin = numBalancingMin.Value;
            _ambientMax = numBalancingMax.Value;
            _sstMin = numSSTMin.Value;
            _sstMax = numSSTMax.Value;
            _commercialFactor = numCommercializedFactor.Value;
            Visible = false;
        }

        public decimal GetAmbientMin()
        {
            return _ambientMin;
        }
        public decimal GetAmbientMax()
        {
            return _ambientMax;
        }
        public decimal GetSSTMin()
        {
            return _sstMin;
        }
        public decimal GetSSTMax()
        {
            return _sstMax;
        }
        public decimal GetFactor()
        {
            return _commercialFactor;
        }

        private void FrmBalancingInfo_Load(object sender, System.EventArgs e)
        {
            Public.ChangeFormLanguage(this);
            Public.ChangeColor(this);
        }
    }
}
