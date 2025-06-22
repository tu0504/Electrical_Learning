using ElectricalLearning.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Repositories.Interceptors
{
    public class UpdateAuditableInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;
            if (dbContext == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<IAuditable>> entities = dbContext.ChangeTracker.Entries<IAuditable>();

            foreach (EntityEntry<IAuditable> entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTimeOffset.UtcNow;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
