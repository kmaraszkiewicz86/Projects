using DataModel.Models.WebAPI;
using Implementations.Exceptions;

namespace Implementations.Helpers
{
	/// <summary>
	/// Category web api model helper
	/// </summary>
	public static class CategoryModelHelper
	{
		/// <summary>
		/// Throws if empty.
		/// </summary>
		/// <param name="categories">The array of <see cref="CategoryModel"/>.</param>
		/// <exception cref="NotFoundException">You must provide at least one category</exception>
		public static void ThrowIfEmpty(this CategoryModel[] categories)
		{
			if (categories == null || categories?.Length == 0)
				throw new NotFoundException("You must provide at least one category");
		}
	}
}