using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiCab.Core.Models
{
    [Table("cabRide")]
    public partial class cabRide
    {
        public int cabRideId { get; set; }

        public int? minutesAboveSixMph { get; set; }

        public int? milesBelowSixMph { get; set; }

        public DateTime dateTime { get; set; }
    }
}