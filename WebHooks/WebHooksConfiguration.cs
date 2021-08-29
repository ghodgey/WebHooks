using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebHooks.Common.Interfaces;

namespace WebHooks
{
    internal class WebHooksConfiguration : IWebHooksConfiguration
    {
        public TimeSpan TimeoutDuration { get; set; } = TimeSpan.FromSeconds(60);

        public int MaxSendAttemptCount { get; set; } = 5;

        public IList<WebHookDefinitionProvider> Providers { get; }

        public JsonSerializerSettings JsonSerializerSettings { get; set; } = null;

        public bool IsAutomaticSubscriptionDeactivationEnabled { get; set; } = false;

        public int MaxConsecutiveFailCountBeforeDeactivateSubscription { get; set; }

        public WebHooksConfiguration()
        {
            Providers = new List<WebHookDefinitionProvider>();

            MaxConsecutiveFailCountBeforeDeactivateSubscription = MaxSendAttemptCount * 3; //deactivates subscription if 3 webhook can not be sent.
        }
    }
}
