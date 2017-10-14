using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap.AutoMocking.Moq;
using TaxiCab.Core.Services;

namespace TaxiCab.UnitTests
{
    [TestClass()]
    public class MeteredStrategyOneFifthLessThanSixRule_ApplyRulesShould
    {
        [TestMethod()]
        public void ReturnThreeDollarsFiftyCentsIfTravelingTwoMilesAtLessThanSixMph()
        {
            // Arrange.

            // Get an instance of the service.
            var autoMocker = new MoqAutoMocker<MeteredStrategyOneFifthLessThanSixRule>();

            var MeteredStrategyOneFifthLessThanSixRule = autoMocker.ClassUnderTest;

            // Creating a test cab ride object.
            var cabRide = new Core.Models.cabRide
            {
                milesBelowSixMph = 2
            };

            // Act.
            var result = MeteredStrategyOneFifthLessThanSixRule.ApplyRule(cabRide, "User1");

            // Assert.
            Assert.AreEqual(result, 3.5);

        }
    }
}
