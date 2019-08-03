using System;
using Rental.Core.Models;

namespace Rental.Core.Entities
{
    public class GameRental : BaseEntity
    {
        public int ClientId { get; set; }
        public int BoardGameId { get; set; }
        public float ChargedDeposit { get; set; }
        public BoardGame BoardGame { get; set; }
        public Client Client { get; set; }
        public Status Status { get; set; }
        public float PaidMoney { get; set; }

        public float GetMoneyToPay()
        {
            if (BoardGame == null)
                throw new ArgumentException(nameof(BoardGame));
            var rentDays = (DateTime.UtcNow - CreationTime).Days;
            var payment = rentDays * BoardGame.PricePerDay;
            return payment;
        }
    }
}