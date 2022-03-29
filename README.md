# SDK for Oman and Omani SMS Gateways

The purpose of this SDK is to help the developers easily integrate SMS service in their .NET projects. Currently SMS service providers share documentation which has the endpoints in terms of APIs and fresh developers struggle for integration.

For current release, it supports iSmart SMS from [Infocom](https://www.smsinfocomm.com/). Additional gateways will be added subsequently by the maintainer and community support is appreciated as well.

## Installation
The service for a provided SMS gateway is injected in the Startup class for .NET Core project as follows:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // iSmart SMS service registration
    services.AddiSmartSMSService(
            new SMSCredentials()
            {
                Header = "<shared_by_sms_service_provider>",
                UserId = "<shared_by_sms_service_provider>",
                Password = "<shared_by_sms_service_provider>"
            }
        );

    //Other services
}
```

## Usage
In the project, you may inject it in your service or controller class as follows:

```csharp
[Route("api/[controller]")]
[ApiController]
public class SMSController : ControllerBase
{
    private readonly ISMSHandler _smsHandler;

    public SMSController(ISMSHandler smsHandler)
    {
        _smsHandler = smsHandler;
    }
}
```

In your method, you can call `SendSMSAsync` as follows:

It takes `message` as `string`, `mobileNumbers` as `List<string>` and a `bool` for checking if it is in Arabic or not.

```csharp
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
```

## Message Length per Language

### English Messages:
* English 1 Part Message = 160 characters
* English 2 Part Message = 306 characters
* English 3 Part Message = 459 characters
* English 4 Part Message = 612 characters
* English 5 Part Message = 765 characters

### Arabic Messages:
* Arabic 1 Part Message = 70 characters
* Arabic 2 Part Message = 134 characters
* Arabic 3 Part Message = 201 characters
* Arabic 4 Part Message = 268 characters
* Arabic 5 Part Message = 335 characters
