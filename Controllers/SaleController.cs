using Microsoft.AspNetCore.Mvc;
using Empresa_Productos.Services;
using Empresa_Productos.Models;

namespace Empresa_Productos.Controller;

[Route("api/[Controller]")]
public class SaleController : ControllerBase
{
  protected readonly ISaleService saleService;

  public SaleController(ISaleService service)
  {
    saleService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(saleService.Get());
  }
  [HttpPost]
  public IActionResult Post([FromBody] Sale sale)
  {
    saleService.Save(sale);
    return Ok();
  }
  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Sale sale)
  {
    saleService.Update(sale, id);
    return Ok();
  }
  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    saleService.Delete(id);
    return Ok();
  }
}