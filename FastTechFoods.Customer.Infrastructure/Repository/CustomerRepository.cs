using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTechFoods.Customer.Infrastructure.Repository;
public class CustomerRepository(ApplicationDbContext context) : EFRepository<CustomerEntity>(context), ICustomerRepository
{
    public async Task<CustomerEntity?> GetByEmailAsync(string email)
        => await _dbSet.FirstOrDefaultAsync(x => x.Email == email);

    public async Task<CustomerEntity?> GetByCPFAsync(string cpf)
        => await _dbSet.FirstOrDefaultAsync(x => x.CPF == cpf);
}
