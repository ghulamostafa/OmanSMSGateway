using OmanSMSGateway.Interfaces.iSmartSMS;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OmanSMSGateway.iSmartSMS
{
    public class SMSHandler : ISMSHandler
    {
        private readonly string _baseURL = "https://www.ismartsms.net/iBulkSMS/HttpWS/SMSDynamicRefIntlAPI.aspx";
        private readonly SMSCredentials _smsCredentials;
        private readonly HttpClient _httpClient;
        private readonly Dictionary<int, string> _responseCodes = new Dictionary<int, string>()
        {
            {0, "Unknown exception happened" },
            {1, "Message Pushed successfully." },
            {2, "Company Not Exits. Please check the company." },
            {3, "User or Password is wrong." },
            {4, "Credit is Low." },
            {5, "Message is blank." },
            {6, "Message Length Exceeded." },
            {7, "Account is Inactive." },
            {8, "Mobile No length is empty." },
            {9, "Invalid Mobile No." },
            {10, "Invalid Language." },
            {11, "Un Known Error." },
            {12, "Account is Blocked by administrator, concurrent failure of login." },
            {13, "Account Expired." },
            {14, "Credit Expired." },
            {15, "Invalid Http request or Parameter fields are wrong." },
            {16, "Invalid date time parameter." },
            {17, "Web Service user Id not registered." },
            {18, "User Not Register to use HTTP GET Method API." },
            {19, "Header Not registers with Infocomm." },
            {20, "Client IP Address has been blocked." },
        };

        public SMSHandler(SMSCredentials smsCredentials, HttpClient httpClient)
        {
            _smsCredentials = smsCredentials;
            _httpClient = httpClient;
        }

        public async Task<SMSResponse> SendSMS(SMSRequest smsModel)
        {
            var mobileNumbers = "";
            
            foreach (var mobileNumber in smsModel.MobileNumbers)
            {
                mobileNumbers += mobileNumber + ",";
            }

            mobileNumbers = mobileNumbers.Remove(mobileNumbers.Length - 1, 1);

            var payLoad = "?";
            payLoad += "UserId=" + _smsCredentials.UserId;
            payLoad += "&Password=" + _smsCredentials.Password;
            payLoad += "&Header=" + _smsCredentials.Header;
            payLoad += "&MobileNo=" + mobileNumbers;
            payLoad += "&Message=" + smsModel.Message;
            payLoad += "&PushDateTime=" + smsModel.PushDateTime;
            payLoad += "&Lang=" + (smsModel.Language == Language.Arabic ? "64" : "0");

            var response = await _httpClient.GetAsync(_baseURL + payLoad);
            var content = await response.Content.ReadAsStringAsync();
            var isValidCode = int.TryParse(content, out var code);
            
            return new SMSResponse()
            {
                Code = isValidCode ? code : 0,
                Message = _responseCodes[isValidCode ? code : 0],
                Success = code == 1,
            };
        }
    }
}
