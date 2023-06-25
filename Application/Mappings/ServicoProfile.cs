using Application.Dtos.ServicoDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<Servico, ServicoViewDto>().ReverseMap();
        }
    }
}
