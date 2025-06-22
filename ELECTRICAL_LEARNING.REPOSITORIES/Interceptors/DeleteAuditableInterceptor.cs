using ElectricalLearning.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Repositories.Interceptors
{
    public class DeleteAuditableInterceptor : SaveChangesInterceptor
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

            IEnumerable<EntityEntry> entities = dbContext.ChangeTracker.Entries();

            foreach (EntityEntry entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Deleted)
                {
                    var entity = entityEntry.Entity;
                    var isDeletedProp = entity.GetType().GetProperty("IsDeleted");
                    var updatedAtProp = entity.GetType().GetProperty("UpdatedAt");
                    if(isDeletedProp != null && isDeletedProp.CanWrite && updatedAtProp != null && updatedAtProp.CanWrite)
                    {
                        entityEntry.State = EntityState.Modified;
                        isDeletedProp.SetValue(entity, true);
                        updatedAtProp.SetValue(entity, DateTimeOffset.UtcNow);
                    }
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
