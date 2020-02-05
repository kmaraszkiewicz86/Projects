// <copyright file="EmailStatusCode.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace DataModel.Enums
{
	/// <summary>
	///     EmailStatusCode enum
	/// </summary>
	public enum EmailStatusCode
	{
		/// <summary>
		///     Your message is valid, but it is not queued to be delivered
		/// </summary>
		Ok = 200,

		/// <summary>
		///     Your message is both valid, and queued to be delivered.
		/// </summary>
		Accepted = 202,

		/// <summary>
		///     The badrequest
		/// </summary>
		Badrequest = 400,

		/// <summary>
		///     You do not have authorization to make the request.
		/// </summary>
		Unauthorized = 401,

		/// <summary>
		///     The forbidden
		/// </summary>
		Forbidden = 403,

		/// <summary>
		///     The resource you tried to locate could not be found or does not exist.
		/// </summary>
		Notfound = 404,

		/// <summary>
		///     Method not allowed
		/// </summary>
		Methodnotallowed = 405,

		/// <summary>
		///     The JSON payload you have included in your request is too large.
		/// </summary>
		PayloadTooLarge = 413,

		/// <summary>
		///     The unsupported media type
		/// </summary>
		UnsupportedMediaType = 415,

		/// <summary>
		///     The number of requests you have made exceeds SendGrid’s rate limitations
		/// </summary>
		TooManyRequests = 429,

		/// <summary>
		///     An error occurred on a SendGrid server.
		/// </summary>
		ServerUnavailable = 500,

		/// <summary>
		///     The SendGrid v3 Web API is not available.
		/// </summary>
		ServiceNotAvailable = 503
	}
}