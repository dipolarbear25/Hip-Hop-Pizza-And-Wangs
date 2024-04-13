using HHPW.Models;
using Microsoft.EntityFrameworkCore;
namespace HHPW.API
{
    public class OrderItemAPI
    {
        public static void Map(WebApplication app) 
        {
            app.MapPost("/api/addItemToOrder/{orderId}", (HipHopPizzaAndWangsDbContext db, int orderId, Item newItem) =>
            {
                Order order = db.Orders.Include(o => o.Items).SingleOrDefault(o => o.Id == orderId);
                if (order == null)
                {
                    return Results.NotFound("Order not found");
                }

                Item existingItem = db.Items.SingleOrDefault(i => i.Id == newItem.Id);
                if (existingItem == null)
                {
                    return Results.NotFound("Item not found");
                }

                OrderItemDto newOrderItem = new OrderItemDto
                {
                    Order = order,
                    Item = existingItem
                };

                order.Items.Add(newOrderItem);

                db.SaveChanges();

                return Results.Ok("Item added to order successfully");
            });


        }
    }
}
