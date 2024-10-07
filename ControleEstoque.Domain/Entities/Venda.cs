namespace ControleEstoque.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public required virtual User Vendedor { get; set; }
        public int CompradorId { get; set; }
        public required virtual User Comprador { get; set; }
        public DateTime DataVenda { get; set; }
    }
}