using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Requests.BoardGames;

namespace Rental.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardGameController
    {
        private readonly IMediatorService _mediatorService;

        public BoardGameController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInput input)
        {
            var result = await _mediatorService.Request(new AddBoardGameRequest(input.Name, input.Price));
            return new OkObjectResult(new CreateOutput(result.NewGameBoardGuid, result.Message));
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediatorService.Request(new GetBoardGameByIdRequest(id));
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatorService.Request(new GetAllBoardGamesRequest());
            return new OkObjectResult(result);
        }
    }

    public class CreateOutput
    {
        public CreateOutput(Guid newBoardGameId)
        {
            NewBoardGameId = newBoardGameId;
        }

        public CreateOutput(Guid newBoardGameId, string message)
        {
            NewBoardGameId = newBoardGameId;
            Message = message;
        }

        public Guid NewBoardGameId { get; set; }
        public string Message { get; set; }
    }

    public class CreateInput
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }
}