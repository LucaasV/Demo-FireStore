using DemoFireStore.Domain.Domain;
using DemoFireStore.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFireStore.Infra.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {

    }
}
