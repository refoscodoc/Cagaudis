using System.ComponentModel.DataAnnotations;
using Core.Entities.BaseEntities;

namespace Core.ViewModels;

public class AddressViewModel : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public String Street;
    public int PostalCode;
    public String City;
}