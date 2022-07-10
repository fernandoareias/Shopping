using Microsoft.EntityFrameworkCore;
using Shopping.Core.Data;
using Shopping.Core.DomainObjects;
using Shopping.Core.Mediator;
using Shopping.Core.Resources.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Data
{
    public class ClientesContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public ClientesContext(DbContextOptions<ClientesContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var prop in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                prop.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientesContext).Assembly);
        }

        public DbSet<Shopping.Cliente.API.Models.Cliente> Cliente { get; set; }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            if (sucesso) 
                await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }

    

}
