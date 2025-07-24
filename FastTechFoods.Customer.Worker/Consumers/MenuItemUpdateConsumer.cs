using FastTechFoods.Contracts;
using FastTechFoods.Customer.Domain.Entities;
using FastTechFoods.Customer.Infrastructure.Repository;
using MassTransit;

namespace FastTechFoods.Customer.Worker.Consumers;
public class MenuItemUpdateConsumer : IConsumer<MenuUpdatedEvent>
{
    private readonly ApplicationDbContext _dbContext;

    public MenuItemUpdateConsumer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<MenuUpdatedEvent> context)
    {
        var item = context.Message;

        var menuItem = new MenuItem
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Category = item.Category,
            IsAvailable = item.IsAvailable,
            UpdatedAt = item.UpdatedAt
        };

        _dbContext.MenuItem.Update(menuItem);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine($"[Worker] Menu item alterado: {menuItem.Name}");
    }
}