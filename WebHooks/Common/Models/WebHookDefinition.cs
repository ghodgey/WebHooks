using System;

namespace WebHooks.Common.Models
{
    public class WebHookDefinition
    {
        /// <summary>
        /// Unique name of the webhook.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Display name of the webhook.
        /// Optional.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Description for the webhook.
        /// Optional.
        /// </summary>
        public string Description { get; set; }

        public WebHookDefinition(string name, string displayName = null, string description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name.Trim();
            DisplayName = displayName;
            Description = description;
        }
    }
}
