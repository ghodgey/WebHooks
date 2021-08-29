using System;
using System.Collections.Generic;
using WebHooks.Common.Models;

namespace WebHooks.Common.Extensions
{
    public static class WebHookSubscriptionInfoExtensions
    {
        /// <summary>
        /// Return List of subscribed webhooks definitions <see cref="WebhookSubscriptionInfo.Webhooks"/>
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSubscribedWebhooks(this WebHookSubscriptionInfo webhookSubscription)
        {
            if (webhookSubscription == null)
            {
                return new List<string>();
            }

            //return webhookSubscription.Webhooks.FromJsonString<List<string>>();
            return new List<string> { };
        }

        /// <summary>
        /// Adds webhook subscription to <see cref="WebhookSubscriptionInfo.Webhooks"/> if not exists
        /// </summary>
        /// <param name="webhookSubscription"></param>
        /// <param name="name">webhook unique name</param>
        public static void SubscribeWebhook(this WebHookSubscriptionInfo webhookSubscription, string name)
        {
            name = name.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), $"{nameof(name)} can not be null, empty or whitespace!");
            }

            var webhookDefinitions = webhookSubscription.GetSubscribedWebhooks();
            if (webhookDefinitions.Contains(name))
            {
                return;
            }

            webhookDefinitions.Add(name);
            //webhookSubscription.Webhooks = webhookDefinitions.ToJsonString();
        }

        /// <summary>
        ///  Removes webhook subscription from <see cref="WebhookSubscriptionInfo.Webhooks"/> if exists
        /// </summary>
        /// <param name="webhookSubscription"></param>
        /// <param name="name">webhook unique name</param>
        public static void UnsubscribeWebhook(this WebHookSubscriptionInfo webhookSubscription, string name)
        {
            name = name.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), $"{nameof(name)} can not be null, empty or whitespace!");
            }

            var webhookDefinitions = webhookSubscription.GetSubscribedWebhooks();
            if (!webhookDefinitions.Contains(name))
            {
                return;
            }

            webhookDefinitions.Remove(name);
            //webhookSubscription.Webhooks = webhookDefinitions.ToJsonString();
        }

        /// <summary>
        /// Clears all <see cref="WebhookSubscriptionInfo.Webhooks"/> 
        /// </summary>
        /// <param name="webhookSubscription"></param> 
        public static void RemoveAllSubscribedWebhooks(this WebHookSubscriptionInfo webhookSubscription)
        {
            webhookSubscription.Webhooks = null;
        }

        /// <summary>
        /// if subscribed to given webhook
        /// </summary>
        /// <returns></returns>
        public static bool IsSubscribed(this WebHookSubscriptionInfo webhookSubscription, string webhookName)
        {
            if (webhookSubscription == null)
            {
                return false;
            }

            return webhookSubscription.GetSubscribedWebhooks().Contains(webhookName);
        }

        /// <summary>
        /// Returns additional webhook headers <see cref="WebhookSubscriptionInfo.Headers"/>
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, string> GetWebhookHeaders(this WebHookSubscriptionInfo webhookSubscription)
        {
            if (webhookSubscription.Headers == null)
            {
                return new Dictionary<string, string>();
            }
            return new Dictionary<string, string>();

            //return webhookSubscription.Headers.FromJsonString<Dictionary<string, string>>();
        }

        /// <summary>
        /// Adds webhook subscription to <see cref="WebhookSubscriptionInfo.Webhooks"/> if not exists
        /// </summary>
        public static void AddWebhookHeader(this WebHookSubscriptionInfo webhookSubscription, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} can not be null, empty or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value), $"{nameof(value)} can not be null, empty or whitespace!");
            }

            var headers = webhookSubscription.GetWebhookHeaders();
            headers[key] = value;

            //webhookSubscription.Headers = headers.ToJsonString();
        }

        /// <summary>
        /// Adds webhook subscription to <see cref="WebhookSubscriptionInfo.Webhooks"/> if not exists
        /// </summary>
        /// <param name="webhookSubscription"></param>
        /// <param name="header">Key of header</param>
        public static void RemoveWebhookHeader(this WebHookSubscriptionInfo webhookSubscription, string header)
        {
            if (string.IsNullOrWhiteSpace(header))
            {
                throw new ArgumentNullException(nameof(header), $"{nameof(header)} can not be null, empty or whitespace!");
            }

            var headers = webhookSubscription.GetWebhookHeaders();

            if (!headers.ContainsKey(header))
            {
                return;
            }

            headers.Remove(header);

            //webhookSubscription.Headers = headers.ToJsonString();
        }

        /// <summary>
        /// Clears all <see cref="WebhookSubscriptionInfo.Webhooks"/> 
        /// </summary>
        /// <param name="webhookSubscription"></param> 
        public static void RemoveAllWebhookHeaders(this WebHookSubscriptionInfo webhookSubscription)
        {
            webhookSubscription.Headers = null;
        }

        public static WebHookSubscriptionInfo ToWebhookSubscriptionInfo(this WebHookSubscription webhookSubscription)
        {
            return new WebHookSubscriptionInfo
            {
                //Id = webhookSubscription.Id,
                TenantId = webhookSubscription.TenantId,
                IsActive = webhookSubscription.IsActive,
                Secret = webhookSubscription.Secret,
                WebhookUri = webhookSubscription.WebhookUri,
                //Webhooks = webhookSubscription.Webhooks.ToJsonString(),
                //Headers = webhookSubscription.Headers.ToJsonString()
            };
        }
    }
}
