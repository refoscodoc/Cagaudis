using Core.DataAccess;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Interfaces;
using GenericPersistence.Repositories;
using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly GenericDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    // private  IDbContextTransaction _dbContextTransaction;

    private ICarServiceRepository _carRepository;
    private ISellerRepository _sellerRepository;
    private IManufacturerRepository _manufacturerRepository;
    private IAuditServiceRepository _auditServiceRepository;

    public UnitOfWork(GenericDbContext context, 
        IHttpContextAccessor httpContextAccessor, 
        // IDbContextTransaction dbContextTransaction, 
        IAuditServiceRepository auditServiceRepository)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        // _dbContextTransaction = dbContextTransaction;
        _auditServiceRepository = auditServiceRepository;
    }

    public IAuditServiceRepository AuditServiceRepository =>
        _auditServiceRepository ??= new AudiRepository(_context);

    public ICarServiceRepository CarRepository =>
        _carRepository ??= new CarRepository(_context);

    public IManufacturerRepository ManufacturerRepository =>
        _manufacturerRepository ??= new ManufacturerRepository(_context);

    public ISellerRepository SellerRepository => 
        _sellerRepository ??= new SellerRepository(_context);

    public async Task Save()
    {
        // var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
        // await _context.SaveChangesAsync(username);
        await _context.SaveChangesAsync();
    }
    
    // public void Dispose()
    // {
    //     _context.Dispose();
    //     if (_dbContextTransaction is not null)
    //     {
    //         _dbContextTransaction.Dispose();
    //     }
    //     GC.SuppressFinalize(this);
    // }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}