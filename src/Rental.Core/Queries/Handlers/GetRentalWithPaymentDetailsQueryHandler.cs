using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Rentals;
using Rental.CQRS;

namespace Rental.Core.Queries.Handlers
{
    internal class GetRentalWithPaymentDetailsQueryHandler : IQueryHandler<GetRentalWithPaymentDetailsQuery, RentalWithPaymentDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMediatorService _mediatorService;

        public GetRentalWithPaymentDetailsQueryHandler(IMapper mapper, IMediatorService mediatorService)
        {
            _mapper = mapper;
            _mediatorService = mediatorService;
        }

        public async Task<RentalWithPaymentDetails> Handle(GetRentalWithPaymentDetailsQuery request, CancellationToken cancellationToken)
        {
            var rentalWithDetails = await _mediatorService.Send(new GetRentalWithDetailsQuery(request.RentalGuid), cancellationToken);
            if (rentalWithDetails == null)
                throw new RentalNotFoundException(request.RentalGuid);

            var rentalWithPaymentDetails = _mapper.Map<RentalWithPaymentDetails>(rentalWithDetails);
            rentalWithPaymentDetails.RentalDays = await _mediatorService.Send(
                new CalculateDailyRentalPaymentsQuery(rentalWithDetails.BoardGame.Price, rentalWithDetails.CreationTime),
                cancellationToken);
            rentalWithPaymentDetails.MoneyToPay = rentalWithPaymentDetails.RentalDays.Sum(x => x.AmountDue);

            return rentalWithPaymentDetails;
        }
    }
}