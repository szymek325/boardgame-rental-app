using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;
using Playingo.Domain.Rentals.Exceptions;

namespace Playingo.Application.Rentals.Queries
{
    public class GetRentalWithPaymentDetailsQuery : IQuery<RentalWithPaymentDetails>
    {
        public GetRentalWithPaymentDetailsQuery(Guid rentalGuid)
        {
            RentalGuid = rentalGuid;
        }

        public Guid RentalGuid { get; }
    }

    internal class
        GetRentalWithPaymentDetailsQueryHandler : IQueryHandler<GetRentalWithPaymentDetailsQuery,
            RentalWithPaymentDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMediatorService _mediatorService;

        public GetRentalWithPaymentDetailsQueryHandler(IMapper mapper, IMediatorService mediatorService)
        {
            _mapper = mapper;
            _mediatorService = mediatorService;
        }

        public async Task<RentalWithPaymentDetails> Handle(GetRentalWithPaymentDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var rentalWithDetails =
                await _mediatorService.Send(new GetRentalWithDetailsQuery(request.RentalGuid), cancellationToken);
            if (rentalWithDetails == null)
                throw new RentalNotFoundException(request.RentalGuid);

            var rentalWithPaymentDetails = _mapper.Map<RentalWithPaymentDetails>(rentalWithDetails);
            rentalWithPaymentDetails.RentalDays = await _mediatorService.Send(
                new GetRentalDaysQuery(rentalWithDetails.BoardGame.Price, rentalWithDetails.CreationTime),
                cancellationToken);

            rentalWithPaymentDetails.MoneyToPay = rentalWithPaymentDetails.RentalDays.Sum(x => x.AmountDue);
            return rentalWithPaymentDetails;
        }
    }
}