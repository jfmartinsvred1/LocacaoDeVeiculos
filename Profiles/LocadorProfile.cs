using AutoMapper;
using LocacaoDeVeiculos.Dtos.Locador;
using LocacaoDeVeiculos.Models;

namespace LocacaoDeVeiculos.Profiles
{
    public class LocadorProfile:Profile
    {
        public LocadorProfile()
        {
            CreateMap<CreateLocadorDto, Locador>();
            CreateMap<ReadLocadorDto, Locador>();
            CreateMap<Locador, ReadLocadorDto>();
            CreateMap<Locador, ReadLocadorSemLocacoesDto>();
        }
    }
}
