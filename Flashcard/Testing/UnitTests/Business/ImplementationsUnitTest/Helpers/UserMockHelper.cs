// <copyright file="UserMockHelper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Linq;
using DataModel.Models;
using DataModel.Models.DbModels;

namespace ImplementationsUnitTest.Helpers
{
	/// <summary>
	///     UserMockHelper class
	/// </summary>
	public static class UserMockHelper
	{
		/// <summary>
		///     Gets the users.
		/// </summary>
		/// <value>
		///     The users.
		/// </value>
		public static IQueryable<User> Users =>
			new List<User>
			{
				new User
				{
					Id = "1",
					Email = "test1@wp.pl",
					UserName = "test",
					SecurityStamp = "*******",
					PasswordHash = "*******",
					ConcurrencyStamp = "*******"
				},
				new User
				{
					Id = "2",
					Email = "test2@wp.pl",
					UserName = "test2",
					SecurityStamp = "*******",
					PasswordHash = "*******",
					ConcurrencyStamp = "*******"
				},
				new User
				{
					Id = "3",
					Email = "test3@wp.pl",
					UserName = "test3",
					SecurityStamp = "*******",
					PasswordHash = "*******",
					ConcurrencyStamp = "*******"
				}
			}.AsQueryable();
	}
}