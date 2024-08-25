using Microsoft.EntityFrameworkCore;
using PrimeAutomobiles.Data.Models;
using PrimeAutomobiles.Data.PrimeAutomobiles.Data;
using PrimeAutomobiles.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Repositories
{
    public class ServiceRepresentativeRepository : IServiceRepresentativeRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepresentativeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRepresentative>> GetAllServiceRepresentativesAsync()
        {
            return await _context.ServiceRepresentatives.ToListAsync();
        }

        public async Task<ServiceRepresentative> GetServiceRepresentativeByIdAsync(int id)
        {
            return await _context.ServiceRepresentatives
                .Include(sa => sa.ServiceRecords)
                .FirstOrDefaultAsync(sa => sa.ServiceAdvisorID == id);
        }

        public async Task AddServiceRepresentativeAsync(ServiceRepresentative serviceRepresentative)
        {
            await _context.ServiceRepresentatives.AddAsync(serviceRepresentative);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceRepresentativeAsync(ServiceRepresentative serviceRepresentative)
        {
            _context.ServiceRepresentatives.Update(serviceRepresentative);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRepresentativeAsync(int id)
        {
            var serviceRepresentative = await _context.ServiceRepresentatives.FindAsync(id);
            if (serviceRepresentative != null)
            {
                _context.ServiceRepresentatives.Remove(serviceRepresentative);
                await _context.SaveChangesAsync();
            }
        }
    }
}
