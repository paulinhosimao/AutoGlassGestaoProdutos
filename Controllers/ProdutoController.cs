using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAutoGlass.Models;
using TesteAutoGlass.Dtos;
using TesteAutoGlass.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace TesteAutoGlass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutosService _produtoService;
        private readonly IMapper _mapper;
    

    public ProdutoController(IProdutosService produtoService, IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoDto>> GetProduto(int id)
    {
        var produto = await _produtoService.GetProdutoByIdAsync(id);
        if (produto == null) return NotFound();
        return _mapper.Map<ProdutoDto>(produto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetProdutos([FromQuery] string filter, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var produtos = await _produtoService.GetProdutosFiltroAsync(filter, pageNumber, pageSize);
        return Ok(_mapper.Map<IEnumerable<ProdutoDto>>(produtos));
    }

        [HttpPost]
        public async Task<IActionResult> AddProduto([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                var produto = _mapper.Map<Produtos>(produtoDto);
                await _produtoService.AddProdutoAsync(produto);

                return CreatedAtAction(nameof(GetProduto), new { id = produto.IdProduto }, produtoDto);
                // Retorna um status 201 (Created) com a localização do recurso e o DTO do produto
            }
            catch (Exception ex)
            {
                // Log de erro pode ser útil para depuração
                // _logger.LogError(ex, "Erro ao adicionar produto.");

                return StatusCode(500, $"Erro ao adicionar produto: {ex.Message}");
                // Retorna um status 500 (Erro interno do servidor) e uma mensagem de erro detalhada
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] ProdutoDto produtoDto)
        {
            if (id != produtoDto.IdProduto)
            {
                return BadRequest("O ID do produto na URL não corresponde ao ID do produto no corpo da requisição.");
            }

            var product = _mapper.Map<Produtos>(produtoDto);

            try
            {
                await _produtoService.UpdateProdutoAsync(product);
                return Ok("Produto atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                // Log de erro pode ser útil para depuração
                // _logger.LogError(ex, "Erro ao atualizar produto.");

                return StatusCode(500, $"Erro ao atualizar produto: {ex.Message}");
            }
        }



        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        try
        {
            await _produtoService.DeleteProdutoAsync(id);
            return Ok("Produto excluído com sucesso.");
        }
        catch (Exception ex)
        {
            // Log de erro pode ser útil para depuração
            // _logger.LogError(ex, "Erro ao excluir produto.");

            return StatusCode(500, $"Erro ao excluir produto: {ex.Message}");
        }
    }





    }
}
