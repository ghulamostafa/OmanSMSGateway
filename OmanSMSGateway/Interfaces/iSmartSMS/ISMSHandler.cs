using OmanSMSGateway.iSmartSMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmanSMSGateway.Interfaces.iSmartSMS
{
    public interface ISMSHandler
    {
        Task<SMSResponse> SendSMS(SMSRequest smsModel);
    }
}
