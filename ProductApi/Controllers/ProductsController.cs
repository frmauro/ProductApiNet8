using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Entities;
using ProductApi.Repositories;

namespace ProductApi.Controllers;   

[Authorize] // Exige autenticação JWT para acessar este controller
[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _repository.AddAsync(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
}