using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;

namespace PF6_Team1_DotNetAssignment.ApplicationInsights
{
    public class CloudRoleTelemetryInitializer : ITelemetryInitializer
    {
        private readonly string MachineName = Environment.MachineName.ToLower();
        private readonly ApplicationInsightsSettings _applicationInsightsSettings;

        public CloudRoleTelemetryInitializer(ApplicationInsightsSettings applicationInsightsSettings)
        {
            _applicationInsightsSettings = applicationInsightsSettings;
        }

        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Cloud.RoleName = _applicationInsightsSettings.CloudRoleName;
            telemetry.Context.Cloud.RoleInstance = MachineName;
        }
    }
}
