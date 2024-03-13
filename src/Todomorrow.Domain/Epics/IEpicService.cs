using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.Epics
{
    public interface IEpicService
    {
        Task<Epic> Create(Epic epic);
        Task<Epic> Update(Epic epic);
        Task<Epic> GetById(Guid epicId);
        Task<List<Epic>> GetAll();
    }
}
