/**
 * @author Izabela Maraszkiewicz IT
 */

(function ($) {

	/**
	 * {tokenService} class instance
	 */
	$.fn.tokenService = new tokenService();

	/**
	 * On fire token form submit event
	 */
	$.fn.onTokenFormSubmit = function () {

		$form = $(this);
		$button = $form.find('button');

		$button.toggleButtonActivity(false);
		$inputs = $form.find('input[type="text"], input[type="password"]');
		errors = false;

		$inputs.each(function () {

			$input = $(this);

			if (isNullOrEmptyEmpty($(this).val())) {
				$input.focus();
				errors = true;
			} else if ($input.hasClass('input-validation-error')) {
				errors = true;
			}
		});
		
		if (!errors) {
			$form.getToken();
		} else {
			$button.toggleButtonActivity(true);
		}

	};

	/**
	 * Send data from form and get token from web api
	 */
	$.fn.getToken = function () {

		$.fn.tokenService.getToken($(this));
	};

}(jQuery));