using OmanSMSGateway.iSmartSMS;
using System.Threading.Tasks;

namespace OmanSMSGateway.Interfaces.iSmartSMS
{
    public interface ISMSHandler
    {
        Task<SMSResponse> SendSMS(SMSRequest smsModel);
    }
}
