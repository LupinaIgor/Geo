using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGeo111.Models.Entities.Geo;

public class RegionModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public List<AreaModel> Areas { get; set; } = new List<AreaModel>();
}