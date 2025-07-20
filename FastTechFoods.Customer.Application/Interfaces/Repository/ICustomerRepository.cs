using FastTechFoods.Customer.Domain.Entities;

namespace FastTechFoods.Customer.Application.Interfaces.Repository;
public interface ICustomerRepository : IRepository<CustomerEntity>
{
    Task<CustomerEntity?> GetByEmailAsync(string email);
    Task<CustomerEntity?> GetByCPFAsync(string cpf);
}
