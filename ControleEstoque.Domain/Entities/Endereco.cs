using ControleEstoque.Domain.Enums;

namespace ControleEstoque.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public UF EstadoSigla { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
    }
}