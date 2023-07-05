using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Empresa_Productos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Empresa_Productos.Services;
public class LoginService : ILoginService
{
  Context context;
  private readonly IConfiguration _config;
  public LoginService(Context dbContext, IConfiguration config)
  {
    context = dbContext;
    _config = config;
  }

  public async Task<IActionResult> Login(LoginUser userLogin)
  {
    var user = await AuthenticateAsync(userLogin);
    if (user != null)
    {
      var token = Generate(user);
      return new OkObjectResult(token);
    }
    return new NotFoundObjectResult("User not found");
  }

  private async Task<User> AuthenticateAsync(LoginUser userLogin)
  {
    var currentUser = await context.Users.FirstOrDefaultAsync(user =>
      user.UserName == userLogin.UserName &&
      user.Password == userLogin.Password);

    if (currentUser != null)
    {
      return currentUser;
    }
    return null;

  }
  private string Generate(User user)
  {
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new[]{
      new Claim(ClaimTypes.NameIdentifier, user.UserName),
      new Claim(ClaimTypes.GivenName, user.Name),
      new Claim(ClaimTypes.Role, user.Role?.ToString() ?? string.Empty),
    };

    var token = new JwtSecurityToken(
      _config["Jwt:Issuer"],
      _config["Jwt:Audience"],
      claims,
      expires: DateTime.Now.AddMinutes(15),
      signingCredentials: credentials
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}

public interface ILoginService
{
  Task<IActionResult> Login(LoginUser userLogin);
}