using AutoMapper;
using DemoFireStore.API.ViewModel;
using DemoFireStore.Domain.Domain;
using Evo.API.ViewModels;
using Evo.Domain.Entities;
using Evo.Services.DTO;

namespace DemoFireStore.API.Configs;

#pragma warning disable CS1591
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Person
        CreateMap<PessoaCadastroViewModel, Pessoa>().ReverseMap();
        CreateMap<PessoaAtualizaViewModel, Pessoa>().ReverseMap();
        #endregion

    }
}