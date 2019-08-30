﻿using System;
using Rental.Core.Models.Rentals;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetRentalWithDetailsQuery : IQuery<RentalWithDetails>
    {
        public GetRentalWithDetailsQuery(Guid gameRentalGuid)
        {
            GameRentalGuid = gameRentalGuid;
        }

        public Guid GameRentalGuid { get; set; }
    }
}