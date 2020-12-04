using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailer.Dtos;
using Mailer.Services.Interfaces;

namespace Mailer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpPost("sendemail")]
        public async Task<IActionResult> SendEmail([FromBody] EmailMessageDto mail)
        {
            try
            {
                await _exchangeService.SendEmailAsync(mail);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("getemails")]
        public async Task<IActionResult> GetEmails([FromBody] string email)
        {
            try
            {
                return Ok(await _exchangeService.GetEmailsAsync(email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
