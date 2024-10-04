namespace ControleEstoque.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Imagem { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public required virtual Categoria Categoria { get; set; }
    }
}