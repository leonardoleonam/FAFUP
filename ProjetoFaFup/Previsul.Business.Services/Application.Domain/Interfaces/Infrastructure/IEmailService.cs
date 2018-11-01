using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.Domain.Interfaces.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> EnviarEmail(MailMessage email);
    }
}
