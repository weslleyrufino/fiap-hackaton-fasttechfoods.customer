using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTechFoods.Customer.Infrastructure.Repository;
public class OrderRepository(ApplicationDbContext context) : EFRepository<Order>(context), IOrderRepository
{
    public async Task<IEnumerable<Order>?> GetOrderByCustomerIdAsync(Guid id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(o => o.Items)
            .Where(o => o.CustomerId == id).ToListAsync();
    }
       

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _dbSet
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(Guid id)
    {
        return await _dbSet
           .AsNoTracking()
           .Include(o => o.Items)
           .FirstOrDefaultAsync(o => o.Id == id);
    }
}
