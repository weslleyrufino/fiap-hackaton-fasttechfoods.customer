﻿using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.Interfaces.Repository;
public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>?> GetOrderByCustomerIdAsync(Guid id);
    Task<Order?> GetOrderByIdAsync(Guid id);
}
