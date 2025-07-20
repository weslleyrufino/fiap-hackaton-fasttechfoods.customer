using FastTechFoods.Customer.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.Order;
public class CreateOrderViewModel
{
    [Required(ErrorMessage = "The customer ID is required.")]
    public string CustomerId { get; set; } // string pois pode ser CPF ou email.

    [Required(ErrorMessage = "The delivery method is required.")]
    public EnumDeliveryMethod DeliveryMethod { get; set; }

    [Required]
    public List<OrderItemViewModel> Items { get; set; } = new();
}
