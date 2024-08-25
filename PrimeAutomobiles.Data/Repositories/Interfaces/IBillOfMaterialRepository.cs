using PrimeAutomobiles.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Repositories.Interfaces
{
    public interface IBillOfMaterialRepository
    {
        Task<IEnumerable<BillOfMaterial>> GetAllBillOfMaterialsAsync();
        Task<BillOfMaterial> GetBillOfMaterialByIdAsync(int id);
        Task AddBillOfMaterialAsync(BillOfMaterial billOfMaterial);
        Task UpdateBillOfMaterialAsync(BillOfMaterial billOfMaterial);
        Task DeleteBillOfMaterialAsync(int id);
    }
}
