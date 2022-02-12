
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Shared.Messages.Bus
{
    internal class RabbitMessageBus : IRabbitMessageBus
    {
        private IConnection _connection;
        private IModel _channel;

        public virtual async Task<bool> Publisher(Event evento)
        {
            try
            {
                var message = JsonSerializer.Serialize(evento);

                var body = Encoding.UTF8.GetBytes(message);

                _channel.BasicPublish(exchange: evento.MessageType,
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private void TryConnect()
        {
            if (_connection.IsOpen) return;
            
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var policy = Policy.Handle<RabbitMQ.Client.Exceptions.ConnectFailureException>()
                .Or<BrokerUnreachableException>()
                .CircuitBreaker(2, TimeSpan.FromMinutes(2));


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

        ~RabbitMessageBus()
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

