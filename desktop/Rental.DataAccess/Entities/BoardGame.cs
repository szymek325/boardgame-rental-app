using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.DataAccess.Entities
{
    internal class BoardGame
    {
        [Key] [Required] public Guid Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public float Price { get; set; }

        [Required] public DateTime CreationTime { get; set; }

        public ICollection<GameRental> GameRentals { get; set; }
    }
}