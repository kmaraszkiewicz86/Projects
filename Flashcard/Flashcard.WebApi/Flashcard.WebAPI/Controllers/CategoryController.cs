// <copyright file="CategoryController.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using DataModel.Models.DbModels;
using Interfaces.CategoryMgt;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.WebAPI.Controllers
{
	/// <summary>
	///     Category controller
	/// </summary>
	/// <seealso cref="Flashcard.WebAPI.Controllers.BaseController" />
	[Produces("application/json")]
	[Route("api/Category")]
	public class CategoryController : BaseController
	{
		/// <summary>
		/// The category service
		/// </summary>
		private ICategoryService _categoryService;

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryController"/> class.
		/// </summary>
		/// <param name="categoryService">The category service.</param>
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns></returns>
		public IActionResult GetAll()
		{
			return OnActionWork(() =>
				new ObjectResult(_categoryService.GetAll()));
		}

		/// <summary>
		/// Adds the specified category model.
		/// </summary>
		/// <param name="categoryModel">The category model.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] Category categoryModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _categoryService.AddAsync(categoryModel);
				return Ok("ok");
			});
		}

		/// <summary>
		/// Updates the specified category.
		/// </summary>
		/// <param name="id">The category identifier.</param>
		/// <param name="categoryModel">The category model.</param>
		/// <returns></returns>
		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update(int id, [FromBody] Category categoryModel)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _categoryService.UpdateAsync(id, categoryModel);

				return Ok();
			});
		}

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			return await OnActionWorkAsync(async () =>
			{
				await _categoryService.DeleteAsync(id);

				return Ok("ok");
			});
		}
	}
}