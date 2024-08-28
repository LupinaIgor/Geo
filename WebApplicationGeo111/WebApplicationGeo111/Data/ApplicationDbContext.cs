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
}