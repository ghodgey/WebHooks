﻿using System.Collections.Generic;

namespace WebHooks.Common.Models
{
    public class WebHookSubscription
    {
        /// <summary>
        /// Tenant id of the subscribed
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// Subscription webhook endpoint
        /// </summary>
        public string WebhookUri { get; set; }

        /// <summary>
        /// Webhook secret
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Is subscription active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Subscribed webhook definitions unique names. <see cref="WebhookDefinition.Name"/>
        /// </summary>
        public List<string> Webhooks { get; set; }

        /// <summary>
        /// Gets a set of additional HTTP headers.That headers will be sent with the webhook
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }

        public WebHookSubscription()
        {
            IsActive = true;
            Headers = new Dictionary<string, string>();
            Webhooks = new List<string>();
        }
    }
}
