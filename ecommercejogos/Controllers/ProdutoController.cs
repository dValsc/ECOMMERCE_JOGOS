using ecommercejogos.Model;
using ecommercejogos.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ecommercejogos.Controllers;

[Route("~/produtos")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    private readonly IValidator<Produto> _produtoValidator;

    public ProdutoController(IProdutoService produtoService, IValidator<Produto> produtoValidator)
    {
        _produtoService = produtoService;
        _produtoValidator = produtoValidator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _produtoService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(long id)
    {
        var produto = await _produtoService.GetById(id);

        if (produto == null)
            return NotFound("Produto não encontrado!");

        return Ok(produto);
    }

    [HttpGet("nome/{nome}")]
    public async Task<ActionResult> GetByNome(string nome)
    {
        return Ok(await _produtoService.GetByNome(nome));
    }

    [HttpGet("nome/{nome}/ouconsole/{console}")]
    public async Task<ActionResult> GetByNomeOrConsole(string nome, string console)
    {
        return Ok(await _produtoService.GetByNomeOrConsole(nome, console));
    }

    [HttpGet("nome/{nome}/euconsole/{console}")]
    public async Task<ActionResult> GetByNomeandConsole(string nome, string console)
    {
        return Ok(await _produtoService.GetByNomeandConsole(nome, console));
    }

    [HttpGet("preco_inicial/{precoInicial}/preco_final/{precoFinal}")]
    public async Task<ActionResult> GetByPriceRange(decimal min, decimal max)
    {
        return Ok(await _produtoService.GetByPriceRange(min, max));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Produto produto)
    {
        var validationResult = await _produtoValidator.ValidateAsync(produto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var resposta = await _produtoService.Create(produto);

        if (resposta == null)
            return BadRequest("Categoria não encontrada");

        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromBody] Produto produto)
    {
        if (produto.Id <= 0)
            return BadRequest("Id do produto inválido");

        var validationResult = await _produtoValidator.ValidateAsync(produto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var produtoUpdate = await _produtoService.Update(produto);

        if (produtoUpdate == null)
            return NotFound("Produto e/ou categoria não encontrado(s)");

        return Ok(produtoUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var produto = await _produtoService.GetById(id);

        if (produto == null)
            return NotFound("Produto não encontrado");

        await _produtoService.Delete(produto);
        return NoContent();
    }
}
