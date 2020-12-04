using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Dtos;

namespace Mailer.Helpers.Interfaces
{
    public interface IExchangeHelper
    {
        Task<bool> SendEmailAsync(string from, string to, string subject, string body);
        Task<List<EmailMessageDto>> GetEmailAsync(string email);
    }
}