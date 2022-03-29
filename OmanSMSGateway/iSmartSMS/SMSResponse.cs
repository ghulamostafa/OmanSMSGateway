namespace OmanSMSGateway.iSmartSMS
{
    public class SMSResponse
    {
        public SMSResponse(bool success, int code, string message)
        {
            Success = success;
            Code = code;
            Message = message;
        }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public int Code { get; private set; }
    }
}
