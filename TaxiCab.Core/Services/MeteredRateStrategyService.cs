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
    public class MeteredRateStrategyService
    {
        private List<IMeteredStrategyRule> _meteredStrategyRules;

        private ISettingService _settingService;

        private List<Error> _errorList { get; set; }

        public MeteredRateStrategyService(ISettingService settingService)
        {
            _settingService = settingService;

            _meteredStrategyRules = new List<IMeteredStrategyRule>();

            _meteredStrategyRules.Add(new MeteredStrategyOneFifthLessThanSixRule(_settingService));

            _meteredStrategyRules.Add(new MeteredStrategyNewYorkRule(_settingService));

            _meteredStrategyRules.Add(new MeteredStrategyNightRule(_settingService));

            _meteredStrategyRules.Add(new MeteredStrategyPeakHourRule(_settingService));

            _meteredStrategyRules.Add(new MeteredStrategySixtyRule(_settingService));
        }

        public double ApplyRules(cabRide cabRide, string loggedInUserName)
        {
            var result = _meteredStrategyRules.Sum(r => r.IsMatch(cabRide, loggedInUserName) ? r.ApplyRule(cabRide, loggedInUserName) : 0);

            return result;
        }

        public IEnumerable<Error> GetErrors()
        {
            foreach (var meteredStrategyRules in _meteredStrategyRules)
            {
                _errorList.AddRange(meteredStrategyRules.GetErrors());
            }

            return _errorList;
        }
    }
}
