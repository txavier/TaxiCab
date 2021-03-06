﻿using AutoClutch.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCab.Core.Interfaces;
using TaxiCab.Core.Models;

namespace TaxiCab.Core.Services
{
    public class MeteredStrategyOneFifthLessThanSixRule : IMeteredStrategyRule
    {
        private ISettingService _settingService;

        public IEnumerable<Error> Errors { get; set; }

        public MeteredStrategyOneFifthLessThanSixRule(ISettingService settingService)
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

            var result = (cabRide.milesBelowSixMph * 5) * fareUnit;

            return result.Value;
        }

        public bool IsMatch(cabRide cabRide, string loggedInUserName)
        {
            if(cabRide.milesBelowSixMph.HasValue)
            {
                return true;
            }

            return false;
        }
    }
}
