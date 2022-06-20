using Microsoft.EntityFrameworkCore;
using Shopping.Core.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Data
{
    public class ClientesContext : DbContext, IUnitOfWork
    {

        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
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
            return await base.SaveChangesAsync() > 0;
        }
    }
}
