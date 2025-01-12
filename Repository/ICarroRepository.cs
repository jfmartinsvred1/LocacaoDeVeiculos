using LocacaoDeVeiculos.Dtos.Carro;
using LocacaoDeVeiculos.Enums;
using LocacaoDeVeiculos.Models;

namespace LocacaoDeVeiculos.Repository
{
    public interface ICarroRepository
    {
        Task AddCar(CreateCarroDto dto);
        Task<IEnumerable<Carro>> GetCarros(bool disponiveis,TipoCarro tipo);
        Task LocarOuDevolver(string carroId);
        Task<Carro> GetCarById(string carroId);
    }
}
