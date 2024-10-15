using ControleEstoque.Domain.Enums;

namespace ControleEstoque.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Imagem { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public TipoUsuario Tipo { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco? Endereco { get; set; }
    }
}