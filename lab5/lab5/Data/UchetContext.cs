using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class UchetContext : DbContext
    {
        public UchetContext(DbContextOptions<UchetContext> options): base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }

}
