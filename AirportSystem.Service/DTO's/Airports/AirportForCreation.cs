using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.DTO_s.Airports
{
    public class AirportForCreation
    {
        [Required(AllowEmptyStrings = false), MaxLength(64)]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }
        public long EmployeeId { get; set; }
        public long RouleTableId { get; set; }
        public long AirplaneId { get; set; }

    }
}
