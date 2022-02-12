
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
        private bool IsConnected;

        public RemoverClienteIntegrationHandler(IServiceProvider serviceProvider)
        {
            
            _serviceProvider = serviceProvider;
        }


     
       
        protected async override Task<Task> ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            TryConnect();
            try
            {

                if (IsConnected)
                {
                    _channel?.QueueDeclare(queue: new UsuarioRemovidoIntegrationEvent().MessageType, durable: false, exclusive: false, autoDelete: true, arguments: null);

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

                }

            }
            catch (Exception)
            {
                TryConnect();
            }

            return await Task.FromResult(Task.CompletedTask);
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


        private Task TryConnect()
        {
            if (_connection != null && _connection.IsOpen) return Task.CompletedTask;
            
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var policy = Policy.Handle<BrokerUnreachableException>().Or<Exception>()
                .WaitAndRetry(retryCount: 2, sleepDurationProvider:retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            try
            {
                policy.Execute(() =>
                {
                    _connection = connectionFactory.CreateConnection();
                    IsConnected = _connection.IsOpen;
                    _channel = _connection?.CreateModel();

                    if (!IsConnected) OnDisconnect();

                });
            }
            catch (Exception)
            {
                if (!IsConnected) OnDisconnect();
            }

            return Task.CompletedTask;
        }

        private async void  OnDisconnect()
        {
            var policy = Policy.Handle<RabbitMQ.Client.Exceptions.ConnectFailureException>()
                .Or<BrokerUnreachableException>()
                .RetryForeverAsync();

            await policy.ExecuteAsync(TryConnect);
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
