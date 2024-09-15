using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationGeo111.Models.Entities.Geo;

namespace WebApplicationGeo111.Data;

public class ApplicationDbContext : IdentityDbContext
{
   public DbSet<CountryModel> Countries { get; set; }
   
   public DbSet<AreaModel> Areas { get; set; }
   
   public DbSet<CityModel> Cities { get; set; }
   
   public DbSet<RegionModel> Regions { get; set; }
   
   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);// GPT
        
        // Настройка отношения один ко многим между AreaModel и CityModel
        modelBuilder.Entity<AreaModel>()
            .HasMany(a => a.Cities)  // Связь с коллекцией Cities
            .WithOne(c => c.Area)     // Обратная связь с Area в CityModel
            .HasForeignKey(c => c.AreaId)  // Указание внешнего ключа в CityModel
            .OnDelete(DeleteBehavior.Restrict);  // Выберите поведение при удалении
    }
}