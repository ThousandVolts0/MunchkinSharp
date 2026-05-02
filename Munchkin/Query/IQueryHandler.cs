using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Query
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult> where TResult : IQueryResult
    {
        TResult Handle(TQuery query);
    }
}
