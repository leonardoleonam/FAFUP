﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class ProdutoFunerais
    {
        public ProdutoFunerais()
        {

        }

        public int id { get; set; }
        public int? idProduto { get; set; }
        public string descricao { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
