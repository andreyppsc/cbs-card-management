using CM.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CM.Api.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Account> Accounts { get; set; } = default!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>().ToTable("cards", "car");
        modelBuilder.Entity<Card>().HasKey(c => c.Id);
        modelBuilder.Entity<Card>()
            .Property(c => c.Id)
            .HasColumnName("card_id")
            .ValueGeneratedNever();
        modelBuilder.Entity<Card>()
            .Property(c => c.HolderName)
            .HasColumnName("holder_name");
        modelBuilder.Entity<Card>()
            .Property(c => c.AccountNumber)
            .HasColumnName("pan");
        modelBuilder.Entity<Card>()
            .Property(c => c.ExpiryDate)
            .HasColumnName("expiry_date");
        modelBuilder.Entity<Card>()
            .Property(c => c.AccountId)
            .HasColumnName("account_id");
        
        modelBuilder.Entity<Account>().ToTable("accounts", "acc");
        modelBuilder.Entity<Account>().HasKey(c => c.Id);
        modelBuilder.Entity<Account>()
            .Property(c => c.Id)
            .HasColumnName("account_id")
            .ValueGeneratedNever();
        modelBuilder.Entity<Account>()
            .Property(c => c.AccountCode)
            .HasColumnName("account_code");
        modelBuilder.Entity<Account>()
            .Property(c => c.IBAN)
            .HasColumnName("iban");
    }
}