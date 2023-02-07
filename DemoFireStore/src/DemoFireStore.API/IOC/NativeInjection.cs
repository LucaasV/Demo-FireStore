

using DemoFireStore.Infra.Interface;
using DemoFireStore.Infra.Repository;
using DemoFireStore.Service.Interface;
using DemoFireStore.Service.Service;

namespace DemoFireStore.API.IOC;

public static class NativeInjection
{
    public static void InjectDependecies(IServiceCollection services)
    {

        //services.AddScoped<IBaseRepository, BaseRepository>();
       //services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IPessoaRepository, PessoaRepository>();

       

    }
}