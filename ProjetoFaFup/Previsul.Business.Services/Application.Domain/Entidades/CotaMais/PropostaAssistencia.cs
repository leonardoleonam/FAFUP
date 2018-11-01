namespace Application.Domain.Entidades.CotaMais
{
    public class PropostaAssistencia
    {
        public int Id { get; set; }

        public virtual Proposta Proposta { get; set; }

        public int IdProposta { get; set; }

        public int IdDeparaProdutoAssistencia { get; set; }

        public string Codigo { get; set; }

        public decimal ValorIndividual { get; set; }

        public decimal ValorGrupo { get; set; }

        public decimal ValorPlano { get; set; }
    }
}