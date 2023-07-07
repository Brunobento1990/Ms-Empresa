using Application.Dtos.ServicosExecutadosDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ServicoExecutadoProfile : Profile
    {
        public ServicoExecutadoProfile()
        {
             CreateMap<ServicoExecutado, ServicoExecutadoCreateDto>().ReverseMap();
             CreateMap<ServicoExecutado, ServicoExecutadoViewDto>().ReverseMap();
        }
    }
}
