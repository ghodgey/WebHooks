﻿using System;

namespace WebHooks.Common.Models
{
    public class WebhookEvent
    {
        /// <summary>
        /// Webhook unique name <see cref="WebhookDefinition.Name"/>
        /// </summary>
        public string WebhookName { get; set; }

        /// <summary>
        /// Webhook data as JSON string.
        /// </summary>
        public string Data { get; set; }

        public DateTime CreationTime { get; set; }

        public int? TenantId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
