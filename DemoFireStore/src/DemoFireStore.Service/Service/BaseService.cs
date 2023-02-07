using DemoFireStore.Domain.Domain;
using DemoFireStore.Infra.Interface;
using DemoFireStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFireStore.Service.Service
{
    public class BaseService<T> : IBaseService<T>
        where T : Base

    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<T> GetAsync(string id)
        {
            return await _baseRepository.GetById(id);
        }

        public async Task RemoveAsync(string id)
        {
           await _baseRepository.Delete(id);
        }
    }
}
