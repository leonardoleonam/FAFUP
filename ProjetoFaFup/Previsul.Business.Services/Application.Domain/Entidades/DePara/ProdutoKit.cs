namespace Application.Domain.Entidades.DePara
{
    public class ProdutoKit
    {
        public int Id { get; set; }

        public int IdDeparaProduto { get; set; }

        public string Nome { get; set; }

        public int TipoImpressao { get; set; }

        public string CodFormularios { get; set; }

        public bool Ativo { get; set; }
    }
}