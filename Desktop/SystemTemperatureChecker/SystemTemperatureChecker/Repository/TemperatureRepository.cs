// <copyright file="TemperatureRepository.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Linq;
using SystemTemperatureChecker.Models;

namespace SystemTemperatureChecker.Repository
{
	/// <summary>
	/// /// TemperatureRepository database repository class.
	/// </summary>
	/// <seealso cref="BaseRepository" />
	public class TemperatureRepository : BaseRepository
	{
		/// <summary>
		/// Adds the temperature.
		/// </summary>
		/// <param name="ariName">Name of the ari.</param>
		/// <param name="temperatureF">The temperature in farenhait.</param>
		/// <param name="temperatureC">The temperature in celsius.</param>
		public void Add(string ariName, double temperatureF, double temperatureC)
		{
			OnConnection(client =>
			{
				var typeId = client.AddType(ariName);
				client.Temperatures.Add(new Temperature
				{
					TypeId = typeId,
					ValueF = temperatureF,
					ValueC = temperatureC
				});

				client.SaveChanges();
			});
		}

		/// <summary>
		/// Clears data from database.
		/// </summary>
		public void Clear()
		{
			OnConnection(client =>
			{
				List<Temperature> temperatures = client.Temperatures.ToList();

				for (int i = 0; i < temperatures.Count; i++)
				{
					client.Temperatures.Remove(temperatures[i]);
				}

				client.ClearTypes();

				client.SaveChanges();
			});
		}

		/// <summary>
		/// Gets the minimum temperature.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public AverageTemperature GetMinTemperature(string name)
		{
			return OnConnection(client =>
			{
				return client.Temperatures.GroupBy(t => t.TemperatureType.Name)
					.Where(temp => temp.Key == name)
					.Select(temp => new AverageTemperature
					{
						Name = temp.Key,
						ValueC = temp.Min(t => t.ValueC),
						ValueF = temp.Min(t => t.ValueF)
					})
					.FirstOrDefault();
			});
		}

		/// <summary>
		/// Gets the maximum temperature.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public AverageTemperature GetMaxTemperature(string name)
		{
			return OnConnection(client =>
			{
				return client.Temperatures.GroupBy(t => t.TemperatureType.Name)
					.Where(temp => temp.Key == name)
					.Select(temp => new AverageTemperature
					{
						Name = temp.Key,
						ValueC = temp.Max(t => t.ValueC),
						ValueF = temp.Max(t => t.ValueF)
					})
					.FirstOrDefault();
			});
		}
	}
}