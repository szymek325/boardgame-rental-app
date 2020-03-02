using System.Collections.Generic;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsQuery : IQuery<IList<Domain.Rentals.Rental>>
    {
    }
}