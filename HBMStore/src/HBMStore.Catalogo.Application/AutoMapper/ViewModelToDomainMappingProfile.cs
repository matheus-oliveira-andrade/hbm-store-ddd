using AutoMapper;
using HBMStore.Catalogo.Application.ViewModels;
using HBMStore.Catalogo.Domain;

namespace HBMStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p => new Produto(p.Nome, 
                                                 p.Descricao, 
                                                 p.Ativo, 
                                                 p.Valor, 
                                                 p.CategoriaId, 
                                                 p.DataCadastro, 
                                                 p.Imagem, 
                                                 new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
