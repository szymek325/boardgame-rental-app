using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;
using Rental.DataAccess.Handlers.ClientHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.ClientHandlers
{
    public class AddAndSaveClientNotificationHandlerTests
    {
        public AddAndSaveClientNotificationHandlerTests()
        {
            _rentalContext = new Mock<RentalContext>(MockBehavior.Strict);
            _clientsDbSetMock = new Mock<DbSet<Client>>();
            _rentalContext.Setup(x => x.Clients).Returns(_clientsDbSetMock.Object);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
            _sut = new AddAndSaveClientNotificationHandler(_mapper.Object, _rentalContext.Object);
        }

        private readonly Mock<DbSet<Client>> _clientsDbSetMock;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<RentalContext> _rentalContext;
        private readonly INotificationHandler<AddAndSaveClientNotification> _sut;

        [Fact]
        public async Task Handle_Should_AddClientToDb_When_MethodCalled()
        {
            var client = new Core.Models.Client("mat", "szym", "123456", "test@test.pl");
            var entity = new Client
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                ContactNumber = client.ContactNumber,
                EmailAddress = client.EmailAddress,
                CreationTime = client.CreationTime
            };
            var input = new AddAndSaveClientNotification(client);
            _mapper.Setup(x => x.Map<Client>(client)).Returns(entity);
            var cancellationToken = new CancellationToken();
            _clientsDbSetMock.Setup(x => x.AddAsync(entity, cancellationToken));
            _rentalContext.Setup(x => x.SaveChangesAsync(cancellationToken));

            await _sut.Handle(input, cancellationToken);

            _rentalContext.Verify(x => x.Clients.AddAsync(entity, cancellationToken), Times.Once);
            _rentalContext.Verify(x => x.SaveChangesAsync(cancellationToken), Times.Once);
        }
    }
}