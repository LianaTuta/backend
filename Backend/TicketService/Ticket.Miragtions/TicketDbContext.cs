using Microsoft.EntityFrameworkCore;
using TicketService.Migrations.Models;
using TicketService.Models;


public class TicketDbContext : DbContext
{
    public DbSet<UserModelEF> Users { get; set; }
    public DbSet<UserRolesModelEF> UserRoles { get; set; }
    public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        _ = modelBuilder.Entity<UserModelEF>().ToTable("Users");
        _ = modelBuilder.Entity<UserModelEF>()
           .HasOne(u => u.UserRole)
           .WithMany()
           .HasForeignKey(u => u.RoleId);

        _ = modelBuilder.Entity<UserModelEF>().Property(u => u.RoleId).HasColumnName("RoleId");
        _ = modelBuilder.Entity<UserRolesModelEF>().ToTable("UserRoles");

        _ = modelBuilder.HasSequence<int>("UserIdSeq")
           .StartsAt(1)
           .IncrementsBy(1);

        _ = modelBuilder.Entity<UserModelEF>()
            .Property(u => u.Id)
            .HasDefaultValueSql("NEXT VALUE FOR UserIdSeq");


        _ = modelBuilder.HasSequence<int>("RoleIdSeq")
            .StartsAt(1)
            .IncrementsBy(1);

        _ = modelBuilder.Entity<UserRolesModelEF>()
            .Property(ur => ur.Id)
            .HasDefaultValueSql("NEXT VALUE FOR RoleIdSeq");

        _ = modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 1, Name = "Manager" });
        _ = modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 2, Name = "Customer" });
        base.OnModelCreating(modelBuilder);
    }
}