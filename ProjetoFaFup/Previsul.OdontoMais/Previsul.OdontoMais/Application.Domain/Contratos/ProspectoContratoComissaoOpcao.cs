using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Contratos
{
    public class ProspectoContratoComissaoOpcao
    {
        public ProspectoContratoComissaoOpcao()
        {            
        }

        public List<prospectoContratoComissaoOpcaoDTOList> prospectoContratoComissaoOpcaoDTOList { get; set; }
    }

    public class prospectoContratoComissaoOpcaoDTOList
    {
        public int Id { get; set; }

        public double PercentualComissao { get; set; }

        public double PercentualVitalicio { get; set; }
    }
}
