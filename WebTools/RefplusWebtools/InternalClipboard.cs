using System.Data;

namespace RefplusWebtools
{
    class InternalClipboard
    {
        private static DataTable _dtAdditionalItems;

        public static void Add_AdditionalItem(string description, int quantity, decimal price)
        {
            SetAdditionalItems();

            DataRow drAdditionalItems = _dtAdditionalItems.NewRow();

            drAdditionalItems["Description"] = description;
            drAdditionalItems["Quantity"] = quantity;
            drAdditionalItems["Price"] = price;

            _dtAdditionalItems.Rows.Add(drAdditionalItems);
        }

        public static void Delete_AdditionalItem(int rowindex)
        {
            if (_dtAdditionalItems.Rows.Count >= rowindex)
            {
                _dtAdditionalItems.Rows.RemoveAt(rowindex);
            }
        }

        public static void Clear_AdditionalItems()
        {
            if (_dtAdditionalItems != null)
            {
                _dtAdditionalItems.Rows.Clear();
            }
        }

        public static DataTable Get_AdditionalItems()
        {
            return (_dtAdditionalItems != null ? _dtAdditionalItems.Copy() : null);
        }

        private static void SetAdditionalItems()
        {
            if (_dtAdditionalItems == null) _dtAdditionalItems = Tables.DtAdditionalItems();
        }
    }
}
