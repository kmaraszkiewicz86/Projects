// <copyright file="SystemInfo.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SystemTemperatureChecker.Models;
using SystemTemperatureChecker.Repository;
using OpenHardwareMonitor.Hardware;

namespace SystemTemperatureChecker.Core
{
	/// <summary>
	///     SystemInfo class.
	/// </summary>
	internal class SystemInfo
	{
		/// <summary>
		///     Occurs when [report items event handler].
		/// </summary>
		public event EventHandler<ReportItemsEventArgs> ReportItemsEventHandler;

		/// <summary>
		///     Occurs when [report items event handler].
		/// </summary>
		public event EventHandler<ErrorEventArgs> ErrorEventArgsEventHandler;

		/// <summary>
		///     The computer hardware
		/// </summary>
		private Computer computerHardware;

		/// <summary>
		///     The system data collections
		/// </summary>
		private Dictionary<string, List<SystemDataItem>> _systemDataCollections;

		/// <summary>
		///     Gets the system temperature information.
		/// </summary>
		public void GetSystemTemperatureInformation()
		{
			var workThread = new Thread(GetSystemTemperatureInformationCommon);
			workThread.Start();
		}

		/// <summary>
		/// Clears the database.
		/// </summary>
		public void ClearDatabase()
		{
			var workThread = new Thread(() =>
			{
				new TemperatureRepository().Clear();
			});

			workThread.Start();
		}

		/// <summary>
		///     Gets the system temperature information common.
		/// </summary>
		private void GetSystemTemperatureInformationCommon()
		{
			try
			{
				computerHardware = new Computer();

				_systemDataCollections = new Dictionary<string, List<SystemDataItem>>
			{
				{"Motherboard", new List<SystemDataItem>()},
				{"CPU", new List<SystemDataItem>()},
				{"GPU", new List<SystemDataItem>()},
				{"Other", new List<SystemDataItem>()}
			};

				string s = string.Empty;
				string name = string.Empty;
				string type = string.Empty;
				string value = string.Empty;
				int x, y, z, yy, zz;
				int hardwareCount;
				int subcount;
				int sensorcount;
				int moresubhardwarecount;
				int moresensorcount;
				computerHardware.MainboardEnabled = true;
				computerHardware.FanControllerEnabled = true;
				computerHardware.CPUEnabled = true;
				computerHardware.GPUEnabled = true;
				computerHardware.RAMEnabled = false;
				computerHardware.HDDEnabled = false;
				computerHardware.Open();
				hardwareCount = computerHardware.Hardware.Count();
				for (x = 0; x < hardwareCount; x++)
				{
					name = computerHardware.Hardware[x].Name;
					type = computerHardware.Hardware[x].HardwareType.ToString();

					value = "";
					AddReportItem(name, type, value);
					subcount = computerHardware.Hardware[x].SubHardware.Count();

					for (y = 0; y < subcount; y++)
					{
						computerHardware.Hardware[x].SubHardware[y].Update();
						if (computerHardware.Hardware[x].SubHardware[y].SubHardware.Any())
						{
							yy = computerHardware.Hardware[x].SubHardware[y].SubHardware.Count();
							for (zz = 0; zz < yy; zz++)
							{
								computerHardware.Hardware[x].SubHardware[y].SubHardware[zz].Update();
							}
						}
					}

					if (subcount > 0)
					{
						for (y = 0; y < subcount; y++)
						{
							sensorcount = computerHardware.Hardware[x].SubHardware[y].Sensors.Count();
							// REV 08-06-2016
							moresubhardwarecount = computerHardware.Hardware[x].SubHardware[y].SubHardware.Count();
							// END REV
							name = computerHardware.Hardware[x].SubHardware[y].Name;
							type = computerHardware.Hardware[x].SubHardware[y].HardwareType.ToString();
							value = "";
							AddReportItem(name, type, value);

							if (sensorcount > 0)
							{
								for (z = 0; z < sensorcount; z++)
								{
									name = computerHardware.Hardware[x].SubHardware[y].Sensors[z].Name;
									type = computerHardware.Hardware[x].SubHardware[y].Sensors[z].SensorType.ToString();
									value = computerHardware.Hardware[x].SubHardware[y].Sensors[z].Value.ToString();
									AddReportItem(name, type, value);
								}
							}

							// REV 08-06-2016
							for (yy = 0; yy < moresubhardwarecount; yy++)
							{
								computerHardware.Hardware[x].SubHardware[y].SubHardware[yy].Update();
								moresensorcount = computerHardware.Hardware[x].SubHardware[y].SubHardware[yy].Sensors
									.Count();
								name = computerHardware.Hardware[x].SubHardware[y].SubHardware[yy].Name;
								type = computerHardware.Hardware[x].SubHardware[y].SubHardware[yy].HardwareType.ToString();
								value = "";
								AddReportItem(name, type, value);

								if (sensorcount > 0)
								{
									for (zz = 0; zz < sensorcount; zz++)
									{
										name = computerHardware.Hardware[x].SubHardware[y].SubHardware[yy].Sensors[zz].Name;
										type = computerHardware.Hardware[x].SubHardware[y].SubHardware[yy].Sensors[zz]
											.SensorType.ToString();
										value = computerHardware.Hardware[x].SubHardware[y].SubHardware[yy].Sensors[zz]
											.Value.ToString();
										AddReportItem(name, type, value);
									}
								}
							}
						}
					}

					sensorcount = computerHardware.Hardware[x].Sensors.Count();

					if (sensorcount > 0)
					{
						for (z = 0; z < sensorcount; z++)
						{
							name = computerHardware.Hardware[x].Sensors[z].Name;
							type = computerHardware.Hardware[x].Sensors[z].SensorType.ToString();
							value = computerHardware.Hardware[x].Sensors[z].Value.ToString();
							AddReportItem(name, type, value);
						}
					}
				}

				ReportItemsEventHandler?.Invoke(this, new ReportItemsEventArgs(_systemDataCollections));
			}
			catch (Exception err)
			{
				ErrorEventArgsEventHandler?.Invoke(this, new ErrorEventArgs(err.Message));
			}
		}

