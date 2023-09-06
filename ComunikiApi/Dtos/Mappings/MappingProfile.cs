using AutoMapper;
using ComunikiApi.Models;

namespace ComunikiApi.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
