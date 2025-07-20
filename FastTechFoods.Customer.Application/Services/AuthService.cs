using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Application.Interfaces.Services.Authentication;
using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.Services;
public class AuthService(ICustomerRepository customerRepository) : IAuthService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<CustomerEntity?> ValidateCredentialsAsync(string? cpf, string? email, string password)
    {
        CustomerEntity? customer;
        if (cpf is not null)
            customer = await _customerRepository.GetByCPFAsync(cpf);
        else if(email is not null)
            customer = await _customerRepository.GetByEmailAsync(email);
        else
            return null;

        if (customer is null)
            return null;

        // Verify password hash
        if(BCrypt.Net.BCrypt.Verify(password, customer.PasswordHash))
            return customer;
        else
            return null;
    }
}
