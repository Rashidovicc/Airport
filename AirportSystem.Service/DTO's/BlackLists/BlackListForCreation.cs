using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.DTO_s.BlackLists
{
    public class BlackListForCreation
    {
        [Required]
        public DateTime Duration { get; set; }
        
        [Required]
        public long PassengerId { get; set; }

    }
}
