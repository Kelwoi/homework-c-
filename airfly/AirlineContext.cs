using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using airfly.Entities;

namespace airfly
{
    public class AirlineContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\ProjectModels; Initial Catalog = Airtours; Integrated Security=True; Connect Timeout = 2");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);


            modelBuilder.Entity<Client>()
                .HasOne(c => c.Account)
                .WithOne(a => a.Client)
                .HasForeignKey<Account>(a => a.ClientId);


            modelBuilder.Entity<ClientFlight>()
                .HasKey(cf => new { cf.ClientId, cf.FlightId });

            modelBuilder.Entity<ClientFlight>()
                .HasOne(cf => cf.Client)
                .WithMany(c => c.ClientFlights)
                .HasForeignKey(cf => cf.ClientId);

            modelBuilder.Entity<ClientFlight>()
                .HasOne(cf => cf.Flight)
                .WithMany(f => f.ClientFlights)
                .HasForeignKey(cf => cf.FlightId);
        }
    }









}
