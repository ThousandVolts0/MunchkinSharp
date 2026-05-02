using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Query
{
    public interface IQuery<TResult> where TResult : IQueryResult
    {
    }
}
