using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsGenerator.Models
{
    public class FlightDto
    {
        public string? Code { get; set; }
        public bool IsDeparture { get; set; }
        public string Status { get; set; }

        public FlightDto()
        {
            Code = Guid.NewGuid().ToString().Substring(0, 6);
            IsDeparture = false;
            Status = "Landing";
        }
    }
}
