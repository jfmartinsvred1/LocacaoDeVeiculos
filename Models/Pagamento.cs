namespace LocacaoDeVeiculos.Models
{
    public abstract class Pagamento
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public double Valor { get; set; }
        public Locador Locador { get; set; }
        public DateTime Data { get; set; }

    }
}
