/**
 * @author Izabela Maraszkiewicz IT
 */


(function ($) {

	$.extend(
		{
			/**
			 * Simulate sending post
			 * @param {any} location url to redirect
			 * @param {any} args args e.g { 'key': 'value' }
			 */
			redirectPost: function (location, args) {
				var form = '';
				$.each(args, function (key, value) {
					value = value.split('"').join('\"');
					form += '<input type="hidden" name="' + key + '" value="' + value + '">';
				});
				$('<form action="' + location + '" method="POST">' + form + '</form>').appendTo($(document.body)).submit();
			}
		});

}(jQuery));