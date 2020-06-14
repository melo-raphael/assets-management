using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using projeto.tcc.order.managament.data.Mappings.DataBase;
using projeto.tcc.order.managament.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Assets> User { get; set; }
        //private IDbContextTransaction _currentTransaction;
        //public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        //public bool HasActiveTransaction => _currentTransaction != null;
        private readonly IMediator _mediator;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)  
            => options.UseNpgsql("Server=database-2.crrtyjh5anqo.sa-east-1.rds.amazonaws.com;Port=5432;Database=tcc_orders;User Id=postgres;Password=polivel12;",
                        // => options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"),
                        npgsqlOptionsAction: pgOptions =>
                        {
                            pgOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssetsMap());
            modelBuilder.ApplyConfiguration(new AssetsSegmentMap());
            modelBuilder.ApplyConfiguration(new OrderTypeMap());
            modelBuilder.ApplyConfiguration(new OrderActiveMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            return await base.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
