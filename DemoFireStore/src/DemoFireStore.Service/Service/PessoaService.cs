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
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) :base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Task<Pessoa> Create(Pessoa pessoa)
        {
            Dictionary<string, object> pessoaInsert = new Dictionary<string, object>
            {
            { "Nome", pessoa.Nome },
             { "Idade", pessoa.Idade }
            };
            return _pessoaRepository.Create(pessoaInsert);
        }

        public Task<Pessoa> Update(Pessoa pessoa)
        {
            Dictionary<string, object> pessoaUpdate = new Dictionary<string, object>
            {
            { "Nome", pessoa.Nome },
             { "Idade", pessoa.Idade }
            };
            return _pessoaRepository.Create(pessoaUpdate);
        }
    }
}
