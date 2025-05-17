using Microsoft.EntityFrameworkCore;
using TicketService.Migrations.Models;
using TicketService.Migrations.Models.Events;
using TicketService.Migrations.Models.Order;
using TicketService.Migrations.Models.User;


public class TicketDbContext : DbContext
{
    public DbSet<UserModelEF> Users { get; set; }
    public DbSet<UserRolesModelEF> UserRoles { get; set; }
    public DbSet<EventTypeEFModel> EventType { get; set; }
    public DbSet<EventEFModel> Event { get; set; }
    public DbSet<EventDetailsEFModel> EventDetails { get; set; }
    public DbSet<OrderEFModel> Order { get; set; }
    public DbSet<ArtistEFModel> Artist { get; set; }
    public DbSet<ArtistScheduleEFModel> ArtistSchedule { get; set; }
    public DbSet<EventScheduleEFModel> EventSchedule { get; set; }
    public DbSet<TicketCategoryEFModel> TicketCategory { get; set; }
    public DbSet<TicketEFModel> Ticket { get; set; }
    public DbSet<TicketPriceEFModel> TicketPrice { get; set; }
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
        _ = modelBuilder.Entity<UserModelEF>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<UserRolesModelEF>().ToTable("UserRoles");


        _ = modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 1, Name = "Manager" });
        _ = modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 2, Name = "Customer" });

        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 1, Name = "Festival" });
        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 2, Name = "Theatre" });
        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 3, Name = "Party" });
        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 4, Name = "Show" });
        base.OnModelCreating(modelBuilder);
    }


}