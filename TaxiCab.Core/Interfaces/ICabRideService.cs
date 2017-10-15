using AutoClutch.Core.Interfaces;
using TaxiCab.Core.Models;

namespace TaxiCab.Core.Interfaces
{
    public interface ICabRideService : IService<cabRide>
    {
        double GetFare(cabRide cabRide, string loggedInUserName);
    }
}