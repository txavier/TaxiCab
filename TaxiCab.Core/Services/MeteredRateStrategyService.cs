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
    public class MeteredRateStrategyService : IMeteredRateStrategyService
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
            // Use strategy pattern to implement fare calculations rules.
            var result = _meteredStrategyRules.Sum(r => r.IsMatch(cabRide, loggedInUserName) ? r.ApplyRule(cabRide, loggedInUserName) : 0);

            // Get the fare upon entry and add it to te calculated sum.
            double dummyHolder;

            var fareUponEntry = double.TryParse(_settingService.GetSettingValueBySettingKey("fareUponEntry"), out dummyHolder) ? dummyHolder : 3;

            result = result + fareUponEntry;

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
