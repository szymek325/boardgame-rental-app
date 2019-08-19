﻿using Rental.Core.Models.BoardGames;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveBoardGameCommand : ICommand
    {
        public RemoveAndSaveBoardGameCommand(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; set; }
    }
}