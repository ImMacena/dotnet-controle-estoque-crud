namespace ControleEstoque.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public required virtual Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public required virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public int? DescontoPorcentagem { get; set; } = null;
    }
}