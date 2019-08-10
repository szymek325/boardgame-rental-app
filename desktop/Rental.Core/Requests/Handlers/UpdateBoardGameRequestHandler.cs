using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Handlers
{
    internal class UpdateBoardGameRequestHandler : IRequestHandler<UpdateBoardGameRequest, string>
    {
        private readonly IMediatorService _mediatorService;

        public UpdateBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<string> Handle(UpdateBoardGameRequest request, CancellationToken cancellationToken)
        {
            var boardGame = await _mediatorService.Request(new GetBoardGameByIdRequest(request.Id), cancellationToken);
            boardGame.Name = request.Name;
            boardGame.Price = request.Price;
            var validator = new UpdateBoardGameValidator();
            var validationResult = validator.Validate(boardGame);

            if (validationResult.IsValid)
            {
                await _mediatorService.Notify(new UpdateAndSaveBoardGameNotification(boardGame), cancellationToken);
                return $"BoardGame {boardGame.Id} was successfully updated";
            }

            var builder = new StringBuilder();
            foreach (var validationFailure in validationResult.Errors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            Trace.WriteLine(builder.ToString());
            return $"BoardGame {boardGame.Id} was not successfully updated";
        }
    }
}