using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Settings;

namespace UnluCoFinalProject.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
