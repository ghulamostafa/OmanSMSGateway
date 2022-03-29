using System;
using System.Collections.Generic;

namespace OmanSMSGateway.iSmartSMS
{
    public class SMSRequest
    {
        public SMSRequest(string message, List<string> mobileNumbers, Language language)
        {
            Message = message;
            MobileNumbers = mobileNumbers;
            Language = language;
        }

        public SMSRequest(string message, List<string> mobileNumbers, Language language, DateTime pushDateTime)
        {
            Message = message;
            MobileNumbers = mobileNumbers;
            Language = language;
            PushDateTime = pushDateTime.ToString();
        }

        public string Message { get; private set; }
        public Language Language { get; private set; }
        public List<string> MobileNumbers { get; private set; }
        public string PushDateTime { get; private set; } = DateTime.Now.ToString();
    }

    public enum Language
    {
        English,
        Arabic
    }
}
