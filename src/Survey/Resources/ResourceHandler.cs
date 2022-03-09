using System.Resources;

namespace Survey.Web.Resources
{
    public class ResourceHandler : IResourceHandler
    {
        public string GetMessage(string key)
        {
            var resourceManger = new ResourceManager(typeof(Resource));
            return resourceManger.GetString(key);
        }

    }
}
