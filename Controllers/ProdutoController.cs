using Microsoft.AspNetCore.Mvc;
using QuickStartWebApi.Interfaces;
using QuickStartWebApi.Models;

namespace QuickStartWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            return Ok(await _produtoRepository.GetAllAsync());
        }

        // GET: api/Produto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // GET: api/Produto/Categoria/{categoriaId}
        [HttpGet("Categoria/{categoriaId}")]
        public async Task<IActionResult> GetProdutosByCategoria(int categoriaId)
        {
            var produtos = await _produtoRepository.GetProdutosByCategoriaAsync(categoriaId);
            if (produtos == null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            await _produtoRepository.AddAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = produto.ProdutoId }, produto);
        }

        // PUT: api/Produto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Dados inválidos!");
            }

            await _produtoRepository.UpdateAsync(produto);
            return NoContent();
        }

        // DELETE: api/Produto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            await _produtoRepository.DeleteAsync(produto);
            return NoContent();
        }

    }
}
