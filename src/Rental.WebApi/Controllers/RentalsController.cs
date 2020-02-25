using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rental.Core.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Queries;
using Rental.CQS;
using Rental.WebApi.Dto;

namespace Rental.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RentalsController
    {
        private readonly IMediatorService _mediatorService;

        public RentalsController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRentalDto input)
        {
            var newGuid = Guid.NewGuid();
            await _mediatorService.Send(new AddRentalCommand(newGuid, input.ClientGuid, input.BoardGameGuid,
                input.ChargedDeposit));
            return new OkObjectResult(new {newGuid});
        }

        [HttpPut("complete")]
        public async Task<IActionResult> Complete(CompleteRentalDto input)
        {
            await _mediatorService.Send(new CompleteRentalCommand(input.RentalGuidId, input.PaidMoney));
            return new OkResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediatorService.Send(new GetRentalByIdQuery(id));
            return new OkObjectResult(result);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetByIdWithPaymentDetails(Guid id)
        {
            var result = await _mediatorService.Send(new GetRentalWithPaymentDetailsQuery(id));
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatorService.Send(new GetAllRentalsQuery());
            return new OkObjectResult(result);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetAllForClient(Guid clientId)
        {
            var result = await _mediatorService.Send(new GetAllRentalsForClientQuery(clientId));
            return new OkObjectResult(result);
        }

        [HttpGet("boardgame/{boardGameId}")]
        public async Task<IActionResult> GetAllForBoardGame(Guid boardGameId)
        {
            var result = await _mediatorService.Send(new GetAllRentalsForBoardGameQuery(boardGameId));
            return new OkObjectResult(result);
        }
    }
}