using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.ApplicationInsights
{
    public class ApplicationInsightsSettings
    {
        public const string SectionKey = "ApplicationInsights";

        public string CloudRoleName { get; set; }
        public string InstrumentationKey { get; set; }
    }
}
