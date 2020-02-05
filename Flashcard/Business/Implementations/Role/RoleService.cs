// <copyright file="RoleService.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models.WebAPI;
using Implementations.Exceptions;
using Interfaces.Role;
using Microsoft.AspNetCore.Identity;

namespace Implementations.Role
{
	public class RoleService : IRoleService
	{
		/// <summary>
		///     The role manager
		/// </summary>
		private readonly RoleManager<IdentityRole> _roleManager;

		/// <summary>
		///     Initializes a new instance of the <see cref="RoleService" /> class.
		/// </summary>
		/// <param name="roleManager">The role manager.</param>
		public RoleService(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}

		/// <summary>
		///     Gets all.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IdentityRole> GetAll()
		{
			return _roleManager.Roles;
		}

		/// <summary>
		///     Creates the role.
		/// </summary>
		/// <param name="roleModel"><see cref="RoleModel" />.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		public async Task Create(RoleModel roleModel)
		{
			var identityResult = await _roleManager.CreateAsync(new IdentityRole
			{
				Name = roleModel.Name
			});

			if (!identityResult.Succeeded)
			{
				throw new IdentityResultException(identityResult);
			}
		}

		/// <summary>
		///     Removes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		public async Task Remove(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);

			if (role == null)
			{
				throw new NotFoundException();
			}

			var result = await _roleManager.DeleteAsync(role);

			if (result.Succeeded)
			{
				throw new IdentityResultException(result);
			}
		}
	}
}