using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projekt.Models;

namespace projekt.Data
{
    public class projektContext : DbContext
    {
        public projektContext (DbContextOptions<projektContext> options)
            : base(options)
        {
        }

        public DbSet<projekt.Models.Destination> Destination { get; set; } = default!;
    }
}
