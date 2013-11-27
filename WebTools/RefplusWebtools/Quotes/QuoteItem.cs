
namespace RefplusWebtools.Quotes
{
    class QuoteItem
    {
        public enum ItemType { Coil = 0, Condenser = 1, CondensingUnit = 2, Evaporator = 3, FluidCooler = 4, ManualCoil = 5, HeatPipe = 6, GravityCoil = 7, CustomUnit = 8, OEMCoil = 9, NRECondenser = 10, WaterEvaporator = 11 };

        public static int ItemTypeToValue(ItemType it)
        {
            int value = 0;

            switch (it)
            {
                case ItemType.Coil:
                    value = 0;
                    break;
                case ItemType.Condenser:
                    value = 1;
                    break;
                case ItemType.CondensingUnit:
                    value = 2;
                    break;
                case ItemType.Evaporator:
                    value = 3;
                    break;
                case ItemType.FluidCooler:
                    value = 4;
                    break;
                case ItemType.ManualCoil:
                    value = 5;
                    break;
                case ItemType.HeatPipe:
                    value = 6;
                    break;
                case ItemType.GravityCoil:
                    value = 7;
                    break;
                case ItemType.CustomUnit:
                    value = 8;
                    break;
                case ItemType.OEMCoil:
                    value = 9;
                    break;
                case ItemType.NRECondenser:
                    value = 10;
                    break;
                case ItemType.WaterEvaporator:
                    value = 11;
                    break;
            }

            return value;
        }

        public static ItemType ValueToItemType(int value)
        {
            var it = ItemType.Coil;

            switch (value)
            {
                case 0:
                    it = ItemType.Coil;
                    break;
                case 1:
                    it = ItemType.Condenser;
                    break;
                case 2:
                    it = ItemType.CondensingUnit;
                    break;
                case 3:
                    it = ItemType.Evaporator;
                    break;
                case 4:
                    it = ItemType.FluidCooler;
                    break;
                case 5:
                    it = ItemType.ManualCoil;
                    break;
                case 6:
                    it = ItemType.HeatPipe;
                    break;
                case 7:
                    it = ItemType.GravityCoil;
                    break;
                case 8:
                    it = ItemType.CustomUnit;
                    break;
                case 9:
                    it = ItemType.OEMCoil;
                    break;
                case 10:
                    it = ItemType.NRECondenser;
                    break;
                case 11:
                    it = ItemType.WaterEvaporator;
                    break;
            }

            return it;
        }
    }
}
