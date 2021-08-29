namespace WebHooks.Common.Interfaces
{
    public interface IWebHookDefinitionContext
    {
        /// <summary>
        /// Gets the webhook definition manager.
        /// </summary>
        IWebHookDefinitionManager Manager { get; }
    }
}
