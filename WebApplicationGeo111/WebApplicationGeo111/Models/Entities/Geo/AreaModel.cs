using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGeo111.Models.Entities.Geo;

public class AreaModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int CountryId { get; set; }
    [ForeignKey("CountryId")]
    public CountryModel? Country { get; set; }

    public List<CityModel> Cities { get; set; } = new List<CityModel>();

    public List<RegionModel> Regions { get; set; } = new List<RegionModel>();
}