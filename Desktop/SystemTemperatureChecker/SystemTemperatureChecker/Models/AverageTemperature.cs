// <copyright file="AverageTemperature.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace SystemTemperatureChecker.Models
{
	/// <summary>
	/// AverageTemperature model class.
	/// </summary>
	public class AverageTemperature
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the value c.
		/// </summary>
		/// <value>
		/// The value c.
		/// </value>
		public double ValueC { get; set; }

		/// <summary>
		/// Gets or sets the value f.
		/// </summary>
		/// <value>
		/// The value f.
		/// </value>
		public double ValueF { get; set; }
	}
}