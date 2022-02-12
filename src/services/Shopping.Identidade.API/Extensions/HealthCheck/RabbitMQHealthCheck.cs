using Microsoft.Extensions.Diagnostics.HealthChecks;
using RabbitMQ.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Extensions.HealthCheck
{
    public class RabbitMQHealthCheck : IHealthCheck
    {


        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var connectionFactory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };

                using (var connection = connectionFactory.CreateConnection())
                {

                    return connection.IsOpen ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
                }
            }
            catch (System.Exception)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
