using FastTechFoods.Customer.Domain.Entities.Base;
using FastTechFoods.Customer.Domain.Entities.Enum;

namespace FastTechFoods.Customer.Domain.Entities;
public class Employee : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public EmployeeRole Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
