using AutoMapper;
using LocacaoDeVeiculos.Dtos.Carro;
using LocacaoDeVeiculos.Models;

namespace LocacaoDeVeiculos.Profiles
{
    public class CarroProfile:Profile
    {
        public CarroProfile()
        {
            CreateMap<CreateCarroDto, Carro>();
            CreateMap<ReadCarroDto, Carro>();
            CreateMap<Carro, ReadCarroDto>();
        }
    }
}
