using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rental.Core.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.CQRS;
using Rental.WebApi.Dto;

namespace Rental.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediatorService.Send(new GetRentalByIdQuery(id));
            return new OkObjectResult(result);
        }

        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetAllForClient(Guid clientId)
        {
            var result = await _mediatorService.Send(new GetAllRentalsForClientQuery(clientId));
            return new OkObjectResult(result);
        }

        [HttpGet("boardgame/{id}")]
        public async Task<IActionResult> GetAllForBoardGame(Guid boardGameId)
        {
            var result = await _mediatorService.Send(new GetAllRentalsForBoardGameQuery(boardGameId));
            return new OkObjectResult(result);
        }
    }
}