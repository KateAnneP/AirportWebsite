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

        public DbSet<projekt.Models.Flight>? Flight { get; set; }

        public DbSet<projekt.Models.FlightPassenger>? FlightPassenger { get; set; }

        public DbSet<projekt.Models.FlightStaff>? FlightStaff { get; set; }

        public DbSet<projekt.Models.Line>? Line { get; set; }

        public DbSet<projekt.Models.LinePlane>? LinePlane { get; set; }

        public DbSet<projekt.Models.Passenger>? Passenger { get; set; }

        public DbSet<projekt.Models.Plane>? Plane { get; set; }

        public DbSet<projekt.Models.Staff>? Staff { get; set; }

        public DbSet<projekt.Models.Status>? Status { get; set; }

        public DbSet<projekt.Models.Terminal>? Terminal { get; set; }
    }
}
