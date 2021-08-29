using System;
using System.Threading.Tasks;
using WebHooks.Common.Interfaces;
using WebHooks.Common.Models;

namespace WebHooks
{
    class WebHookConsumer
    {
        private readonly IWebHooksConfiguration _webhooksConfiguration;
        private readonly IWebHookSubscriptionManager _webhookSubscriptionManager;
        private readonly IWebHookSendAttemptStore _webhookSendAttemptStore;
        private readonly IWebHookSender _webhookSender;
        public WebHookConsumer(
                    IWebHooksConfiguration webhooksConfiguration,
                    IWebHookSubscriptionManager webhookSubscriptionManager,
                    IWebHookSendAttemptStore webhookSendAttemptStore,
                    IWebHookSender webhookSender)
        {
            _webhooksConfiguration = webhooksConfiguration;
            _webhookSubscriptionManager = webhookSubscriptionManager;
            _webhookSendAttemptStore = webhookSendAttemptStore;
            _webhookSender = webhookSender;
        }

        public async Task ExecuteAsync(WebHookSenderArgs args)
        {
            if (args.TryOnce)
            {
                try
                {
                    await SendWebhook(args);
                }
                catch (Exception)
                {
                    //Logger.Warn("An error occured while sending webhook with try once.", e);
                    // ignored
                }
            }
            else
            {
                await SendWebhook(args);
            }
        }

        private async Task SendWebhook(WebHookSenderArgs args)
        {
            if (args.WebhookEventId == default)
            {
                return;
            }

            if (args.WebhookSubscriptionId == default)
            {
                return;
            }

            if (!args.TryOnce)
            {
                var sendAttemptCount = await _webhookSendAttemptStore.GetSendAttemptCountAsync(
                    args.TenantId,
                    args.WebhookEventId,
                    args.WebhookSubscriptionId
                );

                if (sendAttemptCount > _webhooksConfiguration.MaxSendAttemptCount)
                {
                    return;
                }
            }

            try
            {
                await _webhookSender.SendWebhookAsync(args);
            }
            catch (Exception)
            {
                // no need to retry to send webhook since subscription disabled
                if (!await TryDeactivateSubscriptionIfReachedMaxConsecutiveFailCount(
                        args.TenantId,
                        args.WebhookSubscriptionId))
                {
                    throw; //Throw exception to re-try sending webhook
                }
            }
        }

        private async Task<bool> TryDeactivateSubscriptionIfReachedMaxConsecutiveFailCount(int? tenantId,
            Guid subscriptionId)
        {
            if (!_webhooksConfiguration.IsAutomaticSubscriptionDeactivationEnabled)
            {
                return false;
            }

            var hasXConsecutiveFail = await _webhookSendAttemptStore
                .HasXConsecutiveFailAsync(
                    tenantId,
                    subscriptionId,
                    _webhooksConfiguration.MaxConsecutiveFailCountBeforeDeactivateSubscription
                );

            if (!hasXConsecutiveFail)
            {
                return false;
            }

            //using (var uow = UnitOfWorkManager.Begin(TransactionScopeOption.Required))
            //{
            //    await _webhookSubscriptionManager.ActivateWebhookSubscriptionAsync(subscriptionId, false);
            //    await uow.CompleteAsync();
            //    return true;
            //}

            return true;
        }
    }
}

