using FastTechFoods.Customer.Application.ViewModel.Order;

namespace FastTechFoods.Customer.Application.Interfaces.Services;
public interface IOrderService
{
    Task<bool> ExistsAsync(Guid id);
    Task<OrderViewModel?> GetOrderByCustomerIdAsync(Guid id);
    Task CreateOrderAsync(CreateOrderViewModel requestOrder);

    Task CancelOrderAsync(CancellationReasonOrderViewModel requestOrder, OrderViewModel orderFromDB);
}
