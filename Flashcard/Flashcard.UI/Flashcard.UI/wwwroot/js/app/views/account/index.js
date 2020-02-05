(function ($) {

	var $form = $("form");
	$form.submit(function () {

		$(this).onTokenFormSubmit();

		return false;
	});

})(jQuery);