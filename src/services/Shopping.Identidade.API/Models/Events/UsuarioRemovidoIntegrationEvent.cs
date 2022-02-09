using Shopping.Identidade.API.Shared.Integration;
using System;

namespace Shopping.Identidade.API.Models.Events
{
    public class UsuarioRemovidoIntegrationEvent : IntegrationEvent
    {

        public UsuarioRemovidoIntegrationEvent()
        {

        }
        public UsuarioRemovidoIntegrationEvent(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public Guid Id { get;  set; }
        public string Email { get; set; }
    }
}
