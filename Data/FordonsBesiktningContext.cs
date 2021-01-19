using System;
using System.Collections.Generic;
using System.Text;
using Fordonsbesiktning_EF_.Models;
using Microsoft.EntityFrameworkCore;

namespace Fordonsbesiktning_EF_.Data
{
    class FordonsBesiktningContext : DbContext
    {
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BilProvningEF;Integrated Security=True");
        }
    }

    

}
