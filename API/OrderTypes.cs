using HHPW.Models;
using Microsoft.EntityFrameworkCore;
namespace HHPW.API
{
    public class OrderTypeAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/ordertypes", (HipHopPizzaAndWangsDbContext db) =>
            {
                return db.OrderTypes;
            });

            //get single order type
            app.MapGet("/api/ordertypes/{Id}", (HipHopPizzaAndWangsDbContext db, int Id) =>
            {
                OrderType orderType = db.OrderTypes.SingleOrDefault(o => o.Id == Id);
                if (orderType == null)
                {
                    return null;
                }
                return orderType;
            });

        }
    }
}