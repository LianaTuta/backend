using Microsoft.EntityFrameworkCore;

namespace TicketService.Migrations.Extensions
{
    public static class Extensions
    {
        public static void ApplySequence<TEntity>(this ModelBuilder modelBuilder, string sequenceName, string propertyName)
            where TEntity : class
        {
            _ = modelBuilder.HasSequence<int>(sequenceName)
               .StartsAt(1)
               .IncrementsBy(1);

            _ = modelBuilder.Entity<TEntity>()
                .Property<int>(propertyName)
                .HasDefaultValueSql($"NEXT VALUE FOR {sequenceName}");
        }
    }
}
