using CarTARgv23.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarTARgv23.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options) { }

        public DbSet<Car> Cars { get; set; }

    }
}
