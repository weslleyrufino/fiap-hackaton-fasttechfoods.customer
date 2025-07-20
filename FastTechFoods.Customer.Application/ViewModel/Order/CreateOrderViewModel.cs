using FastTechFoods.Customer.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.Order;
public class CreateOrderViewModel
{

    [Required(ErrorMessage = "The delivery method is required.")]
    public EnumDeliveryMethod DeliveryMethod { get; set; }

    [Required]
    public List<CreateOrderItemViewModel> Items { get; set; } = new();
}
