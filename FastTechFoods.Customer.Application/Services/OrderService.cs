using FastTechFoods.Customer.Application.Common;
using FastTechFoods.Customer.Application.ExtensionMethods;
using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Application.Interfaces.Services;
using FastTechFoods.Customer.Application.ViewModel.Order;
using FastTechFoods.Customer.Domain.Entities.Enum;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace FastTechFoods.Customer.Application.Services;
public class OrderService(ISendEndpointProvider sendEndpointProvider, IConfiguration configuration, IOrderRepository orderRepository) : IOrderService
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;
    private readonly IConfiguration _configuration = configuration;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<bool> ExistsAsync(Guid id)
        => await _orderRepository.ExistsAsync(id);


    public async Task CreateOrderAsync(CreateOrderViewModel requestOrder)
    {
        // Insert na base de dados. 
        await _orderRepository.InsertAsync(requestOrder.ToModel());

        // Se gravou com sucesso, colocar a mensagem da fila do rabbitmq
        await RabbitMqHelper.SendMessageAsync(_sendEndpointProvider, _configuration, requestOrder, "MassTransit_CustomerOrderCreated:NomeFila");
    }

    public async Task UpdateOrderAsync(UpdateStatusOrderViewModel requestOrder, OrderViewModel orderFromDB)
    {
        var order = await SetData(requestOrder, orderFromDB);

        // Update na base de dados. 
        await _orderRepository.UpdateAsync(order.ToModel());

        // Se gravou com sucesso, colocar a mensagem da fila do rabbitmq
        await RabbitMqHelper.SendMessageAsync(_sendEndpointProvider, _configuration, requestOrder, "MassTransit_UpdateStatusOrderByCustomer:NomeFila");
    }

    private async Task<OrderViewModel> SetData(UpdateStatusOrderViewModel requestOrder, OrderViewModel orderFromDB)
    {
        // Update order recebido com base no orderViewModel.
        orderFromDB.Status = requestOrder.Status.ToDomainStatus();
        orderFromDB.CancellationReason = requestOrder.CancellationReason;

        return orderFromDB;
    }

    public async Task<OrderViewModel?> GetOrderByIdAsync(Guid id)
        => (await _orderRepository.GetOrderByIdAsync(id))?.ToViewModel();
}
