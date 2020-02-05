using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemTemperatureChecker.Models
{
	public class TemperatureType
	{
		public TemperatureType()
		{
			Temperature = new HashSet<Temperature>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }
		public ICollection<Temperature> Temperature { get; set; }
	}
}
