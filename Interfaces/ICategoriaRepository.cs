using QuickStartWebApi.Models;

namespace QuickStartWebApi.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriasComProdutosAsync();
    }
}
