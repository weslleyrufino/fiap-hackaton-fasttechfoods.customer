using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTechFoods.Customer.Infrastructure.Repository;
public class EmployeeRepository(ApplicationDbContext context) : EFRepository<Employee>(context), IEmployeeRepository
{
    public async Task<Employee?> GetByEmailAsync(string email)
        => await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
}
