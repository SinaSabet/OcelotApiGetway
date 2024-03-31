using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PushNotiffication.Email.Common;

namespace PushNotiffication.Email.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly SmsRequest _smsRequest;
        public EmailController(SmsRequest smsRequest)
        {
                _smsRequest = smsRequest;
        }
        [HttpGet("[action]")]
        public IActionResult SendEmail()
        {
            SendMessage Send = new SendMessage();
            var result = Send.Send("sabetghadamsina03@gmail.com");


            return Ok(result);

        }
        [HttpGet("[action]")]

        public async  Task<IActionResult> SendSms()
        {
            var result = await _smsRequest.Send();


            return Ok(result);

        }


        [HttpGet("[action]")]
        public IActionResult Hc()
        {
          
            return Ok(new { status = "ok" });
        }

    }
}
