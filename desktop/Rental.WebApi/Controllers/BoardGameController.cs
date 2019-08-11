using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rental.Core.Helpers;
using Rental.Core.Requests;

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