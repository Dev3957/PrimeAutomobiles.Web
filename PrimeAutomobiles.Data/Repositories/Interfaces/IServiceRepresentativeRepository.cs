using PrimeAutomobiles.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Repositories.Interfaces
{
    public interface IServiceRepresentativeRepository
    {
        Task<IEnumerable<ServiceRepresentative>> GetAllServiceRepresentativesAsync();
        Task<ServiceRepresentative> GetServiceRepresentativeByIdAsync(int id);
        Task AddServiceRepresentativeAsync(ServiceRepresentative serviceRepresentative);
        Task UpdateServiceRepresentativeAsync(ServiceRepresentative serviceRepresentative);
        Task DeleteServiceRepresentativeAsync(int id);
    }
}
