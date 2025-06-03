using Microsoft.EntityFrameworkCore;
using TicketService.Migrations.Models.Events;
using TicketService.Migrations.Models.Order;
using TicketService.Migrations.Models.Transactions;
using TicketService.Migrations.Models.User;


public class TicketDbContext : DbContext
{
    public DbSet<UserModelEF> users { get; set; }
    public DbSet<UserRolesModelEF> user_roles { get; set; }
    public DbSet<EventTypeEFModel> event_type { get; set; }
    public DbSet<EventEFModel> events { get; set; }
    public DbSet<EventDetailsEFModel> event_details { get; set; }
    public DbSet<CheckoutOrderEFModel> checkout_order { get; set; }
    public DbSet<TicketOrderEFModel> ticket_order { get; set; }
    public DbSet<ArtistEFModel> artist { get; set; }
    public DbSet<ArtistScheduleEFModel> artist_schedule { get; set; }
    public DbSet<EventScheduleEFModel> event_schedule { get; set; }
    public DbSet<TicketCategoryEFModel> ticket_category { get; set; }
    public DbSet<TicketEFModel> ticket { get; set; }

    public DbSet<PaymentsEFModel> payment { get; set; }
    public DbSet<TicketOrderPaymenrEfModel> ticket_order_payment { get; set; }

    public DbSet<QrTicketEFModel> qr_ticket { get; set; }
    public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        _ = modelBuilder.Entity<UserModelEF>().ToTable("users");
        _ = modelBuilder.Entity<UserModelEF>()
           .HasOne(u => u.UserRole)
           .WithMany()
           .HasForeignKey(u => u.RoleId);

        _ = modelBuilder.Entity<UserModelEF>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<UserRolesModelEF>().ToTable("user_roles");

        _ = modelBuilder.Entity<EventTypeEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        _ = modelBuilder.Entity<EventEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<EventDetailsEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<CheckoutOrderEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<TicketOrderEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<ArtistEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        _ = modelBuilder.Entity<ArtistScheduleEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<EventScheduleEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<TicketCategoryEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        _ = modelBuilder.Entity<TicketEFModel>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();


        _ = modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 1, Name = "Manager" });
        _ = modelBuilder.Entity<UserRolesModelEF>().HasData(new UserRolesModelEF() { Id = 2, Name = "Customer" });

        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 1, Name = "Festival" });
        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 2, Name = "Theatre" });
        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 3, Name = "Party" });
        _ = modelBuilder.Entity<EventTypeEFModel>().HasData(new EventTypeEFModel() { Id = 4, Name = "Show" });

        _ = modelBuilder.Entity<CheckoutOrderEFModel>()
                    .Property(t => t.Order)
                    .HasColumnType("jsonb");

        _ = modelBuilder.Entity<PaymentsEFModel>()
                  .Property(t => t.Request)
                  .HasColumnType("jsonb");

        _ = modelBuilder.Entity<PaymentsEFModel>()
                  .Property(t => t.Response)
                  .HasColumnType("jsonb");

        _ = modelBuilder.Entity<CheckoutOrderEFModel>()
         .HasOne(u => u.UserModel)
         .WithMany()
         .HasForeignKey(u => u.UserId);

        _ = modelBuilder.Entity<TicketOrderEFModel>()
       .HasOne(u => u.Ticket)
       .WithMany()
       .HasForeignKey(u => u.TicketId);

        _ = modelBuilder.Entity<PaymentsEFModel>()
                .HasOne(u => u.UserModel)
                .WithMany()
                .HasForeignKey(u => u.UserId);

        _ = modelBuilder.Entity<TicketOrderPaymenrEfModel>()
      .HasOne(u => u.TicketOrder)
      .WithMany()
      .HasForeignKey(u => u.TickerOrderId);

        _ = modelBuilder.Entity<PaymentsEFModel>()
            .HasOne(u => u.CheckoutOrder)
            .WithMany()
        .HasForeignKey(u => u.CheckoutOrderId);

        _ = modelBuilder.Entity<QrTicketEFModel>()
          .HasOne(u => u.TicketOrder)
          .WithMany()
        .HasForeignKey(u => u.TicketOrderId);

        base.OnModelCreating(modelBuilder);
    }


}