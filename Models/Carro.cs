using System.ComponentModel.DataAnnotations;
using LocacaoDeVeiculos.Enums;

namespace LocacaoDeVeiculos.Models
{
    public class Carro
    {

        public string CarroId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public int? Quilometragem { get; set; }
        [Required]
        public float? Combustivel { get; set; }
        [Required]
        public double Diaria { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public TipoCarro Tipo { get; set; }
        [Required]
        public bool Locado { get; set; }

        
    }
}
