## Componente de Integração com I4PRO

### Objetivo
Realizar integração da Solicitação de Token para Emissão de Propostas - Geração de Documentos .pdf (Proposta & Condição Comercial)

### Exemplo de Utilização via REST
1. Utilizar a URL
  https://erp.previsul.com.br/i4proerp/erpws/Run/

2. Consumir o método "BuscarTokenAcesso" presente na classe AutenticadorTokenService que representa o serviço.
  Verificar dados de autenticação no PSI#3742

3. Utilizar o Token gerado no "header" do para execução dos métodos de Emissão de Propostas, por exemplo:

4. Consumir o método "EmitirApolice" presente na classe EmissorApoliceService que representa o serviço.
para emissão da apólice , é necessário que se envie como requestão os dados da apólice em formato Json.

5. Consumir o método "GerarDocumentosApolice" presente na classe GeradorDocumentosApoliceService que representa o serviço.
É necessário imformar como parâmetros de entrada codigoApolice , base64, nomeDocumento , representama respectivamente: o código da apólice para geração dos documentos, apólice em formato 64 e o nome do documento que se refere ao tipo, nesse caso a descrição  "pdf"   


```

```
