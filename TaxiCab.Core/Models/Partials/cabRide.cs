using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCab.Core.Models
{
    [MetadataType(typeof(cabRideMetaData))]
    public partial class cabRide
    {
        private class cabRideMetaData
        {
            [DisplayName("minutes above 6 MPH")]
            public int minutesAboveSixMph { get; set; }

            [DisplayName("miles below 6 MPH")]
            public int milesBelowSixMph { get; set; }

            [DisplayName("date")]
            public DateTime dateTime { get; set; }
        }
    }
}
