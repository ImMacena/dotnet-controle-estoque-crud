using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces
{
    public interface IVendaRepository : IRepository<Venda>
    {
        IEnumerable<Venda> GetBySeller(int id);
        IEnumerable<Venda> GetByBuyer(int id);
        IEnumerable<Venda> GetByDate(DateTime date);
    }
}