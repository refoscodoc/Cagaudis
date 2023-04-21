using Core.Entities;

namespace Core.Contracts;

public interface IAuditServices
{
    Task<int> AddAudits(List<AuditModel> audits);
}