using AirportSystem.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.Extentions
{
    public static class Collection
    {
        public static IEnumerable<T> ToPaged<T>(this IEnumerable<T> source, PaginationParams @params)
        {
            return @params.PageSize >= 0 && @params.PageIndex >= 0
                   ? source.Skip((@params.PageSize - 1) * @params.PageIndex).Take(@params.PageSize) : source;
        }

    }
}
