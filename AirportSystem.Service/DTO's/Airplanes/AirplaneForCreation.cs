using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.DTO_s.Airplanes
{
    public class AirplaneForCreation
    {
        [Required(AllowEmptyStrings=false),MaxLength(64)]
        public string Name { get; set; }


        [Required(AllowEmptyStrings=false),MaxLength(32)]
        public string Country { get; set; }
        public long AirportId { get; set; }


        [Required(AllowEmptyStrings = false),MaxLength(64)]
        public string FromDestination { get; set; }


        [Required(AllowEmptyStrings = false),MaxLength(64)]
        public string ToDestination { get; set; }
    }
}
