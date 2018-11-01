using RestSharp;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline.Handler
{
    public interface IPrevisulOnlineServiceHandler
    {
        IRestResponse Enviar(RestRequest restRequest);
    }
}