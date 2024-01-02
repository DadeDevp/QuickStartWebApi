using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStartWebApi.Models;
using QuickStartWebApi.Repositories;
using System.Threading.Tasks;

namespace QuickStartWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            return Ok(await _categoriaRepository.GetAllAsync());
        }

        // GET: api/Categoria/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        // GET: api/Categoria/Produtos
        [HttpGet("Produtos")]
        public async Task<IActionResult> GetCategoriasComProdutos()
        {
            var categorias = await _categoriaRepository.GetCategoriasComProdutosAsync();
            return Ok(categorias);
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

            await _categoriaRepository.AddAsync(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaId }, categoria);
        }

        // PUT: api/Categoria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            await _categoriaRepository.UpdateAsync(categoria);
            return NoContent();
        }

        // DELETE: api/Categoria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            await _categoriaRepository.DeleteAsync(categoria);
            return NoContent();
        }
    }

}
