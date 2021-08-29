using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace WebHooks.Common.Models
{
    public class WebhookSendAttempt
    {
        /// <summary>
        /// <see cref="WebhookEvent"/> foreign id 
        /// </summary>
        [Required]
        public Guid WebhookEventId { get; set; }

        /// <summary>
        /// <see cref="WebhookSubscription"/> foreign id 
        /// </summary>
        [Required]
        public Guid WebhookSubscriptionId { get; set; }

        /// <summary>
        /// Webhook response content that webhook endpoint send back
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Webhook response status code that webhook endpoint send back
        /// </summary>
        public HttpStatusCode? ResponseStatusCode { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// WebhookEvent of this send attempt.
        /// </summary>
        [ForeignKey("WebhookEventId")]
        public virtual WebhookEvent WebhookEvent { get; set; }
    }
}
