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

    [HttpGet("{id}")]
    public async Task<IActionResult> FindById(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        await _repository.UpdateAsync(product);
        return CreatedAtAction(nameof(Update), new { id = product.Id }, product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _repository.AddAsync(product);
        return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
    }
}