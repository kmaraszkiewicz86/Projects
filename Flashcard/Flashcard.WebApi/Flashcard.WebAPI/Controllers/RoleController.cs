// <copyright file="RoleController.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DataModel.Models.WebAPI;
using Interfaces.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Flashcard.WebAPI.Controllers
{
	/// <summary>
	///     Role controller
	/// </summary>
	/// <seealso cref="BaseController" />
	[Produces("application/json")]
	[Route("api/Role")]
	public class RoleController : BaseController
	{
		/// <summary>
		///     The role service
		/// </summary>
		private readonly IRoleService _roleService;


		private readonly IStringLocalizer<RoleController> _localizer;

		/// <summary>
		///     Initializes a new instance of the <see cref="RoleController" /> class.
		/// </summary>
		/// <param name="roleService">The role service.</param>
		public RoleController(IRoleService roleService, IStringLocalizer<RoleController> localizer)
		{
			_roleService = roleService;
			_localizer = localizer;
		}

		/// <summary>
		///     Gets this instance.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_roleService.GetAll());
		}

		/// <summary>
		///     Creates the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] RoleModel model)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _roleService.Create(model);

				return Ok(_localizer["test"]);
			});

			//return Ok(_localizer["test"]);
		}

		/// <summary>
		///     Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([Required] string id)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _roleService.Remove(id);

				return Ok();
			});
		}
	}
}