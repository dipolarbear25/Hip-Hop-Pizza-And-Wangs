using HHPW.Models;


namespace HHPW.Data
{
    public class OrderTypeData
    {
        public static List<OrderType> OrderTypes = new List<OrderType>
        {
            new OrderType
            {
                Id = 1,
                Name = "Credit",
            },
            new OrderType
            {
                Id = 2,
                Name = "Debit",
            },
            new OrderType 
            {
                Id = 3,
                Name = "Phone"
            }
        };
    }
}