using System.ComponentModel.DataAnnotations;
using Core.Entities.BaseEntities;

namespace Core.Entities;

public class LocationViewModel : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public string CityName { get; set; }
    public string ProvinceName { get; set; }
    public string RegionName { get; set; }
    public int ZipCode { get; set; }
    // here use a geolocation coordinates library
}