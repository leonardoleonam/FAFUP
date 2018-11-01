using System;
using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public class I4ProToken
    {
        public I4ProToken()
        {
            DataCriacao = DateTime.Now;
        }

        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }

        public DateTime DataCriacao { get; set; }

        public int TempoExpiracaoEmMinutos => 15;

        public bool TokenEhValido => DataCriacao.AddMinutes(TempoExpiracaoEmMinutos) >= DateTime.Now;
    }
}
