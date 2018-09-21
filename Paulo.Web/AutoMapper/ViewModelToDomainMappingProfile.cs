using AutoMapper;
using Paulo.Data.Entities;
using Paulo.Web.ViewModels;

namespace Paulo.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FilmeViewModel, Filme>()
                .ForSourceMember(dto => dto.DataDeCadastro, opt => opt.Ignore())
                .ForSourceMember(dto => dto.DataDeAtualizacao, opt => opt.Ignore());

            CreateMap<GeneroViewModel, Genero>()
                .ForSourceMember(dto => dto.DataDeCadastro, opt => opt.Ignore())
                .ForSourceMember(dto => dto.DataDeAtualizacao, opt => opt.Ignore());

            CreateMap<UsuarioViewModel, Usuario>()
                .ForSourceMember(dto => dto.DataDeCadastro, opt => opt.Ignore())
                .ForSourceMember(dto => dto.DataDeAtualizacao, opt => opt.Ignore());

            CreateMap<LocacaoViewModel, Locacao>()
                .ForSourceMember(dto => dto.DataDeCadastro, opt => opt.Ignore())
                .ForSourceMember(dto => dto.DataDeAtualizacao, opt => opt.Ignore());
        }
    }
}