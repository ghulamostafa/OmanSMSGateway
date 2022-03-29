using Microsoft.Extensions.DependencyInjection;
using OmanSMSGateway.Infrastructure;
using OmanSMSGateway.Interfaces.iSmartSMS;
using OmanSMSGateway.iSmartSMS;
using System;
using System.Collections.Generic;

namespace OmanSMSGateway.ExampleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Oman SMS Gateway!" + Environment.NewLine);

            IServiceCollection services = new ServiceCollection();

            //Begin: iSmart SMS

            services.AddiSmartSMSService(
                    new SMSCredentials()
                    {
                        Header = "Any",
                        UserId = "Any",
                        Password = "Any"
                    }
                );

            SendiSmartSMS(services);

            //End: iSmart SMS

            Console.ReadLine();
        }

        private static async void SendiSmartSMS(IServiceCollection services)
        {
            var smsService = services.BuildServiceProvider().GetService<ISMSHandler>();
            var resp = await smsService
                            .SendSMSAsync(new SMSRequest("Hello Oman", new List<string>() { "96893936914" }, Language.English));

            Console.WriteLine("Code: " + resp.Code);
            Console.WriteLine("Message: " + resp.Message);
            Console.WriteLine("Success: " + resp.Success);
        }
    }
}
