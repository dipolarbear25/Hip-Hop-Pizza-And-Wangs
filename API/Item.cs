using HHPW.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HHPW.API
{
    public static class ItemsAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/readItems", (HipHopPizzaAndWangsDbContext db) =>
            {
                return db.Items.ToList();
            });

            app.MapGet("/api/readItemsById/{id}", (HipHopPizzaAndWangsDbContext db, int id) =>
            {
                var iID = db.Items.FirstOrDefault(r => r.Id == id);

                if (iID == null)
                {
                    return Results.NotFound("Item not found.");
                }

                return Results.Ok(iID);
            });

            app.MapGet("/api/readItemsByOrderId/{orderId}", (HipHopPizzaAndWangsDbContext db, int orderId) =>
            {
                Order order = db.Orders.Include(o => o.OrItemsConnection).SingleOrDefault(o => o.Id == orderId);
                if (order == null)
                {
                    return Results.NotFound("Order not found");
                }

                List<Item> items = order.OrItemsConnection.Select(oi => oi.Item).ToList();

                if (items.Count == 0)
                {
                    return Results.NotFound("No items found for the order");
                }

                return Results.Ok(items);
            });


            app.MapPost("/api/createItem", (HipHopPizzaAndWangsDbContext db, Item item) =>
            {
                db.Items.Add(item);
                db.SaveChanges();
                return Results.Created($"/api/users/{item.Id}", item);
            });

            app.MapPut("/api/updateItems/{id}", (HipHopPizzaAndWangsDbContext db, int id, Item post) =>
            {
                Item itemToUpdate = db.Items.SingleOrDefault(post => post.Id == id);

                if (itemToUpdate == null)
                {
                    return Results.NotFound();
                }

                itemToUpdate.Name = post.Name;
                itemToUpdate.Price = post.Price;

                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapDelete("/api/deleteItem/{id}", (HipHopPizzaAndWangsDbContext db, int id) =>
            {
                Item deleteItem = db.Items.SingleOrDefault(itemToDelete => itemToDelete.Id == id);
                if (deleteItem == null)
                {
                    return Results.NotFound();
                }
                db.Items.Remove(deleteItem);
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
