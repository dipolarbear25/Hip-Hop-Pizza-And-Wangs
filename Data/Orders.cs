using HHPW.Models;


namespace HHPW.Data
{
	public class UserData
	{
		public static List<User> Users = new List<User>
		{
			new User 
			{
				Id = 1,
				Name = "Jake",
				Uid = 1
			},
			new User 
			{ 
				Id = 2,
				Name = "Jasmine",
				Uid = 2
			}
		}
	}
}