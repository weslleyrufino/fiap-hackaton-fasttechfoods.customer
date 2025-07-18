using FastTechFoods.Customer.Application.ViewModel.MenuItem;

namespace FastTechFoods.Customer.Application.Interfaces.Services;
public interface IMenuItemService
{
    Task CreateMenuItemAsync(CreateMenuItemViewModel menuItem);
    Task UpdateMenuItemAsync(UpdateMenuItemViewModel menuItem);
    Task<bool> ExistsAsync(Guid id);
}
