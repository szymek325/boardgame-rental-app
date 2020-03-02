using System.Collections.Generic;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsQuery : IQuery<IList<Domain.Rentals.Rental>>
    {
    }
}