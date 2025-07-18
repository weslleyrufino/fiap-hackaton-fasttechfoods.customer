using FastTechFoods.Customer.Application.ViewModel.Order.Enum;
using FastTechFoods.Customer.Domain.Entities.Enum;

namespace FastTechFoods.Customer.Application.ExtensionMethods;
public static class EnumStatusExtensions
{
    public static EnumStatus ToDomainStatus(this EnumAcceptOrRejected viewStatus)
    {
        return viewStatus switch
        {
            EnumAcceptOrRejected.Accepted => EnumStatus.Accepted,
            EnumAcceptOrRejected.Rejected => EnumStatus.Rejected,
            _ => throw new ArgumentOutOfRangeException(nameof(viewStatus), "Invalid status")
        };
    }
}
