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
  public async Task<IActionResult> Get()
  {
    try
    {
      var response = await userService.Get();
      return Ok(response);
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] User user)
  {
    try
    {
      await userService.Save(user);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(string id, [FromBody] User user)
  {
    try
    {
      await userService.Update(user, id);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(string id)
  {
    try
    {
      await userService.Delete(id);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
}