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
                Order order = db.Orders.Include(o => o.OrItemsConnection).SingleOrDefault(o => o.Id == orderId);
                if (order == null)
                {
                    return Results.NotFound("Order not found");
                }

                Item existingItem = db.Items.SingleOrDefault(i => i.Id == newItem.Id);
                if (existingItem == null)
                {
                    return Results.NotFound("Item not found");
                }

                OrderItem newOrderItem = new OrderItem
                {
                    Order = order,
                    Item = existingItem
                };

                order.OrItemsConnection.Add(newOrderItem);

                db.SaveChanges();

                return Results.Ok("Item added to order successfully");
            });

            app.MapDelete("/api/deleteItemFromOrder/{orderId}/{itemId}", (HipHopPizzaAndWangsDbContext db, int orderId, int itemId) =>
            {
                Order order = db.Orders.Include(o => o.OrItemsConnection).SingleOrDefault(o => o.Id == orderId);
                if (order == null)
                {
                    return Results.NotFound("Order not found");
                }

                OrderItem orderItem = order.OrItemsConnection.FirstOrDefault(oi => oi.Item.Id == itemId);
                if (orderItem == null)
                {
                    return Results.NotFound("Item not found in the order");
                }

                order.OrItemsConnection.Remove(orderItem);
                db.OrderItems.Remove(orderItem);

                db.SaveChanges();

                return Results.Ok("Item deleted from order successfully");
            });

        }
    }
}
