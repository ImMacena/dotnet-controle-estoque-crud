namespace ControleEstoque.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T? GetById(int Id);
        T? Update(int Id, T entity);
        T? Remove(int Id);
    }
}