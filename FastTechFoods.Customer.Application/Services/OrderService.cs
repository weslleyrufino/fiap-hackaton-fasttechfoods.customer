﻿using FastTechFoods.Customer.Application.Common;
using FastTechFoods.Customer.Application.ExtensionMethods;
using FastTechFoods.Customer.Application.ExtensionMethods.Event;
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


    public async Task CreateOrderAsync(Guid customerId, CreateOrderViewModel requestOrder)
    {
        var order = requestOrder.ToModel(customerId);

        await _orderRepository.InsertAsync(order);

        await RabbitMqHelper.SendMessageAsync(_sendEndpointProvider, _configuration, order.ToEventModel(), "MassTransit_CustomerOrderCreated:NomeFila");
    }

    public async Task CancelOrderAsync(CancellationReasonOrderViewModel requestOrder, OrderViewModel orderFromDB)
    {
        var order = SetData(requestOrder, orderFromDB);

        await _orderRepository.UpdateAsync(order.ToModel());

        await RabbitMqHelper.SendMessageAsync(_sendEndpointProvider, _configuration, requestOrder.ToEventModel(), "MassTransit_CancelOrderByCustomer:NomeFila");
    }

    private OrderViewModel SetData(CancellationReasonOrderViewModel requestOrder, OrderViewModel orderFromDB)
    {
        // Update order com base no orderFromDB.
        orderFromDB.Status = EnumStatus.Canceled;
        orderFromDB.CancellationReason = requestOrder.CancellationReason;

        return orderFromDB;
    }

    public async Task<IEnumerable<OrderViewModel>?> GetOrderByCustomerIdAsync(Guid id)
        => (await _orderRepository.GetOrderByCustomerIdAsync(id))?.ToViewModel();

    
    public async Task<OrderViewModel?> GetOrderByIdAsync(Guid id)
        => (await _orderRepository.GetOrderByIdAsync(id))?.ToViewModel();
    
}
