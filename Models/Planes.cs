using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Meridian_Line_Travel.Models
{
    // Headings for Aircraft data used with PlaneController and Planes views to make table with database data
    public class Planes
    {
        [Key]
        public string PlaneID { get; set; }
        public string IDName { get; set; }
        public int PlaneIDNum { get; set; }
        public int SeatingCapacity { get; set; }
        public string Assignment { get; set; }
        public string AoO { get; set; }
        public string AoD { get; set; }
        public string FlightID { get; set; }
        public int FlightIDNum { get; set; }
        public string Type { get; set; }
        public string PlaneName { get; set; }
        public Planes()
        {

        }
    }
}
