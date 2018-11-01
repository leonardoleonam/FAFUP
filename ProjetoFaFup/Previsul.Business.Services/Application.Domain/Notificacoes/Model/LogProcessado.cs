using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Notificacoes.Model
{
    public class LogProcessado
    {
        public LogProcessado() { }        

        public string Descricao { get; set; }

        public DateTime DataUltimoProcessamento { get; set; }

        public string Mensagem { get; set; }       
    }
}
