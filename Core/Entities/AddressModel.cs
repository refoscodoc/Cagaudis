using Core.Entities.BaseEntities;

namespace Core.Entities;

public class AddressModel : BaseEntity
{
    public String Street;
    public int PostalCode;
    public String City;
}