using Rental.Core.Models.Rentals;
using Rental.CQRS;

namespace Rental.Core.Queries
{
    public class GetMoneyToBePaid : IQuery<RentalWithPaymentDetails>
    {
    }
}