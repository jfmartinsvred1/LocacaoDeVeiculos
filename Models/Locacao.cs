using System.ComponentModel.DataAnnotations;

namespace LocacaoDeVeiculos.Models
{
    public class Locacao
    {
        public string LocacaoId { get; set; }=Guid.NewGuid().ToString();
        [Required]
        public string LocadorCpf { get; set; }=String.Empty;
        [Required]
        public virtual Locador? Locador { get; set; }
        [Required]
        public string CarroId { get; set; } = String.Empty;
        [Required]
        public virtual Carro? Carro { get; set; }
        [Required]
        public DateTime? DataInicio { get; set; }
        [Required]
        public DateTime? DataEntrega { get; set; }
        [Required]
        public double? Valor { get; set; }
        

        public void CalcularValor(double diaria)
        {
            if (DataInicio.HasValue && DataEntrega.HasValue)
            {
                var dias = (DataEntrega.Value - DataInicio.Value).Days;
                this.Valor = Math.Truncate(dias * diaria*100)/100;
            }
            else
            {
                throw new InvalidOperationException("Dados insuficientes para calcular o valor da locação.");
            }
        }

    }
}
