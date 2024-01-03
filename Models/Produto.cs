using System.Text.Json.Serialization;

namespace QuickStartWebApi.Models
{
    public class Produto
    {
        //Entity Framework já reconhece o padrao "NomedaclasseID" como a chave primária, ou pode usar a data annotation [Key]
        public int ProdutoId { get; set; }
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }

        // Escondendo a propriedade Produtos do Swagger e outras operações de serialização
        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
