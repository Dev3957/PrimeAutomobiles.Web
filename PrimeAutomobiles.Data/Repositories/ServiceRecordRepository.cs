using Microsoft.EntityFrameworkCore;
using PrimeAutomobiles.Data.Models;
using PrimeAutomobiles.Data.PrimeAutomobiles.Data;
using PrimeAutomobiles.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Repositories
{
    public class ServiceRecordRepository : IServiceRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRecord>> GetAllServiceRecordsAsync()
        {
            return await _context.ServiceRecords
                .Include(sr => sr.Vehicle)
                .Include(sr => sr.ServiceRepresentative)
                .ToListAsync();
        }

        public async Task<ServiceRecord> GetServiceRecordByIdAsync(int id)
        {
            return await _context.ServiceRecords
                .Include(sr => sr.Vehicle)
                .Include(sr => sr.ServiceRepresentative)
                .FirstOrDefaultAsync(sr => sr.ServiceID == id);
        }

        public async Task AddServiceRecordAsync(ServiceRecord serviceRecord)
        {
            await _context.ServiceRecords.AddAsync(serviceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceRecordAsync(ServiceRecord serviceRecord)
        {
            _context.ServiceRecords.Update(serviceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRecordAsync(int id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);
            if (serviceRecord != null)
            {
                _context.ServiceRecords.Remove(serviceRecord);
                await _context.SaveChangesAsync();
            }
        }
    }
}
