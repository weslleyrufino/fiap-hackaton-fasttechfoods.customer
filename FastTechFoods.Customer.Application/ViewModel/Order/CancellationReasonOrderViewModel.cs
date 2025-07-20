using FastTechFoods.Customer.Application.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.Order;
public class CancellationReasonOrderViewModel : ViewModelBase
{
    [Required(ErrorMessage = "Cancellation reason is required.")]
    public required string CancellationReason { get; set; }
}
