using FastTechFoods.Contracts;
using FastTechFoods.Customer.Application.ViewModel.Order;

namespace FastTechFoods.Customer.Application.ExtensionMethods.Event;
public static class CancellationReasonEventExtensions
{
    public static CancellationReasonEvent ToEventModel(this CancellationReasonOrderViewModel orderViewModel)
    {
        return new CancellationReasonEvent
            (
                orderViewModel.Id,
                orderViewModel.CancellationReason
            );
    }
}
