/**
 * @author Izabela Maraszkiewicz IT
 */

/**
 * Base service class.
 */
var baseService = function () {
	this.webApiHostUrl = "http://localhost:52408/api/";
};

/**
 * Get required header for web api requests
 *
 * @returns Header data
 */
baseService.prototype.getHeadersWithToken = function() {
	return {
		"Content-Type": "application/json"
	};
};