using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Application.Domain
{
    public class RetornoServicoBase
    {
        protected bool _sucesso { get; set; }

        protected ErroEnum _erroEnum { get; set; }

        protected IEnumerable<string> _erros { get; set; }

        protected RetornoServicoBase()
        {
            _sucesso = true;
        }

        protected RetornoServicoBase(IEnumerable<string> erros, ErroEnum erroEnum)
        {
            _sucesso = false;
            _erroEnum = erroEnum;
            _erros = erros;
        }

        public bool Sucesso => _sucesso;

        public IEnumerable<string> Errors => _erros;

        public string ErrosSerialized => JsonConvert.SerializeObject(_erros.ToArray());

        public ErroEnum ErroEnum => _erroEnum;

        public static RetornoServicoBase SucessoRetorno(IEnumerable<Contratos.ProspectoContratoComissaoOpcao> retorno)
        {
            return new RetornoServicoBase();
        }

        public static RetornoServicoBase RetornoErro(string erro, ErroEnum erroEnum)
        {
            return new RetornoServicoBase(new[] { erro }, erroEnum);
        }

        public static RetornoServicoBase RetornoErro(IEnumerable<string> erros, ErroEnum erroEnum)
        {
            return new RetornoServicoBase(erros, erroEnum);
        }
    }
}