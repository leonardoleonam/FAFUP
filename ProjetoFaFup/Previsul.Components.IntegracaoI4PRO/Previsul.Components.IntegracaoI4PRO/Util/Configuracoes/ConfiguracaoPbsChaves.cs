namespace Application.Domain.Entidades
{
    public static class ConfiguracaoPbsChaves
    {
        //PROD
        //public const string PrevisulProxy = "webproxy.previsul.intranet";
        //public const string PrevisulPort = "80";
        //public const string PrevisulProxyHabilitado = "true";
        //public const string I4ProHost = "https://erp.previsul.com.br/i4proerp/erpws/Run/";
        //public const string I4ProBasicToken = "YXBwLmNvdGEubWFpczpQcmV2aXN1bEAyMDE4";        

        //DEV
        public const string PrevisulProxy = "webproxy.previsul.intranet";
        public const string PrevisulPort = "80";
        public const string PrevisulProxyHabilitado = "true";
        public const string I4ProHost = "http://200.10.245.238/i4pro/erpws/Run/";
        public const string I4ProBasicToken = "cmljYXJkby5tYXJjb3ZpY2hlOkBtdWRhcg==";        
    }
}