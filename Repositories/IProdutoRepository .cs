using QuickStartWebApi.Models;

namespace QuickStartWebApi.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutosByCategoriaAsync(int categoriaId);
    }

}
