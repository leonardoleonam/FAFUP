using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entidades
{
    public class ObterLiConcordo
    {
        public ObterLiConcordo() { }

        public DateTime Data { get; set; }

        public string DescricaoStatus { get; set; }

        public string Status { get; set; }

        public string Conteudo { get; set; }
    }
}
