using FastTechFoods.Customer.Application.ViewModel.Order;
using FastTechFoods.Customer.Domain.Entities;
using FastTechFoods.Customer.Domain.Entities.Enum;

namespace FastTechFoods.Customer.Application.ExtensionMethods;
public static class OrderExtensions
{
    public static OrderViewModel ToViewModel(this Order model)
    {
        return new OrderViewModel
        {
            Id = model.Id,
            Status = model.Status,
            CustomerId = model.CustomerId,
            CancellationReason = model.CancellationReason,
            CreatedAt = model.CreatedAt,
            DeliveryMethod = model.DeliveryMethod,
            Items = model.Items.Select(item =>  new OrderItemViewModel
            {
                Id = item.Id,
                MenuItemId = item.MenuItemId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList()
        };
    }

    public static IEnumerable<OrderViewModel> ToViewModel(this IEnumerable<Order> model)
        => model.Select(model => model.ToViewModel());

    public static Order ToModel(this CreateOrderViewModel model)
    {
        return new Order
        {
            Status = EnumStatus.Pending,
            CustomerId = model.CustomerId,
            CreatedAt = DateTime.Now,
            DeliveryMethod = model.DeliveryMethod,
            Items = model.Items.Select(item => new OrderItem
            {
                Id = item.Id,
                MenuItemId = item.MenuItemId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList()
        };
    }

    public static Order ToModel(this OrderViewModel model)
    {
        return new Order
        {
            Id = model.Id,
            Status = model.Status,
            CustomerId = model.CustomerId,
            CancellationReason = model.CancellationReason,
            CreatedAt = model.CreatedAt,
            DeliveryMethod = model.DeliveryMethod,
            Items = model.Items.Select(item => new OrderItem
            {
                Id = item.Id,
                MenuItemId = item.MenuItemId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList()
        };
    }
}


