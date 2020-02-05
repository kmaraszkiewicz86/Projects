// <copyright file="SettingsModelMockHelper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using DataModel.Models.Config;

namespace ImplementationsUnitTest.Helpers
{
	/// <summary>
	///     SettingsModelMockHelper class.
	/// </summary>
	public static class SettingsModelMockHelper
	{
		/// <summary>
		///     Settingses the model test.
		/// </summary>
		/// <returns></returns>
		public static SettingsModel SettingsModelTest => new SettingsModel
		{
			Hostname = "test.com"
		};

		/// <summary>
		/// Gets the email settings model.
		/// </summary>
		/// <value>
		/// The email settings model.
		/// </value>
		public static EmailSettingsModel EmailSettingsModel => new EmailSettingsModel
		{
			ApiKey = "test",
			Email = "test@wp.pl"
		};
	}
}