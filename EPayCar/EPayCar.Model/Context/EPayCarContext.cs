using EPayCar.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EPayCar.Model.Context
{
    public class EPayCarContext : DbContext
    {
        public EPayCarContext(DbContextOptions<EPayCarContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Carbrands> Carbrandss { get; set; }

        public DbSet<Carscs> Carscs { get; set; }
        public DbSet<Orders> Orderss { get; set; }

    }
}
