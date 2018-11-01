using Application.Domain.Entidades;
using Application.Domain.Interfaces;
using Application.Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Domain.Service
{
    public class ConfiguracaoPbsService : IConfiguracaoPbsService
    {
        public IPrevisulUnitOfWork PrevisulUnitOfWork { get; }

        public ConfiguracaoPbsService(IPrevisulUnitOfWork previsulUnitOfWork)
        {
            PrevisulUnitOfWork = previsulUnitOfWork ?? throw new ArgumentNullException(nameof(previsulUnitOfWork));
        }

        public static Dictionary<string, string> ConfiguracaoPbs { get; set; }

        public string Buscar(string chave)
        {
            if (ConfiguracaoPbs != null && ConfiguracaoPbs.Count > 0)
                return ConfiguracaoPbs[chave];

            try
            {
                var configuracoes = PrevisulUnitOfWork.Repositorio<ConfiguracaoPbs>()
                                        .Buscar()
                                        .AsNoTracking()
                                        .ToList();

                ConfiguracaoPbs = new Dictionary<string, string>();

                foreach (var config in configuracoes)
                    ConfiguracaoPbs.Add(config.Chave, config.Valor);
                
                return ConfiguracaoPbs[chave];

            }
            catch (Exception e)
            {
                ConfiguracaoPbs = null;
            }

            return null;
        }
    }
}
