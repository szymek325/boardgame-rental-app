using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain.Rentals;
using Rental.CQS;

namespace Playingo.Application.Rentals
{
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