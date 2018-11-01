using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class PropostaEventoLocais
    {
        public int Id { get; set; }
        public int IdProposta { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Tipo { get; set; }

        public Propostas IdPropostaNavigation { get; set; }
    }
}
