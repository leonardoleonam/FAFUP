using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataFistPrevisul.Models
{
    public partial class PBS_PREVISULContext : DbContext
    {
        public PBS_PREVISULContext()
        {
        }

        public PBS_PREVISULContext(DbContextOptions<PBS_PREVISULContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarregarPropostasCotamais> CarregarPropostasCotamais { get; set; }
        public virtual DbSet<Csharp> Csharp { get; set; }
        public virtual DbSet<HospPropostas> HospPropostas { get; set; }
        public virtual DbSet<Json> Json { get; set; }
        public virtual DbSet<ProdutoAssistencias> ProdutoAssistencias { get; set; }
        public virtual DbSet<ProdutoAssistencias1> ProdutoAssistencias1 { get; set; }
        public virtual DbSet<ProdutoCoberturas> ProdutoCoberturas { get; set; }
        public virtual DbSet<ProdutoCoberturas1> ProdutoCoberturas1 { get; set; }
        public virtual DbSet<ProdutoKits> ProdutoKits { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Produtos1> Produtos1 { get; set; }
        public virtual DbSet<PropostaArquivos> PropostaArquivos { get; set; }
        public virtual DbSet<PropostaAssistencias> PropostaAssistencias { get; set; }
        public virtual DbSet<PropostaEventoLocais> PropostaEventoLocais { get; set; }
        public virtual DbSet<PropostaGarantias> PropostaGarantias { get; set; }
        public virtual DbSet<PropostaJson> PropostaJson { get; set; }
        public virtual DbSet<PropostaPessoas> PropostaPessoas { get; set; }
        public virtual DbSet<Propostas> Propostas { get; set; }

        // Unable to generate entity type for table 'dbo.MIGRACAO_COBERTURAS_SNGS'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.MIGRACAO_SNGS_APOLICE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.109.10.94,1460;Database=PBS_PREVISUL;user id=APP_PBS;password=@4CUMAAVMNSL3O;Trusted_Connection=True; MultipleActiveResultSets=true;Integrated Security=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarregarPropostasCotamais>(entity =>
            {
                entity.ToTable("CARREGAR_PROPOSTAS_COTAMAIS", "LOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodProcessamento)
                    .HasColumnName("COD_PROCESSAMENTO")
                    .HasMaxLength(200);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("DT_CRIACAO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUltimoProcessamento)
                    .HasColumnName("DT_ULTIMO_PROCESSAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumTentativa).HasColumnName("NUM_TENTATIVA");

                entity.Property(e => e.SitProcessamento).HasColumnName("SIT_PROCESSAMENTO");
            });

            modelBuilder.Entity<Csharp>(entity =>
            {
                entity.HasKey(e => e.Chave);

                entity.ToTable("CSHARP", "CFG");

                entity.Property(e => e.Chave)
                    .HasColumnName("CHAVE")
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasColumnName("VALOR")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<HospPropostas>(entity =>
            {
                entity.ToTable("HOSP_PROPOSTAS", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodStatus).HasColumnName("COD_STATUS");

                entity.Property(e => e.DatLog)
                    .HasColumnName("DAT_LOG")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(4000);

                entity.Property(e => e.Protocolo)
                    .IsRequired()
                    .HasColumnName("PROTOCOLO")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Json>(entity =>
            {
                entity.ToTable("JSON", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.Ordem).HasColumnName("ORDEM");

                entity.Property(e => e.Query).HasColumnName("QUERY");
            });

            modelBuilder.Entity<ProdutoAssistencias>(entity =>
            {
                entity.HasKey(e => e.PkProdutoAssistencias);

                entity.ToTable("PRODUTO_ASSISTENCIAS", "DE_PARA");

                entity.Property(e => e.PkProdutoAssistencias).HasColumnName("PK_PRODUTO_ASSISTENCIAS");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.CodAssistencia).HasColumnName("COD_ASSISTENCIA");

                entity.Property(e => e.CodCotamais)
                    .IsRequired()
                    .HasColumnName("COD_COTAMAIS")
                    .HasMaxLength(50);

                entity.Property(e => e.CodGrupoI4pro).HasColumnName("COD_GRUPO_I4PRO");

                entity.Property(e => e.CodI4pro).HasColumnName("COD_I4PRO");

                entity.Property(e => e.CodSngs)
                    .IsRequired()
                    .HasColumnName("COD_SNGS")
                    .HasMaxLength(50);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(250);

                entity.Property(e => e.IdDeparaProduto).HasColumnName("ID_DEPARA_PRODUTO");

                entity.Property(e => e.PlanoCotamais).HasColumnName("PLANO_COTAMAIS");
            });

            modelBuilder.Entity<ProdutoAssistencias1>(entity =>
            {
                entity.HasKey(e => e.IdProdutoAssistencias);

                entity.ToTable("PRODUTO_ASSISTENCIAS", "CFG");

                entity.Property(e => e.IdProdutoAssistencias).HasColumnName("ID_PRODUTO_ASSISTENCIAS");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.CodAssistencia).HasColumnName("COD_ASSISTENCIA");

                entity.Property(e => e.CodCotamais)
                    .HasColumnName("COD_COTAMAIS")
                    .HasMaxLength(50);

                entity.Property(e => e.CodGrupo).HasColumnName("COD_GRUPO");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(250);

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.Plano).HasColumnName("PLANO");

                entity.Property(e => e.Sistema)
                    .IsRequired()
                    .HasColumnName("SISTEMA")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoAssistencias1)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSISTENCIA_PRODUTO_ID_PRODUTO");
            });

            modelBuilder.Entity<ProdutoCoberturas>(entity =>
            {
                entity.HasKey(e => e.PkProdutoCoberturas);

                entity.ToTable("PRODUTO_COBERTURAS", "DE_PARA");

                entity.Property(e => e.PkProdutoCoberturas).HasColumnName("PK_PRODUTO_COBERTURAS");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.CodCobertura).HasColumnName("COD_COBERTURA");

                entity.Property(e => e.CodCotamais)
                    .IsRequired()
                    .HasColumnName("COD_COTAMAIS")
                    .HasMaxLength(50);

                entity.Property(e => e.CodGrupoI4pro).HasColumnName("COD_GRUPO_I4PRO");

                entity.Property(e => e.CodI4pro).HasColumnName("COD_I4PRO");

                entity.Property(e => e.CodSngs)
                    .IsRequired()
                    .HasColumnName("COD_SNGS")
                    .HasMaxLength(50);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(250);

                entity.Property(e => e.IdDeparaProduto).HasColumnName("ID_DEPARA_PRODUTO");

                entity.Property(e => e.PlanoCotamais).HasColumnName("PLANO_COTAMAIS");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("SIGLA")
                    .HasMaxLength(50);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProdutoCoberturas1>(entity =>
            {
                entity.HasKey(e => e.IdProdutoCoberturas);

                entity.ToTable("PRODUTO_COBERTURAS", "CFG");

                entity.Property(e => e.IdProdutoCoberturas).HasColumnName("ID_PRODUTO_COBERTURAS");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.CodCobertura)
                    .IsRequired()
                    .HasColumnName("COD_COBERTURA")
                    .HasMaxLength(50);

                entity.Property(e => e.CodCotamais)
                    .HasColumnName("COD_COTAMAIS")
                    .HasMaxLength(50);

                entity.Property(e => e.CodGrupo).HasColumnName("COD_GRUPO");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(250);

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.Plano).HasColumnName("PLANO");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("SIGLA")
                    .HasMaxLength(50);

                entity.Property(e => e.Sistema)
                    .IsRequired()
                    .HasColumnName("SISTEMA")
                    .HasMaxLength(50);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoCoberturas1)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COBERTURAS_PRODUTO_ID_PRODUTO");
            });

            modelBuilder.Entity<ProdutoKits>(entity =>
            {
                entity.HasKey(e => e.PkProdutoKits);

                entity.ToTable("PRODUTO_KITS", "DE_PARA");

                entity.Property(e => e.PkProdutoKits).HasColumnName("PK_PRODUTO_KITS");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.CodFormularios)
                    .IsRequired()
                    .HasColumnName("COD_FORMULARIOS")
                    .HasMaxLength(1000);

                entity.Property(e => e.IdDeparaProduto).HasColumnName("ID_DEPARA_PRODUTO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(155);

                entity.Property(e => e.TipoImpressao).HasColumnName("TIPO_IMPRESSAO");
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.PkProduto);

                entity.ToTable("PRODUTOS", "DE_PARA");

                entity.Property(e => e.PkProduto).HasColumnName("PK_PRODUTO");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.CodCotamais)
                    .IsRequired()
                    .HasColumnName("COD_COTAMAIS")
                    .HasMaxLength(50);

                entity.Property(e => e.CodI4pro).HasColumnName("COD_I4PRO");

                entity.Property(e => e.CodProduto).HasColumnName("COD_PRODUTO");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Produtos1>(entity =>
            {
                entity.ToTable("PRODUTOS", "CFG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.CodCotamais)
                    .HasColumnName("COD_COTAMAIS")
                    .HasMaxLength(50);

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PropostaArquivos>(entity =>
            {
                entity.ToTable("PROPOSTA_ARQUIVOS", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodProcessamento)
                    .HasColumnName("COD_PROCESSAMENTO")
                    .HasMaxLength(200);

                entity.Property(e => e.DtUltimoProcessamento)
                    .HasColumnName("DT_ULTIMO_PROCESSAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdProposta).HasColumnName("ID_PROPOSTA");

                entity.Property(e => e.NumTentativa).HasColumnName("NUM_TENTATIVA");

                entity.Property(e => e.SitProcessamento).HasColumnName("SIT_PROCESSAMENTO");

                entity.Property(e => e.SitUploadCondicao).HasColumnName("SIT_UPLOAD_CONDICAO");

                entity.Property(e => e.SitUploadProposta).HasColumnName("SIT_UPLOAD_PROPOSTA");

                entity.HasOne(d => d.IdPropostaNavigation)
                    .WithMany(p => p.PropostaArquivos)
                    .HasForeignKey(d => d.IdProposta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSTA_ID_PROPOSTA_ARQ");
            });

            modelBuilder.Entity<PropostaAssistencias>(entity =>
            {
                entity.ToTable("PROPOSTA_ASSISTENCIAS", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("CODIGO")
                    .HasMaxLength(50);

                entity.Property(e => e.IdDeparaProdutoAssistencias).HasColumnName("ID_DEPARA_PRODUTO_ASSISTENCIAS");

                entity.Property(e => e.IdProposta).HasColumnName("ID_PROPOSTA");

                entity.Property(e => e.ValorGrupo).HasColumnName("VALOR_GRUPO");

                entity.Property(e => e.ValorIndividual).HasColumnName("VALOR_INDIVIDUAL");

                entity.Property(e => e.ValorPlano).HasColumnName("VALOR_PLANO");

                entity.HasOne(d => d.IdPropostaNavigation)
                    .WithMany(p => p.PropostaAssistencias)
                    .HasForeignKey(d => d.IdProposta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSTA_ID_PROPOSTA_ASS");
            });

            modelBuilder.Entity<PropostaEventoLocais>(entity =>
            {
                entity.ToTable("PROPOSTA_EVENTO_LOCAIS", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bairro)
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(100);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(10);

                entity.Property(e => e.Cidade)
                    .HasColumnName("CIDADE")
                    .HasMaxLength(100);

                entity.Property(e => e.Complemento)
                    .HasColumnName("COMPLEMENTO")
                    .HasMaxLength(100);

                entity.Property(e => e.Endereco)
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(100);

                entity.Property(e => e.IdProposta).HasColumnName("ID_PROPOSTA");

                entity.Property(e => e.Numero)
                    .HasColumnName("NUMERO")
                    .HasMaxLength(100);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdPropostaNavigation)
                    .WithMany(p => p.PropostaEventoLocais)
                    .HasForeignKey(d => d.IdProposta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSTA_ID_PROPOSTA_PEL");
            });

            modelBuilder.Entity<PropostaGarantias>(entity =>
            {
                entity.ToTable("PROPOSTA_GARANTIAS", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Capital).HasColumnName("CAPITAL");

                entity.Property(e => e.CapitalTotal).HasColumnName("CAPITAL_TOTAL");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("CODIGO")
                    .HasMaxLength(50);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(200);

                entity.Property(e => e.Grupo)
                    .HasColumnName("GRUPO")
                    .HasMaxLength(30);

                entity.Property(e => e.IdDeparaProdutoCobertura).HasColumnName("ID_DEPARA_PRODUTO_COBERTURA");

                entity.Property(e => e.IdProposta).HasColumnName("ID_PROPOSTA");

                entity.Property(e => e.Percentual).HasColumnName("PERCENTUAL");

                entity.Property(e => e.Plano).HasColumnName("PLANO");

                entity.Property(e => e.PremioTotal).HasColumnName("PREMIO_TOTAL");

                entity.Property(e => e.QtdDias).HasColumnName("QTD_DIAS");

                entity.Property(e => e.Taxa)
                    .HasColumnName("TAXA")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ValorDia).HasColumnName("VALOR_DIA");

                entity.Property(e => e.ValorGrupo).HasColumnName("VALOR_GRUPO");

                entity.Property(e => e.ValorIndividual).HasColumnName("VALOR_INDIVIDUAL");

                entity.HasOne(d => d.IdPropostaNavigation)
                    .WithMany(p => p.PropostaGarantias)
                    .HasForeignKey(d => d.IdProposta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSTA_ID_PROPOSTA_GAR");
            });

            modelBuilder.Entity<PropostaJson>(entity =>
            {
                entity.ToTable("PROPOSTA_JSON", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodProcessamento)
                    .IsRequired()
                    .HasColumnName("COD_PROCESSAMENTO")
                    .HasMaxLength(200);

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("DT_CRIACAO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdProposta).HasColumnName("ID_PROPOSTA");

                entity.Property(e => e.JsonRequest)
                    .IsRequired()
                    .HasColumnName("JSON_REQUEST");

                entity.Property(e => e.JsonResponse)
                    .IsRequired()
                    .HasColumnName("JSON_RESPONSE");

                entity.Property(e => e.SitProcessamento).HasColumnName("SIT_PROCESSAMENTO");

                entity.HasOne(d => d.IdPropostaNavigation)
                    .WithMany(p => p.PropostaJson)
                    .HasForeignKey(d => d.IdProposta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSTA_ID_PROPOSTA_JSON");
            });

            modelBuilder.Entity<PropostaPessoas>(entity =>
            {
                entity.ToTable("PROPOSTA_PESSOAS", "COTA_MAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bairro)
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(100);

                entity.Property(e => e.Cei)
                    .HasColumnName("CEI")
                    .HasMaxLength(20);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(10);

                entity.Property(e => e.Cidade)
                    .HasColumnName("CIDADE")
                    .HasMaxLength(100);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14);

                entity.Property(e => e.CodCnae)
                    .IsRequired()
                    .HasColumnName("COD_CNAE")
                    .HasMaxLength(10);

                entity.Property(e => e.Complemento)
                    .HasColumnName("COMPLEMENTO")
                    .HasMaxLength(30);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11);

                entity.Property(e => e.DatNascimento)
                    .HasColumnName("DAT_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Endereco)
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(100);

                entity.Property(e => e.IdProposta).HasColumnName("ID_PROPOSTA");

                entity.Property(e => e.NomeFantasia)
                    .HasColumnName("NOME_FANTASIA")
                    .HasMaxLength(200);

                entity.Property(e => e.Numero)
                    .HasColumnName("NUMERO")
                    .HasMaxLength(100);

                entity.Property(e => e.RazaoSocial)
                    .HasColumnName("RAZAO_SOCIAL")
                    .HasMaxLength(500);

                entity.Property(e => e.SitCadastral)
                    .IsRequired()
                    .HasColumnName("SIT_CADASTRAL")
                    .HasMaxLength(30);

                entity.Property(e => e.Telefone)
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(100);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdPropostaNavigation)
                    .WithMany(p => p.PropostaPessoas)
                    .HasForeignKey(d => d.IdProposta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSTA_ID_PROPOSTA_PES");
            });

            modelBuilder.Entity<Propostas>(entity =>
            {
                entity.ToTable("PROPOSTAS", "COTA_MAIS");

                entity.HasIndex(e => e.IdDeparaProduto);

                entity.HasIndex(e => e.Protocolo)
                    .HasName("UIX_PROPOTAS_PROTOCOLO")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Agencia)
                    .HasColumnName("AGENCIA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Agenciamento)
                    .HasColumnName("AGENCIAMENTO")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AgravoAtividade)
                    .HasColumnName("AGRAVO_ATIVIDADE")
                    .HasMaxLength(10);

                entity.Property(e => e.AgravoTecnico)
                    .HasColumnName("AGRAVO_TECNICO")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Apolice)
                    .HasColumnName("APOLICE")
                    .HasMaxLength(20);

                entity.Property(e => e.Ate65Anos).HasColumnName("ATE_65_ANOS");

                entity.Property(e => e.Ate70Anos).HasColumnName("ATE_70_ANOS");

                entity.Property(e => e.Ate75Anos).HasColumnName("ATE_75_ANOS");

                entity.Property(e => e.Banco)
                    .HasColumnName("BANCO")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodCor).HasColumnName("COD_COR");

                entity.Property(e => e.CodInterv)
                    .HasColumnName("COD_INTERV")
                    .HasMaxLength(35);

                entity.Property(e => e.CodProcessamento)
                    .HasColumnName("COD_PROCESSAMENTO")
                    .HasMaxLength(200);

                entity.Property(e => e.CodSucursal).HasColumnName("COD_SUCURSAL");

                entity.Property(e => e.Contrato)
                    .HasColumnName("CONTRATO")
                    .HasMaxLength(20);

                entity.Property(e => e.Corretagem)
                    .HasColumnName("CORRETAGEM")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CusteioEmpresa)
                    .HasColumnName("CUSTEIO_EMPRESA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CusteioSegurado)
                    .HasColumnName("CUSTEIO_SEGURADO")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasColumnName("DESTINO")
                    .HasMaxLength(20);

                entity.Property(e => e.DiaMovimentacao).HasColumnName("DIA_MOVIMENTACAO");

                entity.Property(e => e.DiaVencimento).HasColumnName("DIA_VENCIMENTO");

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("DT_CRIACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtEmissao)
                    .HasColumnName("DT_EMISSAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtEtl)
                    .HasColumnName("DT_ETL")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFimVigencia)
                    .HasColumnName("DT_FIM_VIGENCIA")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtIniVigencia)
                    .HasColumnName("DT_INI_VIGENCIA")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUltimoProcessamento)
                    .HasColumnName("DT_ULTIMO_PROCESSAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gerente)
                    .HasColumnName("GERENTE")
                    .HasMaxLength(300);

                entity.Property(e => e.IdDeparaProduto).HasColumnName("ID_DEPARA_PRODUTO");

                entity.Property(e => e.IdadeMaxima).HasColumnName("IDADE_MAXIMA");

                entity.Property(e => e.LocalEvento)
                    .HasColumnName("LOCAL_EVENTO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mais71Anos).HasColumnName("MAIS_71_ANOS");

                entity.Property(e => e.Mais76Anos).HasColumnName("MAIS_76_ANOS");

                entity.Property(e => e.Multiplicador).HasColumnName("MULTIPLICADOR");

                entity.Property(e => e.NomeEvento)
                    .HasColumnName("NOME_EVENTO")
                    .HasMaxLength(200);

                entity.Property(e => e.NossoNumero)
                    .HasColumnName("NOSSO_NUMERO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumProposta)
                    .IsRequired()
                    .HasColumnName("NUM_PROPOSTA")
                    .HasMaxLength(30);

                entity.Property(e => e.NumTentativa).HasColumnName("NUM_TENTATIVA");

                entity.Property(e => e.Periodicidade)
                    .IsRequired()
                    .HasColumnName("PERIODICIDADE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProLabore)
                    .HasColumnName("PRO_LABORE")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Protocolo)
                    .IsRequired()
                    .HasColumnName("PROTOCOLO")
                    .HasMaxLength(30);

                entity.Property(e => e.QtdAfastados).HasColumnName("QTD_AFASTADOS");

                entity.Property(e => e.QtdAlunos).HasColumnName("QTD_ALUNOS");

                entity.Property(e => e.QtdAssociados).HasColumnName("QTD_ASSOCIADOS");

                entity.Property(e => e.QtdClientes).HasColumnName("QTD_CLIENTES");

                entity.Property(e => e.QtdDias).HasColumnName("QTD_DIAS");

                entity.Property(e => e.QtdDiretores).HasColumnName("QTD_DIRETORES");

                entity.Property(e => e.QtdEspectadores).HasColumnName("QTD_ESPECTADORES");

                entity.Property(e => e.QtdEstagiarios).HasColumnName("QTD_ESTAGIARIOS");

                entity.Property(e => e.QtdHoras).HasColumnName("QTD_HORAS");

                entity.Property(e => e.QtdInativas).HasColumnName("QTD_INATIVAS");

                entity.Property(e => e.QtdMotoboys).HasColumnName("QTD_MOTOBOYS");

                entity.Property(e => e.QtdNaoFuncionarios).HasColumnName("QTD_NAO_FUNCIONARIOS");

                entity.Property(e => e.QtdOrganizadores).HasColumnName("QTD_ORGANIZADORES");

                entity.Property(e => e.QtdOutros).HasColumnName("QTD_OUTROS");

                entity.Property(e => e.QtdParticipantes).HasColumnName("QTD_PARTICIPANTES");

                entity.Property(e => e.QtdPrestadores).HasColumnName("QTD_PRESTADORES");

                entity.Property(e => e.QtdSindicalizados).HasColumnName("QTD_SINDICALIZADOS");

                entity.Property(e => e.QtdSocios).HasColumnName("QTD_SOCIOS");

                entity.Property(e => e.SitEtl).HasColumnName("SIT_ETL");

                entity.Property(e => e.SitProcessamento).HasColumnName("SIT_PROCESSAMENTO");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Sucursal)
                    .HasColumnName("SUCURSAL")
                    .HasMaxLength(100);

                entity.Property(e => e.TipoAdesao)
                    .HasColumnName("TIPO_ADESAO")
                    .HasMaxLength(200);

                entity.Property(e => e.TipoCalculo)
                    .IsRequired()
                    .HasColumnName("TIPO_CALCULO")
                    .HasMaxLength(20);

                entity.Property(e => e.TipoCobranca)
                    .IsRequired()
                    .HasColumnName("TIPO_COBRANCA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCusteio)
                    .IsRequired()
                    .HasColumnName("TIPO_CUSTEIO")
                    .HasMaxLength(100);

                entity.Property(e => e.TipoEvento)
                    .HasColumnName("TIPO_EVENTO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalGrupos).HasColumnName("TOTAL_GRUPOS");

                entity.HasOne(d => d.IdDeparaProdutoNavigation)
                    .WithMany(p => p.Propostas)
                    .HasForeignKey(d => d.IdDeparaProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSTAS_ID_DEPARA_PROD");
            });
        }
    }
}
