using Core.Persistence.Repositories.Interfaces;

namespace Core.Persistence;

public interface IUnitOfWork : IDisposable
{
    ICarServiceRepository CarRepository { get; }
    IAuditServiceRepository AuditServiceRepository { get; }
    IManufacturerRepository ManufacturerRepository { get; }
    ISellerRepository SellerRepository { get; }
    Task Save();
}