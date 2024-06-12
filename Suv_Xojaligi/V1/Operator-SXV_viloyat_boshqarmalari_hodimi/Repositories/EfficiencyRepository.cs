using Microsoft.EntityFrameworkCore;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.Common.Repositories;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories;

public class EfficiencyRepository : BaseRepository<Efficiency,EfficiencyFilterModel>, IEfficiencyRepository
{
    private readonly AppDbContext _context;

    public EfficiencyRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Efficiency> Get(Guid id)
    {
        return await _context.Efficiencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Efficiency> DeleteEfficiency(Guid id)
    {
        await _context.Efficiencies.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
        return await _context.Efficiencies.FirstOrDefaultAsync(x => id == id);
    }
    public async Task<Efficiency> CreateEfficiency( Efficiency efficiency)
    {
        efficiency.ReportId = efficiency.ReportId;
        efficiency.CreatedAt = DateTime.UtcNow;
        efficiency.UpdatedAt = DateTime.UtcNow;
        await _context.Efficiencies.AddAsync(efficiency);
        await _context.SaveChangesAsync();
    
        return efficiency;

    }
    public async Task<Efficiency> UpdateEfficiency(Efficiency efficiency)
    {
        await _context.Efficiencies.Where(e => e.Id == efficiency.Id)
            .ExecuteUpdateAsync(
            y => y.SetProperty(e=>e.Year, e=>efficiency.Year)
            .SetProperty(e=>e.Inestment,e=>efficiency.Inestment)
            .SetProperty(e=>e.EneryConsumption,e=>efficiency.EneryConsumption)
            .SetProperty(e=>e.ActualEnergyConsumption,e=>efficiency.ActualEnergyConsumption)
            .SetProperty(e=>e.ActualBudget,e=>efficiency.ActualBudget)
            .SetProperty(e=>e.Percentage,e=>efficiency.Percentage)
            .SetProperty(e=>e.UpdatedAt, e=>DateTime.UtcNow)
            .SetProperty(e=>e.Type,e=>efficiency.Type)
            .SetProperty(e=>e.CurrentStatus,e=>efficiency.CurrentStatus)
            );
        return await _context.Efficiencies.AsNoTracking().FirstOrDefaultAsync(e => e.Id == efficiency.Id);
    }
    protected override IQueryable<Efficiency> GetQuery(EfficiencyFilterModel model)
    {
        var query = _context.Efficiencies.AsNoTracking();
        if(model.Id.HasValue && model.Id.Value != Guid.Empty)
        {
            query = query.Where(x=>x.Id == model.Id.Value);
        }
        return query;
    }
}
