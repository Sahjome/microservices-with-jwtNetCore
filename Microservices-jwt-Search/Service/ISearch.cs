using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices_jwt_Search.Service
{
    public interface ISearch<TEntity>
    {
        //what actions do we want to carry out as a method
        //for search it is just a get with string arg

        IQueryable GetEntity(string entityName);
    }
}
