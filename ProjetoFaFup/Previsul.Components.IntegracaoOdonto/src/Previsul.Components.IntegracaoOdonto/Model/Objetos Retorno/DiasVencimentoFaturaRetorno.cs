using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class DiasVencimentoFaturaRetorno
    {
        public DiasVencimentoFaturaRetorno() { }

        public List<DiaVencimentoFatura> DiaVencimentoFaturaList { get; set; }
    }

    public class DiaVencimentoFatura
    {
        public DiaVencimentoFatura() { }

        public int Id { get; set; }

        public int DiaVencimento { get; set; }
    }

}
