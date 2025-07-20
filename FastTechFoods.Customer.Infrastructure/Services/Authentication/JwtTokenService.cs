using FastTechFoods.Customer.Application.Interfaces.Services.Authentication;
using FastTechFoods.Customer.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastTechFoods.Customer.Infrastructure.Services.Authentication;
public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _config;
    public JwtTokenService(IConfiguration config) => _config = config;

    public string GenerateToken(CustomerEntity customerEntity)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, customerEntity.Id.ToString()),
            new Claim(ClaimTypes.Email, customerEntity.Email)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
