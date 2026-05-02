using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand,TResult> where TCommand : ICommand<TResult> where TResult : ICommandResult
    {
        TResult Handle(TCommand command);
    }
}
