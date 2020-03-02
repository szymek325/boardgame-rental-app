using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.BoardGames.Commands;
using Playingo.Application.Common.Helpers;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    internal class GetRentalDaysQuery : IQuery<IList<RentalDay>>
    {
        public GetRentalDaysQuery(decimal boardGamePrice, DateTime rentStartDate)
        {
            BoardGamePrice = boardGamePrice;
            RentStartDate = rentStartDate;
        }

        public GetRentalDaysQuery(decimal boardGamePrice, DateTime rentStartDate, DateTime? rentFinishDate)
        {
            BoardGamePrice = boardGamePrice;
            RentStartDate = rentStartDate;
            RentFinishDate = rentFinishDate;
        }

        public decimal BoardGamePrice { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime? RentFinishDate { get; set; }
    }

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

            var oneDayRentPrice = await _mediatorService.Send(new GetBoardGameRentDayPriceQuery(request.BoardGamePrice),
                cancellationToken);

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