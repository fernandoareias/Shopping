using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.Data;
using Shopping.Core.Mediator;
using Shopping.Core.Messages;
using Shopping.Core.Resources.Extensions;
using Shopping.Pedido.Domain.Vouchers;
using System.Linq;
using System.Threading.Tasks;


namespace Shopping.Pedido.Infra.Data
{
    public class PedidoContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;

        public PedidoContext(DbContextOptions<PedidoContext> options,IMediatorHandler mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Pedido.Domain.Pedidos.Pedido> Pedidos { get; set; }
        public DbSet<Pedido.Domain.Pedidos.PedidoItem> PedidoItems { get; set; }
        public DbSet<Voucher> Voucher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var prop in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                prop.SetColumnType("varchar(100)");


            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<ValidationResult>();


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoContext).Assembly);


            foreach (var prop in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
                prop.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);

            base.OnModelCreating(modelBuilder);

        }


        public async Task<bool> Commit()
        {

            foreach(var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = System.DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            var sucesso = await base.SaveChangesAsync() > 0;

            if (sucesso)
                await _mediator.PublicarEventos(this);

            return sucesso;
        }
    }
}
