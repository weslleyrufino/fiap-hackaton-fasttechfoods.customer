using FastTechFoods.Customer.Application.ViewModel.Order;

namespace FastTechFoods.Customer.Application.Interfaces.Services;
public interface IOrderService
{
    Task<bool> ExistsAsync(Guid id);
    Task<OrderViewModel?> GetOrderByIdAsync(Guid id);
    Task CreateOrderAsync(CreateOrderViewModel requestOrder);

    Task UpdateOrderAsync(UpdateStatusOrderViewModel requestOrder, OrderViewModel orderFromDB);
}
