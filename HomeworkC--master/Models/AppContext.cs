using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class AppContext : IdentityDbContext<AppUser>
    {
        public DbSet<Passager> Passager{ get; set; }

        public DbSet<Flight> Flight { get; set; }

        public DbSet<Booking> Booking { get; set; }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=hotel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }*/
        public AppContext(DbContextOptions options) : base(options)
        { }
        public AppContext()
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.AppUser)
                    .WithMany(x => x.bookings)
                    .HasForeignKey(x => x.AppUserID)
                    ;
                entity.HasOne(x => x.Flight)
                    .WithMany(x => x.bookings)
                    .HasForeignKey(x => x.FlightId);
                
            });

            modelBuilder.Entity<Passager>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasIndex(x => x.CNP).IsUnique();
            });

            modelBuilder.Entity<Flight>(entity => {
                entity.HasKey(x => x.Id);

               
            });

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

        }
    }
}
