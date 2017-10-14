using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiCab.DependencyResolution;
using TaxiCab.Core.Interfaces;
using TaxiCab.Core.Models;

namespace TaxiCab.IntegrationTests
{
    [TestClass()]
    public class MeteredRateStrategyService_ApplyRulesShould
    {
        [TestMethod()]
        public void ReturnTheCorrectFareIfInNewYorkAndOnlyEnteredCab()
        {
            // Arrange.
            var container = IoC.Initialize();

            var meteredRateStrategyService = container.GetInstance<IMeteredRateStrategyService>();

            var cabRide = new cabRide();

            // Act.
            var result = meteredRateStrategyService.ApplyRules(cabRide, "User1");

            // Assert.
            Assert.IsTrue(result == 3.5);
        }

        [TestMethod()]
        public void ReturnTheCorrectFareForGuggScenario()
        {
            // Arrange.
            var container = IoC.Initialize();

            var meteredRateStrategyService = container.GetInstance<IMeteredRateStrategyService>();

            var cabRide = new cabRide()
            {
                dateTime = DateTime.Parse("10-8-2010 5:30pm"),
                milesBelowSixMph = 2,
                minutesAboveSixMph = 5
            };

            // Act.
            var result = meteredRateStrategyService.ApplyRules(cabRide, "User1");

            // Assert.
            Assert.IsTrue(result == 9.75);
        }
    }
}
