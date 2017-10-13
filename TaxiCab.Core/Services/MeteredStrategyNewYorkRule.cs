using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClutch.Core.Objects;
using TaxiCab.Core.Models;
using TaxiCab.Core.Interfaces;

namespace TaxiCab.Core.Services
{
    public class MeteredStrategyNewYorkRule : IMeteredStrategyRule
    {
        private ISettingService _settingService;

        public IEnumerable<Error> Errors { get; set; }

        public MeteredStrategyNewYorkRule(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IEnumerable<Error> GetErrors()
        {
            return Errors;
        }

        public double ApplyRule(cabRide cabRide, string loggedInUserName)
        {
            double dummyHolder;

            var newYorkStateSurcharge = double.TryParse(_settingService.GetSettingValueBySettingKey("newYorkStateSurcharge"), out dummyHolder) ? dummyHolder : .50;

            return newYorkStateSurcharge;
        }

        public bool IsMatch(cabRide cabRide, string loggedInUserName)
        {
            var state = _settingService.GetSettingValueBySettingKey("state") ?? "NY";

            if(state == "NY" || state == "New York")
            {
                return true;
            }

            return false;
        }
    }
}
