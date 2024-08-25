using PrimeAutomobiles.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Repositories.Interfaces
{
    public interface IServiceRecordRepository
    {
        Task<IEnumerable<ServiceRecord>> GetAllServiceRecordsAsync();
        Task<ServiceRecord> GetServiceRecordByIdAsync(int id);
        Task AddServiceRecordAsync(ServiceRecord serviceRecord);
        Task UpdateServiceRecordAsync(ServiceRecord serviceRecord);
        Task DeleteServiceRecordAsync(int id);
    }
}
