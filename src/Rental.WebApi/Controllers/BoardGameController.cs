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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BoardGameController
    {
        private readonly IMediatorService _mediatorService;

        public BoardGameController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBoardGameDto input)
        {
            var newGuid = Guid.NewGuid();
            await _mediatorService.Send(new AddBoardGameCommand(newGuid, input.Name, input.Price));
            return new OkObjectResult(new {newGuid});
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBoardGameDto input)
        {
            await _mediatorService.Send(new UpdateBoardGameCommand(input.BoardGameGuid, input.Name,
                input.Price));
            return new OkResult();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediatorService.Send(new RemoveBoardGameCommand(id));
            return new OkResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediatorService.Send(new GetBoardGameByIdQuery(id));
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatorService.Send(new GetAllBoardGamesQuery());
            return new OkObjectResult(result);
        }
    }
}