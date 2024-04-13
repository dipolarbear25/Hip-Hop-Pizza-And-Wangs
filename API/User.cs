using HHPW.Models;
using Microsoft.EntityFrameworkCore;

namespace HHPW.API
{
    public static class UsersAPI
    {
        public static void Map(WebApplication app)
        {

            app.MapGet("/checkuser/{uid}", (HipHopPizzaAndWangsDbContext db, string uid) =>
            {
                var user = db.Users.Where(x => x.Uid == uid).ToList();
                if (uid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(user);
                }
            });

            app.MapPost("/register", (HipHopPizzaAndWangsDbContext db, User newUser) =>
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return Results.Created($"/user/{newUser.Id}", newUser);
            });
        }
    }
}