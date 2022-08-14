using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Domain.Configurations
{
    public class PaginationData
    {
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public bool HasPrivious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalCount;

        public PaginationData(int totalCout, PaginationParams @params)
        {
            CurrentPage = @params.PageIndex;
            TotalCount = totalCout;

            TotalPage = (int)Math.Ceiling(totalCout / (double)@params.PageSize);
        }

    }
}
