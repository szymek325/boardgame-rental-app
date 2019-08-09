using System;
using System.ComponentModel.DataAnnotations;
using Rental.Core.Models;

namespace Rental.DataAccess.Entities
{
    internal class GameRental
    {
        [Key]
        public Guid Id { get; set; }

        public int ClientId { get; set; }
        public int BoardGameId { get; set; }
        public float ChargedDeposit { get; set; }
        public float PaidMoney { get; set; }
        public DateTime CreationTime { get; set; }
        public BoardGame BoardGame { get; set; }
        public Client Client { get; set; }
        public Status Status { get; set; }
    }
}