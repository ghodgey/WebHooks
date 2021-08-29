using System.Linq;
using WebHooks.Common.Models;

namespace WebHooks.Common.Extensions
{
    public static class WebHookSubscriptionExtensions
    {
        /// <summary>
        /// checks if subscribed to given webhook
        /// </summary>
        /// <returns></returns>
        public static bool IsSubscribed(this WebHookSubscription webhookSubscription, string webhookName)
        {
            if (webhookSubscription.Webhooks == null)
            {
                return false;
            }

            return webhookSubscription.Webhooks.Contains(webhookName);
        }
        public static WebHookSubscription ToWebhookSubscription(this WebHookSubscriptionInfo webhookSubscriptionInfo)
        {
            return new WebHookSubscription
            {
                //Id = webhookSubscriptionInfo.Id,
                TenantId = webhookSubscriptionInfo.TenantId,
                IsActive = webhookSubscriptionInfo.IsActive,
                Secret = webhookSubscriptionInfo.Secret,
                WebhookUri = webhookSubscriptionInfo.WebhookUri,
                Webhooks = webhookSubscriptionInfo.GetSubscribedWebhooks().ToList(),
                Headers = webhookSubscriptionInfo.GetWebhookHeaders()
            };
        }
    }
}
