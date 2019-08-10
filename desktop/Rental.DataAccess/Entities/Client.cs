using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.DataAccess.Entities
{
    internal class Client
    {
        [Key] public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<GameRental> GameRentals { get; set; }
    }
}