
namespace RefplusWebtools
{
    class BalancingData
    {
        public BalancingData(decimal capacity, decimal kw, decimal ambient, decimal sst, decimal condensing, decimal liquidPressureDrop)
        {
            CAPACITY = capacity;
            KW = kw;
            CONDENSING = condensing;
            AMBIENT = ambient;
            SST = sst;
            EER = CAPACITY / (KW * 1000m);
            LIQUIDPRESSUREDROP = liquidPressureDrop;
        }

        public decimal CAPACITY { get; private set; }
        public decimal KW { get; private set; }
        public decimal CONDENSING { get; private set; }
        public decimal EER { get; private set; }
        public decimal AMBIENT { get; private set; }
        public decimal SST { get; private set; }
        public decimal LIQUIDPRESSUREDROP { get; private set; }
    }
}
