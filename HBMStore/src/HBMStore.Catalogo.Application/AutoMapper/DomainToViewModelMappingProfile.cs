using AutoMapper;
using HBMStore.Catalogo.Application.ViewModels;
using HBMStore.Catalogo.Domain;

namespace HBMStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(d => d.Largura, mo => mo.MapFrom(me => me.Dimensoes.Largura))
                .ForMember(d => d.Altura, mo => mo.MapFrom(me => me.Dimensoes.Altura))
                .ForMember(d => d.Profundidade, mo => mo.MapFrom(me => me.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
