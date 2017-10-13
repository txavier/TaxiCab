using System.Collections.Generic;
using AutoClutch.Core.Objects;
using TaxiCab.Core.Models;

namespace TaxiCab.Core.Interfaces
{
    public interface IMeteredStrategyRule
    {
        IEnumerable<Error> Errors { get; set; }

        double ApplyRule(cabRide cabRide, string loggedInUserName);
        IEnumerable<Error> GetErrors();
        bool IsMatch(cabRide cabRide, string loggedInUserName);
    }
}