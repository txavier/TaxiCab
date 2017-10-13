using AutoClutch.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCab.Core.Interfaces;
using TaxiCab.Core.Models;

namespace TaxiCab.Core.Services
{
    public class MeteredStrategyNightRule : IMeteredStrategyRule
    {
        private ISettingService _settingService;

        public IEnumerable<Error> Errors { get; set; }

        public MeteredStrategyNightRule(ISettingService settingService)
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

            var nightSurcharge = double.TryParse(_settingService.GetSettingValueBySettingKey("nightSurcharge"), out dummyHolder) ? dummyHolder : .50;

            return nightSurcharge;
        }

        public bool IsMatch(cabRide cabRide, string loggedInUserName)
        {
            if (cabRide.dateTime.TimeOfDay.Hours > 20
                && cabRide.dateTime.TimeOfDay.Hours < 6)
            {
                return true;
            }

            return false;
        }
    }
}
