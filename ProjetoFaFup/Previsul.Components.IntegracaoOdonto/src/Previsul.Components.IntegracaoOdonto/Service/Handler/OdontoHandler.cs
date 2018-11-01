using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Previsul.Components.IntegracaoOdonto.Service.Handler
{
    public class OdontoHandler
    {
        public bool IsProduction { get; set; } = false;

        public OdontoHandler(){}

        public OdontoHandler(bool isProduction)
        {
            IsProduction = isProduction;
        }        

        private bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
        {
            // all Certificates are accepted
            return true;
        }

        //Todos os certificados serão aceito
        private bool GenericCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


        public HttpWebResponse CallWebService(string methodName, string parameters = "")
        {
            var soapTemplate = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:web=\"http://webservice.odontows.odonto.tempopar.com.br/\"> ";
            soapTemplate += "<soapenv:Header/>";
            soapTemplate += "<soapenv:Body>";
            soapTemplate += "<web:{0}>";
            soapTemplate += "{1}";
            soapTemplate += "</web:{0}>";
            soapTemplate += "</soapenv:Body>";
            soapTemplate += " </soapenv:Envelope>";

            ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

            Uri uri = new Uri("https://200.10.245.188/OdontoWS/ws/GestaoContratoPort?wsdl");

            ServicePointManager.ServerCertificateValidationCallback = GenericCertificate;

            var request = (HttpWebRequest)WebRequest.Create(uri);


            string username = "ou_ws_previsul";
            string password = "Caixa123*";
            string encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));            

            if (IsProduction)
            {
                request.Proxy = new WebProxy("webproxy.previsul.intranet", 80);
                request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            }

            string soapText = string.Format(soapTemplate, methodName, parameters);

            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes(soapText);
            request.Headers.Add("Authorization", "Basic " + encoded);

            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            var response = (HttpWebResponse)request.GetResponse();

            return response;
        }
    }
}
