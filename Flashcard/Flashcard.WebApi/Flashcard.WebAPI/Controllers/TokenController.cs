// <copyright file="TokenController.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;
using Implementations.Exceptions;
using Interfaces.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.WebAPI.Controllers
{
	/// <summary>
	///     Token action controller
	/// </summary>
	/// <seealso cref="BaseController" />
	[Route("api/[controller]")]
	public class TokenController : BaseController
	{
		/// <summary>
		///     The token model
		/// </summary>
		private readonly ITokenService _tokenService;

		public TokenController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

		/// <summary>
		///     Creates the token.
		/// </summary>
		/// <param name="model"><see cref="LoginModel" />.</param>
		/// <returns>
		///     <see cref="Task{IActionResult}" />
		/// </returns>
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> CreateToken([FromBody] LoginModel model)
		{
			return await OnActionWorkAsync(async () =>
			{
				User user = await _tokenService.AuthenticateAsync(model);

				if (user == null)
				{
					throw new UnauthorizedException();
				}

				var tokenString = await _tokenService.BuildTokenAsync(user);
				return Ok(new {token = tokenString});
			});
		}
	}
}