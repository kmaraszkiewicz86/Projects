/**
 * @author Izabela Maraszkiewicz IT
 */

(function ($) {

	/**
	 * Append message to errorMessage alert dialog
	 * @param {string} message error message
	 */
	$.fn.appendErrorMessage = function (message) {
		$(this).find("ul").append("<li>" + message + "</li>");
	};

	/**
	 * Hide alert dialog event
	 */
	$.fn.hideAlertDialogEvent = function () {
		$(this).click(function () {
			$(this).parent().hideDialog();
		});
	};

	/**
	 * Set visibility to element
	 */
	$.fn.showDialog = function () {
		$(this).removeClass("hidden");
	};

	/**
	 * Hide element
	 */
	$.fn.hideDialog = function () {
		$(this).clearMessages();
		$(this).addClass("hidden");
	};

	/**
	 * Clear error messages
	 */
	$.fn.clearMessages = function () {
		$(this).find("ul li").remove();
	};

	/**
	 * Clear all previous errror and add new one
	 * @param {string} message the error message
	 */
	$.fn.addErrorMessage = function(message) {
		$(this).clearMessages();
		$(this).appendErrorMessage(message);
		$(this).showDialog();
	};

	/**
	 * Clear all message assosiated to error dialog and hide dialog window
	 */
	$.fn.removeErrorMessageDialog = function() {
		$(this).clearMessages();
		$(this).hideDialog();
	};

}(jQuery));