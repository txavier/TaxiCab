using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClutch.Core.Objects;
using TaxiCab.Core.Models;

namespace TaxiCab.Core.Services
{
    class MeteredStrategyNewYorkRule : IMeteredStrategyRule
    {
        public IEnumerable<Error> Errors
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double ApplyRule(cabRide cabRide, string loggedInUserName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Error> GetErrors()
        {
            throw new NotImplementedException();
        }

        public bool IsMatch(cabRide cabRide, string loggedInUserName)
        {
            throw new NotImplementedException();
        }
    }
}
