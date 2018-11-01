using System.Collections.Generic;

namespace Application.Domain
{
    public class RetornoServico<TObject> : RetornoServicoBase
        where TObject : class
    {
        protected RetornoServico(TObject objetoRetorno)
        {
            _sucesso = true;
            ObjetoRetorno = objetoRetorno;
        }

        protected RetornoServico(ErroEnum erroEnum, IEnumerable<string> erros)
        {
            _sucesso = false;
            _erroEnum = erroEnum;
            _erros = erros;
        }

        public TObject ObjetoRetorno { get; }

        public static RetornoServico<TObject> SucessoRetorno(TObject retorno)
        {
            return new RetornoServico<TObject>(retorno);
        }

        public static RetornoServico<TObject> RetornoErro(ErroEnum motivo, string erro)
        {
            return new RetornoServico<TObject>(motivo, new[] { erro });
        }

        public static RetornoServico<TObject> RetornoErro(ErroEnum erroEnum, IEnumerable<string> erros)
        {
            return new RetornoServico<TObject>(erroEnum, erros);
        }
    }
}