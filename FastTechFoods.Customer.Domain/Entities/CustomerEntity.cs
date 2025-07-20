using FastTechFoods.Customer.Domain.Entities.Base;

namespace FastTechFoods.Customer.Domain.Entities;
public class CustomerEntity : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }

    public string PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
