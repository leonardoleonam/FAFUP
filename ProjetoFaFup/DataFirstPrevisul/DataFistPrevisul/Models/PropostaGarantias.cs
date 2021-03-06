﻿using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class PropostaGarantias
    {
        public int Id { get; set; }
        public int IdProposta { get; set; }
        public int IdDeparaProdutoCobertura { get; set; }
        public decimal Capital { get; set; }
        public decimal CapitalTotal { get; set; }
        public decimal ValorIndividual { get; set; }
        public decimal ValorGrupo { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public decimal PremioTotal { get; set; }
        public decimal Taxa { get; set; }
        public string Grupo { get; set; }
        public int Percentual { get; set; }
        public int QtdDias { get; set; }
        public decimal ValorDia { get; set; }
        public int Plano { get; set; }

        public Propostas IdPropostaNavigation { get; set; }
    }
}
