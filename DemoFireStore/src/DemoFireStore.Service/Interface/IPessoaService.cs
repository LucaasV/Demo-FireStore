using DemoFireStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFireStore.Service.Interface
{
    public interface IPessoaService :IBaseService<Pessoa>
    {
        Task<Pessoa> Create(Pessoa pessoa);
        Task<Pessoa> Update(Pessoa pessoa);
    }
}
