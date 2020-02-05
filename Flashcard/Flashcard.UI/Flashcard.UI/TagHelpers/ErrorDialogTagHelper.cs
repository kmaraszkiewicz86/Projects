// <copyright file="ErrorDialogTagHelper.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Flashcard.UI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Flashcard.UI.TagHelpers
{
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
	[HtmlTargetElement("error-dialog")]
	public class ErrorDialogTagHelper : TagHelper
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public string Id { get; set; }

		private IHtmlHelper _htmlHelper;

		private HtmlEncoder _htmlEncoder;

		/// <summary>
		/// Gets or sets the view context.
		/// </summary>
		/// <value>
		/// The view context.
		/// </value>
		[HtmlAttributeNotBound]
		[ViewContext]
		public ViewContext ViewContext { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorDialogTagHelper"/> class.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <param name="htmlEncoder">The HTML encoder.</param>
		public ErrorDialogTagHelper(IHtmlHelper htmlHelper, HtmlEncoder htmlEncoder)
		{
			_htmlHelper = htmlHelper;
			_htmlEncoder = htmlEncoder;
		}

		/// <summary>
		/// Asynchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
		/// <paramref name="output" />.
		/// </summary>
		/// <param name="context">Contains information associated with the current HTML tag.</param>
		/// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
		/// <returns>
		/// A <see cref="T:System.Threading.Tasks.Task" /> that on completion updates the <paramref name="output" />.
		/// </returns>
		/// <remarks>
		/// By default this calls into <see cref="M:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext,Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)" />.
		/// </remarks>
		/// .
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			(_htmlHelper as IViewContextAware).Contextualize(ViewContext);

			output.TagName = "ErrorDialog";
			output.TagMode = TagMode.StartTagAndEndTag;

			var model = new ErrorDialogModel(Id);

			var partial = await _htmlHelper.PartialAsync("_ErrorDialog", model);

			var writer = new StringWriter();

			partial.WriteTo(writer, _htmlEncoder);

			output.PreContent.SetHtmlContent(writer.ToString());
		}
	}
}