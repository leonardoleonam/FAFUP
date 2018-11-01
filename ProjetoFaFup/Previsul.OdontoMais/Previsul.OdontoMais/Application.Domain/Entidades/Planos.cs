using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Application.Domain.Entidades
{
    public class Planos
    {
        public Planos() { }

        //public int IdPlano { get; set; }

        //public int QtdadeVidas { get; set; }

        //public DateTime Data { get; set; }

        //public string DescricaoStatus { get; set; }

        //public string Status { get; set; }

        public List<OpcoesPlanos> OpcoesPlanos { get; set; }
    }

    public class OpcoesPlanos
    {
        public OpcoesPlanos() { }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string TipoContratacao { get; set; }

        public List<string> Coberturas { get; set; }        

        public List<Valores> Valores { get; set; }
    }

    public class Valores
    {
        public  Valores() { }

        public string QuantidadeVidasAte { get; set; }

        public string QuantidadeVidasDe { get; set; }

        public string ValorPremioIndividual { get; set; }

        public string ValorPremioIndividualFmt { get; set; }
    }
}
