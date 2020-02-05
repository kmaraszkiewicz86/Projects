// <copyright file="InvalidWordModelDataType.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace ImplementationsUnitTest.Enums
{
	public enum WordModelDataType
	{
		/// <summary>
		/// The updating valid date
		/// </summary>
		UpdatingValidData,

		/// <summary>
		/// The none
		/// </summary>
		None,

		/// <summary>
		/// The word no exists
		/// </summary>
		WordNoExists,

		/// <summary>
		/// The word as parent word
		/// </summary>
		WordAsChildWord,

		/// <summary>
		/// The category no exists
		/// </summary>
		CategoryNoExists,

		/// <summary>
		/// The empty original value
		/// </summary>
		EmptyOriginalValue,

		/// <summary>
		/// The original value exists
		/// </summary>
		OriginalValueExists,

		/// <summary>
		/// The empty translated word value
		/// </summary>
		EmptyTranslatedWordValue,

		/// <summary>
		/// The empty translated words collection
		/// </summary>
		EmptyTranslatedWordsCollection
	}
}