using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Domain.Enums
{
    public enum StatusGeracaoLog
    {
        [Description("ERRO")]
        Erro = -1,        

        [Description("SUCESSO")]
        Sucesso = 1
    }
}
