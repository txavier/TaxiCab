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
    public class MeteredStrategyPeakHourRule : IMeteredStrategyRule
    {
        private ISettingService _settingService;

        public IEnumerable<Error> Errors { get; set; }

        public MeteredStrategyPeakHourRule(ISettingService settingService)
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

            var peakHourSurcharge = double.TryParse(_settingService.GetSettingValueBySettingKey("peakHourSurcharge"), out dummyHolder) ? dummyHolder : 1;

            return peakHourSurcharge;
        }

        public bool IsMatch(cabRide cabRide, string loggedInUserName)
        {
            if (cabRide.dateTime.DayOfWeek != DayOfWeek.Saturday 
                && cabRide.dateTime.DayOfWeek != DayOfWeek.Sunday
                && cabRide.dateTime.TimeOfDay.Hours > 16
                && cabRide.dateTime.TimeOfDay.Hours < 20)
            {
                return true;
            }

            return false;
        }
    }
}
