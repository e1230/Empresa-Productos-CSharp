using Microsoft.AspNetCore.Mvc;
using Empresa_Productos.Services;
using Empresa_Productos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Empresa_Productos.Controller;

[Route("api/[Controller]")]
[Authorize(Roles = "Admin")]
public class ProductController : ControllerBase
{
  protected readonly IProductService productService;

  public ProductController(IProductService service)
  {
    productService = service;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    try
    {
      var response = await productService.Get();
      return Ok(response);
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    try
    {
      var response = await productService.GetById(id);
      return Ok(response);
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpGet("{id}/info")]
  public async Task<IActionResult> GetProductWithSupplierInfoById(Guid id)
  {
    try
    {
      var response = await productService.GetProductWithSupplierInfoById(id);
      return Ok(response);
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Product product)
  {
    try
    {
      await productService.Save(product);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody] Product product)
  {
    try
    {
      await productService.Update(product, id);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    try
    {
      await productService.Delete(id);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
}