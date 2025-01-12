using System.ComponentModel.DataAnnotations;
using LocacaoDeVeiculos.Dtos.Carro;
using LocacaoDeVeiculos.Dtos.Locador;

namespace LocacaoDeVeiculos.Dtos.Locacao
{
    public class ReadLocacaoDto
    {
        public string LocacaoId { get; set; }
        [Required]
        public virtual ReadLocadorSemLocacoesDto? Locador { get; set; }
        [Required]
        public virtual ReadCarroDto? Carro { get; set; }
        [Required]
        public DateTime? DataInicio { get; set; }
        [Required]
        public DateTime? DataEntrega { get; set; }
        [Required]
        public double? Valor { get; set; }

        public ReadLocacaoDto(string locacaoId, ReadLocadorSemLocacoesDto? locador, ReadCarroDto? carro, DateTime? dataInicio, DateTime? dataEntrega, double? valor)
        {
            LocacaoId = locacaoId;
            Locador = locador;
            Carro = carro;
            DataInicio = dataInicio;
            DataEntrega = dataEntrega;
            Valor = valor;
        }
    }
}
