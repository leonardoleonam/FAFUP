using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    [XmlRoot("obterArquivoProposta")]
    class ArquivoProposta
    {
        [XmlElement("numeroProposta")]
        public int NumeroProposta;
    }
}
