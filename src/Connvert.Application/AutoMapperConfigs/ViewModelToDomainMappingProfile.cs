using AutoMapper;
using Connvert.Application.Model;
using Connvert.Domain.DTOs;

namespace Connvert.Application.AutoMapperConfigs
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<NoticiasModel, Noticias>();
            CreateMap<ConsultaNoticiasModel, Noticias>();
        }
    }
}
