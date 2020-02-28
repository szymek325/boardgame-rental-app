using System;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;

namespace Playingo.Domain.Rentals
{
    public class RentalWithDetails
    {
        public RentalWithDetails(Guid id, decimal chargedDeposit, decimal paidMoney, Status status,
            DateTime creationTime,
            DateTime? finishTime,
            BoardGame boardGame, Client client)
        {
            Id = id;
            ChargedDeposit = chargedDeposit;
            PaidMoney = paidMoney;
            Status = status;
            CreationTime = creationTime;
            FinishTime = finishTime;
            BoardGame = boardGame;
            Client = client;
        }

        public Guid Id { get; set; }
        public decimal ChargedDeposit { get; set; }
        public decimal PaidMoney { get; set; }
        public Status Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public BoardGame BoardGame { get; set; }
        public Client Client { get; set; }
    }
}