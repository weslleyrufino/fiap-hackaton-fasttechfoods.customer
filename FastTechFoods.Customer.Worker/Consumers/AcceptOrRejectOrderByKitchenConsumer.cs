using FastTechFoods.Contracts;
using FastTechFoods.Customer.Infrastructure.Repository;
using MassTransit;
using EnumStatus = FastTechFoods.Customer.Domain.Entities.Enum.EnumStatus;

namespace FastTechFoods.Customer.Worker.Consumers;
public class AcceptOrRejectOrderByKitchenConsumer : IConsumer<AcceptOrRejectOrder>
{
    private readonly ApplicationDbContext _dbContext;

    public AcceptOrRejectOrderByKitchenConsumer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<AcceptOrRejectOrder> context)
    {
        var msg = context.Message;

        var orderFromDB = _dbContext.Order.FirstOrDefault(x => x.Id == msg.Id);

        if (orderFromDB != null)
        {
            orderFromDB.CancellationReason = msg.CancellationReason;
            orderFromDB.Status = (EnumStatus)msg.Status;
            _dbContext.Order.Update(orderFromDB);
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"[Worker][CancelOrderByCustomerConsumer] Order updated. Order.Id: {orderFromDB.Id}");
        }
        else
            Console.WriteLine($"[Worker][CancelOrderByCustomerConsumer] Order doesn't not exist in kitchen DB. Order.Id: {msg.Id}");

    }
}
