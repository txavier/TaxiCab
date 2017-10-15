using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoClutch.Core.Interfaces;
using AutoClutch.Controller;
using TaxiCab.Core.Models;
using System.Web.OData.Routing;
using TaxiCab.Core.Interfaces;
using System.Web.OData;

namespace TaxiCab.Controllers
{
    public class cabRidesController : ApiController
    { 
        private ICabRideService _cabRideService;

        public cabRidesController(ICabRideService cabRideService)
        {
            _cabRideService = cabRideService;
        }

        [HttpPost]
        public double GetFare(cabRide cabRide)
        {
            var result = _cabRideService.GetFare(cabRide, User?.Identity?.Name);

            return result;
        }
    }
}