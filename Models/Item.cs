namespace HHPW.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<OrderItem> Order { get; set; } = new List<OrderItem>();
    }
}