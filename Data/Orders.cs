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
				Uid = "zN5lhMboI3Sv4UwtErkrlHlvPfn2",
				CreatedOn = DateTime.Now,
				Name = "Austin",
				Status = true,
				PhoneNum = "931-999-0000",
				Email = "mangumaustin@gmail.com",
				PaymentType = "Debit",
				Total = 20,
				Tip = 5,
			},
			new Order
			{
				Id = 2,
				Uid = "2",
				CreatedOn = DateTime.Now,
				Name = "Bria",
				Status = false,
				PhoneNum = "931-999-0000",
				Email = "mangumbria@gmail.com",
				PaymentType = "Cash",
				Total = 20,
				Tip = 5,
			}
		};
	}
}