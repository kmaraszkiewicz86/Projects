// <copyright file="UserService.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Enums;
using DataModel.Models.Config;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;
using Implementations.Exceptions;
using Implementations.Helpers;
using Interfaces.Account;
using Interfaces.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;

namespace Implementations.Account
{
	/// <summary>
	///     User manager service
	/// </summary>
	/// <seealso cref="IUserService" />
	public class UserService : IUserService
	{
		/// <summary>
		///     The user manager
		/// </summary>
		private readonly UserManager<User> _userManager;

		/// <summary>
		///     The password validator
		/// </summary>
		private readonly IPasswordValidator<User> _passwordValidator;

		/// <summary>
		///     The password hasher
		/// </summary>
		private readonly IPasswordHasher<User> _passwordHasher;

		/// <summary>
		///     The email service
		/// </summary>
		private readonly IEmailService _emailService;

		/// <summary>
		///     The settings model
		/// </summary>
		private readonly SettingsModel _settingsModel;

		/// <summary>
		///     Logger object
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		///     Initializes a new instance of the <see cref="UserService" /> class.
		/// </summary>
		/// <param name="userManager">The user manager.</param>
		/// <param name="passwordValidator">The password validator.</param>
		/// <param name="passwordHasher">The password hasher.</param>
		/// <param name="emailService">The email service.</param>
		/// <param name="optionsSnapshot">The options snapshot.</param>
		/// <param name="loggerFactory">The logger factory.</param>
		public UserService(UserManager<User> userManager, 
			IPasswordValidator<User> passwordValidator,
			IPasswordHasher<User> passwordHasher,
			IEmailService emailService, 
			IOptionsSnapshot<SettingsModel> optionsSnapshot, 
			ILoggerFactory loggerFactory)
		{
			_userManager = userManager;
			_passwordValidator = passwordValidator;
			_passwordHasher = passwordHasher;
			_emailService = emailService;
			_settingsModel = optionsSnapshot.Value;
			_logger = loggerFactory.CreateLogger(nameof(UserService));
		}

		/// <summary>
		///     Gets all users.
		/// </summary>
		/// <returns>
		///     <see cref="IEnumerable{User}" />
		/// </returns>
		public IEnumerable<User> GetAll()
		{
			_logger?.LogInformation("Getting user list");

			return _userManager.Users.ToList().Select(delegate(User u)
			{
				u.PasswordHash = "*******";
				u.SecurityStamp = "*******";
				u.ConcurrencyStamp = "*******";
				return u;
			});
		}

		/// <summary>
		///     Creates user.
		/// </summary>
		/// <param name="createUserModel">The create user model.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		public async Task<string> Create(CreateUserModel createUserModel)
		{
			var user = new User
			{
				Email = createUserModel.Email,
				UserName = createUserModel.Name
			};

			var identityResult = await _userManager.CreateAsync(user, createUserModel.Password);

			identityResult.Verify();

			return user.Id;
		}

		/// <summary>
		///     Changes the password.
		/// </summary>
		/// <param name="changeUserPasswordModel">The change password model.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		public async Task ChangeUserPassword(ChangeUserPasswordModel changeUserPasswordModel)
		{
			var user = await _userManager.FindByIdAsync(changeUserPasswordModel.Id);

			if (user == null)
			{
				throw new NotFoundException();
			}

			var result =
				await _passwordValidator.ValidateAsync(_userManager, user, changeUserPasswordModel.NewPassword);

			result.Verify();

			result = await _userManager.ChangePasswordAsync(user, changeUserPasswordModel.CurrentPassword,
				changeUserPasswordModel.NewPassword);

			result.Verify();
		}

		/// <summary>
		///     Changes the password.
		/// </summary>
		/// <param name="changePasswordModel">The change password model.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		/// <exception cref="NotFoundException"></exception>
		public async Task ChangePassword(ChangePasswordModel changePasswordModel)
		{
			var user = await _userManager.FindByIdAsync(changePasswordModel.Id);

			if (user == null)
			{
				throw new NotFoundException();
			}

			user.PasswordHash = _passwordHasher.HashPassword(user, changePasswordModel.NewPassword);
			var result = await _userManager.UpdateAsync(user);

			result.Verify();
		}

		/// <summary>
		///     Changes the password after reset.
		/// </summary>
		/// <param name="changePasswordAfterResetModel"><see cref="T:DataModel.Models.ChangePasswordAfterResetModel" />.</param>
		/// <returns>
		///     <see cref="T:System.Threading.Tasks.Task" />
		/// </returns>
		public async Task ChangePasswordAfterReset(ChangePasswordAfterResetModel changePasswordAfterResetModel)
		{
			var user = await _userManager.FindByIdAsync(changePasswordAfterResetModel.UserId);

			if (user == null)
			{
				throw new NotFoundException();
			}

			var result = await _userManager.ResetPasswordAsync(user, changePasswordAfterResetModel.Token,
				changePasswordAfterResetModel.NewPassword);

			result.Verify();
		}

		/// <summary>
		///     Resets the password.
		/// </summary>
		/// <param name="resetPasswordModel">The reset password model.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		public async Task ResetPassword(ResetPasswordModel resetPasswordModel)
		{
			var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);

			if (user == null)
			{
				_logger.LogError($"User not found for user in reset password action");
				throw new NotFoundException();
			}

			var token = await _userManager.GeneratePasswordResetTokenAsync(user);

			var callbackUrl =
				$"{_settingsModel.Hostname}/Account/ChangePasswordAfterReset/Token={token}.{user.Id}";

			var sendGridMessage = new SendGridMessage
			{
				Subject = "Reset Password",
				PlainTextContent = $"To reset password follow the link => {callbackUrl}"
			};

			sendGridMessage.AddTo(new EmailAddress(resetPasswordModel.Email));

			var statusCode = await _emailService.SendAsync(sendGridMessage);

			if (Enum.TryParse<EmailStatusCode>(statusCode, true, out var emailStatusCode))
			{
				if (emailStatusCode != EmailStatusCode.Ok && emailStatusCode != EmailStatusCode.Accepted)
				{
					_logger.LogError($"Sent message done with errors. Return status code {statusCode}");
				}

				_logger.LogInformation($"Send user password for user id {user.Id} and token {token}");
			}
			else
			{
				_logger.LogError($"Sent message done with unsupported {statusCode} status code");
			}
		}

		/// <summary>
		/// </summary>
		/// Adds the user to role.
		/// <param name="addUserToRoleModel">The add user to role model.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		/// <exception cref="NotFoundException"></exception>
		/// <exception cref="IdentityResultException"></exception>
		public async Task AddUserToRole(AddUserToRoleModel addUserToRoleModel)
		{
			var user = await _userManager.FindByNameAsync(addUserToRoleModel.Username);

			if (user == null)
			{
				throw new NotFoundException($"User {addUserToRoleModel.Username} not found");
			}

			var result = await _userManager.AddToRoleAsync(user, addUserToRoleModel.RoleName);

			if (!result.Succeeded)
			{
				throw new IdentityResultException(result);
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
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				throw new NotFoundException("User not found");
			}

			var identityResult = await _userManager.DeleteAsync(user);

			if (!identityResult.Succeeded)
			{
				throw new IdentityResultException(identityResult);
			}
		}
	}
}