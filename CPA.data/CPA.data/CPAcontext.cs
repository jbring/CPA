using System;
using System.Collections.Generic;
using System.Text;
using CPA.domain;
using Microsoft.EntityFrameworkCore;

namespace CPA.data
{
    public class CPAcontext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<When> When { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfCPA; Trusted_Connection = True; ");
        }
    }
}
