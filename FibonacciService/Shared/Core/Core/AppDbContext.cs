using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Core
{
    public class AppDbContext: DbContext
    {
        public virtual DbSet<FibResult> FibResults { get; set; }

        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }
    }
}
