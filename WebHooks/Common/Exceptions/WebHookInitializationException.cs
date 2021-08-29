using System;

namespace WebHooks.Common.Exceptions
{
    public class WebHookInitializationException : Exception
    {
        public WebHookInitializationException()
        {
        }

        public WebHookInitializationException(string message)
            : base(message)
        {
        }
    }
}
