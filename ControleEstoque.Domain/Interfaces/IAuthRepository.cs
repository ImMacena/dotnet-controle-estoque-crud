using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces
{
    public interface IAuthRepository
    {
        User? Signin(string email, string senha);
        bool Signout();
    }
}