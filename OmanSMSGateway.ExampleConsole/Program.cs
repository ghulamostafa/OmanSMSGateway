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
            IServiceCollection services = new ServiceCollection();

            services.AddiSmartSMSService(
                    new SMSCredentials()
                    {
                        Header = "Any",
                        UserId = "Any",
                        Password = "Any"
                    }
                );

            Console.WriteLine("Hello Oman SMS Gateway!" + Environment.NewLine);

            SendiSmartSMS(services);

            Console.ReadLine();
        }

        private static async void SendiSmartSMS(IServiceCollection services)
        {
            var smsService = services.BuildServiceProvider().GetService<ISMSHandler>();
            var resp = await smsService
                            .SendSMS(new SMSRequest("Hello Oman", new List<string>() { "96893936914" }, Language.English));

            Console.WriteLine("Code: " + resp.Code);
            Console.WriteLine("Message: " + resp.Message);
            Console.WriteLine("Success: " + resp.Success);
        }
    }
}
