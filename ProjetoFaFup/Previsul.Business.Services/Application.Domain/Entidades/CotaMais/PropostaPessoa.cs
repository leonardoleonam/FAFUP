using System;

namespace Application.Domain.Entidades.CotaMais
{
    public class PropostaPessoa
    {
        public int Id { get; set; }

        public virtual Proposta Proposta { get; set; }

        public int IdProposta { get; set; }

        public string Cnpj { get; set; }

        public string Cpf { get; set; }

        public string Cei { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CodCnae { get; set; }

        public string SitCadastral { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public string Tipo { get; set; }

        public DateTime? DatNascimento { get; set; }
    }
}