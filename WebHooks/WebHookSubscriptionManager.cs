using WebHooks.Common.Interfaces;

namespace WebHooks
{
    public class WebHookSubscriptionManager : IWebHookSubscriptionManager
    {
        private readonly IWebHookSubscriptionsStore _webHookSubscriptionStore;

        private readonly IWebHookDefinitionManager _webhookDefinitionManager;

        private const string WebhookSubscriptionSecretPrefix = "whs_";

        public WebHookSubscriptionManager(
            IWebHookDefinitionManager webhookDefinitionManager,
            IWebHookSubscriptionsStore webHookSubscriptionsStore)
        {
            _webhookDefinitionManager = webhookDefinitionManager;
            _webHookSubscriptionStore = webHookSubscriptionsStore;
        }

        //public virtual async Task<WebHookSubscription> GetAsync(Guid id)
        //{
        //    return (await WebhookSubscriptionsStore.GetAsync(id)).ToWebhookSubscription();
        //}

        //public virtual WebHookSubscription Get(Guid id)
        //{
        //    return WebhookSubscriptionsStore.Get(id).ToWebhookSubscription();
        //}

        //public virtual async Task<List<WebHookSubscription>> GetAllSubscriptionsAsync(int? tenantId)
        //{
        //    return (await WebhookSubscriptionsStore.GetAllSubscriptionsAsync(tenantId))
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual List<WebHookSubscription> GetAllSubscriptions(int? tenantId)
        //{
        //    return WebhookSubscriptionsStore.GetAllSubscriptions(tenantId)
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual async Task<List<WebHookSubscription>> GetAllSubscriptionsIfFeaturesGrantedAsync(int? tenantId, string webhookName)
        //{
        //    if (!await _webhookDefinitionManager.IsAvailableAsync(tenantId, webhookName))
        //    {
        //        return new List<WebHookSubscription>();
        //    }

        //    return (await WebhookSubscriptionsStore.GetAllSubscriptionsAsync(tenantId, webhookName))
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual List<WebHookSubscription> GetAllSubscriptionsIfFeaturesGranted(int? tenantId, string webhookName)
        //{
        //    if (!_webhookDefinitionManager.IsAvailable(tenantId, webhookName))
        //    {
        //        return new List<WebHookSubscription>();
        //    }

        //    return WebhookSubscriptionsStore.GetAllSubscriptions(tenantId, webhookName)
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual async Task<List<WebHookSubscription>> GetAllSubscriptionsOfTenantsAsync(int?[] tenantIds)
        //{
        //    return (await WebhookSubscriptionsStore.GetAllSubscriptionsOfTenantsAsync(tenantIds))
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual List<WebHookSubscription> GetAllSubscriptionsOfTenants(int?[] tenantIds)
        //{
        //    return WebhookSubscriptionsStore.GetAllSubscriptionsOfTenants(tenantIds)
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual async Task<List<WebHookSubscription>> GetAllSubscriptionsOfTenantsIfFeaturesGrantedAsync(int?[] tenantIds, string webhookName)
        //{
        //    var featureGrantedTenants = new List<int?>();
        //    foreach (var tenantId in tenantIds)
        //    {
        //        if (await _webhookDefinitionManager.IsAvailableAsync(tenantId, webhookName))
        //        {
        //            featureGrantedTenants.Add(tenantId);
        //        }
        //    }

        //    return (await WebhookSubscriptionsStore.GetAllSubscriptionsOfTenantsAsync(featureGrantedTenants.ToArray(), webhookName))
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual List<WebHookSubscription> GetAllSubscriptionsOfTenantsIfFeaturesGranted(int?[] tenantIds, string webhookName)
        //{
        //    var featureGrantedTenants = new List<int?>();
        //    foreach (var tenantId in tenantIds)
        //    {
        //        if (_webhookDefinitionManager.IsAvailable(tenantId, webhookName))
        //        {
        //            featureGrantedTenants.Add(tenantId);
        //        }
        //    }

        //    return WebhookSubscriptionsStore.GetAllSubscriptionsOfTenants(featureGrantedTenants.ToArray(), webhookName)
        //        .Select(subscriptionInfo => subscriptionInfo.ToWebhookSubscription()).ToList();
        //}

        //public virtual async Task<bool> IsSubscribedAsync(int? tenantId, string webhookName)
        //{
        //    if (!await _webhookDefinitionManager.IsAvailableAsync(tenantId, webhookName))
        //    {
        //        return false;
        //    }

        //    return await WebhookSubscriptionsStore.IsSubscribedAsync(tenantId, webhookName);
        //}

        //public virtual bool IsSubscribed(int? tenantId, string webhookName)
        //{
        //    if (!_webhookDefinitionManager.IsAvailable(tenantId, webhookName))
        //    {
        //        return false;
        //    }

        //    return WebhookSubscriptionsStore.IsSubscribed(tenantId, webhookName);
        //}

