﻿using FastTechFoods.Customer.Application.ViewModel.Base;
using FastTechFoods.Customer.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.Order;
public class OrderViewModel : ViewModelBase
{
    [Required(ErrorMessage = "The customer ID is required.")]
    public Guid CustomerId { get; set; } 

    [Required(ErrorMessage = "The order date is required.")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "The order status is required.")]
    public EnumStatus Status { get; set; }

    [Required(ErrorMessage = "The delivery method is required.")]
    public EnumDeliveryMethod DeliveryMethod { get; set; }


    /// <summary>
    /// Only Rejected or Canceled
    /// </summary>
    public string? CancellationReason { get; set; }

    [Required]
    public List<OrderItemViewModel> Items { get; set; } = new();
}