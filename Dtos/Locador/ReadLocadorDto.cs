using System.ComponentModel.DataAnnotations;
using LocacaoDeVeiculos.Dtos.Locacao;

namespace LocacaoDeVeiculos.Dtos.Locador
{
    public class ReadLocadorDto
    {
        [Required]
        public string? Nome { get; set; }
        [StringLength(11, ErrorMessage = "CPF inválido!")]
        [Key]
        [Required]
        public string? Cpf { get; set; }
        public ICollection<ReadLocacaoDto>? Locacoes { get; set; }
    }
}
