using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Dtos;

namespace Mailer.Services.Interfaces
{
    public interface IExchangeService
    {
        Task<bool> SendEmailAsync(EmailMessageDto mail);
        Task<List<EmailMessageDto>> GetEmailsAsync(string email);
    }
}