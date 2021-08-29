using WebHooks.Common.Interfaces;

namespace WebHooks
{
    public class WebHookDefinitionContext : IWebHookDefinitionContext
    {
        public IWebHookDefinitionManager Manager { get; private set; }

        public WebHookDefinitionContext(IWebHookDefinitionManager manager)
        {
            Manager = manager;
        }
    }
}
