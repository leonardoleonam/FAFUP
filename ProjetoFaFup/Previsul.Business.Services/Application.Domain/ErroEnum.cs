using System.ComponentModel;

namespace Application.Domain
{
    public enum ErroEnum
    {
        [Description("Validação de contrato")]
        ValidacaoContrato,

        [Description("Validação de regra de negócio")]
        RegraNegocio,

        [Description("Recurso pesquisado não encontrado")]
        RecursoNaoEncontrado,

        [Description("Ocorreu um erro ao realizar a intergração com sistema parceiro")]
        ErroIntegracao,

        [Description("Erro ao efeturar a atualização do recurso")]
        ErroAtualizacao,

        [Description("Erro ao efeturar a criação do recurso")]
        ErroCriacao,

        [Description("Erro ao efeturar a remoção do recurso")]
        ErroRemocao,

        [Description("Erro inesperado")]
        Excecao
    }
}