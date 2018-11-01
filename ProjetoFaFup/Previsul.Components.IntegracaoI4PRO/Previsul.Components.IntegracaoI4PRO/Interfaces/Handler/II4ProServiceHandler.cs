using RestSharp;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Handler
{
    public interface II4ProServiceHandler
    {
        IRestResponse Enviar(RestRequest restRequest);
    }
}