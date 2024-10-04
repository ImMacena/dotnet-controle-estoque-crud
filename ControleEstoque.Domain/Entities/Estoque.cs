namespace ControleEstoque.Domain.Entities
{
    public class Estoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public required virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}