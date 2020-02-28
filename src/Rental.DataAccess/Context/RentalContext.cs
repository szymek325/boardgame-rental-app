using System;
using System.Linq;
using Faker;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Playingo.Domain;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.Context
{
    internal class RentalContext : DbContext
    {
        // required for Mock of context
        internal RentalContext()
        {
        }

        public RentalContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Entities.Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("r");

            modelBuilder.Entity<BoardGame>().HasKey(x => x.Id);
            modelBuilder.Entity<BoardGame>().Property(x => x.CreationTime).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Entities.Rental>().HasKey(x => x.Id);
            modelBuilder.Entity<Entities.Rental>().Property(x => x.CreationTime).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Client>().HasKey(x => x.Id);
            modelBuilder.Entity<Client>().Property(x => x.CreationTime).HasDefaultValue(DateTime.UtcNow);

            //FillData(modelBuilder);
        }

        private static void FillData(ModelBuilder modelBuilder)
        {
            var client = Builder<Client>.CreateListOfSize(100)
                .All()
                .With(c => c.Id = Guid.NewGuid())
                .With(c => c.FirstName = Name.First())
                .With(c => c.LastName = Name.Last())
                .With(c => c.ContactNumber = Phone.Number())
                .With(c => c.EmailAddress = Internet.Email())
                .Build();
            modelBuilder.Entity<Client>().HasData(client);

            var boardGames = Builder<BoardGame>.CreateListOfSize(100)
                .All()
                .With(c => c.Id = Guid.NewGuid())
                .With(c => c.Name = Lorem.GetFirstWord())
                .With(c => c.Price = RandomNumber.Next(50, 250))
                .Build();
            modelBuilder.Entity<BoardGame>().HasData(boardGames);

            var rnd = new Random();
            var rentals = Builder<Entities.Rental>.CreateListOfSize(100)
                .All()
                .With(c => c.Id = Guid.NewGuid())
                .With(c => c.ClientId = client.OrderBy(x => Guid.NewGuid()).First().Id)
                .With(c => c.BoardGameId = boardGames.OrderBy(x => Guid.NewGuid()).First().Id)
                .With(c => c.ChargedDeposit = 15)
                .With(c => c.Status = (Status) rnd.Next(1, 2))
                .Build();
            modelBuilder.Entity<Entities.Rental>().HasData(rentals);
        }
    }
}