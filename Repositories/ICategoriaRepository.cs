using QuickStartWebApi.Models;

namespace QuickStartWebApi.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriasComProdutosAsync();
    }
}
