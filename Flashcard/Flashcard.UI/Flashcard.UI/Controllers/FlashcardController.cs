// <copyright file="AccountController.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel.Properties;

namespace Flashcard.UI.Controllers
{
	/// <summary>
	/// FlashcardController controller.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class FlashcardController : Controller
    {
		/// <summary>
		/// Indexes this instance.
		/// </summary>
		/// <returns><see cref="IActionResult"/></returns>
		public IActionResult Index()
        {
	        ViewBag.Token = HttpContext.Session.GetString(BaseKeys.Token);

            return View();
        }
    }
}