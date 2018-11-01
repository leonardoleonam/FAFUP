using System.Threading.Tasks;
using Previsul.Components.Logging.Domain.Model;

namespace Previsul.Components.Logging.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task<bool> InsertSync(LogEntry log);

        bool Insert(LogEntry log);
    }
}