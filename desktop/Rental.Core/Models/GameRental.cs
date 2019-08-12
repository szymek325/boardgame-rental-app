using System;

namespace Rental.Core.Models
{
    public class GameRental
    {
        public GameRental(Guid clientId, Guid boardGameId, float chargedDeposit)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            BoardGameId = boardGameId;
            ChargedDeposit = chargedDeposit;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid BoardGameId { get; set; }
        public float ChargedDeposit { get; set; }
        public float PaidMoney { get; set; }
        public BoardGame BoardGame { get; set; }
        public Client Client { get; set; }
        public Status Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? FinishTime { get; set; }
    }
}