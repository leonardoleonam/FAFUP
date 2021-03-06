﻿namespace Application.Domain.Entidades.DePara
{
    public partial class ProdutoAssistencia
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int IdDeparaProduto { get; set; }

        public string CodCotamais { get; set; }

        public int CodI4pro { get; set; }

        public string CodSngs { get; set; }

        public bool Ativo { get; set; }

        public int CodGrupoI4pro { get; set; }

        public int? PlanoCotamais { get; set; }

        public int CodAssistencia { get; set; }
    }
}