namespace Core.Entities.Interfaces;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastModified { get; set; }
}