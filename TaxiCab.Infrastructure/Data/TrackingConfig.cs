﻿using AutoClutch.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCab.Core.Models;
using TrackerEnabledDbContext.Common.Extensions;

namespace TaxiCab.Infrastructure
{
    public class TrackingConfig
    {
        public static void SetTrackingProperties(DbModelBuilder modelBuilder)
        {
            //TrackerEnabledDbContext.Common.Configuration.GlobalTrackingConfig.SetSoftDeletableCriteria<ISoftDeletable>(entity => entity.IsDeleted);

            modelBuilder.Entity<user>().TrackAllProperties();

            modelBuilder.Entity<setting>().TrackAllProperties();
        }
    }
}
