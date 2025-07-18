using FastTechFoods.Customer.Domain.Entities.Base;

namespace FastTechFoods.Customer.Domain.Entities;
public class MenuItem : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }     
    public string Category { get; set; }   
    public bool IsAvailable { get; set; }  
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
