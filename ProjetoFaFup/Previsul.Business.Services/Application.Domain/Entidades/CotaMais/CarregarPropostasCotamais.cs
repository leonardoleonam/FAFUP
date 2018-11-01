using Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entidades.CotaMais
{
    public class CarregarPropostasCotamais
    {
        public CarregarPropostasCotamais() { }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DtCriacao { get; set; }

        public DateTime? DtUltimoProcessamento { get; set; }

        public int? SitProcessamento { get; set; }

        public string CodProcessamento { get; set; }

        public int? NumTentativa { get; set; }

        public bool GeradoComSucesso { get; set; }

        public bool GeradoComErro { get; set; }

        public StatusGeracaoLog SituacaoProcessamento { get; set; }        
    }
}
