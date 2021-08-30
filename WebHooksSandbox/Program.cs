using Microsoft.Extensions.DependencyInjection;
using System;
using WebHooks.Common.Enums;
using WebHooks.Common.Extensions;
using WebHooks.Common.Interfaces;

namespace WebHooksSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting sandbox...");

            var services = new ServiceCollection();
            services.AddWebHooks();
            services.BuildServiceProvider();
            var serviceProvider = services.BuildServiceProvider();
            var webHookDefinitionManager = serviceProvider.GetService<IWebHookDefinitionManager>();

            var nameOfWebHookTest = webHookDefinitionManager.Get(nameof(WebHookDefinitionType));

        }
    }
}
