using HHPW.Models;


namespace HHPW.Data
{
	public class OrderData
	{
		public static List<Order> Orders = new List<Order>
		{
			new Order
			{
				Id = 1,
				Uid = 1,
				CreatedOn = DateTime.Now,
				Name = "Austin",
				Status = true,
				PhoneNum = 9319990000,
				Email = "mangumaustin@gmail.com",
				Type = "Pick up",
				PaymentType = "Debit",
				Total = 20.00,
				Tip = 5.00,
			},
			new Order
			{
				Id = 2,
				Uid = 2,
				CreatedOn = DateTime.Now,
				Name = "Bria",
				Status = false,
				PhoneNum = 9319990000,
				Email = "mangumbria@gmail.com",
				Type = "Delivery",
				PaymentType = "Cash",
				Total = 20.00,
				Tip = 5.00,
			}
		};
	}
}