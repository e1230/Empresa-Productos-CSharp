
using System.Diagnostics;
using Empresa_Productos.Models;
using Empresa_Productos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Empresa_Productos.Controller;

[Route("api/[Controller]")]
public class LoginController : ControllerBase
{
  private readonly ILoginService _loginService;

  public LoginController(ILoginService loginService)
  {
    _loginService = loginService;
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginUser userLogin)
  {
    return await _loginService.Login(userLogin);
  }
}