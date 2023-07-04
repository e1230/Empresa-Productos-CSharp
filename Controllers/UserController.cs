using Microsoft.AspNetCore.Mvc;
using Empresa_Productos.Services;
using Empresa_Productos.Models;

namespace Empresa_Productos.Controller;

[Route("api/[Controller]")]
public class UserController : ControllerBase
{
  protected readonly IUserService userService;

  public UserController(IUserService service)
  {
    userService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(userService.Get());
  }
  [HttpPost]
  public IActionResult Post([FromBody] User user)
  {
    userService.Save(user);
    return Ok();
  }
  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] User user)
  {
    userService.Update(user, id);
    return Ok();
  }
  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    userService.Delete(id);
    return Ok();
  }
}