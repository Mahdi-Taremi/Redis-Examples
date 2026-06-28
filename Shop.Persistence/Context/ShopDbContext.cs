using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Context
{
    public class ShopDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTimeProvider _dateTime;

        private readonly ICurrentUserService _currentUser;
        public ShopDbContext(DbContextOptions<ShopDbContext> options, IDateTimeProvider dateTime, ICurrentUserService currentUser) : base(options)
        {
            _dateTime = dateTime;
            _currentUser = currentUser;
        }
        // ReView 
        protected override void OnModelCreating(
         ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ShopDbContext).Assembly);
        }
        // SaveChangesAsync
        public override async Task<int> SaveChangesAsync(
       CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.CreatedAt = _dateTime.UtcNow;

                        entry.Entity.CreatedBy = _currentUser.UserId;

                        break;

                    case EntityState.Modified:

                        entry.Entity.LastModifiedAt = _dateTime.UtcNow;

                        entry.Entity.LastModifiedBy = _currentUser.UserId;

                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Product> Products => Set<Product>();
    }
}
