using System.ComponentModel;

namespace Previsul.Components.Logging.Domain.Enums
{
    public enum ApplicationEnum : short
    {
        [Description("Cota +")]
        CotaMais = 1,

        [Description("Portal Corretor")]
        PortalCorretor = 2,

        [Description("Odonto +")]
        OdontoMais = 3
    }
}
