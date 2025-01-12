using System.ComponentModel.DataAnnotations;

namespace LocacaoDeVeiculos.Dtos.Locador
{
    public class CreateLocadorDto
    {
        [Required]
        public string? Nome { get; set; }
        [StringLength(11, ErrorMessage = "CPF inválido!")]
        [Key]
        [Required]
        public string? Cpf { get; set; }

    }
}
