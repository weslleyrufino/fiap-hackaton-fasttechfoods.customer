using FastTechFoods.Customer.Application.ViewModel.MenuItem;

namespace FastTechFoods.Customer.Application.Interfaces.Services;
public interface IMenuItemService
{
    Task<IEnumerable<MenuItemViewModel>> GetMenuItemAsync(string? category);
    Task<bool> ExistsAsync(Guid id);
}
