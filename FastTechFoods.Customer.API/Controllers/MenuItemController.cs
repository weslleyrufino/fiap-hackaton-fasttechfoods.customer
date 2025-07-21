using FastTechFoods.Customer.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastTechFoods.Customer.API.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MenuItemController(IMenuItemService menuItemService, ILogger<MenuItemController> logger) : ControllerBase
{
    private readonly IMenuItemService _menuItemService = menuItemService;
    private readonly ILogger<MenuItemController> _logger = logger;


    [HttpGet("GetMenuItens")]
    public async Task<IActionResult> GetMenuItens([FromQuery] string? category)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _menuItemService.GetMenuItemAsync(category);

        if (result is null)
            return NotFound("Menu category not found.");

        return Ok(result);
    }

}
