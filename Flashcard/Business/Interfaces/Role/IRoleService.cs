// <copyright file="IRoleService.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models.WebAPI;
using Microsoft.AspNetCore.Identity;

namespace Interfaces.Role
{
	/// <summary>
	///     Role service
	/// </summary>
	public interface IRoleService
	{
		/// <summary>
		///     Gets all.
		/// </summary>
		/// <returns></returns>
		IEnumerable<IdentityRole> GetAll();

		/// <summary>
		///     Creates the role.
		/// </summary>
		/// <param name="roleModel"><see cref="RoleModel" />..</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task Create(RoleModel roleModel);

		/// <summary>
		///     Removes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task Remove(string id);
	}
}