		/// <summary>
		///     Adds the report item.
		/// </summary>
		/// <param name="ariName">Name of the ari.</param>
		/// <param name="ariType">Type of the ari.</param>
		/// <param name="ariValue">The ari value.</param>
		private void AddReportItem(string ariName, string ariType, string ariValue)
		{
			if (ariType == "Data" && ariValue == "" && !ariName.Contains("Memory") ||
			    ariType == "Level" && ariValue == "")
			{
				return;
			}

			string name = ariName;
			string type = ariType + ": ";
			string reading = ariValue;
			double tempC = 0;
			double tempF = 0;

			if (ariType == "GpuAti")
			{
				type = "Graphics Card";
			}

			if (ariType == "Temperature")
			{
				try
				{
					tempC = Convert.ToDouble(ariValue);
					tempF = 9.0 / 5.0 * tempC + 32;

					reading = $"{ariValue} ({tempF.ToString("F1") + " F"})";
					;
				}
				catch
				{
					return;
				}
			}

			if (ariType == "Clock")
			{
				try
				{
					double temp = Convert.ToDouble(ariValue);
					if (temp < 1000)
					{
						reading = temp.ToString("F1") + " MHZ";
					}
					else
					{
						temp = temp / 1000;
						reading = temp.ToString("F1") + " GHZ";
					}
				}
				catch
				{
					return;
				}
			}

			if (ariType == "Control" || ariType == "Load")
			{
				try
				{
					double temp = Convert.ToDouble(ariValue);
					name = ariName;
					reading = temp.ToString("F1") + " %";
				}
				catch
				{
					return;
				}
			}

			if (ariType == "Voltage")
			{
				try
				{
					double temp = Convert.ToDouble(ariValue);
					name = ariName;
					reading = temp.ToString("F1") + " V";
				}
				catch
				{
					return;
				}
			}

			if (ariType == "Fan")
			{
				try
				{
					double rpm = Convert.ToDouble(ariValue);
					name = ariName;
					reading = rpm.ToString("F0") + " RPM";
				}
				catch
				{
					return;
				}
			}

			if (ariType == "Power")
			{
				try
				{
					double watts = Convert.ToDouble(ariValue);
					name = ariName;
					reading = watts.ToString("F1") + " W";
				}
				catch
				{
					return;
				}
			}

			if (ariName.ToLower().Contains("cpu"))
			{
				AddItemToSystemDataCollections("CPU", name, type, reading, tempF, tempC);
			}
			else if (ariName.ToLower().Contains("gpu"))
			{
				AddItemToSystemDataCollections("GPU", name, type, reading, tempF, tempC);
			}
			else if (ariName.ToLower().Contains("voltage") || ariName.ToLower().Contains("fan"))
			{
				AddItemToSystemDataCollections("Motherboard", name, type, reading);
			}
			else
			{
				AddItemToSystemDataCollections("Motherboard", name, type, reading, tempF, tempC);
			}
		}

		/// <summary>
		///     Adds the item to system data collections.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="ariName">Name of the ari.</param>
		/// <param name="ariType">Type of the ari.</param>
		/// <param name="ariValue">The ari value.</param>
		/// <param name="temperatureF">The farenhait temperature.</param>
		/// <param name="temperatureC">The celsius temperature.</param>
		private void AddItemToSystemDataCollections(string type, string ariName, string ariType, string ariValue,
			double temperatureF = 0, double temperatureC = 0)
		{
			if (ariType.ToLower().Contains("temperature") || ariType.ToLower().Contains("fan"))
			{
				var minValue = "0";
				var maxValue = "0";
				if (ariType.ToLower().Contains("temperature"))
				{
					if (ariName.ToLower().Contains("temperature #"))
					{
						Console.WriteLine(ariName);
					}

					var temperatureRepository = new TemperatureRepository();
					temperatureRepository.Add(ariName, temperatureF, temperatureC);
					var maxAverageTemperature = temperatureRepository.GetMaxTemperature(ariName);
					var minAverageTemperature = temperatureRepository.GetMinTemperature(ariName);

					maxValue = $"{maxAverageTemperature.ValueC} ({maxAverageTemperature.ValueF} F)";
					minValue = $"{minAverageTemperature.ValueC} ({minAverageTemperature.ValueF} F)";
				}
				
				_systemDataCollections[type].Add(new SystemDataItem
				{
					Name = ariName,
					Type = ariType,
					Value = ariValue,
					MinValue = minValue,
					MaxValue = maxValue
				});
			}
		}
	}
}