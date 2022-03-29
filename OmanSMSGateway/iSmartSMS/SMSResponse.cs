namespace OmanSMSGateway.iSmartSMS
{
    public class SMSResponse
    {
        public bool Success { get; internal set; }
        public string Message { get; internal set; }
        public int Code { get; internal set; }
    }
}
