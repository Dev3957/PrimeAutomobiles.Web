using Microsoft.EntityFrameworkCore;
using PrimeAutomobiles.Data.Models;
using PrimeAutomobiles.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Repositories
{
    public class BillOfMaterialRepository : IBillOfMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public BillOfMaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BillOfMaterial>> GetAllBillOfMaterialsAsync()
        {
            return await _context.BillOfMaterials
                .Include(bom => bom.ServiceRecord)
                .ToListAsync();
        }

        public async Task<BillOfMaterial> GetBillOfMaterialByIdAsync(int id)
        {
            return await _context.BillOfMaterials
                .Include(bom => bom.ServiceRecord)
                .FirstOrDefaultAsync(bom => bom.BOMID == id);
        }

        public async Task AddBillOfMaterialAsync(BillOfMaterial billOfMaterial)
        {
            await _context.BillOfMaterials.AddAsync(billOfMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBillOfMaterialAsync(BillOfMaterial billOfMaterial)
        {
            _context.BillOfMaterials.Update(billOfMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBillOfMaterialAsync(int id)
        {
            var billOfMaterial = await _context.BillOfMaterials.FindAsync(id);
            if (billOfMaterial != null)
            {
                _context.BillOfMaterials.Remove(billOfMaterial);
                await _context.SaveChangesAsync();
            }
        }
    }
}
