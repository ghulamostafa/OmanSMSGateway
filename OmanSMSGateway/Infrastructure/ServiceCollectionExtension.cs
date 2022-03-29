﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OmanSMSGateway.Interfaces.iSmartSMS;
using OmanSMSGateway.iSmartSMS;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace OmanSMSGateway.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddiSmartSMSService(this IServiceCollection services, SMSCredentials smsCredentials)
        {
            services.AddHttpClient("OmanNetClient", client =>
            {
                client.Timeout = TimeSpan.FromSeconds(240);
            });
            services.AddTransient<ISMSHandler>(ctx => {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("iSmartSMSClient");
                return new SMSHandler(smsCredentials, httpClient);
            });

            return services;
        }
    }
}