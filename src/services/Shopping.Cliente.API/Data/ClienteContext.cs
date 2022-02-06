using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Shopping.Cliente.API.Configurations.Extensions;
using Shopping.Cliente.API.Models;
using Shopping.Cliente.API.Models.VOs;
using Shopping.Cliente.API.Shared.Interfaces;
using Shopping.Cliente.API.Shared.Mediator;
using Shopping.Cliente.API.Shared.Messages;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Data
{
    public class ClienteContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClienteContext(DbContextOptions<ClienteContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteContext).Assembly);
        }



        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}
