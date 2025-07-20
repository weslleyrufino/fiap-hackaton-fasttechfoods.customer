using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.Interfaces.Services.Authentication;
public interface IAuthService
{
    Task<CustomerEntity?> ValidateCredentialsAsync(string? cpf, string? email, string password);
}
