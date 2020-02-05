// <copyright file="TokenModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;

namespace Interfaces.Authorization
{
	/// <summary>
	///     Manages token functionality
	/// </summary>
	public interface ITokenService
	{
		/// <summary>
		///     Builds the token asynchronous.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Token string.</returns>
		Task<string> BuildTokenAsync(User user);

		/// <summary>
		///     Authenticates user asynchronous.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>
		///     <see cref="User" />
		/// </returns>
		Task<User> AuthenticateAsync(LoginModel model);
	}
}