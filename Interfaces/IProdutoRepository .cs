using QuickStartWebApi.Models;

namespace QuickStartWebApi.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutosByCategoriaAsync(int categoriaId);
    }

}
