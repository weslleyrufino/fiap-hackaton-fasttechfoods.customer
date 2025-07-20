using FastTechFoods.Customer.Application.ExtensionMethods;
using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Application.Interfaces.Services;
using FastTechFoods.Customer.Application.ViewModel.MenuItem;

namespace FastTechFoods.Customer.Application.Services;
public class MenuItemService(IMenuItemRepository menuItemRepository) : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;

    public async Task<IEnumerable<MenuItemViewModel>> GetMenuItemAsync(string category)
        => (await _menuItemRepository.GetMenuItemByCategoryAsync(category)).ToViewModel();

    public async Task<bool> ExistsAsync(Guid id)
        => await _menuItemRepository.ExistsAsync(id);
   
}
