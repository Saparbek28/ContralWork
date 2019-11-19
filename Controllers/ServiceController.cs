using System.Threading.Tasks;
using DependencyInjectionLesson.DTOs;
using DependencyInjectionLesson.Services;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DependencyInjectionLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {

        private readonly IEntitySaverService entitySaverService;

        public ServiceController(IEntitySaverService entitySaverService)
        {
            this.entitySaverService = entitySaverService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveEntity(EntityDTO entity)
        {
            await entitySaverService.SaveEntity(entity);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(EmailMessageDTO emailMessage)
        {
            var emailService = new EmailSenderService();
            await emailService.SendEmail(emailMessage);
            return Ok();
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetCodeVerification(string phoneNumber)
        {
            var smsService = new SmsSenderService();
            await smsService.SendSms(phoneNumber);

            const string accountSid = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            const string authToken = "your_auth_token";

            TwilioClient.Init(accountSid, authToken);

            await MessageResource.CreateAsync(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber("+15558675310")
            );

            return Ok();
        }
    }
}