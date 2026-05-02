using Munchkin.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Commands
{
    public interface ICommand
    {

    }

    public interface ICommand<TResult> where TResult : ICommandResult
    {

    }
}
