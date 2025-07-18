using FastTechFoods.Customer.Application.Interfaces.Services;
using FastTechFoods.Customer.Application.ViewModel.Order;
using Microsoft.AspNetCore.Mvc;

namespace FastTechFoods.Customer.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService orderService, ILogger<OrdersController> logger) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;
    private readonly ILogger<OrdersController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _orderService.GetAllOrdersAsync();

        return Ok(result);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchUpdateStatusOrders([FromBody] UpdateStatusOrderViewModel orderViewModel)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool exists = await _orderService.ExistsAsync(orderViewModel.Id);

        if (!exists)
            return NotFound("Order does not exist.");

        await _orderService.UpdateOrderAsync(orderViewModel);

        return NoContent();

    }
}
