﻿using FastTechFoods.Customer.Domain.Entities.Base;
using FastTechFoods.Customer.Domain.Entities.Enum;

namespace FastTechFoods.Customer.Domain.Entities;
public class Order : EntityBase
{
    public required string CustomerId { get; set; }// string pois pode ser CPF ou email.

    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public required EnumStatus Status { get; set; }

    public required string DeliveryMethod { get; set; }

    public string? CancellationReason { get; set; }

    public required List<OrderItem> Items { get; set; } = new();
}
