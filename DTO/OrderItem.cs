namespace HHPW.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}