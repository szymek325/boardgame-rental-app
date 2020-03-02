using System.Collections.Generic;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsQuery : IQuery<IList<Rental>>
    {
    }
}