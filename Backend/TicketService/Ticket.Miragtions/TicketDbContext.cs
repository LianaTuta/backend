using Microsoft.EntityFrameworkCore;
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
        
        modelBuilder.Entity<UserModelEF>().ToTable("Users");
        modelBuilder.Entity<UserModelEF>()
           .HasOne(u => u.UserRole)
           .WithMany()
           .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<UserModelEF>().Property(u => u.RoleId).HasColumnName("RoleId");
        modelBuilder.Entity<UserRolesModelEF>().ToTable("UserRoles");

        modelBuilder.HasSequence<int>("UserIdSeq") 
           .StartsAt(1) 
           .IncrementsBy(1);  

        modelBuilder.Entity<UserModelEF>()
            .Property(u => u.Id)
            .HasDefaultValueSql("NEXT VALUE FOR UserIdSeq");  

      
        modelBuilder.HasSequence<int>("RoleIdSeq")
            .StartsAt(1)  
            .IncrementsBy(1); 

        modelBuilder.Entity<UserRolesModelEF>()
            .Property(ur => ur.Id)
            .HasDefaultValueSql("NEXT VALUE FOR RoleIdSeq");

        modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 1, Name = "Manager" });
        modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 2, Name = "Customer" });
        base.OnModelCreating(modelBuilder);
    }
}