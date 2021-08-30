using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WebHooks.Common.Enums;
using WebHooks.Common.Interfaces;
using WebHooks.Common.Models;

namespace WebHooks.Common.Extensions
{
    public static class WebHookServiceExtensions
    {
        public static void AddWebHooks(this IServiceCollection services)
        {
            services.AddTransient<IWebHookDefinitionContext, WebHookDefinitionContext>();
            services.AddSingleton<IWebHookDefinitionManager>(
                new WebHookDefinitionManager(new List<WebHookDefinition>
                {
                    new WebHookDefinition(nameof(WebHookDefinitionType.DocsReceived))
                }));



        }
    }
}
