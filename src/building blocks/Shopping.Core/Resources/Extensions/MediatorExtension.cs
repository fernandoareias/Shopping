using Microsoft.EntityFrameworkCore;
using Shopping.Core.DomainObjects;
using Shopping.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.Resources.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx
                .ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.Notificacoes).ToList();

            domainEntities.ToList().ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents.Select(async (domainEvent) => {
                await mediator.PublicarEvento(domainEvent);
            });

            await Task.WhenAll(tasks);
        }
    }
}
