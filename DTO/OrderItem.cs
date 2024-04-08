namespace HHPW.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}