using Application.Domain.Notificacoes.Model;
using System.Collections.Generic;

namespace Application.Domain.Notificacoes
{
    public interface INotificacaoService
    {
        void EnviarEmailPropostasProcessadas(List<PropostaProcessada> propostasProcessadas);

        void EnviarEmailArquivosProcessados(List<ArquivoProcessado> arquivosProcessados);

        void EnviarEmailLogsProcessados(List<LogProcessado> logsProcessados);
    }
}
