using Application.Domain.Contratos.Enums;
using Application.Domain.Utils;
using System.Collections.Generic;

namespace Application.Domain.Contratos
{
    public class PlanoOpcao
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public TipoContratacao TipoContratacao { get; set; }

        public string TipoContratacaoDescricao => TipoContratacao.ToDescriptionString();

        public List<Especialidade> Especialidades { get; set; }

        public List<PlanoOpcaoValor> Valores { get; set; }

        public string Status { get; set; }
    }
}
