using System.ComponentModel.DataAnnotations;
using LocacaoDeVeiculos.Enums;
using LocacaoDeVeiculos.Migrations;

namespace LocacaoDeVeiculos.Dtos.Carro
{
    public class CreateCarroDto
    {
        [Required]
        public int? Quilometragem { get; set; }
        [Required]
        public float? Combustivel { get; set; }
        [Required]
        public double? Diaria { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public TipoCarro Tipo { get; set; }
        public bool Locado { get; set; }=false;
    }
}
