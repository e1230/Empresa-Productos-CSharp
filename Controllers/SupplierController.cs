using Microsoft.AspNetCore.Mvc;
using Empresa_Productos.Services;
using Empresa_Productos.Models;

namespace Empresa_Productos.Controller;

[Route("api/[Controller]")]
public class SupplierController : ControllerBase
{
  protected readonly ISupplierService supplierService;

  public SupplierController(ISupplierService service)
  {
    supplierService = service;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    try
    {
      var response = await supplierService.Get();
      return Ok(response);
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Supplier supplier)
  {
    try
    {
      await supplierService.Save(supplier);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(string id, [FromBody] Supplier supplier)
  {
    try
    {
      await supplierService.Update(supplier, id);
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
      await supplierService.Delete(id);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
}