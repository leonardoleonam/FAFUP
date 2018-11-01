using System.ComponentModel;

namespace Application.Domain.Enums
{
    public enum StatusPropostaEnum
    {
        [Description("ERRO")]
        Erro = -1,

        [Description("LOTE ARQUIVO INCONSISTENTE")]
        LoteArquivoInconsistente = -2,

        [Description("NÃO DEFINIDO")]
        NaoDefinido = 0,
        
        [Description("ALOCADO")]
        Alocado = 1,

        [Description("EXECUTANDO")]
        Executando = 2,

        [Description("SUCESSO")]
        Sucesso = 3,

    }
}
