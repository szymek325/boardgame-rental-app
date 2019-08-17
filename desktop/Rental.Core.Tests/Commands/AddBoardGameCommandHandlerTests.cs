using Moq;
using Rental.Core.Commands;
using Rental.Core.Commands.Handlers;
using Rental.CQRS;

namespace Rental.Core.Tests.Commands
{
    public class AddBoardGameCommandHandlerTests
    {
        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<AddBoardGameCommand> _sut;

        public AddBoardGameCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>();
            _sut = new AddBoardGameCommandHandler(_mediatorService.Object);
        }
    }
}