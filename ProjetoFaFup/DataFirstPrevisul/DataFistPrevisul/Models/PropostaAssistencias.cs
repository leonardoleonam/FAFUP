using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class PropostaAssistencias
    {
        public int Id { get; set; }
        public int IdProposta { get; set; }
        public int IdDeparaProdutoAssistencias { get; set; }
        public string Codigo { get; set; }
        public decimal ValorIndividual { get; set; }
        public decimal ValorGrupo { get; set; }
        public decimal ValorPlano { get; set; }

        public Propostas IdPropostaNavigation { get; set; }
    }
}
