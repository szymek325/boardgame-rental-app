using System;

namespace Playingo.WebApi.Dto
{
    public class CompleteRentalDto
    {
        public Guid RentalGuidId { get; set; }
        public decimal PaidMoney { get; set; }
    }
}