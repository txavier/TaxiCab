using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCab.Core.ViewModels
{
    public class LogDetail
    {
        public string NewValue { get; set; }
        public string OldValue { get; internal set; }
        public string PropertyName { get; set; }
    }
}
