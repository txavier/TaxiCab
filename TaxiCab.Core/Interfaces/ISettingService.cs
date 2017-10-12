using AutoClutch.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCab.Core.Interfaces
{
    public interface ISettingService : IService<TaxiCab.Core.Models.setting>
    {
        string GetSettingValueBySettingKey(string settingKey);
    }
}
