using System;

namespace Rental.WebApi.Dto
{
    public class CreateRentalDto
    {
        public Guid BoardGameGuid { get; set; }
        public Guid ClientGuid { get; set; }
        public decimal ChargedDeposit { get; set; }
    }
}