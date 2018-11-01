using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Domain.Enums
{
    public enum TipoDocumentoEnum
    {
        [Description("PROPOSTA")]
        Proposta = 1,

        [Description("CONDICAO")]
        Condicao = 2
    }
}
