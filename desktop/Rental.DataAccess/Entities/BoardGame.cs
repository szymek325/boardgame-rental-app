using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.DataAccess.Entities
{
    internal class BoardGame
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<GameRental> GameRentals { get; set; }
    }
}