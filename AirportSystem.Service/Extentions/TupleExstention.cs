using System;
using System.Collections.Generic;
using System.Linq;

namespace AirportSystem.Service.Extentions
{
    public static class TupleExstention
    {
        public static IEnumerable<TSourse> GetWithPagination<TSourse>(this IQueryable<TSourse> query, Tuple<int, int> pagination = null)
            where TSourse : class
        {
            if (pagination is null)
                return query.Take(10);  

            return query.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public static IEnumerable<TSourse> GetWithPagination<TSourse>(this IEnumerable<TSourse> query, Tuple<int, int> pagination = null)
            where TSourse : class
        {
            if (pagination is null)
                return query.Take(10);

            return query.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

    }
}