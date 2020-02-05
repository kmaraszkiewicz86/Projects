using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SystemTemperatureChecker.Models;

namespace SystemTemperatureChecker.Database
{
	public class SystemTemperatureCheckerDbContext : DbContext
	{
		public SystemTemperatureCheckerDbContext()
			: base("name=SystemTemperatureCheckerDbContext")
		{
		}

		public virtual DbSet<Temperature> Temperatures { get; set; }
		public virtual DbSet<TemperatureType> TemperatureType { get; set; }
	}
}
