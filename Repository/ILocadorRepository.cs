using LocacaoDeVeiculos.Dtos.Locador;

namespace LocacaoDeVeiculos.Repository
{
    public interface ILocadorRepository
    {
        Task CriarLocador(CreateLocadorDto dto);
        Task<ReadLocadorDto> GetLocador(string cpf);
    }
}
