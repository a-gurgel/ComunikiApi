using AutoMapper;
using ComunikiApi.Data;
using ComunikiApi.Dtos;
using ComunikiApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComunikiAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutoController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public ProdutoController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um novo produto ao banco de dados
    /// </summary>
    /// <param name="produtoDto">Objeto com os campos necessários para criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public IActionResult AdicionaProduto([FromBody] ProdutoDto produtoDto)
    {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProdutoId),
            new { id = produto.Id },
            produto);
    }

    [HttpGet]
    public IEnumerable<Produto> RecuperaProduto([FromQuery] int skip = 0,
        [FromQuery] int take = 20)
    {
        return _context.Produtos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProdutoId(int id)
    {
        var produto = _context.Produtos
            .FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    /// <summary>
    /// Atualiza um produto ao banco de dados
    /// </summary>
    /// <param name="id">Objeto com os campos necessários para atualizãção de um produto</param>
    /// <param name="produtoDto">Objeto com os campos necessários para atualizãção de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizaProduto(int id,
         [FromBody] ProdutoDto produtoDto)
    {
        var produto = _context.Produtos.FirstOrDefault(
            produto => produto.Id == id);
        if (produto == null) return NotFound();
        _mapper.Map(produtoDto, produto);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Exclui o produto do banco de dados
    /// </summary>
    /// <param name="id">Objeto com os campos necessários para exclusão de um produto</param>
    [HttpDelete("{id}")]
    public IActionResult DeletaProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(
            produto => produto.Id == id);
        if (produto == null) return NotFound();
        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}


