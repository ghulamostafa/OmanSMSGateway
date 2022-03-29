using System;
using System.Collections.Generic;

namespace OmanSMSGateway.iSmartSMS
{
    public class SMSRequest
    {
        public string Message { get; set; }
        public Language Language { get; set; }
        public List<string> MobileNumbers { get; set; }
        internal string PushDateTime { get { return DateTime.Now.ToString(); } }
    }

    public enum Language
    {
        English,
        Arabic
    }
}
