using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendApp.Services
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(int id);
    }
}