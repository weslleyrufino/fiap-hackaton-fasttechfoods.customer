using FastTechFoods.Customer.Application.Interfaces.Services.Authentication;
using FastTechFoods.Customer.Application.ViewModel.Login;
using Microsoft.AspNetCore.Mvc;

namespace FastTechFoods.Customer.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService, IJwtTokenService tokens) : ControllerBase
{
    private readonly IAuthService _authService = authService;
    private readonly IJwtTokenService _tokens = tokens;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel vm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // DADOS ABAIXO SÓ ESTÃO AQUI PARA FACILITAR O TESTE DOS PROFESSORES. ÓBVIAMENTE QUE NÃO FICARIAM EM UM CENÁRIO REAL.

        // Login Joselito
        //{
        //    "email": "joselito@yahoo.com.br",
        //    "cpf": "69036452090",
        //    "password": "CustomerJoselito-123!"
        //}

        // Login Maria
        //{    "email": "maria@hotmail.com",
        //    "cpf": "07187176007",
        //    "password": "CustomerMaria-123!"
        //}

        var customer = await _authService.ValidateCredentialsAsync(vm.CPF, vm.Email, vm.Password);
        if (customer is null)
            return Unauthorized("Invalid E-mail/CPF or password.");

        // TODO: Gerar JWT e retornar aqui.
        var jwt = _tokens.GenerateToken(customer);

        return Ok(new { Message = "Successfully authenticated.", token = jwt });
    }
}
