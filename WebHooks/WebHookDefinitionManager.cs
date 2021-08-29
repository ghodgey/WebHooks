using System.Collections.Generic;
using System.Threading.Tasks;
using WebHooks.Common.Exceptions;
using WebHooks.Common.Interfaces;
using WebHooks.Common.Models;

namespace WebHooks
{
    public class WebHookDefinitionManager
    {
        internal class WebhookDefinitionManager : IWebHookDefinitionManager
        {
            private readonly IWebHooksConfiguration _webhooksConfiguration;
            private readonly Dictionary<string, WebHookDefinition> _webhookDefinitions;

            public WebhookDefinitionManager(
                IWebHooksConfiguration webhooksConfiguration
                )
            {
                _webhooksConfiguration = webhooksConfiguration;
                _webhookDefinitions = new Dictionary<string, WebHookDefinition>();
            }

            public void Initialize()
            {
                var context = new WebHookDefinitionContext(this);

                foreach (var providerType in _webhooksConfiguration.Providers)
                {
                    //using (var provider = _iocManager.ResolveAsDisposable<WebhookDefinitionProvider>(providerType))
                    //{
                    //    provider.Object.SetWebhooks(context);
                    //}
                }
            }

            public void Add(WebHookDefinition webhookDefinition)
            {
                if (_webhookDefinitions.ContainsKey(webhookDefinition.Name))
                {
                    throw new WebHookInitializationException("There is already a webhook definition with given name: " + webhookDefinition.Name + ". Webhook names must be unique!");
                }

                _webhookDefinitions.Add(webhookDefinition.Name, webhookDefinition);
            }

            public WebHookDefinition GetOrNull(string name)
            {
                if (!_webhookDefinitions.ContainsKey(name))
                {
                    return null;
                }

                return _webhookDefinitions[name];
            }

            public WebHookDefinition Get(string name)
            {
                if (!_webhookDefinitions.ContainsKey(name))
                {
                    throw new KeyNotFoundException($"Webhook definitions does not contain a definition with the key \"{name}\".");
                }
                return _webhookDefinitions[name];
            }

            public IReadOnlyList<WebHookDefinition> GetAll()
            {
                return new List<WebHookDefinition> { };
            }

            public bool Remove(string name)
            {
                return _webhookDefinitions.Remove(name);
            }

            public bool Contains(string name)
            {
                return _webhookDefinitions.ContainsKey(name);
            }

            public async Task<bool> IsAvailableAsync(int? tenantId, string name)
            {
                if (tenantId == null) // host allowed to subscribe all webhooks
                {
                    return true;
                }

                var webhookDefinition = GetOrNull(name);

                if (webhookDefinition == null)
                {
                    return false;
                }

                //if (webhookDefinition.FeatureDependency == null)
                //{
                //    return true;
                //}

                //using (var featureDependencyContext = _iocManager.ResolveAsDisposable<FeatureDependencyContext>())
                //{
                //    featureDependencyContext.Object.TenantId = tenantId;

                //    if (!await webhookDefinition.FeatureDependency.IsSatisfiedAsync(featureDependencyContext.Object))
                //    {
                //        return false;
                //    }
                //}

                return true;
            }

            public bool IsAvailable(int? tenantId, string name)
            {
                if (tenantId == null) // host allowed to subscribe all webhooks
                {
                    return true;
                }

                var webhookDefinition = GetOrNull(name);

                if (webhookDefinition == null)
                {
                    return false;
                }

                //if (webhookDefinition.FeatureDependency == null)
                //{
                //    return true;
                //}

                //using (var featureDependencyContext = _iocManager.ResolveAsDisposable<FeatureDependencyContext>())
                //{
                //    featureDependencyContext.Object.TenantId = tenantId;

                //    if (!webhookDefinition.FeatureDependency.IsSatisfied(featureDependencyContext.Object))
                //    {
                //        return false;
                //    }
                //}

                return true;
            }
        }
    }
}
