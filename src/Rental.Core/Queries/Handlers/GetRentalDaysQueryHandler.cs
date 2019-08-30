using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rental.Core.Common.Helpers;
using Rental.Core.Models.Rentals;
using Rental.CQS;

namespace Rental.Core.Queries.Handlers
{
    internal class GetRentalDaysQueryHandler : IQueryHandler<GetRentalDaysQuery, IList<RentalDay>>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMediatorService _mediatorService;

        public GetRentalDaysQueryHandler(IDateTimeProvider dateTimeProvider, IMediatorService mediatorService)
        {
            _dateTimeProvider = dateTimeProvider;
            _mediatorService = mediatorService;
        }

        public async Task<IList<RentalDay>> Handle(GetRentalDaysQuery request, CancellationToken cancellationToken)
        {
            if (request.RentFinishDate == null)
                request.RentFinishDate = _dateTimeProvider.UtcNow;

            var oneDayRentPrice = await _mediatorService.Send(new GetBoardGameRentDayPriceQuery(request.BoardGamePrice));

            var passedTime = request.RentFinishDate - request.RentStartDate;
            var passedDays = passedTime.Value.Days;
            if (passedTime.Value.Minutes >= 1)
                passedDays++;

            IList<RentalDay> rentDays = new List<RentalDay>();
            for (var i = 0; i < passedDays; i++)
                rentDays.Add(new RentalDay(oneDayRentPrice, request.RentStartDate.AddDays(i).Date));

            return rentDays;
        }
    }
}