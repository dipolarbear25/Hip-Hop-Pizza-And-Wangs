using HHPW.Models;
using Microsoft.EntityFrameworkCore;

namespace HHPW.API
{
    public static class OrdersAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/orders", (HipHopPizzaAndWangsDbContext db) =>
            {
                return db.Orders.ToList();
            });

            app.MapGet("api/orders/{id}", (HipHopPizzaAndWangsDbContext db, int id) =>
            {
                var orderDetails = db.Orders
                .FirstOrDefault(orders => orders.Id == id);

                if (orderDetails == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(orderDetails);
            });

            app.MapPost("/api/orders", (HipHopPizzaAndWangsDbContext db, Order newOrder) =>
            {
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return Results.Created($"/orders/{newOrder.Id}", newOrder);
            });

            app.MapPut("/api/updateOrder/{orderId}", (HipHopPizzaAndWangsDbContext db, int orderId, Order updatedOrder) =>
            {
                Order existingOrder = db.Orders.SingleOrDefault(o => o.Id == orderId);
                if (existingOrder == null)
                {
                    return Results.NotFound("Order not found");
                }

                existingOrder.Name = updatedOrder.Name;
                existingOrder.Status = updatedOrder.Status;
                existingOrder.PhoneNum = updatedOrder.PhoneNum;
                existingOrder.Email = updatedOrder.Email;
                existingOrder.Type = updatedOrder.Type;
                existingOrder.PaymentType = updatedOrder.PaymentType;
                existingOrder.Total = updatedOrder.Total;
                existingOrder.Tip = updatedOrder.Tip;

                foreach (var updatedOrderItem in updatedOrder.Items)
                {
                    OrderItemDto existingOrderItem = existingOrder.Items.SingleOrDefault(oi => oi.Id == updatedOrderItem.Id);
                    if (existingOrderItem == null)
                    {
                        existingOrderItem = new OrderItemDto();
                        existingOrder.Items.Add(existingOrderItem);
                    }

                    existingOrderItem.Item = updatedOrderItem.Item;
                }

                db.SaveChanges();

                return Results.Ok("Order updated successfully");
            });

            app.MapDelete("/api/deleteOrder/{id}", (HipHopPizzaAndWangsDbContext db, int id) =>
            {
                Order deleteOrder = db.Orders.SingleOrDefault(commentToDelete => commentToDelete.Id == id);
                if (deleteOrder == null)
                {
                    return Results.NotFound();
                }
                db.Orders.Remove(deleteOrder);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapGet("/revenue/total", (HipHopPizzaAndWangsDbContext db) =>
            {
                var totalRevenue = db.Orders.Sum(o => o.Total + o.Tip);

                return Results.Ok(new { Total = totalRevenue });
            });

        }
    }
}