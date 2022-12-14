using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class CarRentalDbContext:DbContext
{   
    public CarRentalDbContext()
    {
    }

    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
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
        modelBuilder.Entity<Rental>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Customer>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<CarImage>().Property(image => image.Id);
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
    
    public DbSet<Rental>? Rentals { get; set; }

    public DbSet<CarImage> CarImages { get; set; }
    
    public DbSet<Customer>? Customers { get; set; }

    public DbSet<OperationClaim> OperationClaims { get; set; }

    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}