using System.Collections.Generic;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    public class GetAllRentalsQuery : IQuery<IList<Rental>>
    {
    }
}