// <copyright file="TemperatureTypeRepository.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Linq;
using SystemTemperatureChecker.Database;
using SystemTemperatureChecker.Models;

namespace SystemTemperatureChecker.Repository
{
	/// <summary>
	/// TemperatureTypeRepository database repository class.
	/// </summary>
	public static class TemperatureTypeRepository
	{
		/// <summary>
		/// Adds the type.
		/// </summary>
		/// <param name="client">The client.</param>
		/// <param name="typeName">Name of the type.</param>
		/// <returns></returns>
		public static int AddType(this SystemTemperatureCheckerDbContext client, string typeName)
		{
			var type = client.TemperatureType.FirstOrDefault(item => item.Name.ToLower() == typeName);

			if (type == null)
			{
				type = client.TemperatureType.Add(new TemperatureType
				{
					Name = typeName
				});
			}

			return type.Id;
		}

		/// <summary>
		/// Clears types.
		/// </summary>
		/// <param name="client">The client.</param>
		public static void ClearTypes(this SystemTemperatureCheckerDbContext client)
		{
			List<TemperatureType> temperatureTypes = client.TemperatureType.ToList();

			for (int i = 0; i < temperatureTypes.Count; i++)
			{
				client.TemperatureType.Remove(temperatureTypes[i]);
			}
		}
	}
}