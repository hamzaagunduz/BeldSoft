using System.Linq.Expressions;

namespace Beldsoft.Application.Interfaces
{
    // Tüm entityler için genel repository interface'i
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);                       // ID ile veri çek
        Task<IEnumerable<T>> GetAllAsync();                 // Tüm verileri çek
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); // Filtreli veri çek
        Task AddAsync(T entity);                            // Veri ekle
        Task UpdateAsync(T entity);   // async
        Task RemoveAsync(T entity);   // async
    }
}
