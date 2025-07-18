using FastTechFoods.Customer.Application.ViewModel.Order;

namespace FastTechFoods.Customer.Application.Interfaces.Services;
public interface IOrderService
{
    Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync();
    Task<bool> ExistsAsync(Guid id);
    Task<OrderViewModel?> GetOrderByIdAsync(Guid id);
    Task UpdateOrderAsync(UpdateStatusOrderViewModel menuItem);
}
