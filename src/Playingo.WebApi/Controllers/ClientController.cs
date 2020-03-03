using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Playingo.Application.Clients.Commands;
using Playingo.Application.Clients.Queries;
using Playingo.Application.Common.Mediator;
using Playingo.WebApi.Dto;

namespace Playingo.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClientController
    {
        private readonly IMediatorService _mediatorService;

        public ClientController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto input)
        {
            var newGuid = Guid.NewGuid();
            await _mediatorService.Send(new AddClientCommand(newGuid, input.FirstName, input.LastName,
                input.ContactNumber, input.EmailAddress));
            return new OkObjectResult(new {newGuid});
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateClientDto input)
        {
            await _mediatorService.Send(new UpdateClientCommand(input.ClientGuid, input.FirstName, input.LastName,
                input.ContactNumber, input.EmailAddress));
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediatorService.Send(new RemoveClientCommand(id));
            return new OkResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediatorService.Send(new GetClientByIdQuery(id));
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatorService.Send(new GetAllClientsQuery());
            return new OkObjectResult(result);
        }
    }
}