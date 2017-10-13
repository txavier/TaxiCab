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
        public void ReturnTheCorrectFare()
        {
            // Arrange.
            var container = IoC.Initialize();

            var meteredRateStrategyService = container.GetInstance<IMeteredRateStrategyService>();

            var cabRide = new cabRide
            {

            };

            // Act.
            var result = meteredRateStrategyService.ApplyRules(cabRide, "User1");

            // Assert.
            Assert.IsTrue(result > 0);
        }
    }
}
