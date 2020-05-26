using AutoMapper;
using Paulo.Data.Entities;
using Paulo.Data.Identity.Models;
using Paulo.Web.ViewModels;

namespace Paulo.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Filme, FilmeViewModel>();
            CreateMap<Genero, GeneroViewModel>();
            CreateMap<ApplicationUser, UsuarioViewModel>();
            CreateMap<Locacao, LocacaoViewModel>();
        }
    }
}