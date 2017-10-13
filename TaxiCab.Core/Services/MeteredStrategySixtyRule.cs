using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClutch.Core.Objects;
using TaxiCab.Core.Interfaces;
using TaxiCab.Core.Models;

namespace TaxiCab.Core.Services
{
    public class MeteredStrategySixtyRule : IMeteredStrategyRule
    {
        private ISettingService _settingService;

        public IEnumerable<Error> Errors { get; set; }

        public MeteredStrategySixtyRule(ISettingService settingService)
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

            var fareUnit = double.TryParse(_settingService.GetSettingValueBySettingKey("fareUnit"), out dummyHolder) ? dummyHolder : 0.35;

            var result = cabRide.minutesAboveSixMph * fareUnit;

            return result.Value;
        }

        public bool IsMatch(cabRide cabRide, string loggedInUserName)
        {
            if(cabRide.minutesAboveSixMph.HasValue)
            {
                return true;
            }

            return false;
        }
    }
}
