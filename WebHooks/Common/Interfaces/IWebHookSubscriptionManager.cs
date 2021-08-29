using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebHooks.Common.Models;

namespace WebHooks.Common.Interfaces
{
    public interface IWebHookSubscriptionManager
    {
        public interface IWebhookSubscriptionManager
        {
            /// <summary>
            /// Returns subscription for given id. 
            /// </summary>
            /// <param name="id">Unique identifier of <see cref="WebhookSubscriptionInfo"/></param>
            Task<WebHookSubscription> GetAsync(Guid id);

            /// <summary>
            /// Returns subscription for given id. 
            /// </summary>
            /// <param name="id">Unique identifier of <see cref="WebhookSubscriptionInfo"/></param>
            WebHookSubscription Get(Guid id);

            /// <summary>
            /// Returns all subscriptions of tenant
            /// </summary>
            /// <param name="tenantId">
            /// Target tenant id.
            /// </param>
            Task<List<WebHookSubscription>> GetAllSubscriptionsAsync(int? tenantId);

            /// <summary>
            /// Returns all subscriptions of tenant
            /// </summary>
            /// <param name="tenantId">
            /// Target tenant id.
            /// </param>
            List<WebHookSubscription> GetAllSubscriptions(int? tenantId);

            /// <summary>
            /// Returns all subscriptions for given webhook.
            /// </summary>
            /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
            /// <param name="tenantId">
            /// Target tenant id.
            /// </param>
            Task<List<WebHookSubscription>> GetAllSubscriptionsIfFeaturesGrantedAsync(int? tenantId, string webhookName);

            /// <summary>
            /// Returns all subscriptions for given webhook.
            /// </summary>
            /// <param name="tenantId">
            /// Target tenant id.
            /// </param>
            /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
            List<WebHookSubscription> GetAllSubscriptionsIfFeaturesGranted(int? tenantId, string webhookName);

            /// <summary>
            /// Returns all subscriptions of tenant
            /// </summary>
            /// <returns></returns>
            Task<List<WebHookSubscription>> GetAllSubscriptionsOfTenantsAsync(int?[] tenantIds);

            /// <summary>
            /// Returns all subscriptions of tenant
            /// </summary>
            /// <param name="tenantIds">
            /// Target tenant id(s).
            /// </param>
            List<WebHookSubscription> GetAllSubscriptionsOfTenants(int?[] tenantIds);

            /// <summary>
            /// Returns all subscriptions for given webhook.
            /// </summary>
            /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
            /// <param name="tenantIds">
            /// Target tenant id(s).
            /// </param>
            Task<List<WebHookSubscription>> GetAllSubscriptionsOfTenantsIfFeaturesGrantedAsync(int?[] tenantIds, string webhookName);

            /// <summary>
            /// Returns all subscriptions for given webhook.
            /// </summary>
            /// <param name="tenantIds">
            /// Target tenant id(s).
            /// </param>
            /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
            List<WebHookSubscription> GetAllSubscriptionsOfTenantsIfFeaturesGranted(int?[] tenantIds, string webhookName);

            /// <summary>
            /// Checks if tenant subscribed for a webhook. (Checks if webhook features are granted)
            /// </summary>
            /// <param name="tenantId">
            /// Target tenant id(s).
            /// </param>
            /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
            Task<bool> IsSubscribedAsync(int? tenantId, string webhookName);

            /// <summary>
            /// Checks if tenant subscribed for a webhook. (Checks if webhook features are granted)
            /// </summary>
            /// <param name="tenantId">
            /// Target tenant id(s).
            /// </param>
            /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
            bool IsSubscribed(int? tenantId, string webhookName);

            /// <summary>
            /// If id is the default(Guid) adds new subscription, else updates current one. (Checks if webhook features are granted)
            /// </summary>
            Task AddOrUpdateSubscriptionAsync(WebHookSubscription webhookSubscription);

            /// <summary>
            /// If id is the default(Guid) adds it, else updates it. (Checks if webhook features are granted)
            /// </summary>
            void AddOrUpdateSubscription(WebHookSubscription webhookSubscription);

            /// <summary>
            /// Activates/Deactivates given webhook subscription
            /// </summary>
            /// <param name="id">unique identifier of <see cref="WebhookSubscriptionInfo"/></param>
            /// <param name="active">IsActive</param>
            Task ActivateWebhookSubscriptionAsync(Guid id, bool active);

            /// <summary>
            /// Delete given webhook subscription.
            /// </summary>
            /// <param name="id">unique identifier of <see cref="WebhookSubscriptionInfo"/></param>
            Task DeleteSubscriptionAsync(Guid id);

            /// <summary>
            /// Delete given webhook subscription.
            /// </summary>
            /// <param name="id">unique identifier of <see cref="WebhookSubscriptionInfo"/></param>
            void DeleteSubscription(Guid id);
        }
    }
}
