// <copyright file="TokenService.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.Config;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;
using Implementations.Exceptions;
using Interfaces.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Implementations.Authorization
{
	/// <summary>
	///     Manages token functionality
	/// </summary>
	/// <seealso cref="ITokenService" />
	public class TokenService : ITokenService, IDisposable
	{
		/// <summary>
		///     The options
		/// </summary>
		private readonly IOptionsSnapshot<AppSettingsModel> _options;

		/// <summary>
		///     The role manager
		/// </summary>
		private readonly RoleManager<IdentityRole> _roleManager;

		private readonly IServiceScope _scope;

		/// <summary>
		///     The sign in manager
		/// </summary>
		private readonly SignInManager<User> _signInManager;

		/// <summary>
		///     The user manager
		/// </summary>
		private readonly UserManager<User> _userManager;

		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public TokenService(UserManager<User> userManager, SignInManager<User> signInManager,
			RoleManager<IdentityRole> roleManager, IOptionsSnapshot<AppSettingsModel> options)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_options = options;
		}

		/// <summary>
		///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			_scope?.Dispose();
		}

		/// <summary>
		///     Builds the token.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Token string.</returns>
		public async Task<string> BuildTokenAsync(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id)
			};

			var userRoles = await _userManager.GetRolesAsync(user);
			var userClaims = await _userManager.GetClaimsAsync(user);
			claims.AddRange(userClaims);

			foreach (var userRole in userRoles)
			{
				claims.Add(new Claim(ClaimTypes.Role, userRole));
				var role = await _roleManager.FindByNameAsync(userRole);
				if (role != null)
				{
					var roleClaims = await _roleManager.GetClaimsAsync(role);
					foreach (var roleClaim in roleClaims)
					{
						claims.Add(roleClaim);
					}
				}
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Jwt.Key));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_options.Value.Jwt.Issuer,
				_options.Value.Jwt.Issuer,
				claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		/// <summary>
		///     Authenticates user asynchronous.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>
		///     <see cref="User" />
		/// </returns>
		public async Task<User> AuthenticateAsync(LoginModel model)
		{
			User user = await _userManager.FindByNameAsync(model.Username) 
			            ?? await _userManager.FindByEmailAsync(model.Username);

			if (user != null)
			{
				await _signInManager.SignOutAsync();
				SignInResult result =
					await _signInManager.PasswordSignInAsync(
						user, model.Password, false, false);

				if (!result.Succeeded)
				{
					return null;
				}
			}
			else
			{
				throw new ModelStateException("Invalid user or password");
			}

			return user;
		}
	}
}