using FastTechFoods.Customer.Application.ViewModel.MenuItem;
using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.ExtensionMethods;
public static class MenuItemExtensions
{

    public static MenuItemViewModel ToViewModel(this MenuItem model)
    {
        return new MenuItemViewModel
        {
           Id = model.Id,
           Category = model.Category,
           Description = model.Description,
           IsAvailable = model.IsAvailable,
           Name = model.Name,
           Price = model.Price
        };
    }

    public static IEnumerable<MenuItemViewModel> ToViewModel(this IEnumerable<MenuItem> model)
        => model.Select(model => model.ToViewModel());
}
