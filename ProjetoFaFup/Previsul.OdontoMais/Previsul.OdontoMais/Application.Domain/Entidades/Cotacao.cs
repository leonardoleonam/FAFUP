using Application.Domain.Entidades.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Domain.Entidades
{
    public class Cotacao
    {
        public Cotacao()
        {
            Guid = Guid.NewGuid();
            DatInclusao = DateTime.Now;
            Status = CotacaoStatusEnum.Inicializada;
            Historico = new List<CotacaoHistorico>();
        }

        public int Id { get; set; }

        public Guid Guid { get; set; }

        public int CodCorretor { get; set; }

        public CotacaoStatusEnum Status { get; set; }

        public DateTime DatInclusao { get; set; }

        public string Json { get; set; }

        public DetalheCotacao DetalheCotacao => string.IsNullOrEmpty(Json) == false ? JsonConvert.DeserializeObject<DetalheCotacao>(Json) : new DetalheCotacao();

        public virtual ICollection<CotacaoHistorico> Historico { get; set; }

        public void AdicionarHistorico()
        {
            Historico.Add
                (
                   new CotacaoHistorico
                   {                       
                       GuidCotacaoHistorico = Guid,
                       DtCriacao = DateTime.Now,
                       CodCorretor = CodCorretor,
                       CotacaoHistoricoJson = Json
                   }
                );
        }
    }
}
