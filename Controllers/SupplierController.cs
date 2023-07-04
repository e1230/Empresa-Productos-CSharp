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
  public IActionResult Get()
  {
    return Ok(supplierService.Get());
  }
  [HttpPost]
  public IActionResult Post([FromBody] Supplier supplier)
  {
    supplierService.Save(supplier);
    return Ok();
  }
  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Supplier supplier)
  {
    supplierService.Update(supplier, id);
    return Ok();
  }
  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    supplierService.Delete(id);
    return Ok();
  }
}