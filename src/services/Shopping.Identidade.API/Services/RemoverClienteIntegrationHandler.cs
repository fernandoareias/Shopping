
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using Shopping.Identidade.API.Models.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Services
{
    public class RemoverClienteIntegrationHandler : BackgroundService, IDisposable
    {
        
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        public RemoverClienteIntegrationHandler(IServiceProvider serviceProvider)
        {
            TryConnect();
            
            _serviceProvider = serviceProvider;
        }

       
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TryConnect();

         
            _channel.QueueDeclare(queue: new UsuarioRemovidoIntegrationEvent().MessageType, durable: false, exclusive: false, autoDelete: true, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {

                var decoder = Encoding.UTF8.GetString(ea.Body.ToArray());

                var cliente = JsonSerializer.Deserialize<UsuarioRemovidoIntegrationEvent>(decoder);

                HandleMessage(cliente);
               
            };

            _channel.BasicConsume(queue: new UsuarioRemovidoIntegrationEvent().MessageType,
                                 autoAck: true,
                                 consumer: consumer);

            return Task.CompletedTask;
        }

        private async void HandleMessage(UsuarioRemovidoIntegrationEvent content)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                   
                    var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                    var usuario = await _userManager.FindByEmailAsync(content?.Email);
                    var result = await _userManager.DeleteAsync(usuario);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }


        private void TryConnect()
        {
            if (_connection.IsOpen) return;
            // get by appsettings
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var policy = Policy.Handle<RabbitMQ.Client.Exceptions.ConnectFailureException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                _connection = connectionFactory.CreateConnection();
                _channel = _connection.CreateModel();
                if (!_connection.IsOpen) OnDisconnect();
            });
        }

        private void OnDisconnect()
        {
            var policy = Policy.Handle<RabbitMQ.Client.Exceptions.ConnectFailureException>()
                .Or<BrokerUnreachableException>()
                .RetryForever();

            policy.Execute(TryConnect);
        }



        ~RemoverClienteIntegrationHandler()
        {
            Dispose();
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}
