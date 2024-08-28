using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGeo111.Models.Entities.Geo;

public class CityModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int AreaId { get; set; }
    [ForeignKey("AreaId")]
    public AreaModel? Area { get; set; }
}