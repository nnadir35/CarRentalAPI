using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class CarDbContext:DbContext
{   
    public CarDbContext()
    {
    }

    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Car>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Brand>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Color>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=CarRental;Username=postgres;Password=123456");
        }
    }

    
    public DbSet<Car>? Cars { get; set; }
    public DbSet<Brand>? Brands { get; set; }
    public DbSet<Color>? Colors { get; set; }


}