using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.Interfaces.Services.Authentication;
public interface IJwtTokenService
{
    string GenerateToken(CustomerEntity customerEntity);
}
