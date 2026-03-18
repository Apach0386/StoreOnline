using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using StoreOnline.Domain.UseCases.UserUseCases.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreOnline.Domain.Services.Token;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GetToken(UserModel model)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:SecretKey"]!));
        var claims = new List<Claim> 
        {
            new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),            
            new Claim(ClaimTypes.Email, model.Email),
            new Claim(ClaimTypes.MobilePhone, model.PhoneNumber)
        };

        foreach (var item in model.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, item));
        }

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Auth:ExpiersInMinutes"]!)),
            SigningCredentials = creds            
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
