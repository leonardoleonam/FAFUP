using System;
using System.Collections.Generic;
using Application.Domain.Enums;
using Application.Domain.Entidades.DePara;
namespace Application.Domain.Entidades.CotaMais
{
    public class Proposta
    {
        public Proposta()
        {
            PropostaAssistencias = new List<PropostaAssistencia>();
            PropostaGarantias = new List<PropostaGarantia>();
            PropostaJson = new List<PropostaJson>();
            PropostaPessoas = new List<PropostaPessoa>();
            PropostaArquivos = new List<PropostaArquivo>();
        }

        public int Id { get; set; }

        public int IdDeparaProduto { get; set; }

        public Produto Produto { get; set; }

        public string Protocolo { get; set; }

        public string NumProposta { get; set; }

        public int CodCorretor { get; set; }

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

        public StatusPropostaEnum SitProcessamento { get; set; }

        public int? NumTentativa { get; set; }

        public string Apolice { get; set; }

        public string Destino { get; set; }

        public string Contrato { get; set; }

        public DateTime? DtEmissao { get; set; }

        public int? DiaMovimentacao { get; set; }

        public virtual ICollection<PropostaAssistencia> PropostaAssistencias { get; set; }

        public virtual ICollection<PropostaGarantia> PropostaGarantias { get; set; }

        public virtual ICollection<PropostaJson> PropostaJson { get; set; }

        public virtual ICollection<PropostaPessoa> PropostaPessoas { get; set; }

        public virtual ICollection<PropostaArquivo> PropostaArquivos { get; set; }
    }
}
