using FastTechFoods.Customer.Application.ViewModel.Order.Enum;
using FastTechFoods.Customer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.Order;
public class UpdateStatusOrderViewModel : EntityBase
{
    [Required(ErrorMessage = "The new status is required.")]
    public EnumAcceptOrRejected Status { get; set; }

    public string? CancellationReason { get; set; }
}
