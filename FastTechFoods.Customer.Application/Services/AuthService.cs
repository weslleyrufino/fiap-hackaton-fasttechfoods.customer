using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Application.Interfaces.Services.Authentication;
using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.Services;
public class AuthService(IEmployeeRepository employeeRepository) : IAuthService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<Employee?> ValidateCredentialsAsync(string email, string password)
    {
        var employee = await _employeeRepository.GetByEmailAsync(email);
        if (employee is null)
            return null;

        // Verify password hash
        if(BCrypt.Net.BCrypt.Verify(password, employee.PasswordHash))
            return employee;
        else
            return null;
    }
}
