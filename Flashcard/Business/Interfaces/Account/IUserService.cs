// <copyright file="IUserService.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;

namespace Interfaces.Account
{
	/// <summary>
	///     User manager service
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		///     Gets all users.
		/// </summary>
		/// <returns>
		///     <see cref="IEnumerable{User}" />
		/// </returns>
		IEnumerable<User> GetAll();

		/// <summary>
		///     Creates user.
		/// </summary>
		/// <param name="createUserModel">
		///     <see cref="ChangeUserPasswordModel" />
		/// </param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task<string> Create(CreateUserModel createUserModel);

		/// <summary>
		///     Changes the user password.
		/// </summary>
		/// <param name="changeUserPasswordModel">The change user password model.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task ChangeUserPassword(ChangeUserPasswordModel changeUserPasswordModel);

		/// <summary>
		///     Changes the password.
		/// </summary>
		/// <param name="changePasswordModel">The change password model.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task ChangePassword(ChangePasswordModel changePasswordModel);

		/// <summary>
		///     Changes the password after reset.
		/// </summary>
		/// <param name="changePasswordAfterResetModel"><see cref="ChangePasswordAfterResetModel" />.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task ChangePasswordAfterReset(ChangePasswordAfterResetModel changePasswordAfterResetModel);

		/// <summary>
		///     Resets the password.
		/// </summary>
		/// <param name="resetPasswordModel">
		///     <see cref="ResetPasswordModel" />
		/// </param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task ResetPassword(ResetPasswordModel resetPasswordModel);

		/// <summary>
		///     Adds the user to role.
		/// </summary>
		/// <param name="addUserToRoleModel">
		///     <see cref="AddUserToRoleModel" />
		/// </param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task AddUserToRole(AddUserToRoleModel addUserToRoleModel);

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