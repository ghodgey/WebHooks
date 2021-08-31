using Microsoft.Extensions.DependencyInjection;
using System;
using WebHooks.Common.Interfaces;

namespace WebHooks.Common.Extensions
{
    public static class WebHookServiceExtensions
    {
        public static IServiceCollection AddWebHooks(this IServiceCollection services, Action<IWebHookDefinitionContext> webHookDefinitionContext)
        {
            services.AddTransient<IWebHookDefinitionContext, WebHookDefinitionContext>();
            services.AddSingleton<IWebHookDefinitionManager, WebHookDefinitionManager>();
            webHookDefinitionContext(new WebHookDefinitionContext(new WebHookDefinitionManager()));

            return services;
        }
    }
}
