using Core.Entities.Interfaces;

namespace Core.Entities;

public class LocationModel : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastModified { get; set; }
    public string CityName { get; set; }
    public string ProvinceName { get; set; }
    public string RegionName { get; set; }
    public int ZipCode { get; set; }
    // here use a geolocation coordinates library
}