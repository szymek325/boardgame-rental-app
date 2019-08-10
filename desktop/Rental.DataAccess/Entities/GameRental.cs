using System;
using System.ComponentModel.DataAnnotations;
using Rental.Core.Models;

namespace Rental.DataAccess.Entities
{
    internal class GameRental
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid BoardGameId { get; set; }

        [Required]
        public float ChargedDeposit { get; set; }

        [Required]
        public float PaidMoney { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public BoardGame BoardGame { get; set; }
        public Client Client { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}