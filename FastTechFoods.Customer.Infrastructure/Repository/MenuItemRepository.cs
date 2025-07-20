using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTechFoods.Customer.Infrastructure.Repository;
public class MenuItemRepository(ApplicationDbContext context) : EFRepository<MenuItem>(context), IMenuItemRepository
{
    public async Task<IEnumerable<MenuItem>> GetMenuItemByCategoryAsync(string category)
    {
        return await _dbSet
            .Where(
            x => x.IsAvailable == true &&
            x.Category == category)
            .ToListAsync();
    }
}
