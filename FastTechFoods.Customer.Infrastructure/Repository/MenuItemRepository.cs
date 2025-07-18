using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Infrastructure.Repository;
public class MenuItemRepository(ApplicationDbContext context) : EFRepository<MenuItem>(context), IMenuItemRepository
{
    
}
