using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebHooks.Common.Interfaces;
using WebHooks.Common.Models;

namespace WebHooks
{
    public class WebHookSubscriptionStore : IWebHookSubscriptionsStore
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public WebHookSubscriptionInfo Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<WebHookSubscriptionInfo> GetAllSubscriptions(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public List<WebHookSubscriptionInfo> GetAllSubscriptions(int? tenantId, string webhookName)
        {
            throw new NotImplementedException();
        }

        public Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsAsync(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsAsync(int? tenantId, string webhookName)
        {
            throw new NotImplementedException();
        }

        public List<WebHookSubscriptionInfo> GetAllSubscriptionsOfTenants(int?[] tenantIds)
        {
            throw new NotImplementedException();
        }

        public List<WebHookSubscriptionInfo> GetAllSubscriptionsOfTenants(int?[] tenantIds, string webhookName)
        {
            throw new NotImplementedException();
        }

        public Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsOfTenantsAsync(int?[] tenantIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsOfTenantsAsync(int?[] tenantIds, string webhookName)
        {
            throw new NotImplementedException();
        }

        public Task<WebHookSubscriptionInfo> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(WebHookSubscriptionInfo webhookSubscription)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(WebHookSubscriptionInfo webhookSubscription)
        {
            throw new NotImplementedException();
        }

        public bool IsSubscribed(int? tenantId, string webhookName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsSubscribedAsync(int? tenantId, string webhookName)
        {
            throw new NotImplementedException();
        }

        public void Update(WebHookSubscriptionInfo webhookSubscription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WebHookSubscriptionInfo webhookSubscription)
        {
            throw new NotImplementedException();
        }
    }
}
