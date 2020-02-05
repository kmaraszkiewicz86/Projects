// <copyright file="AccountController.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DataModel.Models.WebAPI;
using Interfaces.Account;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.WebAPI.Controllers
{
	/// <summary>
	///     Account controller
	/// </summary>
	/// <seealso cref="Flashcard.WebAPI.Controllers.BaseController" />
	[Produces("application/json")]
	[Route("api/Account")]
	public class AccountController : BaseController
	{
		/// <summary>
		///     The user service
		/// </summary>
		private readonly IUserService _userService;

		/// <summary>
		///     Initializes a new instance of the <see cref="AccountController" /> class.
		/// </summary>
		/// <param name="userService">The user service.</param>
		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		/// <summary>
		///     Gets this instance.
		/// </summary>
		/// <returns></returns>
		public IActionResult Get()
		{
			return OnActionWork(() => 
				new ObjectResult(_userService.GetAll()));
		}

		/// <summary>
		///     Creates the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUserModel model)
		{
			return await OnActionWorkAsync(async () =>
			{
				var userId = await _userService.Create(model);

				return Ok(new {Id = userId});
			});
		}

		/// <summary>
		///     Adds the user to role.
		/// </summary>
		/// <param name="addUserToRoleModel">The add user to role model.</param>
		/// <returns></returns>
		[HttpPost("AddUserToRole")]
		public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleModel addUserToRoleModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _userService.AddUserToRole(addUserToRoleModel);

				return Ok();
			});
		}

		/// <summary>
		///     Changes the user password.
		/// </summary>
		/// <param name="changeUserPasswordModel">The change user password model.</param>
		/// <returns></returns>
		[HttpPost("ChangeUserPassword")]
		public async Task<IActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordModel changeUserPasswordModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _userService.ChangeUserPassword(changeUserPasswordModel);

				return Ok();
			});
		}

		/// <summary>
		///     Resets the password.
		/// </summary>
		/// <param name="resetPasswordModel">The reset password model.</param>
		/// <returns></returns>
		[HttpPost("ResetPassword")]
		public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _userService.ResetPassword(resetPasswordModel);

				return Ok();
			});
		}

		/// <summary>
		///     Changes the password after reset.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		[HttpPost("ChangePasswordAfterReset")]
		public async Task<IActionResult> ChangePasswordAfterReset([FromBody] ChangePasswordAfterResetModel model)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _userService.ChangePasswordAfterReset(model);

				return Ok();
			});
		}

		/// <summary>
		///     Changes the password.
		/// </summary>
		/// <param name="changePasswordModel">The change password model.</param>
		/// <returns></returns>
		[HttpPost("ChangePassword")]
		public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _userService.ChangePassword(changePasswordModel);

				return Ok();
			});
		}

		/// <summary>
		///     Removes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove([Required] string id)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _userService.Remove(id);

				return Ok();
			});
		}
	}
}