using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rental.Core.Common.Helpers;
using Rental.Core.Models.Rentals;
using Rental.CQRS;

namespace Rental.Core.Queries.Handlers
{
    internal class CalculateDailyRentalPaymentsQueryHandler : IQueryHandler<CalculateDailyRentalPaymentsQuery, IList<RentalDay>>
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public CalculateDailyRentalPaymentsQueryHandler(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public Task<IList<RentalDay>> Handle(CalculateDailyRentalPaymentsQuery request, CancellationToken cancellationToken)
        {
            if (request.RentFinishDate == null)
                request.RentFinishDate = _dateTimeProvider.UtcNow;

            //TODO this should be calculated in another query
            var dailyPrice = 7 / 100 * request.BoardGamePrice;

            var passedTime = request.RentFinishDate - request.RentStartDate;
            var passedDays = passedTime.Value.Days;
            if (passedDays == default && passedTime.Value.Minutes >= 1)
                passedDays++;

            IList<RentalDay> rentDays = new List<RentalDay>();
            for (var i = 0; i < passedDays; i++)
                rentDays.Add(new RentalDay(dailyPrice, request.RentStartDate.AddDays(0).Date));

            return Task.FromResult(rentDays);
        }
    }
}