        //public virtual async Task AddOrUpdateSubscriptionAsync(WebHookSubscription webhookSubscription)
        //{
        //    await CheckIfPermissionsGrantedAsync(webhookSubscription);

        //    if (webhookSubscription.Id == default)
        //    {
        //        webhookSubscription.Id = _guidGenerator.Create();
        //        webhookSubscription.Secret = WebhookSubscriptionSecretPrefix + Guid.NewGuid().ToString("N");
        //        await WebhookSubscriptionsStore.InsertAsync(webhookSubscription.ToWebhookSubscriptionInfo());
        //    }
        //    else
        //    {
        //        var subscription = await WebhookSubscriptionsStore.GetAsync(webhookSubscription.Id);
        //        subscription.WebhookUri = webhookSubscription.WebhookUri;
        //        subscription.Webhooks = webhookSubscription.Webhooks.ToJsonString();
        //        subscription.Headers = webhookSubscription.Headers.ToJsonString();
        //        await WebhookSubscriptionsStore.UpdateAsync(subscription);
        //    }
        //}

        //public virtual void AddOrUpdateSubscription(WebHookSubscription webhookSubscription)
        //{
        //    CheckIfPermissionsGranted(webhookSubscription);

        //    if (webhookSubscription.Id == default)
        //    {
        //        webhookSubscription.Id = _guidGenerator.Create();
        //        webhookSubscription.Secret = WebhookSubscriptionSecretPrefix + Guid.NewGuid().ToString("N");
        //        WebhookSubscriptionsStore.Insert(webhookSubscription.ToWebhookSubscriptionInfo());
        //    }
        //    else
        //    {
        //        var subscription = WebhookSubscriptionsStore.Get(webhookSubscription.Id);
        //        subscription.WebhookUri = webhookSubscription.WebhookUri;
        //        subscription.Webhooks = webhookSubscription.Webhooks.ToJsonString();
        //        subscription.Headers = webhookSubscription.Headers.ToJsonString();
        //        WebhookSubscriptionsStore.Update(subscription);
        //    }
        //}

        //public virtual async Task ActivateWebhookSubscriptionAsync(Guid id, bool active)
        //{
        //    var webhookSubscription = await WebhookSubscriptionsStore.GetAsync(id);
        //    webhookSubscription.IsActive = active;
        //}

        //[UnitOfWork]
        //public virtual Task DeleteSubscriptionAsync(Guid id)
        //{
        //    return WebhookSubscriptionsStore.DeleteAsync(id);
        //}

        //[UnitOfWork]
        //public virtual void DeleteSubscription(Guid id)
        //{
        //    WebhookSubscriptionsStore.Delete(id);
        //}

        //[UnitOfWork]
        //public virtual async Task AddWebhookAsync(WebhookSubscriptionInfo subscription, string webhookName)
        //{
        //    await CheckPermissionsAsync(subscription.TenantId, webhookName);

        //    subscription.SubscribeWebhook(webhookName);
        //}

        //[UnitOfWork]
        //public virtual void AddWebhook(WebhookSubscriptionInfo subscription, string webhookName)
        //{
        //    CheckPermissions(subscription.TenantId, webhookName);

        //    subscription.SubscribeWebhook(webhookName);
        //}

        //protected virtual async Task CheckIfPermissionsGrantedAsync(WebhookSubscription webhookSubscription)
        //{
        //    if (webhookSubscription.Webhooks.IsNullOrEmpty())
        //    {
        //        return;
        //    }

        //    foreach (var webhookDefinition in webhookSubscription.Webhooks)
        //    {
        //        await CheckPermissionsAsync(webhookSubscription.TenantId, webhookDefinition);
        //    }
        //}

        //protected virtual async Task CheckPermissionsAsync(int? tenantId, string webhookName)
        //{
        //    if (!await _webhookDefinitionManager.IsAvailableAsync(tenantId, webhookName))
        //    {
        //        throw new AbpAuthorizationException($"Tenant \"{tenantId}\" must have necessary feature(s) to use webhook \"{webhookName}\"");
        //    }
        //}

        //protected virtual void CheckIfPermissionsGranted(WebhookSubscription webhookSubscription)
        //{
        //    if (webhookSubscription.Webhooks.IsNullOrEmpty())
        //    {
        //        return;
        //    }

        //    foreach (var webhookDefinition in webhookSubscription.Webhooks)
        //    {
        //        CheckPermissions(webhookSubscription.TenantId, webhookDefinition);
        //    }
        //}

        //protected virtual void CheckPermissions(int? tenantId, string webhookName)
        //{
        //    if (!_webhookDefinitionManager.IsAvailable(tenantId, webhookName))
        //    {
        //        throw new AbpAuthorizationException($"Tenant \"{tenantId}\" must have necessary feature(s) to use webhook \"{webhookName}\"");
        //    }
        //}

    }
}
