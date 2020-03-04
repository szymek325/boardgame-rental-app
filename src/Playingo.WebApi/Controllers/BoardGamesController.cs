using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Playingo.Application.BoardGames.Commands;
using Playingo.Application.BoardGames.Queries;
using Playingo.Application.Common.Mediator;
using Playingo.WebApi.Dto;

namespace Playingo.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BoardGamesController
    {
        private readonly IMediatorService _mediatorService;

        public BoardGamesController(IMediatorService mediatorService)
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

        [HttpDelete("{id}")]
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