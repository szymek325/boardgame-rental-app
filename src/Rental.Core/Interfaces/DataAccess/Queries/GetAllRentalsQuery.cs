﻿using System.Collections.Generic;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsQuery : IQuery<IList<Models.Rentals.Rental>>
    {
    }
}