using System.ComponentModel.DataAnnotations;

namespace Application.Domain.Entidades.Ods
{
    public class Corretor
    {        
        [Key]
        public int CodigoCorretor { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Cnpj { get; set; }

        public string Susep { get; set; }

        public string Email { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public int? Cep { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public string StatusComercial { get; set; }

        public string StatusSngs { get; set; }

        public string GerenteComercial { get; set; }

        public string Tipo { get; set; }
    }
}
