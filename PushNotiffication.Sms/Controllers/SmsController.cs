using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PushNotiffication.Sms.Common;

namespace PushNotiffication.Sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult SendSms()
        {
            SendMessage Send = new SendMessage();
            var result = Send.Send("sabetghadamsina03@gmail.com");


            return Ok(result);

        }
    }
}
