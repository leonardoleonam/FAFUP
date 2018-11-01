using System.Collections.Generic;
using Application.Domain.Entidades.CotaMais;

namespace Application.Domain.Entidades.DePara
{
    public class Produto
    {
        public Produto()
        {
            Propostas = new HashSet<Proposta>();
        }

        public int Id { get; set; }

        public int CodProduto { get; set; }

        public string Descricao { get; set; }

        public string CodCotamais { get; set; }

        public int CodI4pro { get; set; }

        public bool Ativo { get; set; }

        public ICollection<Proposta> Propostas { get; set; }
    }
}
