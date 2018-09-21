using AutoMapper;
using Paulo.Data.Entities;
using Paulo.Web.ViewModels;

namespace Paulo.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Filme, FilmeViewModel>();
            CreateMap<Genero, GeneroViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Locacao, LocacaoViewModel>();
        }
    }
}