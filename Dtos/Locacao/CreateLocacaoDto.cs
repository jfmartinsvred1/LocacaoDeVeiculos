using System.ComponentModel.DataAnnotations;

namespace LocacaoDeVeiculos.Dtos.Locacao
{

    public class CreateLocacaoDto
    {
        [Required]
        public string? LocadorCpf { get; set; }
        [Required]
        public string? CarroId { get; set; }
        [Required]
        public DateTime? DataInicio { get; set; }
        [Required]
        public DateTime? DataEntrega { get; set; }

    }
}
