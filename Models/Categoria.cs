using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace QuickStartWebApi.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public required string Nome { get; set; }

        // Escondendo a propriedade Produtos do Swagger e outras operações de serialização
        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }

        //Importante inicializar a lista de produtos no construtor da classe
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
    }
}
