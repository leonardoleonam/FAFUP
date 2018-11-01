using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.Infrastructure.Services
{
    public class RequestServiceOdontoHelper
    {
        readonly string urlBase = "https://200.10.245.140/OdontoWS/ws/GestaoContratoPort";
        readonly string username = "ou_ws_previsul";
        readonly string password = "Caixa123*";

        readonly string proxyUrl = "http://webproxy.previsul.intranet:80";
        readonly string proxyUser = "PREVISUL/PST34053";
        readonly string proxyPass = "Crow@50";
        readonly string proxyDomain = "previsul.intranet";

        string retornoResponse = "";

        public string Request(string xml, bool useProxy)
        {
            //configura certicado generico para SSL (https)
            ServicePointManager.ServerCertificateValidationCallback = GenericCertificate;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlBase);

            if (useProxy)
            {
                //configura proxy para rede Corp
                WebProxy proxy = new WebProxy(proxyUrl, true);
                proxy.Credentials = new NetworkCredential(proxyUser, proxyPass, proxyDomain);
                request.Proxy = proxy;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
            }

            //configura autenticação basica
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);

            //encoda xml que sera enviado para tipo byte
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(xml);

            //configura tipo do conteudo, tipo requisicao e tamanho do conteudo que sera enviado
            request.ContentType = "text/xml; encoding='utf-8'";
            request.Method = "POST";
            request.ContentLength = bytes.Length;

            //prepara conteudo que sera enviado 
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            //realiza requisicao e recupera o response
            try
            {
                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                retornoResponse = responseStr;
            }
            catch (WebException ex)
            {
                retornoResponse = ex.Message;
            }

            return retornoResponse;
        }

        //Todos os certificados serão aceito
        private static bool GenericCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

}
