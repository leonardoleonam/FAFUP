using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entidades
{
    public class DiaVencimentoFatura
    {
        public DiaVencimentoFatura() { }
      
        public List<DiaVencimentoFaturaList> DiaVencimentoFaturaList { get; set; }
    }

    public class DiaVencimentoFaturaList
    {
        public DiaVencimentoFaturaList() { }

        public int Id { get; set; }

        public int DiaVencimento { get; set; }
    }
}
