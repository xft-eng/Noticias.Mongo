using AutoMapper;
using Connvert.Application.Model;
using Connvert.Domain.DTOs;

namespace Connvert.Application.AutoMapperConfigs
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Noticias, NoticiasModel>();
        }
    }
}
