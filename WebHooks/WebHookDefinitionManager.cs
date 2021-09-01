using System.Collections.Generic;
using System.Threading.Tasks;
using WebHooks.Common.Exceptions;
using WebHooks.Common.Interfaces;
using WebHooks.Common.Models;

namespace WebHooks
{
    public class WebHookDefinitionManager : IWebHookDefinitionManager
    {

        private readonly IWebHooksConfiguration _webhooksConfiguration;
        private readonly Dictionary<string, WebHookDefinition> _webhookDefinitions;

        public WebHookDefinitionManager()
        {
            _webhookDefinitions = new Dictionary<string, WebHookDefinition>();
        }

        public void Initialize(IList<WebHookDefinition> webHookDefinitions)
        {
            foreach (var definition in webHookDefinitions)
            {
                Add(definition);
            }
        }

        public void Add(string webhookName)
        {
            if (_webhookDefinitions.ContainsKey(webhookName))
            {
                throw new WebHookInitializationException("There is already a webhook definition with given name: " + webhookName + ". Webhook names must be unique!");
            }

            _webhookDefinitions.Add(webhookName, new WebHookDefinition(webhookName));
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

            //Implementation of the feature dependency

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
