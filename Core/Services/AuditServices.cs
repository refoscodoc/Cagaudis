using System.Text;
using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using Newtonsoft.Json;

namespace Core.Services;

public class AuditServices : IAuditServices
{
    private readonly HttpClient _httpClient;

    public AuditServices(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AuditServices");
    }

    public async Task<int> AddAudits(List<AuditModel> audits)
    {
        try
        {
            var auditsJson = JsonConvert.SerializeObject(audits);
            var httpContent = new StringContent(auditsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}/Audit", httpContent);
            response.EnsureSuccessStatusCode();
            return 1;
        }
        catch
        {
            throw new BadRequestException("Error while adding audits");
        }
    }
}