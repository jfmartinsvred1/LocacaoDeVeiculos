using System.ComponentModel.DataAnnotations;
using LocacaoDeVeiculos.Enums;

namespace LocacaoDeVeiculos.Dtos.Carro
{
    public class ReadCarroDto
    {
        public string CarroId { get; set; }=string.Empty;
        [Required]
        public int Quilometragem { get; set; }
        [Required]
        public float Combustivel { get; set; }
        [Required]
        public double Diaria { get; set; }
        [Required]
        public string Modelo { get; set; }=string.Empty;
        [Required]
        public TipoCarro Tipo { get; set; }
        [Required]
        public bool Locado { get; set; }
    }
}
