using FastTechFoods.Customer.Application.ExtensionMethods;
using FastTechFoods.Customer.Application.Interfaces.Services;
using FastTechFoods.Customer.Application.ViewModel.Order;
using FastTechFoods.Customer.Domain.Entities.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastTechFoods.Customer.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService orderService, ILogger<OrdersController> logger) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;
    private readonly ILogger<OrdersController> _logger = logger;

    [HttpPost("CreateOrder")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel orderViewModel)
    {
        var customerId = User.GetCustomerId();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _orderService.CreateOrderAsync(customerId, orderViewModel);

        return NoContent();

    }

    [HttpGet("GetOrderByCustomerId")]
    public async Task<IActionResult> GetOrderByCustomerIdAsync()
    {
        var customerId = User.GetCustomerId();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _orderService.GetOrderByCustomerIdAsync(customerId);

        if (result is null)
            return NoContent();

        return Ok(result);
    }

    [HttpPatch("CancelOrder")]
    public async Task<IActionResult> CancelOrder([FromBody] CancellationReasonOrderViewModel orderViewModel)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var orderFromDB = await _orderService.GetOrderByIdAsync(orderViewModel.Id);

        if (orderFromDB is null)
            return NoContent();

        if (orderFromDB.Status == EnumStatus.Accepted)
            return BadRequest("Not possible to cancel the order.");

        await _orderService.CancelOrderAsync(orderViewModel, orderFromDB);

        return NoContent();

    }


}
