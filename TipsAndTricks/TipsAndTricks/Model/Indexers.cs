using System;

namespace TipsAndTricks.Model
{
	public class Indexers
	{
		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public string[] Data { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Indexers"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public Indexers(string[] data)
		{
			Data = data;
		}

		/// <summary>
		/// Gets or sets the <see cref="System.String"/> at the specified index.
		/// </summary>
		/// <value>
		/// The <see cref="System.String"/>.
		/// </value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		/// <exception cref="Exception">
		/// </exception>
		public string this[int index]
		{
			get
			{
				try
				{
					return Data[index];
				}
				catch (IndexOutOfRangeException)
				{
					throw new Exception($"Item at index {index} not found");
				}
			}
			set
			{
				try
				{
					Data[index] = value;
				}
				catch (IndexOutOfRangeException)
				{
					throw new Exception($"Item at index {index} not found");
				}
			}
		}
	}
}