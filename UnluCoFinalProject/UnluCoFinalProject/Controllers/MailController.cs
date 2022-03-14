using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Settings;
using UnluCoFinalProject.Service.Contract;

namespace UnluCoFinalProject.Controllers
{
    [ApiController]
    [Route("api/Mail")]
    public class MailController : ControllerBase
    {
        private readonly IEmailService mailService;
        public MailController(IEmailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            var jobId = BackgroundJob.Schedule(()=>  mailService.SendEmailAsync(request),TimeSpan.Zero);
            return Ok(jobId);
        }

    }
}