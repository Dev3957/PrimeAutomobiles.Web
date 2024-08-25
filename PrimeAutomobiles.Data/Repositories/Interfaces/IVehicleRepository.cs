using PrimeAutomobiles.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}
