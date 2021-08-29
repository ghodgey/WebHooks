using WebHooks.Common.Interfaces;

namespace WebHooks
{
    public abstract class WebHookDefinitionProvider
    {
        /// <summary>
        /// Used to add/manipulate webhook definitions.
        /// </summary>
        /// <param name="context">Context</param>,
        public abstract void SetWebHooks(IWebHookDefinitionContext context);
    }

}
