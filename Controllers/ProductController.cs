using Microsoft.AspNetCore.Mvc;
using Empresa_Productos.Services;
using Empresa_Productos.Models;

namespace Empresa_Productos.Controller;

[Route("api/[Controller]")]
public class ProductController : ControllerBase
{
  protected readonly IProductService productService;

  public ProductController(IProductService service)
  {
    productService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(productService.Get());
  }
  [HttpPost]
  public IActionResult Post([FromBody] Product product)
  {
    productService.Save(product);
    return Ok();
  }
  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Product product)
  {
    productService.Update(product, id);
    return Ok();
  }
  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    productService.Delete(id);
    return Ok();
  }
}