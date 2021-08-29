using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHooks.Common.Interfaces;
using WebHooks.Common.Models;

namespace WebHooks
{
    /// <summary>
    /// Add WebHook events to the queue for the WebHook consumer
    /// to try and send those events to the subscribers of those events 
    /// </summary>
    public class WebHookPublisher : IWebHookPublisher
    {
        private readonly IWebHookSubscriptionManager _webHookSubscriptionManager;
        public WebHookPublisher(IWebHookSubscriptionManager webHookSubscriptionManager)
        {
            _webHookSubscriptionManager = webHookSubscriptionManager;
        }


        public async Task PublishAsync(string webhookName, object data, int? tenantId, bool sendExactSameData = false)
        {
            //var subscriptions = await _webHookSubscriptionManager.GetAllSubscriptionsIfFeaturesGrantedAsync(tenantId, webhookName);
            //await PublishAsync(webhookName, data, subscriptions, sendExactSameData);
        }

        private async Task PublishAsync(string webhookName, object data, List<WebHookSubscription> webhookSubscriptions, bool sendExactSameData = false)
        {
            //if (webhookSubscriptions.IsNullOrEmpty())
            //{
            //    return;
            //}

            var subscriptionsGroupedByTenant = webhookSubscriptions.GroupBy(x => x.TenantId);

            foreach (var subscriptionGroupedByTenant in subscriptionsGroupedByTenant)
            {
                var webhookInfo = await SaveAndGetWebhookAsync(subscriptionGroupedByTenant.Key, webhookName, data);

                foreach (var webhookSubscription in subscriptionGroupedByTenant)
                {
                    //await _backgroundJobManager.EnqueueAsync<WebhookSenderJob, WebhookSenderArgs>(new WebhookSenderArgs
                    //{
                    //    TenantId = webhookSubscription.TenantId,
                    //    WebhookEventId = webhookInfo.Id,
                    //    Data = webhookInfo.Data,
                    //    WebhookName = webhookInfo.WebhookName,
                    //    WebhookSubscriptionId = webhookSubscription.Id,
                    //    Headers = webhookSubscription.Headers,
                    //    Secret = webhookSubscription.Secret,
                    //    WebhookUri = webhookSubscription.WebhookUri,
                    //    SendExactSameData = sendExactSameData
                    //});
                }
            }
        }

        protected virtual async Task<WebhookEvent> SaveAndGetWebhookAsync(int? tenantId, string webhookName, object data)
        {
            var webhookInfo = new WebhookEvent
            {
                //Id = _guidGenerator.Create(),
                //WebhookName = webhookName,
                //Data = _webhooksConfiguration.JsonSerializerSettings != null
                //    ? data.ToJsonString(_webhooksConfiguration.JsonSerializerSettings)
                //    : data.ToJsonString(),
                TenantId = tenantId
            };

            //await WebhookEventStore.InsertAndGetIdAsync(webhookInfo);
            return webhookInfo;
        }


    }
}
