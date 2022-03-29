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
            
            //services.AddiSmart

            services.AddiSmartSMSService(
                    new iSmartSMS.SMSCredentials()
                    {
                        Header = "Any",
                        UserId = "Any",
                        Password = "Any"
                    }
                );

            Console.WriteLine("Hello World!");

            sendSMS(services);
            Console.ReadLine();
        }

        private static async void sendSMS(IServiceCollection services)
        {
            var smsService = services.BuildServiceProvider().GetService<ISMSHandler>();
            var resp = await smsService
                            .SendSMS(
                                new SMSRequest()
                                {
                                    Language = Language.English,
                                    Message = "Hellow world",
                                    MobileNumbers = new List<string>() {
                                        "96893936914"
                                    }
                                }
                            );
            Console.WriteLine(resp);
        }
    }
}
