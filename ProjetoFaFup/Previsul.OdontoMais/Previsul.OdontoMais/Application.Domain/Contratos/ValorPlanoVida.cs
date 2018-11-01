namespace Application.Domain.Contratos
{
    public class ValorPlanoVida
    {
        public ValorPlanoVida() { }

        public int IdPlanoOpcao { get; set; }

        public string Nome { get; set; }

        public string Periodicidade { get; set; }

        public double ValorDesconto { get; set; }

        public double ValorParcela { get; set; }

        public double ValorPremio { get; set; }

        public double ValorPremioIndividual { get; set; }

        public double ValorTotal1Ano { get; set; }

        public int QuantidadeVidasPlano;

        public int QuantidadeVidasTotal; 
        

    }
}