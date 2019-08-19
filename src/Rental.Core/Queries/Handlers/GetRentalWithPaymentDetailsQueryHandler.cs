using System;
using System.Threading;
using System.Threading.Tasks;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Rentals;
using Rental.CQRS;

namespace Rental.Core.Queries.Handlers
{
    internal class GetRentalWithPaymentDetailsQueryHandler : IQueryHandler<GetRentalWithPaymentDetailsQuery, RentalWithPaymentDetails>
    {
        private readonly IMediatorService _mediatorService;

        public GetRentalWithPaymentDetailsQueryHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<RentalWithPaymentDetails> Handle(GetRentalWithPaymentDetailsQuery request, CancellationToken cancellationToken)
        {
            var rentalWithDetails = await _mediatorService.Send(new GetRentalWithDetailsQuery(request.RentalGuid), cancellationToken);

            throw new NotImplementedException();
        }
    }
}