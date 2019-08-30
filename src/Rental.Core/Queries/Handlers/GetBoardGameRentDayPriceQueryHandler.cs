﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Rental.Core.Common.Configuration;
using Rental.CQRS;

namespace Rental.Core.Queries.Handlers
{
    internal class GetBoardGameRentDayPriceQueryHandler : IQueryHandler<GetBoardGameRentDayPriceQuery, decimal>
    {
        private readonly IOptions<PricesConfiguration> _pricesOptions;

        public GetBoardGameRentDayPriceQueryHandler(IOptions<PricesConfiguration> pricesOptions)
        {
            _pricesOptions = pricesOptions;
        }

        public Task<decimal> Handle(GetBoardGameRentDayPriceQuery request, CancellationToken cancellationToken)
        {
            var percentValue = (decimal) _pricesOptions.Value.DailyRentPercent / 100;
            var dailyPrice = percentValue * request.BoardGamePrice;
            return Task.FromResult(dailyPrice);
        }
    }
}