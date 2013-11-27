
namespace RefplusWebtools
{
    
    class Quintuple
    {
        public decimal Quantity { get; set; }
        public string ID { get; private set; }
        public string Description { get; private set; }
        public string Price { get;  set; }
        public string Unit { get; private set; }


        public Quintuple(decimal quantity, string id, string description, string price, string unit)
        {
            Quantity = quantity;
            ID = id;
            Description = description;
            Price = price;
            Unit = unit; 
        }

    }
}
