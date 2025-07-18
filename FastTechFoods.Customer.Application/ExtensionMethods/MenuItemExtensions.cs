using FastTechFoods.Customer.Application.ViewModel.MenuItem;
using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.ExtensionMethods;
public static class MenuItemExtensions
{

    public static MenuItem ToModel(this CreateMenuItemViewModel createViewModel)
    {
        return new MenuItem
        {
            Name = createViewModel.Name,
            Description = createViewModel.Description,
            Price = createViewModel.Price,
            Category = createViewModel.Category,
            IsAvailable = createViewModel.IsAvailable,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateFrom(this MenuItem entity, UpdateMenuItemViewModel viewModel)
    {
        entity.Name = viewModel.Name;
        entity.Description = viewModel.Description;
        entity.Price = viewModel.Price;
        entity.Category = viewModel.Category;
        entity.IsAvailable = viewModel.IsAvailable;
        entity.UpdatedAt = DateTime.UtcNow;
    }
}
