using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmanSMSGateway.Interfaces.iSmartSMS;
using OmanSMSGateway.iSmartSMS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmanSMSGateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSHandler _smsHandler;

        public SMSController(ISMSHandler smsHandler)
        {
            _smsHandler = smsHandler;
        }

        [HttpPost]
        public async Task<ActionResult> SendSMS([FromQuery] string message, [FromQuery] string mobileNumbers, [FromQuery] bool isArabic)
        {
            var response = await _smsHandler
                                    .SendSMSAsync( 
                                        new SMSRequest(
                                            message, 
                                            new List<string>()
                                            {
                                                mobileNumbers
                                            }, 
                                            isArabic ? Language.Arabic : Language.English
                                        )
                                    );

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
