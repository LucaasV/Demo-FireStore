using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoFireStore.Infra.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
		Task<TEntity> Create(Dictionary<string, object> obj);
		Task<TEntity> Update(Dictionary<string, object> obj);
		Task<TEntity?> GetById(string id);
		Task<ICollection<TEntity>> GetAll();
		Task<bool> Delete(string id);
	}
}
