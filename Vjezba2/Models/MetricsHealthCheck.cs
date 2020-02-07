using Metrics;
using Metrics.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Vjezba2.Models
{
    public class MetricsHealthCheck : HealthCheck
    {

        private readonly string url;

        public MetricsHealthCheck(String url) : base("randomApiCheck")
        {
            this.url = url;
        }

        protected override HealthCheckResult Check()
        {
            WebClient client = new WebClient();
            var content = client.DownloadString(url);
            int number = int.Parse(content);
            if (number < 50)
            {
                return HealthCheckResult.Healthy("broj je manji od 50: " + number);
            }
            else
            {
                return HealthCheckResult.Unhealthy("broj je veci od 50: " + number);
            }
        }

    }
}
