using System;
using System.ComponentModel.DataAnnotations;
using Playingo.Domain;

namespace Rental.DataAccess.Entities
{
    internal class Rental
    {
        [Key] [Required] public Guid Id { get; set; }

        [Required] public Guid ClientId { get; set; }

        [Required] public Guid BoardGameId { get; set; }

        [Required] public decimal ChargedDeposit { get; set; }

        public decimal PaidMoney { get; set; }

        [Required] public DateTime CreationTime { get; set; }

        public DateTime? FinishTime { get; set; }

        public BoardGame BoardGame { get; set; }
        public Client Client { get; set; }

        [Required] public Status Status { get; set; }
    }
}