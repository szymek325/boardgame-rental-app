using System;

namespace Rental.React.Dto
{
    public class CompleteRentalDto
    {
        public Guid RentalGuidId { get; set; }
        public decimal PaidMoney { get; set; }
    }
}