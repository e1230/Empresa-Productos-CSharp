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
  public async Task<IActionResult> Get()
  {
    try
    {
      var response = await saleService.Get();
      return Ok(response);
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
  [HttpGet("date-range")]
  public async Task<IActionResult> GetSalesByDateRange([FromQuery] string startDate, [FromQuery] string endDate)
  {
    try
    {
      var sales = await saleService.GetByDateRange(startDate, endDate);
      return Ok(sales);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(ex.Message);
    }
  }
  [HttpGet("topsellers")]
  public async Task<IActionResult> GetTopSellersByDateRange([FromQuery] string startDate, [FromQuery] string endDate)
  {
    try
    {
      var topSellers = await saleService.GetTopSellingUsersByDateRange(startDate, endDate);
      return Ok(topSellers);
    }
    catch (ArgumentException e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("topproducts")]
  public async Task<IActionResult> GetTopSellingProductsByDateRange([FromQuery] string startDate, [FromQuery] string endDate)
  {
    try
    {
      var topProducts = await saleService.GetTopSellingProductsByDateRange(startDate, endDate);
      return Ok(topProducts);
    }
    catch (ArgumentException e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Sale sale)
  {
    try
    {
      await saleService.Save(sale);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody] Sale sale)
  {
    try
    {
      await saleService.Update(sale, id);
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
      await saleService.Delete(id);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return NotFound(ex.Message);
    }
  }
}