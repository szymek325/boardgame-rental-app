using System;
using System.Collections.Generic;
using Rental.Core.Models.BoardGames;
using Rental.Core.Models.Clients;

namespace Rental.Core.Models.Rentals
{
    public class RentalWithPaymentDetails
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid BoardGameId { get; set; }
        public float ChargedDeposit { get; set; }
        public Status Status { get; set; }
        public DateTime CreationTime { get; set; }
        public BoardGame BoardGame { get; set; }
        public float MoneyToPay { get; set; }
        public ICollection<RentalDay> RentalDays { get; set; }
    }
}