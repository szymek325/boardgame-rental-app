using System;
using Bogus;
using Faker;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Entities;

namespace Rental.DataAccess.Context
{
    internal class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<GameRental> GameRentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("r");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                modelBuilder.Entity(
                    entityType.Name,
                    x => { x.Property(nameof(BaseEntity.CreationTime)).HasDefaultValue(DateTime.UtcNow); });

            modelBuilder.Entity<BoardGame>().HasKey(x => x.Id);
            modelBuilder.Entity<GameRental>().HasKey(x => x.Id);
            modelBuilder.Entity<Client>().HasKey(x => x.Id);

            //FillData(modelBuilder);
        }

        private static void FillData(ModelBuilder modelBuilder)
        {
            var customers = Builder<Client>.CreateListOfSize(100)
                .All()
                .With(c => c.FirstName = Faker.Name.First())
                .With(c => c.LastName = Faker.Name.Last())
                .With(c => c.ContactNumber = Faker.Phone.Number())
                .With(c => c.EmailAddress = Faker.Internet.Email())
                .Build();

            modelBuilder.Entity<Client>().HasData(customers);
        }
    }
}