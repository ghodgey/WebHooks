using System.Collections.Generic;
using System.Threading.Tasks;
using WebHooks.Common.Models;

namespace WebHooks.Common.Interfaces
{
    public interface IWebHookDefinitionManager
    {
        /// <summary>
        /// Adds the specified webhook with only a name specified in the <seealso cref="WebHookDefinition"/>. Throws exception if it is already added
        /// </summary>
        void Add(string webhookName);

        /// <summary>
        /// Adds the specified webhook definition. Throws exception if it is already added
        /// </summary>
        void Add(WebHookDefinition webhookDefinition);

        /// <summary>
        /// Gets a webhook definition by name.
        /// Returns null if there is no webhook definition with given name.
        /// </summary>
        WebHookDefinition GetOrNull(string name);

        /// <summary>
        /// Gets a webhook definition by name.
        /// Throws exception if there is no webhook definition with given name.
        /// </summary>
        WebHookDefinition Get(string name);

        /// <summary>
        /// Gets all webhook definitions.
        /// </summary>
        IReadOnlyList<WebHookDefinition> GetAll();

        /// <summary>
        /// Remove webhook with given name
        /// </summary>
        /// <param name="name">webhook definition name</param>
        bool Remove(string name);

        /// <summary>
        /// Checks if webhook definitions contains given webhook name 
        /// </summary>
        bool Contains(string name);

        /// <summary>
        /// Checks if given webhook name is available for given tenant.
        /// </summary>
        Task<bool> IsAvailableAsync(int? tenantId, string name);

        /// <summary>
        /// Checks if given webhook name is available for given tenant.
        /// </summary>
        bool IsAvailable(int? tenantId, string name);
    }
}
