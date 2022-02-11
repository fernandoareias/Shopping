
using Polly;
using RabbitMQ.Client.Exceptions;
using Shopping.Cliente.API.Shared.Integration;
using System;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Shared.Messages.Bus
{
    public class MessageBus : IMessageBus
    {
        public bool IsConnected => throw new NotImplementedException();

        

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Publish<T>(T message) where T : IntegrationEvent
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(T message) where T : IntegrationEvent
        {
            throw new NotImplementedException();
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            throw new NotImplementedException();
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            throw new NotImplementedException();
        }

        public Task<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            throw new NotImplementedException();
        }
    }
}

