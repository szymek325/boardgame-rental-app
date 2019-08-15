﻿using System;
using MediatR;

namespace Rental.Core.Requests.BoardGames
{
    public class RemoveBoardGameRequest : IRequest
    {
        public RemoveBoardGameRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}