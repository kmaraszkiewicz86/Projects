// <copyright file="TimerType.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace Timer.Enums
{
	/// <summary>
	///     TimerType enum
	/// </summary>
	public enum TimerType
	{
		/// <summary>
		/// Invalid action
		/// </summary>
		None = 0,

		/// <summary>
		///     The timer
		/// </summary>
		Timer = 1,

		/// <summary>
		///     The timer before play sound
		/// </summary>
		TimerBeforePlaySound = 2
	}
}