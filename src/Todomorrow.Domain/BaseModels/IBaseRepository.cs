using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.BaseModels
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T obj);
        Task<T> Add(T obj);
        Task<List<T>> AddRange(List<T> obj);
        Task<T> Update(T obj);
        Task<T> DeleteFromContext(T obj);
        Task SaveChangesAsync();
    }
}
