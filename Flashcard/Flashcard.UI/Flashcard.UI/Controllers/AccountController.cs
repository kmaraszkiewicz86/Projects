// <copyright file="AccountController.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Linq;
using DataModel.Models.UI;
using DataModel.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.UI.Controllers
{
	/// <summary>
	/// Account controller class
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class AccountController : Controller
	{
		/// <summary>
		/// Index action.
		/// </summary>`
		/// <returns><see cref="IActionResult"/></returns>
		public IActionResult Index()
		{
			if (HttpContext.Session.Keys.Any(key => key == BaseKeys.Token))
				return RedirectToAction("Index", "Flashcard");

			return View();
		}

		/// <summary>
		/// Processings the token.
		/// </summary>
		/// <param name="processingToken">The processing token.</param>
		/// <returns></returns>
		public IActionResult ProcessingToken(ProcessingToken processingToken)
		{
			if (string.IsNullOrEmpty(processingToken.Token))
				throw new Exception("Invalid token");

			HttpContext.Session.SetString(BaseKeys.Token, processingToken.Token);

			return RedirectToAction("Index", "Flashcard");
		}
	}
}