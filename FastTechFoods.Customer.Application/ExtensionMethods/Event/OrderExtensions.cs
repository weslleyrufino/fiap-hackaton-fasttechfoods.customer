using FastTechFoods.Contracts;
using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.ExtensionMethods.Event;
public static class OrderExtensions
{
    public static OrderCreatedEvent ToEventModel(this Order order)
    {
        return new OrderCreatedEvent(
            order.Id,
            order.CustomerId,
            order.CreatedAt,
            (Contracts.Enum.EnumStatus)order.Status,
            (Contracts.Enum.EnumDeliveryMethod)order.DeliveryMethod,
            order.Items.Select(item => new OrderItemEvent(
                item.Id,
                item.MenuItemId,
                item.Quantity,
                item.UnitPrice
            )).ToList()
        );
    }
}
