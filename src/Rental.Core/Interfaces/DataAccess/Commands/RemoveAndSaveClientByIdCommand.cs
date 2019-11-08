﻿using System;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveClientByIdCommand : ICommand
    {
        public RemoveAndSaveClientByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}