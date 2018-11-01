using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class Estipulante
    {
        public int id { get; set; }
        public string apolice { get; set; }
        public int? idCorretor { get; set; }
        public string cnpjEstipulante { get; set; }
        public string razaoSocialEstipulante { get; set; }
        public string enderecoEstipulante { get; set; }
        public string telefoneEstipulante { get; set; }
        public string cnpjSubEstipulante { get; set; }
        public string razaoSocialSubEstipulante { get; set; }
        public string enderecoSubEstipulante { get; set; }
        public string telefoneSubEstipulante { get; set; }
        public decimal IS { get; set; }
        public decimal agenciamento { get; set; }
        public decimal corretagem { get; set; }
        public decimal proLabore { get; set; }
        public string codigoSusep { get; set; }
        public bool? ativo { get; set; }
        public DateTime? dataCriacao { get; set; }
        public List<Produto> produtos { get; set; }
        public Usuario corretor { get; set; }
    }
}
