using System.ComponentModel.DataAnnotations;

namespace LocacaoDeVeiculos.Models
{
    public class Locador
    {
        [Required]
        public string? Nome { get; set; }
        [StringLength(11,ErrorMessage ="CPF inválido!")]
        [Key]
        [Required]
        public string? Cpf { get; set; }

        public ICollection<Locacao>? Locacoes { get; set; }

    }
}
