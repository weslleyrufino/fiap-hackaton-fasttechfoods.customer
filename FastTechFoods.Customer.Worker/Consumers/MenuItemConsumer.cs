using FastTechFoods.Contracts;
using FastTechFoods.Customer.Domain.Entities;
using FastTechFoods.Customer.Infrastructure.Repository;
using MassTransit;

namespace FastTechFoods.Customer.Worker.Consumers;
public class MenuItemConsumer : IConsumer<MenuCreatedEvent>
{
    private readonly ApplicationDbContext _dbContext;

    public MenuItemConsumer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<MenuCreatedEvent> context)
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
            CreatedAt = item.CreatedAt
        };

        _dbContext.MenuItem.Add(menuItem);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine($"[Worker] Menu item salvo: {menuItem.Name}");
    }
}