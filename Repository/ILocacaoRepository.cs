using LocacaoDeVeiculos.Dtos.Locacao;
using LocacaoDeVeiculos.Models;

namespace LocacaoDeVeiculos.Repository
{
    public interface ILocacaoRepository
    {
        Task Add(CreateLocacaoDto model);
        Task<IEnumerable<ReadLocacaoDto>> GetLocacoes();
    }
}
