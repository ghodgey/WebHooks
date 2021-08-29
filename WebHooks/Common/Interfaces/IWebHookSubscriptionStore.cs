using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebHooks.Common.Models;

namespace WebHooks.Common.Interfaces
{
    public interface IWebHookSubscriptionsStore
    {
        /// <summary>
        /// returns subscription
        /// </summary>
        /// <param name="id">webhook subscription id</param>
        /// <returns></returns>
        Task<WebHookSubscriptionInfo> GetAsync(Guid id);

        /// <summary>
        /// returns subscription
        /// </summary>
        /// <param name="id">webhook subscription id</param>
        /// <returns></returns>
        WebHookSubscriptionInfo Get(Guid id);

        /// <summary>
        /// Saves webhook subscription to a persistent store.
        /// </summary>
        /// <param name="webhookSubscription">webhook subscription information</param>
        Task InsertAsync(WebHookSubscriptionInfo webhookSubscription);

        /// <summary>
        /// Saves webhook subscription to a persistent store.
        /// </summary>
        /// <param name="webhookSubscription">webhook subscription information</param>
        void Insert(WebHookSubscriptionInfo webhookSubscription);

        /// <summary>
        /// Updates webhook subscription to a persistent store.
        /// </summary>
        /// <param name="webhookSubscription">webhook subscription information</param>
        Task UpdateAsync(WebHookSubscriptionInfo webhookSubscription);

        /// <summary>
        /// Updates webhook subscription to a persistent store.
        /// </summary>
        /// <param name="webhookSubscription">webhook subscription information</param>
        void Update(WebHookSubscriptionInfo webhookSubscription);

        /// <summary>
        /// Deletes subscription if exists
        /// </summary>
        /// <param name="id"><see cref="WebhookSubscriptionInfo"/> primary key</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Deletes subscription if exists 
        /// </summary>
        /// <param name="id"><see cref="WebhookSubscriptionInfo"/> primary key</param>
        /// <returns></returns>
        void Delete(Guid id);

        /// <summary>
        /// Returns all subscriptions of given tenant including deactivated 
        /// </summary>
        /// <param name="tenantId">
        /// Target tenant id.
        /// </param>
        Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsAsync(int? tenantId);

        /// <summary>
        /// Returns all subscriptions of given tenant including deactivated 
        /// </summary>
        /// <param name="tenantId">
        /// Target tenant id.
        /// </param>
        List<WebHookSubscriptionInfo> GetAllSubscriptions(int? tenantId);

        /// <summary>
        /// Returns webhook subscriptions which subscribe to given webhook on tenant(s)
        /// </summary>
        /// <param name="tenantId">
        /// Target tenant id.
        /// </param>
        /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
        /// <returns></returns>
        Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsAsync(int? tenantId, string webhookName);

        /// <summary>
        /// Returns webhook subscriptions which subscribe to given webhook on tenant(s)
        /// </summary>
        /// <param name="tenantId">
        /// Target tenant id.
        /// </param>
        /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
        /// <returns></returns>
        List<WebHookSubscriptionInfo> GetAllSubscriptions(int? tenantId, string webhookName);

        /// <summary>
        /// Returns all subscriptions of given tenant including deactivated 
        /// </summary>
        /// <param name="tenantIds">
        /// Target tenant id(s).
        /// </param>
        Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsOfTenantsAsync(int?[] tenantIds);

        /// <summary>
        /// Returns all subscriptions of given tenant including deactivated 
        /// </summary>
        /// <param name="tenantIds">
        /// Target tenant id(s).
        /// </param>
        List<WebHookSubscriptionInfo> GetAllSubscriptionsOfTenants(int?[] tenantIds);

        /// <summary>
        /// Returns webhook subscriptions which subscribe to given webhook on tenant(s)
        /// </summary>
        /// <param name="tenantIds">
        /// Target tenant id(s).
        /// </param>
        /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
        /// <returns></returns>
        Task<List<WebHookSubscriptionInfo>> GetAllSubscriptionsOfTenantsAsync(int?[] tenantIds, string webhookName);

        /// <summary>
        /// Returns webhook subscriptions which subscribe to given webhook on tenant(s)
        /// </summary>
        /// <param name="tenantIds">
        /// Target tenant id(s).
        /// </param>
        /// <param name="webhookName"><see cref="WebhookDefinition.Name"/></param>
        /// <returns></returns>
        List<WebHookSubscriptionInfo> GetAllSubscriptionsOfTenants(int?[] tenantIds, string webhookName);


        /// <summary>
        /// Checks if tenant subscribed for a webhook
        /// </summary>
        /// <param name="tenantId">
        /// Target tenant id(s).
        /// </param>
        /// <param name="webhookName">Name of the webhook</param>
        Task<bool> IsSubscribedAsync(int? tenantId, string webhookName);

        /// <summary>
        /// Checks if tenant subscribed for a webhook
        /// </summary>
        /// <param name="tenantId">
        /// Target tenant id(s).
        /// </param>
        /// <param name="webhookName">Name of the webhook</param>
        bool IsSubscribed(int? tenantId, string webhookName);
    }
}
