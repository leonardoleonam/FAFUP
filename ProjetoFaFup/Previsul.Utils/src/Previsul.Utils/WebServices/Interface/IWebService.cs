using System.Net;

namespace Previsul.Utils.WebServices
{
    public interface IWebService
    {
        HttpWebResponse Call();
    }
}
