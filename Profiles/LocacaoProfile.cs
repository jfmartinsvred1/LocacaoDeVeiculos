using AutoMapper;
using LocacaoDeVeiculos.Dtos.Locacao;
using LocacaoDeVeiculos.Models;

namespace LocacaoDeVeiculos.Profiles
{
    public class LocacaoProfile:Profile
    {
        public LocacaoProfile()
        {
            CreateMap<CreateLocacaoDto, Locacao>();
            CreateMap<Locacao, ReadLocacaoDto>();
            CreateMap<ReadLocacaoDto, Locacao>();
        }
    }
}
