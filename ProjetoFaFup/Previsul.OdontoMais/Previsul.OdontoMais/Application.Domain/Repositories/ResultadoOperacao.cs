namespace Application.Domain.Repositories
{
    public class ResultadoOperacao
    {
        public ResultadoOperacao(bool sucesso, int linhasAfetadas = 0)
        {
            Sucesso = sucesso;
            LinhasAfetadas = linhasAfetadas;
        }

        public int LinhasAfetadas { get; set; }

        public bool Sucesso { get; }

        public string MensagemErro { get; set; }
    }
}