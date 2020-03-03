using System;

namespace Playingo.WebApi.Dto
{
    public class CreateRentalDto
    {
        public Guid BoardGameGuid { get; set; }
        public Guid ClientGuid { get; set; }
        public decimal ChargedDeposit { get; set; }
    }
}