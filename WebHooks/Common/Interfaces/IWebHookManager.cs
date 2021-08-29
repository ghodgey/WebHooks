using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebHooks.Common.Models;

namespace WebHooks.Common.Interfaces
{
    public interface IWebHookManager
    {
        Task<WebHookPayload> GetWebhookPayloadAsync(WebHookSenderArgs webhookSenderArgs);

        WebHookPayload GetWebhookPayload(WebHookSenderArgs webhookSenderArgs);

        void SignWebhookRequest(HttpRequestMessage request, string serializedBody, string secret);

        string GetSerializedBody(WebHookSenderArgs webhookSenderArgs);

        Task<string> GetSerializedBodyAsync(WebHookSenderArgs webhookSenderArgs);

        Task<Guid> InsertAndGetIdWebhookSendAttemptAsync(WebHookSenderArgs webhookSenderArgs);

        Task StoreResponseOnWebhookSendAttemptAsync(
            Guid webhookSendAttemptId, int? tenantId,
            HttpStatusCode? statusCode, string content);
    }
}
