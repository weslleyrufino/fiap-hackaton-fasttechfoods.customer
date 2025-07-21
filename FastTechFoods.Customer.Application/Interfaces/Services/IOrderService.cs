using FastTechFoods.Customer.Application.ViewModel.Order;

namespace FastTechFoods.Customer.Application.Interfaces.Services;
public interface IOrderService
{
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<OrderViewModel>?> GetOrderByCustomerIdAsync(Guid id);
    Task CreateOrderAsync(Guid customerId, CreateOrderViewModel requestOrder);

    Task CancelOrderAsync(CancellationReasonOrderViewModel requestOrder, OrderViewModel orderFromDB);

    Task<OrderViewModel?> GetOrderByIdAsync(Guid id);
}
