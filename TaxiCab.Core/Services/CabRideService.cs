using AutoClutch.Repo.Interfaces;
using TaxiCab.Core.Interfaces;
using TaxiCab.Core.Models;
using TaxiCab.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClutch.Core;

namespace TaxiCab.Core.Services
{
    public class CabRideService : Service<cabRide>, ICabRideService
    {
        private readonly IRepository<cabRide> _cabRideRepository;
        private IMeteredRateStrategyService _meteredRateStrategyService;

        public CabRideService(IRepository<cabRide> cabRideRepository, IMeteredRateStrategyService meteredRateStrategyService)
            : base(cabRideRepository)
        {
            _cabRideRepository = cabRideRepository;

            _meteredRateStrategyService = meteredRateStrategyService;
        }

        public double GetFare(cabRide cabRide, string loggedInUserName)
        {
            var result = _meteredRateStrategyService.ApplyRules(cabRide, loggedInUserName);

            return result;
        }

    }
}
