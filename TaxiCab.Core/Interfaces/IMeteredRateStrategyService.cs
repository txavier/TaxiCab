using System.Collections.Generic;
using AutoClutch.Core.Objects;
using TaxiCab.Core.Models;

namespace TaxiCab.Core.Interfaces
{
    public interface IMeteredRateStrategyService
    {
        double ApplyRules(cabRide cabRide, string loggedInUserName);
        IEnumerable<Error> GetErrors();
    }
}