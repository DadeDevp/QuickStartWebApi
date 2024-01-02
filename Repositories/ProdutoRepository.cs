using Microsoft.EntityFrameworkCore;
using QuickStartWebApi.DBContext;
using QuickStartWebApi.Models;

namespace QuickStartWebApi.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> GetProdutosByCategoriaAsync(int categoriaId)
        {
            return await _context.Produtos
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }
    }

}
