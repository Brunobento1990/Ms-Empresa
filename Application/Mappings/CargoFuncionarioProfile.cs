using Application.Dtos.CargoFuncionarioDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class CargoFuncionarioProfile : Profile
    {
        public CargoFuncionarioProfile()
        {
            CreateMap<CargoFuncionario,  CargoFuncionarioViewDto>().ReverseMap();
        }
    }
}
