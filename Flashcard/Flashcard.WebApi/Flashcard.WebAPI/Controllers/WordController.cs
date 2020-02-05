// <copyright file="WordController.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using DataModel.Enums;
using DataModel.Models.WebAPI;
using Interfaces.WordMgt;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.WebAPI.Controllers
{
	/// <summary>
	///     Word controller
	/// </summary>
	/// <seealso cref="BaseController" />
	[Produces("application/json")]
	[Route("api/Word")]
	public class WordController : BaseController
	{
		/// <summary>
		/// The word service
		/// </summary>
		private IWordService _wordService;

		/// <summary>
		/// Initializes a new instance of the <see cref="WordController"/> class.
		/// </summary>
		/// <param name="wordService">The word service.</param>
		public WordController(IWordService wordService)
		{
			_wordService = wordService;
		}

		/// <summary>
		/// Gets all words.
		/// </summary>
		/// <returns></returns>
		[HttpGet("{type}")]
		public IActionResult GetAll(WordItemsType type)
		{
			return OnActionWork(() => 
				new ObjectResult(_wordService.GetAll(type)));
		}

		/// <summary>
		/// Adds the specified word model.
		/// </summary>
		/// <param name="wordModel">The word model.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] WordModel wordModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _wordService.AddAsync(wordModel);
				return Ok();
			});
		}

		/// <summary>
		/// Updates the specified word model.
		/// </summary>
		/// <param name="wordModel">The word model.</param>
		/// <returns></returns>
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] WordModel wordModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _wordService.UpdateAsync(wordModel);

				return Ok();
			});
		}

		/// <summary>
		/// Deletes the specified word.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _wordService.DeleteAsync(id);

				return Ok();
			});
		}
	}
}