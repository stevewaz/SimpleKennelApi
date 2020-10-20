using System;
using Microsoft.EntityFrameworkCore;
using SimpleKennelApi.Models;

namespace SimpleKennelApi.Models
{
    public class SimpleKennelContext : DbContext
    {
        public SimpleKennelContext(DbContextOptions<SimpleKennelContext> options)
        :base(options)
        {}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=SimpleKennel.db");
        public DbSet<Kennel> Kennels{get;set;}
        public DbSet<Customer> Customers{get;set;}
        public DbSet<Pet> Pets{get;set;}
        public DbSet<SimpleKennelApi.Models.Appointment> Appointment { get; set; }
    }
}
