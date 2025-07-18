using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.Interfaces.Services.Authentication;
public interface IAuthService
{
    Task<Employee?> ValidateCredentialsAsync(string email, string password);
}
