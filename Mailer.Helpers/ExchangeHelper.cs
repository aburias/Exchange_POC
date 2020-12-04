using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Mailer.Dtos;
using Mailer.Helpers.Interfaces;
using Microsoft.Exchange.WebServices.Data;

namespace Mailer.Helpers
{
    public class ExchangeHelper : IExchangeHelper
    {
        public async Task<bool> SendEmailAsync(string @from, string to, string subject, string body)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<EmailMessageDto>> GetEmailAsync(string email)
        {
            try
            {
                // Probably need to store credentials from Settings.
                var exchange = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                exchange.Credentials = new NetworkCredential("Email", "Password", "Domain");
                //exchange.AutodiscoverUrl("devmail@infiniteservices.org");
                exchange.Url = new Uri("https://mail.infiniteservices.org/EWS/Exchange.asmx");

                var results = exchange.FindItems(WellKnownFolderName.Inbox, new ItemView(10));

                var mails = new List<EmailMessageDto>();

                foreach (var item in results)
                {
                    var message = EmailMessage.Bind(exchange, item.Id);
                    var body = message.Body.Text;
                    var subject = message.Subject;
                    var from = message.From;
                    mails.Add(new EmailMessageDto()
                    {
                        To = email,
                        From = from.Address,
                        Subject = subject,
                        Body = body
                    });
                }

                return mails;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
