using DemoFireStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFireStore.Service.Interface
{
    public interface IBaseService<T>
        where T : Base

    {
        //Task<T> CreateAsync(T obj);
        //Task<T> UpdateAsync(T obj);
        Task RemoveAsync(string id);
        Task<T> GetAsync(string id);
        Task<ICollection<T>> GetAllAsync();
    }
}
