using System;
using System.Collections.Generic;
using Application.Domain.Entidades.Enums;

namespace Application.Domain.Entidades
{
    public class DetalheCotacao
    {
        public int Id { get; set; }

        public Guid GuidCotacao { get; set; }

        public List<Planos> Planos { get; set; }

        public ComissaoAoCorretor ComissaoCorretor { get; set; }

        public Empresa Empresa { get; set; }

        public double ValorCotacao { get; set; }

        public CotacaoStatusEnum Status { get; set; }
    }
}