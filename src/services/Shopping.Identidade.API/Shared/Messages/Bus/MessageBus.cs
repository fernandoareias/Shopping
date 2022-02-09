
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using Shopping.Identidade.API.Shared.Integration;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Shared.Messages.Bus
{
    public class MessageBus : IMessageBus
    {
        public MessageBus()
        {

        }

        public MessageBus(string connection)
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

