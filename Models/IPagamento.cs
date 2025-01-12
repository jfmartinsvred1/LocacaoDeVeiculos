using Microsoft.OpenApi.Any;

namespace LocacaoDeVeiculos.Models
{
    public interface IPagamento
    {
        Task Pagar();
    }
}
