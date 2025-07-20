using System.Security.Claims;

namespace FastTechFoods.Customer.Application.ExtensionMethods;
public static class ClaimsPrincipalExtensions
{
    public static Guid GetCustomerId(this ClaimsPrincipal user)
    {
        var sub = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Guid.TryParse(sub, out var id)
            ? id
            : throw new UnauthorizedAccessException("Invalid customer ID.");
    }
}

