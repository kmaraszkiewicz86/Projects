using Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Core.Core
{
    class AppDbContextFactory
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(ConnectionBuilderHelper.GetDefaultConnectionString());

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
