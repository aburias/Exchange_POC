using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Dtos;
using Mailer.Helpers.Interfaces;
using Mailer.Services.Interfaces;

namespace Mailer.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeHelper _exchangeHelper;

        public ExchangeService(IExchangeHelper exchangeHelper)
        {
            _exchangeHelper = exchangeHelper;
        }

        public async Task<bool> SendEmailAsync(EmailMessageDto mail)
        {
            return await _exchangeHelper.SendEmailAsync(mail.From, mail.To, mail.Subject, mail.Body);
        }

        public async Task<List<EmailMessageDto>> GetEmailsAsync(string email)
        {
            return await _exchangeHelper.GetEmailAsync(email);
        }
    }
}