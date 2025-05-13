// Data/AppDbContext.cs
using APIGrowthPersonal.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка таблицы Users (опционально)
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.id);
            entity.Property(u => u.username).IsRequired();
            entity.Property(u => u.password).IsRequired();
        });
    }
}