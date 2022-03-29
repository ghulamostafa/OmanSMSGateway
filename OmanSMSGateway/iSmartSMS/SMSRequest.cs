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
        public string Message { get; private set; }
        public Language Language { get; private set; }
        public List<string> MobileNumbers { get; private set; }
        internal string PushDateTime { get { return DateTime.Now.ToString(); } }
    }

    public enum Language
    {
        English,
        Arabic
    }
}
