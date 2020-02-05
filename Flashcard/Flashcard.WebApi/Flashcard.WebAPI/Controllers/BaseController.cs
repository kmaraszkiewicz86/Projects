// <copyright file="BaseController.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Threading.Tasks;
using Implementations.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.WebAPI.Controllers
{
	/// <summary>
	///     Base controller.
	/// </summary>
	/// <seealso cref="Controller" />
	[Produces("application/json")]
	[Route("api/Base")]
	public abstract class BaseController : Controller
	{
		/// <summary>
		///     Called after action work.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns>
		///     <see cref="IActionResult" />
		/// </returns>
		protected async Task<IActionResult> OnActionWorkAsync(Func<Task<IActionResult>> action)
		{
			if (ModelState.IsValid)
			{
				try
				{
					return await action();
				}
				catch (NotFoundException notFoundException)
				{
					return NotFound(notFoundException.Message);
				}
				catch (BadRequestException badRequestException)
				{
					return BadRequest(badRequestException.Message);
				}
				catch (IdentityResultException identityResultException)
				{
					AddModelError(identityResultException.IdentityResult);
				}
				catch (ModelStateException modelStateException)
				{
					ModelState.AddModelError("",
						modelStateException.Message);
				}
				catch (UnauthorizedException)
				{
					return Unauthorized();
				}
				catch (Exception err)
				{
					ModelState.AddModelError($"Unexpected error ({err.GetType().FullName})", err.ToString());
				}
			}

			return BadRequest(ModelState);
		}

		/// <summary>
		///     Called after action work.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns>
		///     <see cref="IActionResult" />
		/// </returns>
		protected IActionResult OnActionWork(Func<IActionResult> action)
		{
			if (ModelState.IsValid)
			{
				try
				{
					return action();
				}
				catch (NotFoundException notFoundException)
				{
					return NotFound(notFoundException.Message);
				}
				catch (BadRequestException badRequestException)
				{
					return BadRequest(badRequestException.Message);
				}
				catch (IdentityResultException identityResultException)
				{
					AddModelError(identityResultException.IdentityResult);
				}
			}

			return BadRequest(ModelState);
		}

		/// <summary>
		///     Adds the model error.
		/// </summary>
		/// <param name="identityResult">The identity result.</param>
		protected void AddModelError(IdentityResult identityResult)
		{
			foreach (var identityResultError in identityResult.Errors)
			{
				ModelState.AddModelError("", identityResultError.Description);
			}
		}
	}
}