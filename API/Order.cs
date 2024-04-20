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

            app.MapGet("/api/userorders/{uid}", (HipHopPizzaAndWangsDbContext db, string uid) =>
            {
                var orderDetails = db.Orders
                .FirstOrDefault(orders => orders.Uid == uid);

                if (orderDetails == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(orderDetails);
            });

            app.MapGet("/api/orders/{id}", (HipHopPizzaAndWangsDbContext db, int id) =>
            {
                var order = db.Orders
                              .Include(o => o.OrItemsConnection) 
                              .FirstOrDefault(o => o.Id == id);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                return Results.Ok(order);
            });


            app.MapPost("/api/orders", (HipHopPizzaAndWangsDbContext db, Order newOrder) =>
            {
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return Results.Created($"/orders/{newOrder.Id}", newOrder);
            });

            app.MapPut("/api/updateOrder/{orderId}", (HipHopPizzaAndWangsDbContext db, int orderId, Order updatedOrder) =>
            {
                var orderToUpdate = db.Orders.Single(o => o.Id == orderId);
                orderToUpdate.Name = updatedOrder.Name;
                orderToUpdate.Status = updatedOrder.Status;
                orderToUpdate.PhoneNum = updatedOrder.PhoneNum;
                orderToUpdate.Email = updatedOrder.Email;
                orderToUpdate.CreatedOn = updatedOrder.CreatedOn;
                orderToUpdate.PaymentType = updatedOrder.PaymentType;
                orderToUpdate.Total = updatedOrder.Total;
                orderToUpdate.Tip = updatedOrder.Tip;

                db.SaveChanges();
                return Results.Created($"/orders/{orderToUpdate.Id}", updatedOrder);
            });

            app.MapDelete("/api/deleteOrder/{id}", (HipHopPizzaAndWangsDbContext db, int id) =>
            {
                Order deleteOrder = db.Orders.SingleOrDefault(orderToDelete => orderToDelete.Id == id);
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