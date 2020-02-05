// <copyright file="LabelHelper.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Windows.Forms;

namespace Timer.Helpers
{
	/// <summary>
	///     Label extension helper class.
	/// </summary>
	public static class LabelHelper
	{
		/// <summary>
		///     Gets the time.
		/// </summary>
		/// <param name="label">The label.</param>
		/// <returns></returns>
		/// <exception cref="Exception">Invalid input data</exception>
		public static string[] GetTime(this Label label)
		{
			var time = label.Text.Split(':');

			if (time == null || time.Length != 2) throw new Exception("Invalid input data");

			return time;
		}
	}
}