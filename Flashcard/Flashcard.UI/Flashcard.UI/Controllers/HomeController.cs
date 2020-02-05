// <copyright file="HomeController.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace Flashcard.UI.Controllers
{
	/// <summary>
	/// HomeController class.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class HomeController : Controller
	{
		/// <summary>
		/// Index action.
		/// </summary>
		/// <returns><see cref="IActionResult"/></returns>
		public IActionResult Index()
		{
			return View();
		}
	}
}