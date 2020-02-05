using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemTemperatureChecker.Models
{
	public class Temperature
	{
		public int Id { get; set; }

		[Required]
		public int TypeId { get; set; }

		[Required]
		public double ValueC { get; set; }

		[Required]
		public double ValueF { get; set; }

		[ForeignKey("TypeId")]
		public TemperatureType TemperatureType { get; set; }
	}
}
