using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entidades
{
    public class Proposta
    {
        public Proposta()
        {
            GuidProposta = Guid.NewGuid();
            DataInclusao = DateTime.Now;
        }

        public int PropostaId { get; set; }

        public Guid GuidProposta { get; set; }

        public int CodCorretor { get; set; }

        public string Status { get; set; }

        public DateTime DataInclusao { get; set; }

        public string Protocolo { get; set; }         

        public string PropostaJson { get; set; }      
    }
}
