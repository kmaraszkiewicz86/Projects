/**
 * @author Izabela Maraszkiewicz IT
 */

/**
 * Token service functionality class.
 * @constructor 
 */
var tokenService = function (  ) {
	baseService.call(this);
	this.url = this.webApiHostUrl + "Token";
};

/**
 * Send data from form and get token from web api
 * @param {jQuery} $form
 */
tokenService.prototype.getToken = function ($form) {
	$.ajax({
		url: this.url,
		data: JSON.stringify({
			username: $form.find("#Username").val(),
			password: $form.find("#Password").val()
		}),
		dataType: 'json',
		contentType: 'application/json',
		method: 'post',
		error: function (jqXHR) {
			
			$("#errorMessage").clearMessages();
			$(".validation-summary-errors").clearMessages();
			$("#errorMessage").appendErrorMessage('Error occours while processing request. ' + jqXHR.responseText);
			$("#errorMessage").showDialog();

			$button.toggleButtonActivity(true);
		},
		success: function (data, textStatus, jqXHR) {
			
			$("#errorMessage").clearMessages();
			$(".validation-summary-errors").clearMessages();
			$("#errorMessage").hideDialog();

			console.log(data.token);

			$button.toggleButtonActivity(true);

			$.redirectPost('/Account/ProcessingToken', { 'Token': data.token });
		}
	});
};