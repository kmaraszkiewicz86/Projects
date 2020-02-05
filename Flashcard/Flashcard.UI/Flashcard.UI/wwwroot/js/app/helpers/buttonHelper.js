/**
 * @author Izabela Maraszkiewicz IT
 */


(function($) {

	/**
	 * Toggles button activity
	 * @param {jQuery} $button
	 * @param {boolean} state
	 */
	$.fn.toggleButtonActivity = function (state) {

		$button = $(this);

		if (state) {
			$button.removeClass('disabled')
				.removeAttr('disabled');
		} else {
			$button.addClass('disabled')
				.attr('disabled', 'disabled');
		}
	};

}(jQuery));