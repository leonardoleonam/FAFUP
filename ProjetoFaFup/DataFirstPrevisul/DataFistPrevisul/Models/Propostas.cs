using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class Propostas
    {
        public Propostas()
        {
            PropostaArquivos = new HashSet<PropostaArquivos>();
            PropostaAssistencias = new HashSet<PropostaAssistencias>();
            PropostaEventoLocais = new HashSet<PropostaEventoLocais>();
            PropostaGarantias = new HashSet<PropostaGarantias>();
            PropostaJson = new HashSet<PropostaJson>();
            PropostaPessoas = new HashSet<PropostaPessoas>();
        }

        public int Id { get; set; }
        public int IdDeparaProduto { get; set; }
        public string Protocolo { get; set; }
        public string NumProposta { get; set; }
        public int CodCor { get; set; }
        public string CodInterv { get; set; }
        public int? CodSucursal { get; set; }
        public string Gerente { get; set; }
        public string Sucursal { get; set; }
        public short Status { get; set; }
        public DateTime DtCriacao { get; set; }
        public string TipoCalculo { get; set; }
        public decimal Corretagem { get; set; }
        public decimal Agenciamento { get; set; }
        public decimal ProLabore { get; set; }
        public DateTime DtIniVigencia { get; set; }
        public DateTime DtFimVigencia { get; set; }
        public string TipoCusteio { get; set; }
        public decimal CusteioEmpresa { get; set; }
        public decimal CusteioSegurado { get; set; }
        public string TipoAdesao { get; set; }
        public int QtdPrestadores { get; set; }
        public int QtdSocios { get; set; }
        public int QtdEstagiarios { get; set; }
        public int QtdMotoboys { get; set; }
        public int QtdInativas { get; set; }
        public int QtdAfastados { get; set; }
        public int QtdNaoFuncionarios { get; set; }
        public int QtdAlunos { get; set; }
        public int QtdClientes { get; set; }
        public int QtdOutros { get; set; }
        public int QtdSindicalizados { get; set; }
        public int QtdDiretores { get; set; }
        public int QtdAssociados { get; set; }
        public int Ate65Anos { get; set; }
        public int Ate70Anos { get; set; }
        public int Ate75Anos { get; set; }
        public int Mais71Anos { get; set; }
        public int Mais76Anos { get; set; }
        public int IdadeMaxima { get; set; }
        public int? Multiplicador { get; set; }
        public decimal? AgravoTecnico { get; set; }
        public string TipoCobranca { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Cc { get; set; }
        public string Periodicidade { get; set; }
        public short DiaVencimento { get; set; }
        public string AgravoAtividade { get; set; }
        public string NossoNumero { get; set; }
        public int? TotalGrupos { get; set; }
        public DateTime DtEtl { get; set; }
        public int SitEtl { get; set; }
        public DateTime? DtUltimoProcessamento { get; set; }
        public string CodProcessamento { get; set; }
        public int? SitProcessamento { get; set; }
        public int? NumTentativa { get; set; }
        public string Apolice { get; set; }
        public string Destino { get; set; }
        public string Contrato { get; set; }
        public DateTime? DtEmissao { get; set; }
        public int? DiaMovimentacao { get; set; }
        public int QtdEspectadores { get; set; }
        public int QtdParticipantes { get; set; }
        public int QtdOrganizadores { get; set; }
        public int QtdDias { get; set; }
        public int QtdHoras { get; set; }
        public string NomeEvento { get; set; }
        public int? TipoEvento { get; set; }
        public int? LocalEvento { get; set; }

        public Produtos IdDeparaProdutoNavigation { get; set; }
        public ICollection<PropostaArquivos> PropostaArquivos { get; set; }
        public ICollection<PropostaAssistencias> PropostaAssistencias { get; set; }
        public ICollection<PropostaEventoLocais> PropostaEventoLocais { get; set; }
        public ICollection<PropostaGarantias> PropostaGarantias { get; set; }
        public ICollection<PropostaJson> PropostaJson { get; set; }
        public ICollection<PropostaPessoas> PropostaPessoas { get; set; }
    }
}
