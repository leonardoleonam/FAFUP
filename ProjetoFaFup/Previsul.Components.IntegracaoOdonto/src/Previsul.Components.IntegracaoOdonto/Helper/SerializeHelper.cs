using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Previsul.Components.IntegracaoOdonto.Helper
{
    public static class SerializeHelper
    {
        public static string Serialize<T>(this T Obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(Obj.GetType());

            using (var sww = new StringWriter())
            {
                MemoryStream strm = new MemoryStream();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
                settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
                settings.CloseOutput = true;
                settings.Encoding = Encoding.Default;
                var xml = "";

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }); ns.Add("", "");

                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    try
                    {
                        writer.WriteStartDocument();
                        xsSubmit.Serialize(writer, Obj, ns);

                        return xml = sww.ToString();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        public static string GerarXmlInterno(this Dictionary<string, string> Parametros)
        {
            string parametersText;

            if (Parametros != null && Parametros.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (var Parametro in Parametros)
                    sb.AppendFormat("  <{0}>{1}</{0}>\r\n", Parametro.Key, Parametro.Value);

                parametersText = sb.ToString();
            }
            else
            {
                parametersText = "";
            }

            return parametersText;
        }
    }
}
