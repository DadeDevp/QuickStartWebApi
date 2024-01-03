using Microsoft.EntityFrameworkCore;
using QuickStartWebApi.DBContext;
using QuickStartWebApi.Interfaces;
using QuickStartWebApi.Models;

namespace QuickStartWebApi.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Categoria>> GetCategoriasComProdutosAsync()
        {
            return await _context.Categorias
                .Include(c => c.Produtos)
                .ToListAsync();
        }
    }

}
