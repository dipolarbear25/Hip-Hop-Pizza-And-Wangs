using HHPW.Models;
using Microsoft.EntityFrameworkCore;

namespace HHPW.API
{
    public static class UsersAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/user/{uid}", (HipHopPizzaAndWangsDbContext db, int uid) =>
            {
                var user = db.Users.Where(user => user.Uid == uid).ToList();

                if (uid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(user);
                }
            });

            app.MapPost("/user", (HipHopPizzaAndWangsDbContext db, User newUser) =>
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return Results.Created($"/user/{newUser.Id}", newUser);
            });
        }
    }
}