using System;

namespace FlashcardUIAutomatedTests.Attributes
{
	/// <summary>
	/// PageName attribute
	/// </summary>
	/// <seealso cref="System.Attribute" />
	[AttributeUsage(AttributeTargets.Class)]
	internal class PageNameAttribute : Attribute
	{
		/// <summary>
		/// Gets the name of the page.
		/// </summary>
		/// <value>
		/// The name of the page.
		/// </value>
		public string PageName { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PageNameAttribute"/> class.
		/// </summary>
		/// <param name="pageName">Name of the page.</param>
		public PageNameAttribute(string pageName)
		{
			PageName = pageName;
		}
	}
}