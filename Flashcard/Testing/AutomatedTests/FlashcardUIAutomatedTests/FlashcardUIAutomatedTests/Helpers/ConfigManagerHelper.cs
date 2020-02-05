using System.Configuration;

namespace FlashcardUIAutomatedTests.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	internal static class ConfigManagerHelper
	{
		/// <summary>
		/// Gets the host URL.
		/// </summary>
		/// <value>
		/// The host URL.
		/// </value>
		public static string HostUrl =>
			ConfigurationManager.AppSettings["Host"];

		/// <summary>
		/// Gets the login.
		/// </summary>
		/// <param name="prefix">The prefix.</param>
		/// <returns></returns>
		public static string GetLogin(string prefix) =>
			ConfigurationManager.AppSettings[$"{prefix}Login"];

		/// <summary>
		/// Gets the password.
		/// </summary>
		/// <param name="prefix">The prefix.</param>
		/// <returns></returns>
		public static string GetPassword(string prefix) =>
			ConfigurationManager.AppSettings[$"{prefix}Password"];

		/// <summary>
		/// Gets the page URL.
		/// </summary>
		/// <param name="prefix">The prefix.</param>
		/// <returns></returns>
		public static string GetPageUrl(string prefix) =>
			$"{HostUrl}/{ConfigurationManager.AppSettings[$"{prefix}Page"]}";
	}
}